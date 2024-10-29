using System.Text.Json.Serialization;

namespace BlazorPaddleIntegration.SSR.Client.Models;

public record CustomData(
    [property: JsonPropertyName("customerInfo")]
    CustomerInfo CustomerInfo);

public record CustomerInfo(string Id, string Email);
