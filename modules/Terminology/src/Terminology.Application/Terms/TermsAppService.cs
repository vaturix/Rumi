using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Terminology.Permissions;
using Terminology.Terms;
using MiniExcelLibs;
using Volo.Abp.Content;
using Volo.Abp.Authorization;
using Volo.Abp.Caching;
using Microsoft.Extensions.Caching.Distributed;
using Terminology.Shared;

namespace Terminology.Terms
{

    [Authorize(TerminologyPermissions.Terms.Default)]
    public abstract class TermsAppServiceBase : TerminologyAppService
    {
        protected IDistributedCache<TermDownloadTokenCacheItem, string> _downloadTokenCache;
        protected ITermRepository _termRepository;
        protected TermManager _termManager;

        public TermsAppServiceBase(ITermRepository termRepository, TermManager termManager, IDistributedCache<TermDownloadTokenCacheItem, string> downloadTokenCache)
        {
            _downloadTokenCache = downloadTokenCache;
            _termRepository = termRepository;
            _termManager = termManager;

        }

        public virtual async Task<PagedResultDto<TermDto>> GetListAsync(GetTermsInput input)
        {
            var totalCount = await _termRepository.GetCountAsync(input.FilterText, input.Name, input.Description);
            var items = await _termRepository.GetListAsync(input.FilterText, input.Name, input.Description, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<TermDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<Term>, List<TermDto>>(items)
            };
        }

        public virtual async Task<TermDto> GetAsync(Guid id)
        {
            return ObjectMapper.Map<Term, TermDto>(await _termRepository.GetAsync(id));
        }

        [Authorize(TerminologyPermissions.Terms.Delete)]
        public virtual async Task DeleteAsync(Guid id)
        {
            await _termRepository.DeleteAsync(id);
        }

        [Authorize(TerminologyPermissions.Terms.Create)]
        public virtual async Task<TermDto> CreateAsync(TermCreateDto input)
        {

            var term = await _termManager.CreateAsync(
            input.Name, input.Description
            );

            return ObjectMapper.Map<Term, TermDto>(term);
        }

        [Authorize(TerminologyPermissions.Terms.Edit)]
        public virtual async Task<TermDto> UpdateAsync(Guid id, TermUpdateDto input)
        {

            var term = await _termManager.UpdateAsync(
            id,
            input.Name, input.Description, input.ConcurrencyStamp
            );

            return ObjectMapper.Map<Term, TermDto>(term);
        }

        [AllowAnonymous]
        public virtual async Task<IRemoteStreamContent> GetListAsExcelFileAsync(TermExcelDownloadDto input)
        {
            var downloadToken = await _downloadTokenCache.GetAsync(input.DownloadToken);
            if (downloadToken == null || input.DownloadToken != downloadToken.Token)
            {
                throw new AbpAuthorizationException("Invalid download token: " + input.DownloadToken);
            }

            var items = await _termRepository.GetListAsync(input.FilterText, input.Name, input.Description);

            var memoryStream = new MemoryStream();
            await memoryStream.SaveAsAsync(ObjectMapper.Map<List<Term>, List<TermExcelDto>>(items));
            memoryStream.Seek(0, SeekOrigin.Begin);

            return new RemoteStreamContent(memoryStream, "Terms.xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }

        [Authorize(TerminologyPermissions.Terms.Delete)]
        public virtual async Task DeleteByIdsAsync(List<Guid> termIds)
        {
            await _termRepository.DeleteManyAsync(termIds);
        }

        [Authorize(TerminologyPermissions.Terms.Delete)]
        public virtual async Task DeleteAllAsync(GetTermsInput input)
        {
            await _termRepository.DeleteAllAsync(input.FilterText, input.Name, input.Description);
        }
        public virtual async Task<Terminology.Shared.DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            var token = Guid.NewGuid().ToString("N");

            await _downloadTokenCache.SetAsync(
                token,
                new TermDownloadTokenCacheItem { Token = token },
                new DistributedCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(30)
                });

            return new Terminology.Shared.DownloadTokenResultDto
            {
                Token = token
            };
        }
    }
}