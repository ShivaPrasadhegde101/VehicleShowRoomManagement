namespace VehicalShowroomManagement
{
    partial class user
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
            this.button_WOC3 = new ePOSOne.btnProduct.Button_WOC();
            this.button_WOC2 = new ePOSOne.btnProduct.Button_WOC();
            this.button_WOC1 = new ePOSOne.btnProduct.Button_WOC();
            this.SuspendLayout();
            // 
            // button_WOC3
            // 
            this.button_WOC3.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.button_WOC3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button_WOC3.BorderColor = System.Drawing.Color.White;
            this.button_WOC3.ButtonColor = System.Drawing.Color.Gray;
            this.button_WOC3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_WOC3.Font = new System.Drawing.Font("Cooper Black", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_WOC3.Location = new System.Drawing.Point(598, 527);
            this.button_WOC3.Name = "button_WOC3";
            this.button_WOC3.OnHoverBorderColor = System.Drawing.Color.Gray;
            this.button_WOC3.OnHoverButtonColor = System.Drawing.Color.DimGray;
            this.button_WOC3.OnHoverTextColor = System.Drawing.Color.Gray;
            this.button_WOC3.Size = new System.Drawing.Size(208, 60);
            this.button_WOC3.TabIndex = 2;
            this.button_WOC3.Text = "<-Back";
            this.button_WOC3.TextColor = System.Drawing.Color.White;
            this.button_WOC3.UseVisualStyleBackColor = false;
            this.button_WOC3.Click += new System.EventHandler(this.button_WOC3_Click);
            // 
            // button_WOC2
            // 
            this.button_WOC2.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.button_WOC2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button_WOC2.BorderColor = System.Drawing.Color.White;
            this.button_WOC2.ButtonColor = System.Drawing.Color.Gray;
            this.button_WOC2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_WOC2.Font = new System.Drawing.Font("Cooper Black", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_WOC2.Location = new System.Drawing.Point(598, 369);
            this.button_WOC2.Name = "button_WOC2";
            this.button_WOC2.OnHoverBorderColor = System.Drawing.Color.Gray;
            this.button_WOC2.OnHoverButtonColor = System.Drawing.Color.DimGray;
            this.button_WOC2.OnHoverTextColor = System.Drawing.Color.Gray;
            this.button_WOC2.Size = new System.Drawing.Size(208, 60);
            this.button_WOC2.TabIndex = 1;
            this.button_WOC2.Text = "Log-In";
            this.button_WOC2.TextColor = System.Drawing.Color.White;
            this.button_WOC2.UseVisualStyleBackColor = false;
            this.button_WOC2.Click += new System.EventHandler(this.button_WOC2_Click);
            // 
            // button_WOC1
            // 
            this.button_WOC1.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.button_WOC1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button_WOC1.BorderColor = System.Drawing.Color.White;
            this.button_WOC1.ButtonColor = System.Drawing.Color.Gray;
            this.button_WOC1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_WOC1.Font = new System.Drawing.Font("Cooper Black", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_WOC1.Location = new System.Drawing.Point(598, 207);
            this.button_WOC1.Name = "button_WOC1";
            this.button_WOC1.OnHoverBorderColor = System.Drawing.Color.Gray;
            this.button_WOC1.OnHoverButtonColor = System.Drawing.Color.DimGray;
            this.button_WOC1.OnHoverTextColor = System.Drawing.Color.Gray;
            this.button_WOC1.Size = new System.Drawing.Size(208, 60);
            this.button_WOC1.TabIndex = 0;
            this.button_WOC1.Text = "Sign-Up";
            this.button_WOC1.TextColor = System.Drawing.Color.White;
            this.button_WOC1.UseVisualStyleBackColor = false;
            this.button_WOC1.Click += new System.EventHandler(this.button_WOC1_Click);
            // 
            // user
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::VehicalShowroomManagement.Properties.Resources.userpage;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1077, 631);
            this.Controls.Add(this.button_WOC3);
            this.Controls.Add(this.button_WOC2);
            this.Controls.Add(this.button_WOC1);
            this.Name = "user";
            this.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultBounds;
            this.Text = "user";
            this.TopMost = true;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

        }

        #endregion

        private ePOSOne.btnProduct.Button_WOC button_WOC1;
        private ePOSOne.btnProduct.Button_WOC button_WOC2;
        private ePOSOne.btnProduct.Button_WOC button_WOC3;
    }
}