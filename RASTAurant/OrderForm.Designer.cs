namespace RASTAurant
{
    partial class OrderForm
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
            totalLabel = new Label();
            label1 = new Label();
            label2 = new Label();
            newItemTextBox = new TextBox();
            newPriceTextBox = new TextBox();
            addButton = new Button();
            dataGridView1 = new DataGridView();
            Column1 = new DataGridViewTextBoxColumn();
            Price = new DataGridViewTextBoxColumn();
            clearOrdersButton = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // totalLabel
            // 
            totalLabel.AutoSize = true;
            totalLabel.Location = new Point(12, 412);
            totalLabel.Name = "totalLabel";
            totalLabel.Size = new Size(42, 20);
            totalLabel.TabIndex = 0;
            totalLabel.Text = "Total";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 461);
            label1.Name = "label1";
            label1.Size = new Size(49, 20);
            label1.TabIndex = 1;
            label1.Text = "Name";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(202, 461);
            label2.Name = "label2";
            label2.Size = new Size(41, 20);
            label2.TabIndex = 2;
            label2.Text = "Price";
            // 
            // newItemTextBox
            // 
            newItemTextBox.Location = new Point(67, 458);
            newItemTextBox.Name = "newItemTextBox";
            newItemTextBox.Size = new Size(125, 27);
            newItemTextBox.TabIndex = 3;
            // 
            // newPriceTextBox
            // 
            newPriceTextBox.Location = new Point(249, 458);
            newPriceTextBox.Name = "newPriceTextBox";
            newPriceTextBox.Size = new Size(125, 27);
            newPriceTextBox.TabIndex = 4;
            // 
            // addButton
            // 
            addButton.Location = new Point(405, 457);
            addButton.Name = "addButton";
            addButton.Size = new Size(94, 29);
            addButton.TabIndex = 5;
            addButton.Text = "Add Order";
            addButton.UseVisualStyleBackColor = true;
            addButton.Click += addButton_Click_1;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { Column1, Price });
            dataGridView1.Location = new Point(12, 12);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(487, 375);
            dataGridView1.TabIndex = 6;
            // 
            // Column1
            // 
            Column1.HeaderText = "Item";
            Column1.MinimumWidth = 6;
            Column1.Name = "Column1";
            Column1.ReadOnly = true;
            Column1.Width = 125;
            // 
            // Price
            // 
            Price.HeaderText = "Price";
            Price.MinimumWidth = 6;
            Price.Name = "Price";
            Price.ReadOnly = true;
            Price.Width = 125;
            // 
            // clearOrdersButton
            // 
            clearOrdersButton.Location = new Point(405, 408);
            clearOrdersButton.Name = "clearOrdersButton";
            clearOrdersButton.Size = new Size(94, 29);
            clearOrdersButton.TabIndex = 7;
            clearOrdersButton.Text = "Done";
            clearOrdersButton.UseVisualStyleBackColor = true;
            clearOrdersButton.Click += clearOrdersButton_Click;
            // 
            // OrderForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(511, 490);
            Controls.Add(clearOrdersButton);
            Controls.Add(dataGridView1);
            Controls.Add(addButton);
            Controls.Add(newPriceTextBox);
            Controls.Add(newItemTextBox);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(totalLabel);
            Name = "OrderForm";
            Text = "OrderForm";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label totalLabel;
        private Label label1;
        private Label label2;
        private TextBox newItemTextBox;
        private TextBox newPriceTextBox;
        private Button addButton;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Price;
        private Button clearOrdersButton;
    }
}