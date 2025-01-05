namespace GMAShop.WebUI.Settings
{
    public class ClientSettings
    {
        public Client GMAShopVisitorClient { get; set; }
        public Client GMAShopManagerClient { get; set; }
        public Client GMAShopAdminClient { get; set; }
    }

    public class Client
    {
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
    }
}
