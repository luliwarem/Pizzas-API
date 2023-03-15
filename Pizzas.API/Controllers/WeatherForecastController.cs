using Microsoft.AspNetCore.Mvc;
using Pizzas.API.Models; 
namespace Pizzas.API.Controllers;
using System.Collections.Generic;

[ApiController]
[Route("[controller]")]
public class PizzasController : ControllerBase
{
    [HttpGet]
    public IActionResult GetAll(){
        List<Pizza> lista = new List<Pizza>();
        lista = BD.GetAll();
        return Ok(lista);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id){
        return Ok(BD.GetById(id));
    }

    [HttpPost]
    public IActionResult Create(Pizza pizza){
        BD.Create(pizza);
        return Ok();
    }
    
    [HttpPut("{id}")]
    public IActionResult Update(int id, Pizza pizza){
        BD.Update(id,pizza);
        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteById(int id){
        BD.DeleteById(id);
        return Ok();
    }
    

}
