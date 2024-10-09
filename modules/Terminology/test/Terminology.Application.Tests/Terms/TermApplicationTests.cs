using System;
using System.Linq;
using Shouldly;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Modularity;
using Xunit;

namespace Terminology.Terms
{
    public abstract class TermsAppServiceTests<TStartupModule> : TerminologyApplicationTestBase<TStartupModule>
        where TStartupModule : IAbpModule
    {
        private readonly ITermsAppService _termsAppService;
        private readonly IRepository<Term, Guid> _termRepository;

        public TermsAppServiceTests()
        {
            _termsAppService = GetRequiredService<ITermsAppService>();
            _termRepository = GetRequiredService<IRepository<Term, Guid>>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Act
            var result = await _termsAppService.GetListAsync(new GetTermsInput());

            // Assert
            result.TotalCount.ShouldBe(2);
            result.Items.Count.ShouldBe(2);
            result.Items.Any(x => x.Id == Guid.Parse("6e24a277-236f-4806-b7b5-c7c86dbf7e16")).ShouldBe(true);
            result.Items.Any(x => x.Id == Guid.Parse("e0aacaf3-104f-410c-98ed-faeb0eee37ea")).ShouldBe(true);
        }

        [Fact]
        public async Task GetAsync()
        {
            // Act
            var result = await _termsAppService.GetAsync(Guid.Parse("6e24a277-236f-4806-b7b5-c7c86dbf7e16"));

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(Guid.Parse("6e24a277-236f-4806-b7b5-c7c86dbf7e16"));
        }

        [Fact]
        public async Task CreateAsync()
        {
            // Arrange
            var input = new TermCreateDto
            {
                Name = "d5f270a4bff3411e9959d7dc4ae56b2d6c99cfe6902d41ea89a3af2d4eb9",
                Description = "eeabb8f06369473c98ae3751ba88385b35dfcf9b0973400"
            };

            // Act
            var serviceResult = await _termsAppService.CreateAsync(input);

            // Assert
            var result = await _termRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.Name.ShouldBe("d5f270a4bff3411e9959d7dc4ae56b2d6c99cfe6902d41ea89a3af2d4eb9");
            result.Description.ShouldBe("eeabb8f06369473c98ae3751ba88385b35dfcf9b0973400");
        }

        [Fact]
        public async Task UpdateAsync()
        {
            // Arrange
            var input = new TermUpdateDto()
            {
                Name = "2f4fd9b8e4a94e4393fa7c031bb43c7f46c4b1cb86fd4d799f73c5c4781ffa8d07c42bbca691",
                Description = "00e219f08eb1480aa2f0dedbd1a29dfd5b49f935f5184235a4ead4cc97b356cc4cd15952198a49ca85bfa83cfccd33e675"
            };

            // Act
            var serviceResult = await _termsAppService.UpdateAsync(Guid.Parse("6e24a277-236f-4806-b7b5-c7c86dbf7e16"), input);

            // Assert
            var result = await _termRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.Name.ShouldBe("2f4fd9b8e4a94e4393fa7c031bb43c7f46c4b1cb86fd4d799f73c5c4781ffa8d07c42bbca691");
            result.Description.ShouldBe("00e219f08eb1480aa2f0dedbd1a29dfd5b49f935f5184235a4ead4cc97b356cc4cd15952198a49ca85bfa83cfccd33e675");
        }

        [Fact]
        public async Task DeleteAsync()
        {
            // Act
            await _termsAppService.DeleteAsync(Guid.Parse("6e24a277-236f-4806-b7b5-c7c86dbf7e16"));

            // Assert
            var result = await _termRepository.FindAsync(c => c.Id == Guid.Parse("6e24a277-236f-4806-b7b5-c7c86dbf7e16"));

            result.ShouldBeNull();
        }
    }
}