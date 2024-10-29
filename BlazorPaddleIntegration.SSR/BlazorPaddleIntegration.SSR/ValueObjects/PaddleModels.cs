using System.Text.Json.Serialization;
using BlazorPaddleIntegration.SSR.Client.Models;

namespace BlazorPaddleIntegration.SSR.ValueObjects;

public record WebhookEvent(
    [property: JsonPropertyName("event_id")] string EventId,
    [property: JsonPropertyName("event_type")] string EventType,
    [property: JsonPropertyName("occurred_at")] DateTime OccurredAt,
    [property: JsonPropertyName("notification_id")] string NotificationId,
    [property: JsonPropertyName("data")] TransactionData Data
);

public record TransactionData(
    [property: JsonPropertyName("id")] string Id,
    [property: JsonPropertyName("items")] IReadOnlyList<TransactionItem> Items,
    [property: JsonPropertyName("origin")] string Origin,
    [property: JsonPropertyName("status")] string Status,
    [property: JsonPropertyName("details")] TransactionDetails Details,
    [property: JsonPropertyName("checkout")] Checkout Checkout,
    [property: JsonPropertyName("payments")] IReadOnlyList<Payment> Payments,
    [property: JsonPropertyName("billed_at")] DateTime BilledAt,
    [property: JsonPropertyName("address_id")] string AddressId,
    [property: JsonPropertyName("created_at")] DateTime CreatedAt,
    [property: JsonPropertyName("invoice_id")] string InvoiceId,
    [property: JsonPropertyName("updated_at")] DateTime UpdatedAt,
    [property: JsonPropertyName("business_id")] string? BusinessId,
    [property: JsonPropertyName("custom_data")] CustomData? CustomData,
    [property: JsonPropertyName("customer_id")] string CustomerId,
    [property: JsonPropertyName("discount_id")] string? DiscountId,
    [property: JsonPropertyName("currency_code")] string CurrencyCode,
    [property: JsonPropertyName("billing_period")] BillingPeriod BillingPeriod,
    [property: JsonPropertyName("invoice_number")] string InvoiceNumber,
    [property: JsonPropertyName("billing_details")] object? BillingDetails,
    [property: JsonPropertyName("collection_mode")] string CollectionMode,
    [property: JsonPropertyName("subscription_id")] string SubscriptionId
);

public record TransactionItem(
    [property: JsonPropertyName("price")] Price Price,
    [property: JsonPropertyName("quantity")] int Quantity,
    [property: JsonPropertyName("proration")] object? Proration
);

public record Price(
    [property: JsonPropertyName("id")] string Id,
    [property: JsonPropertyName("name")] string Name,
    [property: JsonPropertyName("type")] string Type,
    [property: JsonPropertyName("status")] string Status,
    [property: JsonPropertyName("quantity")] Quantity Quantity,
    [property: JsonPropertyName("tax_mode")] string TaxMode,
    [property: JsonPropertyName("created_at")] DateTime CreatedAt,
    [property: JsonPropertyName("product_id")] string ProductId,
    [property: JsonPropertyName("unit_price")] UnitPrice UnitPrice,
    [property: JsonPropertyName("updated_at")] DateTime UpdatedAt,
    [property: JsonPropertyName("custom_data")] object? CustomData,
    [property: JsonPropertyName("description")] string Description,
    [property: JsonPropertyName("trial_period")] object? TrialPeriod,
    [property: JsonPropertyName("billing_cycle")] BillingCycle? BillingCycle,
    [property: JsonPropertyName("unit_price_overrides")] IReadOnlyList<object> UnitPriceOverrides,
    [property: JsonPropertyName("import_meta")] object? ImportMeta
);

public record Quantity(
    [property: JsonPropertyName("maximum")] int Maximum,
    [property: JsonPropertyName("minimum")] int Minimum
);

public record UnitPrice(
    [property: JsonPropertyName("amount")] string Amount,
    [property: JsonPropertyName("currency_code")] string CurrencyCode
);

public record BillingCycle(
    [property: JsonPropertyName("interval")] string Interval,
    [property: JsonPropertyName("frequency")] int Frequency
);

public record TransactionDetails(
    [property: JsonPropertyName("totals")] Totals Totals,
    [property: JsonPropertyName("line_items")] IReadOnlyList<LineItem> LineItems,
    [property: JsonPropertyName("payout_totals")] Totals PayoutTotals,
    [property: JsonPropertyName("tax_rates_used")] IReadOnlyList<TaxRate> TaxRatesUsed,
    [property: JsonPropertyName("adjusted_totals")] AdjustedTotals AdjustedTotals
);

