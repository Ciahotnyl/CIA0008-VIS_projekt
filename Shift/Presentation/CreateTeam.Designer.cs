namespace Shift.Presentation
{
    partial class CreateTeam
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
            this.Update_team_btn = new System.Windows.Forms.Button();
            this.Leva = new System.Windows.Forms.DataGridView();
            this.Prava = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.Leva)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Prava)).BeginInit();
            this.SuspendLayout();
            // 
            // Update_team_btn
            // 
            this.Update_team_btn.Location = new System.Drawing.Point(494, 272);
            this.Update_team_btn.Name = "Update_team_btn";
            this.Update_team_btn.Size = new System.Drawing.Size(106, 23);
            this.Update_team_btn.TabIndex = 2;
            this.Update_team_btn.Text = "Add to Team";
            this.Update_team_btn.UseVisualStyleBackColor = true;
            this.Update_team_btn.Click += new System.EventHandler(this.Update_team_btn_Click);
            // 
            // Leva
            // 
            this.Leva.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Leva.Location = new System.Drawing.Point(12, 12);
            this.Leva.Name = "Leva";
            this.Leva.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Leva.Size = new System.Drawing.Size(288, 244);
            this.Leva.TabIndex = 3;
            // 
            // Prava
            // 
            this.Prava.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Prava.Location = new System.Drawing.Point(312, 12);
            this.Prava.Name = "Prava";
            this.Prava.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Prava.Size = new System.Drawing.Size(288, 244);
            this.Prava.TabIndex = 4;
            // 
            // CreateTeam
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(612, 307);
            this.Controls.Add(this.Prava);
            this.Controls.Add(this.Leva);
            this.Controls.Add(this.Update_team_btn);
            this.Name = "CreateTeam";
            this.Text = "CreateTeam";
            this.Load += new System.EventHandler(this.CreateTeam_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Leva)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Prava)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button Update_team_btn;
        private System.Windows.Forms.DataGridView Leva;
        private System.Windows.Forms.DataGridView Prava;
    }
}