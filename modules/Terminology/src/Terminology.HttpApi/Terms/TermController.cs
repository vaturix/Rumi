using Asp.Versioning;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using Terminology.Terms;
using Volo.Abp.Content;
using Terminology.Shared;

namespace Terminology.Terms
{
    [RemoteService(Name = "Terminology")]
    [Area("terminology")]
    [ControllerName("Term")]
    [Route("api/terminology/terms")]
    public abstract class TermControllerBase : AbpController
    {
        protected ITermsAppService _termsAppService;

        public TermControllerBase(ITermsAppService termsAppService)
        {
            _termsAppService = termsAppService;
        }

        [HttpGet]
        public virtual Task<PagedResultDto<TermDto>> GetListAsync(GetTermsInput input)
        {
            return _termsAppService.GetListAsync(input);
        }

        [HttpGet]
        [Route("{id}")]
        public virtual Task<TermDto> GetAsync(Guid id)
        {
            return _termsAppService.GetAsync(id);
        }

        [HttpPost]
        public virtual Task<TermDto> CreateAsync(TermCreateDto input)
        {
            return _termsAppService.CreateAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public virtual Task<TermDto> UpdateAsync(Guid id, TermUpdateDto input)
        {
            return _termsAppService.UpdateAsync(id, input);
        }

        [HttpDelete]
        [Route("{id}")]
        public virtual Task DeleteAsync(Guid id)
        {
            return _termsAppService.DeleteAsync(id);
        }

        [HttpGet]
        [Route("as-excel-file")]
        public virtual Task<IRemoteStreamContent> GetListAsExcelFileAsync(TermExcelDownloadDto input)
        {
            return _termsAppService.GetListAsExcelFileAsync(input);
        }

        [HttpGet]
        [Route("download-token")]
        public virtual Task<Terminology.Shared.DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            return _termsAppService.GetDownloadTokenAsync();
        }

        [HttpDelete]
        [Route("")]
        public virtual Task DeleteByIdsAsync(List<Guid> termIds)
        {
            return _termsAppService.DeleteByIdsAsync(termIds);
        }

        [HttpDelete]
        [Route("all")]
        public virtual Task DeleteAllAsync(GetTermsInput input)
        {
            return _termsAppService.DeleteAllAsync(input);
        }
    }
}