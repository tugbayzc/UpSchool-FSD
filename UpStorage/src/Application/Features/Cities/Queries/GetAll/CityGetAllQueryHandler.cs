using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace Application.Features.Cities.Queries.GetAll
{
    public class CityGetAllQueryHandler : IRequestHandler<CityGetAllQuery, List<CityGetAllDto>>
    //sorgularda response, spesifik bir mesaj dönmeye gerek yok!
    {
        private readonly IApplicationDbContext _applicationDbContext;
        private readonly IMemoryCache _memoryCache;
        private readonly MemoryCacheEntryOptions _cacheOptions;
        private const string CITIES_KEY = "CitiesList";

        public CityGetAllQueryHandler(IApplicationDbContext applicationDbContext, IMemoryCache memoryCache)
        {
            _applicationDbContext = applicationDbContext;

            _memoryCache = memoryCache;

            _cacheOptions=new MemoryCacheEntryOptions()
            {
                Priority= CacheItemPriority.Normal,
                AbsoluteExpiration = DateTimeOffset.Now.AddHours(6)
            };

        }

        public async Task<List<CityGetAllDto>> Handle(CityGetAllQuery request, CancellationToken cancellationToken)
        {
            if (_memoryCache.TryGetValue(CITIES_KEY,out List<CityGetAllDto> cachedCities))
            {
                return cachedCities;
            }
            var dbQuery = _applicationDbContext.Cities.AsQueryable();

            //dbQuery = dbQuery.Where(x => x.CountryId == request.CountryId);

            if (request.IsDeleted.HasValue) dbQuery = dbQuery.Where(x => x.IsDeleted == request.IsDeleted.Value);
            //üçüncü usecase girmeye izin verir! yani null verirsem bu ifi geçer hepsini getirir!

            dbQuery = dbQuery.Include(x => x.Country);

            var cities = await dbQuery
                .Select(x=> MapToDto(x))
                .ToListAsync(cancellationToken);
            //şehirler db den çekildi.


            _memoryCache.Set(CITIES_KEY, cities, _cacheOptions);

            return cities.ToList();
        }


        private static CityGetAllDto MapToDto(City city)
        {
            return new CityGetAllDto()
            {
                Id = city.Id,
                CountryId = city.CountryId,
                CountryName = city.Country.Name,
                Name = city.Name,
                IsDeleted = city.IsDeleted,
                Longitude = city.Longitude,
                Latitude = city.Latitude
            };
        }

        private IEnumerable<CityGetAllDto> MapCitiesToGetAllDtos(List<City> cities)
        //mapleme yaptık.
        {
            List<CityGetAllDto> cityGetAllDtos = new List<CityGetAllDto>();

            foreach (var city in cities)
            {
                yield return new CityGetAllDto()
                //sadece IEnumarable da çalışır! her döndüğünde listeye bir bir city leri atıyor. İşlemin ortasındayken!
                {
                    Id = city.Id,
                    CountryId = city.CountryId,

                    CountryName = city.Country.Name,
                    // bunu vermeseydik yukarıda null ref hatası alırdık! => dbQuery = dbQuery.Include(x => x.Country);

                    Name = city.Name,
                    IsDeleted = city.IsDeleted,
                    Longitude = city.Longitude,
                    Latitude = city.Latitude
                };
            }
        }        
    }
}