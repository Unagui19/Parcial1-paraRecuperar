using DatoSpace;
using Entidades;

namespace Entidades
{
    public class Blog
    {
        public string Nombre{ get;}
        public string Descripcion{ get;}
        public List<Post> Posts { get; set; }
        // public int cantidadDePosts {get; set;}
        AccesoADatos accesoDatos;

        public Blog()
        {
            Nombre = "Blog del Parcial";
            Descripcion = "Un blog asi nomas";
            accesoDatos = new AccesoADatos();
            Posts = accesoDatos.GetPosts();
            // cantidadDePosts=0;
        }


        // private static Blog instancia;

        // public static Blog GetInstancia()
        // {
        //     if (instancia == null)
        //     {
        //         AccesoADatos helper= new AccesoADatos();
        //         instancia = new Blog();
        //         // List<Post> posts= helper.GetPosts();
        //     }
        //     return instancia;
        // }

        
        public List<Post> ListarPubliciones()
        {
            return Posts;
        }

        public Post BuscarporPublicacionPorId(int id)
        {
            Post post = Posts.FirstOrDefault(post => post.Id == id);
            if (post!=null)
            {
                return post;            
            }
            else
            {
                return null;
            }
        }

        public bool CrearPublicacion(string titulo, string contenido)
        {
            // cantidadDePosts++;

            // DateTime fechaActual = DateTime.Now;
            Post nuevoPost = new Post( Posts.Count()+1, titulo, contenido, DateTime.Now);
            if(nuevoPost==null) return false;
            Posts.Add(nuevoPost);
            accesoDatos.guardarPosts(Posts);
            return true;
        }

        public void ActualizarPost(int idPosts, string titulo, string contenido){

            Post postBuscado = BuscarporPublicacionPorId(idPosts);
            if (postBuscado != null)
            {
                postBuscado.Titulo = titulo;
                postBuscado.Contenido = contenido;
                accesoDatos.guardarPosts(Posts);
            }
        }
        
        public bool DarMeGusta(Post post)
        {
            if (post != null)
            {
                post.Reaccion.tipoDeReaccion = TipoDeReaccion.meGusta; 
                post.CantidadDeMegusta++;
                accesoDatos.guardarPosts(Posts);
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool EliminarPublicacion(int idPost)
        {
            Post post = BuscarporPublicacionPorId(idPost);
            if(post!=null){
                Posts.Remove(post);
                accesoDatos.guardarPosts(Posts);
                return true;
            }
            else{
                return false;
            }
        }


    }
    
}