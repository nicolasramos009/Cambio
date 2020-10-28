using System.Collections.Generic;

namespace AvisoDeCambio.Interfaces
{
    public static class AvisoDeCambioInfo
    {


        public static List<string> AccionASeguir => new List<string>
        {

            "Procesar con última revisión",
            "Dejar como está",
            "Retrabajar",
            "Enviar a Scrapp"

        };
        public static List<string> EstadoDelProceso => new List<string>
        {

            "No iniciado",
            "Con orden de compra",
            "En proceso",
            "Terminado"
        };
    }
}
