namespace TextAdventureGame
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

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
            this.lblNarration = new System.Windows.Forms.Label();
            this.lblHealth = new System.Windows.Forms.Label();
            this.lblLocation = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.lstInventory = new System.Windows.Forms.ListBox();
            this.txtCommand = new System.Windows.Forms.TextBox();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.txtOutput = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblNarration
            // 
            this.lblNarration.AutoSize = true;
            this.lblNarration.Location = new System.Drawing.Point(20, 20);
            this.lblNarration.Name = "lblNarration";
            this.lblNarration.Size = new System.Drawing.Size(0, 13);
            this.lblNarration.TabIndex = 0;
            // 
            // lblHealth
            // 
            this.lblHealth.AutoSize = true;
            this.lblHealth.Location = new System.Drawing.Point(20, 80);
            this.lblHealth.Name = "lblHealth";
            this.lblHealth.Size = new System.Drawing.Size(0, 13);
            this.lblHealth.TabIndex = 1;
            // 
            // lblLocation
            // 
            this.lblLocation.AutoSize = true;
            this.lblLocation.Location = new System.Drawing.Point(20, 110);
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.Size = new System.Drawing.Size(0, 13);
            this.lblLocation.TabIndex = 2;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(20, 140);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(0, 13);
            this.lblDescription.TabIndex = 3;
            // 
            // lstInventory
            // 
            this.lstInventory.FormattingEnabled = true;
            this.lstInventory.Location = new System.Drawing.Point(20, 270);
            this.lstInventory.Name = "lstInventory";
            this.lstInventory.Size = new System.Drawing.Size(150, 95);
            this.lstInventory.TabIndex = 4;
            // 
            // txtCommand
            // 
            this.txtCommand.Location = new System.Drawing.Point(250, 450);
            this.txtCommand.Name = "txtCommand";
            this.txtCommand.Size = new System.Drawing.Size(150, 20);
            this.txtCommand.TabIndex = 5;
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(420, 448);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(75, 23);
            this.btnSubmit.TabIndex = 6;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // txtOutput
            // 
            this.txtOutput.Location = new System.Drawing.Point(600, 80);
            this.txtOutput.Multiline = true;
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.ReadOnly = true;
            this.txtOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtOutput.Size = new System.Drawing.Size(350, 470);
            this.txtOutput.TabIndex = 7;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 562);
            this.Controls.Add(this.txtOutput);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.txtCommand);
            this.Controls.Add(this.lstInventory);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.lblLocation);
            this.Controls.Add(this.lblHealth);
            this.Controls.Add(this.lblNarration);
            this.Name = "Form1";
            this.Text = "Lost in the Woods";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblNarration;
        private System.Windows.Forms.Label lblHealth;
        private System.Windows.Forms.Label lblLocation;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.ListBox lstInventory;
        private System.Windows.Forms.TextBox txtCommand;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.TextBox txtOutput;
    }
}
