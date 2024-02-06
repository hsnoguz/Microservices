using Dapper;
using FreeCourse.Shared.Dtos;
using Microsoft.AspNetCore.Server.Kestrel.Core.Features;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace FreeCourse.Services.Discount.API.Services
{
    public class DiscountService : IDiscountService
    {
        private readonly IConfiguration _configuration;
        private readonly IDbConnection _dbConnection;

        public DiscountService(IConfiguration configuration)
        {
            _configuration = configuration;
            _dbConnection = new NpgsqlConnection(_configuration.GetConnectionString("PostreSql"));
        }

        public async Task<Response<NoContent>> Delete(int id)
        {
            var discount = (await _dbConnection.ExecuteAsync("delete from discount where id=@Id", new { Id = id }));

            return discount > 0 ? Response<NoContent>.Succes(204) : Response<NoContent>.Fail("Discount not found", 404);
        }

  

        public async Task<Response<List<Models.Discount>>> GetAll()
        {
            var discounts = await _dbConnection.QueryAsync<Models.Discount>("select * from discount");
            return Response<List<Models.Discount>>.Succes(discounts.ToList(),200);
        }

        public async Task<Response<Models.Discount>> GetByCodeAndUserId(string code, string userId)
        {
            var discount = (await _dbConnection.QueryAsync<Models.Discount>("select * from discount where code=@Code and userid = @UserId",
                new { Code = code, UserId = userId})).SingleOrDefault();

            if (discount == null)
            {
                return Response<Models.Discount>.Fail("Not Found", 404);
            }
            return Response<Models.Discount>.Succes(discount, 200);
        }

        public async Task<Response<Models.Discount>> GetById(int id)
        {
            var discount = (await _dbConnection.QueryAsync<Models.Discount>("select * from discount where id=@Id",new { Id = id })).SingleOrDefault();
            if (discount == null)
            {
                return Response<Models.Discount>.Fail("Not Found", 404);
            }
            return Response<Models.Discount>.Succes(discount, 200);
        }

        public async Task<Response<NoContent>> Save(Models.Discount discount)
        {
            var saveStatus =await _dbConnection.ExecuteAsync("INSERT INTO discount(userid,rate,code)  VALUES(@UserId,@Rate,@Code)", discount);
            if (saveStatus > 0)
            {
                return Response<NoContent>.Succes(204);
            }
            return Response<NoContent>.Fail("an error occurred while adding",500);
        }

        public async Task<Response<NoContent>> Update(Models.Discount discount)
        {
            var updateStatus = await _dbConnection.ExecuteAsync("UPDATE discount SET userid = @UserId,rate = @Rate,code = @Code WHERE id= @Id", new { 
                Id = discount.Id,
                Code = discount.Code,
                UserId = discount.UserId,
                Rate = discount.Rate,
            });

            if (updateStatus > 0)
            {
                return Response<NoContent>.Succes(204);
            }
            return Response<NoContent>.Fail("an error occurred while updating", 500);
        }
    }
}
