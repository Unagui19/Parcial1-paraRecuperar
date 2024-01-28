namespace Entidades
{
    public class Post
    {
        int id;
        string titulo;
        string contenido;
        DateTime fechaCreacion;
        Reaccion reaccion;


        public int Id { get => id; set => id = value; }
        public string Titulo { get => titulo; set => titulo = value; }
        public string Contenido { get => contenido; set => contenido = value; }
        public DateTime FechaCreacion { get => fechaCreacion; set => fechaCreacion = value.Date; }
        public Reaccion Reaccion { get => reaccion; set => reaccion = value; }
        public int CantidadDeMegusta{ get; set; }
        public int CantidadDeLecturas{ get; set; }

        public Post(int id, string titulo, string contenido, DateTime fechaCreacion)
        {
            this.Id = id;
            this.Titulo = titulo;
            this.Contenido = contenido;
            this.FechaCreacion = fechaCreacion;
            CantidadDeLecturas = 0;
            CantidadDeMegusta = 0;
            reaccion = new Reaccion();
        }

    }
}