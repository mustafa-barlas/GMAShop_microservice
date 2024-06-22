﻿namespace GMAShop.WebUI.Settings
{
    public class ServiceApiSettings
    {
        public string Ocelot { get; set; }
        public string IdentityServer { get; set; }
        public ServiceApi Catalog { get; set; }
        public ServiceApi Image { get; set; }
        public ServiceApi Discount { get; set; }
        public ServiceApi Order { get; set; }
        public ServiceApi Cargo { get; set; }
        public ServiceApi Basket { get; set; }
        public ServiceApi Payment { get; set; }
        public ServiceApi Comment { get; set; }
        public ServiceApi Message { get; set; }
    }
}