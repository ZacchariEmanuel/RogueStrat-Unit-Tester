namespace Unit_Test
{
    partial class DeckbuilderForm
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.txtDeck = new System.Windows.Forms.TextBox();
            this.btnDraw = new System.Windows.Forms.Button();
            this.txtHand = new System.Windows.Forms.TextBox();
            this.txtLocalDeck = new System.Windows.Forms.TextBox();
            this.btnPushDeck = new System.Windows.Forms.Button();
            this.txtMana = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22.22222F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 55.55556F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22.22222F));
            this.tableLayoutPanel1.Controls.Add(this.txtDeck, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnDraw, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtHand, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtLocalDeck, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.btnPushDeck, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtMana, 3, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(391, 450);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // txtDeck
            // 
            this.txtDeck.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDeck.Location = new System.Drawing.Point(28, 32);
            this.txtDeck.Multiline = true;
            this.txtDeck.Name = "txtDeck";
            this.tableLayoutPanel1.SetRowSpan(this.txtDeck, 2);
            this.txtDeck.Size = new System.Drawing.Size(75, 415);
            this.txtDeck.TabIndex = 0;
            this.txtDeck.Text = "Imp\r\nBear\r\nHawk\r\nAtlantean\r\nSpirit\r\nZombie\r\nDwarf\r\nImp\r\nBear\r\nHawk\r\nAtlantean\r\nSp" +
    "irit\r\nZombie\r\nDwarf\r\nImp\r\nBear\r\nHawk\r\nAtlantean\r\nSpirit\r\nZombie\r\nDwarf";
            // 
            // btnDraw
            // 
            this.btnDraw.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDraw.Location = new System.Drawing.Point(109, 3);
            this.btnDraw.Name = "btnDraw";
            this.btnDraw.Size = new System.Drawing.Size(197, 23);
            this.btnDraw.TabIndex = 1;
            this.btnDraw.Text = "Draw New 5";
            this.btnDraw.UseVisualStyleBackColor = true;
            this.btnDraw.Click += new System.EventHandler(this.BtnDraw_Click);
            // 
            // txtHand
            // 
            this.txtHand.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtHand.Location = new System.Drawing.Point(109, 32);
            this.txtHand.Multiline = true;
            this.txtHand.Name = "txtHand";
            this.txtHand.Size = new System.Drawing.Size(197, 204);
            this.txtHand.TabIndex = 2;
            // 
            // txtLocalDeck
            // 
            this.txtLocalDeck.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtLocalDeck.Location = new System.Drawing.Point(109, 242);
            this.txtLocalDeck.Multiline = true;
            this.txtLocalDeck.Name = "txtLocalDeck";
            this.txtLocalDeck.Size = new System.Drawing.Size(197, 205);
            this.txtLocalDeck.TabIndex = 3;
            // 
            // btnPushDeck
            // 
            this.btnPushDeck.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPushDeck.Location = new System.Drawing.Point(28, 3);
            this.btnPushDeck.Name = "btnPushDeck";
            this.btnPushDeck.Size = new System.Drawing.Size(75, 23);
            this.btnPushDeck.TabIndex = 4;
            this.btnPushDeck.Text = "Push Deck";
            this.btnPushDeck.UseVisualStyleBackColor = true;
            this.btnPushDeck.Click += new System.EventHandler(this.BtnPushDeck_Click);
            // 
            // txtMana
            // 
            this.txtMana.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMana.Location = new System.Drawing.Point(312, 32);
            this.txtMana.Multiline = true;
            this.txtMana.Name = "txtMana";
            this.tableLayoutPanel1.SetRowSpan(this.txtMana, 2);
            this.txtMana.Size = new System.Drawing.Size(76, 415);
            this.txtMana.TabIndex = 5;
            this.txtMana.Text = "F: 0\r\nW: 0\r\nN: 0\r\nR: 0\r\nA: 0\r\nL: 0\r\nD: 0";
            // 
            // DeckbuilderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(391, 450);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "DeckbuilderForm";
            this.Text = "DeckbuilderForm";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox txtDeck;
        private System.Windows.Forms.Button btnDraw;
        private System.Windows.Forms.TextBox txtHand;
        private System.Windows.Forms.TextBox txtLocalDeck;
        private System.Windows.Forms.Button btnPushDeck;
        private System.Windows.Forms.TextBox txtMana;
    }
}