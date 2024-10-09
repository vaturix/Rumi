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
    public abstract class EditModalModelBase : TerminologyPageModel
    {
        [HiddenInput]
        [BindProperty(SupportsGet = true)]
        public Guid Id { get; set; }

        [BindProperty]
        public TermUpdateViewModel Term { get; set; }

        protected ITermsAppService _termsAppService;

        public EditModalModelBase(ITermsAppService termsAppService)
        {
            _termsAppService = termsAppService;

            Term = new();
        }

        public virtual async Task OnGetAsync()
        {
            var term = await _termsAppService.GetAsync(Id);
            Term = ObjectMapper.Map<TermDto, TermUpdateViewModel>(term);

        }

        public virtual async Task<NoContentResult> OnPostAsync()
        {

            await _termsAppService.UpdateAsync(Id, ObjectMapper.Map<TermUpdateViewModel, TermUpdateDto>(Term));
            return NoContent();
        }
    }

    public class TermUpdateViewModel : TermUpdateDto
    {
    }
}