using System;
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
        string IAvisoDeCambio.NotaVenta { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        string IAvisoDeCambio.Potencia { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        IList<PlanoUI> IAvisoDeCambio.PlanosLista { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        IEnumerable<string> IAvisoDeCambio.To { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        string IAvisoDeCambio.CodigoTrafo { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        string IAvisoDeCambio.Tensiones { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        string IAvisoDeCambio.Cliente { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override string ToString()
        {
            return $"Aviso de cambio!!  Nota de Venta: {NotaVenta}, Potencia: {Potencia}, Cambiaron: {PlanosLista.Count}Planos";
        }


    }
}
