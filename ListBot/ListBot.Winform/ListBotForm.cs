using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ListBot.Lib;

namespace ListBot.Winform
{
	public partial class ListBotForm : Form
	{
		public ListBotForm()
		{
			InitializeComponent();
		}

		private void buttonSubmitUrl_Click(object sender, EventArgs e)
		{
			var pca = new PCA();
			//var content = await pca.SearchPcaChurchesByStateNoJavaScript("GA");
			var content = pca.SearchPcaChurchesByState("PA");
			textBoxResponse.Text = content;
		}
	}
}
