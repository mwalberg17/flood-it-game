namespace Flood_It_Game
{
    partial class UserInterface
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
            this.uxNewGame = new System.Windows.Forms.Button();
            this.uxBoard = new System.Windows.Forms.FlowLayoutPanel();
            this.uxSizeLabel = new System.Windows.Forms.Label();
            this.uxColorLabel = new System.Windows.Forms.Label();
            this.uxStatusStrip = new System.Windows.Forms.StatusStrip();
            this.uxTurns = new System.Windows.Forms.ToolStripStatusLabel();
            this.uxSizeList = new System.Windows.Forms.ComboBox();
            this.uxColorList = new System.Windows.Forms.ComboBox();
            this.uxStatusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // uxNewGame
            // 
            this.uxNewGame.Location = new System.Drawing.Point(480, 9);
            this.uxNewGame.Name = "uxNewGame";
            this.uxNewGame.Size = new System.Drawing.Size(103, 28);
            this.uxNewGame.TabIndex = 0;
            this.uxNewGame.Text = "New Game";
            this.uxNewGame.UseVisualStyleBackColor = true;
            this.uxNewGame.Click += new System.EventHandler(this.uxNewGame_Click);
            // 
            // uxBoard
            // 
            this.uxBoard.Location = new System.Drawing.Point(16, 55);
            this.uxBoard.Name = "uxBoard";
            this.uxBoard.Size = new System.Drawing.Size(567, 389);
            this.uxBoard.TabIndex = 1;
            // 
            // uxSizeLabel
            // 
            this.uxSizeLabel.AutoSize = true;
            this.uxSizeLabel.Location = new System.Drawing.Point(12, 12);
            this.uxSizeLabel.Name = "uxSizeLabel";
            this.uxSizeLabel.Size = new System.Drawing.Size(109, 20);
            this.uxSizeLabel.TabIndex = 3;
            this.uxSizeLabel.Text = "Size of Board:";
            // 
            // uxColorLabel
            // 
            this.uxColorLabel.AutoSize = true;
            this.uxColorLabel.Location = new System.Drawing.Point(270, 12);
            this.uxColorLabel.Name = "uxColorLabel";
            this.uxColorLabel.Size = new System.Drawing.Size(136, 20);
            this.uxColorLabel.TabIndex = 4;
            this.uxColorLabel.Text = "Number of Colors:";
            // 
            // uxStatusStrip
            // 
            this.uxStatusStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.uxStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.uxTurns});
            this.uxStatusStrip.Location = new System.Drawing.Point(0, 461);
            this.uxStatusStrip.Name = "uxStatusStrip";
            this.uxStatusStrip.Size = new System.Drawing.Size(595, 30);
            this.uxStatusStrip.TabIndex = 5;
            this.uxStatusStrip.Text = "uxStatusStrip";
            // 
            // uxTurns
            // 
            this.uxTurns.Name = "uxTurns";
            this.uxTurns.Size = new System.Drawing.Size(91, 25);
            this.uxTurns.Text = "Turns: 0/0";
            // 
            // uxSizeList
            // 
            this.uxSizeList.FormattingEnabled = true;
            this.uxSizeList.Items.AddRange(new object[] {
            "10x10",
            "14x14",
            "18x18"});
            this.uxSizeList.Location = new System.Drawing.Point(135, 9);
            this.uxSizeList.Name = "uxSizeList";
            this.uxSizeList.Size = new System.Drawing.Size(121, 28);
            this.uxSizeList.TabIndex = 6;
            this.uxSizeList.Text = "14x14";
            // 
            // uxColorList
            // 
            this.uxColorList.FormattingEnabled = true;
            this.uxColorList.Items.AddRange(new object[] {
            "6"});
            this.uxColorList.Location = new System.Drawing.Point(420, 9);
            this.uxColorList.Name = "uxColorList";
            this.uxColorList.Size = new System.Drawing.Size(46, 28);
            this.uxColorList.TabIndex = 7;
            this.uxColorList.Text = "6";
            // 
            // UserInterface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(595, 491);
            this.Controls.Add(this.uxColorList);
            this.Controls.Add(this.uxSizeList);
            this.Controls.Add(this.uxStatusStrip);
            this.Controls.Add(this.uxColorLabel);
            this.Controls.Add(this.uxSizeLabel);
            this.Controls.Add(this.uxBoard);
            this.Controls.Add(this.uxNewGame);
            this.Name = "UserInterface";
            this.Text = "Flood It";
            this.uxStatusStrip.ResumeLayout(false);
            this.uxStatusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button uxNewGame;
        private System.Windows.Forms.FlowLayoutPanel uxBoard;
        private System.Windows.Forms.Label uxSizeLabel;
        private System.Windows.Forms.Label uxColorLabel;
        private System.Windows.Forms.StatusStrip uxStatusStrip;
        private System.Windows.Forms.ToolStripStatusLabel uxTurns;
        private System.Windows.Forms.ComboBox uxSizeList;
        private System.Windows.Forms.ComboBox uxColorList;
    }
}

