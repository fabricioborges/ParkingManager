namespace ParkingManager.Presentation.Features.Managers
{
    partial class Manager
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
            this.btnToVehicle = new System.Windows.Forms.Button();
            this.btnToPrice = new System.Windows.Forms.Button();
            this.dGManager = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dGManager)).BeginInit();
            this.SuspendLayout();
            // 
            // btnToVehicle
            // 
            this.btnToVehicle.Location = new System.Drawing.Point(260, 53);
            this.btnToVehicle.Name = "btnToVehicle";
            this.btnToVehicle.Size = new System.Drawing.Size(112, 23);
            this.btnToVehicle.TabIndex = 0;
            this.btnToVehicle.Text = "Entrada veículo";
            this.btnToVehicle.UseVisualStyleBackColor = true;
            this.btnToVehicle.Click += new System.EventHandler(this.btnToVehicle_Click);
            // 
            // btnToPrice
            // 
            this.btnToPrice.Location = new System.Drawing.Point(378, 53);
            this.btnToPrice.Name = "btnToPrice";
            this.btnToPrice.Size = new System.Drawing.Size(126, 23);
            this.btnToPrice.TabIndex = 1;
            this.btnToPrice.Text = "Cadastrar valor R$";
            this.btnToPrice.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnToPrice.UseVisualStyleBackColor = true;
            this.btnToPrice.Click += new System.EventHandler(this.btnToPrice_Click);
            // 
            // dGManager
            // 
            this.dGManager.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGManager.Location = new System.Drawing.Point(31, 117);
            this.dGManager.Name = "dGManager";
            this.dGManager.Size = new System.Drawing.Size(745, 214);
            this.dGManager.TabIndex = 2;
            // 
            // Manager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dGManager);
            this.Controls.Add(this.btnToPrice);
            this.Controls.Add(this.btnToVehicle);
            this.Name = "Manager";
            this.Text = "Manager";
            ((System.ComponentModel.ISupportInitialize)(this.dGManager)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnToVehicle;
        private System.Windows.Forms.Button btnToPrice;
        private System.Windows.Forms.DataGridView dGManager;
    }
}