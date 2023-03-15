namespace Pizzas.API.Models;
using System.Data.SqlClient;
using Dapper;
using System.Collections.Generic;

public class BD
{

    private static string _connectionString = @"Server=A-PHZ2-CIDI-021;DataBase=DAI-Pizzas;Trusted_Connection=True";

    public static List<Pizza> GetAll()
    {
        List<Pizza> lista = new List<Pizza>();
        string sql = "SELECT * FROM Pizzas";
        using (SqlConnection db = new SqlConnection(_connectionString))
        {
            lista = db.Query<Pizza>(sql).ToList();
        }
        return lista;
    }
    public static Pizza GetById(int IdPizza){
        Pizza pizza = null;
        string sql = "SELECT * FROM Pizzas WHERE Id = @pIdPizza";
        using(SqlConnection db = new SqlConnection(_connectionString)){
            pizza = db.QueryFirstOrDefault<Pizza>(sql, new { pIdPizza = IdPizza });
        }
        return pizza;
    }

    public static void Create(Pizza pizza){
        string sql = "INSERT INTO Pizzas VALUES (@pNombre, @pLibreGluten, @pImporte, @pDescricion)";
        using(SqlConnection db = new SqlConnection(_connectionString)){
            db.Execute(sql, new {pNombre = pizza.Nombre, pLibreGluten = pizza.LibreGluten, pImporte = pizza.Importe, pDescripcion = pizza.Descripcion});
        }
    }

    public static void Update(int id, Pizza pizza){
        string sql = "UPDATE Pizzas SET Nombre = @pNombre, LibreGluten = @pLibreGluten, Importe = @pImporte, Descripcion = @pDescripcion WHERE id = @pId";
        using(SqlConnection db = new SqlConnection(_connectionString)){
            db.Execute(sql, new {pNombre = pizza.Nombre, pLibreGluten = pizza.LibreGluten, pImporte = pizza.Importe, pDescripcion = pizza.Descripcion});
        }
    }

    public static void DeleteById(int Id){
        string sql = "DELETE FROM Pizzas WHERE Id = @pId";
        using(SqlConnection db = new SqlConnection(_connectionString)){
            db.Execute(sql, new { pId = Id });
        }
    }

}