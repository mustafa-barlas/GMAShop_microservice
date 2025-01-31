using Dapper;
using GMAShop.Discount.Context;
using GMAShop.Discount.Dtos;

namespace GMAShop.Discount.Services;

public class DiscountService(DapperContext dapperContext) : IDiscountService
{
    public async Task<List<ResultDiscountCouponDto>> GetAllDiscountCouponAsync()
    {
        string query = "select * from coupons";

        using (var connection = dapperContext.CreateConnection())
        {
            var values = await connection.QueryAsync<ResultDiscountCouponDto>(query);
            return values.ToList();
        }
    }

    public async Task CreateDiscountCouponAsync(CreateDiscountCouponDto createCouponDto)
    {
        string query = "insert into coupons (Code,Rate,IsActive,ValidDate) values (@Code,@Rate,@IsActive,@ValidDate)";
        var parameters = new DynamicParameters();
        parameters.Add("@code", createCouponDto.Code);
        parameters.Add("@Rate", createCouponDto.Rate);
        parameters.Add("@IsActive", createCouponDto.IsActive);
        parameters.Add("@ValidDate", createCouponDto.ValidDate);

        using (var connection = dapperContext.CreateConnection())
        {
            await connection.ExecuteAsync(query, parameters);
        }
    }

    public async Task UpdateDiscountCouponAsync(UpdateDiscountCouponDto updateCouponDto)
    {
        string query =
            "update  coupons set  Code=@Code,Rate=@Rate,IsActive=@IsActive,ValidDate=@ValidDate where CouponId=@CouponId";
        var parameters = new DynamicParameters();
        parameters.Add("@CouponId", updateCouponDto.CouponId);
        parameters.Add("@code", updateCouponDto.Code);
        parameters.Add("@Rate", updateCouponDto.Rate);
        parameters.Add("@IsActive", updateCouponDto.IsActive);
        parameters.Add("@ValidDate", updateCouponDto.ValidDate);

        using (var connection = dapperContext.CreateConnection())
        {
            await connection.ExecuteAsync(query, parameters);
        }
    }

    public async Task DeleteDiscountCouponAsync(int couponId)
    {
        string query = "delete from coupons where CouponId=@CouponId";
        var parameters = new DynamicParameters();

        parameters.Add("@CouponId", couponId);

        using (var connection = dapperContext.CreateConnection())
        {
            await connection.ExecuteAsync(query, parameters);
        }
    }

    public async Task<GetByIdDiscountCouponDto> GetByIdDiscountCouponAsync(int couponId)
    {
        string query = "select * from coupons where CouponId=@CouponId";
        var parameters = new DynamicParameters();
        parameters.Add("@CouponId", couponId);


        using (var connection = dapperContext.CreateConnection())
        {
            return await connection.QueryFirstOrDefaultAsync<GetByIdDiscountCouponDto>(query, parameters);
        }
    }

    public async Task<ResultDiscountCouponDto> GetCodeDetailByCodeAsync(string code)
    {
        string query = "select * from coupons where Code = @code";
        var parameters = new DynamicParameters();
        parameters.Add("@code", code);

        using (var connection = dapperContext.CreateConnection())
        {
            return await connection.QueryFirstOrDefaultAsync<ResultDiscountCouponDto>(query, parameters);
        }
    }

    public int GetDiscountCouponCountRate(string code)
    {
        string query = "select Rate from coupons where Code = @code";
        var parameters = new DynamicParameters();
        parameters.Add("@code", code);

        using (var connection = dapperContext.CreateConnection())
        {
            return connection.QueryFirstOrDefault<int>(query, parameters);
        }
    }
}