﻿using AngleSharp;
using AngleSharp.Dom;
using AvisoDeCambio.Interfaces;
using Microsoft.Office.Interop.Outlook;
using System.IO;
using System.Threading.Tasks;

namespace AvisoDeCambio.Service
{
    public static class MailDeRev
    {
        public static void EnviarCorreo(IAvisoDeCambio aviso)
        {

            Application application = new Application();

            var mailItem = (MailItem)application.CreateItem(OlItemType.olMailItem);
            mailItem.To = string.Join(";", aviso.To);

            mailItem.Subject = aviso.ToString();
            mailItem.HTMLBody = CreateHtml(aviso).Result;
            mailItem.Display();

        }

        private async static Task<string> CreateHtml(IAvisoDeCambio aviso)
        {


            TextReader template = new StreamReader(@"Template.html");
            string html = template.ReadToEnd();
            var context = BrowsingContext.New(Configuration.Default);
            var document = await context.OpenAsync(req => req.Content(html));

            #region Datos de la cabecera
            document.QuerySelector("#notaDeVenta").InnerHtml = aviso.NotaVenta;
            document.QuerySelector("#cliente").InnerHtml = aviso.Cliente;
            document.QuerySelector("#codigoTransformador").InnerHtml = aviso.CodigoTrafo;
            document.QuerySelector("#potencia").InnerHtml = aviso.Potencia;
            document.QuerySelector("#tension").InnerHtml = aviso.Tensiones;
            #endregion Fin datos de la cabecera


            #region Tabla
            var tbody = document.QuerySelector("table > tbody");

            foreach (var plano in aviso.PlanosLista)
            {
                //creo la fila
                var tr = document.CreateElement("tr");
                tr.AppendChild(CreateCell(document, plano.Codigo));
                tr.AppendChild(CreateCell(document, plano.Title));
                tr.AppendChild(CreateCell(document, plano.Revision.ToString()));
                tr.AppendChild(CreateCell(document, plano.Codigo));
                tr.AppendChild(CreateCell(document, plano.Title));
                tr.AppendChild(CreateCell(document, plano.NextRevision.ToString()));
                tr.AppendChild(CreateCell(document, plano.Modificaciones));
                tr.AppendChild(CreateCell(document, plano.EstadoDelProceso));
                tr.AppendChild(CreateCell(document, plano.AccionASeguir));
                tr.AppendChild(CreateCell(document, plano.Observaciones));
                tbody.AppendChild(tr);
            }
            #endregion


            return document.DocumentElement.OuterHtml;

        }


        private static IElement CreateCell(IDocument document, string value)
        {
            var cell = document.CreateElement("td");
            cell.InnerHtml = value;
            return cell;
        }


    }
}
