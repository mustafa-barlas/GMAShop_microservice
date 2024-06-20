﻿namespace GMAShop.DtoLayer.CatalogDtos.AboutDtos
{
    public record ResultAboutDto
    {
        public string AboutId { get; init; }
        public string Description { get; init; }
        public string Address { get; init; }
        public string Email { get; init; }
        public string Phone { get; init; }
    }
}
