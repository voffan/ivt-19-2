namespace Yaxel
{
    partial class MultiList
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
            this.btnEmployees = new System.Windows.Forms.Button();
            this.btnComputers = new System.Windows.Forms.Button();
            this.btnPeripherals = new System.Windows.Forms.Button();
            this.btnComponents = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnDeleteEntry = new System.Windows.Forms.Button();
            this.btnAddEntry = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.yaxelForm1 = new Yaxel.YaxelStyle.YaxelForm(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnEmployees
            // 
            this.btnEmployees.Location = new System.Drawing.Point(10, 66);
            this.btnEmployees.Margin = new System.Windows.Forms.Padding(0);
            this.btnEmployees.Name = "btnEmployees";
            this.btnEmployees.Size = new System.Drawing.Size(250, 50);
            this.btnEmployees.TabIndex = 1;
            this.btnEmployees.Text = "Список сотрудников";
            this.btnEmployees.UseVisualStyleBackColor = true;
            this.btnEmployees.Click += new System.EventHandler(this.btnEmployees_Click);
            // 
            // btnComputers
            // 
            this.btnComputers.Location = new System.Drawing.Point(10, 140);
            this.btnComputers.Margin = new System.Windows.Forms.Padding(0);
            this.btnComputers.Name = "btnComputers";
            this.btnComputers.Size = new System.Drawing.Size(250, 50);
            this.btnComputers.TabIndex = 2;
            this.btnComputers.Text = "Список компьютеров";
            this.btnComputers.UseVisualStyleBackColor = true;
            this.btnComputers.Click += new System.EventHandler(this.btnComputers_Click);
            // 
            // btnPeripherals
            // 
            this.btnPeripherals.Location = new System.Drawing.Point(10, 215);
            this.btnPeripherals.Margin = new System.Windows.Forms.Padding(0);
            this.btnPeripherals.Name = "btnPeripherals";
            this.btnPeripherals.Size = new System.Drawing.Size(250, 50);
            this.btnPeripherals.TabIndex = 3;
            this.btnPeripherals.Text = "Список периферии";
            this.btnPeripherals.UseVisualStyleBackColor = true;
            this.btnPeripherals.Click += new System.EventHandler(this.btnPeripherals_Click);
            // 
            // btnComponents
            // 
            this.btnComponents.Location = new System.Drawing.Point(10, 289);
            this.btnComponents.Margin = new System.Windows.Forms.Padding(0);
            this.btnComponents.Name = "btnComponents";
            this.btnComponents.Size = new System.Drawing.Size(250, 50);
            this.btnComponents.TabIndex = 4;
            this.btnComponents.Text = "Список компонентов";
            this.btnComponents.UseVisualStyleBackColor = true;
            this.btnComponents.Click += new System.EventHandler(this.btnComponents_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(910, 66);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(0);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(250, 50);
            this.btnSearch.TabIndex = 11;
            this.btnSearch.Text = "Поиск";
            this.btnSearch.UseVisualStyleBackColor = true;
            // 
            // btnDeleteEntry
            // 
            this.btnDeleteEntry.Location = new System.Drawing.Point(650, 66);
            this.btnDeleteEntry.Margin = new System.Windows.Forms.Padding(0);
            this.btnDeleteEntry.Name = "btnDeleteEntry";
            this.btnDeleteEntry.Size = new System.Drawing.Size(250, 50);
            this.btnDeleteEntry.TabIndex = 10;
            this.btnDeleteEntry.Text = "Удалить запись";
            this.btnDeleteEntry.UseVisualStyleBackColor = true;
            // 
            // btnAddEntry
            // 
            this.btnAddEntry.Location = new System.Drawing.Point(390, 66);
            this.btnAddEntry.Margin = new System.Windows.Forms.Padding(0);
            this.btnAddEntry.Name = "btnAddEntry";
            this.btnAddEntry.Size = new System.Drawing.Size(250, 50);
            this.btnAddEntry.TabIndex = 9;
            this.btnAddEntry.Text = "Добавить запись";
            this.btnAddEntry.UseVisualStyleBackColor = true;
            this.btnAddEntry.Click += new System.EventHandler(this.btnAddEntry_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(290, 140);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(970, 564);
            this.dataGridView1.TabIndex = 8;
            // 
            // yaxelForm1
            // 
            this.yaxelForm1.ThisForm = this;
            // 
            // MultiList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1280, 720);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnDeleteEntry);
            this.Controls.Add(this.btnAddEntry);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnComponents);
            this.Controls.Add(this.btnPeripherals);
            this.Controls.Add(this.btnComputers);
            this.Controls.Add(this.btnEmployees);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MultiList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Главное меню";
            this.Load += new System.EventHandler(this.MultiList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private YaxelStyle.YaxelForm yaxelForm1;
        private System.Windows.Forms.Button btnComponents;
        private System.Windows.Forms.Button btnPeripherals;
        private System.Windows.Forms.Button btnComputers;
        private System.Windows.Forms.Button btnEmployees;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnDeleteEntry;
        private System.Windows.Forms.Button btnAddEntry;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}