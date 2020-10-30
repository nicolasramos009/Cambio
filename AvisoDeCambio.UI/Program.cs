using AvisoDeCambio.Interfaces;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace AvisoDeCambio.UI
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            List<IPlano> planos = new List<IPlano> {
                new PlanoPDM { Codigo="02-CM-CE", Revision=1, Title="PLANO DE CUBA" },
               /* new PlanoPDM { Codigo="02-CM-CD", Revision=0, Title="PLANO DE TAPA" },
                new PlanoPDM { Codigo="02-CM-CE", Revision=2, Title="PLANO" },
                new PlanoPDM { Codigo="02-CM-CD", Revision=2, Title="PLANO" }*/
            };
            Application.Run(new Form1(planos, TipoDeCambio.CONFIRMADO));
        }
    }
}
