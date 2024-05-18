namespace Pos點餐
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.priceLab = new System.Windows.Forms.Label();
            this.container = new System.Windows.Forms.FlowLayoutPanel();
            this.recordContainer = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(547, 566);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "總金額";
            // 
            // priceLab
            // 
            this.priceLab.AutoSize = true;
            this.priceLab.Location = new System.Drawing.Point(613, 566);
            this.priceLab.Name = "priceLab";
            this.priceLab.Size = new System.Drawing.Size(11, 12);
            this.priceLab.TabIndex = 3;
            this.priceLab.Text = "0";
            // 
            // container
            // 
            this.container.Location = new System.Drawing.Point(6, 5);
            this.container.Name = "container";
            this.container.Size = new System.Drawing.Size(415, 595);
            this.container.TabIndex = 16;
            // 
            // recordContainer
            // 
            this.recordContainer.Location = new System.Drawing.Point(429, 5);
            this.recordContainer.Name = "recordContainer";
            this.recordContainer.Size = new System.Drawing.Size(400, 527);
            this.recordContainer.TabIndex = 17;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(832, 601);
            this.Controls.Add(this.recordContainer);
            this.Controls.Add(this.container);
            this.Controls.Add(this.priceLab);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label priceLab;
        private System.Windows.Forms.FlowLayoutPanel container;
        private System.Windows.Forms.FlowLayoutPanel recordContainer;
    }
}

