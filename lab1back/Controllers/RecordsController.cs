using Entities;
using lab1back.Logic;
using lab1back.Models;
using Microsoft.AspNetCore.Mvc;

namespace lab1back.Controllers;

[ApiController]
public class RecordsController : ControllerBase
{

    private readonly IRecordRepository _recordRepository;
    public RecordsController(IRecordRepository recordRepository)
    {
        _recordRepository = recordRepository;
    }
    
    [HttpGet("record/{id}")]
    public IActionResult Get(Guid id)
    {
        try
        {
            var record = _recordRepository.GetRecordById(id);
            if (record is null)
                return NotFound();

            return Ok();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return BadRequest();
        }
    }

    [HttpGet("record")]
    public IActionResult Get([FromQuery] RecordRequest request)
    {
        try
        {
            if (request.category_id is null && request.user_id is null)
                BadRequest("Incorrect request");
            var record = _recordRepository.GetRecords(request);
            return Ok(record);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return BadRequest();
        }
    }
    
    [HttpDelete("record/{id}")]
    public IActionResult Delete(Guid id)
    {
        try
        {
            _recordRepository.DeleteRecord(id);
            return Ok();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return BadRequest();
        }
    }

    [HttpPost("record")]
    public IActionResult Add([FromBody]CreateRecordRequest req)
    {
        try
        {
            _recordRepository.AddRecord(new Record(req));
            return Ok();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return BadRequest();
        }
    }
}