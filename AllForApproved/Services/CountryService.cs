

using AllForApproved.Entities;
using AllForApproved.Repositories;

namespace AllForApproved.Services;

public class CountryService 
{
    private readonly CountryRepo _countryRepo;

    public CountryService(CountryRepo countryRepo
        )
    {
        _countryRepo = countryRepo;
    }


    public CountryEntity CreateCountry(string city, string country)
    {
        var countryEntity = _countryRepo.Get(x => x.City == city && x.Country== country );
        if (countryEntity == null)
        {
            countryEntity = _countryRepo.Create(new CountryEntity { City = city, Country = country });

        }
        return countryEntity;

    }


    public CountryEntity GetCountryId(int id)
    {
        var countryEntity = _countryRepo.Get(x => x.Id == id);
        return countryEntity;
    }

    public IEnumerable<CountryEntity> GetAllCountry()
    {
        var countries = _countryRepo.GetAll();
        return countries;
    }

    public CountryEntity UpdateCountry(CountryEntity countryEntity)
    {
        var Updatecountries = _countryRepo.Update(x => x.Id == countryEntity.Id,countryEntity);
        return Updatecountries;
    }


    public void DeleteCountry(int id)
    {
        _countryRepo.Delete(x => x.Id == id);
    }



}
