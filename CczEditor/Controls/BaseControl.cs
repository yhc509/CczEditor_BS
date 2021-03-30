#region using List

using System.IO;
using System.Windows.Forms;

using CczEditor.Data;
using CczEditor.Resources;

#endregion

namespace CczEditor.Controls
{
    /// <summary>
    /// 自定义控件基类
    /// </summary>
    public class BaseControl : UserControl
    {
        protected ExeData ExeData;
        protected GameData GameData;
        protected StarData StarData;
        protected ImsgData ImsgData;

        protected HitareaResources Hitareas;
        protected EffareaResources Effareas;
        protected FaceResources Faces;
        protected FaceResources FaceLarges;
        protected PmapobjResources Pmapobjs;
        protected ItemResources ItemIcons;
        protected UnitAtkResources UnitAtk;
        protected UnitMovResources UnitMov;
        private Label label1;
        protected UnitSpcResources UnitSpc;

        protected BaseControl()
        {
            Width = 794;
            Height = 550;
            if (Program.GameData != null)
            {
                GameData = Program.GameData;
            }
            else
            {
                Program.LoadGameData();
                GameData = Program.GameData;
            }
            if (Program.ImsgData != null)
            {
                ImsgData = Program.ImsgData;
            }
            else
            {
                Program.LoadImsgData();
                ImsgData = Program.ImsgData;
            }
            if (Program.StarData != null)
            {
                StarData = Program.StarData;
            }
            else
            {
                Program.LoadStarData();
                StarData = Program.StarData;
            }            
            if (Program.ExeData != null)
            {
                Program.LoadExeData();
                ExeData = Program.ExeData;
            }
            else
            {
                Program.LoadExeData();
                ExeData = Program.ExeData;
            }

        }

        public bool GameDataLoaded
        {
            get { return GameData != null && GameData.CurrentFile != null && GameData.CurrentStream != null; }
        }

        public bool ImsgDataLoaded
        {
            get { return ImsgData != null && ImsgData.CurrentFile != null && ImsgData.CurrentStream != null; }
        }

        public bool ExeDataLoaded
        {
            get { return ExeData != null && ExeData.CurrentFile != null && ExeData.CurrentStream != null; }
        }

        public bool StarDataLoaded
        {
            get { return StarData != null && StarData.CurrentFile != null && StarData.CurrentStream != null; }
        }
        protected void GetResourcesItemIcon()
        {
            if (ItemIcons != null)
            {
                return;
            }
            if (GameData != null && GameData.CurrentFile != null && !string.IsNullOrEmpty(GameData.CurrentFile.DirectoryName))
            {
                ItemIcons = new ItemResources(Path.Combine(GameData.CurrentFile.DirectoryName, Program.FILENAME_ITEM));
            }
            else if (ImsgData != null && ImsgData.CurrentFile != null && !string.IsNullOrEmpty(ImsgData.CurrentFile.DirectoryName))
            {
                ItemIcons = new ItemResources(Path.Combine(ImsgData.CurrentFile.DirectoryName, Program.FILENAME_ITEM));
            }
            else if (Program.CurrentConfig != null && !string.IsNullOrEmpty(Program.CurrentConfig.DataFileDirectory) && Directory.Exists(Program.CurrentConfig.DataFileDirectory))
            {
                ItemIcons = new ItemResources(Path.Combine(Program.CurrentConfig.DataFileDirectory, Program.FILENAME_ITEM));
            }
        }

        protected void GetResourcesFace()
        {
            if (Faces != null)
            {
                return;
            }
            if (GameData != null && GameData.CurrentFile != null && !string.IsNullOrEmpty(GameData.CurrentFile.DirectoryName))
            {
                Faces = new FaceResources(Path.Combine(GameData.CurrentFile.DirectoryName, Program.FILENAME_FACE));
            }
            else if (ImsgData != null && ImsgData.CurrentFile != null && !string.IsNullOrEmpty(ImsgData.CurrentFile.DirectoryName))
            {
                Faces = new FaceResources(Path.Combine(ImsgData.CurrentFile.DirectoryName, Program.FILENAME_FACE));
            }
            else if (Program.CurrentConfig != null && !string.IsNullOrEmpty(Program.CurrentConfig.DataFileDirectory) && Directory.Exists(Program.CurrentConfig.DataFileDirectory))
            {
                Faces = new FaceResources(Path.Combine(Program.CurrentConfig.DataFileDirectory, Program.FILENAME_FACE));
            }
        }

