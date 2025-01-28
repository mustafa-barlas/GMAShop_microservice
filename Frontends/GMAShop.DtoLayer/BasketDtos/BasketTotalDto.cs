namespace GMAShop.DtoLayer.BasketDtos
{
    public record BasketTotalDto
    {
        public string UserId { get; init; }
        public string DiscountCode { get; init; }
        public int DiscountRate { get; init; }
        public List<BasketItemDto> BasketItems { get; init; }
        public decimal TotalPrice { get => BasketItems.Sum(x => x.Price * x.Quantity); }
    }
}
