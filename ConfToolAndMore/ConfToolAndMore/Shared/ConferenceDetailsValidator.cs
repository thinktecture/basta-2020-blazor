using ConfToolAndMore.Shared.DTO;
using FluentValidation;

namespace ConfToolAndMore.Shared
{
    public class ConferenceDetailsValidator : AbstractValidator<ConferenceDetails>
    {
        public ConferenceDetailsValidator()
        {
            RuleFor(conference => conference.DateTo).GreaterThanOrEqualTo(conference => conference.DateFrom);
        }
    }
}
