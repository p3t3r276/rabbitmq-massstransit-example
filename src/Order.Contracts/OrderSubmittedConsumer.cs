using MassTransit;
using Microsoft.Extensions.Logging;

namespace Order.Contracts;

public class OrderSubmittedConsumer(ILogger<OrderSubmitted> logger) : IConsumer<OrderSubmitted>
{
    public async Task Consume(ConsumeContext<OrderSubmitted> context)
    {
        var message = context.Message;
        // Simulate processing logic
        logger.LogInformation("[Processing] Order {OrderId} for {CustomerName} (${TotalAmount})", message.OrderId, message.CustomerName, message.TotalAmount);
        await Task.Delay(1000); 
    }
}
