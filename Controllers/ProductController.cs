using Microsoft.AspNetCore.Mvc;
using NLog;
using NLogBasics.Models;

namespace NLogBasics.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
    private static List<Product> Products = new List<Product>();

    [HttpPost("add")]
    public IActionResult AddProduct([FromBody] Product product)
    {
        try
        {
            product.Id = Products.Count + 1;
            Products.Add(product);

            Logger.Info($"Product added: Product ID = {product.Id}, Name = {product.Name}, Price = {product.Price}");
            return Ok(product);
        }
        catch (Exception ex)
        {
            Logger.Error(ex, "Error occurred while adding a product.");
            return StatusCode(500, "Internal server error.");
        }
    }

    [HttpPut("update/{id}")]
    public IActionResult UpdateProduct(int id, [FromBody] Product updatedProduct)
    {
        try
        {
            var product = Products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                Logger.Warn($"Product not found: Product ID = {id}");
                return NotFound("Product not found.");
            }

            product.Name = updatedProduct.Name;
            product.Price = updatedProduct.Price;

            Logger.Info($"Product updated: Product ID = {id}, New Name = {product.Name}, New Price = {product.Price}");
            return Ok(product);
        }
        catch (Exception ex)
        {
            Logger.Error(ex, "Error occurred while updating a product.");
            return StatusCode(500, "Internal server error.");
        }
    }

    [HttpDelete("delete/{id}")]
    public IActionResult DeleteProduct(int id)
    {
        try
        {
            var product = Products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                Logger.Warn($"Product not found: Product ID = {id}");
                return NotFound("Product not found.");
            }

            Products.Remove(product);
            Logger.Info($"Product deleted: Product ID = {id}");
            return Ok("Product deleted successfully.");
        }
        catch (Exception ex)
        {
            Logger.Error(ex, "Error occurred while deleting a product.");
            return StatusCode(500, "Internal server error.");
        }
    }

    [HttpGet("list")]
    public IActionResult GetProducts()
    {
        Logger.Info("Products listed.");
        return Ok(Products);
    }
}
