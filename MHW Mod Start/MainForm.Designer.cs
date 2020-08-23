/*
 * Created by SharpDevelop.
 * User: Val
 * Date: 23.08.2020
 * Time: 15:09
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace MHW_Mod_Start
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.ListView lv_ModList;
		private System.Windows.Forms.ColumnHeader ch_ID;
		private System.Windows.Forms.ColumnHeader ch_ModName;
		private System.Windows.Forms.ColumnHeader ch_ModPath;
		private System.Windows.Forms.Button btn_NewMod;
		private System.Windows.Forms.Button btn_EditMod;
		private System.Windows.Forms.Button btn_DeleteMod;
		private System.Windows.Forms.TextBox txt_MHW_Path;
		private System.Windows.Forms.Label lbl_MHW_Path;
		private System.Windows.Forms.Label lbl_MHW_Path_Check;
		private System.Windows.Forms.Button btn_BrowseMHW;
		private System.Windows.Forms.RadioButton rb_EN;
		private System.Windows.Forms.RadioButton rb_DE;
		private System.Windows.Forms.Timer ti_EditorWatch;
		private System.Windows.Forms.Button btn_RunMHW;
		private System.Windows.Forms.Button btn_Info;
		private System.Windows.Forms.Button btn_License;
		
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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.lv_ModList = new System.Windows.Forms.ListView();
			this.ch_ID = new System.Windows.Forms.ColumnHeader();
			this.ch_ModName = new System.Windows.Forms.ColumnHeader();
			this.ch_ModPath = new System.Windows.Forms.ColumnHeader();
			this.btn_NewMod = new System.Windows.Forms.Button();
			this.btn_EditMod = new System.Windows.Forms.Button();
			this.btn_DeleteMod = new System.Windows.Forms.Button();
			this.txt_MHW_Path = new System.Windows.Forms.TextBox();
			this.lbl_MHW_Path = new System.Windows.Forms.Label();
			this.lbl_MHW_Path_Check = new System.Windows.Forms.Label();
			this.btn_BrowseMHW = new System.Windows.Forms.Button();
			this.rb_DE = new System.Windows.Forms.RadioButton();
			this.rb_EN = new System.Windows.Forms.RadioButton();
			this.ti_EditorWatch = new System.Windows.Forms.Timer(this.components);
			this.btn_RunMHW = new System.Windows.Forms.Button();
			this.btn_Info = new System.Windows.Forms.Button();
			this.btn_License = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// lv_ModList
			// 
			this.lv_ModList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
			this.ch_ID,
			this.ch_ModName,
			this.ch_ModPath});
			this.lv_ModList.FullRowSelect = true;
			this.lv_ModList.Location = new System.Drawing.Point(12, 107);
			this.lv_ModList.Name = "lv_ModList";
			this.lv_ModList.Size = new System.Drawing.Size(306, 173);
			this.lv_ModList.TabIndex = 0;
			this.lv_ModList.UseCompatibleStateImageBehavior = false;
			this.lv_ModList.View = System.Windows.Forms.View.Details;
			// 
			// ch_ID
			// 
			this.ch_ID.Text = "ID";
			this.ch_ID.Width = 38;
			// 
			// ch_ModName
			// 
			this.ch_ModName.Text = "MOD Name";
			this.ch_ModName.Width = 114;
			// 
			// ch_ModPath
			// 
			this.ch_ModPath.Text = "MOD Path";
			this.ch_ModPath.Width = 147;
			// 
			// btn_NewMod
			// 
			this.btn_NewMod.Location = new System.Drawing.Point(12, 286);
			this.btn_NewMod.Name = "btn_NewMod";
			this.btn_NewMod.Size = new System.Drawing.Size(75, 23);
			this.btn_NewMod.TabIndex = 1;
			this.btn_NewMod.Text = "button1";
			this.btn_NewMod.UseVisualStyleBackColor = true;
			this.btn_NewMod.Click += new System.EventHandler(this.Btn_NewModClick);
			// 
			// btn_EditMod
			// 
			this.btn_EditMod.Location = new System.Drawing.Point(93, 286);
			this.btn_EditMod.Name = "btn_EditMod";
			this.btn_EditMod.Size = new System.Drawing.Size(75, 23);
			this.btn_EditMod.TabIndex = 2;
			this.btn_EditMod.Text = "button2";
			this.btn_EditMod.UseVisualStyleBackColor = true;
			this.btn_EditMod.Click += new System.EventHandler(this.Btn_EditModClick);
			// 
			// btn_DeleteMod
			// 
			this.btn_DeleteMod.Location = new System.Drawing.Point(174, 286);
			this.btn_DeleteMod.Name = "btn_DeleteMod";
			this.btn_DeleteMod.Size = new System.Drawing.Size(75, 23);
			this.btn_DeleteMod.TabIndex = 3;
			this.btn_DeleteMod.Text = "button3";
			this.btn_DeleteMod.UseVisualStyleBackColor = true;
			this.btn_DeleteMod.Click += new System.EventHandler(this.Btn_DeleteModClick);
			// 
			// txt_MHW_Path
			// 
			this.txt_MHW_Path.Location = new System.Drawing.Point(12, 38);
			this.txt_MHW_Path.Name = "txt_MHW_Path";
			this.txt_MHW_Path.Size = new System.Drawing.Size(100, 20);
			this.txt_MHW_Path.TabIndex = 4;
			this.txt_MHW_Path.TextChanged += new System.EventHandler(this.Txt_MHW_PathTextChanged);
			// 
			// lbl_MHW_Path
			// 
			this.lbl_MHW_Path.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbl_MHW_Path.Location = new System.Drawing.Point(12, 9);
			this.lbl_MHW_Path.Name = "lbl_MHW_Path";
			this.lbl_MHW_Path.Size = new System.Drawing.Size(136, 23);
			this.lbl_MHW_Path.TabIndex = 5;
			this.lbl_MHW_Path.Text = "label1";
			// 
			// lbl_MHW_Path_Check
			// 
			this.lbl_MHW_Path_Check.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbl_MHW_Path_Check.Location = new System.Drawing.Point(12, 65);
			this.lbl_MHW_Path_Check.Name = "lbl_MHW_Path_Check";
			this.lbl_MHW_Path_Check.Size = new System.Drawing.Size(136, 28);
			this.lbl_MHW_Path_Check.TabIndex = 6;
			this.lbl_MHW_Path_Check.Text = "label2";
			// 
			// btn_BrowseMHW
			// 
			this.btn_BrowseMHW.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_BrowseMHW.Location = new System.Drawing.Point(118, 38);
			this.btn_BrowseMHW.Name = "btn_BrowseMHW";
			this.btn_BrowseMHW.Size = new System.Drawing.Size(30, 20);
			this.btn_BrowseMHW.TabIndex = 7;
			this.btn_BrowseMHW.Text = "...\r\n";
			this.btn_BrowseMHW.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			this.btn_BrowseMHW.UseVisualStyleBackColor = true;
			this.btn_BrowseMHW.Click += new System.EventHandler(this.Btn_BrowseMHWClick);
			// 
			// rb_DE
			// 
			this.rb_DE.Checked = true;
			this.rb_DE.Image = ((System.Drawing.Image)(resources.GetObject("rb_DE.Image")));
			this.rb_DE.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.rb_DE.Location = new System.Drawing.Point(260, 12);
			this.rb_DE.Name = "rb_DE";
			this.rb_DE.Size = new System.Drawing.Size(58, 28);
			this.rb_DE.TabIndex = 9;
			this.rb_DE.TabStop = true;
			this.rb_DE.UseVisualStyleBackColor = true;
			this.rb_DE.CheckedChanged += new System.EventHandler(this.Rb_CheckedChanged);
			// 
			// rb_EN
			// 
			this.rb_EN.Image = ((System.Drawing.Image)(resources.GetObject("rb_EN.Image")));
			this.rb_EN.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.rb_EN.Location = new System.Drawing.Point(260, 43);
			this.rb_EN.Name = "rb_EN";
			this.rb_EN.Size = new System.Drawing.Size(58, 28);
			this.rb_EN.TabIndex = 10;
			this.rb_EN.UseVisualStyleBackColor = true;
			this.rb_EN.CheckedChanged += new System.EventHandler(this.Rb_CheckedChanged);
			// 
			// ti_EditorWatch
			// 
			this.ti_EditorWatch.Interval = 10;
			this.ti_EditorWatch.Tick += new System.EventHandler(this.Ti_EditorWatchTick);
			// 
			// btn_RunMHW
			// 
			this.btn_RunMHW.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_RunMHW.Location = new System.Drawing.Point(12, 325);
			this.btn_RunMHW.Name = "btn_RunMHW";
			this.btn_RunMHW.Size = new System.Drawing.Size(156, 73);
			this.btn_RunMHW.TabIndex = 11;
			this.btn_RunMHW.Text = "button1";
			this.btn_RunMHW.UseVisualStyleBackColor = true;
			this.btn_RunMHW.Click += new System.EventHandler(this.Btn_RunMHWClick);
			// 
			// btn_Info
			// 
			this.btn_Info.Location = new System.Drawing.Point(174, 12);
			this.btn_Info.Name = "btn_Info";
			this.btn_Info.Size = new System.Drawing.Size(75, 23);
			this.btn_Info.TabIndex = 12;
			this.btn_Info.Text = "button1";
			this.btn_Info.UseVisualStyleBackColor = true;
			this.btn_Info.Click += new System.EventHandler(this.Btn_InfoClick);
			// 
			// btn_License
			// 
			this.btn_License.Location = new System.Drawing.Point(174, 41);
			this.btn_License.Name = "btn_License";
			this.btn_License.Size = new System.Drawing.Size(75, 23);
			this.btn_License.TabIndex = 13;
			this.btn_License.Text = "button2";
			this.btn_License.UseVisualStyleBackColor = true;
			this.btn_License.Click += new System.EventHandler(this.Btn_LicenseClick);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(329, 409);
			this.Controls.Add(this.btn_License);
			this.Controls.Add(this.btn_Info);
			this.Controls.Add(this.btn_RunMHW);
			this.Controls.Add(this.rb_EN);
			this.Controls.Add(this.rb_DE);
			this.Controls.Add(this.btn_BrowseMHW);
			this.Controls.Add(this.lbl_MHW_Path_Check);
			this.Controls.Add(this.lbl_MHW_Path);
			this.Controls.Add(this.txt_MHW_Path);
			this.Controls.Add(this.btn_DeleteMod);
			this.Controls.Add(this.btn_EditMod);
			this.Controls.Add(this.btn_NewMod);
			this.Controls.Add(this.lv_ModList);
			this.Name = "MainForm";
			this.Text = "MHW Mod Start";
			this.ResumeLayout(false);
			this.PerformLayout();

		}
	}
}
