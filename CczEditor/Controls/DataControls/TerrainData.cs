#region using List

using System;

#endregion
using System.Linq;
using System.Windows.Forms;

namespace CczEditor.Controls.DataControls
{
	public partial class TerrainData : BaseDataControl
	{
		public TerrainData()
		{
			InitializeComponent();
		}

		private void TerrainData_Load(object sender, EventArgs e)
		{
            lbList.Items.AddRange(ConfigUtils.GetForceCategoryNames(Program.FORMATSTRING_KEYVALUEPAIR_HEX2).Values.ToArray());
			lbList.SelectedIndex = 0;
			lbList.Focus();
		}

		private void lbList_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (lbList.SelectedIndex < 0 || lbList.SelectedIndex >= lbList.Items.Count)
			{
				return;
			}
			var terrain = Program.GameData.TerrainGet(lbList.SelectedIndex);
			ncTerrain01.Value = terrain[0];
			ncTerrain02.Value = terrain[1];
			ncTerrain03.Value = terrain[2];
			ncTerrain04.Value = terrain[3];
			ncTerrain05.Value = terrain[4];
			ncTerrain06.Value = terrain[5];
			ncTerrain07.Value = terrain[6];
			ncTerrain08.Value = terrain[7];
			ncTerrain09.Value = terrain[8];
			ncTerrain10.Value = terrain[9];
			ncTerrain11.Value = terrain[10];
			ncTerrain12.Value = terrain[11];
			ncTerrain13.Value = terrain[12];
			ncTerrain14.Value = terrain[13];
			ncTerrain15.Value = terrain[14];
			ncTerrain16.Value = terrain[15];
			ncTerrain17.Value = terrain[16];
			ncTerrain18.Value = terrain[17];
			ncTerrain19.Value = terrain[18];
			ncTerrain20.Value = terrain[19];
			ncTerrain21.Value = terrain[20];
			ncTerrain22.Value = terrain[21];
			ncTerrain23.Value = terrain[22];
			ncTerrain24.Value = terrain[23];
			ncTerrain25.Value = terrain[24];
			ncTerrain26.Value = terrain[25];
			ncTerrain27.Value = terrain[26];
			ncTerrain28.Value = terrain[27];
			ncTerrain29.Value = terrain[28];
			ncTerrain30.Value = terrain[29];
			ncMobility01.Value = terrain[30];
			ncMobility02.Value = terrain[31];
			ncMobility03.Value = terrain[32];
			ncMobility04.Value = terrain[33];
			ncMobility05.Value = terrain[34];
			ncMobility06.Value = terrain[35];
			ncMobility07.Value = terrain[36];
			ncMobility08.Value = terrain[37];
			ncMobility09.Value = terrain[38];
			ncMobility10.Value = terrain[39];
			ncMobility11.Value = terrain[40];
			ncMobility12.Value = terrain[41];
			ncMobility13.Value = terrain[42];
			ncMobility14.Value = terrain[43];
			ncMobility15.Value = terrain[44];
			ncMobility16.Value = terrain[45];
			ncMobility17.Value = terrain[46];
			ncMobility18.Value = terrain[47];
			ncMobility19.Value = terrain[48];
			ncMobility20.Value = terrain[49];
			ncMobility21.Value = terrain[50];
			ncMobility22.Value = terrain[51];
			ncMobility23.Value = terrain[52];
			ncMobility24.Value = terrain[53];
			ncMobility25.Value = terrain[54];
			ncMobility26.Value = terrain[55];
			ncMobility27.Value = terrain[56];
			ncMobility28.Value = terrain[57];
			ncMobility29.Value = terrain[58];
			ncMobility30.Value = terrain[59];
			if (TopLevelControl != null)
			{
				TopLevelControl.Text = string.Format("{1} - 지형 편집 - 번호：{0}", lbList.SelectedIndex, Program.TitleNameCurrent);
			}
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			if (lbList.SelectedIndex < 0 || lbList.SelectedIndex >= lbList.Items.Count)
			{
				return;
			}
			var index = lbList.SelectedIndex;
			var terrain = Program.GameData.TerrainGet(index);
			terrain[0] = (byte)ncTerrain01.Value;
			terrain[1] = (byte)ncTerrain02.Value;
			terrain[2] = (byte)ncTerrain03.Value;
			terrain[3] = (byte)ncTerrain04.Value;
			terrain[4] = (byte)ncTerrain05.Value;
			terrain[5] = (byte)ncTerrain06.Value;
			terrain[6] = (byte)ncTerrain07.Value;
			terrain[7] = (byte)ncTerrain08.Value;
			terrain[8] = (byte)ncTerrain09.Value;
			terrain[9] = (byte)ncTerrain10.Value;
			terrain[10] = (byte)ncTerrain11.Value;
			terrain[11] = (byte)ncTerrain12.Value;
			terrain[12] = (byte)ncTerrain13.Value;
			terrain[13] = (byte)ncTerrain14.Value;
			terrain[14] = (byte)ncTerrain15.Value;
			terrain[15] = (byte)ncTerrain16.Value;
			terrain[16] = (byte)ncTerrain17.Value;
			terrain[17] = (byte)ncTerrain18.Value;
			terrain[18] = (byte)ncTerrain19.Value;
			terrain[19] = (byte)ncTerrain20.Value;
			terrain[20] = (byte)ncTerrain21.Value;
			terrain[21] = (byte)ncTerrain22.Value;
			terrain[22] = (byte)ncTerrain23.Value;
			terrain[23] = (byte)ncTerrain24.Value;
			terrain[24] = (byte)ncTerrain25.Value;
			terrain[25] = (byte)ncTerrain26.Value;
			terrain[26] = (byte)ncTerrain27.Value;
			terrain[27] = (byte)ncTerrain28.Value;
			terrain[28] = (byte)ncTerrain29.Value;
			terrain[29] = (byte)ncTerrain30.Value;
			terrain[30] = (byte)ncMobility01.Value;
			terrain[31] = (byte)ncMobility02.Value;
			terrain[32] = (byte)ncMobility03.Value;
			terrain[33] = (byte)ncMobility04.Value;
			terrain[34] = (byte)ncMobility05.Value;
			terrain[35] = (byte)ncMobility06.Value;
			terrain[36] = (byte)ncMobility07.Value;
			terrain[37] = (byte)ncMobility08.Value;
			terrain[38] = (byte)ncMobility09.Value;
			terrain[39] = (byte)ncMobility10.Value;
			terrain[40] = (byte)ncMobility11.Value;
			terrain[41] = (byte)ncMobility12.Value;
			terrain[42] = (byte)ncMobility13.Value;
			terrain[43] = (byte)ncMobility14.Value;
			terrain[44] = (byte)ncMobility15.Value;
			terrain[45] = (byte)ncMobility16.Value;
			terrain[46] = (byte)ncMobility17.Value;
			terrain[47] = (byte)ncMobility18.Value;
			terrain[48] = (byte)ncMobility19.Value;
			terrain[49] = (byte)ncMobility20.Value;
			terrain[50] = (byte)ncMobility21.Value;
			terrain[51] = (byte)ncMobility22.Value;
			terrain[52] = (byte)ncMobility23.Value;
			terrain[53] = (byte)ncMobility24.Value;
			terrain[54] = (byte)ncMobility25.Value;
			terrain[55] = (byte)ncMobility26.Value;
			terrain[56] = (byte)ncMobility27.Value;
			terrain[57] = (byte)ncMobility28.Value;
			terrain[58] = (byte)ncMobility29.Value;
			terrain[59] = (byte)ncMobility30.Value;
            Program.GameData.TerrainSet(index, terrain);
		}

		private void btnRestore_Click(object sender, EventArgs e)
		{
			lbList_SelectedIndexChanged(lbList, new EventArgs());
		}

        private void searchButton_Click(object sender, EventArgs e)
        {
            var list = ConfigUtils.GetForceCategoryNames(null).Values.ToList();
            var index = list.FindIndex(x => x == searchTextBox.Text);
            if (index == -1)
            {
                MessageBox.Show("찾기에 실패했습니다.", "경고", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            lbList.SelectedIndex = index;
        }
    }
}