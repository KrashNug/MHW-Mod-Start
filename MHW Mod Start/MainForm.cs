/*
 * Created by SharpDevelop.
 * User: Val
 * Date: 23.08.2020
 * Time: 15:09
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

using System.IO;
using System.Diagnostics;

namespace MHW_Mod_Start
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		
		// DEBUG
		//ListViewItem lviModData = new ListViewItem(new String[]{"0","ModName","ModPath"});
		
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
			
			
			// Check if some files need to be created
			if(!File.Exists("settings.txt"))
				CreateDataFiles.SettingsFile();
			if(!File.Exists("modlist.txt"))
				CreateDataFiles.ModsFile();
			
			// Load language and MHW-Exe path
			Settings.LoadSettings();
			
			// Load UI text and informations
			LoadUI();
			
			// Load Mods and add them to the listView control
			ModList.LoadMods();
			LoadItemsToListView();
			
			
			
			
			
			
			
			// DEBUG COMMANDS
		
			//lv_ModList.Items.Add(lviModData);
				
			//Settings.UpdateSettings("en","NewPath");
			
			//MessageBox.Show("Lang: "+Settings.Language+"\nPath: "+Settings.MHW_Path);
			//if(File.Exists(Settings.MHW_Path))
			//   MessageBox.Show("FertilizerMOD found");
			//Process.Start(Settings.MHW_Path);
			
		}

		void LoadItemsToListView()
		{
			lv_ModList.Items.Clear();
			foreach(ListViewItem lvi in ModList.Lvi_Modlist)
			lv_ModList.Items.Add(lvi);
		}
		
		void Txt_MHW_PathTextChanged(object sender, EventArgs e)
		{
			// check for " at both ends of the string and delete them
			// ==> BISHERIGE METHODEN HABEN NICHT FUNKTIONIERT. VORERST MUSS BENUTZER SELBST DARAUF ACHTEN
			
			
			// check if the file can be found under the new path, if so update settings
			if(CheckForMHW())
				Settings.UpdateSettings("nochange",txt_MHW_Path.Text);
		}
		
		private bool CheckForMHW()
		{
			// check if mhw file exists and change label
			if(File.Exists(txt_MHW_Path.Text))
			{
				lbl_MHW_Path_Check.ForeColor = Color.Green;
				
				if(Settings.Language == "de")
					lbl_MHW_Path_Check.Text = ControlTextDE.lbl_MHW_Path_Check_OK;
				else
					lbl_MHW_Path_Check.Text = ControlTextEN.lbl_MHW_Path_Check_OK;
				
				return true;
			}
			else
			{
				lbl_MHW_Path_Check.ForeColor = Color.Red;
				
				if(Settings.Language == "de")
					lbl_MHW_Path_Check.Text = ControlTextDE.lbl_MHW_Path_Check_NotOK;
				else
					lbl_MHW_Path_Check.Text = ControlTextEN.lbl_MHW_Path_Check_NotOK;
				
				return false;
			}
		}
		
		public void LoadUI()
		{
			// load UI text for controls
			// --> only en and de are supported, no need for deep construction
			if(Settings.Language == "de")
			{
				btn_NewMod.Text = ControlTextDE.btn_New;
				btn_EditMod.Text = ControlTextDE.btn_Edit;
				btn_DeleteMod.Text = ControlTextDE.btn_Delete;
				btn_RunMHW.Text = ControlTextDE.btn_RunMHW;
				btn_License.Text = ControlTextDE.btn_License;
				btn_Info.Text = ControlTextDE.btn_Info;
				
				lv_ModList.Columns[0].Text = ControlTextDE.column_ID;
				lv_ModList.Columns[1].Text = ControlTextDE.column_ModName;
				lv_ModList.Columns[2].Text = ControlTextDE.column_ModPfad;
				
				lbl_MHW_Path.Text = ControlTextDE.lbl_MHW_Path;
				txt_MHW_Path.Text = Settings.MHW_Path;
				
				rb_DE.Checked = true;
			}
			else
			{
				//==> Muss noch ausgearbeitet werden ....
				
				btn_NewMod.Text = ControlTextEN.btn_New;
				btn_EditMod.Text = ControlTextEN.btn_Edit;
				btn_DeleteMod.Text = ControlTextEN.btn_Delete;
				btn_RunMHW.Text = ControlTextEN.btn_RunMHW;
				btn_License.Text = ControlTextEN.btn_License;
				btn_Info.Text = ControlTextEN.btn_Info;
				
				lv_ModList.Columns[0].Text = ControlTextEN.column_ID;
				lv_ModList.Columns[1].Text = ControlTextEN.column_ModName;
				lv_ModList.Columns[2].Text = ControlTextEN.column_ModPfad;
				
				lbl_MHW_Path.Text = ControlTextEN.lbl_MHW_Path;
				txt_MHW_Path.Text = Settings.MHW_Path;
				
				rb_EN.Checked = true;
			}
			
			// take a check on the path to update the label
			// ==> MAYBE NOT THE BEST WAY TO DO THAT HERE ....
			CheckForMHW();
		}
		
		void Btn_BrowseMHWClick(object sender, EventArgs e)
		{
			OpenFileDialog ofd = new OpenFileDialog();
			ofd.ShowDialog();
			if(ofd.FileName!="")
				txt_MHW_Path.Text = ofd.FileName;
		}
		
		void Rb_CheckedChanged(object sender, EventArgs e)
		{
			if(rb_DE.Checked)
				Settings.UpdateSettings("de", "nochange");
			if(rb_EN.Checked)
				Settings.UpdateSettings("en", "nochange");
			
			Settings.LoadSettings();
			LoadUI();
		}
		
		ModEditor modEditor;
		
		void Btn_NewModClick(object sender, EventArgs e)
		{
			if(modEditor == null)
			{
				modEditor = new ModEditor(ModList.GetNextID);
				modEditor.Show();
				modEditor.BringToFront();
				this.Enabled = false;
				ti_EditorWatch.Enabled = true;
			}
			
		}
		void Ti_EditorWatchTick(object sender, EventArgs e)
		{
			if(modEditor.Visible == false)
			{
				// disable timer
				ti_EditorWatch.Enabled=false;
				
				// HIER MÜSSEN ÜBERGEBENE DATEN BEHANDELT WERDEN SOFERN WELCHE ÜBERGEBEN WURDEN
				if(modEditor.NewData)
				{
					ModList.Lvi_Modlist.Add(modEditor.LviModData);
					ModList.SaveMods();
					LoadItemsToListView();
				}
				if(modEditor.EditedData)
				{
					// search the correct item in the modlist and overwrite it
					for(int i=0;i<ModList.Lvi_Modlist.Count;i++)
					{
						if(ModList.Lvi_Modlist[i].SubItems[0].Text == modEditor.LviModData.SubItems[0].Text)
						{
							ModList.Lvi_Modlist[i] = modEditor.LviModData;
							ModList.SaveMods();
							LoadItemsToListView();
						}
					}
				}
				
				// delete active modEditor object and enable main form
				modEditor = null;
				this.BringToFront();
				this.Enabled = true;
			}
		}
		void Btn_DeleteModClick(object sender, EventArgs e)
		{
			// check if item is selected befor starting some action
			if(lv_ModList.SelectedItems.Count > 0)
			{
				// compare selected id with list to find the mod that should be deleted
				string selectedID = lv_ModList.SelectedItems[0].SubItems[0].Text;
				
				for(int i=0;i<ModList.Lvi_Modlist.Count;i++)
				{
					if(ModList.Lvi_Modlist[i].SubItems[0].Text == selectedID)
					{
						// delete the list entry
						//ModList.Lvi_Modlist[i].Remove();
						ModList.Lvi_Modlist.RemoveAt(i);
						
						// decrease all following entriy id by one
						for(int j=i;j<ModList.Lvi_Modlist.Count;j++)
						{
							int dummyID = Convert.ToInt32(ModList.Lvi_Modlist[j].SubItems[0].Text);
							dummyID--;
							ModList.Lvi_Modlist[j].SubItems[0].Text = dummyID.ToString();
						}
					}
				}
				
				// save the modlist to file
				ModList.SaveMods();
				// update the list view control
				LoadItemsToListView();
			}
		}
		void Btn_EditModClick(object sender, EventArgs e)
		{
			// check if item is selected befor starting some action
			if(lv_ModList.SelectedItems.Count > 0)
			{
				// search selected entry in modlist List
				// start modeditor with selected modlist List item
				modEditor = new ModEditor(lv_ModList.SelectedItems[0]);
				// start timer and disable form
				modEditor.Show();
				modEditor.BringToFront();
				this.Enabled = false;
				ti_EditorWatch.Enabled = true;
			}
		}
		
		void Btn_RunMHWClick(object sender, EventArgs e)
		{
			// just to be sure ... check all paths again
			// if one ore more files cannot found do nothing and throw some error
			
			bool errorDetected = false;
			
			if(!File.Exists(Settings.MHW_Path))
			{
				ErrorReports.FileNotFoundError(Settings.MHW_Path);
				errorDetected = true;
			}
			
			foreach(ListViewItem lvi in ModList.Lvi_Modlist)
			{
				if(!File.Exists(lvi.SubItems[2].Text))
				{
					ErrorReports.FileNotFoundError(lvi.SubItems[2].Text);
					errorDetected = true;
				}
			}
			
			// if no error occured, start mhw first, wait ten seconds and start the mods
			if(!errorDetected)
			{
				Process.Start(Settings.MHW_Path);
				
				System.Threading.Thread.Sleep(10000);
				
				foreach(ListViewItem lvi in ModList.Lvi_Modlist)
				{
					Process.Start(lvi.SubItems[2].Text);
				}
				
				// once all the work is done bow yourselfe and shut down
				Application.Exit();
			}
		}
		void Btn_InfoClick(object sender, EventArgs e)
		{
			MessageBox.Show("Autor Tim Licha\nMail info@uruban.de\n\nFeedback jeglicher Art ist gerne unter der angegebenen Mailadresse willkommen, bitte im Betreff 'MHW Mod Start' angeben.\n\nFeedback in all kinds is gladly welcome under the given mail adress, please refer to 'MHW Mod Start'.");
		}
		void Btn_LicenseClick(object sender, EventArgs e)
		{
			MessageBox.Show("DEUTSCH\n Dieses Programm ist Freie Software: Sie können es unter den Bedingungen der GNU General Public License, wie von der Free Software Foundation, Version 3 der Lizenz oder (nach Ihrer Wahl) jeder neueren veröffentlichten Version, weiter verteilen und/oder modifizieren.\nDieses Programm wird in der Hoffnung bereitgestellt, dass es nützlich sein wird, jedoch OHNE JEDE GEWÄHR,; sogar ohne die implizite Gewähr der MARKTFÄHIGKEIT oder EIGNUNG FÜR EINEN BESTIMMTEN ZWECK. Siehe die GNU General Public License für weitere Einzelheiten.\nSie sollten eine Kopie der GNU General Public License zusammen mit diesem Programm erhalten haben. Wenn nicht, siehe <https://www.gnu.org/licenses/>.\n\nENGLISH\nThis program is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version.\nThis program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of ERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU General Public License for more details.\nYou should have received a copy of the GNU General Public License along with this program.  If not, see <http://www.gnu.org/licenses/>.");
		}
	}
}




#region TODO
/*
 
 - Prüfen ob MHW läuft, bevor MODS gestartet werden >> Ausgabe Fehler, wenn nicht
 - Prüfen ob MOD Pfade gültig sind >> Bei Start Programm / Bei aktualisierung MOD Einträge
 
 - Zweite Form, für neue Einträge
 - LOAD Funktion für ListView, wenn Einträge hinzugefügt, geändert oder gelöscht werden
 
 - FirstStartup Aktionen: Settings Datei anlegen, mit DefaultSprache und MHW Pfad
 
 - Startup Routine, prüfe ob Settings Datei vorhanden, erstelle falls nötig, lade DefaultSprache, prüfe ob Pfad zur MHW EXE korrekt
 
 
 
 */
#endregion




