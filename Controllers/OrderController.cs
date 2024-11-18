using Microsoft.AspNetCore.Mvc;
using NLog;
using NLogBasics.Models;

namespace NLogBasics.Controllers;


[Route("api/[controller]")]
[ApiController]
public class OrderController : ControllerBase
{
    private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
    private static List<Order> Orders = new List<Order>(); 

    [HttpPost("create")]
    public IActionResult CreateOrder([FromBody] Order order)
    {
        try
        {
            order.Id = Orders.Count + 1;
            order.OrderDate = DateTime.Now;
            order.Status = "Pending";
            Orders.Add(order);

            Logger.Info($"Order created: Order ID = {order.Id}, Product ID = {order.ProductId}, Quantity = {order.Quantity}");
            return Ok(order);
        }
        catch (Exception ex)
        {
            Logger.Error(ex, "Error occurred while creating an order.");
            return StatusCode(500, "Internal server error.");
        }
    }

    [HttpPut("update/{id}")]
    public IActionResult UpdateOrder(int id, [FromBody] Order updatedOrder)
    {
        try
        {
            var order = Orders.FirstOrDefault(o => o.Id == id);
            if (order == null)
            {
                Logger.Warn($"Order not found: Order ID = {id}");
                return NotFound("Order not found.");
            }

            order.Quantity = updatedOrder.Quantity;
            order.Status = updatedOrder.Status;
            Logger.Info($"Order updated: Order ID = {id}, New Quantity = {order.Quantity}, New Status = {order.Status}");
            return Ok(order);
        }
        catch (Exception ex)
        {
            Logger.Error(ex, "Error occurred while updating an order.");
            return StatusCode(500, "Internal server error.");
        }
    }

    [HttpDelete("cancel/{id}")]
    public IActionResult CancelOrder(int id)
    {
        try
        {
            var order = Orders.FirstOrDefault(o => o.Id == id);
            if (order == null)
            {
                Logger.Warn($"Order not found: Order ID = {id}");
                return NotFound("Order not found.");
            }

            order.Status = "Cancelled";
            Logger.Info($"Order cancelled: Order ID = {id}");
            return Ok(order);
        }
        catch (Exception ex)
        {
            Logger.Error(ex, "Error occurred while cancelling an order.");
            return StatusCode(500, "Internal server error.");
        }
    }

    [HttpGet("list")]
    public IActionResult GetOrders()
    {
        Logger.Info("Orders listed.");
        return Ok(Orders);
    }
}
