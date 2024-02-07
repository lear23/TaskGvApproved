

using AllForApproved.Entities;
using AllForApproved.Repositories;

namespace AllForApproved.Services;

public class UserService
{
    private readonly UserRepo _userRepo;

    public UserService(UserRepo userRepo)
    {
        _userRepo = userRepo;
    }

    public UserEntity CreateUser(string userName)
    {
        var userEntity = _userRepo.Get(x => x.UserName == userName);
        if (userEntity == null)
        {
            userEntity = _userRepo.Create(new UserEntity { UserName = userName });

        }
        return userEntity;

    }

    public UserEntity GetUserId(string userName)
    {
        var userEntity = _userRepo.Get(x => x.UserName == userName);
        return userEntity;
    }

    public IEnumerable<UserEntity> GetAllUsers()
    {
        var users = _userRepo.GetAll();
        return users;
    }

    public UserEntity UpdateCountry(UserEntity userEntity)
    {
        var UpdateUser = _userRepo.Update(x => x.UserName == userEntity.UserName, userEntity);
        return UpdateUser;
    }

    public void DeleteUser(int id)
    {
        _userRepo.Delete(x => x.Id == id);
    }

}
