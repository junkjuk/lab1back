using Entities;
using lab1back.Logic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace lab1back.Controllers;

[Authorize, ApiController]
public class BillController : ControllerBase
{
    private readonly IBillService _billService;

    public BillController(IBillService billService)
    {
        _billService = billService;
    }
    
    [HttpGet("bill/{userId}")]
    public async Task<IActionResult> Get(Guid userId)
    {
        try
        {
            return Ok(await _billService.Get(userId));
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return BadRequest();
        }
    }
    
    [HttpPost("bill")]
    public async Task<IActionResult> Add([FromBody]Guid userId)
    {
        try
        {
            await _billService.Add(userId);
            return Ok();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return BadRequest();
        }
    }
    
    [HttpPost("bill/addMoney")]
    public async Task<IActionResult> AddMoney([FromBody]BillChangeMoneyRequest req)
    {
        try
        {
            await _billService.AddMoney(req.UserId, req.Money);
            return Ok();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return BadRequest();
        }
    }
    
    [HttpPost("bill/minusMoney")]
    public async Task<IActionResult> MinusMoney([FromBody]BillChangeMoneyRequest req)
    {
        try
        {
            await _billService.MinusMoney(req.UserId, req.Money);
            return Ok();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return BadRequest();
        }
    }
}