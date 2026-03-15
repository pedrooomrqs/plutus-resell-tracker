namespace Tracker
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

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtBuy = new System.Windows.Forms.TextBox();
            this.txtSell = new System.Windows.Forms.TextBox();
            this.txtFees = new System.Windows.Forms.TextBox();
            this.txtShipping = new System.Windows.Forms.TextBox();
            this.txtBumps = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.gridItems = new System.Windows.Forms.DataGridView();
            this.lblGrossProfit = new System.Windows.Forms.Label();
            this.lblTotalBumps = new System.Windows.Forms.Label();
            this.lblNetProfit = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnUndoBump = new System.Windows.Forms.Button();
            this.topPanel = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gridItems)).BeginInit();
            this.topPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(20, 36);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(120, 20);
            this.txtName.TabIndex = 0;
            // 
            // txtBuy
            // 
            this.txtBuy.Location = new System.Drawing.Point(146, 36);
            this.txtBuy.Name = "txtBuy";
            this.txtBuy.Size = new System.Drawing.Size(110, 20);
            this.txtBuy.TabIndex = 1;
            // 
            // txtSell
            // 
            this.txtSell.Location = new System.Drawing.Point(262, 36);
            this.txtSell.Name = "txtSell";
            this.txtSell.Size = new System.Drawing.Size(110, 20);
            this.txtSell.TabIndex = 2;
            // 
            // txtFees
            // 
            this.txtFees.Location = new System.Drawing.Point(378, 36);
            this.txtFees.Name = "txtFees";
            this.txtFees.Size = new System.Drawing.Size(110, 20);
            this.txtFees.TabIndex = 3;
            // 
            // txtShipping
            // 
            this.txtShipping.Location = new System.Drawing.Point(494, 36);
            this.txtShipping.Name = "txtShipping";
            this.txtShipping.Size = new System.Drawing.Size(110, 20);
            this.txtShipping.TabIndex = 4;
            // 
            // txtBumps
            // 
            this.txtBumps.Location = new System.Drawing.Point(610, 36);
            this.txtBumps.Name = "txtBumps";
            this.txtBumps.Size = new System.Drawing.Size(120, 20);
            this.txtBumps.TabIndex = 5;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(461, 418);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(85, 30);
            this.btnAdd.TabIndex = 6;
            this.btnAdd.Text = "Add Item";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // gridItems
            // 
            this.gridItems.AllowUserToAddRows = false;
            this.gridItems.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridItems.Location = new System.Drawing.Point(20, 62);
            this.gridItems.Name = "gridItems";
            this.gridItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridItems.Size = new System.Drawing.Size(710, 350);
            this.gridItems.TabIndex = 7;
            // 
            // lblGrossProfit
            // 
            this.lblGrossProfit.AutoSize = true;
            this.lblGrossProfit.Location = new System.Drawing.Point(17, 418);
            this.lblGrossProfit.Name = "lblGrossProfit";
            this.lblGrossProfit.Size = new System.Drawing.Size(94, 13);
            this.lblGrossProfit.TabIndex = 8;
            this.lblGrossProfit.Text = "Gross Profit: 0.00€";
            this.lblGrossProfit.Click += new System.EventHandler(this.lblGrossProfit_Click);
            // 
            // lblTotalBumps
            // 
            this.lblTotalBumps.AutoSize = true;
            this.lblTotalBumps.Location = new System.Drawing.Point(17, 435);
            this.lblTotalBumps.Name = "lblTotalBumps";
            this.lblTotalBumps.Size = new System.Drawing.Size(72, 13);
            this.lblTotalBumps.TabIndex = 9;
            this.lblTotalBumps.Text = "Bumps: 0.00€";
            this.lblTotalBumps.Click += new System.EventHandler(this.lblTotalBumps_Click);
            // 
            // lblNetProfit
            // 
            this.lblNetProfit.AutoSize = true;
            this.lblNetProfit.Location = new System.Drawing.Point(17, 452);
            this.lblNetProfit.Name = "lblNetProfit";
            this.lblNetProfit.Size = new System.Drawing.Size(84, 13);
            this.lblNetProfit.TabIndex = 10;
            this.lblNetProfit.Text = "Net Profit: 0.00€";
            this.lblNetProfit.Click += new System.EventHandler(this.lblNetProfit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(645, 418);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(85, 30);
            this.btnDelete.TabIndex = 11;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnUndoBump
            // 
            this.btnUndoBump.Location = new System.Drawing.Point(553, 418);
            this.btnUndoBump.Name = "btnUndoBump";
            this.btnUndoBump.Size = new System.Drawing.Size(85, 30);
            this.btnUndoBump.TabIndex = 12;
            this.btnUndoBump.Text = "Undo Bump";
            this.btnUndoBump.UseVisualStyleBackColor = true;
            this.btnUndoBump.Click += new System.EventHandler(this.btnUndoBump_Click);
            // 
            // topPanel
            // 
            this.topPanel.Controls.Add(this.button2);
            this.topPanel.Controls.Add(this.button1);
            this.topPanel.Controls.Add(this.label1);
            this.topPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topPanel.Location = new System.Drawing.Point(0, 0);
            this.topPanel.Name = "topPanel";
            this.topPanel.Size = new System.Drawing.Size(754, 30);
            this.topPanel.TabIndex = 13;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(700, 0);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(27, 30);
            this.button2.TabIndex = 2;
            this.button2.Text = "-";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(727, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(27, 30);
            this.button1.TabIndex = 1;
            this.button1.Text = "X";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label1.Location = new System.Drawing.Point(8, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Plutus";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(14)))), ((int)(((byte)(15)))));
            this.ClientSize = new System.Drawing.Size(754, 474);
            this.Controls.Add(this.topPanel);
            this.Controls.Add(this.btnUndoBump);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.lblNetProfit);
            this.Controls.Add(this.lblTotalBumps);
            this.Controls.Add(this.lblGrossProfit);
            this.Controls.Add(this.gridItems);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.txtBumps);
            this.Controls.Add(this.txtShipping);
            this.Controls.Add(this.txtFees);
            this.Controls.Add(this.txtSell);
            this.Controls.Add(this.txtBuy);
            this.Controls.Add(this.txtName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridItems)).EndInit();
            this.topPanel.ResumeLayout(false);
            this.topPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtBuy;
        private System.Windows.Forms.TextBox txtSell;
        private System.Windows.Forms.TextBox txtFees;
        private System.Windows.Forms.TextBox txtShipping;
        private System.Windows.Forms.TextBox txtBumps;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.DataGridView gridItems;
        private System.Windows.Forms.Label lblGrossProfit;
        private System.Windows.Forms.Label lblTotalBumps;
        private System.Windows.Forms.Label lblNetProfit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnUndoBump;
        private System.Windows.Forms.Panel topPanel;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
    }
}