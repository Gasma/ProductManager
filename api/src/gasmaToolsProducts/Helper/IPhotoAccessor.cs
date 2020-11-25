using Microsoft.AspNetCore.Http;

namespace gasmaToolsProducts.Helper
{
    public interface IPhotoAccessor
    {
        PhotoUploadResult AddPhoto(IFormFile file);

        string DeletePhoto(string publicId);
    }
}
