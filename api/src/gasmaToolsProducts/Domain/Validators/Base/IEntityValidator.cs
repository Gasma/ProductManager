using gasmaToolsProducts.Domain.Models.Base;

namespace gasmaToolsProducts.Domain.Validators.Base
{
    public interface IEntityValidator
    {
        void Validate(params Entity[] entities);
    }
}
