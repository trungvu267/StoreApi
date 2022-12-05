using StoreApi.Models;
using StoreApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace StoreApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AddressesController : ControllerBase
{
    private readonly AddressesService _addressesService;

    public AddressesController(AddressesService productsService) =>
        _addressesService = productsService;

    [HttpGet]
    public async Task<List<Address>> Get() =>
        await _addressesService.GetAddresses();

    [HttpGet("{id:length(24)}")]
    public async Task<List<Address>> Get(string id)=>
        await _addressesService.GetAddressesByUserId(id);
    [HttpPost]
    public async Task<IActionResult> Post(Address newAddress)
    {
        await _addressesService.CreateAsync(newAddress);

        return CreatedAtAction(nameof(Get), new { id = newAddress.Id }, newAddress);
    }

    [HttpPut("{id:length(24)}")]
    public async Task<IActionResult> Update(string id, Address updatedAddress)
    {
        var address = await _addressesService.GetAddresses(id);

        if (address is null)
        {
            return NotFound();
        }

        updatedAddress.Id = address.Id;

        await _addressesService.UpdateAsync(id, updatedAddress);

        return NoContent();
    }

    [HttpDelete("{id:length(24)}")]
    public async Task<IActionResult> Delete(string id)
    {
        var address = await _addressesService.GetAddresses(id);

        if (address is null)
        {
            return NotFound();
        }

        await _addressesService.RemoveAsync(id);

        return NoContent();
    }
}