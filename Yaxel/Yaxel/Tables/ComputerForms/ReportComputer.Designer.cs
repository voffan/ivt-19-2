namespace Yaxel.Tables.ComputerForms
{
    partial class ReportComputer
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
            this.yaxelForm1 = new Yaxel.YaxelStyle.YaxelForm(this.components);
            this.yaxelButton1 = new Yaxel.YaxelStyle.YaxelButton();
            this.yaxelButton2 = new Yaxel.YaxelStyle.YaxelButton();
            this.yaxelButton3 = new Yaxel.YaxelStyle.YaxelButton();
            this.SuspendLayout();
            // 
            // yaxelForm1
            // 
            this.yaxelForm1.ThisForm = this;
            // 
            // yaxelButton1
            // 
            this.yaxelButton1.DialogResult = System.Windows.Forms.DialogResult.None;
            this.yaxelButton1.Font = new System.Drawing.Font("Arial", 16F);
            this.yaxelButton1.ForeColor = System.Drawing.Color.White;
            this.yaxelButton1.Location = new System.Drawing.Point(200, 133);
            this.yaxelButton1.Name = "yaxelButton1";
            this.yaxelButton1.Size = new System.Drawing.Size(400, 50);
            this.yaxelButton1.TabIndex = 0;
            this.yaxelButton1.Text = "О работающих компьютерах";
            this.yaxelButton1.Click += new System.EventHandler(this.yaxelButton1_Click);
            // 
            // yaxelButton2
            // 
            this.yaxelButton2.DialogResult = System.Windows.Forms.DialogResult.None;
            this.yaxelButton2.Font = new System.Drawing.Font("Arial", 16F);
            this.yaxelButton2.ForeColor = System.Drawing.Color.White;
            this.yaxelButton2.Location = new System.Drawing.Point(200, 209);
            this.yaxelButton2.Name = "yaxelButton2";
            this.yaxelButton2.Size = new System.Drawing.Size(400, 50);
            this.yaxelButton2.TabIndex = 1;
            this.yaxelButton2.Text = "О компьютерах, которые должны быть списаны, и по какой причине";
            // 
            // yaxelButton3
            // 
            this.yaxelButton3.DialogResult = System.Windows.Forms.DialogResult.None;
            this.yaxelButton3.Font = new System.Drawing.Font("Arial", 16F);
            this.yaxelButton3.ForeColor = System.Drawing.Color.White;
            this.yaxelButton3.Location = new System.Drawing.Point(200, 286);
            this.yaxelButton3.Name = "yaxelButton3";
            this.yaxelButton3.Size = new System.Drawing.Size(400, 50);
            this.yaxelButton3.TabIndex = 2;
            this.yaxelButton3.Text = "О компьютерах, которые были в ремонте в этом месяце";
            // 
            // ReportComputer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.yaxelButton3);
            this.Controls.Add(this.yaxelButton2);
            this.Controls.Add(this.yaxelButton1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ReportComputer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Получить отчёт";
            this.ResumeLayout(false);

        }

        #endregion

        private YaxelStyle.YaxelForm yaxelForm1;
        private YaxelStyle.YaxelButton yaxelButton3;
        private YaxelStyle.YaxelButton yaxelButton2;
        private YaxelStyle.YaxelButton yaxelButton1;
    }
}