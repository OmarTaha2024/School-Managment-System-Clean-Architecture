using MediatR;
using Microsoft.Extensions.Localization;
using SchoolManagment.Core.Bases;
using SchoolManagment.Core.Features.Emails.Commands.Models;
using SchoolManagment.Core.Resources;
using SchoolManagment.Service.Abstracts;

namespace SchoolManagment.Core.Features.Emails.Commands.Handlers
{
    public class EmailCommandsHandler : ResponseHandler,
        IRequestHandler<SendEmailCommand, Response<string>>
    {
        #region Fields
        private readonly IStringLocalizer<SharedResources> _localizer;
        private readonly IEmailService _emailservice;

        #endregion
        #region Ctor
        public EmailCommandsHandler(IStringLocalizer<SharedResources> stringLocalizer, IEmailService emailservice) : base(stringLocalizer)
        {
            _localizer = stringLocalizer;
            _emailservice = emailservice;
        }
        #endregion
        #region Handle Function

        public async Task<Response<string>> Handle(SendEmailCommand request, CancellationToken cancellationToken)
        {
            var response = await _emailservice.SendEmailAsync(request.Email, request.Msg);
            if (response == "Success")
                return Success<string>("");
            return BadRequest<string>(_localizer[SharedResourcesKeys.SendEmailFailed]);
        }
        #endregion

    }
}
