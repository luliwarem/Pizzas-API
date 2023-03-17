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
        Pizza respuesta = BD.GetById(id);
        if(respuesta == null){
            return NotFound();
        }
        else{
            return Ok(respuesta);
        }
    }

    [HttpPost]
    public IActionResult Create(Pizza pizza){
        BD.Create(pizza);
        return Ok();
    }
    
    [HttpPut("{id}")]
    public IActionResult Update(int id, Pizza pizza){
        int rows = BD.Update(id,pizza);

        if (rows == 0)
        {
            return NotFound();
        }
        return Ok();    }

    [HttpDelete("{id}")]
    public IActionResult DeleteById(int id){
        int rows = BD.DeleteById(id);

        if (rows == 0)
        {
            return NotFound();
        }
        return Ok();

    }
    

}