        protected void GetResourcesFaceLarge()
        {
            if (FaceLarges != null)
            {
                return;
            }
            if (GameData != null && GameData.CurrentFile != null && !string.IsNullOrEmpty(GameData.CurrentFile.DirectoryName))
            {
                FaceLarges = new FaceResources(Path.Combine(GameData.CurrentFile.DirectoryName, Program.FILENAME_FACE_LARGE));
            }
            else if (ImsgData != null && ImsgData.CurrentFile != null && !string.IsNullOrEmpty(ImsgData.CurrentFile.DirectoryName))
            {
                FaceLarges = new FaceResources(Path.Combine(ImsgData.CurrentFile.DirectoryName, Program.FILENAME_FACE_LARGE));
            }
            else if (Program.CurrentConfig != null && !string.IsNullOrEmpty(Program.CurrentConfig.DataFileDirectory) && Directory.Exists(Program.CurrentConfig.DataFileDirectory))
            {
                FaceLarges = new FaceResources(Path.Combine(Program.CurrentConfig.DataFileDirectory, Program.FILENAME_FACE_LARGE));
            }
        }


        protected void GetResourcesPmapobj()
        {
            if (Pmapobjs != null)
            {
                return;
            }
            if (GameData != null && GameData.CurrentFile != null && !string.IsNullOrEmpty(GameData.CurrentFile.DirectoryName))
            {
                Pmapobjs = new PmapobjResources(Path.Combine(GameData.CurrentFile.DirectoryName, Program.FILENAME_PMAPOBJ));
            }
            else if (ImsgData != null && ImsgData.CurrentFile != null && !string.IsNullOrEmpty(ImsgData.CurrentFile.DirectoryName))
            {
                Pmapobjs = new PmapobjResources(Path.Combine(ImsgData.CurrentFile.DirectoryName, Program.FILENAME_PMAPOBJ));
            }
            else if (Program.CurrentConfig != null && !string.IsNullOrEmpty(Program.CurrentConfig.DataFileDirectory) && Directory.Exists(Program.CurrentConfig.DataFileDirectory))
            {
                Pmapobjs = new PmapobjResources(Path.Combine(Program.CurrentConfig.DataFileDirectory, Program.FILENAME_PMAPOBJ));
            }
        }

        protected void GetResourcesHitarea()
        {
            if (Hitareas != null)
            {
                return;
            }
            if (GameData != null && GameData.CurrentFile != null && !string.IsNullOrEmpty(GameData.CurrentFile.DirectoryName))
            {
                Hitareas = new HitareaResources(Path.Combine(GameData.CurrentFile.DirectoryName, Program.FILENAME_HITAREA));
            }
            else if (ImsgData != null && ImsgData.CurrentFile != null && !string.IsNullOrEmpty(ImsgData.CurrentFile.DirectoryName))
            {
                Hitareas = new HitareaResources(Path.Combine(ImsgData.CurrentFile.DirectoryName, Program.FILENAME_HITAREA));
            }
            else if (Program.CurrentConfig != null && !string.IsNullOrEmpty(Program.CurrentConfig.DataFileDirectory) && Directory.Exists(Program.CurrentConfig.DataFileDirectory))
            {
                Hitareas = new HitareaResources(Path.Combine(Program.CurrentConfig.DataFileDirectory, Program.FILENAME_HITAREA));
            }
        }

        protected void GetResourcesEffarea()
        {
            if (Effareas != null)
            {
                return;
            }
            if (GameData != null && GameData.CurrentFile != null && !string.IsNullOrEmpty(GameData.CurrentFile.DirectoryName))
            {
                Effareas = new EffareaResources(Path.Combine(GameData.CurrentFile.DirectoryName, Program.FILENAME_EFFAREA));
            }
            else if (ImsgData != null && ImsgData.CurrentFile != null && !string.IsNullOrEmpty(ImsgData.CurrentFile.DirectoryName))
            {
                Effareas = new EffareaResources(Path.Combine(ImsgData.CurrentFile.DirectoryName, Program.FILENAME_EFFAREA));
            }
            else if (Program.CurrentConfig != null && !string.IsNullOrEmpty(Program.CurrentConfig.DataFileDirectory) && Directory.Exists(Program.CurrentConfig.DataFileDirectory))
            {
                Effareas = new EffareaResources(Path.Combine(Program.CurrentConfig.DataFileDirectory, Program.FILENAME_EFFAREA));
            }
        }

