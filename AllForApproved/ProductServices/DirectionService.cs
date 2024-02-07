

using AllForApproved.ProductEntities;
using AllForApproved.ProductRepo;

namespace AllForApproved.ProductServices;

public class DirectionService
{
    private readonly DirectionRepo _directionRepo;

    public DirectionService(DirectionRepo directionRepo)
    {
        _directionRepo = directionRepo;
    }


    public DirectionsEntity CreateDirection(string streetName, string postalCode, string city)
    {
        var directionEntity = _directionRepo.Get(x => x.StreetName == streetName && x.PostalCode == postalCode && x.City == city);

        if (directionEntity == null)
        {
            directionEntity = _directionRepo.Create(new DirectionsEntity 
            { StreetName = streetName,
              PostalCode = postalCode,
              City = city
            });

        }
        return directionEntity;

    }

    public DirectionsEntity GetDirection(string streetName, string postalCode, string city)
    {
        var directionEntity = _directionRepo.Get(x => x.StreetName == streetName && x.PostalCode == postalCode && x.City == city);
        return directionEntity;
    }
    public DirectionsEntity GetDirectionById(int Id)
    {
        var directionEntity = _directionRepo.Get(x => x.Id == Id);
        return directionEntity;
    }

    public IEnumerable<DirectionsEntity> GetAllDirections()
    {
        var directions = _directionRepo.GetAll();
        return directions;
    }

    public DirectionsEntity UpdateDirection(DirectionsEntity directionEntity)
    {
        if (directionEntity == null)
        {
            throw new ArgumentNullException(nameof(directionEntity), "The category entity cannot be null.");
        }

        // Call the Update method of the generic repository with the category entity

        var updateDirection = _directionRepo.Update(directionEntity);

        return updateDirection;
    }

    //public DirectionsEntity UpdateDirectiony(DirectionsEntity directionEntity)
    //{
    //    var UpdateDirectionEntity = _directionRepo.Update(x => x.Id == directionEntity.Id, directionEntity);
    //    return UpdateDirectionEntity;
    //}

    public void DeleteDirection(int id)
    {
        _directionRepo.Delete(x => x.Id == id);
    }

}
