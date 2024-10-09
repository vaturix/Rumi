using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using JetBrains.Annotations;

using Volo.Abp;

namespace Terminology.Terms
{
    public abstract class TermBase : FullAuditedAggregateRoot<Guid>
    {
        [CanBeNull]
        public virtual string? Name { get; set; }

        [CanBeNull]
        public virtual string? Description { get; set; }

        protected TermBase()
        {

        }

        public TermBase(Guid id, string? name = null, string? description = null)
        {

            Id = id;
            Name = name;
            Description = description;
        }

    }
}