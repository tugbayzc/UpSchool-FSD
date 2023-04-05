using MediatR;

namespace Application.Features.Cities.Queries.GetAll
{
    public class CityGetAllQuery:IRequest<List<CityGetAllDto>>
    //query sorgu olduğu için bir dto dönmeliyiz!
    {
        public int CountryId { get; set; }//zorunlu olmalı!
        public bool? IsDeleted { get; set; }//

        public CityGetAllQuery(int countryId, bool? isDeleted)
        {
            CountryId = countryId;

            IsDeleted = isDeleted;
        }
    }
}