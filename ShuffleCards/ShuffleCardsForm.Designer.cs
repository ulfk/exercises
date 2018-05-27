namespace ShuffleCards
{
    partial class ShuffleCardsForm
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
            this.buttonShuffle = new System.Windows.Forms.Button();
            this.buttonReset = new System.Windows.Forms.Button();
            this.picturePanel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // buttonShuffle
            // 
            this.buttonShuffle.Location = new System.Drawing.Point(13, 13);
            this.buttonShuffle.Name = "buttonShuffle";
            this.buttonShuffle.Size = new System.Drawing.Size(75, 23);
            this.buttonShuffle.TabIndex = 0;
            this.buttonShuffle.Text = "Shuffle";
            this.buttonShuffle.UseVisualStyleBackColor = true;
            this.buttonShuffle.Click += new System.EventHandler(this.buttonShuffle_Click);
            // 
            // buttonReset
            // 
            this.buttonReset.Location = new System.Drawing.Point(95, 13);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Size = new System.Drawing.Size(75, 23);
            this.buttonReset.TabIndex = 1;
            this.buttonReset.Text = "Reset";
            this.buttonReset.UseVisualStyleBackColor = true;
            this.buttonReset.Click += new System.EventHandler(this.buttonReset_Click);
            // 
            // picturePanel
            // 
            this.picturePanel.Location = new System.Drawing.Point(13, 42);
            this.picturePanel.Name = "picturePanel";
            this.picturePanel.Size = new System.Drawing.Size(1092, 512);
            this.picturePanel.TabIndex = 2;
            // 
            // ShuffleCardsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1114, 564);
            this.Controls.Add(this.picturePanel);
            this.Controls.Add(this.buttonReset);
            this.Controls.Add(this.buttonShuffle);
            this.Name = "ShuffleCardsForm";
            this.Text = "ShuffleCards";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonShuffle;
        private System.Windows.Forms.Button buttonReset;
        private System.Windows.Forms.Panel picturePanel;
    }
}

