using FluentAssertions;
using gasmaToolsProducts.Domain.Models;
using System.Linq;
using Xunit;

namespace gasmaToolsProducts.Test.Unit
{
    public class TestProduct
    {
        [Fact]
        public void Test_InstanceProduct_ShouldReturnValidProduct()
        {
            var product = new Product("Balão de Borracha", (decimal)15.90);
            product.Valid.Should().BeTrue();
        }

        [Fact]
        public void Test_InstanceProduct_ShouldReturnInValidProduct_WhenProductNoName()
        {
            var product = new Product(string.Empty, (decimal)15.90);
            product.Valid.Should().BeFalse();
        }

        [Fact]
        public void Test_InstanceProduct_ShouldReturnInValidProduct_WhenProductPriceIsZero()
        {
            var product = new Product("Balão de Decorado", 0);
            product.Valid.Should().BeFalse();
        }

        [Fact]
        public void Test_InstanceProduct_ShouldReturnInValidProduct_WhenNameExceedsMaxLength()
        {
            string name = string.Empty;

            for (int i = 0; i < 110; i++)
            {
                name += "a";
            }

            var product = new Product(name, (decimal)15.90);
            product.Valid.Should().BeFalse();
            Assert.Contains("Nome do Produto deve ter no maximo 100 caracteres.", product.ValidationResult.Errors.Select(x => x.ErrorMessage));
        }
    }
}
