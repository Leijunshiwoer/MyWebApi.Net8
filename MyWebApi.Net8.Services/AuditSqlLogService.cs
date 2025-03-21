using AutoMapper;
using MyWebApi.Net8.IServices;
using MyWebApi.Net8.Model;
using MyWebApi.Net8.Repository.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWebApi.Net8.Services
{
    public class AuditSqlLogService : BaseService<AuditSqlLog, AuditSqlLogVo>, IAuditSqlLogService
    {
        public AuditSqlLogService(IMapper mapper, IBaseRepository<AuditSqlLog> repository) : base(mapper, repository)
        {

        }
    }
}
