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
            this.txtSearchVehicle = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSearchVehicle = new System.Windows.Forms.Button();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPayment)).BeginInit();
            this.SuspendLayout();
            // 
            // btnInput
            // 
            this.btnInput.Location = new System.Drawing.Point(509, 70);
            this.btnInput.Name = "btnInput";
            this.btnInput.Size = new System.Drawing.Size(122, 23);
            this.btnInput.TabIndex = 0;
            this.btnInput.Text = "Entrada veículo";
            this.btnInput.UseVisualStyleBackColor = true;
            this.btnInput.Click += new System.EventHandler(this.btnInput_Click);
            // 
            // btnToExit
            // 
            this.btnToExit.Enabled = false;
            this.btnToExit.Location = new System.Drawing.Point(637, 70);
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
            // txtSearchVehicle
            // 
            this.txtSearchVehicle.Location = new System.Drawing.Point(30, 70);
            this.txtSearchVehicle.Name = "txtSearchVehicle";
            this.txtSearchVehicle.Size = new System.Drawing.Size(157, 20);
            this.txtSearchVehicle.TabIndex = 4;
            this.txtSearchVehicle.TextChanged += new System.EventHandler(this.txtSearchVehicle_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Pesquisar pela placa:";
            // 
            // btnSearchVehicle
            // 
            this.btnSearchVehicle.Enabled = false;
            this.btnSearchVehicle.Location = new System.Drawing.Point(193, 70);
            this.btnSearchVehicle.Name = "btnSearchVehicle";
            this.btnSearchVehicle.Size = new System.Drawing.Size(122, 23);
            this.btnSearchVehicle.TabIndex = 6;
            this.btnSearchVehicle.Text = "Buscar veículo";
            this.btnSearchVehicle.UseVisualStyleBackColor = true;
            this.btnSearchVehicle.Click += new System.EventHandler(this.btnSearchVehicle_Click);
            // 
            // PaymentDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 337);
            this.Controls.Add(this.btnSearchVehicle);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtSearchVehicle);
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
        private System.Windows.Forms.TextBox txtSearchVehicle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSearchVehicle;
    }
}