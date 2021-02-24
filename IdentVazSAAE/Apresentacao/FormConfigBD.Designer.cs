
namespace IdentificaVazSAAE.Apresentação
{
    partial class FormConfigBD
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
        	System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormConfigBD));
        	this.bd_groupBox = new System.Windows.Forms.GroupBox();
        	this.instancia_label = new System.Windows.Forms.Label();
        	this.instancia_comboBox = new System.Windows.Forms.ComboBox();
        	this.atualizarServidores_button = new System.Windows.Forms.Button();
        	this.bd_comboBox = new System.Windows.Forms.ComboBox();
        	this.bd_label = new System.Windows.Forms.Label();
        	this.senha_label = new System.Windows.Forms.Label();
        	this.usuário_label = new System.Windows.Forms.Label();
        	this.autenticação_label = new System.Windows.Forms.Label();
        	this.senha_textBox = new System.Windows.Forms.TextBox();
        	this.usuário_textBox = new System.Windows.Forms.TextBox();
        	this.autenticação_comboBox = new System.Windows.Forms.ComboBox();
        	this.servidor_comboBox = new System.Windows.Forms.ComboBox();
        	this.servidor_label = new System.Windows.Forms.Label();
        	this.okButton = new System.Windows.Forms.Button();
        	this.cancelarButton = new System.Windows.Forms.Button();
        	this.testaBd_button = new System.Windows.Forms.Button();
        	this.bd_groupBox.SuspendLayout();
        	this.SuspendLayout();
        	// 
        	// bd_groupBox
        	// 
        	this.bd_groupBox.Controls.Add(this.instancia_label);
        	this.bd_groupBox.Controls.Add(this.instancia_comboBox);
        	this.bd_groupBox.Controls.Add(this.atualizarServidores_button);
        	this.bd_groupBox.Controls.Add(this.bd_comboBox);
        	this.bd_groupBox.Controls.Add(this.bd_label);
        	this.bd_groupBox.Controls.Add(this.senha_label);
        	this.bd_groupBox.Controls.Add(this.usuário_label);
        	this.bd_groupBox.Controls.Add(this.autenticação_label);
        	this.bd_groupBox.Controls.Add(this.senha_textBox);
        	this.bd_groupBox.Controls.Add(this.usuário_textBox);
        	this.bd_groupBox.Controls.Add(this.autenticação_comboBox);
        	this.bd_groupBox.Controls.Add(this.servidor_comboBox);
        	this.bd_groupBox.Controls.Add(this.servidor_label);
        	this.bd_groupBox.Location = new System.Drawing.Point(12, 12);
        	this.bd_groupBox.Name = "bd_groupBox";
        	this.bd_groupBox.Size = new System.Drawing.Size(315, 191);
        	this.bd_groupBox.TabIndex = 1;
        	this.bd_groupBox.TabStop = false;
        	this.bd_groupBox.Text = "Configurações do banco de dados:";
        	this.bd_groupBox.Enter += new System.EventHandler(this.Bd_groupBoxEnter);
        	// 
        	// instancia_label
        	// 
        	this.instancia_label.Location = new System.Drawing.Point(14, 52);
        	this.instancia_label.Name = "instancia_label";
        	this.instancia_label.Size = new System.Drawing.Size(92, 18);
        	this.instancia_label.TabIndex = 11;
        	this.instancia_label.Text = "Instância:";
        	this.instancia_label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        	// 
        	// instancia_comboBox
        	// 
        	this.instancia_comboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
        	this.instancia_comboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
        	this.instancia_comboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
        	this.instancia_comboBox.FormattingEnabled = true;
        	this.instancia_comboBox.Location = new System.Drawing.Point(112, 52);
        	this.instancia_comboBox.Name = "instancia_comboBox";
        	this.instancia_comboBox.Size = new System.Drawing.Size(188, 21);
        	this.instancia_comboBox.TabIndex = 2;
        	// 
        	// atualizarServidores_button
        	// 
        	this.atualizarServidores_button.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("atualizarServidores_button.BackgroundImage")));
        	this.atualizarServidores_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
        	this.atualizarServidores_button.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
        	this.atualizarServidores_button.Location = new System.Drawing.Point(272, 26);
        	this.atualizarServidores_button.Name = "atualizarServidores_button";
        	this.atualizarServidores_button.Size = new System.Drawing.Size(28, 23);
        	this.atualizarServidores_button.TabIndex = 0;
        	this.atualizarServidores_button.UseVisualStyleBackColor = true;
        	this.atualizarServidores_button.Click += new System.EventHandler(this.atualizarServidores_button_Click);
        	// 
        	// bd_comboBox
        	// 
        	this.bd_comboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
        	this.bd_comboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
        	this.bd_comboBox.DisplayMember = "Name";
        	this.bd_comboBox.FormattingEnabled = true;
        	this.bd_comboBox.Location = new System.Drawing.Point(112, 156);
        	this.bd_comboBox.Name = "bd_comboBox";
        	this.bd_comboBox.Size = new System.Drawing.Size(188, 21);
        	this.bd_comboBox.TabIndex = 6;
        	this.bd_comboBox.Enter += new System.EventHandler(this.Bd_comboBoxEnter);
        	// 
        	// bd_label
        	// 
        	this.bd_label.Location = new System.Drawing.Point(14, 156);
        	this.bd_label.Name = "bd_label";
        	this.bd_label.Size = new System.Drawing.Size(92, 18);
        	this.bd_label.TabIndex = 9;
        	this.bd_label.Text = "Banco de Dados:";
        	this.bd_label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        	// 
        	// senha_label
        	// 
        	this.senha_label.Location = new System.Drawing.Point(14, 130);
        	this.senha_label.Name = "senha_label";
        	this.senha_label.Size = new System.Drawing.Size(92, 18);
        	this.senha_label.TabIndex = 8;
        	this.senha_label.Text = "Senha:";
        	this.senha_label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        	// 
        	// usuário_label
        	// 
        	this.usuário_label.Location = new System.Drawing.Point(14, 104);
        	this.usuário_label.Name = "usuário_label";
        	this.usuário_label.Size = new System.Drawing.Size(92, 18);
        	this.usuário_label.TabIndex = 7;
        	this.usuário_label.Text = "Usuário:";
        	this.usuário_label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        	// 
        	// autenticação_label
        	// 
        	this.autenticação_label.Location = new System.Drawing.Point(14, 77);
        	this.autenticação_label.Name = "autenticação_label";
        	this.autenticação_label.Size = new System.Drawing.Size(92, 18);
        	this.autenticação_label.TabIndex = 6;
        	this.autenticação_label.Text = "Autenticação:";
        	this.autenticação_label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        	// 
        	// senha_textBox
        	// 
        	this.senha_textBox.Enabled = false;
        	this.senha_textBox.Location = new System.Drawing.Point(112, 130);
        	this.senha_textBox.Name = "senha_textBox";
        	this.senha_textBox.Size = new System.Drawing.Size(188, 20);
        	this.senha_textBox.TabIndex = 5;
        	this.senha_textBox.UseSystemPasswordChar = true;
        	// 
        	// usuário_textBox
        	// 
        	this.usuário_textBox.Enabled = false;
        	this.usuário_textBox.Location = new System.Drawing.Point(112, 104);
        	this.usuário_textBox.Name = "usuário_textBox";
        	this.usuário_textBox.Size = new System.Drawing.Size(188, 20);
        	this.usuário_textBox.TabIndex = 4;
        	// 
        	// autenticação_comboBox
        	// 
        	this.autenticação_comboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
        	this.autenticação_comboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
        	this.autenticação_comboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        	this.autenticação_comboBox.FormattingEnabled = true;
        	this.autenticação_comboBox.Items.AddRange(new object[] {
        	        	        	"Autenticação do Windows",
        	        	        	"Autenticação do Servidor SQL"});
        	this.autenticação_comboBox.Location = new System.Drawing.Point(112, 77);
        	this.autenticação_comboBox.Name = "autenticação_comboBox";
        	this.autenticação_comboBox.Size = new System.Drawing.Size(188, 21);
        	this.autenticação_comboBox.TabIndex = 3;
        	this.autenticação_comboBox.Tag = "";
        	this.autenticação_comboBox.SelectedIndexChanged += new System.EventHandler(this.autenticação_comboBox_SelectedIndexChanged);
        	// 
        	// servidor_comboBox
        	// 
        	this.servidor_comboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
        	this.servidor_comboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
        	this.servidor_comboBox.FormattingEnabled = true;
        	this.servidor_comboBox.Location = new System.Drawing.Point(112, 27);
        	this.servidor_comboBox.Name = "servidor_comboBox";
        	this.servidor_comboBox.Size = new System.Drawing.Size(154, 21);
        	this.servidor_comboBox.TabIndex = 1;
        	this.servidor_comboBox.SelectedIndexChanged += new System.EventHandler(this.servidor_comboBox_SelectedIndexChanged);
        	// 
        	// servidor_label
        	// 
        	this.servidor_label.Location = new System.Drawing.Point(14, 27);
        	this.servidor_label.Name = "servidor_label";
        	this.servidor_label.Size = new System.Drawing.Size(92, 18);
        	this.servidor_label.TabIndex = 0;
        	this.servidor_label.Text = "Servidor:";
        	this.servidor_label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        	// 
        	// okButton
        	// 
        	this.okButton.Location = new System.Drawing.Point(333, 21);
        	this.okButton.Name = "okButton";
        	this.okButton.Size = new System.Drawing.Size(68, 23);
        	this.okButton.TabIndex = 3;
        	this.okButton.Text = "&Ok";
        	this.okButton.UseVisualStyleBackColor = true;
        	this.okButton.Click += new System.EventHandler(this.okButton_Click);
        	// 
        	// cancelarButton
        	// 
        	this.cancelarButton.Location = new System.Drawing.Point(333, 50);
        	this.cancelarButton.Name = "cancelarButton";
        	this.cancelarButton.Size = new System.Drawing.Size(68, 23);
        	this.cancelarButton.TabIndex = 4;
        	this.cancelarButton.Text = "&Cancelar";
        	this.cancelarButton.UseVisualStyleBackColor = true;
        	this.cancelarButton.Click += new System.EventHandler(this.cancelarButton_Click);
        	// 
        	// testaBd_button
        	// 
        	this.testaBd_button.Location = new System.Drawing.Point(333, 79);
        	this.testaBd_button.Name = "testaBd_button";
        	this.testaBd_button.Size = new System.Drawing.Size(68, 124);
        	this.testaBd_button.TabIndex = 5;
        	this.testaBd_button.Text = "&Testar conexão com o Bd";
        	this.testaBd_button.UseVisualStyleBackColor = true;
        	this.testaBd_button.Click += new System.EventHandler(this.testaBd_button_Click);
        	// 
        	// FormConfigBD
        	// 
        	this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        	this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        	this.ClientSize = new System.Drawing.Size(409, 215);
        	this.Controls.Add(this.testaBd_button);
        	this.Controls.Add(this.cancelarButton);
        	this.Controls.Add(this.okButton);
        	this.Controls.Add(this.bd_groupBox);
        	this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
        	this.Name = "FormConfigBD";
        	this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        	this.Text = "Configurações do BD";
        	this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormConfigBD_FormClosed);
        	this.bd_groupBox.ResumeLayout(false);
        	this.bd_groupBox.PerformLayout();
        	this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.GroupBox bd_groupBox;
        private System.Windows.Forms.Label instancia_label;
        private System.Windows.Forms.ComboBox instancia_comboBox;
        private System.Windows.Forms.Button atualizarServidores_button;
        private System.Windows.Forms.ComboBox bd_comboBox;
        private System.Windows.Forms.Label bd_label;
        private System.Windows.Forms.Label senha_label;
        private System.Windows.Forms.Label usuário_label;
        private System.Windows.Forms.Label autenticação_label;
        private System.Windows.Forms.TextBox senha_textBox;
        private System.Windows.Forms.TextBox usuário_textBox;
        private System.Windows.Forms.ComboBox autenticação_comboBox;
        private System.Windows.Forms.ComboBox servidor_comboBox;
        private System.Windows.Forms.Label servidor_label;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelarButton;
        private System.Windows.Forms.Button testaBd_button;
    }
}