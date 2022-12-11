using StoreApi.Models;
using StoreApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace StoreApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OnlineOrdersController : ControllerBase
{
    private readonly OnlineOrdersService _onlineOrdersService;

    public OnlineOrdersController(OnlineOrdersService productsService) =>
        _onlineOrdersService = productsService;

    [HttpGet]
    public async Task<List<OnlineOrder>> Get() =>
        await _onlineOrdersService.GetOnlineOrders();

    [HttpGet("{id:length(24)}")]
    public async Task<ActionResult<OnlineOrder>> Get(string id)
    {
        var onlineOrder = await _onlineOrdersService.GetOnlineOrders(id);

        if (onlineOrder is null)
        {
            return NotFound();
        }

        return onlineOrder;
    }
    [HttpGet("users/{id:length(24)}")]
    public async Task<List<OnlineOrder>> GetAddressesAsync(string id)=>
        await _onlineOrdersService.GetOnlineOrdersByUserId(id);
    [HttpPost]
    public async Task<IActionResult> Post(OnlineOrder newOnlineOrder)
    {
        await _onlineOrdersService.CreateAsync(newOnlineOrder);

        return CreatedAtAction(nameof(Get), new { id = newOnlineOrder.Id }, newOnlineOrder);
    }

    // [HttpPut("{id:length(24)}")]
    // public async Task<IActionResult> Update(string id, Cart updatedCart)
    // {
    //     var cart = await _onlineOrdersService.GetCarts(id);

    //     if (cart is null)
    //     {
    //         return NotFound();
    //     }

    //     updatedCart.Id = cart.Id;

    //     await _onlineOrdersService.UpdateAsync(id, updatedCart);

    //     return NoContent();
    // }

    [HttpDelete("{id:length(24)}")]
    public async Task<IActionResult> Delete(string id)
    {
        var onlineOrder = await _onlineOrdersService.GetOnlineOrders(id);

        if (onlineOrder is null)
        {
            return NotFound();
        }

        await _onlineOrdersService.RemoveAsync(id);

        return NoContent();
    }
}