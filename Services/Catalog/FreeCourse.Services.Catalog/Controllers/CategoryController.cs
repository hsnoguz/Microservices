using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using FreeCourse.Shared.ControllerBases;
using FreeCourse.Services.Catalog.Services;
using FreeCourse.Services.Catalog.Dtos;
using FreeCourse.Shared.Dtos;
using FreeCourse.Services.Catalog.Model;
using Microsoft.AspNetCore.Authorization;

namespace FreeCategory.Services.Catalog.Controllers
{
   
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : CustomBaseController
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            Response<List<CategoryDto>> response = await _categoryService.GetAllAsync();
            return CreateActionResultInstance(response);

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetbyId(string id)
        {
            Response<CategoryDto> response = await _categoryService.GeByIdAsync(id);
            return CreateActionResultInstance(response);

        }



        [HttpPost]
        public async Task<IActionResult> Create(CategoryDto categoryCreateDto)
        {
            Response<CategoryDto> response = await _categoryService.CreateAsync(categoryCreateDto);
            return CreateActionResultInstance(response);

        }

        //[HttpPut]
        //public async Task<IActionResult> Update(CategoryUpdateDto CategoryUpdateDto)
        //{
        //    Response<NoContent> response = await _categoryService.UpdateAsync(CategoryUpdateDto);
        //    return CreateActionResultInstance(response);

        //}

        //[HttpDelete("{id}")]
        //public async Task<IActionResult> Delete(string Id)
        //{
        //    if (Id is null)
        //    {
        //        throw new ArgumentNullException(nameof(Id));
        //    }

        //    Response<NoContent> response = await _categoryService.DeleteAsync(Id);
        //    return CreateActionResultInstance(response);

        //}
    }
}
