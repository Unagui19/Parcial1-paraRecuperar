using System.Security.AccessControl;
using System.Text.Json;
using System.Text.Json.Serialization;
using Entidades;

namespace DatoSpace
{
    public class AccesoADatos
    {
        public List<Post> GetPosts()
        {

            try
            {
                string textoJson = File.ReadAllText("Data/posts.json");
                List<Post> nuevaLista = JsonSerializer.Deserialize<List<Post>>(textoJson);
                return nuevaLista;
            }
            catch (Exception)
            {

                List<Post> nuevaLista = new List<Post>();
                return nuevaLista;
            }
    
            // try
            // {
            //     string filePath = "Data/posts.json";

            //     if (!File.Exists(filePath))
            //     {
            //         // Si el archivo no existe, lo crea con un array JSON vacío.
            //         File.WriteAllText(filePath, "[]");
            //     }

            //     string textoJson = File.ReadAllText(filePath);

            //     if (string.IsNullOrWhiteSpace(textoJson))
            //     {
            //         // Si el archivo está vacío o contiene solo espacios en blanco, retorna una lista vacía.
            //         return new List<Post>();
            //     }

            //     return JsonSerializer.Deserialize<List<Post>>(textoJson) ?? new List<Post>();
            // }
            // catch (Exception ex)
            // {
            //     // Manejar otras excepciones aquí según sea necesario.
            //     Console.WriteLine($"Error al obtener tareas: {ex.Message}");
            //     return new List<Post>();
            // }
        }

        public void guardarPosts(List<Post> posts)
        {    
            var fst = new FileStream("Data/posts.json",FileMode.Create);
            var options = new JsonSerializerOptions { WriteIndented = true };
            string archivoJson = JsonSerializer.Serialize<List<Post>>(posts, options);
            using (var sw =new StreamWriter(fst))
            {
                sw.WriteLine(archivoJson);
                sw.Close();
            }//PARA CREAR UN JSON y guardar o solo guardar 
            fst.Close();
        }
    }
}