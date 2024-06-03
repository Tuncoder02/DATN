namespace QLDLC1_sys
{
    partial class Kiemtradaily
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea7 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend7 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series7 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea8 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend8 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series8 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cboTinh = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.chartXa = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.dtgvXa = new System.Windows.Forms.DataGridView();
            this.chartHuyen = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.a = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.txtMatDo = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDientich = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDanso = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dtgvHuyen = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cboHuyen = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartXa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvXa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartHuyen)).BeginInit();
            this.a.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvHuyen)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel1.Controls.Add(this.cboTinh);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1080, 59);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // cboTinh
            // 
            this.cboTinh.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboTinh.FormattingEnabled = true;
            this.cboTinh.Location = new System.Drawing.Point(138, 17);
            this.cboTinh.Name = "cboTinh";
            this.cboTinh.Size = new System.Drawing.Size(282, 30);
            this.cboTinh.TabIndex = 1;
            this.cboTinh.SelectedIndexChanged += new System.EventHandler(this.cboTinh_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(30, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "Chọn tỉnh:";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label10);
            this.panel3.Controls.Add(this.cboHuyen);
            this.panel3.Controls.Add(this.label9);
            this.panel3.Controls.Add(this.chartXa);
            this.panel3.Controls.Add(this.dtgvXa);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 475);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1080, 458);
            this.panel3.TabIndex = 2;
            this.panel3.Paint += new System.Windows.Forms.PaintEventHandler(this.panel3_Paint);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(460, 49);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(257, 29);
            this.label9.TabIndex = 13;
            this.label9.Text = "Thống kê theo huyện";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // chartXa
            // 
            chartArea7.Name = "ChartArea1";
            this.chartXa.ChartAreas.Add(chartArea7);
            legend7.Name = "Legend1";
            this.chartXa.Legends.Add(legend7);
            this.chartXa.Location = new System.Drawing.Point(586, 81);
            this.chartXa.Name = "chartXa";
            series7.ChartArea = "ChartArea1";
            series7.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series7.Legend = "Legend1";
            series7.Name = "Series1";
            this.chartXa.Series.Add(series7);
            this.chartXa.Size = new System.Drawing.Size(511, 374);
            this.chartXa.TabIndex = 12;
            this.chartXa.Text = "chartXa";
            this.chartXa.Click += new System.EventHandler(this.chart1_Click);
            // 
            // dtgvXa
            // 
            this.dtgvXa.BackgroundColor = System.Drawing.Color.White;
            this.dtgvXa.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvXa.Location = new System.Drawing.Point(0, 81);
            this.dtgvXa.Name = "dtgvXa";
            this.dtgvXa.RowHeadersWidth = 51;
            this.dtgvXa.RowTemplate.Height = 24;
            this.dtgvXa.Size = new System.Drawing.Size(583, 377);
            this.dtgvXa.TabIndex = 2;
            // 
            // chartHuyen
            // 
            chartArea8.Name = "ChartArea1";
            this.chartHuyen.ChartAreas.Add(chartArea8);
            legend8.Name = "Legend1";
            this.chartHuyen.Legends.Add(legend8);
            this.chartHuyen.Location = new System.Drawing.Point(586, 141);
            this.chartHuyen.Name = "chartHuyen";
            series8.ChartArea = "ChartArea1";
            series8.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series8.Legend = "Legend1";
            series8.Name = "Series1";
            this.chartHuyen.Series.Add(series8);
            this.chartHuyen.Size = new System.Drawing.Size(482, 275);
            this.chartHuyen.TabIndex = 2;
            this.chartHuyen.Text = "chartHuyen";
            // 
            // a
            // 
            this.a.Controls.Add(this.chartHuyen);
            this.a.Controls.Add(this.label7);
            this.a.Controls.Add(this.txtMatDo);
            this.a.Controls.Add(this.label8);
            this.a.Controls.Add(this.label5);
            this.a.Controls.Add(this.txtDientich);
            this.a.Controls.Add(this.label6);
            this.a.Controls.Add(this.label4);
            this.a.Controls.Add(this.txtDanso);
            this.a.Controls.Add(this.label3);
            this.a.Controls.Add(this.label2);
            this.a.Controls.Add(this.dtgvHuyen);
            this.a.Dock = System.Windows.Forms.DockStyle.Fill;
            this.a.Location = new System.Drawing.Point(0, 0);
            this.a.Name = "a";
            this.a.Size = new System.Drawing.Size(1080, 416);
            this.a.TabIndex = 0;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(876, 79);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(94, 20);
            this.label7.TabIndex = 11;
            this.label7.Text = "người/km2";
            // 
            // txtMatDo
            // 
            this.txtMatDo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMatDo.Location = new System.Drawing.Point(755, 76);
            this.txtMatDo.Name = "txtMatDo";
            this.txtMatDo.ReadOnly = true;
            this.txtMatDo.Size = new System.Drawing.Size(115, 27);
            this.txtMatDo.TabIndex = 10;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(680, 79);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(66, 20);
            this.label8.TabIndex = 9;
            this.label8.Text = "Mật độ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(603, 76);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 20);
            this.label5.TabIndex = 8;
            this.label5.Text = "km2";
            // 
            // txtDientich
            // 
            this.txtDientich.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDientich.Location = new System.Drawing.Point(482, 73);
            this.txtDientich.Name = "txtDientich";
            this.txtDientich.ReadOnly = true;
            this.txtDientich.Size = new System.Drawing.Size(115, 27);
            this.txtDientich.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(388, 76);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(85, 20);
            this.label6.TabIndex = 6;
            this.label6.Text = "Diện tích";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(250, 76);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(105, 20);
            this.label4.TabIndex = 5;
            this.label4.Text = "nghìn người";
            // 
            // txtDanso
            // 
            this.txtDanso.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDanso.Location = new System.Drawing.Point(129, 73);
            this.txtDanso.Name = "txtDanso";
            this.txtDanso.ReadOnly = true;
            this.txtDanso.Size = new System.Drawing.Size(115, 27);
            this.txtDanso.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(54, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "Dân số";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(262, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(637, 58);
            this.label2.TabIndex = 2;
            this.label2.Text = "Tình trạng diện tích, dân số  và mật độ dân số của tỉnh\r\n Năm 2022";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // dtgvHuyen
            // 
            this.dtgvHuyen.BackgroundColor = System.Drawing.Color.White;
            this.dtgvHuyen.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvHuyen.Location = new System.Drawing.Point(0, 141);
            this.dtgvHuyen.Name = "dtgvHuyen";
            this.dtgvHuyen.RowHeadersWidth = 51;
            this.dtgvHuyen.RowTemplate.Height = 24;
            this.dtgvHuyen.Size = new System.Drawing.Size(583, 275);
            this.dtgvHuyen.TabIndex = 1;
            this.dtgvHuyen.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgvHuyen_CellClick);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.a);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 59);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1080, 416);
            this.panel2.TabIndex = 1;
            // 
            // cboHuyen
            // 
            this.cboHuyen.DropDownHeight = 90;
            this.cboHuyen.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboHuyen.FormattingEnabled = true;
            this.cboHuyen.IntegralHeight = false;
            this.cboHuyen.Location = new System.Drawing.Point(156, 6);
            this.cboHuyen.Name = "cboHuyen";
            this.cboHuyen.Size = new System.Drawing.Size(282, 30);
            this.cboHuyen.TabIndex = 24;
            this.cboHuyen.SelectedIndexChanged += new System.EventHandler(this.cboHuyen_SelectedIndexChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(12, 9);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(123, 22);
            this.label10.TabIndex = 2;
            this.label10.Text = "Chọn huyện:";
            // 
            // Kiemtradaily
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1080, 933);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.Name = "Kiemtradaily";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kiemtradaily";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartXa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvXa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartHuyen)).EndInit();
            this.a.ResumeLayout(false);
            this.a.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvHuyen)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cboTinh;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView dtgvXa;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartHuyen;
        private System.Windows.Forms.Panel a;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtMatDo;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtDientich;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDanso;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dtgvHuyen;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartXa;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cboHuyen;
    }
}