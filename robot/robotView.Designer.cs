namespace RobotApp
{
    partial class robotView
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtCmd = new System.Windows.Forms.TextBox();
            this.lblOutput = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtCmd
            // 
            this.txtCmd.AutoCompleteCustomSource.AddRange(new string[] {
            "PLACE",
            "MOVE",
            "LEFT",
            "RIGHT",
            "REPORT"});
            this.txtCmd.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtCmd.Location = new System.Drawing.Point(157, 15);
            this.txtCmd.Name = "txtCmd";
            this.txtCmd.Size = new System.Drawing.Size(332, 20);
            this.txtCmd.TabIndex = 7;
            this.txtCmd.Text = "PLACE 0,0,NORTH";
            // 
            // lblOutput
            // 
            this.lblOutput.AutoSize = true;
            this.lblOutput.Location = new System.Drawing.Point(154, 51);
            this.lblOutput.Name = "lblOutput";
            this.lblOutput.Size = new System.Drawing.Size(0, 13);
            this.lblOutput.TabIndex = 10;
            // 
            // robotView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblOutput);
            this.Controls.Add(this.txtCmd);
            this.Name = "robotView";
            this.Size = new System.Drawing.Size(513, 166);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtCmd;
        private System.Windows.Forms.Label lblOutput;
    }
}
