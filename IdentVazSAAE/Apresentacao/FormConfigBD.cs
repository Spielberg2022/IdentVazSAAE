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
    public partial class FormConfigBD : Form
    {
		public SqlConnection connection = new SqlConnection();

		ClassConfigBD_Apl configBD_Apl = new ClassConfigBD_Apl();
        ClassConfigBD_Per configBD_Per = new ClassConfigBD_Per();
        ClassConfigBD_Dom bd = new ClassConfigBD_Dom();
        BindingSource relacionamento = new BindingSource();
        char[] pesquisa = { '\\' };

        public FormConfigBD()
        {
            InitializeComponent();
            this.Cursor = Cursors.WaitCursor;
            AtualizarServidores();
            this.Cursor = Cursors.Default;
        }
		void Limpa()
		{
			this.Cursor = Cursors.WaitCursor;
			if (autenticação_comboBox.Text == "Autenticação do Windows" || autenticação_comboBox.Text == "")
			{
				autenticação_comboBox.Text = "Autenticação do Windows";
				usuário_textBox.Enabled = false;
				senha_textBox.Enabled = false;
			}
			else
			{
				autenticação_comboBox.Text = "Autenticação do SQL";
				usuário_textBox.Enabled = true;
				senha_textBox.Enabled = true;
			}
			usuário_textBox.ResetText();
			senha_textBox.ResetText();
			bd_comboBox.Text = "";
			bd_comboBox.DataSource = null;
			usuário_textBox.Focus();
			this.Cursor = Cursors.Default;
		}

		void PreencheBO()
		{
			bd = new ClassConfigBD_Dom();
			bd.Servidor = servidor_comboBox.Text;
			bd.Instância = instancia_comboBox.Text;
			bd.Autenticação = autenticação_comboBox.Text;
			bd.Usuário = usuário_textBox.Text;
			bd.Senha = senha_textBox.Text;
			bd.Bd = bd_comboBox.Text;
		}

		void AtualizarServidores()
		{
			this.Cursor = Cursors.WaitCursor;
			relacionamento.DataSource = configBD_Apl.pegaServidores();
			servidor_comboBox.DisplayMember = "ServerName";
			servidor_comboBox.DataSource = relacionamento;
			instancia_comboBox.DisplayMember = "InstanceName";
			instancia_comboBox.DataSource = relacionamento;
			this.Cursor = Cursors.Default;
			servidor_comboBox.Focus();
		}

		void Bd_comboBoxEnter(object sender, EventArgs e)
		{
			bd_comboBox.Text = "";
			PreencheBO();
			
			this.Cursor = Cursors.WaitCursor;
			if (autenticação_comboBox.Text != "")
			{
				if (autenticação_comboBox.Text == "Autenticação do Windows")
				{
					if (configBD_Apl.Conectar(bd))
						bd_comboBox.DataSource = configBD_Apl.pegaBDs();
					else
					{
						MessageBox.Show("Usuário do Windows sem permissão de entrada.\n\n" + configBD_Per.erro,
										"Atenção: ",
										  MessageBoxButtons.OK,
										 MessageBoxIcon.Exclamation);
						Limpa();
					}
				}
				else
				{
					if (usuário_textBox.Text != "" && senha_textBox.Text != "")
					{
						if (configBD_Apl.Conectar(bd))
							bd_comboBox.DataSource = configBD_Apl.pegaBDs();
						else
						{
							MessageBox.Show("Erro ao logar com autenticação SQL, usuário e senhas incorretos.\n\n" + configBD_Per.erro,
										"Erro",
										  MessageBoxButtons.OK,
										 MessageBoxIcon.Error);
							Limpa();
						}
					}
					else
					{
						MessageBox.Show("Informe um usuário e senha para autenticação SQL!",
								"Atenção!",
								MessageBoxButtons.OK,
								MessageBoxIcon.Exclamation);
						Limpa();
					}
				}
				
			}
			else
			{
				Limpa();
				Bd_comboBoxEnter(sender, e);
			}
			this.Cursor = Cursors.Default;		
		}

        private void FormConfigBD_FormClosed(object sender, FormClosedEventArgs e)
        {
			Application.Exit();
        }

        private void autenticação_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
			Limpa();
        }

        private void atualizarServidores_button_Click(object sender, EventArgs e)
        {
			Limpa();
			AtualizarServidores();
		}

        private void servidor_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
			Limpa();
		}

        private void cancelarButton_Click(object sender, EventArgs e)
        {
			this.Close();
        }

        private void testaBd_button_Click(object sender, EventArgs e)
        {
			bd.Bd = bd_comboBox.Text;
			if (configBD_Apl.Conectar(bd))
            {
				connection = configBD_Apl.connection;
				MessageBox.Show("Conexão com banco de dados bem sucedida!.",
										"Informação",
										 MessageBoxButtons.OK,
										 MessageBoxIcon.Information);
			}
			else
				MessageBox.Show("Erro ao tentar conectar com o banco de dados.\n\n" + configBD_Per.erro,
										"Erro",
										  MessageBoxButtons.OK,
										 MessageBoxIcon.Error);
		}

        private void okButton_Click(object sender, EventArgs e)
        {
			FormVerificaVazamento verificaVazamento = new FormVerificaVazamento();
			verificaVazamento.configBD_Apl = configBD_Apl;
			verificaVazamento.configBD_Per = configBD_Per;
			verificaVazamento.configBD_Dom = bd;
			verificaVazamento.connection = connection;
			verificaVazamento.Show();
			this.Hide();
        }
        
        void Bd_groupBoxEnter(object sender, EventArgs e)
        {
        	
        }
    }
}
