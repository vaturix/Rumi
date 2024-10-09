using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities;

namespace Terminology.Terms
{
    public abstract class TermUpdateDtoBase : IHasConcurrencyStamp
    {
        public string? Name { get; set; }
        public string? Description { get; set; }

        public string ConcurrencyStamp { get; set; } = null!;
    }
}