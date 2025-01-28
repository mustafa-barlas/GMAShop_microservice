namespace GMAShop.DtoLayer.OrderDtos.OrderOrderingDtos
{
    public record ResultOrderingByUserIdDto
    {
        public int OrderingId { get; init; }
        public string UserId { get; init; }
        public decimal TotalPrice { get; init; }
        public DateTime OrderDate { get; init; }
    }
}
