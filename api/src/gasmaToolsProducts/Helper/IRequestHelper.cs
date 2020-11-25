using System.Threading.Tasks;

namespace gasmaToolsProducts.Helper
{
    public interface IRequestHelper
    {
        Task<ResponseModel> SendRequest(string url, string pass, string user);
    }
}
