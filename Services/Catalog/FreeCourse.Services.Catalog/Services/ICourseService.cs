using AutoMapper;
using FreeCourse.Services.Catalog.Dtos;
using FreeCourse.Services.Catalog.Settings;
using FreeCourse.Shared.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FreeCourse.Services.Catalog.Services
{
    public interface ICourseService
    {
        public Task<Response<List<CourseDto>>> GetAllAsyc();
        public Task<Response<CourseDto>> GetByIdAsync(string id);
        public Task<Response<List<CourseDto>>> GetByUserIdAsync(string userId);

        public Task<Response<CourseDto>> CreateAsync(CourseCreateDto courseCreateDto);

        public Task<Response<NoContent>> UpdateAsync(CourseUpdateDto courseUpdateDto);

        public Task<Response<NoContent>> DeleteAsync(string id);
    }
}
