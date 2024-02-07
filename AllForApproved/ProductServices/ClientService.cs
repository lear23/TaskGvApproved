

using AllForApproved.ProductEntities;
using AllForApproved.ProductRepo;

namespace AllForApproved.ProductServices;

public class ClientService
{

    private readonly ClientsRepo _clientRepo;
    private readonly ReadersServices _readerService;
    private readonly DirectionService _directionService;

    public ClientService(ClientsRepo clientRepo, ReadersServices readerService, DirectionService directionService)
    {
        _clientRepo = clientRepo;
        _readerService = readerService;
        _directionService = directionService;
    }


    public ClientsEntity CreateClient(string firstName, string lastName, string readerName, string streetName, string postalCode, string city)
    {
        var readerEntity = _readerService.CreateReader(readerName);
        var directionEntity = _directionService.CreateDirection(streetName, postalCode, city);

        var clientEntity = new ClientsEntity
        {
            FirstName = firstName,
            LastName = lastName,
            ReaderId = readerEntity.Id,
            DirectionId = directionEntity.Id,
        };

         clientEntity = _clientRepo.Create(clientEntity);
        return clientEntity;
    }


    public ClientsEntity GetClientById(int Id)
    {
        var clientEntity = _clientRepo.Get(x => x.Id == Id);
        return clientEntity;
    }

    public IEnumerable<ClientsEntity> GetAllClients()
    {
        var clients = _clientRepo.GetAll();
        return clients;
    }

    public ClientsEntity UpdateCategory(ClientsEntity clientEntity)
    {
        var UpdateClientEntity = _clientRepo.Update(x => x.Id == clientEntity.Id, clientEntity);
        return UpdateClientEntity;
    }

    public void DeleteClient(int id)
    {
        _clientRepo.Delete(x => x.Id == id);
    }
}
