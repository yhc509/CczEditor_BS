#region using List

using System;

#endregion
using System.Linq;
using System.Windows.Forms;

namespace CczEditor.Controls.DataControls
{
	public partial class TerrainController : BaseDataControl
	{
        private Data.Wrapper.TerrainData CurrentData;

        NumericControl[] ControlList;

        public TerrainController()
		{
			InitializeComponent();
		}

		private void TerrainData_Load(object sender, EventArgs e)
		{
            lbList.Items.AddRange(ConfigUtils.GetForceCategoryNames(Program.ExeData, Program.CurrentConfig, Program.FORMATSTRING_KEYVALUEPAIR_HEX2).Values.ToArray());
            
            ControlList = new NumericControl[]
            {
                ncTerrain01, ncTerrain02, ncTerrain03, ncTerrain04, ncTerrain05, ncTerrain06, ncTerrain07, ncTerrain08, ncTerrain09, ncTerrain10,
                ncTerrain11, ncTerrain12, ncTerrain13, ncTerrain14, ncTerrain15, ncTerrain16, ncTerrain17, ncTerrain18, ncTerrain19, ncTerrain20,
                ncTerrain21, ncTerrain22, ncTerrain23, ncTerrain24, ncTerrain25, ncTerrain26, ncTerrain27, ncTerrain28, ncTerrain29, ncTerrain30,

                ncMobility01, ncMobility02, ncMobility03, ncMobility04, ncMobility05, ncMobility06, ncMobility07, ncMobility08, ncMobility09, ncMobility10,
                ncMobility11, ncMobility12, ncMobility13, ncMobility14, ncMobility15, ncMobility16, ncMobility17, ncMobility18, ncMobility19, ncMobility20,
                ncMobility21, ncMobility22, ncMobility23, ncMobility24, ncMobility25, ncMobility26, ncMobility27, ncMobility28, ncMobility29, ncMobility30
            };
            
        }

        public override void Reset()
        {
            base.Reset();
            CurrentData = new Data.Wrapper.TerrainData();

            lbList.SelectedIndex = 0;
            lbList.Focus();
        }


        private void lbList_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (lbList.SelectedIndex < 0 || lbList.SelectedIndex >= lbList.Items.Count)
			{
				return;
			}
            int index = lbList.SelectedIndex;
            CurrentData.Read(index, Program.GameData, Program.ImsgData, Program.ExeData, Program.CurrentConfig);

            for (int i = 0; i < ControlList.Length; i++)
            {
                ControlList[i].Value = CurrentData.Values[i];
            }
            
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
            


            for (int i = 0; i < ControlList.Length; i++)
            {
                CurrentData.Values[i] = (byte)ControlList[i].Value;
            }
            
            CurrentData.Write(index, Program.GameData, Program.ImsgData, Program.ExeData, Program.CurrentConfig);
        }

		private void btnRestore_Click(object sender, EventArgs e)
		{
			lbList_SelectedIndexChanged(lbList, new EventArgs());
		}

        private void searchButton_Click(object sender, EventArgs e)
        {
            var list = ConfigUtils.GetForceCategoryNames(Program.ExeData, Program.CurrentConfig).Values.ToList();
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