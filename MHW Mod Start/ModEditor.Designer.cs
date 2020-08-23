/*
 * Created by SharpDevelop.
 * User: Val
 * Date: 23.08.2020
 * Time: 15:19
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace MHW_Mod_Start
{
	partial class ModEditor
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.Button btn_SaveMod;
		private System.Windows.Forms.TextBox txt_ModName;
		private System.Windows.Forms.TextBox txt_ModPfad;
		private System.Windows.Forms.Button btn_Cancel;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.btn_SaveMod = new System.Windows.Forms.Button();
			this.txt_ModName = new System.Windows.Forms.TextBox();
			this.txt_ModPfad = new System.Windows.Forms.TextBox();
			this.btn_Cancel = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// btn_SaveMod
			// 
			this.btn_SaveMod.Location = new System.Drawing.Point(12, 38);
			this.btn_SaveMod.Name = "btn_SaveMod";
			this.btn_SaveMod.Size = new System.Drawing.Size(75, 23);
			this.btn_SaveMod.TabIndex = 0;
			this.btn_SaveMod.Text = "button1";
			this.btn_SaveMod.UseVisualStyleBackColor = true;
			this.btn_SaveMod.Click += new System.EventHandler(this.Btn_SaveModClick);
			// 
			// txt_ModName
			// 
			this.txt_ModName.Location = new System.Drawing.Point(12, 12);
			this.txt_ModName.Name = "txt_ModName";
			this.txt_ModName.Size = new System.Drawing.Size(100, 20);
			this.txt_ModName.TabIndex = 1;
			// 
			// txt_ModPfad
			// 
			this.txt_ModPfad.Location = new System.Drawing.Point(118, 12);
			this.txt_ModPfad.Name = "txt_ModPfad";
			this.txt_ModPfad.Size = new System.Drawing.Size(100, 20);
			this.txt_ModPfad.TabIndex = 2;
			// 
			// btn_Cancel
			// 
			this.btn_Cancel.Location = new System.Drawing.Point(93, 38);
			this.btn_Cancel.Name = "btn_Cancel";
			this.btn_Cancel.Size = new System.Drawing.Size(75, 23);
			this.btn_Cancel.TabIndex = 3;
			this.btn_Cancel.Text = "button2";
			this.btn_Cancel.UseVisualStyleBackColor = true;
			this.btn_Cancel.Click += new System.EventHandler(this.Btn_CancelClick);
			// 
			// ModEditor
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(241, 79);
			this.Controls.Add(this.btn_Cancel);
			this.Controls.Add(this.txt_ModPfad);
			this.Controls.Add(this.txt_ModName);
			this.Controls.Add(this.btn_SaveMod);
			this.Name = "ModEditor";
			this.Text = "ModEditor";
			this.ResumeLayout(false);
			this.PerformLayout();

		}
	}
}
