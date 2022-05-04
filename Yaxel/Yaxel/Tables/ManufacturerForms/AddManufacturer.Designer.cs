namespace Yaxel.Tables.ManufacturerForms
{
    partial class AddManufacturer
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
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.ApplyButton = new Yaxel.YaxelStyle.YaxelButton();
            this.SuspendLayout();
            // 
            // yaxelForm1
            // 
            this.yaxelForm1.ThisForm = this;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(293, 157);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(190, 32);
            this.label1.TabIndex = 18;
            this.label1.Text = "Название";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBoxName
            // 
            this.textBoxName.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxName.Location = new System.Drawing.Point(483, 158);
            this.textBoxName.Margin = new System.Windows.Forms.Padding(0);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(210, 32);
            this.textBoxName.TabIndex = 17;
            // 
            // ApplyButton
            // 
            this.ApplyButton.DialogResult = System.Windows.Forms.DialogResult.None;
            this.ApplyButton.Font = new System.Drawing.Font("Arial", 16F);
            this.ApplyButton.ForeColor = System.Drawing.Color.White;
            this.ApplyButton.Location = new System.Drawing.Point(417, 300);
            this.ApplyButton.Name = "ApplyButton";
            this.ApplyButton.Size = new System.Drawing.Size(250, 50);
            this.ApplyButton.TabIndex = 24;
            this.ApplyButton.Text = "Добавить";
            this.ApplyButton.Click += new System.EventHandler(this.ApplyButton_Click);
            // 
            // AddManufacturer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1080, 577);
            this.Controls.Add(this.ApplyButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxName);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AddManufacturer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Добавить производителя";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private YaxelStyle.YaxelForm yaxelForm1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxName;
        private YaxelStyle.YaxelButton ApplyButton;
    }
}