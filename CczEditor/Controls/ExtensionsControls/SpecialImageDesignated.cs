#region using List

using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

using CczEditor.Config;

#endregion

namespace CczEditor.Controls.ExtensionsControls
{
	public partial class SpecialImageDesignated : BaseControl
	{
		private FileStream _fs;
		private List<string> _names;
		private List<byte> _forces;

        byte[] spc0 = new byte[2];
        byte[] pmap0 = new byte[2];

		public SpecialImageDesignated()
		{
			InitializeComponent();
			GetResourcesImageSpc();
            GetResourcesPmapobj();
		}
		private void SpecialImageDesignated_Load(object sender, EventArgs e)
		{
			ncOffset.Value = 0xD2800;
            pmapoffset.Value = 0xE1000;
			lbList.Items.Clear();
			_names = GameData.UnitNameList(true);
			_forces = GameData.UnitForce;
			lbList.Items.AddRange(_names.ToArray());
			var index = 0;
			cbType.Items.Clear();
			cbType.Items.Add(string.Format(Program.FORMATSTRING_KEYVALUEPAIR_HEX4, index++, "보통조형"));
			for (; index <= 32; index++)
			{
				cbType.Items.Add(string.Format(Program.FORMATSTRING_KEYVALUEPAIR_HEX4, index, "특수조형"));
			}
			var count = UnitSpc.GetImageLength();
			for (; index <= count; index++)
			{
				cbType.Items.Add(string.Format(Program.FORMATSTRING_KEYVALUEPAIR_HEX4, index, "특수조형"));
			}
		}

		private void btnLoadFile_Click(object sender, EventArgs e)
		{
			var ofd = new OpenFileDialog
			          {
			          	Filter = "조조전 실행파일|*.exe"
			          };
			if (DialogResult.OK != ofd.ShowDialog() || string.IsNullOrEmpty(ofd.FileName) || !File.Exists(ofd.FileName))
			{
				_fs = null;
				txtFileName.Text = string.Empty;
				btnSave.Enabled = lbList.Enabled = cbType.Enabled = rbtnCamp3.Enabled = rbtnCamp2.Enabled = rbtnCamp1.Enabled = ncPmapobj.Enabled = false;
				lbList.SelectedIndex = -1;
				return;
			}
			txtFileName.Text = ofd.FileName;
			try
			{
				_fs = new FileStream(ofd.FileName, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite);
                btnSave.Enabled = lbList.Enabled = cbType.Enabled = rbtnCamp3.Enabled = rbtnCamp2.Enabled = rbtnCamp1.Enabled = ncPmapobj.Enabled = true;
				lbList.SelectedIndex = 0;
				lbList_SelectedIndexChanged(lbList, new EventArgs());
				lbList.Focus();
			}
			catch (Exception ex)
			{
				_fs = null;
				txtFileName.Text = string.Empty;
				btnSave.Enabled = lbList.Enabled = cbType.Enabled = rbtnCamp3.Enabled = rbtnCamp2.Enabled = rbtnCamp1.Enabled = false;
				lbList.SelectedIndex = -1;
				Utils.ShowError(ex.Message);
				return;
			}
		}

		private void lbList_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (_fs == null || lbList.SelectedIndex < 0 || lbList.SelectedIndex >= lbList.Items.Count)
			{
				return;
			}
			_fs.Seek((int)ncOffset.Value+lbList.SelectedIndex*2, SeekOrigin.Begin);
            _fs.Read(spc0, 0, 2);
            cbType.SelectedIndex = spc0[0] + spc0[1]*0x100;
			cbType_SelectedIndexChanged(cbType, new EventArgs());
            _fs.Seek((int)pmapoffset.Value + lbList.SelectedIndex * 2, SeekOrigin.Begin);
            _fs.Read(pmap0, 0, 2);
            ncPmapobj.Value = pmap0[0] + pmap0[1] * 0x100;
            ncPmapobj_ValueChanged_1(ncPmapobj, new EventArgs());
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			if (_fs == null || lbList.SelectedIndex < 0 || lbList.SelectedIndex >= lbList.Items.Count)
			{
				return;
			}
            spc0 =  BitConverter.GetBytes(cbType.SelectedIndex);
			_fs.Seek((int)ncOffset.Value+lbList.SelectedIndex*2, SeekOrigin.Begin);
            _fs.Write(spc0, 0, 2);
            pmap0 = BitConverter.GetBytes((short)ncPmapobj.Value);
            _fs.Seek((int)pmapoffset.Value + lbList.SelectedIndex * 2, SeekOrigin.Begin);
            _fs.Write(pmap0, 0, 2);
		}

