
namespace _2
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.generateButton = new System.Windows.Forms.Button();
            this.clearButton = new System.Windows.Forms.Button();
            this.randomButton = new System.Windows.Forms.Button();
            this.multiThreadCheckBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(687, 450);
            this.panel1.TabIndex = 0;
            // 
            // generateButton
            // 
            this.generateButton.Location = new System.Drawing.Point(693, 12);
            this.generateButton.Name = "generateButton";
            this.generateButton.Size = new System.Drawing.Size(112, 53);
            this.generateButton.TabIndex = 0;
            this.generateButton.Text = "Створити";
            this.generateButton.UseVisualStyleBackColor = true;
            this.generateButton.Click += new System.EventHandler(this.generateButton_Click);
            // 
            // clearButton
            // 
            this.clearButton.Location = new System.Drawing.Point(693, 89);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(112, 53);
            this.clearButton.TabIndex = 1;
            this.clearButton.Text = "Очистити";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // randomButton
            // 
            this.randomButton.Location = new System.Drawing.Point(693, 166);
            this.randomButton.Name = "randomButton";
            this.randomButton.Size = new System.Drawing.Size(112, 53);
            this.randomButton.TabIndex = 2;
            this.randomButton.Text = "Випадкова генерація";
            this.randomButton.UseVisualStyleBackColor = true;
            this.randomButton.Click += new System.EventHandler(this.randomButton_Click);
            // 
            // multiThreadCheckBox
            // 
            this.multiThreadCheckBox.AutoSize = true;
            this.multiThreadCheckBox.Location = new System.Drawing.Point(697, 249);
            this.multiThreadCheckBox.Name = "multiThreadCheckBox";
            this.multiThreadCheckBox.Size = new System.Drawing.Size(105, 21);
            this.multiThreadCheckBox.TabIndex = 3;
            this.multiThreadCheckBox.Text = "multiThread";
            this.multiThreadCheckBox.UseVisualStyleBackColor = true;
            this.multiThreadCheckBox.CheckedChanged += new System.EventHandler(this.multiThreadCheckBox_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(812, 450);
            this.Controls.Add(this.multiThreadCheckBox);
            this.Controls.Add(this.randomButton);
            this.Controls.Add(this.clearButton);
            this.Controls.Add(this.generateButton);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button generateButton;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.Button randomButton;
        private System.Windows.Forms.CheckBox multiThreadCheckBox;
    }
}

