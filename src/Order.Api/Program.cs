using MassTransit;
using Order.Contracts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddMassTransit(x =>
{   
    x.AddConsumer<OrderSubmittedConsumer>(); // Only in Processor
    
    x.UsingRabbitMq((context, cfg) =>
    {
        cfg.Host("localhost", "/", h =>
        {
            h.Username("guest");
            h.Password("guest");
        });
        cfg.ConfigureEndpoints(context);
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

// Endpoint to submit an order
app.MapPost("/orders", async (IPublishEndpoint publishEndpoint, OrderRequest request) =>
{
    var order = new OrderSubmitted()
    {
        OrderId = Guid.NewGuid(),
        CustomerName = request.CustomerName,
        TotalAmount = request.Amount
    };

    await publishEndpoint.Publish(order);
    return Results.Accepted($"/orders/{order.OrderId}", order);
});

app.Run();

public record OrderRequest(string CustomerName, decimal Amount);
