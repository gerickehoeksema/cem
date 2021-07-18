using AutoMapper;
using CEM.DAL.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CEM.Web.API.Controllers
{
    /// <summary>
    /// Task Controller
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : BaseController<DAL.Entities.Task>
    {
        private readonly IRepositoryFor<DAL.Entities.Task> repository;
        private readonly IMapper mapper;

        /// <summary>
        /// TaskController Constructor
        /// </summary>
        /// <param name="repository"></param>
        /// <param name="mapper"></param>
        public TaskController(IRepositoryFor<DAL.Entities.Task> repository
            , IMapper mapper)
            : base(repository, mapper)
        {

        }
    }
}
