using System;
using System.Collections.Generic;


namespace AvisoDeCambio.Interfaces
{
    public interface IAvisoDeCambio 
    {
        string NotaVenta { get; set; }
        String Potencia { get; set; }
        IList<PlanoUI> PlanosLista { get; set; }
        IEnumerable<string> To { get; set; }
        string CodigoTrafo { get; set; }
        string Tensiones { get; set; }
        string Cliente { get; set; }

    }
    public class Aviso : IAvisoDeCambio
    {
        public string NotaVenta { get; set; }
        public String Potencia { get; set; }
        public IList<PlanoUI> PlanosLista { get; set; } = new List<PlanoUI>();
        public IEnumerable<string> To { get; set; } = new List<string> { "nramos@artrans.com.ar" };

     

        public string CodigoTrafo { get; set; }
        public string Tensiones { get; set; }
        public string Cliente { get; set; }

        public override string ToString()
        {
            return $"Aviso de Cambio: {TipoDeCambio.CONFIRMADO}  Nota de Venta: {NotaVenta},  Cliente: {Cliente},   Codigo Trafo: {CodigoTrafo}, Potencia: {Potencia},  Tensiones: {Tensiones},   Cambiaron: {PlanosLista.Count} Planos";
        }
    }

}
