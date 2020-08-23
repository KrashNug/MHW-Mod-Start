/*
 * Created by SharpDevelop.
 * User: Val
 * Date: 23.08.2020
 * Time: 15:26
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
	public static class Settings
	{
		private static string language = "";
		public static string Language{
			get { return language; }
			set { language = value; }
		}
		
		private static string mhw_path = "";
		public static string MHW_Path{
			get { return mhw_path; }
			set { mhw_path = value; }
		}
	
		// load values from settings file into static strings
		public static void LoadSettings()
		{
			// Load content of settings file
			string[] filecontent = File.ReadAllLines("settings.txt");
			
			// check if settings content is valid, if not reload settings content
			if(filecontent.Length != 2)
			{
				// throw some error message and create settings file new
				ErrorReports.SettingsError("Settings file must contain exactly two entries, one for language and one for mhw exe path");
				// load content again
				filecontent = File.ReadAllLines("settings.txt");
			}
			
			// load setting into static variables		==> NEEDS FURTHER ERROR CHECKS
			language = filecontent[0].Split('=')[1];
			mhw_path = filecontent[1].Split('=')[1];
		}
		
		// update values in settings file from overgiven values
		// ==> use "nochange" as flag if only one value should be changed
		public static void UpdateSettings(string newLang, string newPath)
		{
			string langDummy = "lang=";
			string mhwDummy = "mhw=";
			
			// possible changes: 1. update both lines --> create file new 2. update just one line --> use lineChanger
			
			// 1. update both lines
			if(newLang != "nochange" && newPath!="nochange")
			{
				langDummy+=newLang;
				mhwDummy+=newPath;
				
				File.WriteAllLines("settings.txt",new string[]{langDummy,mhwDummy});
				
				language = newLang;
				mhw_path = newPath;
			}
			
			// 2. update only one line
			if(newLang == "nochange" || newPath == "nochange")
			{
				if(newLang == "nochange")
				{
					mhwDummy+=newPath;
					lineChanger(mhwDummy,"settings.txt",2);
					mhw_path = newPath;
				}
				if(newPath == "nochange")
				{
					langDummy+=newLang;
					lineChanger(langDummy,"settings.txt",1);
					language = newLang;
				}
			}
		}
		
		// changes the specific line of the file with the overgiven value
		// source https://stackoverflow.com/questions/1971008/edit-a-specific-line-of-a-text-file-in-c-sharp
		// --> best for small files
		static void lineChanger(string newText, string fileName, int line_to_edit)
		{
		     string[] arrLine = File.ReadAllLines(fileName);
		     arrLine[line_to_edit - 1] = newText;
		     File.WriteAllLines(fileName, arrLine);
		}
	}
	
	public static class ModList
	{
		private static List<ListViewItem> lvi_ModList = new List<ListViewItem>();
		public static List<ListViewItem> Lvi_Modlist
		{
			get { return lvi_ModList; }
			set { lvi_ModList = value; }
		}
		
		public static int GetNextID{
			get {
				int latestID;
				
				if(lvi_ModList.Count>0)
				{
					latestID = Convert.ToInt32(lvi_ModList[lvi_ModList.Count-1].SubItems[0].Text);
					latestID++;
				}
				else
					latestID = 0;
				
				return latestID;
			}
		}
		
		public static void LoadMods()
		{
			// read modlist.txt			
			string[] fileContent = File.ReadAllLines("modlist.txt");
			
			
			// split every line in file ';'
			foreach(string s in fileContent)
			{
				if(s != "") // check if line contains data
				{
					// split line and store data in array
					string[] splitDummy = s.Split(';');
					
					// check if entries available
					if(splitDummy.Length == 0)
						ErrorReports.ModlistError("Split lenght is zero.");					   
					else
					{
						// check if entries have the correct amaount
						if(splitDummy.Length != 3)
							ErrorReports.ModlistError("Split lenght is not three.");
						else
						{
							// add entry to modlist listview List
							lvi_ModList.Add(new ListViewItem(new String[]{splitDummy[0],splitDummy[1],splitDummy[2]}));
						}
					}
				}
				else // report error for empty line
					ErrorReports.ModlistError("Empty line.");
			}
		}
		
		public static void SaveMods()
		{
			// set up the data in string array
			string[] modsDummy = new string[lvi_ModList.Count];
			
			// fill the dummy array
			for(int i=0;i<lvi_ModList.Count;i++)
			{
				// every lvi entry contains the following data [0]=ID [1]=ModName [2]=ModPath
				modsDummy[i] = lvi_ModList[i].SubItems[0].Text+";"+lvi_ModList[i].SubItems[1].Text+";"+lvi_ModList[i].SubItems[2].Text;
			}
			
			// write the dummy array to the modlist.txt
			File.WriteAllLines("modlist.txt",modsDummy);
		}
	}
	
	public static class ErrorReports
	{
		// if error occures while doing stuff with settings file, throw some message to the user, delete the corrupted file and restart the application (triggering CreateDataFiles.SettingsFile)
		public static void SettingsError(string info)
		{
				MessageBox.Show("Settings file contains some errors.\nFile will be deleted and created new with default values.\n"+info,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
				
				File.Delete("settings.txt");
				
				CreateDataFiles.SettingsFile();
		}
		
		public static void ModlistError(string info)
		{
			MessageBox.Show("Modlist entry contains some errors.\n"+info,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
		}
		
		public static void FileNotFoundError(string info)
		{
			MessageBox.Show("File not found:\n"+info,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
		}
	}
	
	public static class CreateDataFiles
	{
		// Needed files are created in the applications startup folder, so no path necessary
		
		// Creates new settings file with default data
		public static void SettingsFile()
		{
			StreamWriter sw = File.CreateText("settings.txt");
			sw.WriteLine("lang=de");
			sw.Write("mhw=");
			sw.Close();
		}
		// Creates empty modlist file
		public static void ModsFile()
		{
			File.CreateText("modlist.txt").Close();
		}
	}
	
	public static class ControlTextDE
	{
		public static string btn_New = "Neu";
		public static string btn_Edit = "Bearbeiten";
		public static string btn_Delete = "Löschen";
		public static string column_ID = "ID";
		public static string column_ModName = "Mod Name";
		public static string column_ModPfad = "Mod Pfad";
		public static string btn_Info = "Info";
		public static string btn_License = "Lizenz";
		
		public static string lbl_MHW_Path_Check_OK = "DATEI GEFUNDEN";
		public static string lbl_MHW_Path_Check_NotOK = "DATEI NICHT GEFUNDEN";
		public static string lbl_MHW_Path = "MHW Dateipfad";
		
		public static string btn_SaveMod = "Speichern";
		public static string btn_Cancel = "Abbrechen";
		
		public static string btn_RunMHW = "Starte\nMHW";
	}
	
	public static class ControlTextEN
	{
		public static string btn_New = "New";
		public static string btn_Edit = "Edit";
		public static string btn_Delete = "Delete";
		public static string column_ID = "ID";
		public static string column_ModName = "Mod Name";
		public static string column_ModPfad = "Mod Path";
		public static string btn_Info = "Info";
		public static string btn_License = "License";
		
		public static string lbl_MHW_Path_Check_OK = "FILE FOUND";
		public static string lbl_MHW_Path_Check_NotOK = "FILE NOT FOUND";
		public static string lbl_MHW_Path = "MHW Filepath";
		
		public static string btn_SaveMod = "Save";
		public static string btn_Cancel = "Cancel";
		
		public static string btn_RunMHW = "Run\nMHW";
	}
	
	
}