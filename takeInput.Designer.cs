namespace airlinemanagement
{
    partial class takeInput
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
            this.ratingName = new System.Windows.Forms.TextBox();
            this.ratingButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ratingName
            // 
            this.ratingName.Location = new System.Drawing.Point(60, 34);
            this.ratingName.Name = "ratingName";
            this.ratingName.Size = new System.Drawing.Size(100, 20);
            this.ratingName.TabIndex = 0;
            // 
            // ratingButton
            // 
            this.ratingButton.Location = new System.Drawing.Point(60, 60);
            this.ratingButton.Name = "ratingButton";
            this.ratingButton.Size = new System.Drawing.Size(100, 23);
            this.ratingButton.TabIndex = 1;
            this.ratingButton.Text = "button1";
            this.ratingButton.UseVisualStyleBackColor = true;
            this.ratingButton.Click += new System.EventHandler(this.ratingButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(62, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 31);
            this.label1.TabIndex = 2;
            this.label1.Text = "Name:";
            // 
            // takeInput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(219, 104);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ratingButton);
            this.Controls.Add(this.ratingName);
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "takeInput";
            this.Text = "takeInput";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox ratingName;
        private System.Windows.Forms.Button ratingButton;
        private System.Windows.Forms.Label label1;
    }
}