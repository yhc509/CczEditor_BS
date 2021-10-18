using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CczEditor
{
    public class Bs12ConfigCreateHandler : Bs11ConfigCreateHandler
    {

        protected override void CreateBaseInfo()
        {
            result.VersionName = "BS 1.2";
            if (result.DisplayName == null) result.DisplayName = "비상조조전 1.2";
            result.DirectoryPath = string.Empty;
            result.ExeFileName = "Ekd5.exe";
            result.UseE5Directory = false;
        }

        protected override void CreateDataSettings()
        {
            base.CreateDataSettings();
            
            result.Data.ForceCount = 0x78;
            result.Data.ForceOffset = 0x9DB4;
            result.Data.ForceLength = 0x23;
            
            result.Data.MagicOffset = 0xC0DC;
            result.Data.MagicLength = 0x89;

            result.Data.TerrainOffset = 0xAE1C;
        }

        protected override void CreateImsgSettings()
        {
            result.Imsg.ForceOffset = 0x11170;
            result.Imsg.UnitOriginalOffset = 0x15F90;
            result.Imsg.UnitExtensionOffset = 0x2D050;
            result.Imsg.RetreatOffset = 0x1FBD0;
            result.Imsg.CriticalOffset = 0x222E0;
            result.Imsg.StaffOffset = 0x27100;
        }

        protected override void CreateExeSettings()
        {
            base.CreateExeSettings();
            
            
            result.Exe.SpecialSkillForceOffset = 0xA3A00;
            
            result.Exe.Force.AtkEffectOffset = 0x14A900;
            result.Exe.Force.MoveSoundOffset = 0x14A980;
            result.Exe.Force.MoveSpeedOffset = 0x14AA00;
            result.Exe.Force.AtkSoundOffset = 0x14AA90;
            result.Exe.Force.AtkTypeOffset = 0x14AB00;
            result.Exe.Force.TypeOffset = 0x14AB80;
            result.Exe.Force.MagicDamageOffset = 0x14AC00;
            result.Exe.Force.AtkDelayOffset = 0x14AC80;
            result.Exe.Force.AtkPincOffset = 0x14AD00;
            result.Exe.Force.SynastryOffset = 0x14AD80;        
            result.Exe.Force.AiTypeOffset = 0x14C680;
            
        }


        protected override void CreateForceNames()
        {
            result.ForceNames.Add(new Config.ConfigForceNameInfos { Index = 0, Length = 8, Offset = 0xD18D0 });
            result.ForceNames.Add(new Config.ConfigForceNameInfos { Index = 1, Length = 8, Offset = 0xD18D9 });
            result.ForceNames.Add(new Config.ConfigForceNameInfos { Index = 2, Length = 8, Offset = 0xD18E2 });
            result.ForceNames.Add(new Config.ConfigForceNameInfos { Index = 3, Length = 8, Offset = 0xD18EB });
            result.ForceNames.Add(new Config.ConfigForceNameInfos { Index = 4, Length = 8, Offset = 0xD18F4 });
            result.ForceNames.Add(new Config.ConfigForceNameInfos { Index = 5, Length = 8, Offset = 0xD18FD });
            result.ForceNames.Add(new Config.ConfigForceNameInfos { Index = 6, Length = 8, Offset = 0xD1906 });
            result.ForceNames.Add(new Config.ConfigForceNameInfos { Index = 7, Length = 8, Offset = 0xD190F });
            result.ForceNames.Add(new Config.ConfigForceNameInfos { Index = 8, Length = 8, Offset = 0xD1918 });
            result.ForceNames.Add(new Config.ConfigForceNameInfos { Index = 9, Length = 8, Offset = 0xD1921 });
            result.ForceNames.Add(new Config.ConfigForceNameInfos { Index = 10, Length = 8, Offset = 0xD192A });

            result.ForceNames.Add(new Config.ConfigForceNameInfos { Index = 11, Length = 8, Offset = 0xD1933 });
            result.ForceNames.Add(new Config.ConfigForceNameInfos { Index = 12, Length = 8, Offset = 0xD193C });
            result.ForceNames.Add(new Config.ConfigForceNameInfos { Index = 13, Length = 8, Offset = 0xD1945 });
            result.ForceNames.Add(new Config.ConfigForceNameInfos { Index = 14, Length = 8, Offset = 0xD194E });
            result.ForceNames.Add(new Config.ConfigForceNameInfos { Index = 15, Length = 8, Offset = 0xD1957 });
            result.ForceNames.Add(new Config.ConfigForceNameInfos { Index = 16, Length = 8, Offset = 0xD1960 });
            result.ForceNames.Add(new Config.ConfigForceNameInfos { Index = 17, Length = 8, Offset = 0xD1969 });
            result.ForceNames.Add(new Config.ConfigForceNameInfos { Index = 18, Length = 8, Offset = 0xD1972 });
            result.ForceNames.Add(new Config.ConfigForceNameInfos { Index = 19, Length = 8, Offset = 0xD197B });
            result.ForceNames.Add(new Config.ConfigForceNameInfos { Index = 20, Length = 8, Offset = 0xD1984 });

            result.ForceNames.Add(new Config.ConfigForceNameInfos { Index = 21, Length = 8, Offset = 0xD198D });
            result.ForceNames.Add(new Config.ConfigForceNameInfos { Index = 22, Length = 8, Offset = 0xD1996 });
            result.ForceNames.Add(new Config.ConfigForceNameInfos { Index = 23, Length = 8, Offset = 0xD199F });
            result.ForceNames.Add(new Config.ConfigForceNameInfos { Index = 24, Length = 8, Offset = 0xD19A8 });
            result.ForceNames.Add(new Config.ConfigForceNameInfos { Index = 25, Length = 8, Offset = 0xD19B1 });
            result.ForceNames.Add(new Config.ConfigForceNameInfos { Index = 26, Length = 8, Offset = 0xD19BA });
            result.ForceNames.Add(new Config.ConfigForceNameInfos { Index = 27, Length = 8, Offset = 0xD19C3 });
            result.ForceNames.Add(new Config.ConfigForceNameInfos { Index = 28, Length = 8, Offset = 0xD19CC });
            result.ForceNames.Add(new Config.ConfigForceNameInfos { Index = 29, Length = 8, Offset = 0xD19D5 });
            result.ForceNames.Add(new Config.ConfigForceNameInfos { Index = 30, Length = 8, Offset = 0xD19DE });

            result.ForceNames.Add(new Config.ConfigForceNameInfos { Index = 31, Length = 8, Offset = 0xD19E7 });
            result.ForceNames.Add(new Config.ConfigForceNameInfos { Index = 32, Length = 8, Offset = 0xD19F0 });
            result.ForceNames.Add(new Config.ConfigForceNameInfos { Index = 33, Length = 8, Offset = 0xD19F9 });
            result.ForceNames.Add(new Config.ConfigForceNameInfos { Index = 34, Length = 8, Offset = 0xD1A02 });
            result.ForceNames.Add(new Config.ConfigForceNameInfos { Index = 35, Length = 8, Offset = 0xD1A0B });
            result.ForceNames.Add(new Config.ConfigForceNameInfos { Index = 36, Length = 8, Offset = 0xD1A14 });
            result.ForceNames.Add(new Config.ConfigForceNameInfos { Index = 37, Length = 8, Offset = 0xD1A1D });
            result.ForceNames.Add(new Config.ConfigForceNameInfos { Index = 38, Length = 8, Offset = 0xD1A26 });
            result.ForceNames.Add(new Config.ConfigForceNameInfos { Index = 39, Length = 8, Offset = 0xD1A2F });
            result.ForceNames.Add(new Config.ConfigForceNameInfos { Index = 40, Length = 8, Offset = 0xD1A38 });

            result.ForceNames.Add(new Config.ConfigForceNameInfos { Index = 41, Length = 8, Offset = 0xD1A41 });
            result.ForceNames.Add(new Config.ConfigForceNameInfos { Index = 42, Length = 8, Offset = 0xD1A4A });
            result.ForceNames.Add(new Config.ConfigForceNameInfos { Index = 43, Length = 8, Offset = 0xD1A53 });
            result.ForceNames.Add(new Config.ConfigForceNameInfos { Index = 44, Length = 8, Offset = 0xD1A5C });
            result.ForceNames.Add(new Config.ConfigForceNameInfos { Index = 45, Length = 8, Offset = 0xD1A65 });
            result.ForceNames.Add(new Config.ConfigForceNameInfos { Index = 46, Length = 8, Offset = 0xD1A6E });
            result.ForceNames.Add(new Config.ConfigForceNameInfos { Index = 47, Length = 8, Offset = 0xD1A77 });
            result.ForceNames.Add(new Config.ConfigForceNameInfos { Index = 48, Length = 8, Offset = 0xD1A80 });
            result.ForceNames.Add(new Config.ConfigForceNameInfos { Index = 49, Length = 8, Offset = 0xD1A89 });
            result.ForceNames.Add(new Config.ConfigForceNameInfos { Index = 50, Length = 8, Offset = 0xD1A92 });

            result.ForceNames.Add(new Config.ConfigForceNameInfos { Index = 51, Length = 8, Offset = 0xD1A9B });
            result.ForceNames.Add(new Config.ConfigForceNameInfos { Index = 52, Length = 8, Offset = 0xD1AA4 });
            result.ForceNames.Add(new Config.ConfigForceNameInfos { Index = 53, Length = 8, Offset = 0xD1AAD });
            result.ForceNames.Add(new Config.ConfigForceNameInfos { Index = 54, Length = 8, Offset = 0xD1AB6 });
            result.ForceNames.Add(new Config.ConfigForceNameInfos { Index = 55, Length = 8, Offset = 0xD1ABF });
            result.ForceNames.Add(new Config.ConfigForceNameInfos { Index = 56, Length = 8, Offset = 0xD1AC8 });
            result.ForceNames.Add(new Config.ConfigForceNameInfos { Index = 57, Length = 8, Offset = 0xD1AD1 });
            result.ForceNames.Add(new Config.ConfigForceNameInfos { Index = 58, Length = 8, Offset = 0xD1ADA });
            result.ForceNames.Add(new Config.ConfigForceNameInfos { Index = 59, Length = 8, Offset = 0xD1AE3 });
            result.ForceNames.Add(new Config.ConfigForceNameInfos { Index = 60, Length = 8, Offset = 0xD1AEC });

            result.ForceNames.Add(new Config.ConfigForceNameInfos { Index = 61, Length = 8, Offset = 0xD1AF5 });
            result.ForceNames.Add(new Config.ConfigForceNameInfos { Index = 62, Length = 8, Offset = 0xD1AFE });
            result.ForceNames.Add(new Config.ConfigForceNameInfos { Index = 63, Length = 8, Offset = 0xD1B07 });
            result.ForceNames.Add(new Config.ConfigForceNameInfos { Index = 64, Length = 8, Offset = 0xD1B10 });
            result.ForceNames.Add(new Config.ConfigForceNameInfos { Index = 65, Length = 8, Offset = 0xD1B19 });
            result.ForceNames.Add(new Config.ConfigForceNameInfos { Index = 66, Length = 8, Offset = 0xD1B22 });
            result.ForceNames.Add(new Config.ConfigForceNameInfos { Index = 67, Length = 8, Offset = 0xD1B2B });
            result.ForceNames.Add(new Config.ConfigForceNameInfos { Index = 68, Length = 8, Offset = 0xD1B34 });
            result.ForceNames.Add(new Config.ConfigForceNameInfos { Index = 69, Length = 8, Offset = 0xD1B3D });
            result.ForceNames.Add(new Config.ConfigForceNameInfos { Index = 70, Length = 8, Offset = 0xD1B46 });

            result.ForceNames.Add(new Config.ConfigForceNameInfos { Index = 71, Length = 8, Offset = 0xD1B4F });
            result.ForceNames.Add(new Config.ConfigForceNameInfos { Index = 72, Length = 8, Offset = 0xD1B58 });
            result.ForceNames.Add(new Config.ConfigForceNameInfos { Index = 73, Length = 8, Offset = 0xD1B61 });
            result.ForceNames.Add(new Config.ConfigForceNameInfos { Index = 74, Length = 8, Offset = 0xD1B6A });
            result.ForceNames.Add(new Config.ConfigForceNameInfos { Index = 75, Length = 8, Offset = 0xD1B73 });
            result.ForceNames.Add(new Config.ConfigForceNameInfos { Index = 76, Length = 8, Offset = 0xD1B7C });
            result.ForceNames.Add(new Config.ConfigForceNameInfos { Index = 77, Length = 8, Offset = 0xD1B85 });
            result.ForceNames.Add(new Config.ConfigForceNameInfos { Index = 78, Length = 8, Offset = 0xD1B8E });
            result.ForceNames.Add(new Config.ConfigForceNameInfos { Index = 79, Length = 8, Offset = 0xD1B97 });

            result.ForceNames.Add(new Config.ConfigForceNameInfos { Index = 80, Length = 8, Offset = 0xD18D0 });
            result.ForceNames.Add(new Config.ConfigForceNameInfos { Index = 81, Length = 8, Offset = 0xD18D0 });
            result.ForceNames.Add(new Config.ConfigForceNameInfos { Index = 82, Length = 8, Offset = 0xD18D0 });
            result.ForceNames.Add(new Config.ConfigForceNameInfos { Index = 83, Length = 8, Offset = 0xD18D0 });
            result.ForceNames.Add(new Config.ConfigForceNameInfos { Index = 84, Length = 8, Offset = 0xD18D0 });
            result.ForceNames.Add(new Config.ConfigForceNameInfos { Index = 85, Length = 8, Offset = 0xD18D0 });
            result.ForceNames.Add(new Config.ConfigForceNameInfos { Index = 86, Length = 8, Offset = 0xD18D0 });
            result.ForceNames.Add(new Config.ConfigForceNameInfos { Index = 87, Length = 8, Offset = 0xD18D0 });
            result.ForceNames.Add(new Config.ConfigForceNameInfos { Index = 88, Length = 8, Offset = 0xD18D0 });
            result.ForceNames.Add(new Config.ConfigForceNameInfos { Index = 89, Length = 8, Offset = 0xD18D0 });

            result.ForceNames.Add(new Config.ConfigForceNameInfos { Index = 90, Length = 8, Offset = 0xD18D0 });
            result.ForceNames.Add(new Config.ConfigForceNameInfos { Index = 91, Length = 8, Offset = 0xD18D0 });
            result.ForceNames.Add(new Config.ConfigForceNameInfos { Index = 92, Length = 8, Offset = 0xD18D0 });
            result.ForceNames.Add(new Config.ConfigForceNameInfos { Index = 93, Length = 8, Offset = 0xD18D0 });
            result.ForceNames.Add(new Config.ConfigForceNameInfos { Index = 94, Length = 8, Offset = 0xD18D0 });
            result.ForceNames.Add(new Config.ConfigForceNameInfos { Index = 95, Length = 8, Offset = 0xD18D0 });
            result.ForceNames.Add(new Config.ConfigForceNameInfos { Index = 96, Length = 8, Offset = 0xD18D0 });
            result.ForceNames.Add(new Config.ConfigForceNameInfos { Index = 97, Length = 8, Offset = 0xD18D0 });
            result.ForceNames.Add(new Config.ConfigForceNameInfos { Index = 98, Length = 8, Offset = 0xD18D0 });
            result.ForceNames.Add(new Config.ConfigForceNameInfos { Index = 99, Length = 8, Offset = 0xD18D0 });

            result.ForceNames.Add(new Config.ConfigForceNameInfos { Index = 100, Length = 8, Offset = 0xD18D0 });
            result.ForceNames.Add(new Config.ConfigForceNameInfos { Index = 101, Length = 8, Offset = 0xD18D0 });
            result.ForceNames.Add(new Config.ConfigForceNameInfos { Index = 102, Length = 8, Offset = 0xD18D0 });
            result.ForceNames.Add(new Config.ConfigForceNameInfos { Index = 103, Length = 8, Offset = 0xD18D0 });
            result.ForceNames.Add(new Config.ConfigForceNameInfos { Index = 104, Length = 8, Offset = 0xD18D0 });
            result.ForceNames.Add(new Config.ConfigForceNameInfos { Index = 105, Length = 8, Offset = 0xD18D0 });
            result.ForceNames.Add(new Config.ConfigForceNameInfos { Index = 106, Length = 8, Offset = 0xD18D0 });
            result.ForceNames.Add(new Config.ConfigForceNameInfos { Index = 107, Length = 8, Offset = 0xD18D0 });
            result.ForceNames.Add(new Config.ConfigForceNameInfos { Index = 108, Length = 8, Offset = 0xD18D0 });
            result.ForceNames.Add(new Config.ConfigForceNameInfos { Index = 109, Length = 8, Offset = 0xD18D0 });

            result.ForceNames.Add(new Config.ConfigForceNameInfos { Index = 110, Length = 8, Offset = 0xD18D0 });
            result.ForceNames.Add(new Config.ConfigForceNameInfos { Index = 111, Length = 8, Offset = 0xD18D0 });
            result.ForceNames.Add(new Config.ConfigForceNameInfos { Index = 112, Length = 8, Offset = 0xD18D0 });
            result.ForceNames.Add(new Config.ConfigForceNameInfos { Index = 113, Length = 8, Offset = 0xD18D0 });
            result.ForceNames.Add(new Config.ConfigForceNameInfos { Index = 114, Length = 8, Offset = 0xD18D0 });
            result.ForceNames.Add(new Config.ConfigForceNameInfos { Index = 115, Length = 8, Offset = 0xD18D0 });
            result.ForceNames.Add(new Config.ConfigForceNameInfos { Index = 116, Length = 8, Offset = 0xD18D0 });
            result.ForceNames.Add(new Config.ConfigForceNameInfos { Index = 117, Length = 8, Offset = 0xD18D0 });
            result.ForceNames.Add(new Config.ConfigForceNameInfos { Index = 118, Length = 8, Offset = 0xD18D0 });
            result.ForceNames.Add(new Config.ConfigForceNameInfos { Index = 119, Length = 8, Offset = 0xD18D0 });
            result.ForceNames.Add(new Config.ConfigForceNameInfos { Index = 120, Length = 8, Offset = 0xD18D0 });
        }

        protected override void CreateForceCategoryNames()
        {
            result.ForceCategoryNames.Add(new Config.ConfigForceCategoryNameInfos { Index = 0, Length = 8, Offset = 0x8B010 });
            result.ForceCategoryNames.Add(new Config.ConfigForceCategoryNameInfos { Index = 1, Length = 8, Offset = 0x8B019 });
            result.ForceCategoryNames.Add(new Config.ConfigForceCategoryNameInfos { Index = 2, Length = 8, Offset = 0x8B022 });
            result.ForceCategoryNames.Add(new Config.ConfigForceCategoryNameInfos { Index = 3, Length = 8, Offset = 0x8B02B });
            result.ForceCategoryNames.Add(new Config.ConfigForceCategoryNameInfos { Index = 4, Length = 8, Offset = 0x8B034 });
            result.ForceCategoryNames.Add(new Config.ConfigForceCategoryNameInfos { Index = 5, Length = 8, Offset = 0x8B03D });
            result.ForceCategoryNames.Add(new Config.ConfigForceCategoryNameInfos { Index = 6, Length = 8, Offset = 0x8B046 });
            result.ForceCategoryNames.Add(new Config.ConfigForceCategoryNameInfos { Index = 7, Length = 8, Offset = 0x8B04F });
            result.ForceCategoryNames.Add(new Config.ConfigForceCategoryNameInfos { Index = 8, Length = 8, Offset = 0x8B058 });
            result.ForceCategoryNames.Add(new Config.ConfigForceCategoryNameInfos { Index = 9, Length = 8, Offset = 0x8B061 });

            result.ForceCategoryNames.Add(new Config.ConfigForceCategoryNameInfos { Index = 10, Length = 8, Offset = 0x8B06A });
            result.ForceCategoryNames.Add(new Config.ConfigForceCategoryNameInfos { Index = 11, Length = 8, Offset = 0x8B073 });
            result.ForceCategoryNames.Add(new Config.ConfigForceCategoryNameInfos { Index = 12, Length = 8, Offset = 0x8B07C });
            result.ForceCategoryNames.Add(new Config.ConfigForceCategoryNameInfos { Index = 13, Length = 8, Offset = 0x8B085 });
            result.ForceCategoryNames.Add(new Config.ConfigForceCategoryNameInfos { Index = 14, Length = 8, Offset = 0x8B08E });
            result.ForceCategoryNames.Add(new Config.ConfigForceCategoryNameInfos { Index = 15, Length = 8, Offset = 0x8B097 });
            result.ForceCategoryNames.Add(new Config.ConfigForceCategoryNameInfos { Index = 16, Length = 8, Offset = 0x8B0A0 });
            result.ForceCategoryNames.Add(new Config.ConfigForceCategoryNameInfos { Index = 17, Length = 8, Offset = 0x8B0A9 });
            result.ForceCategoryNames.Add(new Config.ConfigForceCategoryNameInfos { Index = 18, Length = 8, Offset = 0x8B0B2 });
            result.ForceCategoryNames.Add(new Config.ConfigForceCategoryNameInfos { Index = 19, Length = 8, Offset = 0x8B0BB });

            result.ForceCategoryNames.Add(new Config.ConfigForceCategoryNameInfos { Index = 20, Length = 8, Offset = 0x8B0C4 });
            result.ForceCategoryNames.Add(new Config.ConfigForceCategoryNameInfos { Index = 21, Length = 8, Offset = 0x8B0CD });
            result.ForceCategoryNames.Add(new Config.ConfigForceCategoryNameInfos { Index = 22, Length = 8, Offset = 0x8B0D6 });
            result.ForceCategoryNames.Add(new Config.ConfigForceCategoryNameInfos { Index = 23, Length = 8, Offset = 0x8B0DF });
            result.ForceCategoryNames.Add(new Config.ConfigForceCategoryNameInfos { Index = 24, Length = 8, Offset = 0x8B0E8 });
            result.ForceCategoryNames.Add(new Config.ConfigForceCategoryNameInfos { Index = 25, Length = 8, Offset = 0x8B0F1 });
            result.ForceCategoryNames.Add(new Config.ConfigForceCategoryNameInfos { Index = 26, Length = 8, Offset = 0x8B0FA });
            result.ForceCategoryNames.Add(new Config.ConfigForceCategoryNameInfos { Index = 27, Length = 8, Offset = 0x8B103 });
            result.ForceCategoryNames.Add(new Config.ConfigForceCategoryNameInfos { Index = 28, Length = 8, Offset = 0x8B10C });
            result.ForceCategoryNames.Add(new Config.ConfigForceCategoryNameInfos { Index = 29, Length = 8, Offset = 0x8B115 });

            result.ForceCategoryNames.Add(new Config.ConfigForceCategoryNameInfos { Index = 30, Length = 8, Offset = 0x8B11E });
            result.ForceCategoryNames.Add(new Config.ConfigForceCategoryNameInfos { Index = 31, Length = 8, Offset = 0x8B127 });
            result.ForceCategoryNames.Add(new Config.ConfigForceCategoryNameInfos { Index = 32, Length = 8, Offset = 0x8B130 });
            result.ForceCategoryNames.Add(new Config.ConfigForceCategoryNameInfos { Index = 33, Length = 8, Offset = 0x8B139 });
            result.ForceCategoryNames.Add(new Config.ConfigForceCategoryNameInfos { Index = 34, Length = 8, Offset = 0x8B142 });
            result.ForceCategoryNames.Add(new Config.ConfigForceCategoryNameInfos { Index = 35, Length = 8, Offset = 0x8B14B });
            result.ForceCategoryNames.Add(new Config.ConfigForceCategoryNameInfos { Index = 36, Length = 8, Offset = 0x8B154 });
            result.ForceCategoryNames.Add(new Config.ConfigForceCategoryNameInfos { Index = 37, Length = 8, Offset = 0x8B15D });
            result.ForceCategoryNames.Add(new Config.ConfigForceCategoryNameInfos { Index = 38, Length = 8, Offset = 0x8B166 });
            result.ForceCategoryNames.Add(new Config.ConfigForceCategoryNameInfos { Index = 39, Length = 8, Offset = 0x8B16F });

            result.ForceCategoryNames.Add(new Config.ConfigForceCategoryNameInfos { Index = 40, Length = 8, Offset = 0x8B11E });
            result.ForceCategoryNames.Add(new Config.ConfigForceCategoryNameInfos { Index = 41, Length = 8, Offset = 0x8B127 });
            result.ForceCategoryNames.Add(new Config.ConfigForceCategoryNameInfos { Index = 42, Length = 8, Offset = 0x8B130 });
            result.ForceCategoryNames.Add(new Config.ConfigForceCategoryNameInfos { Index = 43, Length = 8, Offset = 0x8B139 });
            result.ForceCategoryNames.Add(new Config.ConfigForceCategoryNameInfos { Index = 44, Length = 8, Offset = 0x8B142 });
            result.ForceCategoryNames.Add(new Config.ConfigForceCategoryNameInfos { Index = 45, Length = 8, Offset = 0x8B14B });
            result.ForceCategoryNames.Add(new Config.ConfigForceCategoryNameInfos { Index = 46, Length = 8, Offset = 0x8B154 });
            result.ForceCategoryNames.Add(new Config.ConfigForceCategoryNameInfos { Index = 47, Length = 8, Offset = 0x8B15D });
            result.ForceCategoryNames.Add(new Config.ConfigForceCategoryNameInfos { Index = 48, Length = 8, Offset = 0x8B166 });
            result.ForceCategoryNames.Add(new Config.ConfigForceCategoryNameInfos { Index = 49, Length = 8, Offset = 0x8B16F });

            result.ForceCategoryNames.Add(new Config.ConfigForceCategoryNameInfos { Index = 50, Length = 8, Offset = 0x8B11E });
            result.ForceCategoryNames.Add(new Config.ConfigForceCategoryNameInfos { Index = 51, Length = 8, Offset = 0x8B127 });
            result.ForceCategoryNames.Add(new Config.ConfigForceCategoryNameInfos { Index = 52, Length = 8, Offset = 0x8B130 });
            result.ForceCategoryNames.Add(new Config.ConfigForceCategoryNameInfos { Index = 53, Length = 8, Offset = 0x8B139 });
            result.ForceCategoryNames.Add(new Config.ConfigForceCategoryNameInfos { Index = 54, Length = 8, Offset = 0x8B142 });
            result.ForceCategoryNames.Add(new Config.ConfigForceCategoryNameInfos { Index = 55, Length = 8, Offset = 0x8B14B });
            result.ForceCategoryNames.Add(new Config.ConfigForceCategoryNameInfos { Index = 56, Length = 8, Offset = 0x8B154 });
            result.ForceCategoryNames.Add(new Config.ConfigForceCategoryNameInfos { Index = 57, Length = 8, Offset = 0x8B15D });
            result.ForceCategoryNames.Add(new Config.ConfigForceCategoryNameInfos { Index = 58, Length = 8, Offset = 0x8B166 });
            result.ForceCategoryNames.Add(new Config.ConfigForceCategoryNameInfos { Index = 59, Length = 8, Offset = 0x8B16F });

            result.ForceCategoryNames.Add(new Config.ConfigForceCategoryNameInfos { Index = 60, Length = 8, Offset = 0x8B11E });
            result.ForceCategoryNames.Add(new Config.ConfigForceCategoryNameInfos { Index = 61, Length = 8, Offset = 0x8B127 });
            result.ForceCategoryNames.Add(new Config.ConfigForceCategoryNameInfos { Index = 62, Length = 8, Offset = 0x8B130 });
            result.ForceCategoryNames.Add(new Config.ConfigForceCategoryNameInfos { Index = 63, Length = 8, Offset = 0x8B139 });
            result.ForceCategoryNames.Add(new Config.ConfigForceCategoryNameInfos { Index = 64, Length = 8, Offset = 0x8B142 });
            result.ForceCategoryNames.Add(new Config.ConfigForceCategoryNameInfos { Index = 65, Length = 8, Offset = 0x8B14B });
            result.ForceCategoryNames.Add(new Config.ConfigForceCategoryNameInfos { Index = 66, Length = 8, Offset = 0x8B154 });
            result.ForceCategoryNames.Add(new Config.ConfigForceCategoryNameInfos { Index = 67, Length = 8, Offset = 0x8B15D });
            result.ForceCategoryNames.Add(new Config.ConfigForceCategoryNameInfos { Index = 68, Length = 8, Offset = 0x8B166 });
            result.ForceCategoryNames.Add(new Config.ConfigForceCategoryNameInfos { Index = 69, Length = 8, Offset = 0x8B16F });

            result.ForceCategoryNames.Add(new Config.ConfigForceCategoryNameInfos { Index = 70, Length = 8, Offset = 0x8B11E });
            result.ForceCategoryNames.Add(new Config.ConfigForceCategoryNameInfos { Index = 71, Length = 8, Offset = 0x8B127 });
            result.ForceCategoryNames.Add(new Config.ConfigForceCategoryNameInfos { Index = 72, Length = 8, Offset = 0x8B130 });
            result.ForceCategoryNames.Add(new Config.ConfigForceCategoryNameInfos { Index = 73, Length = 8, Offset = 0x8B139 });
            result.ForceCategoryNames.Add(new Config.ConfigForceCategoryNameInfos { Index = 74, Length = 8, Offset = 0x8B142 });
            result.ForceCategoryNames.Add(new Config.ConfigForceCategoryNameInfos { Index = 75, Length = 8, Offset = 0x8B14B });
            result.ForceCategoryNames.Add(new Config.ConfigForceCategoryNameInfos { Index = 76, Length = 8, Offset = 0x8B154 });
            result.ForceCategoryNames.Add(new Config.ConfigForceCategoryNameInfos { Index = 77, Length = 8, Offset = 0x8B15D });
            result.ForceCategoryNames.Add(new Config.ConfigForceCategoryNameInfos { Index = 78, Length = 8, Offset = 0x8B166 });
            result.ForceCategoryNames.Add(new Config.ConfigForceCategoryNameInfos { Index = 79, Length = 8, Offset = 0x8B16F });
        }

    }
}
