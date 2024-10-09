using Asp.Versioning;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using Terminology.Terms;

namespace Terminology.Terms
{
    [RemoteService(Name = "Terminology")]
    [Area("terminology")]
    [ControllerName("Term")]
    [Route("api/terminology/terms")]
    public class TermController : TermControllerBase, ITermsAppService
    {
        public TermController(ITermsAppService termsAppService) : base(termsAppService)
        {
        }
    }
}