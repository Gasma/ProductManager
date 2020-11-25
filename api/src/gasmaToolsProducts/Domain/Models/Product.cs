using gasmaToolsProducts.Domain.Models.Base;
using gasmaToolsProducts.Domain.Validators;
using gasmaToolsProducts.Helper;

namespace gasmaToolsProducts.Domain.Models
{
    public class Product : Entity
    {
        public string Name { get; private set; }
        public decimal Price { get; private set; }
        public string UrlPhoto { get; private set; }
        public string PhotoPublicId { get; private set; }
        public Product(long id, string name, decimal price) : this (name, price)
        {
            Id = id;
        }

        public Product(string name, decimal price)
        {
            Name = name;
            Price = price;
        }

        public override bool Validar()
        {
            return Validate(this, new ProductValidator());
        }

        public void Update(string name, decimal price, PhotoUploadResult photo)
        {
            Name = name;
            Price = price;
            UrlPhoto = photo?.Url;
            PhotoPublicId = photo?.PublicId;
            Validar();
        }

        public void AddPhoto(PhotoUploadResult photo)
        {
            UrlPhoto = photo?.Url;
            PhotoPublicId = photo?.PublicId;
            Validar();
        }
    }
}
