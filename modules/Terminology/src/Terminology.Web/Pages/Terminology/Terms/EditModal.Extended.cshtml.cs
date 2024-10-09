using Terminology.Shared;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Volo.Abp.Application.Dtos;
using Terminology.Terms;

namespace Terminology.Web.Pages.Terminology.Terms
{
    public class EditModalModel : EditModalModelBase
    {
        public EditModalModel(ITermsAppService termsAppService)
            : base(termsAppService)
        {
        }
    }
}