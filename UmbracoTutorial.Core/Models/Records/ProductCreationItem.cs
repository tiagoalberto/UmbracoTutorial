using System.ComponentModel.DataAnnotations;

namespace UmbracoTutorial.Core.Models.Records;

public record ProductCreationItem(
    string ProductName,
    decimal Price,
    List<string> Categories,
    string Description,
    string? Sku,
    string PhotoFileName,
    string Photo
    );