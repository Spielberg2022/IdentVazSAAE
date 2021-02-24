using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using IdentificaVazSAAE.Domínio;
using IdentificaVazSAAE.Aplicação;
using IdentificaVazSAAE.Persistência;

namespace IdentificaVazSAAE.Apresentação
{
    public partial class FormVerificaVazamento : Form
    {
        public ClassVerificaVazamento_Apl verificaVazamento_Apl = new ClassVerificaVazamento_Apl();
        public ClassVerificaVazamento_Per verificaVazamento_Per = new ClassVerificaVazamento_Per();
        public ClassVerificaVazamento_Dom verificaVazamento_Dom = new ClassVerificaVazamento_Dom();

        public ClassConfigBD_Apl configBD_Apl = new ClassConfigBD_Apl();
        public ClassConfigBD_Per configBD_Per = new ClassConfigBD_Per();
        public ClassConfigBD_Dom configBD_Dom = new ClassConfigBD_Dom();

        public SqlConnection connection = new SqlConnection();

        public FormVerificaVazamento()
        {
            InitializeComponent();
        }

        private void localizar_button_Click(object sender, EventArgs e)
        {
            try
            {
                if(codLigacao_textBox.Text != "")
                {
                    verificaVazamento_Apl.connection = connection;
                    
                    verificaVazamento_Dom.ligacao = Int64.Parse(codLigacao_textBox.Text);
                    leituras_dataGridView.DataSource = verificaVazamento_Apl.ListaLeituras(verificaVazamento_Dom);
                    rol_dataGridView.DataSource = verificaVazamento_Apl.ListaRol(verificaVazamento_Dom);
                    verificaVazamento_Dom.mMensais = verificaVazamento_Apl.PreencheTabelaMediasMensais(verificaVazamento_Dom);
                    moda_dataGridView.DataSource = verificaVazamento_Apl.ListaModa(verificaVazamento_Dom);
                    jan_textBox.Text = verificaVazamento_Dom.mMensais.Rows[0][0].ToString();
                    fev_textBox.Text = verificaVazamento_Dom.mMensais.Rows[0][1].ToString();
                    mar_textBox.Text = verificaVazamento_Dom.mMensais.Rows[0][2].ToString();
                    abr_textBox.Text = verificaVazamento_Dom.mMensais.Rows[0][3].ToString();
                    mai_textBox.Text = verificaVazamento_Dom.mMensais.Rows[0][4].ToString();
                    jun_textBox.Text = verificaVazamento_Dom.mMensais.Rows[0][5].ToString();
                    jul_textBox.Text = verificaVazamento_Dom.mMensais.Rows[0][6].ToString();
                    ago_textBox.Text = verificaVazamento_Dom.mMensais.Rows[0][7].ToString();
                    set_textBox.Text = verificaVazamento_Dom.mMensais.Rows[0][8].ToString();
                    out_textBox.Text = verificaVazamento_Dom.mMensais.Rows[0][9].ToString();
                    nov_textBox.Text = verificaVazamento_Dom.mMensais.Rows[0][10].ToString();
                    dez_textBox.Text = verificaVazamento_Dom.mMensais.Rows[0][11].ToString();
                    verificaVazamento_Dom.consumoMaximo = verificaVazamento_Apl.VerConsumoMaximo(verificaVazamento_Dom);
                    consumoMaxFaturado_textBox.Text = verificaVazamento_Dom.consumoMaximo.ToString();
                    verificaVazamento_Dom.consumoMinimo = verificaVazamento_Apl.VerConsumoMinimo(verificaVazamento_Dom);
                    consumoMinFaturado_textBox.Text = verificaVazamento_Dom.consumoMinimo.ToString();
                    verificaVazamento_Dom.mediault3meses = verificaVazamento_Apl.VerMediaUlt3Meses(verificaVazamento_Dom);
                    mediaUlt3meses_textBox.Text = verificaVazamento_Dom.mediault3meses.ToString();
                    verificaVazamento_Dom.mediaGeral = verificaVazamento_Apl.VerMediaGeral(verificaVazamento_Dom);
                    mediaGeral_textBox.Text = verificaVazamento_Dom.mediaGeral.ToString();
                    verificaVazamento_Dom.desvioPadraoGeral = verificaVazamento_Apl.VerDesvioPadrao(verificaVazamento_Dom);
                    desvioPadrao_textBox.Text = verificaVazamento_Dom.desvioPadraoGeral.ToString();
                    verificaVazamento_Dom.consumoPadraoMaximo = verificaVazamento_Apl.VerConsumoPadraoMax(verificaVazamento_Dom);
                    mediaPadraoMax_textBox.Text = verificaVazamento_Dom.consumoPadraoMaximo.ToString();
                    if (verificaVazamento_Apl.verificaUltConta())
                        MessageBox.Show("Possível Vazamento! Última conta faturada excedeu o limite de consumo em comparação com a conta do mês anterior!\n\nData de referência: " + verificaVazamento_Apl.verificaVazamento_Dom.dataRef + ".\nConsumo Faturado: " + verificaVazamento_Apl.verificaVazamento_Dom.consumoAtual + ".\nConsumo Máximo Permitido: " + verificaVazamento_Dom.consumoPadraoMaximo + ".",
                            "Atenção!",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Exclamation);
                    else
                        MessageBox.Show("Última conta faturada está dentro do padrão normal.",
                            "Mensagem: ",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    if (verificaVazamento_Apl.verificaVazamento_Dom.leituras.Rows.Count > 0)
                    {
                        verificaVazamento_Dom.vazamentos = verificaVazamento_Apl.verificaVazamentos(verificaVazamento_Dom);
                        vazamentos_dataGridView.DataSource = verificaVazamento_Dom.vazamentos;
                    }
                    else
                        MessageBox.Show("Tabela de leituras vazia",
                            "Erro ",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                }
                else
                    MessageBox.Show("Informe um código de ligação para continuar!",
                            "Atenção!",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Exclamation);

            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message,
                        "Erro:",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
            }
            finally
            {

            }
        }

        private void FormVerificaVazamento_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void simFat_button_Click(object sender, EventArgs e)
        {
            try
            {
                int linha;
                linha = int.Parse(vazamentos_dataGridView.CurrentRow.Index.ToString());
                if (simFatMedMeses_radioButton.Checked)
                {
                    switch (verificaVazamento_Dom.vazamentos.Rows[linha][0].ToString().Substring(0, 2))
                    {
                        case "01":
                            vrSimulação_textBox.Text = verificaVazamento_Apl.SimulaValorConta(verificaVazamento_Dom, linha, verificaVazamento_Dom.mediaJan).ToString();
                            break;
                        case "02":
                            vrSimulação_textBox.Text = verificaVazamento_Apl.SimulaValorConta(verificaVazamento_Dom, linha, verificaVazamento_Dom.mediaFev).ToString();
                            break;
                        case "03":
                            vrSimulação_textBox.Text = verificaVazamento_Apl.SimulaValorConta(verificaVazamento_Dom, linha, verificaVazamento_Dom.mediaMar).ToString();
                            break;
                        case "04":
                            vrSimulação_textBox.Text = verificaVazamento_Apl.SimulaValorConta(verificaVazamento_Dom, linha, verificaVazamento_Dom.mediaAbr).ToString();
                            break;
                        case "05":
                            vrSimulação_textBox.Text = verificaVazamento_Apl.SimulaValorConta(verificaVazamento_Dom, linha, verificaVazamento_Dom.mediaMai).ToString();
                            break;
                        case "06":
                            vrSimulação_textBox.Text = verificaVazamento_Apl.SimulaValorConta(verificaVazamento_Dom, linha, verificaVazamento_Dom.mediaJun).ToString();
                            break;
                        case "07":
                            vrSimulação_textBox.Text = verificaVazamento_Apl.SimulaValorConta(verificaVazamento_Dom, linha, verificaVazamento_Dom.mediaJul).ToString();
                            break;
                        case "08":
                            vrSimulação_textBox.Text = verificaVazamento_Apl.SimulaValorConta(verificaVazamento_Dom, linha, verificaVazamento_Dom.mediaAgo).ToString();
                            break;
                        case "09":
                            vrSimulação_textBox.Text = verificaVazamento_Apl.SimulaValorConta(verificaVazamento_Dom, linha, verificaVazamento_Dom.mediaSet).ToString();
                            break;
                        case "10":
                            vrSimulação_textBox.Text = verificaVazamento_Apl.SimulaValorConta(verificaVazamento_Dom, linha, verificaVazamento_Dom.mediaOut).ToString();
                            break;
                        case "11":
                            vrSimulação_textBox.Text = verificaVazamento_Apl.SimulaValorConta(verificaVazamento_Dom, linha, verificaVazamento_Dom.mediaNov).ToString();
                            break;
                        case "12":
                            vrSimulação_textBox.Text = verificaVazamento_Apl.SimulaValorConta(verificaVazamento_Dom, linha, verificaVazamento_Dom.mediaDez).ToString();
                            break;
                        default:
                            MessageBox.Show("Nenhum mês selecionado! Selecione algum mês!",
                                "Atenção:",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation);
                            break;
                    }
                }
                else if (simFatMedGer_radioButton.Checked)
                    vrSimulação_textBox.Text = verificaVazamento_Apl.SimulaValorConta(verificaVazamento_Dom, linha, verificaVazamento_Dom.mediaGeral).ToString();
                else if (simFatMed3_radioButton.Checked)
                    vrSimulação_textBox.Text = verificaVazamento_Apl.SimulaValorConta(verificaVazamento_Dom, linha, verificaVazamento_Dom.mediault3meses).ToString();
                else if(simFatConsMaxPadr_radioButton.Checked)
                    vrSimulação_textBox.Text = verificaVazamento_Apl.SimulaValorConta(verificaVazamento_Dom, linha, verificaVazamento_Dom.consumoPadraoMaximo).ToString();
                else if(simFatMed3ConsMaxPadr_radioButton.Checked)
                {
                    switch (verificaVazamento_Dom.vazamentos.Rows[linha][0].ToString().Substring(0, 2))
                    {
                        case "01":
                            vrSimulação_textBox.Text = verificaVazamento_Apl.SimulaValorConta(verificaVazamento_Dom, linha, verificaVazamento_Dom.mediaJan + verificaVazamento_Dom.desvioPadraoGeral).ToString();
                            break;
                        case "02":
                            vrSimulação_textBox.Text = verificaVazamento_Apl.SimulaValorConta(verificaVazamento_Dom, linha, verificaVazamento_Dom.mediaFev + verificaVazamento_Dom.desvioPadraoGeral).ToString();
                            break;
                        case "03":
                            vrSimulação_textBox.Text = verificaVazamento_Apl.SimulaValorConta(verificaVazamento_Dom, linha, verificaVazamento_Dom.mediaMar + verificaVazamento_Dom.desvioPadraoGeral).ToString();
                            break;
                        case "04":
                            vrSimulação_textBox.Text = verificaVazamento_Apl.SimulaValorConta(verificaVazamento_Dom, linha, verificaVazamento_Dom.mediaAbr + verificaVazamento_Dom.desvioPadraoGeral).ToString();
                            break;
                        case "05":
                            vrSimulação_textBox.Text = verificaVazamento_Apl.SimulaValorConta(verificaVazamento_Dom, linha, verificaVazamento_Dom.mediaMai + verificaVazamento_Dom.desvioPadraoGeral).ToString();
                            break;
                        case "06":
                            vrSimulação_textBox.Text = verificaVazamento_Apl.SimulaValorConta(verificaVazamento_Dom, linha, verificaVazamento_Dom.mediaJun + verificaVazamento_Dom.desvioPadraoGeral).ToString();
                            break;
                        case "07":
                            vrSimulação_textBox.Text = verificaVazamento_Apl.SimulaValorConta(verificaVazamento_Dom, linha, verificaVazamento_Dom.mediaJul + verificaVazamento_Dom.desvioPadraoGeral).ToString();
                            break;
                        case "08":
                            vrSimulação_textBox.Text = verificaVazamento_Apl.SimulaValorConta(verificaVazamento_Dom, linha, verificaVazamento_Dom.mediaAgo + verificaVazamento_Dom.desvioPadraoGeral).ToString();
                            break;
                        case "09":
                            vrSimulação_textBox.Text = verificaVazamento_Apl.SimulaValorConta(verificaVazamento_Dom, linha, verificaVazamento_Dom.mediaSet + verificaVazamento_Dom.desvioPadraoGeral).ToString();
                            break;
                        case "10":
                            vrSimulação_textBox.Text = verificaVazamento_Apl.SimulaValorConta(verificaVazamento_Dom, linha, verificaVazamento_Dom.mediaOut + verificaVazamento_Dom.desvioPadraoGeral).ToString();
                            break;
                        case "11":
                            vrSimulação_textBox.Text = verificaVazamento_Apl.SimulaValorConta(verificaVazamento_Dom, linha, verificaVazamento_Dom.mediaNov + verificaVazamento_Dom.desvioPadraoGeral).ToString();
                            break;
                        case "12":
                            vrSimulação_textBox.Text = verificaVazamento_Apl.SimulaValorConta(verificaVazamento_Dom, linha, verificaVazamento_Dom.mediaDez + verificaVazamento_Dom.desvioPadraoGeral).ToString();
                            break;
                        default:
                            MessageBox.Show("Nenhum mês selecionado! Selecione algum mês!",
                                "Atenção:",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation);
                            break;
                    }
                }

                //MessageBox.Show(verificaVazamento_Apl.SimulaValorConta(verificaVazamento_Dom, linha).ToString());
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message,
                        "Erro:",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
            }
            finally
            {

            }
        }
    }
}
