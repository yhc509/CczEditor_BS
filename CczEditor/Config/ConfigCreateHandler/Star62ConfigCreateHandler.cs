using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CczEditor
{
    public class Star62ConfigCreateHandler : Star61ConfigCreateHandler
    {

        protected override void CreateBaseInfo()
        {
            result.VersionName = "Star 6.2";
            if (result.DisplayName == null) result.DisplayName = "신조조전 6.2";
            result.DirectoryPath = string.Empty;
            result.ExeFileName = "Ekd5.exe";
            result.UseE5Directory = true;
        }

        protected override void CreateCodeOptionSettings()
        {
            base.CreateCodeOptionSettings();

            result.UseE5Directory = true;
            result.CodeOptionContainer.UseMagicCondition = false;
            result.CodeOptionContainer.UseMeffAfterMcallExtension = true;
        }
        protected override void CreateDataSettings()
        {
            base.CreateDataSettings();
            
            result.Data.MagicCount = 0x56;
        }

        protected override void CreateItemSettings()
        {
            base.CreateItemSettings();

            result.Items.AuxiliaryIndexMax = 127;
        }

        protected override void CreateExeSettings()
        {
            base.CreateExeSettings();
            

            result.Exe.TitleOffsets = new int[]
            {
                0x8B2D8,
            };

            result.Exe.Magic.UseMeffIndexes = new int[] {
                0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09, 0x0A, 0x0B, 0x0C, 0x0D, 0x0E, 0x0F,
                0x10, 0x11, 0x12, 0x13, 0x14, 0x15, 0x16, 0x17, 0x18, 0x19, 0x1A, 0x1B, 0x1C, 0x1D, 0x1E, 0x1F,
                0x20, 0x21, 0x22, 0x23, 0x24, 0x25, 0x26, 0x27, 0x28, 0x29, 0x2A, 0x2B, 0x2C, 0x2D, 0x2E, 0x2F,
                0x30, 0x31, 0x32, 0x33, 0x34, 0x35, 0x36, 0x37, 0x38, 0x39, 0x3A, 0x3B, 0x3C, 0x3D, 0x3E, 0x3F,
                0x40, 0x41, 0x42, 0x43, 0x44, 0x45, 0x46, 0x47, 0x48, 0x49
            };
            result.Exe.Magic.MeffOffset = 0x858BC;


            result.Exe.Magic.UseMcallIndexes = new int[] {
                0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09, 0x0A, 0x0B, 0x0C, 0x0D, 0x0E, 0x0F,
                0x10, 0x11, 0x12, 0x13, 0x14, 0x15, 0x16, 0x17, 0x18, 0x19, 0x1A, 0x1B, 0x1C, 0x1D, 0x1E, 0x1F,
                0x20, 0x21, 0x22, 0x23, 0x24, 0x25, 0x26, 0x27, 0x28, 0x29, 0x2A, 0x2B, 0x2C, 0x2D, 0x2E, 0x2F,
                0x30, 0x31, 0x32, 0x33, 0x34, 0x35, 0x36, 0x37, 0x38, 0x39, 0x3A, 0x3B, 0x3C, 0x3D, 0x3E, 0x3F,
                0x40, 0x41, 0x42, 0x43, 0x44, 0x45, 0x46, 0x47, 0x48, 0x49, 0x4A, 0x4B, 0x4C, 0x4D, 0x4E, 0x4F,
                0x50, 0x51, 0x52, 0x53, 0x54, 0x55
            };
            result.Exe.Magic.McallOffset = 0x20A70;

            result.Exe.Magic.UseMagicTypeIndexes = new int[] {
                0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09, 0x0A, 0x0B, 0x0C, 0x0D, 0x0E, 0x0F,
                0x10, 0x11, 0x12, 0x13, 0x14, 0x15, 0x16, 0x17, 0x18, 0x19, 0x1A, 0x1B, 0x1C, 0x1D, 0x1E, 0x1F,
                0x20, 0x21, 0x22, 0x23, 0x24, 0x25, 0x26, 0x27, 0x28, 0x29, 0x2A, 0x2B, 0x2C, 0x2D, 0x2E, 0x2F,
                0x30, 0x31, 0x32, 0x33, 0x34, 0x35, 0x36, 0x37, 0x38, 0x39, 0x3A, 0x3B, 0x3C, 0x3D, 0x3E, 0x3F,
                0x40, 0x41, 0x42, 0x43, 0x44, 0x45, 0x46, 0x47, 0x48, 0x49, 0x4A, 0x4B, 0x4C, 0x4D, 0x4E, 0x4F,
                0x50, 0x51, 0x52, 0x53, 0x54, 0x55
            };
            result.Exe.Magic.MagicTypeOffset = 0x24E53;

            result.Exe.Magic.UseDamageTypeIndexes = new int[] {
                0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09, 0x0A, 0x0B, 0x0C, 0x0D, 0x0E, 0x0F,
                0x10, 0x11, 0x12, 0x13, 0x14, 0x15, 0x16, 0x17, 0x18, 0x19, 0x1A, 0x1B, 0x1C, 0x1D, 0x1E, 0x1F,
                0x20, 0x21, 0x22, 0x23, 0x24, 0x25, 0x26, 0x27, 0x28, 0x29, 0x2A, 0x2B, 0x2C, 0x2D, 0x2E, 0x2F,
                0x30, 0x31, 0x32, 0x33, 0x34, 0x35, 0x36, 0x37, 0x38, 0x39, 0x3A, 0x3B, 0x3C, 0x3D, 0x3E, 0x3F,
                0x40, 0x41, 0x42, 0x43, 0x44, 0x45, 0x46, 0x47, 0x48, 0x49, 0x4A, 0x4B, 0x4C, 0x4D, 0x4E, 0x4F,
                0x50, 0x51, 0x52, 0x53, 0x54, 0x55
            };
            result.Exe.Magic.DamageTypeOffset = 0x48FB7;

            result.Exe.Magic.UseHealTypeIndexes = new int[] {
                0x26, 0x27, 0x28, 0x29, 0x2A, 0x2B, 0x2C, 0x2D, 0x2E, 0x2F,
                0x30, 0x31, 0x32, 0x33, 0x34, 0x35, 0x36, 0x37, 0x38, 0x39, 0x3A, 0x3B, 0x3C, 0x3D, 0x3E, 0x3F,
                0x40, 0x41, 0x42, 0x43
            };
            result.Exe.Magic.HealTypeOffset = 0x3BB14;

            result.Exe.Magic.UseAiTypeIndexes = new int[] {
                0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09, 0x0A, 0x0B, 0x0C, 0x0D, 0x0E, 0x0F,
                0x10, 0x11, 0x12, 0x13, 0x14, 0x15, 0x16, 0x17, 0x18, 0x19, 0x1A, 0x1B, 0x1C, 0x1D, 0x1E, 0x1F,
                0x20, 0x21, 0x22, 0x23, 0x24, 0x25, 0x26, 0x27, 0x28, 0x29, 0x2A, 0x2B, 0x2C, 0x2D, 0x2E, 0x2F,
                0x30, 0x31, 0x32, 0x33, 0x34, 0x35, 0x36, 0x37, 0x38, 0x39, 0x3A, 0x3B, 0x3C, 0x3D, 0x3E, 0x3F,
                0x40, 0x41, 0x42, 0x43, 0x44, 0x45, 0x46, 0x47, 0x48, 0x49, 0x4A, 0x4B, 0x4C, 0x4D, 0x4E, 0x4F,
                0x50, 0x51, 0x52, 0x53, 0x54, 0x55
            };
            result.Exe.Magic.AiTypeOffset = 0x39580;

            result.Exe.Magic.UseDamageValueIndexes = new int[] {
                0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09, 0x0A, 0x0B, 0x0C, 0x0D, 0x0E, 0x0F,
                0x10, 0x11, 0x12, 0x13, 0x14, 0x15, 0x16, 0x17, 0x18, 0x19, 0x1A, 0x1B, 0x1C, 0x1D, 0x1E, 0x1F,
                0x20, 0x21, 0x22, 0x23, 0x24, 0x25, 0x26, 0x27, 0x28, 0x29, 0x2A, 0x2B, 0x2C, 0x2D, 0x2E, 0x2F,
                0x30, 0x31, 0x32, 0x33, 0x34, 0x35, 0x36, 0x37, 0x38, 0x39, 0x3A, 0x3B, 0x3C, 0x3D, 0x3E, 0x3F,
                0x40, 0x41, 0x42, 0x43, 0x4E, 0x4F, 0x50, 0x51, 0x52
            };
            result.Exe.Magic.DamageValueOffset = 0x3B71D;

            result.Exe.Magic.UseAccRateIndexes = new int[] {
                0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09, 0x0A, 0x0B, 0x0C, 0x0D, 0x0E, 0x0F,
                0x10, 0x11, 0x12, 0x13, 0x14, 0x15, 0x16, 0x17, 0x18, 0x19, 0x1A, 0x1B, 0x1C, 0x1D, 0x1E, 0x1F,
                0x20, 0x21, 0x22, 0x23, 0x24, 0x25, 0x26, 0x27, 0x28, 0x29, 0x2A, 0x2B, 0x2C, 0x2D, 0x2E, 0x2F,
                0x30, 0x31, 0x32, 0x33, 0x34, 0x35, 0x36, 0x37, 0x38, 0x39, 0x3A, 0x3B, 0x3C, 0x3D, 0x3E, 0x3F,
                0x40, 0x41, 0x42, 0x43, 0x44, 0x45, 0x46, 0x47, 0x48, 0x49, 0x4A, 0x4B, 0x4C, 0x4D, 0x4E, 0x4F,
                0x50, 0x51, 0x52, 0x53, 0x54, 0x55
            };
            result.Exe.Magic.AccRateOffset = 0x3AE07;

            result.Exe.Magic.UseLearnTypeIndexes = new int[] {
                0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09, 0x0A, 0x0B, 0x0C, 0x0D, 0x0E, 0x0F,
                0x10, 0x11, 0x12, 0x13, 0x14, 0x15, 0x16, 0x17, 0x18, 0x19, 0x1A, 0x1B, 0x1C, 0x1D, 0x1E, 0x1F,
                0x20, 0x21, 0x22, 0x23, 0x24, 0x25, 0x26, 0x27, 0x28, 0x29, 0x2A, 0x2B, 0x2C, 0x2D, 0x2E, 0x2F,
                0x30, 0x31, 0x32, 0x33, 0x34, 0x35, 0x36, 0x37, 0x38, 0x39, 0x3A, 0x3B, 0x3C, 0x3D, 0x3E, 0x3F,
                0x40, 0x41, 0x42, 0x43, 0x44, 0x45, 0x46, 0x47, 0x48, 0x49, 0x4A, 0x4B, 0x4C, 0x4D, 0x4E, 0x4F,
                0x50, 0x51, 0x52, 0x53, 0x54, 0x55
            };
            result.Exe.Magic.LearTypeOffset = 0x65201;
        }
        
        protected override void CreateItemEffectNames()
        {
            result.ItemEffects.Add(new Config.ConfigItemEffectNameInfos { Index = 0, Length = 4, Offset = 0x8AC70 });
            result.ItemEffects.Add(new Config.ConfigItemEffectNameInfos { Index = 1, Length = 4, Offset = 0x8AC70 });
            result.ItemEffects.Add(new Config.ConfigItemEffectNameInfos { Index = 2, Length = 4, Offset = 0x8AC75 });
            result.ItemEffects.Add(new Config.ConfigItemEffectNameInfos { Index = 3, Length = 4, Offset = 0x8AC75 });
            result.ItemEffects.Add(new Config.ConfigItemEffectNameInfos { Index = 4, Length = 4, Offset = 0x8AC7A });
            result.ItemEffects.Add(new Config.ConfigItemEffectNameInfos { Index = 5, Length = 4, Offset = 0x8AC7A });
            result.ItemEffects.Add(new Config.ConfigItemEffectNameInfos { Index = 6, Length = 4, Offset = 0x8AC7F });
            result.ItemEffects.Add(new Config.ConfigItemEffectNameInfos { Index = 7, Length = 4, Offset = 0x8AC7F });
            result.ItemEffects.Add(new Config.ConfigItemEffectNameInfos { Index = 8, Length = 4, Offset = 0x8AC84 });
            result.ItemEffects.Add(new Config.ConfigItemEffectNameInfos { Index = 9, Length = 4, Offset = 0x8AC84 });
            result.ItemEffects.Add(new Config.ConfigItemEffectNameInfos { Index = 10, Length = 4, Offset = 0x8AC89 });
            result.ItemEffects.Add(new Config.ConfigItemEffectNameInfos { Index = 11, Length = 4, Offset = 0x8AC89 });
            result.ItemEffects.Add(new Config.ConfigItemEffectNameInfos { Index = 12, Length = 4, Offset = 0x8AC8E });
            result.ItemEffects.Add(new Config.ConfigItemEffectNameInfos { Index = 13, Length = 4, Offset = 0x8AC8E });
            result.ItemEffects.Add(new Config.ConfigItemEffectNameInfos { Index = 14, Length = 4, Offset = 0x8AC93 });
            result.ItemEffects.Add(new Config.ConfigItemEffectNameInfos { Index = 15, Length = 4, Offset = 0x8AC93 });
            result.ItemEffects.Add(new Config.ConfigItemEffectNameInfos { Index = 16, Length = 4, Offset = 0x8AC98 });
            result.ItemEffects.Add(new Config.ConfigItemEffectNameInfos { Index = 17, Length = 4, Offset = 0x8AC98 });
            result.ItemEffects.Add(new Config.ConfigItemEffectNameInfos { Index = 18, Length = 4, Offset = 0x8AC9D });
            result.ItemEffects.Add(new Config.ConfigItemEffectNameInfos { Index = 19, Length = 4, Offset = 0x8AC9D });
            result.ItemEffects.Add(new Config.ConfigItemEffectNameInfos { Index = 20, Length = 4, Offset = 0x8ACA2 });
            result.ItemEffects.Add(new Config.ConfigItemEffectNameInfos { Index = 21, Length = 4, Offset = 0x8ACA2 });
            result.ItemEffects.Add(new Config.ConfigItemEffectNameInfos { Index = 22, Length = 4, Offset = 0x8ACA7 });
            result.ItemEffects.Add(new Config.ConfigItemEffectNameInfos { Index = 23, Length = 4, Offset = 0x8ACA7 });
            result.ItemEffects.Add(new Config.ConfigItemEffectNameInfos { Index = 24, Length = 4, Offset = 0x8ACAC });
            result.ItemEffects.Add(new Config.ConfigItemEffectNameInfos { Index = 25, Length = 4, Offset = 0x8ACAC });

            result.ItemEffects.Add(new Config.ConfigItemEffectNameInfos { Index = 26, Length = 12, Offset = 0x8A9E8 });
            result.ItemEffects.Add(new Config.ConfigItemEffectNameInfos { Index = 27, Length = 12, Offset = 0x8A9F5 });
            result.ItemEffects.Add(new Config.ConfigItemEffectNameInfos { Index = 28, Length = 14, Offset = 0x8AA02 });
            result.ItemEffects.Add(new Config.ConfigItemEffectNameInfos { Index = 29, Length = 12, Offset = 0x8AA11 });

            result.ItemEffects.Add(new Config.ConfigItemEffectNameInfos { Index = 30, Length = 17, Offset = 0x8AA1E });
            result.ItemEffects.Add(new Config.ConfigItemEffectNameInfos { Index = 31, Length = 8, Offset = 0x8AA30 });
            result.ItemEffects.Add(new Config.ConfigItemEffectNameInfos { Index = 32, Length = 10, Offset = 0x8AA39 });
            result.ItemEffects.Add(new Config.ConfigItemEffectNameInfos { Index = 33, Length = 10, Offset = 0x8AA44 });
            result.ItemEffects.Add(new Config.ConfigItemEffectNameInfos { Index = 34, Length = 10, Offset = 0x8AA4F });
            result.ItemEffects.Add(new Config.ConfigItemEffectNameInfos { Index = 35, Length = 10, Offset = 0x8AA5A });
            result.ItemEffects.Add(new Config.ConfigItemEffectNameInfos { Index = 36, Length = 8, Offset = 0x8AA65 });
            result.ItemEffects.Add(new Config.ConfigItemEffectNameInfos { Index = 37, Length = 6, Offset = 0x8AA6E });
            result.ItemEffects.Add(new Config.ConfigItemEffectNameInfos { Index = 38, Length = 6, Offset = 0x8AA75 });
            result.ItemEffects.Add(new Config.ConfigItemEffectNameInfos { Index = 39, Length = 11, Offset = 0x8AA7C });
            result.ItemEffects.Add(new Config.ConfigItemEffectNameInfos { Index = 40, Length = 10, Offset = 0x8AA88 });

            result.ItemEffects.Add(new Config.ConfigItemEffectNameInfos { Index = 41, Length = 8, Offset = 0x8AA93 });
            result.ItemEffects.Add(new Config.ConfigItemEffectNameInfos { Index = 42, Length = 8, Offset = 0x8AA9C });
            result.ItemEffects.Add(new Config.ConfigItemEffectNameInfos { Index = 43, Length = 8, Offset = 0x8AAA5 });
            result.ItemEffects.Add(new Config.ConfigItemEffectNameInfos { Index = 44, Length = 8, Offset = 0x8AAAE });
            result.ItemEffects.Add(new Config.ConfigItemEffectNameInfos { Index = 45, Length = 8, Offset = 0x8AAB7 });
            result.ItemEffects.Add(new Config.ConfigItemEffectNameInfos { Index = 46, Length = 8, Offset = 0x8AAC0 });
            result.ItemEffects.Add(new Config.ConfigItemEffectNameInfos { Index = 47, Length = 12, Offset = 0x8AAC9 });
            result.ItemEffects.Add(new Config.ConfigItemEffectNameInfos { Index = 48, Length = 12, Offset = 0x8AAD6 });
            result.ItemEffects.Add(new Config.ConfigItemEffectNameInfos { Index = 49, Length = 12, Offset = 0x8AAE3 });
            result.ItemEffects.Add(new Config.ConfigItemEffectNameInfos { Index = 50, Length = 8, Offset = 0x8AAF0 });

            result.ItemEffects.Add(new Config.ConfigItemEffectNameInfos { Index = 51, Length = 8, Offset = 0x8AAF9 });
            result.ItemEffects.Add(new Config.ConfigItemEffectNameInfos { Index = 52, Length = 10, Offset = 0x8AB02 });
            result.ItemEffects.Add(new Config.ConfigItemEffectNameInfos { Index = 53, Length = 8, Offset = 0x8AB0D });
            result.ItemEffects.Add(new Config.ConfigItemEffectNameInfos { Index = 54, Length = 8, Offset = 0x8AB16 });
            result.ItemEffects.Add(new Config.ConfigItemEffectNameInfos { Index = 55, Length = 12, Offset = 0x8AB1F });
            result.ItemEffects.Add(new Config.ConfigItemEffectNameInfos { Index = 56, Length = 12, Offset = 0x8AB2C });
            result.ItemEffects.Add(new Config.ConfigItemEffectNameInfos { Index = 57, Length = 6, Offset = 0x8AB39 });
            result.ItemEffects.Add(new Config.ConfigItemEffectNameInfos { Index = 58, Length = 8, Offset = 0x8AB40 });
            result.ItemEffects.Add(new Config.ConfigItemEffectNameInfos { Index = 59, Length = 8, Offset = 0x8AB49 });
            result.ItemEffects.Add(new Config.ConfigItemEffectNameInfos { Index = 60, Length = 12, Offset = 0x8AB52 });

            result.ItemEffects.Add(new Config.ConfigItemEffectNameInfos { Index = 61, Length = 12, Offset = 0x8AB5F });
            result.ItemEffects.Add(new Config.ConfigItemEffectNameInfos { Index = 62, Length = 12, Offset = 0x8AB6C });
            result.ItemEffects.Add(new Config.ConfigItemEffectNameInfos { Index = 63, Length = 10, Offset = 0x8AB79 });
            result.ItemEffects.Add(new Config.ConfigItemEffectNameInfos { Index = 64, Length = 12, Offset = 0x8AB84 });
            result.ItemEffects.Add(new Config.ConfigItemEffectNameInfos { Index = 65, Length = 12, Offset = 0x8AB91 });
            result.ItemEffects.Add(new Config.ConfigItemEffectNameInfos { Index = 66, Length = 8, Offset = 0x8AB9E });
            result.ItemEffects.Add(new Config.ConfigItemEffectNameInfos { Index = 67, Length = 12, Offset = 0x8ABA7 });
            result.ItemEffects.Add(new Config.ConfigItemEffectNameInfos { Index = 68, Length = 10, Offset = 0x8ABB4 });
            result.ItemEffects.Add(new Config.ConfigItemEffectNameInfos { Index = 69, Length = 12, Offset = 0x8ABBF });
            result.ItemEffects.Add(new Config.ConfigItemEffectNameInfos { Index = 70, Length = 8, Offset = 0x8ABCC });

            result.ItemEffects.Add(new Config.ConfigItemEffectNameInfos { Index = 89, Length = 12, Offset = 0x8ABD5 });
            result.ItemEffects.Add(new Config.ConfigItemEffectNameInfos { Index = 90, Length = 8, Offset = 0x8ABE2 });

            result.ItemEffects.Add(new Config.ConfigItemEffectNameInfos { Index = 91, Length = 8, Offset = 0x8ABEB });
            result.ItemEffects.Add(new Config.ConfigItemEffectNameInfos { Index = 92, Length = 8, Offset = 0x8ABF4 });
            result.ItemEffects.Add(new Config.ConfigItemEffectNameInfos { Index = 93, Length = 8, Offset = 0x8ABFD });
            result.ItemEffects.Add(new Config.ConfigItemEffectNameInfos { Index = 94, Length = 12, Offset = 0x8AC06 });
            result.ItemEffects.Add(new Config.ConfigItemEffectNameInfos { Index = 95, Length = 8, Offset = 0x8AC13 });
            result.ItemEffects.Add(new Config.ConfigItemEffectNameInfos { Index = 96, Length = 8, Offset = 0x8AC1C });
            result.ItemEffects.Add(new Config.ConfigItemEffectNameInfos { Index = 97, Length = 8, Offset = 0x8AC25 });
            result.ItemEffects.Add(new Config.ConfigItemEffectNameInfos { Index = 98, Length = 8, Offset = 0x8AC2E });
            result.ItemEffects.Add(new Config.ConfigItemEffectNameInfos { Index = 99, Length = 8, Offset = 0x8AC37 });
            result.ItemEffects.Add(new Config.ConfigItemEffectNameInfos { Index = 100, Length = 8, Offset = 0x8AC40 });

            result.ItemEffects.Add(new Config.ConfigItemEffectNameInfos { Index = 101, Length = 8, Offset = 0xD1BA0 });
            result.ItemEffects.Add(new Config.ConfigItemEffectNameInfos { Index = 102, Length = 8, Offset = 0xD1BA9 });
            result.ItemEffects.Add(new Config.ConfigItemEffectNameInfos { Index = 103, Length = 8, Offset = 0xD1BB2 });
            result.ItemEffects.Add(new Config.ConfigItemEffectNameInfos { Index = 104, Length = 8, Offset = 0xD1BBB });
            result.ItemEffects.Add(new Config.ConfigItemEffectNameInfos { Index = 105, Length = 8, Offset = 0xD1BC4 });
            result.ItemEffects.Add(new Config.ConfigItemEffectNameInfos { Index = 106, Length = 8, Offset = 0xD1BCD });
            result.ItemEffects.Add(new Config.ConfigItemEffectNameInfos { Index = 107, Length = 8, Offset = 0xD1BD6 });
            result.ItemEffects.Add(new Config.ConfigItemEffectNameInfos { Index = 108, Length = 8, Offset = 0xD1BDF });
            result.ItemEffects.Add(new Config.ConfigItemEffectNameInfos { Index = 109, Length = 8, Offset = 0xD1BE8 });
            result.ItemEffects.Add(new Config.ConfigItemEffectNameInfos { Index = 110, Length = 8, Offset = 0xD1BF1 });

            result.ItemEffects.Add(new Config.ConfigItemEffectNameInfos { Index = 111, Length = 8, Offset = 0xD1BFA });
            result.ItemEffects.Add(new Config.ConfigItemEffectNameInfos { Index = 112, Length = 8, Offset = 0xD1C03 });
            result.ItemEffects.Add(new Config.ConfigItemEffectNameInfos { Index = 113, Length = 8, Offset = 0xD1C0C });
            result.ItemEffects.Add(new Config.ConfigItemEffectNameInfos { Index = 114, Length = 8, Offset = 0xD1C15 });
            result.ItemEffects.Add(new Config.ConfigItemEffectNameInfos { Index = 115, Length = 8, Offset = 0xD1C1E });
            result.ItemEffects.Add(new Config.ConfigItemEffectNameInfos { Index = 116, Length = 8, Offset = 0xD1C27 });
            result.ItemEffects.Add(new Config.ConfigItemEffectNameInfos { Index = 117, Length = 8, Offset = 0xD1C30 });
            result.ItemEffects.Add(new Config.ConfigItemEffectNameInfos { Index = 118, Length = 8, Offset = 0xD1C39 });
            result.ItemEffects.Add(new Config.ConfigItemEffectNameInfos { Index = 119, Length = 8, Offset = 0xD1C42 });
            result.ItemEffects.Add(new Config.ConfigItemEffectNameInfos { Index = 120, Length = 8, Offset = 0xD1C4B });

            result.ItemEffects.Add(new Config.ConfigItemEffectNameInfos { Index = 121, Length = 8, Offset = 0xD1C54 });
            result.ItemEffects.Add(new Config.ConfigItemEffectNameInfos { Index = 122, Length = 8, Offset = 0xD1C5D });
            result.ItemEffects.Add(new Config.ConfigItemEffectNameInfos { Index = 123, Length = 8, Offset = 0xD1C66 });
            result.ItemEffects.Add(new Config.ConfigItemEffectNameInfos { Index = 124, Length = 8, Offset = 0xD1C6F });
            result.ItemEffects.Add(new Config.ConfigItemEffectNameInfos { Index = 125, Length = 8, Offset = 0xD1C78 });
            result.ItemEffects.Add(new Config.ConfigItemEffectNameInfos { Index = 126, Length = 8, Offset = 0xD1C81 });
            result.ItemEffects.Add(new Config.ConfigItemEffectNameInfos { Index = 127, Length = 8, Offset = 0xD1C8A });

            result.ItemEffects.Add(new Config.ConfigItemEffectNameInfos { Index = 71, Length = 6, Offset = 0x8ACBB });
            result.ItemEffects.Add(new Config.ConfigItemEffectNameInfos { Index = 72, Length = 6, Offset = 0x8ACC2 });
            result.ItemEffects.Add(new Config.ConfigItemEffectNameInfos { Index = 73, Length = 8, Offset = 0x8ACC9 });
            result.ItemEffects.Add(new Config.ConfigItemEffectNameInfos { Index = 74, Length = 8, Offset = 0x8ACD2 });
            result.ItemEffects.Add(new Config.ConfigItemEffectNameInfos { Index = 75, Length = 8, Offset = 0x8ACDB });
            result.ItemEffects.Add(new Config.ConfigItemEffectNameInfos { Index = 76, Length = 8, Offset = 0x8ACE4 });
            result.ItemEffects.Add(new Config.ConfigItemEffectNameInfos { Index = 77, Length = 8, Offset = 0x8ACED });
            result.ItemEffects.Add(new Config.ConfigItemEffectNameInfos { Index = 78, Length = 8, Offset = 0x8ACF6 });
            result.ItemEffects.Add(new Config.ConfigItemEffectNameInfos { Index = 79, Length = 8, Offset = 0x8AE01 });
            result.ItemEffects.Add(new Config.ConfigItemEffectNameInfos { Index = 80, Length = 10, Offset = 0x8AD08 });

            result.ItemEffects.Add(new Config.ConfigItemEffectNameInfos { Index = 81, Length = 8, Offset = 0x8AD13 });
            result.ItemEffects.Add(new Config.ConfigItemEffectNameInfos { Index = 82, Length = 8, Offset = 0x8AD1C });
            result.ItemEffects.Add(new Config.ConfigItemEffectNameInfos { Index = 83, Length = 8, Offset = 0x8AD25 });
            result.ItemEffects.Add(new Config.ConfigItemEffectNameInfos { Index = 84, Length = 8, Offset = 0x8AD2E });
            result.ItemEffects.Add(new Config.ConfigItemEffectNameInfos { Index = 85, Length = 8, Offset = 0x8AD37 });
            result.ItemEffects.Add(new Config.ConfigItemEffectNameInfos { Index = 86, Length = 8, Offset = 0x8AD40 });
            result.ItemEffects.Add(new Config.ConfigItemEffectNameInfos { Index = 87, Length = 8, Offset = 0x8AD49 });
            result.ItemEffects.Add(new Config.ConfigItemEffectNameInfos { Index = 88, Length = 6, Offset = 0x8AD49 });

        }
        
        protected override void CreateSpecialEffects()
        {
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 0, Length = 0x10, Offset = 0xD1160 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 1, Length = 0x10, Offset = 0xD1170 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 2, Length = 0x10, Offset = 0xD1180 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 3, Length = 0x10, Offset = 0xD1190 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 4, Length = 0x10, Offset = 0xD11A0 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 5, Length = 0x10, Offset = 0xD11B0 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 6, Length = 0x10, Offset = 0xD11C0 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 7, Length = 0x10, Offset = 0xD11D0 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 8, Length = 0x10, Offset = 0xD11E0 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 9, Length = 0x10, Offset = 0xD11F0 });

            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 10, Length = 0x10, Offset = 0xD1200 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 11, Length = 0x10, Offset = 0xD1210 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 12, Length = 0x10, Offset = 0xD1220 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 13, Length = 0x10, Offset = 0xD1230 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 14, Length = 0x10, Offset = 0xD1240 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 15, Length = 0x10, Offset = 0xD1250 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 16, Length = 0x10, Offset = 0xD1260 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 17, Length = 0x10, Offset = 0xD1270 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 18, Length = 0x10, Offset = 0xD1280 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 19, Length = 0x10, Offset = 0xD1290 });

            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 20, Length = 0x10, Offset = 0xD12A0 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 21, Length = 0x10, Offset = 0xD12B0 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 22, Length = 0x10, Offset = 0xD12C0 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 23, Length = 0x10, Offset = 0xD12D0 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 24, Length = 0x10, Offset = 0xD12E0 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 25, Length = 0x10, Offset = 0xD12F0 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 26, Length = 0x10, Offset = 0xD1300 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 27, Length = 0x10, Offset = 0xD1310 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 28, Length = 0x10, Offset = 0xD1320 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 29, Length = 0x10, Offset = 0xD1330 });

            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 30, Length = 0x10, Offset = 0xD1340 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 31, Length = 0x10, Offset = 0xD1350 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 32, Length = 0x10, Offset = 0xD1360 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 33, Length = 0x10, Offset = 0xD1370 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 34, Length = 0x10, Offset = 0xD1380 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 35, Length = 0x10, Offset = 0xD1390 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 36, Length = 0x10, Offset = 0xD13A0 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 37, Length = 0x10, Offset = 0xD13B0 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 38, Length = 0x10, Offset = 0xD13C0 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 39, Length = 0x10, Offset = 0xD13D0 });

            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 40, Length = 0x10, Offset = 0xD13E0 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 41, Length = 0x10, Offset = 0xD13F0 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 42, Length = 0x10, Offset = 0xD1400 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 43, Length = 0x10, Offset = 0xD1410 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 44, Length = 0x10, Offset = 0xD1420 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 45, Length = 0x10, Offset = 0xD1430 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 46, Length = 0x10, Offset = 0xD1440 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 47, Length = 0x10, Offset = 0xD1450 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 48, Length = 0x10, Offset = 0xD1460 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 49, Length = 0x10, Offset = 0xD1470 });

            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 50, Length = 0x10, Offset = 0xD1480 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 51, Length = 0x10, Offset = 0xD1490 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 52, Length = 0x10, Offset = 0xD14A0 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 53, Length = 0x10, Offset = 0xD14B0 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 54, Length = 0x10, Offset = 0xD14C0 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 55, Length = 0x10, Offset = 0xD14D0 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 56, Length = 0x10, Offset = 0xD14E0 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 57, Length = 0x10, Offset = 0xD14F0 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 58, Length = 0x10, Offset = 0xD1500 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 59, Length = 0x10, Offset = 0xD1510 });

            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 60, Length = 0x10, Offset = 0xD1520 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 61, Length = 0x10, Offset = 0xD1530 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 62, Length = 0x10, Offset = 0xD1540 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 63, Length = 0x10, Offset = 0xD1550 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 64, Length = 0x10, Offset = 0xD1560 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 65, Length = 0x10, Offset = 0xD1570 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 66, Length = 0x10, Offset = 0xD1580 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 67, Length = 0x10, Offset = 0xD1590 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 68, Length = 0x10, Offset = 0xD15A0 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 69, Length = 0x10, Offset = 0xD15B0 });

            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 70, Length = 0x10, Offset = 0xD15C0 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 71, Length = 0x10, Offset = 0xD15D0 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 72, Length = 0x10, Offset = 0xD15E0 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 73, Length = 0x10, Offset = 0xD15F0 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 74, Length = 0x10, Offset = 0xD1600 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 75, Length = 0x10, Offset = 0xD1610 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 76, Length = 0x10, Offset = 0xD1620 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 77, Length = 0x10, Offset = 0xD1630 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 78, Length = 0x10, Offset = 0xD1640 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 79, Length = 0x10, Offset = 0xD1650 });

            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 80, Length = 0x10, Offset = 0xD1660 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 81, Length = 0x10, Offset = 0xD1670 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 82, Length = 0x10, Offset = 0xD1680 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 83, Length = 0x10, Offset = 0xD1690 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 84, Length = 0x10, Offset = 0xD16A0 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 85, Length = 0x10, Offset = 0xD16B0 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 86, Length = 0x10, Offset = 0xD16C0 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 87, Length = 0x10, Offset = 0xD16D0 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 88, Length = 0x10, Offset = 0xD16E0 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 89, Length = 0x10, Offset = 0xD16F0 });

            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 90, Length = 0x10, Offset = 0xD1700 });
        }
        
        protected override void CreateCodeEffectNames()
        {
            result.CodeEffects.Add(new Config.ConfigCodeEffectInfos { Offset = 0x5BF8, TypeIndex = (int)Config.ConfigCodeEffectInfos.Type.AbilityAssist, Description = "공격력보조", Editable = false, SubEdit = 1 });
            result.CodeEffects.Add(new Config.ConfigCodeEffectInfos { Offset = 0x5C00, TypeIndex = (int)Config.ConfigCodeEffectInfos.Type.AbilityAssist, Description = "방어력보조", Editable = false, SubEdit = 1 });
            result.CodeEffects.Add(new Config.ConfigCodeEffectInfos { Offset = 0x5C08, TypeIndex = (int)Config.ConfigCodeEffectInfos.Type.AbilityAssist, Description = "정신력보조", Editable = false, SubEdit = 1 });
            result.CodeEffects.Add(new Config.ConfigCodeEffectInfos { Offset = 0x5C10, TypeIndex = (int)Config.ConfigCodeEffectInfos.Type.AbilityAssist, Description = "순발력보조", Editable = false, SubEdit = 1 });
            result.CodeEffects.Add(new Config.ConfigCodeEffectInfos { Offset = 0x5C18, TypeIndex = (int)Config.ConfigCodeEffectInfos.Type.AbilityAssist, Description = "사기보조", Editable = false, SubEdit = 1 });
            result.CodeEffects.Add(new Config.ConfigCodeEffectInfos { Offset = 0x5C20, TypeIndex = (int)Config.ConfigCodeEffectInfos.Type.AbilityAssist, Description = "HP보조", Editable = false, SubEdit = 1 });
            result.CodeEffects.Add(new Config.ConfigCodeEffectInfos { Offset = 0x5C28, TypeIndex = (int)Config.ConfigCodeEffectInfos.Type.AbilityAssist, Description = "MP보조", Editable = false, SubEdit = 1 });
            result.CodeEffects.Add(new Config.ConfigCodeEffectInfos { Offset = 0x5C30, TypeIndex = (int)Config.ConfigCodeEffectInfos.Type.AbilityAssist, Description = "획득Exp보조", Editable = false, SubEdit = 0 });
            result.CodeEffects.Add(new Config.ConfigCodeEffectInfos { Offset = 0x5C38, TypeIndex = (int)Config.ConfigCodeEffectInfos.Type.AbilityAssist, Description = "이동력보조", Editable = false, SubEdit = 0 });
            result.CodeEffects.Add(new Config.ConfigCodeEffectInfos { Offset = 0x361F8, TypeIndex = (int)Config.ConfigCodeEffectInfos.Type.AbilityAssist, Description = "능력정화", Editable = false, SubEdit = 0 });
            result.CodeEffects.Add(new Config.ConfigCodeEffectInfos { Offset = 0x3B7D4, TypeIndex = (int)Config.ConfigCodeEffectInfos.Type.AbilityAssist, Description = "능력각성", Editable = true, SubEdit = 0 });
            result.CodeEffects.Add(new Config.ConfigCodeEffectInfos { Offset = 0x3BF56, TypeIndex = (int)Config.ConfigCodeEffectInfos.Type.AbilityAssist, Description = "일치단결", Editable = true, SubEdit = 0 });
            result.CodeEffects.Add(new Config.ConfigCodeEffectInfos { Offset = 0x782B3, TypeIndex = (int)Config.ConfigCodeEffectInfos.Type.AbilityAssist, Description = "일기당천", Editable = true, SubEdit = 0 });
            result.CodeEffects.Add(new Config.ConfigCodeEffectInfos { Offset = 0x5AA92, TypeIndex = (int)Config.ConfigCodeEffectInfos.Type.AbilityAssist, Description = "악전고투", Editable = true, SubEdit = 0 });
            result.CodeEffects.Add(new Config.ConfigCodeEffectInfos { Offset = 0x5A64, TypeIndex = (int)Config.ConfigCodeEffectInfos.Type.AbilityAssist, Description = "MP공격", Editable = true, SubEdit = 0 });
            result.CodeEffects.Add(new Config.ConfigCodeEffectInfos { Offset = 0x3B7E6, TypeIndex = (int)Config.ConfigCodeEffectInfos.Type.AbilityAssist, Description = "만부부당", Editable = true, SubEdit = 0 });

            result.CodeEffects.Add(new Config.ConfigCodeEffectInfos { Offset = 0x4EDB1, TypeIndex = (int)Config.ConfigCodeEffectInfos.Type.SpecialAttack, Description = "치명일격", Editable = true, SubEdit = 0 });
            result.CodeEffects.Add(new Config.ConfigCodeEffectInfos { Offset = 0x50EB, TypeIndex = (int)Config.ConfigCodeEffectInfos.Type.SpecialAttack, Description = "주동/연환공격", Editable = false, SubEdit = 0 });
            result.CodeEffects.Add(new Config.ConfigCodeEffectInfos { Offset = 0xA0BEA, TypeIndex = (int)Config.ConfigCodeEffectInfos.Type.SpecialAttack, Description = "인도/분전공격", Editable = false, SubEdit = 0 });
            result.CodeEffects.Add(new Config.ConfigCodeEffectInfos { Offset = 0x10489, TypeIndex = (int)Config.ConfigCodeEffectInfos.Type.SpecialAttack, Description = "강화/돌파공격", Editable = true, SubEdit = 0 });
            result.CodeEffects.Add(new Config.ConfigCodeEffectInfos { Offset = 0x6C5A, TypeIndex = (int)Config.ConfigCodeEffectInfos.Type.SpecialAttack, Description = "범위공격", Editable = false, SubEdit = 0 });
            result.CodeEffects.Add(new Config.ConfigCodeEffectInfos { Offset = 0x587C, TypeIndex = (int)Config.ConfigCodeEffectInfos.Type.SpecialAttack, Description = "무반격공격", Editable = true, SubEdit = 0 });
            result.CodeEffects.Add(new Config.ConfigCodeEffectInfos { Offset = 0x5820, TypeIndex = (int)Config.ConfigCodeEffectInfos.Type.SpecialAttack, Description = "반격후반격", Editable = true, SubEdit = 0 });
            result.CodeEffects.Add(new Config.ConfigCodeEffectInfos { Offset = 0x5F8A, TypeIndex = (int)Config.ConfigCodeEffectInfos.Type.SpecialAttack, Description = "흡혈공격", Editable = true, SubEdit = 0 });
            result.CodeEffects.Add(new Config.ConfigCodeEffectInfos { Offset = 0x5FDB, TypeIndex = (int)Config.ConfigCodeEffectInfos.Type.SpecialAttack, Description = "금전약탈", Editable = true, SubEdit = 0 });
            result.CodeEffects.Add(new Config.ConfigCodeEffectInfos { Offset = 0x10312, TypeIndex = (int)Config.ConfigCodeEffectInfos.Type.SpecialAttack, Description = "선제공격", Editable = true, SubEdit = 0 });
            result.CodeEffects.Add(new Config.ConfigCodeEffectInfos { Offset = 0x3832A, TypeIndex = (int)Config.ConfigCodeEffectInfos.Type.SpecialAttack, Description = "지원공격", Editable = true, SubEdit = 0 });
            result.CodeEffects.Add(new Config.ConfigCodeEffectInfos { Offset = 0x3B22B, TypeIndex = (int)Config.ConfigCodeEffectInfos.Type.SpecialAttack, Description = "돌진공격", Editable = true, SubEdit = 0 });
            result.CodeEffects.Add(new Config.ConfigCodeEffectInfos { Offset = 0x3B29A, TypeIndex = (int)Config.ConfigCodeEffectInfos.Type.SpecialAttack, Description = "반격강화", Editable = true, SubEdit = 0 });
            result.CodeEffects.Add(new Config.ConfigCodeEffectInfos { Offset = 0x78310, TypeIndex = (int)Config.ConfigCodeEffectInfos.Type.SpecialAttack, Description = "보복공격", Editable = true, SubEdit = 0 });
            result.CodeEffects.Add(new Config.ConfigCodeEffectInfos { Offset = 0x3B7C2, TypeIndex = (int)Config.ConfigCodeEffectInfos.Type.SpecialAttack, Description = "기습공격", Editable = false, SubEdit = 0 });
            result.CodeEffects.Add(new Config.ConfigCodeEffectInfos { Offset = 0x3ECF7, TypeIndex = (int)Config.ConfigCodeEffectInfos.Type.SpecialAttack, Description = "간접공격1", Editable = false, SubEdit = 0 });
            result.CodeEffects.Add(new Config.ConfigCodeEffectInfos { Offset = 0x3ED02, TypeIndex = (int)Config.ConfigCodeEffectInfos.Type.SpecialAttack, Description = "간접공격2", Editable = true, SubEdit = 1 });
            result.CodeEffects.Add(new Config.ConfigCodeEffectInfos { Offset = 0x3ED14, TypeIndex = (int)Config.ConfigCodeEffectInfos.Type.SpecialAttack, Description = "간접공격3", Editable = true, SubEdit = 2 });
            result.CodeEffects.Add(new Config.ConfigCodeEffectInfos { Offset = 0x3B0B1, TypeIndex = (int)Config.ConfigCodeEffectInfos.Type.SpecialAttack, Description = "방어무시", Editable = false, SubEdit = 3 });

            result.CodeEffects.Add(new Config.ConfigCodeEffectInfos { Offset = 0x3AA7A, TypeIndex = (int)Config.ConfigCodeEffectInfos.Type.AttackAcc, Description = "공격백발백중", Editable = true, SubEdit = 0 });
            result.CodeEffects.Add(new Config.ConfigCodeEffectInfos { Offset = 0x3AA92, TypeIndex = (int)Config.ConfigCodeEffectInfos.Type.AttackAcc, Description = "공격명중보조", Editable = true, SubEdit = 0 });
            result.CodeEffects.Add(new Config.ConfigCodeEffectInfos { Offset = 0x3AAB7, TypeIndex = (int)Config.ConfigCodeEffectInfos.Type.AttackAcc, Description = "공격방어보조", Editable = true, SubEdit = 0 });
            result.CodeEffects.Add(new Config.ConfigCodeEffectInfos { Offset = 0x102E3, TypeIndex = (int)Config.ConfigCodeEffectInfos.Type.AttackAcc, Description = "전방어보조", Editable = true, SubEdit = 0 });

            result.CodeEffects.Add(new Config.ConfigCodeEffectInfos { Offset = 0x3B659, TypeIndex = (int)Config.ConfigCodeEffectInfos.Type.Magic, Description = "원소책략보조", Editable = true, SubEdit = 0 });
            result.CodeEffects.Add(new Config.ConfigCodeEffectInfos { Offset = 0x51C5, TypeIndex = (int)Config.ConfigCodeEffectInfos.Type.Magic, Description = "책략위력보조", Editable = true, SubEdit = 0 });
            result.CodeEffects.Add(new Config.ConfigCodeEffectInfos { Offset = 0x4D351, TypeIndex = (int)Config.ConfigCodeEffectInfos.Type.Magic, Description = "MP절약", Editable = true, SubEdit = 0 });
            result.CodeEffects.Add(new Config.ConfigCodeEffectInfos { Offset = 0x1F317, TypeIndex = (int)Config.ConfigCodeEffectInfos.Type.Magic, Description = "날씨무시책략", Editable = true, SubEdit = 0 });
            result.CodeEffects.Add(new Config.ConfigCodeEffectInfos { Offset = 0x1CD33, TypeIndex = (int)Config.ConfigCodeEffectInfos.Type.Magic, Description = "지형무시책략", Editable = true, SubEdit = 0 });
            result.CodeEffects.Add(new Config.ConfigCodeEffectInfos { Offset = 0xA152C, TypeIndex = (int)Config.ConfigCodeEffectInfos.Type.Magic, Description = "책략모방", Editable = true, SubEdit = 0 });
            result.CodeEffects.Add(new Config.ConfigCodeEffectInfos { Offset = 0x3ABD1, TypeIndex = (int)Config.ConfigCodeEffectInfos.Type.Magic, Description = "책략백발백중", Editable = true, SubEdit = 0 });
            result.CodeEffects.Add(new Config.ConfigCodeEffectInfos { Offset = 0x3ADA7, TypeIndex = (int)Config.ConfigCodeEffectInfos.Type.Magic, Description = "책략명중보조", Editable = true, SubEdit = 0 });
            result.CodeEffects.Add(new Config.ConfigCodeEffectInfos { Offset = 0x3ACB4, TypeIndex = (int)Config.ConfigCodeEffectInfos.Type.Magic, Description = "책략방어보조", Editable = true, SubEdit = 0 });
            result.CodeEffects.Add(new Config.ConfigCodeEffectInfos { Offset = 0x3D5B0, TypeIndex = (int)Config.ConfigCodeEffectInfos.Type.Magic, Description = "책략사용", Editable = false, SubEdit = 0 });
            result.CodeEffects.Add(new Config.ConfigCodeEffectInfos { Offset = 0x384BF, TypeIndex = (int)Config.ConfigCodeEffectInfos.Type.Magic, Description = "연속책략", Editable = true, SubEdit = 0 });
            result.CodeEffects.Add(new Config.ConfigCodeEffectInfos { Offset = 0x1F388, TypeIndex = (int)Config.ConfigCodeEffectInfos.Type.Magic, Description = "사신소환", Editable = false, SubEdit = 0 });

            result.CodeEffects.Add(new Config.ConfigCodeEffectInfos { Offset = 0x3721F, TypeIndex = (int)Config.ConfigCodeEffectInfos.Type.StateEffectAttack, Description = "부동공격", Editable = true, SubEdit = 0 });
            result.CodeEffects.Add(new Config.ConfigCodeEffectInfos { Offset = 0x37220, TypeIndex = (int)Config.ConfigCodeEffectInfos.Type.StateEffectAttack, Description = "금책공격", Editable = true, SubEdit = 0 });
            result.CodeEffects.Add(new Config.ConfigCodeEffectInfos { Offset = 0x37221, TypeIndex = (int)Config.ConfigCodeEffectInfos.Type.StateEffectAttack, Description = "혼란공격", Editable = true, SubEdit = 0 });
            result.CodeEffects.Add(new Config.ConfigCodeEffectInfos { Offset = 0x37222, TypeIndex = (int)Config.ConfigCodeEffectInfos.Type.StateEffectAttack, Description = "중독공격", Editable = true, SubEdit = 0 });
            result.CodeEffects.Add(new Config.ConfigCodeEffectInfos { Offset = 0x4E6A, TypeIndex = (int)Config.ConfigCodeEffectInfos.Type.StateEffectAttack, Description = "상태이상공격", Editable = true, SubEdit = 1 });

            result.CodeEffects.Add(new Config.ConfigCodeEffectInfos { Offset = 0x3C25A, TypeIndex = (int)Config.ConfigCodeEffectInfos.Type.TurnCure, Description = "매턴 HP 회복", Editable = true, SubEdit = 0 });
            result.CodeEffects.Add(new Config.ConfigCodeEffectInfos { Offset = 0x3C297, TypeIndex = (int)Config.ConfigCodeEffectInfos.Type.TurnCure, Description = "매턴 MP 회복", Editable = true, SubEdit = 0 });
            result.CodeEffects.Add(new Config.ConfigCodeEffectInfos { Offset = 0x3BB46, TypeIndex = (int)Config.ConfigCodeEffectInfos.Type.TurnCure, Description = "매턴 상태 회복", Editable = true, SubEdit = 0 });
            result.CodeEffects.Add(new Config.ConfigCodeEffectInfos { Offset = 0x3C2E3, TypeIndex = (int)Config.ConfigCodeEffectInfos.Type.TurnCure, Description = "매턴 Exp 획득", Editable = true, SubEdit = 0 });
            result.CodeEffects.Add(new Config.ConfigCodeEffectInfos { Offset = 0x3C30E, TypeIndex = (int)Config.ConfigCodeEffectInfos.Type.TurnCure, Description = "매턴 무기 Exp 획득", Editable = true, SubEdit = 0 });
            result.CodeEffects.Add(new Config.ConfigCodeEffectInfos { Offset = 0x3C339, TypeIndex = (int)Config.ConfigCodeEffectInfos.Type.TurnCure, Description = "매턴 방어 Exp 획득", Editable = true, SubEdit = 0 });
            result.CodeEffects.Add(new Config.ConfigCodeEffectInfos { Offset = 0x3C42D, TypeIndex = (int)Config.ConfigCodeEffectInfos.Type.TurnCure, Description = "자동상승", Editable = false, SubEdit = 0 });

            result.CodeEffects.Add(new Config.ConfigCodeEffectInfos { Offset = 0x37219, TypeIndex = (int)Config.ConfigCodeEffectInfos.Type.DeburfAttack, Description = "공격저하", Editable = true, SubEdit = 0 });
            result.CodeEffects.Add(new Config.ConfigCodeEffectInfos { Offset = 0x3721A, TypeIndex = (int)Config.ConfigCodeEffectInfos.Type.DeburfAttack, Description = "방어저하", Editable = true, SubEdit = 0 });
            result.CodeEffects.Add(new Config.ConfigCodeEffectInfos { Offset = 0x3721B, TypeIndex = (int)Config.ConfigCodeEffectInfos.Type.DeburfAttack, Description = "정신저하", Editable = true, SubEdit = 0 });
            result.CodeEffects.Add(new Config.ConfigCodeEffectInfos { Offset = 0x3721C, TypeIndex = (int)Config.ConfigCodeEffectInfos.Type.DeburfAttack, Description = "순발저하", Editable = true, SubEdit = 0 });
            result.CodeEffects.Add(new Config.ConfigCodeEffectInfos { Offset = 0x3721D, TypeIndex = (int)Config.ConfigCodeEffectInfos.Type.DeburfAttack, Description = "사기저하", Editable = true, SubEdit = 0 });
            result.CodeEffects.Add(new Config.ConfigCodeEffectInfos { Offset = 0x3721E, TypeIndex = (int)Config.ConfigCodeEffectInfos.Type.DeburfAttack, Description = "이동저하", Editable = true, SubEdit = 0 });
            result.CodeEffects.Add(new Config.ConfigCodeEffectInfos { Offset = 0x72164, TypeIndex = (int)Config.ConfigCodeEffectInfos.Type.DeburfAttack, Description = "속성이상공격", Editable = true, SubEdit = 0 });

            result.CodeEffects.Add(new Config.ConfigCodeEffectInfos { Offset = 0x3B1ED, TypeIndex = (int)Config.ConfigCodeEffectInfos.Type.DecreaseDmg, Description = "간접피해감소", Editable = true, SubEdit = 0 });
            result.CodeEffects.Add(new Config.ConfigCodeEffectInfos { Offset = 0x3B259, TypeIndex = (int)Config.ConfigCodeEffectInfos.Type.DecreaseDmg, Description = "물리피해감소", Editable = true, SubEdit = 0 });
            result.CodeEffects.Add(new Config.ConfigCodeEffectInfos { Offset = 0x3B679, TypeIndex = (int)Config.ConfigCodeEffectInfos.Type.DecreaseDmg, Description = "책략피해감소", Editable = true, SubEdit = 0 });
            
            result.CodeEffects.Add(new Config.ConfigCodeEffectInfos { Offset = 0x51D7, TypeIndex = (int)Config.ConfigCodeEffectInfos.Type.Defence, Description = "치명일격방어", Editable = true, SubEdit = 0 });
            result.CodeEffects.Add(new Config.ConfigCodeEffectInfos { Offset = 0x5335, TypeIndex = (int)Config.ConfigCodeEffectInfos.Type.Defence, Description = "이차공격방어", Editable = true, SubEdit = 0 });
            result.CodeEffects.Add(new Config.ConfigCodeEffectInfos { Offset = 0x3ECD1, TypeIndex = (int)Config.ConfigCodeEffectInfos.Type.Defence, Description = "간접공격방어", Editable = true, SubEdit = 0 });
            result.CodeEffects.Add(new Config.ConfigCodeEffectInfos { Offset = 0x7205B, TypeIndex = (int)Config.ConfigCodeEffectInfos.Type.Defence, Description = "상태이상반사", Editable = true, SubEdit = 0 });
            result.CodeEffects.Add(new Config.ConfigCodeEffectInfos { Offset = 0xA151A, TypeIndex = (int)Config.ConfigCodeEffectInfos.Type.Defence, Description = "MP방어", Editable = true, SubEdit = 2 });
            result.CodeEffects.Add(new Config.ConfigCodeEffectInfos { Offset = 0xA13AD, TypeIndex = (int)Config.ConfigCodeEffectInfos.Type.Defence, Description = "금전방어", Editable = true, SubEdit = 1 });

            result.CodeEffects.Add(new Config.ConfigCodeEffectInfos { Offset = 0x3EC67, TypeIndex = (int)Config.ConfigCodeEffectInfos.Type.TerrainAssist, Description = "지형효과보조", Editable = true, SubEdit = 0 });
            result.CodeEffects.Add(new Config.ConfigCodeEffectInfos { Offset = 0xA0AD2, TypeIndex = (int)Config.ConfigCodeEffectInfos.Type.TerrainAssist, Description = "수전보조", Editable = true, SubEdit = 0 });
            result.CodeEffects.Add(new Config.ConfigCodeEffectInfos { Offset = 0x371A0, TypeIndex = (int)Config.ConfigCodeEffectInfos.Type.TerrainAssist, Description = "돌격이동", Editable = true, SubEdit = 0 });
            result.CodeEffects.Add(new Config.ConfigCodeEffectInfos { Offset = 0x3EC7C, TypeIndex = (int)Config.ConfigCodeEffectInfos.Type.TerrainAssist, Description = "험로이동", Editable = true, SubEdit = 0 });
            result.CodeEffects.Add(new Config.ConfigCodeEffectInfos { Offset = 0x2E80, TypeIndex = (int)Config.ConfigCodeEffectInfos.Type.TerrainAssist, Description = "비상이동", Editable = true, SubEdit = 0 });

            result.CodeEffects.Add(new Config.ConfigCodeEffectInfos { Offset = 0xA1491, TypeIndex = (int)Config.ConfigCodeEffectInfos.Type.Etc, Description = "연속행동", Editable = true, SubEdit = 0 });
            result.CodeEffects.Add(new Config.ConfigCodeEffectInfos { Offset = 0x103E9, TypeIndex = (int)Config.ConfigCodeEffectInfos.Type.Etc, Description = "SP보조", Editable = true, SubEdit = 0 });
            result.CodeEffects.Add(new Config.ConfigCodeEffectInfos { Offset = 0x222E8, TypeIndex = (int)Config.ConfigCodeEffectInfos.Type.Etc, Description = "자동사용", Editable = false, SubEdit = 0 });
            result.CodeEffects.Add(new Config.ConfigCodeEffectInfos { Offset = 0x40275, TypeIndex = (int)Config.ConfigCodeEffectInfos.Type.Etc, Description = "물리반사", Editable = true, SubEdit = 0 });
            result.CodeEffects.Add(new Config.ConfigCodeEffectInfos { Offset = 0x29FAB, TypeIndex = (int)Config.ConfigCodeEffectInfos.Type.Etc, Description = "공훈추가", Editable = true, SubEdit = 0 });
            result.CodeEffects.Add(new Config.ConfigCodeEffectInfos { Offset = 0x78277, TypeIndex = (int)Config.ConfigCodeEffectInfos.Type.Etc, Description = "은신방어", Editable = true, SubEdit = 0 });
            result.CodeEffects.Add(new Config.ConfigCodeEffectInfos { Offset = 0x4EDD1, TypeIndex = (int)Config.ConfigCodeEffectInfos.Type.Etc, Description = "공격유도", Editable = true, SubEdit = 0 });
            result.CodeEffects.Add(new Config.ConfigCodeEffectInfos { Offset = 0x3B80A, TypeIndex = (int)Config.ConfigCodeEffectInfos.Type.Etc, Description = "피해전가", Editable = true, SubEdit = 0 });
            result.CodeEffects.Add(new Config.ConfigCodeEffectInfos { Offset = 0x3B81C, TypeIndex = (int)Config.ConfigCodeEffectInfos.Type.Etc, Description = "특기모방", Editable = true, SubEdit = 0 });
            result.CodeEffects.Add(new Config.ConfigCodeEffectInfos { Offset = 0x3B82E, TypeIndex = (int)Config.ConfigCodeEffectInfos.Type.Etc, Description = "특기차단", Editable = true, SubEdit = 0 });
            result.CodeEffects.Add(new Config.ConfigCodeEffectInfos { Offset = 0x3B840, TypeIndex = (int)Config.ConfigCodeEffectInfos.Type.Etc, Description = "연속이동", Editable = true, SubEdit = 0 });

        }

        protected override void CreateCodes()
        {
            result.Codes.Add("Even", new Config.ConfigExeCodeInfo[]
            {
            new Config.ConfigExeCodeInfo { offset = 0x665, CodeArr = "37 73 1E 3C 28 73 04 B0 64 EB 08 2C 27 6B C0 28 83 C0 64" },
            new Config.ConfigExeCodeInfo { offset = 0x6539, CodeArr = "D1 E0" },
            new Config.ConfigExeCodeInfo { offset = 0x1C4BB, CodeArr = "D1 F8" },
            new Config.ConfigExeCodeInfo { offset = 0x1C5FB, CodeArr = "37 6A 00 EB 05 6A 32" },
            new Config.ConfigExeCodeInfo { offset = 0x2A097, CodeArr = "37 73 31 8B 55 08 D1 E6 03 D6 3C 28 73 06 66 B8 64 00 EB 08 2C 27 6B C0 28 83 C0 64" },
            new Config.ConfigExeCodeInfo { offset = 0x3B903, CodeArr = "32 76 10 83 EA 32 6B D2 02" },
            new Config.ConfigExeCodeInfo { offset = 0x3BB60, CodeArr = "90 90 EB 2A 6A 00 8B 4D FC E8 72 17 FE FF 0F B6 C0 83 F8 32 7E 04 B0 0A EB 14 6A 00 8B 4D FC E8 5C 17 FE FF 90 90" },
            new Config.ConfigExeCodeInfo { offset = 0x3C048, CodeArr = "2D 72 04 B0 05 EB 0A 3C 28" },
            new Config.ConfigExeCodeInfo { offset = 0x4C030, CodeArr = "19 88 51 02 EB 09 0F B6 51 03 89 55 F8 D1 E2" },
            new Config.ConfigExeCodeInfo { offset = 0x598AD, CodeArr = "D1 E2" },
            new Config.ConfigExeCodeInfo { offset = 0x59949, CodeArr = "2D 74 01 42 52 FF 75 FC FF 15 E8 62 48 00 8B 4D 0C 8B 45 F4 33 D2 80 7C 08 21 23" },
            new Config.ConfigExeCodeInfo { offset = 0x614D2, CodeArr = "37 73 E6 3C 28 73 0E 83 FE 64 72 22 83 EE 64 FE 44 11 21 EB E5 2C 27 6B C0 28 83 C0 64" },
            new Config.ConfigExeCodeInfo { offset = 0xD2613, CodeArr = "23" },
            });

            result.Codes.Add("Odd", new Config.ConfigExeCodeInfo[]
            {
            new Config.ConfigExeCodeInfo { offset = 0x665, CodeArr = "6E 73 1E 3C 50 73 04 B0 32 EB 08 2C 4F 6B C0 0A 83 C0 37" },
            new Config.ConfigExeCodeInfo { offset = 0x6539, CodeArr = "90 90" },
            new Config.ConfigExeCodeInfo { offset = 0x1C4BB, CodeArr = "90 90" },
            new Config.ConfigExeCodeInfo { offset = 0x1C5FB, CodeArr = "6E 6A 00 EB 05 6A 64" },
            new Config.ConfigExeCodeInfo { offset = 0x2A097, CodeArr = "6E 73 31 8B 55 08 D1 E6 03 D6 3C 50 73 06 66 B8 32 00 EB 08 2C 4F 6B C0 0A 83 C0 37" },
            new Config.ConfigExeCodeInfo { offset = 0x3B903, CodeArr = "64 76 10 83 EA 64 6B D2 01" },
            new Config.ConfigExeCodeInfo { offset = 0x3BB60, CodeArr = "D1 E8 EB 2A 6A 00 8B 4D FC E8 72 17 FE FF 0F B6 C0 83 F8 64 7E 04 B0 0A EB 14 6A 00 8B 4D FC E8 5C 17 FE FF D1 E8" },
            new Config.ConfigExeCodeInfo { offset = 0x3C048, CodeArr = "5A 72 04 B0 05 EB 0A 3C 50" },
            new Config.ConfigExeCodeInfo { offset = 0x4C030, CodeArr = "32 88 51 02 EB 09 0F B6 51 03 89 55 F8 90 90" },
            new Config.ConfigExeCodeInfo { offset = 0x598AD, CodeArr = "90 90" },
            new Config.ConfigExeCodeInfo { offset = 0x59949, CodeArr = "5A 74 01 42 52 FF 75 FC FF 15 E8 62 48 00 8B 4D 0C 8B 45 F4 33 D2 80 7C 08 21 46" },
            new Config.ConfigExeCodeInfo { offset = 0x614D2, CodeArr = "6E 73 E6 3C 50 73 0E 83 FE 32 72 22 83 EE 32 FE 44 11 21 EB E5 2C 4F 6B C0 0A 83 C0 37" },
            new Config.ConfigExeCodeInfo { offset = 0xD2613, CodeArr = "46" },
            });
        }
    }
}
