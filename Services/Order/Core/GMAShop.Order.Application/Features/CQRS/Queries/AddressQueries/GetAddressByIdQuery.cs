namespace GMAShop.Order.Application.Feature.CQRS.Queries.AddressQueries;

public class GetAddressByIdQuery
{
    public int AddressId { get; set; }

    public GetAddressByIdQuery(int addressId)
    {
        AddressId = addressId;
    }

}