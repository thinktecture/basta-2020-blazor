using System;
using System.Threading.Tasks;
using BastaLiveReal.Client.Services;
using BastaLiveReal.Shared.DTO;
using Microsoft.AspNetCore.Components;

namespace BastaLiveReal.Client.Pages
{
    public partial class Conference : ComponentBase
    {
        [Parameter]
        public Guid Id { get; set; }

        [Parameter]
        public string Mode { get; set; }

        [Inject]
        private ConferencesClientService _conferencesClient { get; set; }

        private ConferenceDetails _conferenceDetails;

        private bool _isShow;

        public Conference()
        {
            _conferenceDetails = new ConferenceDetails();
            _conferenceDetails.DateFrom = DateTime.UtcNow;
            _conferenceDetails.DateTo = DateTime.UtcNow;
        }

        protected override async Task OnInitializedAsync()
        {
            _isShow = Mode == ConferencesDetailsModes.Show;

            switch (Mode)
            {
                case ConferencesDetailsModes.Show:
                    var result = await _conferencesClient.GetConferenceDetailsAsync(Id);
                    _conferenceDetails = result;
                    break;
            }
        }

        private async Task SaveConference()
        {
            await _conferencesClient.AddConferenceAsync(_conferenceDetails);
            Console.WriteLine("NEW CONF ADDED...");
        }
    }
}
