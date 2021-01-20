using System.Drawing;

namespace new_Game
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.StartWaveButton = new System.Windows.Forms.Button();
            this.ExitButton = new System.Windows.Forms.Button();
            this.PlayerControl_Panel = new System.Windows.Forms.Panel();
            this.BuildOptions_Panel = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.ControlMode_label = new System.Windows.Forms.Label();
            this.MenuPanel = new System.Windows.Forms.Panel();
            this.Records_panel = new System.Windows.Forms.Panel();
            this.RemoveRecords = new System.Windows.Forms.Button();
            this.CloseRecords = new System.Windows.Forms.Button();
            this.Records_ListBox = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.ShowRecordsButton = new System.Windows.Forms.Button();
            this.StartGameButton = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.PlayerControl_Panel.SuspendLayout();
            this.BuildOptions_Panel.SuspendLayout();
            this.MenuPanel.SuspendLayout();
            this.Records_panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // StartWaveButton
            // 
            this.StartWaveButton.Location = new System.Drawing.Point(595, 12);
            this.StartWaveButton.Name = "StartWaveButton";
            this.StartWaveButton.Size = new System.Drawing.Size(121, 61);
            this.StartWaveButton.TabIndex = 0;
            this.StartWaveButton.Text = "Ready";
            this.StartWaveButton.UseVisualStyleBackColor = true;
            this.StartWaveButton.Click += new System.EventHandler(this.StartWaveButton_Click);
            // 
            // ExitButton
            // 
            this.ExitButton.Location = new System.Drawing.Point(740, 12);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(121, 61);
            this.ExitButton.TabIndex = 4;
            this.ExitButton.Text = "Exit";
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // PlayerControl_Panel
            // 
            this.PlayerControl_Panel.BackColor = System.Drawing.Color.LightYellow;
            this.PlayerControl_Panel.Controls.Add(this.BuildOptions_Panel);
            this.PlayerControl_Panel.Controls.Add(this.ControlMode_label);
            this.PlayerControl_Panel.Location = new System.Drawing.Point(603, 324);
            this.PlayerControl_Panel.Name = "PlayerControl_Panel";
            this.PlayerControl_Panel.Size = new System.Drawing.Size(257, 242);
            this.PlayerControl_Panel.TabIndex = 5;
            // 
            // BuildOptions_Panel
            // 
            this.BuildOptions_Panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.BuildOptions_Panel.Controls.Add(this.label3);
            this.BuildOptions_Panel.Controls.Add(this.label2);
            this.BuildOptions_Panel.Controls.Add(this.label1);
            this.BuildOptions_Panel.Controls.Add(this.button3);
            this.BuildOptions_Panel.Controls.Add(this.button2);
            this.BuildOptions_Panel.Controls.Add(this.button1);
            this.BuildOptions_Panel.Location = new System.Drawing.Point(11, 61);
            this.BuildOptions_Panel.Name = "BuildOptions_Panel";
            this.BuildOptions_Panel.Size = new System.Drawing.Size(231, 147);
            this.BuildOptions_Panel.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(152, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 21);
            this.label3.TabIndex = 5;
            this.label3.Text = "AntiAirTower";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(83, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 31);
            this.label2.TabIndex = 4;
            this.label2.Text = "FocusTower";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(14, 85);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 33);
            this.label1.TabIndex = 3;
            this.label1.Text = "BaseTower";
            // 
            // button3
            // 
            this.button3.Image = ((System.Drawing.Image) (resources.GetObject("button3.Image")));
            this.button3.Location = new System.Drawing.Point(152, 30);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(63, 51);
            this.button3.TabIndex = 2;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Image = ((System.Drawing.Image) (resources.GetObject("button2.Image")));
            this.button2.Location = new System.Drawing.Point(83, 30);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(63, 51);
            this.button2.TabIndex = 1;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Image = ((System.Drawing.Image) (resources.GetObject("button1.Image")));
            this.button1.Location = new System.Drawing.Point(14, 30);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(63, 51);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ControlMode_label
            // 
            this.ControlMode_label.Location = new System.Drawing.Point(26, 19);
            this.ControlMode_label.Name = "ControlMode_label";
            this.ControlMode_label.Size = new System.Drawing.Size(195, 39);
            this.ControlMode_label.TabIndex = 0;
            this.ControlMode_label.Text = "Build Mode";
            // 
            // MenuPanel
            // 
            this.MenuPanel.AutoSize = true;
            this.MenuPanel.BackColor = System.Drawing.SystemColors.Control;
            this.MenuPanel.BackgroundImage = ((System.Drawing.Image) (resources.GetObject("MenuPanel.BackgroundImage")));
            this.MenuPanel.Controls.Add(this.Records_panel);
            this.MenuPanel.Controls.Add(this.label4);
            this.MenuPanel.Controls.Add(this.ShowRecordsButton);
            this.MenuPanel.Controls.Add(this.StartGameButton);
            this.MenuPanel.Controls.Add(this.textBox1);
            this.MenuPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MenuPanel.Location = new System.Drawing.Point(0, 0);
            this.MenuPanel.Name = "MenuPanel";
            this.MenuPanel.Size = new System.Drawing.Size(949, 592);
            this.MenuPanel.TabIndex = 6;
            // 
            // Records_panel
            // 
            this.Records_panel.Controls.Add(this.RemoveRecords);
            this.Records_panel.Controls.Add(this.CloseRecords);
            this.Records_panel.Controls.Add(this.Records_ListBox);
            this.Records_panel.Location = new System.Drawing.Point(115, 79);
            this.Records_panel.Name = "Records_panel";
            this.Records_panel.Size = new System.Drawing.Size(726, 460);
            this.Records_panel.TabIndex = 7;
            this.Records_panel.Visible = false;
            // 
            // RemoveRecords
            // 
            this.RemoveRecords.Location = new System.Drawing.Point(367, 368);
            this.RemoveRecords.Name = "RemoveRecords";
            this.RemoveRecords.Size = new System.Drawing.Size(176, 60);
            this.RemoveRecords.TabIndex = 2;
            this.RemoveRecords.Text = "Remove";
            this.RemoveRecords.UseVisualStyleBackColor = true;
            this.RemoveRecords.Click += new System.EventHandler(this.RemoveRecords_button_Click);
            // 
            // CloseRecords
            // 
            this.CloseRecords.Location = new System.Drawing.Point(185, 368);
            this.CloseRecords.Name = "CloseRecords";
            this.CloseRecords.Size = new System.Drawing.Size(176, 60);
            this.CloseRecords.TabIndex = 1;
            this.CloseRecords.Text = "Close";
            this.CloseRecords.UseVisualStyleBackColor = true;
            this.CloseRecords.Click += new System.EventHandler(this.CloseRecords_button_Click);
            // 
            // Records_ListBox
            // 
            this.Records_ListBox.BackColor = System.Drawing.SystemColors.Info;
            this.Records_ListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (204)));
            this.Records_ListBox.ForeColor = System.Drawing.Color.SlateBlue;
            this.Records_ListBox.FormattingEnabled = true;
            this.Records_ListBox.ItemHeight = 18;
            this.Records_ListBox.Location = new System.Drawing.Point(140, 55);
            this.Records_ListBox.Name = "Records_ListBox";
            this.Records_ListBox.Size = new System.Drawing.Size(436, 256);
            this.Records_ListBox.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Aquamarine;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (204)));
            this.label4.Location = new System.Drawing.Point(377, 242);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(161, 59);
            this.label4.TabIndex = 6;
            this.label4.Text = "Menu";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ShowRecordsButton
            // 
            this.ShowRecordsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (204)));
            this.ShowRecordsButton.Location = new System.Drawing.Point(359, 441);
            this.ShowRecordsButton.Name = "ShowRecordsButton";
            this.ShowRecordsButton.Size = new System.Drawing.Size(199, 41);
            this.ShowRecordsButton.TabIndex = 5;
            this.ShowRecordsButton.Text = "Records";
            this.ShowRecordsButton.UseVisualStyleBackColor = true;
            this.ShowRecordsButton.Click += new System.EventHandler(this.ShowRecordsButton_Click);
            // 
            // StartGameButton
            // 
            this.StartGameButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (204)));
            this.StartGameButton.Location = new System.Drawing.Point(359, 323);
            this.StartGameButton.Name = "StartGameButton";
            this.StartGameButton.Size = new System.Drawing.Size(199, 112);
            this.StartGameButton.TabIndex = 4;
            this.StartGameButton.Text = "Start Game";
            this.StartGameButton.UseVisualStyleBackColor = true;
            this.StartGameButton.Click += new System.EventHandler(this.StartGameButton_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(28, 16);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(156, 20);
            this.textBox1.TabIndex = 3;
            this.textBox1.Text = "User";
            this.textBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer) (resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "AirPlane.png");
            this.imageList1.Images.SetKeyName(1, "Boy.png");
            this.imageList1.Images.SetKeyName(2, "FastBoy.png");
            this.imageList1.Images.SetKeyName(3, "MegaBoy.png");
            this.imageList1.Images.SetKeyName(4, "AntiAir_tower.png");
            this.imageList1.Images.SetKeyName(5, "bitBullet.png");
            this.imageList1.Images.SetKeyName(6, "focus_tower.png");
            this.imageList1.Images.SetKeyName(7, "lazer_gun1.png");
            this.imageList1.Images.SetKeyName(8, "Rocket.png");
            this.imageList1.Images.SetKeyName(9, "SmallBullet.png");
            this.imageList1.Images.SetKeyName(10, "towerDefense_tile203.png");
            this.imageList1.Images.SetKeyName(11, "towerDefense_tile204.png");
            this.imageList1.Images.SetKeyName(12, "towerDefense_tile250.png");
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Blue;
            this.ClientSize = new System.Drawing.Size(949, 592);
            this.Controls.Add(this.MenuPanel);
            this.Controls.Add(this.PlayerControl_Panel);
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.StartWaveButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.Location = new System.Drawing.Point(15, 15);
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Click += new System.EventHandler(this.Form1_Click);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseClick);
            this.PlayerControl_Panel.ResumeLayout(false);
            this.BuildOptions_Panel.ResumeLayout(false);
            this.MenuPanel.ResumeLayout(false);
            this.MenuPanel.PerformLayout();
            this.Records_panel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Panel BuildOptions_Panel;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button CloseRecords;
        private System.Windows.Forms.Label ControlMode_label;
        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel MenuPanel;
        private System.Windows.Forms.Panel PlayerControl_Panel;
        private System.Windows.Forms.ListBox Records_ListBox;
        private System.Windows.Forms.Panel Records_panel;
        private System.Windows.Forms.Button RemoveRecords;
        private System.Windows.Forms.Button ShowRecordsButton;
        private System.Windows.Forms.Button StartGameButton;
        private System.Windows.Forms.Button StartWaveButton;
        private System.Windows.Forms.TextBox textBox1;

        #endregion
    }
}