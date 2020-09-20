using System.Threading.Tasks;

namespace ConfToolAndMore.Client.Services
{
    public interface IAlertService
    {
        Task<bool> ConfirmAsync(string message);
        Task AlertAsync(string message);
    }
}
