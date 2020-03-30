namespace ParkingManager.Presentation.Features.Payments
{
    partial class PaymentDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PaymentDialog));
            this.btnInput = new System.Windows.Forms.Button();
            this.btnToExit = new System.Windows.Forms.Button();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbAddPrice = new System.Windows.Forms.ToolStripButton();
            this.dgvPayment = new System.Windows.Forms.DataGridView();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPayment)).BeginInit();
            this.SuspendLayout();
            // 
            // btnInput
            // 
            this.btnInput.Location = new System.Drawing.Point(226, 68);
            this.btnInput.Name = "btnInput";
            this.btnInput.Size = new System.Drawing.Size(122, 23);
            this.btnInput.TabIndex = 0;
            this.btnInput.Text = "Entrada veículo";
            this.btnInput.UseVisualStyleBackColor = true;
            this.btnInput.Click += new System.EventHandler(this.btnInput_Click);
            // 
            // btnToExit
            // 
            this.btnToExit.Location = new System.Drawing.Point(354, 68);
            this.btnToExit.Name = "btnToExit";
            this.btnToExit.Size = new System.Drawing.Size(130, 23);
            this.btnToExit.TabIndex = 1;
            this.btnToExit.Text = "Saída veículo";
            this.btnToExit.UseVisualStyleBackColor = true;
            this.btnToExit.Click += new System.EventHandler(this.btnToExit_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbAddPrice});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(800, 25);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbAddPrice
            // 
            this.tsbAddPrice.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbAddPrice.Image = ((System.Drawing.Image)(resources.GetObject("tsbAddPrice.Image")));
            this.tsbAddPrice.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbAddPrice.Name = "tsbAddPrice";
            this.tsbAddPrice.Size = new System.Drawing.Size(95, 22);
            this.tsbAddPrice.Text = "Adicionar preço";
            this.tsbAddPrice.Click += new System.EventHandler(this.tsbAddPrice_Click);
            // 
            // dgvPayment
            // 
            this.dgvPayment.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPayment.Location = new System.Drawing.Point(30, 114);
            this.dgvPayment.Name = "dgvPayment";
            this.dgvPayment.Size = new System.Drawing.Size(735, 199);
            this.dgvPayment.TabIndex = 3;
            this.dgvPayment.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPayment_CellContentClick);
            // 
            // PaymentDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 337);
            this.Controls.Add(this.dgvPayment);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.btnToExit);
            this.Controls.Add(this.btnInput);
            this.Name = "PaymentDialog";
            this.Text = "PaymentDialog";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPayment)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnInput;
        private System.Windows.Forms.Button btnToExit;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbAddPrice;
        private System.Windows.Forms.DataGridView dgvPayment;
    }
}