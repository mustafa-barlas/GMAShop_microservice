﻿
using System.Collections.Generic;
using IdentityServer4;
using IdentityServer4.Models;

namespace GMAShop.IdentityServer
{
    public static class Config
    {
        public static IEnumerable<ApiResource> ApiResources => new ApiResource[]
        {
           new ApiResource("ResourceCatalog"){Scopes={"CatalogFullPermission","CatalogReadPermission"} },
           new ApiResource("ResourceDiscount"){Scopes={"DiscountFullPermission"} },
           new ApiResource("ResourceOrder"){Scopes={"OrderFullPermission"}},
           new ApiResource("ResourceCargo"){Scopes={"CargoFullPermission"} },
           new ApiResource("ResourceBasket"){Scopes={"BasketFullPermission"} },
           new ApiResource("ResourceComment"){Scopes={"CommentFullPermission"} },
           new ApiResource("ResourcePayment"){Scopes={ "PaymentFullPermission" } },
           new ApiResource("ResourceImage"){Scopes={ "ImageFullPermission" } },
           new ApiResource("ResourceOcelot"){Scopes={"OcelotFullPermission"} },
           new ApiResource("ResourceMessage"){Scopes={"MessageFullPermission"} },
           new ApiResource(IdentityServerConstants.LocalApi.ScopeName)
        };

        public static IEnumerable<IdentityResource> IdentityResources => new IdentityResource[]
        {
          new IdentityResources.OpenId(),
          new IdentityResources.Profile(),
          new IdentityResources.Email()
        };

        public static IEnumerable<ApiScope> ApiScopes => new ApiScope[]
        {
            new ApiScope("CatalogFullPermission","Full authority for catalog operations"),
            new ApiScope("CatalogReadPermission","Reading authority for catalog operations"),
            new ApiScope("DiscountFullPermission","Full authority for discount operations"),
            new ApiScope("OrderFullPermission","Full authority for order operations"),
            new ApiScope("CargoFullPermission","Full authority for cargo operations"),
            new ApiScope("BasketFullPermission","Full authority for basket operations"),
            new ApiScope("CommentFullPermission","Full authority for comment operations"),
            new ApiScope("PaymentFullPermission","Full authority for payment operations"),
            new ApiScope("ImageFullPermission","Full authority for image operations"),
            new ApiScope("OcelotFullPermission","Full authority for ocelot operations"),
            new ApiScope("MessageFullPermission","Full authority for message operations"),
            new ApiScope(IdentityServerConstants.LocalApi.ScopeName)
        };

        public static IEnumerable<Client> Clients => new Client[]
        {
            //Visitor
            new Client
            {
                ClientId="GMAShopVisitorId",
                ClientName="GMA Shop Visitor User",
                AllowedGrantTypes=GrantTypes.ClientCredentials,
                ClientSecrets={new Secret("gmashopsecret".Sha256())},
                AllowedScopes={"CatalogFullPermission","DiscountFullPermission","OcelotFullPermission","CommentFullPermission","ImageFullPermission", "CommentFullPermission",  IdentityServerConstants.LocalApi.ScopeName 
                },
                AllowAccessTokensViaBrowser=true
            },

            //Manager
            new Client
            {
                ClientId="GMAShopManagerId",
                ClientName="GMA Shop Manager User",
                AllowedGrantTypes=GrantTypes.ResourceOwnerPassword,
                ClientSecrets={new Secret("gmashopsecret".Sha256()) },
                AllowedScopes={"CatalogFullPermission", "BasketFullPermission", "OcelotFullPermission", "CommentFullPermission", "PaymentFullPermission", "ImageFullPermission","OrderFullPermission","MessageFullPermission","CargoFullPermission",
                IdentityServerConstants.LocalApi.ScopeName,
                IdentityServerConstants.StandardScopes.Email,
                IdentityServerConstants.StandardScopes.OpenId,
                IdentityServerConstants.StandardScopes.Profile

                }
            },

            //Admin
            new Client
            {
                ClientId="GMAShopAdminId",
                ClientName="GMA Shop Admin User",
                AllowedGrantTypes=GrantTypes.ResourceOwnerPassword,
                ClientSecrets={new Secret("gmashopsecret".Sha256()) },
                AllowedScopes={ "CatalogFullPermission", "DiscountFullPermission", "OrderFullPermission","CargoFullPermission","BasketFullPermission","OcelotFullPermission","CommentFullPermission","PaymentFullPermission","ImageFullPermission",
                IdentityServerConstants.LocalApi.ScopeName,
                IdentityServerConstants.StandardScopes.Email,
                IdentityServerConstants.StandardScopes.OpenId,
                IdentityServerConstants.StandardScopes.Profile
                },
                AccessTokenLifetime=600
            }
        };
    }
}