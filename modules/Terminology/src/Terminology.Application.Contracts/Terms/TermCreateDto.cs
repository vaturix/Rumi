using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Terminology.Terms
{
    public abstract class TermCreateDtoBase
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
    }
}