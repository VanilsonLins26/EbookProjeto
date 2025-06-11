using Microsoft.AspNetCore.Mvc;

namespace WebApplication8.Controllers;


[ApiController]
[Route("api/[controller]")]
public class ProdutosController : ControllerBase
{
    private static List<Produto> produtos = new();
    private static int id = 1;
    

    [HttpGet]
    public IActionResult Get() => Ok(produtos);
    

    [HttpPost]
    public ActionResult<Produto> Post(Produto produto)
    {
        produto.Id = id;
        id++;
        produtos.Add(produto);
        return Ok(produto);
       
    }

    [HttpPut]
    public ActionResult<Produto> Update(Produto produto, int id)
    {
        if(produto.Id != id) 
            return BadRequest();

        var produtoModificado = produtos.Where(p => p.Id == id).FirstOrDefault();
        if(produtoModificado == null)
            return NotFound("Produto não encontrado");
        produtoModificado.Nome = produto.Nome;
        produtoModificado.Preco = produto.Preco;
        return Ok(produtoModificado);
    }

    [HttpDelete]
    public ActionResult<Produto> Delete(int id)
    {
        var produto = produtos.Where(p =>p.Id == id).FirstOrDefault();
        if (produto == null)
            return NotFound("Produto não encontrado");

        produtos.Remove(produto);
        return Ok(produto);
    }
}
