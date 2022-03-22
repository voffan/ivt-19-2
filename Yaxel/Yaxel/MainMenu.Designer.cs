namespace Yaxel
{
    partial class MainMenu
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
            this.listEmployeesButton = new System.Windows.Forms.Button();
            this.listСomputersButton = new System.Windows.Forms.Button();
            this.listPeripheralsButton = new System.Windows.Forms.Button();
            this.listComponentsButton = new System.Windows.Forms.Button();
            this.backButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listEmployeesButton
            // 
            this.listEmployeesButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.listEmployeesButton.Location = new System.Drawing.Point(365, 170);
            this.listEmployeesButton.Margin = new System.Windows.Forms.Padding(0);
            this.listEmployeesButton.Name = "listEmployeesButton";
            this.listEmployeesButton.Size = new System.Drawing.Size(550, 50);
            this.listEmployeesButton.TabIndex = 0;
            this.listEmployeesButton.Text = "Посмотреть список сотрудников";
            this.listEmployeesButton.UseVisualStyleBackColor = true;
            this.listEmployeesButton.Click += new System.EventHandler(this.listEmployeesButton_Click);
            // 
            // listСomputersButton
            // 
            this.listСomputersButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.listСomputersButton.Location = new System.Drawing.Point(365, 280);
            this.listСomputersButton.Margin = new System.Windows.Forms.Padding(0);
            this.listСomputersButton.Name = "listСomputersButton";
            this.listСomputersButton.Size = new System.Drawing.Size(550, 50);
            this.listСomputersButton.TabIndex = 1;
            this.listСomputersButton.Text = "Посмотреть список компьютеров";
            this.listСomputersButton.UseVisualStyleBackColor = true;
            this.listСomputersButton.Click += new System.EventHandler(this.listСomputersButton_Click);
            // 
            // listPeripheralsButton
            // 
            this.listPeripheralsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.listPeripheralsButton.Location = new System.Drawing.Point(365, 390);
            this.listPeripheralsButton.Margin = new System.Windows.Forms.Padding(0);
            this.listPeripheralsButton.Name = "listPeripheralsButton";
            this.listPeripheralsButton.Size = new System.Drawing.Size(550, 50);
            this.listPeripheralsButton.TabIndex = 2;
            this.listPeripheralsButton.Text = "Посмотреть список периферии";
            this.listPeripheralsButton.UseVisualStyleBackColor = true;
            this.listPeripheralsButton.Click += new System.EventHandler(this.listPeripheralsButton_Click);
            // 
            // listComponentsButton
            // 
            this.listComponentsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.listComponentsButton.Location = new System.Drawing.Point(365, 500);
            this.listComponentsButton.Margin = new System.Windows.Forms.Padding(0);
            this.listComponentsButton.Name = "listComponentsButton";
            this.listComponentsButton.Size = new System.Drawing.Size(550, 50);
            this.listComponentsButton.TabIndex = 3;
            this.listComponentsButton.Text = "Посмотреть список комплектующих";
            this.listComponentsButton.UseVisualStyleBackColor = true;
            this.listComponentsButton.Click += new System.EventHandler(this.listComponentsButton_Click);
            // 
            // backButton
            // 
            this.backButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.backButton.Location = new System.Drawing.Point(30, 30);
            this.backButton.Margin = new System.Windows.Forms.Padding(0);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(100, 50);
            this.backButton.TabIndex = 4;
            this.backButton.Text = "<<";
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.listComponentsButton);
            this.Controls.Add(this.listPeripheralsButton);
            this.Controls.Add(this.listСomputersButton);
            this.Controls.Add(this.listEmployeesButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximumSize = new System.Drawing.Size(1280, 720);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(960, 540);
            this.Name = "MainMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainMenu";
            this.Load += new System.EventHandler(this.MainMenu_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button listEmployeesButton;
        private System.Windows.Forms.Button listСomputersButton;
        private System.Windows.Forms.Button listPeripheralsButton;
        private System.Windows.Forms.Button listComponentsButton;
        private System.Windows.Forms.Button backButton;
    }
}