        protected void GetResourcesImageAtk()
        {
            if (Effareas != null)
            {
                return;
            }
            if (GameData != null && GameData.CurrentFile != null && !string.IsNullOrEmpty(GameData.CurrentFile.DirectoryName))
            {
                UnitAtk = new UnitAtkResources(Path.Combine(GameData.CurrentFile.DirectoryName, Program.FILENAME_IMAGEATK));
            }
            else if (ImsgData != null && ImsgData.CurrentFile != null && !string.IsNullOrEmpty(ImsgData.CurrentFile.DirectoryName))
            {
                UnitAtk = new UnitAtkResources(Path.Combine(ImsgData.CurrentFile.DirectoryName, Program.FILENAME_IMAGEATK));
            }
            else if (Program.CurrentConfig != null && !string.IsNullOrEmpty(Program.CurrentConfig.DataFileDirectory) && Directory.Exists(Program.CurrentConfig.DataFileDirectory))
            {
                UnitAtk = new UnitAtkResources(Path.Combine(Program.CurrentConfig.DataFileDirectory, Program.FILENAME_IMAGEATK));
            }
        }

        protected void GetResourcesImageMov()
        {
            if (Effareas != null)
            {
                return;
            }
            if (GameData != null && GameData.CurrentFile != null && !string.IsNullOrEmpty(GameData.CurrentFile.DirectoryName))
            {
                UnitMov = new UnitMovResources(Path.Combine(GameData.CurrentFile.DirectoryName, Program.FILENAME_IMAGEMOV));
            }
            else if (ImsgData != null && ImsgData.CurrentFile != null && !string.IsNullOrEmpty(ImsgData.CurrentFile.DirectoryName))
            {
                UnitMov = new UnitMovResources(Path.Combine(ImsgData.CurrentFile.DirectoryName, Program.FILENAME_IMAGEMOV));
            }
            else if (Program.CurrentConfig != null && !string.IsNullOrEmpty(Program.CurrentConfig.DataFileDirectory) && Directory.Exists(Program.CurrentConfig.DataFileDirectory))
            {
                UnitMov = new UnitMovResources(Path.Combine(Program.CurrentConfig.DataFileDirectory, Program.FILENAME_IMAGEMOV));
            }
        }

        protected void GetResourcesImageSpc()
        {
            if (Effareas != null)
            {
                return;
            }
            if (GameData != null && GameData.CurrentFile != null && !string.IsNullOrEmpty(GameData.CurrentFile.DirectoryName))
            {
                UnitSpc = new UnitSpcResources(Path.Combine(GameData.CurrentFile.DirectoryName, Program.FILENAME_IMAGESPC));
            }
            else if (ImsgData != null && ImsgData.CurrentFile != null && !string.IsNullOrEmpty(ImsgData.CurrentFile.DirectoryName))
            {
                UnitSpc = new UnitSpcResources(Path.Combine(ImsgData.CurrentFile.DirectoryName, Program.FILENAME_IMAGESPC));
            }
            else if (Program.CurrentConfig != null && !string.IsNullOrEmpty(Program.CurrentConfig.DataFileDirectory) && Directory.Exists(Program.CurrentConfig.DataFileDirectory))
            {
                UnitSpc = new UnitSpcResources(Path.Combine(Program.CurrentConfig.DataFileDirectory, Program.FILENAME_IMAGESPC));
            }
        }

        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(247, 250);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(334, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "조조전 모드 세상 -- http://cafe.naver.com/angsam";
            // 
            // BaseControl
            // 
            this.Controls.Add(this.label1);
            this.Name = "BaseControl";
            this.Size = new System.Drawing.Size(850, 550);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

    }
}