namespace Yaxel.Tables.ComponentForms
{
    partial class UpdateComponent
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
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.selectComputersButton = new Yaxel.YaxelStyle.YaxelButton();
            this.deleteAttributeButton = new Yaxel.YaxelStyle.YaxelButton();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.attributeTypeComboBox = new System.Windows.Forms.ComboBox();
            this.attributeValueTextBox = new System.Windows.Forms.TextBox();
            this.addAttributeButton = new Yaxel.YaxelStyle.YaxelButton();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.applyButton = new Yaxel.YaxelStyle.YaxelButton();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // yaxelForm1
            // 
            this.yaxelForm1.ThisForm = this;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(322, 147);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(171, 26);
            this.label3.TabIndex = 50;
            this.label3.Text = "Производитель";
            this.label3.UseMnemonic = false;
            // 
            // comboBox1
            // 
            this.comboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(561, 147);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(203, 33);
            this.comboBox1.TabIndex = 49;
            // 
            // selectComputersButton
            // 
            this.selectComputersButton.DialogResult = System.Windows.Forms.DialogResult.None;
            this.selectComputersButton.Font = new System.Drawing.Font("Arial", 16F);
            this.selectComputersButton.ForeColor = System.Drawing.Color.White;
            this.selectComputersButton.Location = new System.Drawing.Point(420, 434);
            this.selectComputersButton.Name = "selectComputersButton";
            this.selectComputersButton.Size = new System.Drawing.Size(250, 50);
            this.selectComputersButton.TabIndex = 48;
            this.selectComputersButton.Text = "Выбрать компьютер";
            this.selectComputersButton.Click += new System.EventHandler(this.selectComputersButton_Click);
            // 
            // deleteAttributeButton
            // 
            this.deleteAttributeButton.DialogResult = System.Windows.Forms.DialogResult.None;
            this.deleteAttributeButton.Font = new System.Drawing.Font("Arial", 16F);
            this.deleteAttributeButton.ForeColor = System.Drawing.Color.White;
            this.deleteAttributeButton.Location = new System.Drawing.Point(780, 294);
            this.deleteAttributeButton.Name = "deleteAttributeButton";
            this.deleteAttributeButton.Size = new System.Drawing.Size(151, 33);
            this.deleteAttributeButton.TabIndex = 47;
            this.deleteAttributeButton.Text = "удалить";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridView1.Location = new System.Drawing.Point(327, 246);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(437, 182);
            this.dataGridView1.TabIndex = 46;
            // 
            // attributeTypeComboBox
            // 
            this.attributeTypeComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.attributeTypeComboBox.FormattingEnabled = true;
            this.attributeTypeComboBox.Location = new System.Drawing.Point(327, 200);
            this.attributeTypeComboBox.Name = "attributeTypeComboBox";
            this.attributeTypeComboBox.Size = new System.Drawing.Size(203, 33);
            this.attributeTypeComboBox.TabIndex = 45;
            // 
            // attributeValueTextBox
            // 
            this.attributeValueTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.attributeValueTextBox.Location = new System.Drawing.Point(561, 201);
            this.attributeValueTextBox.Name = "attributeValueTextBox";
            this.attributeValueTextBox.Size = new System.Drawing.Size(203, 32);
            this.attributeValueTextBox.TabIndex = 44;
            // 
            // addAttributeButton
            // 
            this.addAttributeButton.DialogResult = System.Windows.Forms.DialogResult.None;
            this.addAttributeButton.Font = new System.Drawing.Font("Arial", 16F);
            this.addAttributeButton.ForeColor = System.Drawing.Color.White;
            this.addAttributeButton.Location = new System.Drawing.Point(780, 246);
            this.addAttributeButton.Name = "addAttributeButton";
            this.addAttributeButton.Size = new System.Drawing.Size(151, 33);
            this.addAttributeButton.TabIndex = 43;
            this.addAttributeButton.Text = "новый";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(145, 207);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(176, 26);
            this.label4.TabIndex = 42;
            this.label4.Text = "Характеристики";
            this.label4.UseMnemonic = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(322, 108);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(175, 26);
            this.label2.TabIndex = 41;
            this.label2.Text = "Тип компонента";
            this.label2.UseMnemonic = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(322, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(219, 26);
            this.label1.TabIndex = 40;
            this.label1.Text = "Модель компонента";
            this.label1.UseMnemonic = false;
            // 
            // comboBox2
            // 
            this.comboBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(561, 108);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(203, 33);
            this.comboBox2.TabIndex = 39;
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox1.Location = new System.Drawing.Point(561, 70);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(203, 32);
            this.textBox1.TabIndex = 38;
            // 
            // applyButton
            // 
            this.applyButton.DialogResult = System.Windows.Forms.DialogResult.None;
            this.applyButton.Font = new System.Drawing.Font("Arial", 16F);
            this.applyButton.ForeColor = System.Drawing.Color.White;
            this.applyButton.Location = new System.Drawing.Point(420, 490);
            this.applyButton.Name = "applyButton";
            this.applyButton.Size = new System.Drawing.Size(250, 50);
            this.applyButton.TabIndex = 37;
            this.applyButton.Text = "Обновить";
            this.applyButton.Click += new System.EventHandler(this.applyButton_Click_1);
            // 
            // UpdateComponent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1080, 577);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.selectComputersButton);
            this.Controls.Add(this.deleteAttributeButton);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.attributeTypeComboBox);
            this.Controls.Add(this.attributeValueTextBox);
            this.Controls.Add(this.addAttributeButton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.applyButton);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "UpdateComponent";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Обновить компонент";
            this.Load += new System.EventHandler(this.UpdateComponent_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private YaxelStyle.YaxelForm yaxelForm1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox1;
        private YaxelStyle.YaxelButton selectComputersButton;
        private YaxelStyle.YaxelButton deleteAttributeButton;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox attributeTypeComboBox;
        private System.Windows.Forms.TextBox attributeValueTextBox;
        private YaxelStyle.YaxelButton addAttributeButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.TextBox textBox1;
        private YaxelStyle.YaxelButton applyButton;
    }
}