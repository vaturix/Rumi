using Volo.Abp.Application.Dtos;
using System;

namespace Terminology.Terms
{
    public abstract class TermExcelDownloadDtoBase
    {
        public string DownloadToken { get; set; } = null!;

        public string? FilterText { get; set; }

        public string? Name { get; set; }
        public string? Description { get; set; }

        public TermExcelDownloadDtoBase()
        {

        }
    }
}