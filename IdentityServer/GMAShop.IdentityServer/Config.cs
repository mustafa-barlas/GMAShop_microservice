using IdentityServer4.Models;
using System.Collections.Generic;
using IdentityServer4;

namespace GMAShop.IdentityServer
{
    public static class Config
    {
        public static IEnumerable<ApiResource> ApiResources => new ApiResource[]
        {
            new ApiResource("ResourceCatalog") { Scopes = { "CatalogFullPermission", "CatalogReadPermission" } },
            new ApiResource("ResourceDiscount") { Scopes = { "DiscountFullPermission", "DiscountReadPermission" } },
            new ApiResource("ResourceOrder") { Scopes = { "OrderFullPermission", "OrderReadPermission" } },
            new ApiResource(IdentityServerConstants.LocalApi.ScopeName),
        };

        public static IEnumerable<IdentityResource> IdentityResources => new IdentityResource[]
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Email(),
            new IdentityResources.Profile()
        };

        public static IEnumerable<ApiScope> ApiScopes => new ApiScope[]
        {
            new ApiScope("CatalogFullPermission", "Full authority for catalog operations"),
            new ApiScope("CatalogReadPermission", "Reading authority for catalog operations"),

            new ApiScope("DiscountFullPermission", "Full authority for discount operations"),
            new ApiScope("DiscountReadPermission", "Reading authority for discount operations"),

            new ApiScope("OrderFullPermission", "Full authority for order operations"),
            new ApiScope("OrderReadPermission", "Reading authority for order operations"),

            new ApiScope(IdentityServerConstants.LocalApi.ScopeName),
        };

        public static IEnumerable<Client> Clients => new Client[]
        {
            new Client() // Visitor
            {
                ClientId = "GMAShopVisitorId",
                ClientName = "GMAShop Visitor User",
                AllowedGrantTypes = GrantTypes.ClientCredentials,
                ClientSecrets = { new Secret("gmashopsecret".Sha256()) },
                AllowedScopes = { "DiscountFullPermission", "CatalogReadPermission" }
            },
            new Client() // Manager
            {
                ClientId = "GMAShopManagerId",
                ClientName = "GMAShop Manager User",
                AllowedGrantTypes = GrantTypes.ClientCredentials,
                ClientSecrets = { new Secret("gmashopsecret".Sha256()) },
                AllowedScopes = { "CatalogFullPermission", "DiscountFullPermission" }
            },
            new Client() // Admin
            {
                ClientId = "GMAShopAdminId",
                ClientName = "GMAShop Admin User",
                AllowedGrantTypes = GrantTypes.ClientCredentials,
                ClientSecrets = { new Secret("gmashopsecret".Sha256()) },
                AllowedScopes =
                {
                    "CatalogFullPermission", "DiscountFullPermission", "OrderFullPermission",
                    IdentityServer4.IdentityServerConstants.LocalApi.ScopeName,
                    IdentityServer4.IdentityServerConstants.StandardScopes.Email,
                    IdentityServer4.IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServer4.IdentityServerConstants.StandardScopes.Profile,
                },
                AccessTokenLifetime = 600
            }
        };
    }
}