namespace RobotWars.Forms
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.command2 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.command1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.outputs = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.arenaHeight = new System.Windows.Forms.TextBox();
            this.arenaWidth = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.arenaDisplay = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // command2
            // 
            this.command2.Location = new System.Drawing.Point(687, 40);
            this.command2.Name = "command2";
            this.command2.Size = new System.Drawing.Size(375, 20);
            this.command2.TabIndex = 7;
            this.command2.Text = "R";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(1068, 37);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(103, 23);
            this.button2.TabIndex = 9;
            this.button2.Text = "Send commands";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // command1
            // 
            this.command1.Location = new System.Drawing.Point(306, 40);
            this.command1.Name = "command1";
            this.command1.Size = new System.Drawing.Size(375, 20);
            this.command1.TabIndex = 8;
            this.command1.Text = "3 3 N";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(303, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Robot init command";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(684, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(114, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Robot move command";
            // 
            // outputs
            // 
            this.outputs.Location = new System.Drawing.Point(749, 86);
            this.outputs.Multiline = true;
            this.outputs.Name = "outputs";
            this.outputs.Size = new System.Drawing.Size(473, 653);
            this.outputs.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(749, 70);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Output";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Arena height";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Arena width";
            // 
            // arenaHeight
            // 
            this.arenaHeight.Location = new System.Drawing.Point(85, 6);
            this.arenaHeight.Name = "arenaHeight";
            this.arenaHeight.Size = new System.Drawing.Size(100, 20);
            this.arenaHeight.TabIndex = 16;
            this.arenaHeight.Text = "5";
            this.arenaHeight.TextChanged += new System.EventHandler(this.arenaHeight_TextChanged);
            // 
            // arenaWidth
            // 
            this.arenaWidth.Location = new System.Drawing.Point(85, 32);
            this.arenaWidth.Name = "arenaWidth";
            this.arenaWidth.Size = new System.Drawing.Size(100, 20);
            this.arenaWidth.TabIndex = 17;
            this.arenaWidth.Text = "5";
            this.arenaWidth.TextChanged += new System.EventHandler(this.arenaWidth_TextChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(191, 6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 46);
            this.button1.TabIndex = 18;
            this.button1.Text = "Reset arena";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // arenaDisplay
            // 
            this.arenaDisplay.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.arenaDisplay.Location = new System.Drawing.Point(19, 86);
            this.arenaDisplay.Name = "arenaDisplay";
            this.arenaDisplay.Size = new System.Drawing.Size(724, 653);
            this.arenaDisplay.TabIndex = 19;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1234, 751);
            this.Controls.Add(this.arenaDisplay);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.arenaWidth);
            this.Controls.Add(this.arenaHeight);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.outputs);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.command1);
            this.Controls.Add(this.command2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox command2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox command1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox outputs;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox arenaHeight;
        private System.Windows.Forms.TextBox arenaWidth;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel arenaDisplay;
    }
}

