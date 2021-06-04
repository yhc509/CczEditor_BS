using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CczEditor
{
    public class Bs10ConfigCreateHandler : Star61ConfigCreateHandler
    {

        protected override void CreateBaseInfo()
        {
            result.VersionName = "BS 1.0";
            if (result.DisplayName == null) result.DisplayName = "비상조조전 1.0";
            result.DirectoryPath = string.Empty;
            result.ExeFileName = "Ekd5.exe";
            result.UseE5Directory = false;
        }

        protected override void CreateCodeOptionSettings()
        {
            base.CreateCodeOptionSettings();

            result.CodeOptionContainer.MagicReflect = true;
            result.CodeOptionContainer.UseLargeFace = true;
            result.CodeOptionContainer.UseCutin = true;
            result.CodeOptionContainer.UseVoice = true;
            result.CodeOptionContainer.UseCost = true;
        }
        
        protected override void CreateExeSettings()
        {
            base.CreateExeSettings();

            result.Exe.UnitCutinOffset = 0xF7F50;
            result.Exe.UnitCostOffset = 0xF9330;
            result.Exe.UnitVoiceOffset = 0xF80C0;

            result.Exe.Magic.UseReflectIndexes = new int[] {
                0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09, 0x0A, 0x0B, 0x0C, 0x0D, 0x0E, 0x0F,
                0x10, 0x11, 0x12, 0x13, 0x14, 0x15, 0x16, 0x17, 0x18, 0x19, 0x1A, 0x1B, 0x1C, 0x1D, 0x1E, 0x1F,
                0x20, 0x21, 0x22, 0x23, 0x24, 0x25, 0x26, 0x27, 0x28, 0x29, 0x2A, 0x2B, 0x2C, 0x2D, 0x2E, 0x2F,
                0x30, 0x31, 0x32, 0x33, 0x34, 0x35, 0x36, 0x37, 0x38, 0x39, 0x3A, 0x3B, 0x3C, 0x3D, 0x3E, 0x3F,
                0x40, 0x41, 0x42, 0x43, 0x44, 0x45, 0x46, 0x47, 0x48, 0x49
            };
            result.Exe.Magic.ReflectTypeOffset = 0xC465;
        }
        
        protected override void CreateSpecialEffects()
        {
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 0, Length = 0x10, Offset = 0xF9430 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 1, Length = 0x10, Offset = 0xF9440 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 2, Length = 0x10, Offset = 0xF9450 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 3, Length = 0x10, Offset = 0xF9460 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 4, Length = 0x10, Offset = 0xF9470 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 5, Length = 0x10, Offset = 0xF9480 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 6, Length = 0x10, Offset = 0xF9490 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 7, Length = 0x10, Offset = 0xF94A0 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 8, Length = 0x10, Offset = 0xF94B0 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 9, Length = 0x10, Offset = 0xF94C0 });

            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 10, Length = 0x10, Offset = 0xF94D0 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 11, Length = 0x10, Offset = 0xF94E0 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 12, Length = 0x10, Offset = 0xF94F0 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 13, Length = 0x10, Offset = 0xF9500 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 14, Length = 0x10, Offset = 0xF9510 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 15, Length = 0x10, Offset = 0xF9520 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 16, Length = 0x10, Offset = 0xF9530 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 17, Length = 0x10, Offset = 0xF9540 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 18, Length = 0x10, Offset = 0xF9550 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 19, Length = 0x10, Offset = 0xF9560 });

            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 20, Length = 0x10, Offset = 0xF9570 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 21, Length = 0x10, Offset = 0xF9580 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 22, Length = 0x10, Offset = 0xF9590 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 23, Length = 0x10, Offset = 0xF95A0 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 24, Length = 0x10, Offset = 0xF95B0 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 25, Length = 0x10, Offset = 0xF95C0 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 26, Length = 0x10, Offset = 0xF95D0 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 27, Length = 0x10, Offset = 0xF95E0 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 28, Length = 0x10, Offset = 0xF95F0 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 29, Length = 0x10, Offset = 0xF9600 });

            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 30, Length = 0x10, Offset = 0xF9610 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 31, Length = 0x10, Offset = 0xF9620 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 32, Length = 0x10, Offset = 0xF9630 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 33, Length = 0x10, Offset = 0xF9640 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 34, Length = 0x10, Offset = 0xF9650 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 35, Length = 0x10, Offset = 0xF9660 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 36, Length = 0x10, Offset = 0xF9670 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 37, Length = 0x10, Offset = 0xF9680 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 38, Length = 0x10, Offset = 0xF9690 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 39, Length = 0x10, Offset = 0xF96A0 });

            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 40, Length = 0x10, Offset = 0xF96B0 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 41, Length = 0x10, Offset = 0xF96C0 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 42, Length = 0x10, Offset = 0xF96D0 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 43, Length = 0x10, Offset = 0xF96E0 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 44, Length = 0x10, Offset = 0xF96F0 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 45, Length = 0x10, Offset = 0xF9700 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 46, Length = 0x10, Offset = 0xF9710 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 47, Length = 0x10, Offset = 0xF9720 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 48, Length = 0x10, Offset = 0xF9730 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 49, Length = 0x10, Offset = 0xF9740 });

            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 50, Length = 0x10, Offset = 0xF9750 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 51, Length = 0x10, Offset = 0xF9760 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 52, Length = 0x10, Offset = 0xF9770 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 53, Length = 0x10, Offset = 0xF9780 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 54, Length = 0x10, Offset = 0xF9790 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 55, Length = 0x10, Offset = 0xF97A0 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 56, Length = 0x10, Offset = 0xF97B0 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 57, Length = 0x10, Offset = 0xF97C0 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 58, Length = 0x10, Offset = 0xF97D0 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 59, Length = 0x10, Offset = 0xF97E0 });

            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 60, Length = 0x10, Offset = 0xF97F0 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 61, Length = 0x10, Offset = 0xF9800 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 62, Length = 0x10, Offset = 0xF9810 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 63, Length = 0x10, Offset = 0xF9820 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 64, Length = 0x10, Offset = 0xF9830 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 65, Length = 0x10, Offset = 0xF9840 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 66, Length = 0x10, Offset = 0xF9850 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 67, Length = 0x10, Offset = 0xF9860 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 68, Length = 0x10, Offset = 0xF9870 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 69, Length = 0x10, Offset = 0xF9880 });

            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 70, Length = 0x10, Offset = 0xF9890 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 71, Length = 0x10, Offset = 0xF98A0 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 72, Length = 0x10, Offset = 0xF98B0 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 73, Length = 0x10, Offset = 0xF98C0 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 74, Length = 0x10, Offset = 0xF98D0 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 75, Length = 0x10, Offset = 0xF98E0 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 76, Length = 0x10, Offset = 0xF98F0 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 77, Length = 0x10, Offset = 0xF9900 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 78, Length = 0x10, Offset = 0xF9910 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 79, Length = 0x10, Offset = 0xF9920 });

            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 80, Length = 0x10, Offset = 0xF9930 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 81, Length = 0x10, Offset = 0xF9940 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 82, Length = 0x10, Offset = 0xF9950 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 83, Length = 0x10, Offset = 0xF9960 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 84, Length = 0x10, Offset = 0xF9970 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 85, Length = 0x10, Offset = 0xF9980 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 86, Length = 0x10, Offset = 0xF9990 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 87, Length = 0x10, Offset = 0xF99A0 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 88, Length = 0x10, Offset = 0xF99B0 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 89, Length = 0x10, Offset = 0xF99C0 });

            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 90, Length = 0x10, Offset = 0xF99D0 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 91, Length = 0x10, Offset = 0xF99E0 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 92, Length = 0x10, Offset = 0xF99F0 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 93, Length = 0x10, Offset = 0xF9A00 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 94, Length = 0x10, Offset = 0xF9A10 });
        }
        
        protected override void CreateCodeEffectNames()
        {
            base.CreateCodeEffectNames();

            result.CodeEffects.Add(new Config.ConfigCodeEffectInfos { Offset = 0xC219, TypeIndex = (int)Config.ConfigCodeEffectInfos.Type.SpecialAttack, Description = "맹공일격", Editable = true, SubEdit = 0 });
            result.CodeEffects.Add(new Config.ConfigCodeEffectInfos { Offset = 0xC24F, TypeIndex = (int)Config.ConfigCodeEffectInfos.Type.SpecialAttack, Description = "허점공격", Editable = true, SubEdit = 0 });
            result.CodeEffects.Add(new Config.ConfigCodeEffectInfos { Offset = 0xC283, TypeIndex = (int)Config.ConfigCodeEffectInfos.Type.SpecialAttack, Description = "약점공격", Editable = true, SubEdit = 0 });
            result.CodeEffects.Add(new Config.ConfigCodeEffectInfos { Offset = 0xC360, TypeIndex = (int)Config.ConfigCodeEffectInfos.Type.SpecialAttack, Description = "무조건반격", Editable = true, SubEdit = 0 });

            result.CodeEffects.Add(new Config.ConfigCodeEffectInfos { Offset = 0xC30F, TypeIndex = (int)Config.ConfigCodeEffectInfos.Type.Magic, Description = "책략범위고정", Editable = true, SubEdit = 0 });
            result.CodeEffects.Add(new Config.ConfigCodeEffectInfos { Offset = 0xC388, TypeIndex = (int)Config.ConfigCodeEffectInfos.Type.Magic, Description = "회복책략보조", Editable = true, SubEdit = 0 });

            result.CodeEffects.Add(new Config.ConfigCodeEffectInfos { Offset = 0xC194, TypeIndex = (int)Config.ConfigCodeEffectInfos.Type.DeburfAttack, Description = "선제공격저하", Editable = true, SubEdit = 0 });
            result.CodeEffects.Add(new Config.ConfigCodeEffectInfos { Offset = 0xC1D8, TypeIndex = (int)Config.ConfigCodeEffectInfos.Type.DeburfAttack, Description = "선제정신저하", Editable = true, SubEdit = 0 });

            result.CodeEffects.Add(new Config.ConfigCodeEffectInfos { Offset = 0xC4F1, TypeIndex = (int)Config.ConfigCodeEffectInfos.Type.DecreaseDmg, Description = "물리피해고정", Editable = true, SubEdit = 0 });

            result.CodeEffects.Add(new Config.ConfigCodeEffectInfos { Offset = 0xC3D5, TypeIndex = (int)Config.ConfigCodeEffectInfos.Type.Defence, Description = "책략반사", Editable = true, SubEdit = 0 });

            result.CodeEffects.Add(new Config.ConfigCodeEffectInfos { Offset = 0xC32F, TypeIndex = (int)Config.ConfigCodeEffectInfos.Type.Etc, Description = "도구범위고정", Editable = true, SubEdit = 0 });
        }
        
    }
}
