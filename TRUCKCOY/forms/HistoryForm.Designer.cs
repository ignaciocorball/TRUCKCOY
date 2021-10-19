
namespace TRUCKCOY.forms
{
    partial class HistoryForm
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pTittleHF = new System.Windows.Forms.Panel();
            this.lblTittleDesc = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.add = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.showForm = new System.Windows.Forms.Timer(this.components);
            this.dgvHistory = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.income_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.driver = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.patente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.address_source = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.address_out = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.delete = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.details0 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.select = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pTittleHF.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.add)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistory)).BeginInit();
            this.SuspendLayout();
            // 
            // pTittleHF
            // 
            this.pTittleHF.BackColor = System.Drawing.Color.White;
            this.pTittleHF.Controls.Add(this.lblTittleDesc);
            this.pTittleHF.Controls.Add(this.label1);
            this.pTittleHF.Controls.Add(this.tableLayoutPanel2);
            this.pTittleHF.Dock = System.Windows.Forms.DockStyle.Top;
            this.pTittleHF.Location = new System.Drawing.Point(0, 0);
            this.pTittleHF.Name = "pTittleHF";
            this.pTittleHF.Size = new System.Drawing.Size(819, 60);
            this.pTittleHF.TabIndex = 24;
            // 
            // lblTittleDesc
            // 
            this.lblTittleDesc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTittleDesc.Font = new System.Drawing.Font("Bahnschrift", 10F);
            this.lblTittleDesc.ForeColor = System.Drawing.Color.DimGray;
            this.lblTittleDesc.Location = new System.Drawing.Point(17, 36);
            this.lblTittleDesc.MaximumSize = new System.Drawing.Size(300, 24);
            this.lblTittleDesc.Name = "lblTittleDesc";
            this.lblTittleDesc.Size = new System.Drawing.Size(300, 20);
            this.lblTittleDesc.TabIndex = 16;
            this.lblTittleDesc.Text = "Últimos 10 registros";
            this.lblTittleDesc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Bahnschrift", 11F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(38)))), ((int)(((byte)(55)))));
            this.label1.Location = new System.Drawing.Point(17, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(157, 18);
            this.label1.TabIndex = 15;
            this.label1.Text = "HISTORIAL DE VIAJES";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.ColumnCount = 5;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 4.678362F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 95.32164F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 78F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 52F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 46F));
            this.tableLayoutPanel2.Controls.Add(this.add, 1, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(543, 35);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(276, 25);
            this.tableLayoutPanel2.TabIndex = 14;
            // 
            // add
            // 
            this.add.Cursor = System.Windows.Forms.Cursors.Hand;
            this.add.Dock = System.Windows.Forms.DockStyle.Fill;
            this.add.Image = global::TRUCKCOY.Properties.Resources.terr_off;
            this.add.Location = new System.Drawing.Point(7, 3);
            this.add.Name = "add";
            this.add.Size = new System.Drawing.Size(89, 19);
            this.add.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.add.TabIndex = 15;
            this.add.TabStop = false;
            this.add.Click += new System.EventHandler(this.add_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 613);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(819, 40);
            this.panel1.TabIndex = 59;
            // 
            // showForm
            // 
            this.showForm.Interval = 2500;
            // 
            // dgvHistory
            // 
            this.dgvHistory.AllowUserToAddRows = false;
            this.dgvHistory.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Bahnschrift", 10F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvHistory.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvHistory.BackgroundColor = System.Drawing.Color.White;
            this.dgvHistory.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvHistory.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Bahnschrift", 10F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvHistory.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHistory.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.income_date,
            this.driver,
            this.patente,
            this.address_source,
            this.address_out,
            this.status,
            this.delete,
            this.details0,
            this.select});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Bahnschrift", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvHistory.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvHistory.GridColor = System.Drawing.Color.LightSlateGray;
            this.dgvHistory.Location = new System.Drawing.Point(0, 60);
            this.dgvHistory.Name = "dgvHistory";
            this.dgvHistory.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Bahnschrift", 10F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvHistory.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvHistory.RowHeadersVisible = false;
            this.dgvHistory.RowHeadersWidth = 20;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Bahnschrift", 10F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle5.NullValue = "Indefinido";
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvHistory.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvHistory.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.dgvHistory.RowTemplate.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvHistory.RowTemplate.Height = 25;
            this.dgvHistory.RowTemplate.ReadOnly = true;
            this.dgvHistory.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvHistory.Size = new System.Drawing.Size(819, 553);
            this.dgvHistory.TabIndex = 60;
            // 
            // id
            // 
            this.id.HeaderText = "ID";
            this.id.MinimumWidth = 30;
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Width = 30;
            // 
            // income_date
            // 
            this.income_date.HeaderText = "Ingreso de orden";
            this.income_date.MinimumWidth = 130;
            this.income_date.Name = "income_date";
            this.income_date.ReadOnly = true;
            this.income_date.Width = 130;
            // 
            // driver
            // 
            this.driver.HeaderText = "Conductor";
            this.driver.MinimumWidth = 105;
            this.driver.Name = "driver";
            this.driver.ReadOnly = true;
            this.driver.Width = 105;
            // 
            // patente
            // 
            this.patente.HeaderText = "Patente";
            this.patente.MinimumWidth = 88;
            this.patente.Name = "patente";
            this.patente.ReadOnly = true;
            this.patente.Width = 88;
            // 
            // address_source
            // 
            this.address_source.HeaderText = "Dirección de Origen";
            this.address_source.MinimumWidth = 150;
            this.address_source.Name = "address_source";
            this.address_source.ReadOnly = true;
            this.address_source.Width = 150;
            // 
            // address_out
            // 
            this.address_out.HeaderText = "Dirección de Destino";
            this.address_out.MinimumWidth = 150;
            this.address_out.Name = "address_out";
            this.address_out.ReadOnly = true;
            this.address_out.Width = 150;
            // 
            // status
            // 
            this.status.HeaderText = "Estado";
            this.status.MinimumWidth = 90;
            this.status.Name = "status";
            this.status.ReadOnly = true;
            this.status.Width = 90;
            // 
            // delete
            // 
            this.delete.HeaderText = "x";
            this.delete.MinimumWidth = 25;
            this.delete.Name = "delete";
            this.delete.ReadOnly = true;
            this.delete.Width = 25;
            // 
            // details0
            // 
            this.details0.HeaderText = "o";
            this.details0.MinimumWidth = 25;
            this.details0.Name = "details0";
            this.details0.ReadOnly = true;
            this.details0.Width = 25;
            // 
            // select
            // 
            this.select.HeaderText = "s";
            this.select.MinimumWidth = 25;
            this.select.Name = "select";
            this.select.ReadOnly = true;
            this.select.Width = 25;
            // 
            // HistoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(819, 653);
            this.Controls.Add(this.dgvHistory);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pTittleHF);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "HistoryForm";
            this.Opacity = 0D;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "HistoryForm";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.HistoryForm_Load);
            this.pTittleHF.ResumeLayout(false);
            this.pTittleHF.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.add)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistory)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pTittleHF;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.PictureBox add;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Timer showForm;
        private System.Windows.Forms.Label lblTittleDesc;
        private System.Windows.Forms.DataGridView dgvHistory;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn income_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn driver;
        private System.Windows.Forms.DataGridViewTextBoxColumn patente;
        private System.Windows.Forms.DataGridViewTextBoxColumn address_source;
        private System.Windows.Forms.DataGridViewTextBoxColumn address_out;
        private System.Windows.Forms.DataGridViewTextBoxColumn status;
        private System.Windows.Forms.DataGridViewTextBoxColumn delete;
        private System.Windows.Forms.DataGridViewTextBoxColumn details0;
        private System.Windows.Forms.DataGridViewTextBoxColumn select;
    }
}