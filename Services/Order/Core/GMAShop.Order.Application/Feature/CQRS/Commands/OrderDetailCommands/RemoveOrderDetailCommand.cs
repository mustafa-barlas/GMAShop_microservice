namespace GMAShop.Order.Application.Feature.CQRS.Commands.OrderDetailCommands;

public class RemoveOrderDetailCommand
{
    public int Id { get; set; }

    public RemoveOrderDetailCommand(int id)
    {
        Id = id;
    }
}