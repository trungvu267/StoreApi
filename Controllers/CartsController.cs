using StoreApi.Models;
using StoreApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace StoreApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CartsController : ControllerBase
{
    private readonly CartsService _cartsService;

    public CartsController(CartsService productsService) =>
        _cartsService = productsService;

    [HttpGet]
    public async Task<List<Cart>> Get() =>
        await _cartsService.GetCarts();

    [HttpGet("{id:length(24)}")]
    public async Task<ActionResult<Cart>> Get(string id)
    {
        var product = await _cartsService.GetCarts(id);

        if (product is null)
        {
            return NotFound();
        }

        return product;
    }

    [HttpPost]
    public async Task<IActionResult> Post(Cart newCart)
    {
        await _cartsService.CreateAsync(newCart);

        return CreatedAtAction(nameof(Get), new { id = newCart.Id }, newCart);
    }

    [HttpPut("{id:length(24)}")]
    public async Task<IActionResult> Update(string id, Cart updatedCart)
    {
        var cart = await _cartsService.GetCarts(id);

        if (cart is null)
        {
            return NotFound();
        }

        updatedCart.Id = cart.Id;

        await _cartsService.UpdateAsync(id, updatedCart);

        return NoContent();
    }

    [HttpDelete("{id:length(24)}")]
    public async Task<IActionResult> Delete(string id)
    {
        var cart = await _cartsService.GetCarts(id);

        if (cart is null)
        {
            return NotFound();
        }

        await _cartsService.RemoveAsync(id);

        return NoContent();
    }
}