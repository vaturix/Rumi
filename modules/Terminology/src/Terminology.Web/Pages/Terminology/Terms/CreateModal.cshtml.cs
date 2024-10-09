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
    public abstract class CreateModalModelBase : TerminologyPageModel
    {

        [BindProperty]
        public TermCreateViewModel Term { get; set; }

        protected ITermsAppService _termsAppService;

        public CreateModalModelBase(ITermsAppService termsAppService)
        {
            _termsAppService = termsAppService;

            Term = new();
        }

        public virtual async Task OnGetAsync()
        {
            Term = new TermCreateViewModel();

            await Task.CompletedTask;
        }

        public virtual async Task<IActionResult> OnPostAsync()
        {

            await _termsAppService.CreateAsync(ObjectMapper.Map<TermCreateViewModel, TermCreateDto>(Term));
            return NoContent();
        }
    }

    public class TermCreateViewModel : TermCreateDto
    {
    }
}