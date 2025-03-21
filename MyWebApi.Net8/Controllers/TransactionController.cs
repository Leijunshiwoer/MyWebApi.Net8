﻿using Microsoft.AspNetCore.Mvc;
using MyWebApi.Net8.IServices;
using MyWebApi.Net8.Model;
using MyWebApi.Net8.Repository.UnitOfWorks;

namespace MyWebApi.Net8.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly IRoleService _roleService;
        private readonly IUserService _userService;
        private readonly IUnitOfWorkManage _unitOfWorkManage;

        public TransactionController(IRoleService roleService, IUserService userService, IUnitOfWorkManage unitOfWorkManage)
        {
            _roleService = roleService;
            _userService = userService;
            _unitOfWorkManage = unitOfWorkManage;
        }

        [HttpGet]
        public async Task<object> Get()
        {
            try
            {
                Console.WriteLine($"Begin Transaction");

                //_unitOfWorkManage.BeginTran();
                using var uow = _unitOfWorkManage.CreateUnitOfWork();
                var roles = await _roleService.Query();
                Console.WriteLine($"1 first time : the count of role is :{roles.Count}");


                Console.WriteLine($"insert a data into the table role now.");
                TimeSpan timeSpan = DateTime.Now.ToUniversalTime() - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
                var insertPassword = await _roleService.Add(new Role()
                {
                    Id = Convert.ToInt32(timeSpan.TotalSeconds),
                    IsDeleted = false,
                    Name = "role name",
                });

                var roles2 = await _roleService.Query();
                Console.WriteLine($"2 second time : the count of role is :{roles2.Count}");


                int ex = 0;
                Console.WriteLine($"There's an exception!!");
                Console.WriteLine($" ");
                int throwEx = 1 / ex;

                uow.Commit();
                //_unitOfWorkManage.CommitTran();
            }
            catch (Exception)
            {
              //  _unitOfWorkManage.RollbackTran();
                var roles3 = await _roleService.Query();
                Console.WriteLine($"3 third time : the count of role is :{roles3.Count}");
            }

            return "ok";
        }

        [HttpGet]
        public async Task<object> TestTranPropagation()
        {
             return await _userService.TestTranPropagation();
        }

    }
}
