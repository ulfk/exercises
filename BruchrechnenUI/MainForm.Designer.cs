namespace BruchrechnenUI
{
    partial class MainForm
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
            this.textBoxZaehlerLinks = new System.Windows.Forms.TextBox();
            this.textBoxNennerLinks = new System.Windows.Forms.TextBox();
            this.textBoxZaehlerRechts = new System.Windows.Forms.TextBox();
            this.textBoxNennerRechts = new System.Windows.Forms.TextBox();
            this.textBoxZaehlerErgebnis = new System.Windows.Forms.TextBox();
            this.textBoxNennerErgebnis = new System.Windows.Forms.TextBox();
            this.comboBoxCalcSelector = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBoxZaehlerLinks
            // 
            this.textBoxZaehlerLinks.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxZaehlerLinks.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxZaehlerLinks.Location = new System.Drawing.Point(45, 23);
            this.textBoxZaehlerLinks.Name = "textBoxZaehlerLinks";
            this.textBoxZaehlerLinks.Size = new System.Drawing.Size(66, 19);
            this.textBoxZaehlerLinks.TabIndex = 0;
            this.textBoxZaehlerLinks.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxZaehlerLinks.TextChanged += new System.EventHandler(this.textBoxZaehlerLinks_TextChanged);
            this.textBoxZaehlerLinks.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxZaehlerLinks_KeyPress);
            // 
            // textBoxNennerLinks
            // 
            this.textBoxNennerLinks.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxNennerLinks.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxNennerLinks.Location = new System.Drawing.Point(45, 64);
            this.textBoxNennerLinks.Name = "textBoxNennerLinks";
            this.textBoxNennerLinks.Size = new System.Drawing.Size(66, 19);
            this.textBoxNennerLinks.TabIndex = 1;
            this.textBoxNennerLinks.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxNennerLinks.TextChanged += new System.EventHandler(this.textBoxNennerLinks_TextChanged);
            this.textBoxNennerLinks.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxNennerLinks_KeyPress);
            // 
            // textBoxZaehlerRechts
            // 
            this.textBoxZaehlerRechts.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxZaehlerRechts.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxZaehlerRechts.Location = new System.Drawing.Point(190, 23);
            this.textBoxZaehlerRechts.Name = "textBoxZaehlerRechts";
            this.textBoxZaehlerRechts.Size = new System.Drawing.Size(68, 19);
            this.textBoxZaehlerRechts.TabIndex = 3;
            this.textBoxZaehlerRechts.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxZaehlerRechts.TextChanged += new System.EventHandler(this.textBoxZaehlerRechts_TextChanged);
            this.textBoxZaehlerRechts.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxZaehlerRechts_KeyPress);
            // 
            // textBoxNennerRechts
            // 
            this.textBoxNennerRechts.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxNennerRechts.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxNennerRechts.Location = new System.Drawing.Point(190, 64);
            this.textBoxNennerRechts.Name = "textBoxNennerRechts";
            this.textBoxNennerRechts.Size = new System.Drawing.Size(68, 19);
            this.textBoxNennerRechts.TabIndex = 4;
            this.textBoxNennerRechts.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxNennerRechts.TextChanged += new System.EventHandler(this.textBoxNennerRechts_TextChanged);
            this.textBoxNennerRechts.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxNennerRechts_KeyPress);
            // 
            // textBoxZaehlerErgebnis
            // 
            this.textBoxZaehlerErgebnis.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxZaehlerErgebnis.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxZaehlerErgebnis.Location = new System.Drawing.Point(314, 23);
            this.textBoxZaehlerErgebnis.Name = "textBoxZaehlerErgebnis";
            this.textBoxZaehlerErgebnis.ReadOnly = true;
            this.textBoxZaehlerErgebnis.Size = new System.Drawing.Size(68, 19);
            this.textBoxZaehlerErgebnis.TabIndex = 4;
            this.textBoxZaehlerErgebnis.TabStop = false;
            this.textBoxZaehlerErgebnis.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxNennerErgebnis
            // 
            this.textBoxNennerErgebnis.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxNennerErgebnis.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxNennerErgebnis.Location = new System.Drawing.Point(314, 64);
            this.textBoxNennerErgebnis.Name = "textBoxNennerErgebnis";
            this.textBoxNennerErgebnis.ReadOnly = true;
            this.textBoxNennerErgebnis.Size = new System.Drawing.Size(68, 19);
            this.textBoxNennerErgebnis.TabIndex = 5;
            this.textBoxNennerErgebnis.TabStop = false;
            this.textBoxNennerErgebnis.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // comboBoxCalcSelector
            // 
            this.comboBoxCalcSelector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCalcSelector.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxCalcSelector.FormattingEnabled = true;
            this.comboBoxCalcSelector.Items.AddRange(new object[] {
            "+",
            "-",
            "*",
            "/"});
            this.comboBoxCalcSelector.Location = new System.Drawing.Point(124, 41);
            this.comboBoxCalcSelector.Name = "comboBoxCalcSelector";
            this.comboBoxCalcSelector.Size = new System.Drawing.Size(51, 33);
            this.comboBoxCalcSelector.TabIndex = 2;
            this.comboBoxCalcSelector.SelectedValueChanged += new System.EventHandler(this.comboBoxCalcSelector_SelectedValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(34, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 46);
            this.label1.TabIndex = 7;
            this.label1.Text = "___";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(182, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 46);
            this.label2.TabIndex = 8;
            this.label2.Text = "___";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(306, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 46);
            this.label3.TabIndex = 9;
            this.label3.Text = "___";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(268, 37);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 39);
            this.label4.TabIndex = 10;
            this.label4.Text = "=";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(423, 111);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.comboBoxCalcSelector);
            this.Controls.Add(this.textBoxNennerErgebnis);
            this.Controls.Add(this.textBoxZaehlerErgebnis);
            this.Controls.Add(this.textBoxNennerRechts);
            this.Controls.Add(this.textBoxZaehlerRechts);
            this.Controls.Add(this.textBoxNennerLinks);
            this.Controls.Add(this.textBoxZaehlerLinks);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Name = "MainForm";
            this.Text = "Bruchrechnen";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxZaehlerLinks;
        private System.Windows.Forms.TextBox textBoxNennerLinks;
        private System.Windows.Forms.TextBox textBoxZaehlerRechts;
        private System.Windows.Forms.TextBox textBoxNennerRechts;
        private System.Windows.Forms.TextBox textBoxZaehlerErgebnis;
        private System.Windows.Forms.TextBox textBoxNennerErgebnis;
        private System.Windows.Forms.ComboBox comboBoxCalcSelector;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}

