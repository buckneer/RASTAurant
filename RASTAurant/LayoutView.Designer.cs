namespace RASTAurant
{
    partial class LayoutView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private ListBox listBoxLayouts;
        private TextBox textBoxLayoutDetails;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            listBoxLayouts = new ListBox();
            textBoxLayoutDetails = new TextBox();
            newLayoutButton = new Button();
            SuspendLayout();
            // 
            // listBoxLayouts
            // 
            listBoxLayouts.FormattingEnabled = true;
            listBoxLayouts.Location = new Point(12, 12);
            listBoxLayouts.Name = "listBoxLayouts";
            listBoxLayouts.Size = new Size(200, 324);
            listBoxLayouts.TabIndex = 0;
            listBoxLayouts.SelectedIndexChanged += listBoxLayouts_SelectedIndexChanged;
            listBoxLayouts.MouseDoubleClick += listBoxLayouts_MouseDoubleClick;
            // 
            // textBoxLayoutDetails
            // 
            textBoxLayoutDetails.Location = new Point(218, 12);
            textBoxLayoutDetails.Multiline = true;
            textBoxLayoutDetails.Name = "textBoxLayoutDetails";
            textBoxLayoutDetails.Size = new Size(254, 328);
            textBoxLayoutDetails.TabIndex = 1;
            // 
            // newLayoutButton
            // 
            newLayoutButton.Location = new Point(56, 351);
            newLayoutButton.Name = "newLayoutButton";
            newLayoutButton.Size = new Size(112, 29);
            newLayoutButton.TabIndex = 2;
            newLayoutButton.Text = "New Layout";
            newLayoutButton.UseVisualStyleBackColor = true;
            newLayoutButton.Click += this.newLayoutButton_Click;
            // 
            // LayoutView
            // 
            ClientSize = new Size(484, 392);
            Controls.Add(newLayoutButton);
            Controls.Add(textBoxLayoutDetails);
            Controls.Add(listBoxLayouts);
            Name = "LayoutView";
            Text = "Layouts";
            ResumeLayout(false);
            PerformLayout();
        }

        private Button newLayoutButton;
    }
}