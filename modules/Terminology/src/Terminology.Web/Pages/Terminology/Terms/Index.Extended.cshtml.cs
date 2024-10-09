using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Volo.Abp.Application.Dtos;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;
using Terminology.Terms;
using Terminology.Shared;

namespace Terminology.Web.Pages.Terminology.Terms
{
    public class IndexModel : IndexModelBase
    {
        public IndexModel(ITermsAppService termsAppService)
            : base(termsAppService)
        {
        }
    }
}