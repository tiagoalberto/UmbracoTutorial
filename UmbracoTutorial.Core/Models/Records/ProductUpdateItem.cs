namespace UmbracoTutorial.Core.Models.Records;

public record ProductUpdateItem(
    string? ProductName,
    decimal? Price,
    List<string>? Categories,
    string? Description,
    string? Sku,
    string? PhotoFileName,
    string? Photo);