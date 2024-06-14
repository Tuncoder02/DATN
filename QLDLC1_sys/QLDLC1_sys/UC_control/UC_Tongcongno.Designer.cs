namespace QLDLC1_sys.UC_control
{
    partial class UC_Tongcongno
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnTraCuu = new System.Windows.Forms.Button();
            this.dateDenNgay = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.dateTuNgay = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.lblTieude = new System.Windows.Forms.Label();
            this.dtgvTongcongno = new System.Windows.Forms.DataGridView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtTongno = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnSwitch = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvTongcongno)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1496, 57);
            this.panel1.TabIndex = 10;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(253, 41);
            this.label1.TabIndex = 0;
            this.label1.Text = "     Tổng công nợ";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnSwitch);
            this.panel2.Controls.Add(this.btnTraCuu);
            this.panel2.Controls.Add(this.dateDenNgay);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.dateTuNgay);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.lblTieude);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 57);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1496, 164);
            this.panel2.TabIndex = 11;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // btnTraCuu
            // 
            this.btnTraCuu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnTraCuu.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTraCuu.Location = new System.Drawing.Point(1079, 96);
            this.btnTraCuu.Name = "btnTraCuu";
            this.btnTraCuu.Size = new System.Drawing.Size(146, 34);
            this.btnTraCuu.TabIndex = 6;
            this.btnTraCuu.Text = "Tra Cứu";
            this.btnTraCuu.UseVisualStyleBackColor = false;
            this.btnTraCuu.Click += new System.EventHandler(this.btnTraCuu_Click);
            // 
            // dateDenNgay
            // 
            this.dateDenNgay.CustomFormat = "dd/MM/yyyy";
            this.dateDenNgay.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateDenNgay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateDenNgay.Location = new System.Drawing.Point(831, 96);
            this.dateDenNgay.Name = "dateDenNgay";
            this.dateDenNgay.Size = new System.Drawing.Size(209, 34);
            this.dateDenNgay.TabIndex = 5;
            this.dateDenNgay.ValueChanged += new System.EventHandler(this.dateDenNgay_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(703, 96);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(129, 29);
            this.label4.TabIndex = 4;
            this.label4.Text = "Đến ngày:";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // dateTuNgay
            // 
            this.dateTuNgay.CustomFormat = "dd/MM/yyyy";
            this.dateTuNgay.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTuNgay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTuNgay.Location = new System.Drawing.Point(420, 96);
            this.dateTuNgay.Name = "dateTuNgay";
            this.dateTuNgay.Size = new System.Drawing.Size(209, 34);
            this.dateTuNgay.TabIndex = 3;
            this.dateTuNgay.ValueChanged += new System.EventHandler(this.dateTuNgay_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(308, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 29);
            this.label3.TabIndex = 1;
            this.label3.Text = "Từ ngày:";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // lblTieude
            // 
            this.lblTieude.AutoSize = true;
            this.lblTieude.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTieude.Location = new System.Drawing.Point(485, 35);
            this.lblTieude.Name = "lblTieude";
            this.lblTieude.Size = new System.Drawing.Size(424, 38);
            this.lblTieude.TabIndex = 0;
            this.lblTieude.Text = "CÔNG NỢ KHÁCH HÀNG";
            this.lblTieude.Click += new System.EventHandler(this.label2_Click);
            // 
            // dtgvTongcongno
            // 
            this.dtgvTongcongno.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dtgvTongcongno.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgvTongcongno.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgvTongcongno.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgvTongcongno.DefaultCellStyle = dataGridViewCellStyle2;
            this.dtgvTongcongno.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgvTongcongno.Location = new System.Drawing.Point(0, 221);
            this.dtgvTongcongno.Name = "dtgvTongcongno";
            this.dtgvTongcongno.RowHeadersWidth = 51;
            this.dtgvTongcongno.RowTemplate.Height = 24;
            this.dtgvTongcongno.Size = new System.Drawing.Size(1496, 640);
            this.dtgvTongcongno.TabIndex = 12;
            this.dtgvTongcongno.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgvTongcongno_CellContentClick);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.txtTongno);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 774);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1496, 87);
            this.panel3.TabIndex = 13;
            this.panel3.Paint += new System.Windows.Forms.PaintEventHandler(this.panel3_Paint);
            // 
            // txtTongno
            // 
            this.txtTongno.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTongno.Location = new System.Drawing.Point(1095, 19);
            this.txtTongno.Name = "txtTongno";
            this.txtTongno.ReadOnly = true;
            this.txtTongno.Size = new System.Drawing.Size(324, 34);
            this.txtTongno.TabIndex = 8;
            this.txtTongno.TextChanged += new System.EventHandler(this.txtTongno_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(937, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(152, 29);
            this.label5.TabIndex = 7;
            this.label5.Text = "Tổng số dư:";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // btnSwitch
            // 
            this.btnSwitch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnSwitch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSwitch.Location = new System.Drawing.Point(29, 27);
            this.btnSwitch.Name = "btnSwitch";
            this.btnSwitch.Size = new System.Drawing.Size(117, 46);
            this.btnSwitch.TabIndex = 7;
            this.btnSwitch.Text = "Đổi";
            this.btnSwitch.UseVisualStyleBackColor = false;
            this.btnSwitch.Click += new System.EventHandler(this.btnSwitch_Click);
            // 
            // UC_Tongcongno
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.dtgvTongcongno);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "UC_Tongcongno";
            this.Size = new System.Drawing.Size(1496, 861);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvTongcongno)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dtgvTongcongno;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnTraCuu;
        private System.Windows.Forms.DateTimePicker dateDenNgay;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dateTuNgay;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTongno;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnSwitch;
        private System.Windows.Forms.Label lblTieude;
    }
}
