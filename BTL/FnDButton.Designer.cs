namespace Test_1
{
    partial class FnDButton
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.ThucDon = new CustomButton.VBButton();
            this.nhatKy = new CustomButton.VBButton();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.nhatKy, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.ThucDon, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(301, 222);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(625, 180);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // ThucDon
            // 
            this.ThucDon.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ThucDon.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.ThucDon.BackgroundColor = System.Drawing.Color.MediumSlateBlue;
            this.ThucDon.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.ThucDon.BorderRadius = 20;
            this.ThucDon.BorderSize = 0;
            this.ThucDon.FlatAppearance.BorderSize = 0;
            this.ThucDon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ThucDon.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ThucDon.ForeColor = System.Drawing.Color.White;
            this.ThucDon.Location = new System.Drawing.Point(315, 3);
            this.ThucDon.Name = "ThucDon";
            this.ThucDon.Size = new System.Drawing.Size(307, 174);
            this.ThucDon.TabIndex = 1;
            this.ThucDon.Text = "Thực đơn";
            this.ThucDon.TextColor = System.Drawing.Color.White;
            this.ThucDon.UseVisualStyleBackColor = false;
            this.ThucDon.Click += new System.EventHandler(this.ThucDon_Click);
            // 
            // nhatKy
            // 
            this.nhatKy.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nhatKy.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.nhatKy.BackgroundColor = System.Drawing.Color.MediumSlateBlue;
            this.nhatKy.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.nhatKy.BorderRadius = 20;
            this.nhatKy.BorderSize = 0;
            this.nhatKy.FlatAppearance.BorderSize = 0;
            this.nhatKy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.nhatKy.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nhatKy.ForeColor = System.Drawing.Color.White;
            this.nhatKy.Location = new System.Drawing.Point(3, 3);
            this.nhatKy.Name = "nhatKy";
            this.nhatKy.Size = new System.Drawing.Size(306, 174);
            this.nhatKy.TabIndex = 0;
            this.nhatKy.Text = "Nhật ký ăn uống";
            this.nhatKy.TextColor = System.Drawing.Color.White;
            this.nhatKy.UseVisualStyleBackColor = false;
            this.nhatKy.Click += new System.EventHandler(this.nhatKy_Click);
            // 
            // FnDButton
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1182, 653);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FnDButton";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.FnDButton_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private CustomButton.VBButton ThucDon;
        private CustomButton.VBButton nhatKy;
    }
}