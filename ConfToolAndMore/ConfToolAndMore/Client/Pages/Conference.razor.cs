using System;
using System.Threading.Tasks;
using ConfToolAndMore.Client.Services;
using ConfToolAndMore.Shared.DTO;
using Microsoft.AspNetCore.Components;

namespace ConfToolAndMore.Client.Pages
{
    public partial class Conference : ComponentBase
    {
        [Parameter]
        public Guid Id { get; set; }

        [Parameter]
        public string Mode { get; set; }

        private bool _isShow { get; set; }

        [Inject]
        private ConferencesClientService _conferencesClient { get; set; }

        private ConferenceDetails _conferenceDetails = new ConferenceDetails();

        public Conference()
        {
            _conferenceDetails = new ConferenceDetails();
            _conferenceDetails.DateFrom = DateTime.UtcNow;
            _conferenceDetails.DateTo = DateTime.UtcNow;
        }

        protected override async Task OnInitializedAsync()
        {
            _isShow = Mode == ConferenceDetailsModes.Show;

            switch (Mode)
            {
                case ConferenceDetailsModes.Show:
                    var result = await _conferencesClient.GetConferenceDetailsAsync(Id);
                    _conferenceDetails = result;
                    break;
            }
        }
    }
}
