namespace Order.Contracts;

public record OrderSubmitted
{
    // The explicit parameterless constructor MassTransit needs
    public OrderSubmitted() { }

    public Guid OrderId { get; init; }
    public string CustomerName { get; init; } = string.Empty;
    public decimal TotalAmount { get; init; }
    public DateTime SubmittedAt { get; init; } = DateTime.UtcNow;
}
