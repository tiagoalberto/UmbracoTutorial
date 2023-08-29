﻿using Umbraco.Cms.Core.Models.PublishedContent;
using UmbracoTutorial.Core.UmbracoModels;
namespace UmbracoTutorial.ViewModels.Umbraco;

// We should inherit from PublishedContentWrapped or derived class
public class ProductListingViewModel:Products
{
    public ProductListingViewModel(IPublishedContent content,
        IPublishedValueFallback publishedValueFallback) : base(content,
        publishedValueFallback)
    {
    }

    public List<Product> Products { get; set; } = new();
}