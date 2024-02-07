

using AllForApproved.ProductEntities;
using AllForApproved.ProductRepo;

namespace AllForApproved.ProductServices;

public class ReadersServices
{
    private readonly ReadersRepo _readersRepo;

    public ReadersServices(ReadersRepo readersRepo)
    {
        _readersRepo = readersRepo;
    }

    public ReadersEntity CreateReader(string readerName)
    {
        var readerEntity = _readersRepo.Get(x => x.ReaderName == readerName);

        if (readerEntity == null)
        {
            readerEntity = _readersRepo.Create(new ReadersEntity { ReaderName = readerName });

        }
        return readerEntity;

    }

    public ReadersEntity GetReaders(string readerName)
    {
        var readerEntity = _readersRepo.Get(x => x.ReaderName == readerName);
        return readerEntity;
    }
    public ReadersEntity GetReadersById(int Id)
    {
        var readerEntity = _readersRepo.Get(x => x.Id == Id);
        return readerEntity;
    }

    public IEnumerable<ReadersEntity> GetAllReaders()
    {
        var readers = _readersRepo.GetAll();
        return readers;
    }

    public ReadersEntity UpdateReader(ReadersEntity readerEntity)
    {
        if (readerEntity == null)
        {
            throw new ArgumentNullException(nameof(readerEntity), "The category entity cannot be null.");
        }

        // Call the Update method of the generic repository with the category entity

        var updateReader = _readersRepo.Update(readerEntity);

        return updateReader;
    }

    //public ReadersEntity UpdateReader(ReadersEntity readerEntity)
    //{
    //    var UpdateReaderEntity = _readersRepo.Update(x => x.Id == readerEntity.Id, readerEntity);
    //    return UpdateReaderEntity;
    //}

    public void DeleteReader(int id)
    {
        _readersRepo.Delete(x => x.Id == id);
    }


}
