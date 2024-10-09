using System;
using Terminology.Shared;
using Volo.Abp.AutoMapper;
using Terminology.Terms;
using AutoMapper;

namespace Terminology;

public class TerminologyApplicationAutoMapperProfile : Profile
{
    public TerminologyApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */

        CreateMap<Term, TermDto>();
        CreateMap<Term, TermExcelDto>();
    }
}