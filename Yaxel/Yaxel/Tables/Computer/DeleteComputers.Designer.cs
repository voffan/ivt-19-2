namespace Yaxel.Tables.Computer
{
    partial class DeleteComputers
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
            this.noButton = new Yaxel.YaxelStyle.YaxelButton();
            this.yesButton = new Yaxel.YaxelStyle.YaxelButton();
            this.SuspendLayout();
            // 
            // yaxelForm1
            // 
            this.yaxelForm1.ThisForm = this;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(31, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(638, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "Вы действительно хотите безвозвратно удалить эти записи?";
            // 
            // noButton
            // 
            this.noButton.DialogResult = System.Windows.Forms.DialogResult.None;
            this.noButton.Font = new System.Drawing.Font("Arial", 16F);
            this.noButton.ForeColor = System.Drawing.Color.White;
            this.noButton.Location = new System.Drawing.Point(66, 120);
            this.noButton.Name = "noButton";
            this.noButton.Size = new System.Drawing.Size(250, 50);
            this.noButton.TabIndex = 1;
            this.noButton.Text = "Нет";
            this.noButton.Click += new System.EventHandler(this.noButton_Click);
            // 
            // yesButton
            // 
            this.yesButton.DialogResult = System.Windows.Forms.DialogResult.None;
            this.yesButton.Font = new System.Drawing.Font("Arial", 16F);
            this.yesButton.ForeColor = System.Drawing.Color.White;
            this.yesButton.Location = new System.Drawing.Point(384, 120);
            this.yesButton.Name = "yesButton";
            this.yesButton.Size = new System.Drawing.Size(250, 50);
            this.yesButton.TabIndex = 2;
            this.yesButton.Text = "Да";
            this.yesButton.Click += new System.EventHandler(this.yesButton_Click);
            // 
            // DeleteComputers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 200);
            this.Controls.Add(this.yesButton);
            this.Controls.Add(this.noButton);
            this.Controls.Add(this.label1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "DeleteComputers";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DeleteComputers";
            this.Load += new System.EventHandler(this.DeleteComputers_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private YaxelStyle.YaxelForm yaxelForm1;
        private YaxelStyle.YaxelButton yesButton;
        private YaxelStyle.YaxelButton noButton;
        private System.Windows.Forms.Label label1;
    }
}