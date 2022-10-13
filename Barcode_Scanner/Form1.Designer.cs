
namespace Barcode_Scanner
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tb_datetime = new System.Windows.Forms.TextBox();
            this.tb_barcode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_exportall = new System.Windows.Forms.Button();
            this.btn_export = new System.Windows.Forms.Button();
            this.lb_count = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tb_datetime
            // 
            this.tb_datetime.Location = new System.Drawing.Point(88, 104);
            this.tb_datetime.Margin = new System.Windows.Forms.Padding(2);
            this.tb_datetime.Name = "tb_datetime";
            this.tb_datetime.ReadOnly = true;
            this.tb_datetime.Size = new System.Drawing.Size(193, 23);
            this.tb_datetime.TabIndex = 0;
            // 
            // tb_barcode
            // 
            this.tb_barcode.Location = new System.Drawing.Point(88, 68);
            this.tb_barcode.Margin = new System.Windows.Forms.Padding(2);
            this.tb_barcode.Name = "tb_barcode";
            this.tb_barcode.ReadOnly = true;
            this.tb_barcode.Size = new System.Drawing.Size(193, 23);
            this.tb_barcode.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Barcode";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 107);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Time";
            // 
            // btn_exportall
            // 
            this.btn_exportall.Location = new System.Drawing.Point(33, 181);
            this.btn_exportall.Name = "btn_exportall";
            this.btn_exportall.Size = new System.Drawing.Size(75, 23);
            this.btn_exportall.TabIndex = 2;
            this.btn_exportall.Text = "Export All";
            this.btn_exportall.UseVisualStyleBackColor = true;
            this.btn_exportall.Click += new System.EventHandler(this.btn_exportall_Click);
            // 
            // btn_export
            // 
            this.btn_export.Location = new System.Drawing.Point(33, 142);
            this.btn_export.Name = "btn_export";
            this.btn_export.Size = new System.Drawing.Size(75, 23);
            this.btn_export.TabIndex = 3;
            this.btn_export.Text = "Export";
            this.btn_export.UseVisualStyleBackColor = true;
            this.btn_export.Click += new System.EventHandler(this.btn_export_Click);
            // 
            // lb_count
            // 
            this.lb_count.AutoSize = true;
            this.lb_count.Location = new System.Drawing.Point(88, 42);
            this.lb_count.Name = "lb_count";
            this.lb_count.Size = new System.Drawing.Size(0, 15);
            this.lb_count.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(33, 42);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 15);
            this.label4.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(666, 403);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lb_count);
            this.Controls.Add(this.btn_export);
            this.Controls.Add(this.btn_exportall);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tb_barcode);
            this.Controls.Add(this.tb_datetime);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tb_datetime;
        private System.Windows.Forms.TextBox tb_barcode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_exportall;
        private System.Windows.Forms.Button btn_export;
        private System.Windows.Forms.Label lb_count;
        private System.Windows.Forms.Label label4;
    }
}

