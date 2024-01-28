using Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http.HttpResults;
using DatoSpace;


namespace Parcial1_paraRecuperar.Controllers;

[ApiController]
[Route("[controller]")]
public class BlogController : ControllerBase
{
    private readonly ILogger<BlogController> _logger;

    private Blog blog;
    public BlogController(ILogger<BlogController> logger)
    {
        _logger = logger;
        blog = new Blog();
        
    }

    [HttpGet ("/api/blog", Name = "Nombre del Blog")]
    // [Route ("Nombre del Blog")]
    public ActionResult<string> GetNombreBlog()
    {
        return Ok(blog.Nombre);
    }

    [HttpGet ("/api/posts", Name = "Publicaciones del Blog")]
    // [Route ("Publicaciones del Blog")]

    public ActionResult<IEnumerable<Blog>> GetPublicaciones()
    {
        return Ok(blog.ListarPubliciones());
    }

    
    [HttpGet ("/api/posts/{id}")]
    public ActionResult<Post>GetPublicacionPorId([FromRoute] int id )
    {
        Post post = blog.BuscarporPublicacionPorId(id);
        if (post!=null)
        {
            return Ok(post);
        }
        else{
            return NotFound("No existe el post buscado");
        }
    }

    [HttpPost ("/api/posts", Name ="Crear publicacion")]
    // [Route ("CrearPublicacion")]
    public ActionResult<bool>CrearPublicacion(string titulo, string contenido)
    {
        bool resultado = blog.CrearPublicacion(titulo, contenido);
        if(resultado){
            return Ok("Publicacion agregada con exito");
        }
        else{
            return StatusCode(500,"error al agregar publicacion");
        }
    }

    [HttpPut("/api/posts/{id}", Name = "Actualizar publicacion")]
    public ActionResult<bool> ActualizarPublicacion([FromRoute] int id, string titulo, string contenido)
    {
        if(blog.BuscarporPublicacionPorId(id)!=null){
            blog.ActualizarPost(id, titulo, contenido);
            return Ok("Pedido actualizado con exito");
        }
        else{
            return NotFound("Numero de pedido incorrecto");
        }
    }

    [HttpPut("/api/posts/MeGusta/{id}", Name = "Incrementar Me gusta")]
    // [Route ("Incrementar me gusta")]

    public ActionResult<bool> IncrementarMeGusta([FromRoute] int id)
    {  
        Post postBuscado = blog.BuscarporPublicacionPorId(id);
        if (postBuscado != null)
        {
            bool resultado = blog.DarMeGusta(postBuscado);
            if (resultado)
            {
                return Ok("Reaccion dada");            
            }
            else
            {
                return BadRequest("No se pudo dar me gusta");
            }
        }
        else
        {
            return BadRequest("No se opudo encntrar un Post con dicho id");
        }
    }

    [HttpDelete("/api/posts/{id}")]
    public ActionResult<bool> borrarPublicacion([FromRoute] int id)
    {
        if (blog.BuscarporPublicacionPorId(id) != null)
        {
            blog.EliminarPublicacion(id);
            return Ok("Posto eliminado con exito ");
        }
        else
        {
            return BadRequest("No se opudo encntrar un Post con dicho id");
        }

    }
    

}
