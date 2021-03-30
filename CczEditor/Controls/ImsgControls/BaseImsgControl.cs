#region using List

using System;

#endregion

namespace CczEditor.Controls.ImsgControls
{
	public partial class BaseImsgControl : BaseControl
	{
		public BaseImsgControl()
		{
			InitializeComponent();
            if (GameDataLoaded == true)
            {
                comboBox1.Items.AddRange(GameData.UnitNameList(true).ToArray());
                comboBox1.Items.Add("400,없음");
            }
		}

		private void txtText_TextChanged(object sender, EventArgs e)
		{
			lblTextCount.Text = string.Format("글자 수：{0}", txtText.Text.Length);
		}

	}
}