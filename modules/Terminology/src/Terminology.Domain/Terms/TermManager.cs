using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;
using Volo.Abp.Data;

namespace Terminology.Terms
{
    public abstract class TermManagerBase : DomainService
    {
        protected ITermRepository _termRepository;

        public TermManagerBase(ITermRepository termRepository)
        {
            _termRepository = termRepository;
        }

        public virtual async Task<Term> CreateAsync(
        string? name = null, string? description = null)
        {

            var term = new Term(
             GuidGenerator.Create(),
             name, description
             );

            return await _termRepository.InsertAsync(term);
        }

        public virtual async Task<Term> UpdateAsync(
            Guid id,
            string? name = null, string? description = null, [CanBeNull] string? concurrencyStamp = null
        )
        {

            var term = await _termRepository.GetAsync(id);

            term.Name = name;
            term.Description = description;

            term.SetConcurrencyStampIfNotNull(concurrencyStamp);
            return await _termRepository.UpdateAsync(term);
        }

    }
}