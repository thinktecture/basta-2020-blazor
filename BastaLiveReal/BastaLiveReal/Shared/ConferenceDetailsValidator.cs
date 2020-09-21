using BastaLiveReal.Shared.DTO;
using FluentValidation;

namespace BastaLiveReal.Shared
{
    public class ConferenceDetailsValidator : AbstractValidator<ConferenceDetails>
    {
        public ConferenceDetailsValidator()
        {
            RuleFor(conference => conference.DateTo).GreaterThanOrEqualTo(
                conference => conference.DateFrom);
        }
    }
}
