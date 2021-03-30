#region using List

using System;
using System.Windows.Forms;

#endregion

namespace CczEditor.Controls
{
	public class NumericControl : NumericUpDown
	{
		protected bool ClickFlag;

		protected override void OnGotFocus(EventArgs e)
		{
			Select(0, Text.Length);
			base.OnGotFocus(e);
		}

		protected override void OnLostFocus(EventArgs e)
		{
			ClickFlag = false;
			base.OnLostFocus(e);
		}

		protected override void OnMouseClick(MouseEventArgs e)
		{
			if (!ClickFlag)
			{
				Select(0, Text.Length);
				ClickFlag = true;
			}
			base.OnMouseClick(e);
		}

		protected override void OnValueChanged(EventArgs e)
		{
			if (MinNumberControl != null && Value < MinNumberControl.Value)
			{
				Value = MinNumberControl.Value;
			}
			if (MaxNumberControl != null && Value > MaxNumberControl.Value)
			{
				Value = MaxNumberControl.Value;
			}
			base.OnValueChanged(e);
		}

		public NumericControl MinNumberControl { get; set; }

		public NumericControl MaxNumberControl { get; set; }
	}
}