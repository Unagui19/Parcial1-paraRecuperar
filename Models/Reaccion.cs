namespace Entidades
{   
    public enum TipoDeReaccion
    {
        sinReaccion,
        meGusta
    }
    public class Reaccion
    {

        // int IdDeReaccion;

        public TipoDeReaccion tipoDeReaccion{ get; set; }

        public Reaccion()
        {
            tipoDeReaccion=TipoDeReaccion.sinReaccion;
        }


    }


}