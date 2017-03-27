using Xunit;

namespace Servant.Tests
{
    public sealed class PermutationExtensionsTests
    {
        [Fact]
        public void PermuteTest()
        {
            Assert.Equal(new[]
                {
                    new[] {1, 2, 3},
                    new[] {1, 3, 2},
                    new[] {2, 1, 3},
                    new[] {2, 3, 1},
                    new[] {3, 1, 2},
                    new[] {3, 2, 1}
                },
                new[] {1, 2, 3}.Permute());

            Assert.Equal(new[] {new[] {1}}, new[] {1}.Permute());
            Assert.Equal(new[] {new int[0]}, new int[0].Permute());
        }
    }
}