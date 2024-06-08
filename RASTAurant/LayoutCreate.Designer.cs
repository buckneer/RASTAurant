namespace RASTAurant
{
    partial class LayoutCreate
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
            components = new System.ComponentModel.Container();
            formTimer = new System.Windows.Forms.Timer(components);
            label1 = new Label();
            label2 = new Label();
            layoutNameTextBox = new TextBox();
            saveLayout = new Button();
            newTable = new Button();
            SuspendLayout();
            // 
            // formTimer
            // 
            formTimer.Enabled = true;
            formTimer.Interval = 20;
            formTimer.Tick += timer1_Tick;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(52, 22);
            label1.Name = "label1";
            label1.Size = new Size(50, 20);
            label1.TabIndex = 0;
            label1.Text = "label1";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 421);
            label2.Name = "label2";
            label2.Size = new Size(131, 20);
            label2.TabIndex = 1;
            label2.Text = "New Layout Name";
            // 
            // layoutNameTextBox
            // 
            layoutNameTextBox.Location = new Point(149, 418);
            layoutNameTextBox.Name = "layoutNameTextBox";
            layoutNameTextBox.Size = new Size(176, 27);
            layoutNameTextBox.TabIndex = 2;
            // 
            // saveLayout
            // 
            saveLayout.Location = new Point(340, 417);
            saveLayout.Name = "saveLayout";
            saveLayout.Size = new Size(135, 29);
            saveLayout.TabIndex = 3;
            saveLayout.Text = "Save Layout";
            saveLayout.UseVisualStyleBackColor = true;
            saveLayout.Click += saveLayout_Click;
            // 
            // newTable
            // 
            newTable.Location = new Point(694, 416);
            newTable.Name = "newTable";
            newTable.Size = new Size(94, 29);
            newTable.TabIndex = 4;
            newTable.Text = "Add Table";
            newTable.UseVisualStyleBackColor = true;
            newTable.Click += newTable_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(newTable);
            Controls.Add(saveLayout);
            Controls.Add(layoutNameTextBox);
            Controls.Add(label2);
            Controls.Add(label1);
            DoubleBuffered = true;
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            Paint += FormPaintEvent;
            MouseDown += FormMouseDown;
            MouseMove += FormMouseMove;
            MouseUp += FormMouseUp;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Timer formTimer;
        private Label label1;
        private Label label2;
        private TextBox layoutNameTextBox;
        private Button saveLayout;
        private Button newTable;
    }
}
