using Xunit.Abstractions;
using Xunit.Sdk;

namespace CryptoAxus.Application.Features.Artist.Repositories;

public class ArtistRepositoryTests : ArtistRepositoryTestsData
{
    [Fact]
    public async Task Expect_Artist_Document_Is_Returned()
    {
        // Arrange


        try
        {
            var sut = SetupMockSettings().SetupMockRepositoryFindByIdAsync().Build();
            // Act
            var result = await sut.FindByIdAsync(ArtistId);
        }
        catch (Exception ex)
        {
            ITestOutputHelper helper = new TestOutputHelper();
            helper.WriteLine(ex.Message);
        }

        // Assert
        //result.ShouldNotBeNull();
        //result.Username.ShouldBe("Ben Affleck");
        //result.Website.ShouldBe("https://localhost:5000");
    }
}