namespace Unit_Test
{
    partial class Form1
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
            this.label1 = new System.Windows.Forms.Label();
            this.listboxUnits = new System.Windows.Forms.ListBox();
            this.tablelayoutGameBoard = new System.Windows.Forms.TableLayoutPanel();
            this.btnRunTurn = new System.Windows.Forms.Button();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.txtUnitInfo = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.lblPlayerHP = new System.Windows.Forms.Label();
            this.lblEnemyHP = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.listboxUnits, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tablelayoutGameBoard, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnRunTurn, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.radioButton1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.radioButton2, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtUnitInfo, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 2, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.624708F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 91.37529F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 123F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(800, 450);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Units";
            // 
            // listboxUnits
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.listboxUnits, 2);
            this.listboxUnits.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listboxUnits.FormattingEnabled = true;
            this.listboxUnits.Location = new System.Drawing.Point(3, 28);
            this.listboxUnits.Name = "listboxUnits";
            this.listboxUnits.Size = new System.Drawing.Size(394, 258);
            this.listboxUnits.TabIndex = 1;
            this.listboxUnits.SelectedIndexChanged += new System.EventHandler(this.ListboxUnits_SelectedIndexChanged);
            // 
            // tablelayoutGameBoard
            // 
            this.tablelayoutGameBoard.ColumnCount = 1;
            this.tablelayoutGameBoard.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tablelayoutGameBoard.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tablelayoutGameBoard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tablelayoutGameBoard.Location = new System.Drawing.Point(403, 28);
            this.tablelayoutGameBoard.Name = "tablelayoutGameBoard";
            this.tablelayoutGameBoard.RowCount = 1;
            this.tablelayoutGameBoard.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tablelayoutGameBoard.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 258F));
            this.tablelayoutGameBoard.Size = new System.Drawing.Size(394, 258);
            this.tablelayoutGameBoard.TabIndex = 3;
            // 
            // btnRunTurn
            // 
            this.btnRunTurn.Location = new System.Drawing.Point(403, 292);
            this.btnRunTurn.Name = "btnRunTurn";
            this.btnRunTurn.Size = new System.Drawing.Size(75, 23);
            this.btnRunTurn.TabIndex = 4;
            this.btnRunTurn.Text = "Run";
            this.btnRunTurn.UseVisualStyleBackColor = true;
            this.btnRunTurn.Click += new System.EventHandler(this.BtnRunTurn_Click);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(3, 292);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(54, 17);
            this.radioButton1.TabIndex = 5;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Player";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(203, 292);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(57, 17);
            this.radioButton2.TabIndex = 6;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Enemy";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // txtUnitInfo
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.txtUnitInfo, 3);
            this.txtUnitInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtUnitInfo.Location = new System.Drawing.Point(3, 329);
            this.txtUnitInfo.Multiline = true;
            this.txtUnitInfo.Name = "txtUnitInfo";
            this.txtUnitInfo.Size = new System.Drawing.Size(794, 118);
            this.txtUnitInfo.TabIndex = 7;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.lblPlayerHP, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.lblEnemyHP, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(403, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(394, 19);
            this.tableLayoutPanel2.TabIndex = 8;
            // 
            // lblPlayerHP
            // 
            this.lblPlayerHP.AutoSize = true;
            this.lblPlayerHP.Location = new System.Drawing.Point(3, 0);
            this.lblPlayerHP.Name = "lblPlayerHP";
            this.lblPlayerHP.Size = new System.Drawing.Size(35, 13);
            this.lblPlayerHP.TabIndex = 0;
            this.lblPlayerHP.Text = "label2";
            // 
            // lblEnemyHP
            // 
            this.lblEnemyHP.AutoSize = true;
            this.lblEnemyHP.Location = new System.Drawing.Point(200, 0);
            this.lblEnemyHP.Name = "lblEnemyHP";
            this.lblEnemyHP.Size = new System.Drawing.Size(35, 13);
            this.lblEnemyHP.TabIndex = 1;
            this.lblEnemyHP.Text = "label3";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listboxUnits;
        private System.Windows.Forms.TableLayoutPanel tablelayoutGameBoard;
        private System.Windows.Forms.Button btnRunTurn;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.TextBox txtUnitInfo;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label lblPlayerHP;
        private System.Windows.Forms.Label lblEnemyHP;
    }
}

