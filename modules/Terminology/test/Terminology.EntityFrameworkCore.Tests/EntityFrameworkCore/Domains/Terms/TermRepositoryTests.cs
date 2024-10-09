using Shouldly;
using System;
using System.Linq;
using System.Threading.Tasks;
using Terminology.Terms;
using Terminology.EntityFrameworkCore;
using Xunit;

namespace Terminology.EntityFrameworkCore.Domains.Terms
{
    public class TermRepositoryTests : TerminologyEntityFrameworkCoreTestBase
    {
        private readonly ITermRepository _termRepository;

        public TermRepositoryTests()
        {
            _termRepository = GetRequiredService<ITermRepository>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Arrange
            await WithUnitOfWorkAsync(async () =>
            {
                // Act
                var result = await _termRepository.GetListAsync(
                    name: "22350b13baf",
                    description: "69f734f467304f79866c59278a4fdd5675058c3fbc8c4790aa618a2218bb4b9"
                );

                // Assert
                result.Count.ShouldBe(1);
                result.FirstOrDefault().ShouldNotBe(null);
                result.First().Id.ShouldBe(Guid.Parse("6e24a277-236f-4806-b7b5-c7c86dbf7e16"));
            });
        }

        [Fact]
        public async Task GetCountAsync()
        {
            // Arrange
            await WithUnitOfWorkAsync(async () =>
            {
                // Act
                var result = await _termRepository.GetCountAsync(
                    name: "3f1ce3684fc04d0",
                    description: "2d8edbccd2b74711ae92d29bbe3eb6ff22ac421ac2"
                );

                // Assert
                result.ShouldBe(1);
            });
        }
    }
}