using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Content;
using Terminology.Shared;

namespace Terminology.Terms
{
    public partial interface ITermsAppService : IApplicationService
    {

        Task<PagedResultDto<TermDto>> GetListAsync(GetTermsInput input);

        Task<TermDto> GetAsync(Guid id);

        Task DeleteAsync(Guid id);

        Task<TermDto> CreateAsync(TermCreateDto input);

        Task<TermDto> UpdateAsync(Guid id, TermUpdateDto input);

        Task<IRemoteStreamContent> GetListAsExcelFileAsync(TermExcelDownloadDto input);
        Task DeleteByIdsAsync(List<Guid> termIds);

        Task DeleteAllAsync(GetTermsInput input);
        Task<Terminology.Shared.DownloadTokenResultDto> GetDownloadTokenAsync();

    }
}