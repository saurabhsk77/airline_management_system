﻿namespace airlinemanagement
{
    partial class UserRating
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.ratingButton = new System.Windows.Forms.Button();
            this.ratingName = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(7, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 31);
            this.label1.TabIndex = 5;
            this.label1.Text = "Name:";
            // 
            // ratingButton
            // 
            this.ratingButton.Location = new System.Drawing.Point(3, 60);
            this.ratingButton.Name = "ratingButton";
            this.ratingButton.Size = new System.Drawing.Size(100, 23);
            this.ratingButton.TabIndex = 4;
            this.ratingButton.Text = "SUBMIT";
            this.ratingButton.UseVisualStyleBackColor = true;
            this.ratingButton.Click += new System.EventHandler(this.ratingButton_Click);
            // 
            // ratingName
            // 
            this.ratingName.Location = new System.Drawing.Point(3, 34);
            this.ratingName.Name = "ratingName";
            this.ratingName.Size = new System.Drawing.Size(100, 20);
            this.ratingName.TabIndex = 3;
            // 
            // UserRating
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ratingButton);
            this.Controls.Add(this.ratingName);
            this.Name = "UserRating";
            this.Size = new System.Drawing.Size(106, 86);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button ratingButton;
        private System.Windows.Forms.TextBox ratingName;
    }
}
