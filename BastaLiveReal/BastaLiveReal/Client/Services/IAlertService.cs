using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BastaLiveReal.Client.Services
{
    public interface IAlertService
    {
        Task<bool> ConfirmAsync(string message);
        Task AlertAsync(string message);
    }
}
