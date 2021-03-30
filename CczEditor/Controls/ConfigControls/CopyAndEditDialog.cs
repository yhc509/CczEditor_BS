#region using List

using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Forms;

#endregion

namespace CczEditor.Controls.ConfigControls
{
	public partial class CopyAndEditDialog : Form
	{
		public string TypeName { get; set; }

		public string TypeDisplayName { get; set; }

		public Dictionary<string, string> TypeNames { get; set; }

		public CopyAndEditDialog()
		{
			InitializeComponent();
		}

		private void CopyAndEditDialog_Load(object sender, EventArgs e)
		{
			txtTypeName.Text = TypeName;
			txtDisplayName.Text = TypeDisplayName;
		}

		private void btnAccept_Click(object sender, EventArgs e)
		{
			TypeName = txtTypeName.Text;
			TypeDisplayName = txtDisplayName.Text;
			if (string.IsNullOrEmpty(TypeName) || string.IsNullOrEmpty(TypeDisplayName))
			{
				Utils.ShowError("버전명을 입력해주십시오!");
			}
			else if (TypeNames.ContainsKey(TypeName))
			{
				Utils.ShowError("그 이름은 이미 존재합니다!");
			}
			else
			{
				DialogResult = DialogResult.OK;
				Close();
			}
		}

		private void txtTypeName_TextChanged(object sender, EventArgs e)
		{
			txtTypeName.Text = Regex.Replace(txtTypeName.Text, @"[^0-9a-zA-Z-.]", string.Empty);
		}
	}
}