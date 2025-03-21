using MyWebApi.Net8.Model;
using MyWebApi.Net8.Repository.Base;
using MyWebApi.Net8.Repository.UnitOfWorks;
using Newtonsoft.Json;
using SqlSugar;

namespace MyWebApi.Net8.Repository
{
    public class UserRepository(IUnitOfWorkManage  unitOfWorkManage) : BaseRepository<User>(unitOfWorkManage) , IUserRepository
    {

    }
}
    