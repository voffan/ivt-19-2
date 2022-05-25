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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.SearchTextBox = new System.Windows.Forms.TextBox();
            this.yaxelButton1 = new Yaxel.YaxelStyle.YaxelButton();
            this.btnManufacturers = new Yaxel.YaxelStyle.YaxelButton();
            this.btnSearch = new Yaxel.YaxelStyle.YaxelButton();
            this.btnDeleteEntry = new Yaxel.YaxelStyle.YaxelButton();
            this.btnAddEntry = new Yaxel.YaxelStyle.YaxelButton();
            this.btnComponents = new Yaxel.YaxelStyle.YaxelButton();
            this.btnPeripherals = new Yaxel.YaxelStyle.YaxelButton();
            this.btnComputers = new Yaxel.YaxelStyle.YaxelButton();
            this.btnEmployees = new Yaxel.YaxelStyle.YaxelButton();
            this.yaxelForm1 = new Yaxel.YaxelStyle.YaxelForm(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridView1.Location = new System.Drawing.Point(290, 136);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(970, 564);
            this.dataGridView1.TabIndex = 8;
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            // 
            // SearchTextBox
            // 
            this.SearchTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SearchTextBox.Location = new System.Drawing.Point(811, 75);
            this.SearchTextBox.Name = "SearchTextBox";
            this.SearchTextBox.Size = new System.Drawing.Size(290, 32);
            this.SearchTextBox.TabIndex = 20;
            // 
            // yaxelButton1
            // 
            this.yaxelButton1.DialogResult = System.Windows.Forms.DialogResult.None;
            this.yaxelButton1.Font = new System.Drawing.Font("Arial", 16F);
            this.yaxelButton1.ForeColor = System.Drawing.Color.White;
            this.yaxelButton1.Location = new System.Drawing.Point(20, 650);
            this.yaxelButton1.Name = "yaxelButton1";
            this.yaxelButton1.Size = new System.Drawing.Size(250, 50);
            this.yaxelButton1.TabIndex = 21;
            this.yaxelButton1.Text = "Отчёты";
            this.yaxelButton1.Click += new System.EventHandler(this.yaxelButton1_Click);
            // 
            // btnManufacturers
            // 
            this.btnManufacturers.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnManufacturers.Font = new System.Drawing.Font("Arial", 16F);
            this.btnManufacturers.ForeColor = System.Drawing.Color.White;
            this.btnManufacturers.Location = new System.Drawing.Point(20, 346);
            this.btnManufacturers.Name = "btnManufacturers";
            this.btnManufacturers.Size = new System.Drawing.Size(250, 50);
            this.btnManufacturers.TabIndex = 19;
            this.btnManufacturers.Text = "Список производителей";
            this.btnManufacturers.Click += new System.EventHandler(this.btnManufacturers_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnSearch.Font = new System.Drawing.Font("Arial", 16F);
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Location = new System.Drawing.Point(1107, 66);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(153, 50);
            this.btnSearch.TabIndex = 18;
            this.btnSearch.Text = "Поиск";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnDeleteEntry
            // 
            this.btnDeleteEntry.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnDeleteEntry.Font = new System.Drawing.Font("Arial", 16F);
            this.btnDeleteEntry.ForeColor = System.Drawing.Color.White;
            this.btnDeleteEntry.Location = new System.Drawing.Point(555, 66);
            this.btnDeleteEntry.Name = "btnDeleteEntry";
            this.btnDeleteEntry.Size = new System.Drawing.Size(250, 50);
            this.btnDeleteEntry.TabIndex = 17;
            this.btnDeleteEntry.Text = "Удалить запись";
            this.btnDeleteEntry.Click += new System.EventHandler(this.btnDeleteEntry_Click);
            // 
            // btnAddEntry
            // 
            this.btnAddEntry.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnAddEntry.Font = new System.Drawing.Font("Arial", 16F);
            this.btnAddEntry.ForeColor = System.Drawing.Color.White;
            this.btnAddEntry.Location = new System.Drawing.Point(295, 66);
            this.btnAddEntry.Name = "btnAddEntry";
            this.btnAddEntry.Size = new System.Drawing.Size(250, 50);
            this.btnAddEntry.TabIndex = 16;
            this.btnAddEntry.Text = "Добавить запись";
            this.btnAddEntry.Click += new System.EventHandler(this.btnAddEntry_Click);
            // 
            // btnComponents
            // 
            this.btnComponents.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnComponents.Font = new System.Drawing.Font("Arial", 16F);
            this.btnComponents.ForeColor = System.Drawing.Color.White;
            this.btnComponents.Location = new System.Drawing.Point(20, 276);
            this.btnComponents.Name = "btnComponents";
            this.btnComponents.Size = new System.Drawing.Size(250, 50);
            this.btnComponents.TabIndex = 15;
            this.btnComponents.Text = "Список компонентов";
            this.btnComponents.Click += new System.EventHandler(this.btnComponents_Click);
            // 
            // btnPeripherals
            // 
            this.btnPeripherals.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnPeripherals.Font = new System.Drawing.Font("Arial", 16F);
            this.btnPeripherals.ForeColor = System.Drawing.Color.White;
            this.btnPeripherals.Location = new System.Drawing.Point(20, 206);
            this.btnPeripherals.Name = "btnPeripherals";
            this.btnPeripherals.Size = new System.Drawing.Size(250, 50);
            this.btnPeripherals.TabIndex = 14;
            this.btnPeripherals.Text = "Список периферии";
            this.btnPeripherals.Click += new System.EventHandler(this.btnPeripherals_Click);
            // 
            // btnComputers
            // 
            this.btnComputers.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnComputers.Font = new System.Drawing.Font("Arial", 16F);
            this.btnComputers.ForeColor = System.Drawing.Color.White;
            this.btnComputers.Location = new System.Drawing.Point(20, 136);
            this.btnComputers.Name = "btnComputers";
            this.btnComputers.Size = new System.Drawing.Size(250, 50);
            this.btnComputers.TabIndex = 13;
            this.btnComputers.Text = "Список компьютеров";
            this.btnComputers.Click += new System.EventHandler(this.btnComputers_Click);
            // 
            // btnEmployees
            // 
            this.btnEmployees.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnEmployees.Font = new System.Drawing.Font("Arial", 16F);
            this.btnEmployees.ForeColor = System.Drawing.Color.White;
            this.btnEmployees.Location = new System.Drawing.Point(20, 66);
            this.btnEmployees.Name = "btnEmployees";
            this.btnEmployees.Size = new System.Drawing.Size(250, 50);
            this.btnEmployees.TabIndex = 12;
            this.btnEmployees.Text = "Список сотрудников";
            this.btnEmployees.Click += new System.EventHandler(this.btnEmployees_Click);
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
            this.Controls.Add(this.yaxelButton1);
            this.Controls.Add(this.SearchTextBox);
            this.Controls.Add(this.btnManufacturers);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnDeleteEntry);
            this.Controls.Add(this.btnAddEntry);
            this.Controls.Add(this.btnComponents);
            this.Controls.Add(this.btnPeripherals);
            this.Controls.Add(this.btnComputers);
            this.Controls.Add(this.btnEmployees);
            this.Controls.Add(this.dataGridView1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MultiList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Главное меню";
            this.Load += new System.EventHandler(this.MultiList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private YaxelStyle.YaxelForm yaxelForm1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private YaxelStyle.YaxelButton btnEmployees;
        private YaxelStyle.YaxelButton btnComputers;
        private YaxelStyle.YaxelButton btnComponents;
        private YaxelStyle.YaxelButton btnPeripherals;
        private YaxelStyle.YaxelButton btnDeleteEntry;
        private YaxelStyle.YaxelButton btnAddEntry;
        private YaxelStyle.YaxelButton btnManufacturers;
        private System.Windows.Forms.TextBox SearchTextBox;
        private YaxelStyle.YaxelButton btnSearch;
        private YaxelStyle.YaxelButton yaxelButton1;
    }
}