		private int GetParm2(int unitIndex)
		{
			var force = _forces[unitIndex];
			int value;
			switch (force)
			{
				case 0:
				case 1:
				case 2:
				{
					value = 0;
					break;
				}
				case 3:
				case 4:
				case 5:
				{
					value = 1;
					break;
				}
				case 6:
				case 7:
				case 8:
				{
					value = 2;
					break;
				}
				case 9:
				case 10:
				case 11:
				{
					value = 3;
					break;
				}
				case 12:
				case 13:
				case 14:
				{
					value = 4;
					break;
				}
				case 15:
				case 16:
				case 17:
				{
					value = 5;
					break;
				}
				case 18:
				case 19:
				case 20:
				{
					value = 6;
					break;
				}
				case 21:
				case 22:
				case 23:
				{
					value = 7;
					break;
				}
				case 24:
				case 25:
				case 26:
				{
					value = 8;
					break;
				}
				case 27:
				case 28:
				case 29:
				{
					value = 9;
					break;
				}
				case 30:
				case 31:
				case 32:
				{
					value = 10;
					break;
				}
				case 33:
				case 34:
				case 35:
				{
					value = 11;
					break;
				}
				case 36:
				case 37:
				case 38:
				{
					value = 12;

					break;
				}
				case 39:
                case 40:
                case 41:
				{
					value = 13;
					break;
				}
				case 42:
                case 43:
                case 44:
				{
					value = 14;
					break;
				}
				case 45:
                case 46:
                case 47:
				{
					value = 15;
					break;
				}
				case 48:
                case 49:
                case 50:
				{
					value = 16;
					break;
				}
				case 51:
                case 52:
                case 53:
				{
					value = 17;
					break;
				}
				case 54:
                case 55:
                case 56:
				{
					value = 18;
					break;
				}
				case 57:
                case 58:
                case 59:
				{
					value = 19;
					break;
				}
				case 60:
				{
					value = 20;
					break;
				}
				case 61:
				{
					value = 21;
					break;
				}
				case 62:
				{
					value = 22;
					break;
				}
				case 63:
				{
					value = 23;
					break;
				}
				case 64:
				{
					value = 24;
					break;
				}
				case 65:
				{
					value = 25;
					break;
				}
				case 66:
				{
					value = 26;
					break;
				}
                case 67:
                {
                    value = 27;
                    break;
                }
                case 68:
                {
                    value = 28;
                    break;
                }
                case 69:
                {
                    value = 29;
                    break;
                }
                case 70:
                {
                    value = 30;
                    break;
                }
                case 71:
                {
                    value = 31;
                    break;
                }
                case 72:
                {
                    value = 32;
                    break;
                }
                case 73:
                {
                    value = 33;
                    break;
                }
                case 74:
                {
                    value = 34;
                    break;
                }
                case 75:
                {
                    value = 35;
                    break;
                }
                case 76:
                {
                    value = 36;
                    break;
                }
                case 77:
                {
                    value = 37;
                    break;
                }
                case 78:
                {
                    value = 38;
                    break;
                }
                case 79:
                {
                    value = 39;
                    break;
                }
				default:
				{
					value = 0;
					break;
				}
			}
			return value;
		}

		private void cbType_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (_fs == null || lbList.SelectedIndex < 0 || lbList.SelectedIndex >= lbList.Items.Count || cbType.SelectedIndex < 0 || cbType.SelectedIndex >= cbType.Items.Count)
			{
				return;
			}
			var parm1 = cbType.SelectedIndex;
			var parm2 = GetParm2(lbList.SelectedIndex);
			KeyValuePair<int, Image>[] spc;
			if (parm1 == 0)
			{
				rbtnCamp1.Enabled = rbtnCamp2.Enabled = rbtnCamp3.Enabled = true;
				var parm3 = rbtnCamp1.Checked ? 0 : (rbtnCamp2.Checked ? 1 : (rbtnCamp3.Checked ? 2 : 0));
				spc = UnitSpc.GetImages(parm1, parm2, parm3);
			}
			else if (parm1 >= 1 && parm1 <= 32)
			{
				rbtnCamp1.Enabled = rbtnCamp2.Enabled = rbtnCamp3.Enabled = false;
				spc = UnitSpc.GetImages(parm1, 0, 0);
			}
			else
			{
				rbtnCamp1.Enabled = rbtnCamp2.Enabled = rbtnCamp3.Enabled = false;
				spc = UnitSpc.GetImages(parm1, 0, 0);
			}
			SetValueToControls(spc);
		}

		private void rbtnCamp_CheckedChanged(object sender, EventArgs e)
		{
			var parm1 = cbType.SelectedIndex;
			var parm2 = GetParm2(lbList.SelectedIndex);
			if (parm1 != 0)
			{
				pbSpc1.Image = pbSpc2.Image = pbSpc3.Image = null;
				return;
			}
			var parm3 = rbtnCamp1.Checked ? 0 : (rbtnCamp2.Checked ? 1 : (rbtnCamp3.Checked ? 2 : 0));
			var spc = UnitSpc.GetImages(parm1, parm2, parm3);
			SetValueToControls(spc);
		}

		private void SetValueToControls(KeyValuePair<int, Image>[] spc)
		{
			if (spc != null)
			{
				pbSpc1.Image = spc.Length > 0 ? spc[0].Value : null;
				lblSpc1.Text = spc.Length > 0 ? (spc[0].Key+1).ToString() : string.Empty;
				pbSpc2.Image = spc.Length > 1 ? spc[1].Value : null;
				lblSpc2.Text = spc.Length > 1 ? (spc[1].Key+1).ToString() : string.Empty;
				pbSpc3.Image = spc.Length > 2 ? spc[2].Value : null;
				lblSpc3.Text = spc.Length > 2 ? (spc[2].Key+1).ToString() : string.Empty;
			}
			else
			{
				pbSpc1.Image = pbSpc2.Image = pbSpc3.Image = null;
			}
		}

		private void btnSaveOffset_Click(object sender, EventArgs e)
		{
			//ConfigOperation.SystemConfig.SpecialImageDesignatedOffset = (int)ncOffset.Value;
            //ConfigOperation.SystemConfig.RSpecialImageDesignatedOffset = (int)pmapoffset.Value;
		}

        private void ncPmapobj_ValueChanged_1(object sender, EventArgs e)
        {
            if (Pmapobjs == null || lbList.SelectedIndex < 0)
            {
                return;
            }
            lblpmap1.Text = (ncPmapobj.Value * 2 + 1).ToString();
            lblpmap2.Text = (ncPmapobj.Value * 2 + 2).ToString();
            //pbpmap1.Image = Pmapobjs.GetImage((int)ncPmapobj.Value);
            //pbpmap2.Image = Pmapobjs.GetImage((int)ncPmapobj.Value);
        }
	}
}