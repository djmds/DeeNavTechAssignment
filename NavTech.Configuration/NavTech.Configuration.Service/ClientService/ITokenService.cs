using NavTech.Configuration.Models;
using System.Threading.Tasks;

namespace NavTech.Configuration.Service.ClientService
{
    public interface ITokenService
    {
        Task<string> GetAuthToken(BaseOptionModel baseOptionModel);
    }
}
