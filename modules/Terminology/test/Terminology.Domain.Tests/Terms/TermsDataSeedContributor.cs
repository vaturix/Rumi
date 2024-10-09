using System;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Uow;
using Terminology.Terms;

namespace Terminology.Terms
{
    public class TermsDataSeedContributor : IDataSeedContributor, ISingletonDependency
    {
        private bool IsSeeded = false;
        private readonly ITermRepository _termRepository;
        private readonly IUnitOfWorkManager _unitOfWorkManager;

        public TermsDataSeedContributor(ITermRepository termRepository, IUnitOfWorkManager unitOfWorkManager)
        {
            _termRepository = termRepository;
            _unitOfWorkManager = unitOfWorkManager;

        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (IsSeeded)
            {
                return;
            }

            await _termRepository.InsertAsync(new Term
            (
                id: Guid.Parse("6e24a277-236f-4806-b7b5-c7c86dbf7e16"),
                name: "22350b13baf",
                description: "69f734f467304f79866c59278a4fdd5675058c3fbc8c4790aa618a2218bb4b9"
            ));

            await _termRepository.InsertAsync(new Term
            (
                id: Guid.Parse("e0aacaf3-104f-410c-98ed-faeb0eee37ea"),
                name: "3f1ce3684fc04d0",
                description: "2d8edbccd2b74711ae92d29bbe3eb6ff22ac421ac2"
            ));

            await _unitOfWorkManager!.Current!.SaveChangesAsync();

            IsSeeded = true;
        }
    }
}