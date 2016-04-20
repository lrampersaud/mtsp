namespace mTSP
{
    partial class frmMain
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
            this.btnStartStop = new System.Windows.Forms.Button();
            this.pnlOptions = new System.Windows.Forms.Panel();
            this.pnlCanvas = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPopulationSize = new System.Windows.Forms.TextBox();
            this.txtMutationProbability = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtGenerationCount = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCities = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSalesmen = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDelay = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.pnlOptions.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnStartStop
            // 
            this.btnStartStop.Location = new System.Drawing.Point(41, 414);
            this.btnStartStop.Name = "btnStartStop";
            this.btnStartStop.Size = new System.Drawing.Size(75, 23);
            this.btnStartStop.TabIndex = 0;
            this.btnStartStop.Text = "Start";
            this.btnStartStop.UseVisualStyleBackColor = true;
            this.btnStartStop.Click += new System.EventHandler(this.btnStartStop_Click);
            // 
            // pnlOptions
            // 
            this.pnlOptions.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlOptions.Controls.Add(this.label7);
            this.pnlOptions.Controls.Add(this.txtDelay);
            this.pnlOptions.Controls.Add(this.label6);
            this.pnlOptions.Controls.Add(this.txtSalesmen);
            this.pnlOptions.Controls.Add(this.label5);
            this.pnlOptions.Controls.Add(this.txtCities);
            this.pnlOptions.Controls.Add(this.label4);
            this.pnlOptions.Controls.Add(this.txtGenerationCount);
            this.pnlOptions.Controls.Add(this.label3);
            this.pnlOptions.Controls.Add(this.btnStartStop);
            this.pnlOptions.Controls.Add(this.txtMutationProbability);
            this.pnlOptions.Controls.Add(this.label2);
            this.pnlOptions.Controls.Add(this.txtPopulationSize);
            this.pnlOptions.Controls.Add(this.label1);
            this.pnlOptions.Location = new System.Drawing.Point(466, 12);
            this.pnlOptions.Name = "pnlOptions";
            this.pnlOptions.Size = new System.Drawing.Size(150, 455);
            this.pnlOptions.TabIndex = 1;
            // 
            // pnlCanvas
            // 
            this.pnlCanvas.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.pnlCanvas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCanvas.Location = new System.Drawing.Point(16, 12);
            this.pnlCanvas.Name = "pnlCanvas";
            this.pnlCanvas.Size = new System.Drawing.Size(439, 455);
            this.pnlCanvas.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Population Size";
            // 
            // txtPopulationSize
            // 
            this.txtPopulationSize.Location = new System.Drawing.Point(6, 30);
            this.txtPopulationSize.Name = "txtPopulationSize";
            this.txtPopulationSize.Size = new System.Drawing.Size(141, 20);
            this.txtPopulationSize.TabIndex = 1;
            this.txtPopulationSize.Text = "100";
            // 
            // txtMutationProbability
            // 
            this.txtMutationProbability.Location = new System.Drawing.Point(6, 92);
            this.txtMutationProbability.Name = "txtMutationProbability";
            this.txtMutationProbability.Size = new System.Drawing.Size(141, 20);
            this.txtMutationProbability.TabIndex = 3;
            this.txtMutationProbability.Text = "0.002";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Mutation Probability";
            // 
            // txtGenerationCount
            // 
            this.txtGenerationCount.Location = new System.Drawing.Point(3, 160);
            this.txtGenerationCount.Name = "txtGenerationCount";
            this.txtGenerationCount.Size = new System.Drawing.Size(141, 20);
            this.txtGenerationCount.TabIndex = 5;
            this.txtGenerationCount.Text = "100";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(0, 144);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Generation Count";
            // 
            // txtCities
            // 
            this.txtCities.Location = new System.Drawing.Point(6, 225);
            this.txtCities.Name = "txtCities";
            this.txtCities.Size = new System.Drawing.Size(141, 20);
            this.txtCities.TabIndex = 7;
            this.txtCities.Text = "125";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 209);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Cities";
            // 
            // txtSalesmen
            // 
            this.txtSalesmen.Location = new System.Drawing.Point(6, 287);
            this.txtSalesmen.Name = "txtSalesmen";
            this.txtSalesmen.Size = new System.Drawing.Size(141, 20);
            this.txtSalesmen.TabIndex = 9;
            this.txtSalesmen.Text = "5";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 271);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Salesmen";
            // 
            // txtDelay
            // 
            this.txtDelay.Location = new System.Drawing.Point(6, 353);
            this.txtDelay.Name = "txtDelay";
            this.txtDelay.Size = new System.Drawing.Size(69, 20);
            this.txtDelay.TabIndex = 11;
            this.txtDelay.Text = "500";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 337);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(34, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Delay";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(81, 356);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(66, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "milli seconds";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(623, 475);
            this.Controls.Add(this.pnlCanvas);
            this.Controls.Add(this.pnlOptions);
            this.Name = "frmMain";
            this.Text = "mTSP";
            this.pnlOptions.ResumeLayout(false);
            this.pnlOptions.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnStartStop;
        private System.Windows.Forms.Panel pnlOptions;
        private System.Windows.Forms.TextBox txtGenerationCount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtMutationProbability;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPopulationSize;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnlCanvas;
        private System.Windows.Forms.TextBox txtSalesmen;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtCities;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtDelay;
        private System.Windows.Forms.Label label6;
    }
}

