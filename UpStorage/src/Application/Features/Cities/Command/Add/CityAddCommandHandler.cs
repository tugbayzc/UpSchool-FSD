using Application.Common.Interfaces;
using Application.Common.Localizations;
using Domain.Common;
using Domain.Entities;
using Domain.Extensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;

namespace Application.Features.Cities.Command.Add
{
    public class CityAddCommandHandler:IRequestHandler<CityAddCommand,Response<int>>
        //Mediator buradan anlayacak nereye gideceğini!
    {
        private readonly IApplicationDbContext _applicationDbContext;
        private readonly IStringLocalizer<CommonLocalizations> _localizer;

        public CityAddCommandHandler(IApplicationDbContext applicationDbContext, IStringLocalizer<CommonLocalizations> localizer)
        {
            _applicationDbContext = applicationDbContext;
            _localizer = localizer;
        }
        
        public async Task<Response<int>> Handle(CityAddCommand request, CancellationToken cancellationToken)
        {

            var city = new City()
            {
                Name = request.Name,
                CountryId = request.CountryId,
                Latitude = request.Latitude,
                Longitude = request.Longitude,
                CreatedOn = DateTimeOffset.Now,
                CreatedByUserId = null,
                IsDeleted = false
            };

            await _applicationDbContext.Cities.AddAsync(city, cancellationToken);

            await _applicationDbContext.SaveChangesAsync(cancellationToken);
            //savechanges yapmadan db ye hiçbir şey gitmez!

            return new Response<int>(_localizer[CommonLocalizationKeys.City.Added,city.Name],city.Id);
        }
    }
}