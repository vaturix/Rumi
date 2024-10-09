using Terminology.Web.Pages.Terminology.Terms;
using Volo.Abp.AutoMapper;
using Terminology.Terms;
using AutoMapper;

namespace Terminology.Web;

public class TerminologyWebAutoMapperProfile : Profile
{
    public TerminologyWebAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */

        CreateMap<TermDto, TermUpdateViewModel>();
        CreateMap<TermUpdateViewModel, TermUpdateDto>();
        CreateMap<TermCreateViewModel, TermCreateDto>();
    }
}