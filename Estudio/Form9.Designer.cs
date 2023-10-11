namespace Estudio
{
    partial class Form9
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
            this.txtAlunos = new System.Windows.Forms.TextBox();
            this.lblQtde_alunos = new System.Windows.Forms.Label();
            this.txtHoras = new System.Windows.Forms.MaskedTextBox();
            this.btnCadastrar = new System.Windows.Forms.Button();
            this.txtDiaSemana = new System.Windows.Forms.TextBox();
            this.txtProfessor = new System.Windows.Forms.TextBox();
            this.txtModalidade = new System.Windows.Forms.TextBox();
            this.lblHora = new System.Windows.Forms.Label();
            this.lblDiaSemana = new System.Windows.Forms.Label();
            this.lblProfessor = new System.Windows.Forms.Label();
            this.lblModalidade = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.modalidade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtAlunos);
            this.groupBox1.Controls.Add(this.lblQtde_alunos);
            this.groupBox1.Controls.Add(this.txtHoras);
            this.groupBox1.Controls.Add(this.btnCadastrar);
            this.groupBox1.Controls.Add(this.txtDiaSemana);
            this.groupBox1.Controls.Add(this.txtProfessor);
            this.groupBox1.Controls.Add(this.txtModalidade);
            this.groupBox1.Controls.Add(this.lblHora);
            this.groupBox1.Controls.Add(this.lblDiaSemana);
            this.groupBox1.Controls.Add(this.lblProfessor);
            this.groupBox1.Controls.Add(this.lblModalidade);
            this.groupBox1.Location = new System.Drawing.Point(46, 38);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(676, 288);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Turma";
            // 
            // txtAlunos
            // 
            this.txtAlunos.Location = new System.Drawing.Point(442, 182);
            this.txtAlunos.Name = "txtAlunos";
            this.txtAlunos.Size = new System.Drawing.Size(137, 22);
            this.txtAlunos.TabIndex = 11;
            // 
            // lblQtde_alunos
            // 
            this.lblQtde_alunos.AutoSize = true;
            this.lblQtde_alunos.Location = new System.Drawing.Point(317, 185);
            this.lblQtde_alunos.Name = "lblQtde_alunos";
            this.lblQtde_alunos.Size = new System.Drawing.Size(119, 16);
            this.lblQtde_alunos.TabIndex = 10;
            this.lblQtde_alunos.Text = "Máximo de alunos:";
            // 
            // txtHoras
            // 
            this.txtHoras.Location = new System.Drawing.Point(179, 182);
            this.txtHoras.Mask = "00:00";
            this.txtHoras.Name = "txtHoras";
            this.txtHoras.Size = new System.Drawing.Size(112, 22);
            this.txtHoras.TabIndex = 9;
            // 
            // btnCadastrar
            // 
            this.btnCadastrar.Location = new System.Drawing.Point(76, 238);
            this.btnCadastrar.Name = "btnCadastrar";
            this.btnCadastrar.Size = new System.Drawing.Size(503, 23);
            this.btnCadastrar.TabIndex = 8;
            this.btnCadastrar.Text = "Cadastrar";
            this.btnCadastrar.UseVisualStyleBackColor = true;
            this.btnCadastrar.Click += new System.EventHandler(this.btnCadastrar_Click);
            // 
            // txtDiaSemana
            // 
            this.txtDiaSemana.Location = new System.Drawing.Point(179, 136);
            this.txtDiaSemana.Name = "txtDiaSemana";
            this.txtDiaSemana.Size = new System.Drawing.Size(400, 22);
            this.txtDiaSemana.TabIndex = 6;
            // 
            // txtProfessor
            // 
            this.txtProfessor.Location = new System.Drawing.Point(179, 94);
            this.txtProfessor.Name = "txtProfessor";
            this.txtProfessor.Size = new System.Drawing.Size(400, 22);
            this.txtProfessor.TabIndex = 5;
            // 
            // txtModalidade
            // 
            this.txtModalidade.Location = new System.Drawing.Point(179, 52);
            this.txtModalidade.Name = "txtModalidade";
            this.txtModalidade.Size = new System.Drawing.Size(400, 22);
            this.txtModalidade.TabIndex = 4;
            // 
            // lblHora
            // 
            this.lblHora.AutoSize = true;
            this.lblHora.Location = new System.Drawing.Point(133, 182);
            this.lblHora.Name = "lblHora";
            this.lblHora.Size = new System.Drawing.Size(40, 16);
            this.lblHora.TabIndex = 3;
            this.lblHora.Text = "Hora:";
            // 
            // lblDiaSemana
            // 
            this.lblDiaSemana.AutoSize = true;
            this.lblDiaSemana.Location = new System.Drawing.Point(73, 139);
            this.lblDiaSemana.Name = "lblDiaSemana";
            this.lblDiaSemana.Size = new System.Drawing.Size(104, 16);
            this.lblDiaSemana.TabIndex = 2;
            this.lblDiaSemana.Text = "Dia da Semana:";
            // 
            // lblProfessor
            // 
            this.lblProfessor.AutoSize = true;
            this.lblProfessor.Location = new System.Drawing.Point(109, 100);
            this.lblProfessor.Name = "lblProfessor";
            this.lblProfessor.Size = new System.Drawing.Size(68, 16);
            this.lblProfessor.TabIndex = 1;
            this.lblProfessor.Text = "Professor:";
            // 
            // lblModalidade
            // 
            this.lblModalidade.AutoSize = true;
            this.lblModalidade.Location = new System.Drawing.Point(94, 55);
            this.lblModalidade.Name = "lblModalidade";
            this.lblModalidade.Size = new System.Drawing.Size(83, 16);
            this.lblModalidade.TabIndex = 0;
            this.lblModalidade.Text = "Modalidade:";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.modalidade});
            this.dataGridView1.Location = new System.Drawing.Point(46, 351);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(676, 171);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // modalidade
            // 
            this.modalidade.HeaderText = "Modalidade";
            this.modalidade.MinimumWidth = 6;
            this.modalidade.Name = "modalidade";
            this.modalidade.Width = 125;
            // 
            // Form9
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 570);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form9";
            this.Text = "Cadastro de Turma";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnCadastrar;
        private System.Windows.Forms.TextBox txtDiaSemana;
        private System.Windows.Forms.TextBox txtProfessor;
        private System.Windows.Forms.TextBox txtModalidade;
        private System.Windows.Forms.Label lblHora;
        private System.Windows.Forms.Label lblDiaSemana;
        private System.Windows.Forms.Label lblProfessor;
        private System.Windows.Forms.Label lblModalidade;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.MaskedTextBox txtHoras;
        private System.Windows.Forms.TextBox txtAlunos;
        private System.Windows.Forms.Label lblQtde_alunos;
        private System.Windows.Forms.DataGridViewTextBoxColumn modalidade;
    }
}