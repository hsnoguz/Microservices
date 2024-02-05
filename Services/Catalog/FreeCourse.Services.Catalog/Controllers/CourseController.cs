using FreeCourse.Services.Catalog.Dtos;
using FreeCourse.Services.Catalog.Services;
using FreeCourse.Shared.ControllerBases;
using FreeCourse.Shared.Dtos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FreeCourse.Services.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : CustomBaseController
    {
        private readonly ICourseService _courseService;

        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            Response<List<CourseDto>> response = await _courseService.GetAllAsyc();
            return CreateActionResultInstance(response);

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetbyId(string id)
        {
            Response<CourseDto> response =await _courseService.GetByIdAsync(id);
            return CreateActionResultInstance(response);

        }

        [HttpGet]
        [Route("/api/controller/GetAllByUserId/{userId}")]
        public async Task<IActionResult> GetAllByUserId(string userId)
        {
            Response<List<CourseDto>> response = await _courseService.GetByUserIdAsync(userId);
            return CreateActionResultInstance(response);

        }


        [HttpPost]
        public async Task<IActionResult> Create(CourseCreateDto courseCreateDto)
        {
            Response<CourseDto> response = await _courseService.CreateAsync(courseCreateDto);
            return CreateActionResultInstance(response);

        }

        [HttpPut]
        public async Task<IActionResult> Update(CourseUpdateDto courseUpdateDto)
        {
            Response<NoContent> response = await _courseService.UpdateAsync(courseUpdateDto);
            return CreateActionResultInstance(response);

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            if (id is null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            Response<NoContent> response = await _courseService.DeleteAsync(id);
            return CreateActionResultInstance(response);

        }

    }
}