public record Totals(
    [property: JsonPropertyName("fee")] string Fee,
    [property: JsonPropertyName("tax")] string Tax,
    [property: JsonPropertyName("total")] string Total,
    [property: JsonPropertyName("credit")] string Credit,
    [property: JsonPropertyName("balance")] string Balance,
    [property: JsonPropertyName("discount")] string Discount,
    [property: JsonPropertyName("earnings")] string Earnings,
    [property: JsonPropertyName("subtotal")] string Subtotal,
    [property: JsonPropertyName("grand_total")] string GrandTotal,
    [property: JsonPropertyName("currency_code")] string CurrencyCode,
    [property: JsonPropertyName("credit_to_balance")] string CreditToBalance
);

public record LineItem(
    [property: JsonPropertyName("id")] string Id,
    [property: JsonPropertyName("totals")] LineItemTotals Totals,
    [property: JsonPropertyName("product")] Product Product,
    [property: JsonPropertyName("price_id")] string PriceId,
    [property: JsonPropertyName("quantity")] int Quantity,
    [property: JsonPropertyName("tax_rate")] string TaxRate,
    [property: JsonPropertyName("unit_totals")] LineItemTotals UnitTotals
);

public record LineItemTotals(
    [property: JsonPropertyName("tax")] string Tax,
    [property: JsonPropertyName("total")] string Total,
    [property: JsonPropertyName("discount")] string Discount,
    [property: JsonPropertyName("subtotal")] string Subtotal
);

public record Product(
    [property: JsonPropertyName("id")] string Id,
    [property: JsonPropertyName("name")] string Name,
    [property: JsonPropertyName("type")] string Type,
    [property: JsonPropertyName("status")] string Status,
    [property: JsonPropertyName("image_url")] string ImageUrl,
    [property: JsonPropertyName("created_at")] DateTime CreatedAt,
    [property: JsonPropertyName("updated_at")] DateTime UpdatedAt,
    [property: JsonPropertyName("custom_data")] ProductCustomData? CustomData,
    [property: JsonPropertyName("description")] string Description,
    [property: JsonPropertyName("tax_category")] string TaxCategory,
    [property: JsonPropertyName("import_meta")] object? ImportMeta
);

public record ProductCustomData(
    [property: JsonPropertyName("features")] ProductFeatures Features,
    [property: JsonPropertyName("suggested_addons")] IReadOnlyList<string>? SuggestedAddons,
    [property: JsonPropertyName("upgrade_description")] string? UpgradeDescription
);

public record ProductFeatures(
    [property: JsonPropertyName("sso")] bool Sso,
    [property: JsonPropertyName("route_planning")] bool RoutePlanning,
    [property: JsonPropertyName("payment_by_invoice")] bool PaymentByInvoice,
    [property: JsonPropertyName("aircraft_performance")] bool AircraftPerformance,
    [property: JsonPropertyName("compliance_monitoring")] bool ComplianceMonitoring,
    [property: JsonPropertyName("flight_log_management")] bool FlightLogManagement
);

public record TaxRate(
    [property: JsonPropertyName("totals")] LineItemTotals Totals,
    [property: JsonPropertyName("tax_rate")] string Rate
);

public record AdjustedTotals(
    [property: JsonPropertyName("fee")] string Fee,
    [property: JsonPropertyName("tax")] string Tax,
    [property: JsonPropertyName("total")] string Total,
    [property: JsonPropertyName("earnings")] string Earnings,
    [property: JsonPropertyName("subtotal")] string Subtotal,
    [property: JsonPropertyName("grand_total")] string GrandTotal,
    [property: JsonPropertyName("currency_code")] string CurrencyCode
);

public record Checkout(
    [property: JsonPropertyName("url")] string Url
);

public record Payment(
    [property: JsonPropertyName("amount")] string Amount,
    [property: JsonPropertyName("status")] string Status,
    [property: JsonPropertyName("created_at")] DateTime CreatedAt,
    [property: JsonPropertyName("error_code")] string? ErrorCode,
    [property: JsonPropertyName("captured_at")] DateTime? CapturedAt,
    [property: JsonPropertyName("method_details")] PaymentMethodDetails MethodDetails,
    [property: JsonPropertyName("payment_method_id")] string PaymentMethodId,
    [property: JsonPropertyName("payment_attempt_id")] string PaymentAttemptId,
    [property: JsonPropertyName("stored_payment_method_id")] string StoredPaymentMethodId
);

public record PaymentMethodDetails(
    [property: JsonPropertyName("card")] Card Card,
    [property: JsonPropertyName("type")] string Type
);

public record Card(
    [property: JsonPropertyName("type")] string Type,
    [property: JsonPropertyName("last4")] string Last4,
    [property: JsonPropertyName("expiry_year")] int ExpiryYear,
    [property: JsonPropertyName("expiry_month")] int ExpiryMonth,
    [property: JsonPropertyName("cardholder_name")] string CardholderName
);

public record BillingPeriod(
    [property: JsonPropertyName("ends_at")] DateTime EndsAt,
    [property: JsonPropertyName("starts_at")] DateTime StartsAt
);