using AutoMapper;
using MyWebApi.Net8.Model;


namespace MyWebApi.Net8.Extension
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<UserVo, User>().ForMember(a => a.Name, o => o.MapFrom(d => d.UserName)).ReverseMap();
            CreateMap<RoleVo, Role>().ForMember(a => a.Name, o => o.MapFrom(d => d.RoleName)).ReverseMap();
            CreateMap<DepartmentVo, Department>().ReverseMap();
            CreateMap<AuditSqlLogVo,AuditSqlLog>().ReverseMap();
        }
    }
}
