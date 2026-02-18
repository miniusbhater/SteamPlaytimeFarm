namespace SteamPlaytimeFarmLauncher
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            textBox1 = new TextBox();
            label1 = new Label();
            button1 = new Button();
            button2 = new Button();
            listBoxGames = new ListBox();
            label2 = new Label();
            button3 = new Button();
            label3 = new Label();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Location = new Point(128, 16);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(122, 23);
            textBox1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(12, 14);
            label1.Name = "label1";
            label1.Size = new Size(110, 21);
            label1.TabIndex = 1;
            label1.Text = "Enter an appid";
            // 
            // button1
            // 
            button1.Location = new Point(256, 16);
            button1.Name = "button1";
            button1.Size = new Size(65, 23);
            button1.TabIndex = 2;
            button1.Text = "SteamDB";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button2.Location = new Point(12, 57);
            button2.Name = "button2";
            button2.Size = new Size(309, 57);
            button2.TabIndex = 3;
            button2.Text = "Start idling";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // listBoxGames
            // 
            listBoxGames.FormattingEnabled = true;
            listBoxGames.Location = new Point(12, 168);
            listBoxGames.Name = "listBoxGames";
            listBoxGames.Size = new Size(309, 259);
            listBoxGames.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(12, 144);
            label2.Name = "label2";
            label2.Size = new Size(121, 21);
            label2.TabIndex = 5;
            label2.Text = "Currently idling:";
            // 
            // button3
            // 
            button3.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button3.Location = new Point(12, 433);
            button3.Name = "button3";
            button3.Size = new Size(309, 31);
            button3.TabIndex = 6;
            button3.Text = "Stop idling";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(12, 467);
            label3.Name = "label3";
            label3.Size = new Size(31, 13);
            label3.TabIndex = 7;
            label3.Text = "1.0.0";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(333, 484);
            Controls.Add(label3);
            Controls.Add(button3);
            Controls.Add(label2);
            Controls.Add(listBoxGames);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label1);
            Controls.Add(textBox1);
            Name = "Form1";
            Text = "SteamPlaytimeFarm";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private Label label1;
        private Button button1;
        private Button button2;
        private ListBox listBoxGames;
        private Label label2;
        private Button button3;
        private Label label3;
    }
}
