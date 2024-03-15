using Application.Services;
using Domain.Entities;
using Domain.Requests;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ADA.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CarrosController : ControllerBase
{

    private readonly ICarService _service;

    public CarrosController(ICarService service)
    {
        _service = service;
    }

    [HttpGet]
    public IActionResult List([FromQuery] CarroFilters filtros)
    {
        var cars = _service.List();

        return Ok(cars);
    }

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        var car = _service.GetById(id);
        return car is null? NotFound() : Ok(car);
    }

    [HttpPost]
    public IActionResult Post([FromBody] BaseCarRequest car)
    {
        var newCar = _service.Create(car);
        return Ok(newCar);
    }


    [HttpPut]
    public IActionResult Put(int id, [FromBody] UpdateCarRequest car)
    {
        car.Id = id;
        var updatedCar = _service.Update(car);

        return Ok(updatedCar);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id) 
    {
        _service.Delete(id);

        return NoContent();
    }
}

public class CarroFilters
{
    public string? Marca { get; set; }
    public string? Modelo { get; set; }
    public string? OrderBy { get; set; }
}