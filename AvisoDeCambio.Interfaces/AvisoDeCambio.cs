/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvisoDeCambio.Interfaces
{
    public class AvisoDeCambio : IAvisoDeCambio
    {
        public string NotaVenta { get; set; }
        public String Potencia { get; set; }
        public IList<PlanoUI> PlanosLista { get; set; } = new List<PlanoUI>();
        public IEnumerable<string> To { get; set; } = new List<string> { "nramos@artrans.com.ar", "nramos@artrans.com.ar" };
        public string CodigoTrafo { get; set; }
        public string Tensiones { get; set; }

        public override string ToString()
        {
            return $"Aviso de cambio!!  Nota de Venta: {NotaVenta}, Potencia: {Potencia}, Cambiaron: {PlanosLista.Count}Planos";
        }


    }
}
*/