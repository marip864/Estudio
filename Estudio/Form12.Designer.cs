namespace Estudio
{
    partial class Form12
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCPFAluno = new System.Windows.Forms.MaskedTextBox();
            this.cbxTurma = new System.Windows.Forms.ComboBox();
            this.cbxDiaSemana = new System.Windows.Forms.ComboBox();
            this.cbxHora = new System.Windows.Forms.ComboBox();
            this.btnCadastrar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnCadastrar);
            this.groupBox1.Controls.Add(this.cbxHora);
            this.groupBox1.Controls.Add(this.cbxDiaSemana);
            this.groupBox1.Controls.Add(this.cbxTurma);
            this.groupBox1.Controls.Add(this.txtCPFAluno);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(75, 55);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(639, 342);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Cadastrar";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(137, 82);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Aluno:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(132, 129);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Turma:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(77, 176);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Dia da Semana:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(141, 219);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "Hora:";
            // 
            // txtCPFAluno
            // 
            this.txtCPFAluno.Location = new System.Drawing.Point(199, 79);
            this.txtCPFAluno.Mask = "000.000.000-00";
            this.txtCPFAluno.Name = "txtCPFAluno";
            this.txtCPFAluno.Size = new System.Drawing.Size(292, 22);
            this.txtCPFAluno.TabIndex = 4;
            this.txtCPFAluno.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCPFAluno_KeyPress);
            // 
            // cbxTurma
            // 
            this.cbxTurma.Enabled = false;
            this.cbxTurma.FormattingEnabled = true;
            this.cbxTurma.Location = new System.Drawing.Point(199, 126);
            this.cbxTurma.Name = "cbxTurma";
            this.cbxTurma.Size = new System.Drawing.Size(292, 24);
            this.cbxTurma.TabIndex = 5;
            this.cbxTurma.SelectedIndexChanged += new System.EventHandler(this.cbxTurma_SelectedIndexChanged);
            // 
            // cbxDiaSemana
            // 
            this.cbxDiaSemana.Enabled = false;
            this.cbxDiaSemana.FormattingEnabled = true;
            this.cbxDiaSemana.Location = new System.Drawing.Point(199, 173);
            this.cbxDiaSemana.Name = "cbxDiaSemana";
            this.cbxDiaSemana.Size = new System.Drawing.Size(292, 24);
            this.cbxDiaSemana.TabIndex = 6;
            this.cbxDiaSemana.SelectedIndexChanged += new System.EventHandler(this.cbxDiaSemana_SelectedIndexChanged);
            // 
            // cbxHora
            // 
            this.cbxHora.Enabled = false;
            this.cbxHora.FormattingEnabled = true;
            this.cbxHora.Location = new System.Drawing.Point(199, 216);
            this.cbxHora.Name = "cbxHora";
            this.cbxHora.Size = new System.Drawing.Size(292, 24);
            this.cbxHora.TabIndex = 7;
            this.cbxHora.SelectedIndexChanged += new System.EventHandler(this.cbxHora_SelectedIndexChanged);
            // 
            // btnCadastrar
            // 
            this.btnCadastrar.Enabled = false;
            this.btnCadastrar.Location = new System.Drawing.Point(80, 273);
            this.btnCadastrar.Name = "btnCadastrar";
            this.btnCadastrar.Size = new System.Drawing.Size(459, 23);
            this.btnCadastrar.TabIndex = 8;
            this.btnCadastrar.Text = "Cadastrar";
            this.btnCadastrar.UseVisualStyleBackColor = true;
            this.btnCadastrar.Click += new System.EventHandler(this.btnCadastrar_Click);
            // 
            // Form12
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form12";
            this.Text = "Cadastrar Aluno em Turma";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.MaskedTextBox txtCPFAluno;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCadastrar;
        private System.Windows.Forms.ComboBox cbxHora;
        private System.Windows.Forms.ComboBox cbxDiaSemana;
        private System.Windows.Forms.ComboBox cbxTurma;
    }
}