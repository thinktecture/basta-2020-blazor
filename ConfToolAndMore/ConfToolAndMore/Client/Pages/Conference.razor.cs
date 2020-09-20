using System;
using System.Collections.Generic;
using System.Linq;
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
        [Inject]
        private CountriesClientService _countriesClient { get; set; }
        [Inject]
        private IAlertService _alert { get; set; }

        private ConferenceDetails _conferenceDetails = new ConferenceDetails();
        private List<string> _countries;

        public Conference()
        {
            _conferenceDetails = new ConferenceDetails();
            _conferenceDetails.DateFrom = DateTime.UtcNow;
            _conferenceDetails.DateTo = DateTime.UtcNow;
            _countries = new List<string>();
        }

        protected override async Task OnInitializedAsync()
        {
            _isShow = Mode == ConferenceDetailsModes.Show;

            switch (Mode)
            {
                case ConferenceDetailsModes.Show:
                    var conferenceResult = await _conferencesClient.GetConferenceDetailsAsync(Id);
                    _conferenceDetails = conferenceResult;
                    break;
                case ConferenceDetailsModes.Edit:
                case ConferenceDetailsModes.New:
                    var countriesResult = await _countriesClient.ListCountriesAsync();
                    _countries = countriesResult;
                    _conferenceDetails.Country = _countries[0];
                    break;
            }
        }

        private async Task SaveConference()
        {
            if (!await _alert.ConfirmAsync("Do you want to save this new entry?"))
            {
                Console.WriteLine("### User declined to save conference!");
                return;
            }

            await _conferencesClient.AddConferenceAsync(_conferenceDetails);

            Console.WriteLine("NEW Conference added...");
        }

        private async Task<IEnumerable<string>> FilterCountries(string searchText)
        {
            return await Task.FromResult(_countries.Where(
                c => c.ToLower().Contains(searchText.ToLower())).ToList());
        }
    }
}
