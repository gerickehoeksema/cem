using AutoMapper;
using CEM.DAL.Entities;
using CEM.Web.API.Mappings;

namespace CEM.Web.API.Models
{
    /// <summary>
    /// Employee
    /// </summary>
    public class EmployeeModel : BaseModel, IMapFrom<Employee>
    {
        public long UserId { get; set; }
        public long? ImageId { get; set; }

        /// <summary>
        /// Map model to entity and reverse map
        /// </summary>
        /// <param name="profile"></param>
        public void Mapping(Profile profile)
        {
            profile.CreateMap<EmployeeModel, Employee>().ReverseMap();
        }
    }
}
