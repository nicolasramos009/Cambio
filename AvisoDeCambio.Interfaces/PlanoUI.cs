﻿namespace AvisoDeCambio.Interfaces
{
    public class PlanoUI : IPlano
    {
        public string Codigo { get; set; }
        public string Title { get; set; }
        public int Revision { get; set; }
        public int NextRevision => Revision + 1;
        public string Modificaciones { get; set; }
        public string EstadoDelProceso { get; set; }
        public string AccionASeguir { get; set; }
        public string Observaciones { get; set; }

        public PlanoUI(IPlano plano)
        {
            Codigo = plano.Codigo;
            Title = plano.Title;
            Revision = plano.Revision;


        }

        public PlanoUI()
        {

        }
        public override string ToString()
        {
            return $"[Codigo: {Codigo}]\n[Title: {Title}]\n[Revision: {Revision}]\n[NextRevision: {NextRevision}]\n[Modificaciones: {Modificaciones}]\n[EstadoDeProceso: {EstadoDelProceso}]\n[AccionesASeguir: {AccionASeguir}]\n[Observaciones:{Observaciones}]";

        }


    }
}
