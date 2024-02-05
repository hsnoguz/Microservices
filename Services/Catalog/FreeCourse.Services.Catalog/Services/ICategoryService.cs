using FreeCourse.Services.Catalog.Dtos;
using FreeCourse.Services.Catalog.Model;
using FreeCourse.Shared.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FreeCourse.Services.Catalog.Services
{
    public interface ICategoryService
    {
        Task<Response<List<CategoryDto>>> GetAllAsync();

        Task<Response<CategoryDto>> GeByIdAsync(string id);
        Task<Response<CategoryDto>> CreateAsync(CategoryDto category);
        Task<Response<CategoryDto>> GetResponseAsync(string id);
    }
}
