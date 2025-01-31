using GMAShop.Discount.Dtos;

namespace GMAShop.Discount.Services;

public interface IDiscountService
{
    Task<List<ResultDiscountCouponDto>> GetAllDiscountCouponAsync();
    Task CreateDiscountCouponAsync(CreateDiscountCouponDto createDiscountCouponDto);
    Task UpdateDiscountCouponAsync(UpdateDiscountCouponDto updateDiscountCouponDto);
    Task DeleteDiscountCouponAsync(int couponId);
    Task<GetByIdDiscountCouponDto> GetByIdDiscountCouponAsync(int couponId);
    Task<ResultDiscountCouponDto> GetCodeDetailByCodeAsync(string code);
    int GetDiscountCouponCountRate(string code);
}