using AutoMapper;
using CEM.DAL.Entities;
using CEM.DAL.Repositories;
using CEM.Web.API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace CEM.Web.API.Controllers
{
    /// <summary>
    /// Employee Controller
    /// </summary>
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : BaseController<Employee>
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IRepositoryFor<Employee> repository;
        private readonly IMapper mapper;

        /// <summary>
        /// EmployeeController Constructor
        /// </summary>
        /// <param name="userManager"></param>
        /// <param name="repository"></param>
        /// <param name="mapper"></param>
        public EmployeeController(UserManager<ApplicationUser> userManager
            , IRepositoryFor<Employee> repository
            , IMapper mapper)
            : base(repository, mapper)
        {
            this.userManager = userManager;
            this.repository = repository;
        }

        /// <summary>
        /// Get list of Employees
        /// </summary>
        //[Authorize(Roles = UserRoles.HospitalList)]
        [HttpPost("list/dt", Order = 1)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetList([FromForm] DataTableParams param)
        {
            try
            {

                return Ok(new
                {
                    //param.draw,
                    //recordsTotal = paging.resultCount,
                    //recordsFiltered = paging.resultCount,
                    //data = response
                });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
