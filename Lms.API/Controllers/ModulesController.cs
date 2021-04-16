using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Lms.Data.Data;
using Lms.Core.Entities;
using Lms.Core.Repositories;
using AutoMapper;
using Lms.Core.Dto;

namespace Lms.API.Controllers
{
    [Route("api/courses/{id}/modules")]
    [ApiController]
    public class ModulesController : ControllerBase
    {

        private readonly IUoW uoW;
        private readonly IMapper mapper;

        public ModulesController(LmsAPIContext context, IUoW uoW, IMapper mapper)
        {
            this.uoW = uoW;
            this.mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<ModuleDto>> GetAllModulesAsync(int id)
        {
            if (await uoW.CourseRepository.GetCourseAsync(id) is null)
            {
                return BadRequest();
            }

            var modules = await uoW.ModuleRepository.GetAllModulesAsync(id);
            if (!(modules.Any()))
            {
                return NoContent();
            }
            var model = mapper.Map<IEnumerable<ModuleDto>>(modules);
            return Ok(model);
        }

        [HttpGet("{moduleId:int}")]
        public async Task<ActionResult<ModuleDto>> GetModuleAsync(int id, int moduleId)
        {
            if (await uoW.CourseRepository.GetCourseAsync(id) is null) return BadRequest();


            var module = await uoW.ModuleRepository.GetModuleAsync(id, moduleId);
            if (module is null)
            {
                return NotFound();
            }
            var model = mapper.Map<ModuleDto>(module);
            return Ok(model);
        }

    }
}
