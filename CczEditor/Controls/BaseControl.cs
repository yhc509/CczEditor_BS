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
        }

        public bool GameDataLoaded
        {
            get { return Program.GameData != null; }
        }

        public bool ImsgDataLoaded
        {
            get { return Program.ImsgData != null; }
        }

        public bool StarDataLoaded
        {
            get { return Program.StarData != null; }
        }


        public virtual void Reset()
        {

        }

        protected void GetResourcesItemIcon()
        {
            if (ItemIcons != null)
            {
                return;
            }

            string path;
            if (Program.CurrentConfig.UseE5Directory)
                path = Path.Combine(Program.GameData.CurrentFile.DirectoryName, "E5", Program.FILENAME_ITEM);
            else
                path = Path.Combine(Program.GameData.CurrentFile.DirectoryName, Program.FILENAME_ITEM);
            ItemIcons = new ItemResources(path);
            
        }

        protected void GetResourcesFace()
        {
            if (Faces != null)
            {
                return;
            }

            string path;
            if (Program.CurrentConfig.UseE5Directory)
                path = Path.Combine(Program.GameData.CurrentFile.DirectoryName, "E5", Program.FILENAME_FACE);
            else
                path = Path.Combine(Program.GameData.CurrentFile.DirectoryName, Program.FILENAME_FACE);
            Faces = new FaceResources(path);
            
        }

        protected void GetResourcesFaceLarge()
        {
            if (FaceLarges != null)
            {
                return;
            }

            string path;
            if (Program.CurrentConfig.UseE5Directory)
                path = Path.Combine(Program.GameData.CurrentFile.DirectoryName, "E5", Program.FILENAME_FACE_LARGE);
            else
                path = Path.Combine(Program.GameData.CurrentFile.DirectoryName, Program.FILENAME_FACE_LARGE);
            FaceLarges = new FaceResources(path);
            
        }


        protected void GetResourcesPmapobj()
        {
            if (Pmapobjs != null)
            {
                return;
            }

            string path = Path.Combine(Program.GameData.CurrentFile.DirectoryName, Program.FILENAME_PMAPOBJ);
            Pmapobjs = new PmapobjResources(path);
            
        }

        protected void GetResourcesHitarea()
        {
            if (Hitareas != null)
            {
                return;
            }

            string path;
            if (Program.CurrentConfig.UseE5Directory)
                path = Path.Combine(Program.GameData.CurrentFile.DirectoryName, "E5", Program.FILENAME_HITAREA);
            else
                path = Path.Combine(Program.GameData.CurrentFile.DirectoryName, Program.FILENAME_HITAREA);
            Hitareas = new HitareaResources(path);
        }

        protected void GetResourcesEffarea()
        {
            if (Effareas != null)
            {
                return;
            }

            string path;
            if (Program.CurrentConfig.UseE5Directory)
                path = Path.Combine(Program.GameData.CurrentFile.DirectoryName, "E5", Program.FILENAME_EFFAREA);
            else
                path = Path.Combine(Program.GameData.CurrentFile.DirectoryName, Program.FILENAME_EFFAREA);
            Effareas = new EffareaResources(path);
        }

        protected void GetResourcesImageAtk()
        {
            if (UnitAtk != null)
            {
                return;
            }

            string path = Path.Combine(Program.GameData.CurrentFile.DirectoryName, Program.FILENAME_IMAGEATK);
            UnitAtk = new UnitAtkResources(path);
        }

        protected void GetResourcesImageMov()
        {
            if (UnitMov != null)
            {
                return;
            }

            string path = Path.Combine(Program.GameData.CurrentFile.DirectoryName, Program.FILENAME_IMAGEMOV);
            UnitMov = new UnitMovResources(path);
        }

        protected void GetResourcesImageSpc()
        {
            if (UnitSpc != null)
            {
                return;
            }

            string path = Path.Combine(Program.GameData.CurrentFile.DirectoryName, Program.FILENAME_IMAGESPC);
            UnitSpc = new UnitSpcResources(path);
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