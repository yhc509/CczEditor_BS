using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CczEditor
{
    public class Bs11ConfigCreateHandler : Star62ConfigCreateHandler
    {

        protected override void CreateBaseInfo()
        {
            result.VersionName = "BS 1.1";
            if (result.DisplayName == null) result.DisplayName = "비상조조전 1.1";
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

            result.Exe.UnitCutinOffset = 0x147A10;
            result.Exe.UnitCostOffset = 0x147910;
            result.Exe.UnitVoiceOffset = 0x147B10;

            result.Exe.Magic.UseReflectIndexes = new int[] {
                0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09, 0x0A, 0x0B, 0x0C, 0x0D, 0x0E, 0x0F,
                0x10, 0x11, 0x12, 0x13, 0x14, 0x15, 0x16, 0x17, 0x18, 0x19, 0x1A, 0x1B, 0x1C, 0x1D, 0x1E, 0x1F,
                0x20, 0x21, 0x22, 0x23, 0x24, 0x25, 0x26, 0x27, 0x28, 0x29, 0x2A, 0x2B, 0x2C, 0x2D, 0x2E, 0x2F,
                0x30, 0x31, 0x32, 0x33, 0x34, 0x35, 0x36, 0x37, 0x38, 0x39, 0x3A, 0x3B, 0x3C, 0x3D, 0x3E, 0x3F,
                0x40, 0x41, 0x42, 0x43, 0x44, 0x45, 0x46, 0x47, 0x48, 0x49, 0x4A, 0x4B, 0x4C, 0x4D, 0x4E, 0x4F,
                0x50, 0x51, 0x52, 0x53, 0x54, 0x55
            };
            result.Exe.Magic.ReflectTypeOffset = 0x147C10;
        }

        protected override void CreateSpecialEffects()
        {
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 0, Length = 0x10, Offset = 0x141900 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 1, Length = 0x10, Offset = 0x141910 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 2, Length = 0x10, Offset = 0x141920 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 3, Length = 0x10, Offset = 0x141930 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 4, Length = 0x10, Offset = 0x141940 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 5, Length = 0x10, Offset = 0x141950 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 6, Length = 0x10, Offset = 0x141960 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 7, Length = 0x10, Offset = 0x141970 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 8, Length = 0x10, Offset = 0x141980 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 9, Length = 0x10, Offset = 0x141990 });

            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 10, Length = 0x10, Offset = 0x1419A0 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 11, Length = 0x10, Offset = 0x1419B0 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 12, Length = 0x10, Offset = 0x1419C0 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 13, Length = 0x10, Offset = 0x1419D0 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 14, Length = 0x10, Offset = 0x1419E0 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 15, Length = 0x10, Offset = 0x1419F0 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 16, Length = 0x10, Offset = 0x141A00 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 17, Length = 0x10, Offset = 0x141A10 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 18, Length = 0x10, Offset = 0x141A20 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 19, Length = 0x10, Offset = 0x141A30 });

            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 20, Length = 0x10, Offset = 0x141A40 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 21, Length = 0x10, Offset = 0x141A50 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 22, Length = 0x10, Offset = 0x141A60 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 23, Length = 0x10, Offset = 0x141A70 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 24, Length = 0x10, Offset = 0x141A80 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 25, Length = 0x10, Offset = 0x141A90 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 26, Length = 0x10, Offset = 0x141AA0 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 27, Length = 0x10, Offset = 0x141AB0 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 28, Length = 0x10, Offset = 0x141AC0 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 29, Length = 0x10, Offset = 0x141AD0 });

            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 30, Length = 0x10, Offset = 0x141AE0 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 31, Length = 0x10, Offset = 0x141AF0 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 32, Length = 0x10, Offset = 0x141B00 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 33, Length = 0x10, Offset = 0x141B10 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 34, Length = 0x10, Offset = 0x141B20 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 35, Length = 0x10, Offset = 0x141B30 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 36, Length = 0x10, Offset = 0x141B40 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 37, Length = 0x10, Offset = 0x141B50 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 38, Length = 0x10, Offset = 0x141B60 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 39, Length = 0x10, Offset = 0x141B70 });

            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 40, Length = 0x10, Offset = 0x141B80 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 41, Length = 0x10, Offset = 0x141B90 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 42, Length = 0x10, Offset = 0x141BA0 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 43, Length = 0x10, Offset = 0x141BB0 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 44, Length = 0x10, Offset = 0x141BC0 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 45, Length = 0x10, Offset = 0x141BD0 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 46, Length = 0x10, Offset = 0x141BE0 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 47, Length = 0x10, Offset = 0x141BF0 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 48, Length = 0x10, Offset = 0x141C00 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 49, Length = 0x10, Offset = 0x141C10 });

            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 50, Length = 0x10, Offset = 0x141C20 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 51, Length = 0x10, Offset = 0x141C30 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 52, Length = 0x10, Offset = 0x141C40 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 53, Length = 0x10, Offset = 0x141C50 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 54, Length = 0x10, Offset = 0x141C60 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 55, Length = 0x10, Offset = 0x141C70 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 56, Length = 0x10, Offset = 0x141C80 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 57, Length = 0x10, Offset = 0x141C90 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 58, Length = 0x10, Offset = 0x141CA0 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 59, Length = 0x10, Offset = 0x141CB0 });

            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 60, Length = 0x10, Offset = 0x141CC0 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 61, Length = 0x10, Offset = 0x141CD0 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 62, Length = 0x10, Offset = 0x141CE0 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 63, Length = 0x10, Offset = 0x141CF0 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 64, Length = 0x10, Offset = 0x141D00 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 65, Length = 0x10, Offset = 0x141D10 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 66, Length = 0x10, Offset = 0x141D20 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 67, Length = 0x10, Offset = 0x141D30 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 68, Length = 0x10, Offset = 0x141D40 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 69, Length = 0x10, Offset = 0x141D50 });

            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 70, Length = 0x10, Offset = 0x141D60 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 71, Length = 0x10, Offset = 0x141D70 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 72, Length = 0x10, Offset = 0x141D80 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 73, Length = 0x10, Offset = 0x141D90 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 74, Length = 0x10, Offset = 0x141DA0 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 75, Length = 0x10, Offset = 0x141DB0 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 76, Length = 0x10, Offset = 0x141DC0 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 77, Length = 0x10, Offset = 0x141DD0 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 78, Length = 0x10, Offset = 0x141DE0 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 79, Length = 0x10, Offset = 0x141DF0 });

            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 80, Length = 0x10, Offset = 0x141E00 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 81, Length = 0x10, Offset = 0x141E10 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 82, Length = 0x10, Offset = 0x141E20 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 83, Length = 0x10, Offset = 0x141E30 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 84, Length = 0x10, Offset = 0x141E40 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 85, Length = 0x10, Offset = 0x141E50 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 86, Length = 0x10, Offset = 0x141E60 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 87, Length = 0x10, Offset = 0x141E70 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 88, Length = 0x10, Offset = 0x141E80 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 89, Length = 0x10, Offset = 0x141E90 });

            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 90, Length = 0x10, Offset = 0x141EA0 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 91, Length = 0x10, Offset = 0x141EB0 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 92, Length = 0x10, Offset = 0x141EC0 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 93, Length = 0x10, Offset = 0x141ED0 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 94, Length = 0x10, Offset = 0x141EE0 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 95, Length = 0x10, Offset = 0x141EF0 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 96, Length = 0x10, Offset = 0x141F00 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 97, Length = 0x10, Offset = 0x141F10 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 98, Length = 0x10, Offset = 0x141F20 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 99, Length = 0x10, Offset = 0x141F30 });

            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 100, Length = 0x10, Offset = 0x141F40 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 101, Length = 0x10, Offset = 0x141F50 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 102, Length = 0x10, Offset = 0x141F60 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 103, Length = 0x10, Offset = 0x141F70 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 104, Length = 0x10, Offset = 0x141F80 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 105, Length = 0x10, Offset = 0x141F90 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 106, Length = 0x10, Offset = 0x141FA0 });
        }

        protected override void CreateCodeEffectNames()
        {
            base.CreateCodeEffectNames();

            result.CodeEffects.Add(new Config.ConfigCodeEffectInfos { Offset = 0xF8207, TypeIndex = (int)Config.ConfigCodeEffectInfos.Type.SpecialAttack, Description = "맹공일격", Editable = true, SubEdit = 0 });
            result.CodeEffects.Add(new Config.ConfigCodeEffectInfos { Offset = 0xF823D, TypeIndex = (int)Config.ConfigCodeEffectInfos.Type.SpecialAttack, Description = "허점공격", Editable = true, SubEdit = 0 });
            result.CodeEffects.Add(new Config.ConfigCodeEffectInfos { Offset = 0xF82FC, TypeIndex = (int)Config.ConfigCodeEffectInfos.Type.SpecialAttack, Description = "무조건반격", Editable = true, SubEdit = 0 });

            result.CodeEffects.Add(new Config.ConfigCodeEffectInfos { Offset = 0xF82AB, TypeIndex = (int)Config.ConfigCodeEffectInfos.Type.Magic, Description = "책략범위고정", Editable = true, SubEdit = 0 });
            result.CodeEffects.Add(new Config.ConfigCodeEffectInfos { Offset = 0xF8324, TypeIndex = (int)Config.ConfigCodeEffectInfos.Type.Magic, Description = "회복책략보조", Editable = true, SubEdit = 0 });

            result.CodeEffects.Add(new Config.ConfigCodeEffectInfos { Offset = 0xF81CE, TypeIndex = (int)Config.ConfigCodeEffectInfos.Type.DeburfAttack, Description = "선제공격저하", Editable = true, SubEdit = 0 });
            result.CodeEffects.Add(new Config.ConfigCodeEffectInfos { Offset = 0xF8157, TypeIndex = (int)Config.ConfigCodeEffectInfos.Type.DeburfAttack, Description = "선제정신저하", Editable = true, SubEdit = 0 });
            
            result.CodeEffects.Add(new Config.ConfigCodeEffectInfos { Offset = 0xF80FC, TypeIndex = (int)Config.ConfigCodeEffectInfos.Type.Defence, Description = "책략반사", Editable = true, SubEdit = 0 });

            result.CodeEffects.Add(new Config.ConfigCodeEffectInfos { Offset = 0xF82CB, TypeIndex = (int)Config.ConfigCodeEffectInfos.Type.Etc, Description = "도구범위고정", Editable = true, SubEdit = 0 });

            result.CodeEffects.Add(new Config.ConfigCodeEffectInfos { Offset = 0xF8410, TypeIndex = (int)Config.ConfigCodeEffectInfos.Type.Defence, Description = "반격방어", Editable = true, SubEdit = 0 });
            result.CodeEffects.Add(new Config.ConfigCodeEffectInfos { Offset = 0xF8440, TypeIndex = (int)Config.ConfigCodeEffectInfos.Type.SpecialAttack, Description = "특수방어무시", Editable = true, SubEdit = 0 });
            result.CodeEffects.Add(new Config.ConfigCodeEffectInfos { Offset = 0xF86BD, TypeIndex = (int)Config.ConfigCodeEffectInfos.Type.SpecialAttack, Description = "전능력보조", Editable = true, SubEdit = 0 });

            result.CodeEffects.Add(new Config.ConfigCodeEffectInfos { Offset = 0xF88E6, TypeIndex = (int)Config.ConfigCodeEffectInfos.Type.AbilityAssist, Description = "문무겸비", Editable = true, SubEdit = 0 });
            result.CodeEffects.Add(new Config.ConfigCodeEffectInfos { Offset = 0xF89F8, TypeIndex = (int)Config.ConfigCodeEffectInfos.Type.SpecialAttack, Description = "장비파괴", Editable = true, SubEdit = 0 });
            result.CodeEffects.Add(new Config.ConfigCodeEffectInfos { Offset = 0xF8A8A, TypeIndex = (int)Config.ConfigCodeEffectInfos.Type.SpecialAttack, Description = "능력와해", Editable = true, SubEdit = 0 });
            result.CodeEffects.Add(new Config.ConfigCodeEffectInfos { Offset = 0xF8AFD, TypeIndex = (int)Config.ConfigCodeEffectInfos.Type.SpecialAttack, Description = "일격필살", Editable = true, SubEdit = 0 });

        }

    }
}
