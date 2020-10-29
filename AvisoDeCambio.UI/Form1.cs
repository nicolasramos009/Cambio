using AvisoDeCambio.Interfaces;
using AvisoDeCambio.Service;
using System;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Forms;
using TextBox = System.Windows.Controls.TextBox;
using WebBrowser = System.Windows.Forms.WebBrowser;

namespace AvisoDeCambio.UI
{
    public partial class Form1 : Form
    {
        private List<PlanoUI> _planos = new List<PlanoUI>();
        private TipoDeCambio _tipoDeCambio;
        public Form1(List<IPlano> planos, TipoDeCambio tipoDeCambio)
        {

            foreach (var plano in planos)
            {
                _planos.Add(new PlanoUI(plano));
            }

            _tipoDeCambio = tipoDeCambio;

            Load += Form1_Load;

            InitializeComponent();
        }



        private void Form1_Load(object sender, EventArgs e)
        {
            btnEnviar.Click += BtnEnviar_Click;
            switch (_tipoDeCambio)
            {
                case TipoDeCambio.Inicial:
                    label1.Text = "AVISO DE CAMBIO POSIBLE";
                    break;
                case TipoDeCambio.Confirmado:
                    label1.Text = "AVISO DE CAMBIO REALIZADO";
                    break;
                case TipoDeCambio.Retirado:
                    label1.Text = "AVISO DE CAMBIO DESESTIMADO";
                    break;
            }

            var codigoDePlano = new DataGridViewTextBoxColumn
            {
                Name = "codigo",
                HeaderText = "Codigo",
                ReadOnly = true
            };

            var titleColumn = new DataGridViewTextBoxColumn
            {
                Name = "title",
                HeaderText = "Titulo",
                ReadOnly = true
            };

            var revisionColumn = new DataGridViewTextBoxColumn
            {
                Name = "rev",
                HeaderText = "Revision",
                ReadOnly = true
            };

            var nuevaRevisionColumn = new DataGridViewTextBoxColumn
            {
                Name = "newRev",
                HeaderText = "Nueva Revision",
                ReadOnly = true
            };

            //editables
            var modificacionRealizada = new DataGridViewTextBoxColumn
            {
                Name = "modificacionRealizada",
                HeaderText = "Modificacion realizada"
            };

            var estadoDelProceso = new DataGridViewComboBoxColumn
            {
                Name = "estadoDelProceso",
                HeaderText = "Estado del plroceso",
            };

            var accionASeguir = new DataGridViewComboBoxColumn
            {
                Name = "accionASeguir",
                HeaderText = "Accion a Seguir",
            };
            var observaciones = new DataGridViewTextBoxColumn
            {
                Name = "observaciones",
                HeaderText = "Observaciones",
            };

            //leo la lista
            foreach (var estadoDeProceso in AvisoDeCambioInfo.EstadoDelProceso)
            {
                estadoDelProceso.Items.Add(estadoDeProceso);
            }
            foreach (var accionAseguir in AvisoDeCambioInfo.AccionASeguir)
            {
                accionASeguir.Items.Add(accionAseguir);
            }


            tablaPlano.AllowUserToAddRows = false;
            tablaPlano.Columns.Add(codigoDePlano);
            tablaPlano.Columns.Add(titleColumn);
            tablaPlano.Columns.Add(revisionColumn);
            tablaPlano.Columns.Add(nuevaRevisionColumn);
            tablaPlano.Columns.Add(modificacionRealizada);
            tablaPlano.Columns.Add(estadoDelProceso);
            tablaPlano.Columns.Add(accionASeguir);
            tablaPlano.Columns.Add(observaciones);

            loadData();
        }
        private void loadData()
        {
            foreach (var plano in _planos)
            {
                tablaPlano.Rows.Add(plano.Codigo, plano.Title, plano.Revision, plano.NextRevision);
            }
        }

        private void BtnEnviar_Click(object sender, EventArgs e)


        {
           
            var aviso = new Aviso
            {
                NotaVenta = "13054",
                CodigoTrafo = "07-LSDGFSDGF2165140001",
                Potencia = "40MVA",
                Tensiones = "1312313",
                Cliente = "Nicolas"


            };

            foreach (DataGridViewRow fila in tablaPlano.Rows)
            {
                var planoUi = new PlanoUI();
                foreach (DataGridViewCell celda in fila.Cells)
                {
                    if (celda.OwningColumn.Name == "codigo")
                    {
                        planoUi.Codigo = celda.Value.ToString();
                    }

                    if (celda.OwningColumn.Name == "title")
                    {
                        planoUi.Title = celda.Value.ToString();
                    }

                    if (celda.OwningColumn.Name == "rev")
                    {
                        planoUi.Revision = int.Parse(celda.Value.ToString());
                    }


                    if (celda.OwningColumn.Name == "modificacionRealizada")
                    {
                        if (celda.Value == null)
                        {
                            MessageBox.Show("La modificacion es obligatoria");
                            return;
                        }
                        planoUi.Modificaciones = celda.Value.ToString();
                    }

                    if (celda.OwningColumn.Name == "accionASeguir")
                    {
                        if (celda.Value == null)
                        {
                            MessageBox.Show("Debe completar Accion a seguir!!");
                            return;
                        }
                        planoUi.AccionASeguir = celda.Value.ToString();
                    }
                    if (celda.OwningColumn.Name == "estadoDelProceso")
                    {
                        if (celda.Value == null)
                        {
                            MessageBox.Show("Debe completar El estado del proceso!!");
                            return;
                        }
                        planoUi.EstadoDelProceso = celda.Value.ToString();
                    }
                    if (celda.OwningColumn.Name == "observaciones")
                    {
                        planoUi.Observaciones = celda.Value.ToString();
                    }



                }
                aviso.PlanosLista.Add(planoUi);
            }
            MailDeRev.EnviarCorreo(aviso);
        }

       
    }
}