using Terminology.Shared;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using Volo.Abp.Application.Dtos;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Terminology.Terms;

namespace Terminology.Web.Pages.Terminology.Terms
{
    public class CreateModalModel : CreateModalModelBase
    {
        public CreateModalModel(ITermsAppService termsAppService)
            : base(termsAppService)
        {
        }
    }
}