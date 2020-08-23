/*
 * Created by SharpDevelop.
 * User: Val
 * Date: 23.08.2020
 * Time: 15:19
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;

namespace MHW_Mod_Start
{
	/// <summary>
	/// Description of ModEditor.
	/// </summary>
	public partial class ModEditor : Form
	{
		private bool newData = false;
		public bool NewData{
			get { return newData; }
		}
		
		private bool editedData = false;
		public bool EditedData{
			get { return editedData; }
		}
		
		private ListViewItem lviModData = new ListViewItem(new String[]{"0","ModName","ModPath"});
		public ListViewItem LviModData
		{
			get { return lviModData; }
			set { lviModData = value; }
		}
		
		// constructor for creating a new mod
		public ModEditor(int modID)
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
			
			
			// load text on UI
			LoadUI();
			
			// create new object for mod entry with overgiven ID
			lviModData = new ListViewItem(new String[]{modID.ToString(),"ModName","ModPath"});
			// load default data
			txt_ModName.Text = lviModData.SubItems[1].Text;
			txt_ModPfad.Text = lviModData.SubItems[2].Text;
			
			// set the specific bool indicator to true, to determin if a new mod is saved or changes to an existing were made
			newData = true;
			editedData = false;
			// DEBUG
			//MessageBox.Show(modID.ToString());
		}
		
		// constructor for editing an existing mod
		public ModEditor(ListViewItem givenModEntry)
		{
			InitializeComponent();
			
			lviModData = givenModEntry;
			txt_ModName.Text = lviModData.SubItems[1].Text;
			txt_ModPfad.Text = lviModData.SubItems[2].Text;
			
			// set the specific bool indicator to true, to determin if a new mod is saved or changes to an existing were made
			editedData = true;
			newData = false;
			
			LoadUI();
		}
		
		void Btn_CancelClick(object sender, EventArgs e)
		{
			newData = false;
			editedData = false;
			this.Close();
		}
		
		
		public void LoadUI()
		{
			// load UI text for controls
			// --> only en and de are supported, no need for deep construction
			if(Settings.Language == "de")
			{
				btn_SaveMod.Text = 	ControlTextDE.btn_SaveMod;
				btn_Cancel.Text = 	ControlTextDE.btn_Cancel;
			}
			else
			{
				btn_SaveMod.Text = 	ControlTextEN.btn_SaveMod;
				btn_Cancel.Text = 	ControlTextEN.btn_Cancel;
			}
			
		}
		void Btn_SaveModClick(object sender, EventArgs e)
		{
			
			lviModData.SubItems[1].Text = txt_ModName.Text;
			lviModData.SubItems[2].Text = txt_ModPfad.Text;
			
			//newData = true;
			//editedData = false;
			// bools will be set to true in the specific constructor, in case the user cancels the action the bools are set to false by the cancel button
			this.Close();
	
		}
		
	}
}
