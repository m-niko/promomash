using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Promomash.Domain.CountryAggregate;
using Promomash.Infrastructure.Identity;

namespace Promomash.WebApp.Application.Features.User
{
    public class Create
    {
        public class Command : IRequest
        {
            public string Login { get; set; }
            public string Password { get; set; }
            public bool IsAgreeToWorkForFood { get; set; }
            public int ProvinceId { get; set; }
        }
        
        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(command => command.Login).EmailAddress();
                RuleFor(command => command.Password).NotEmpty();
                RuleFor(command => command.IsAgreeToWorkForFood).NotEqual(false);
                RuleFor(command => command.ProvinceId).NotEmpty();
            }
        }
        
        public class Handler : IRequestHandler<Command>
        {
            private readonly UserManager<Promomash.Infrastructure.Identity.User> _userManager;
            private readonly ICountryRepository _countryRepository;

            public Handler(UserManager<Promomash.Infrastructure.Identity.User> userManager, ICountryRepository countryRepository)
            {
                _userManager = userManager;
                _countryRepository = countryRepository;
            }
            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var province = await _countryRepository.GetProvinceByIdAsync(request.ProvinceId, cancellationToken);
                var user = new Promomash.Infrastructure.Identity.User(request.Login, province, request.IsAgreeToWorkForFood);

                var result = await _userManager.CreateAsync(user, request.Password);

                if (result.Succeeded) 
                    return Unit.Value;
                
                var message = string.Join('|', result.Errors.Select(err => $"{err.Code} - {err.Description}"));
                throw new ApplicationException(message);
            }
        }
    }
}