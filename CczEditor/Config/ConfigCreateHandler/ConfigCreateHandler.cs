using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CczEditor
{
    public class ConfigCreateHandler
    {
        public Config result;

        public ConfigCreateHandler()
        {
            result = new Config();
        }

        public Config Execute()
        {
            CreateBaseInfo();
            CreateCodeOptionSettings();
            CreateDataSettings();
            CreateImsgSettings();
            CreateItemSettings();
            CreateExeSettings();
            CreateSaveSettings();
            CreateItemEffectNames();
            CreateForceNames();
            CreateForceCategoryNames();
            CreateHitAreaNames();
            CreateEffectAreaNames();
            CreateSpecialEffects();
            CreateSpecialSkillNames();
            CreateCodeEffectNames();
            CreateCodes();

            return result;
        }

        protected virtual void CreateBaseInfo()
        {
        }

        protected virtual void CreateCodeOptionSettings()
        {
        }

        protected virtual void CreateDataSettings()
        {
        }

        protected virtual void CreateImsgSettings()
        {
        }

        protected virtual void CreateItemSettings()
        {
        }

        protected virtual void CreateExeSettings()
        {
        }

        protected virtual void CreateSaveSettings()
        {
        }

        protected virtual void CreateItemEffectNames()
        {
        }

        protected virtual void CreateForceNames()
        {
        }

        protected virtual void CreateForceCategoryNames()
        {
        }

        protected virtual void CreateHitAreaNames()
        {
            result.HitAreaNames.Add("00,군웅 경기병");
            result.HitAreaNames.Add("01,보병");
            result.HitAreaNames.Add("02,궁병 노기병");
            result.HitAreaNames.Add("03,노병");
            result.HitAreaNames.Add("04,연노병");
            result.HitAreaNames.Add("05,폭염");
            result.HitAreaNames.Add("06,몰우전");
            result.HitAreaNames.Add("07,경포차");
            result.HitAreaNames.Add("08,벽력차");
            result.HitAreaNames.Add("09,궁기병");
            result.HitAreaNames.Add("0A,전체");
            result.HitAreaNames.Add("0B,무공격");
            result.HitAreaNames.Add("0C,대몰우전");
            result.HitAreaNames.Add("0D,거대몰우전");
            result.HitAreaNames.Add("0E,특수");
            result.HitAreaNames.Add("0F,대방괴");
            result.HitAreaNames.Add("10,자객1");
            result.HitAreaNames.Add("11,자객2");
            result.HitAreaNames.Add("12,자객3");
            result.HitAreaNames.Add("13,대폭염");
            result.HitAreaNames.Add("14,방괴1");
            result.HitAreaNames.Add("15,방괴2");
            result.HitAreaNames.Add("16,방괴3");
            result.HitAreaNames.Add("17,교차일격");
            result.HitAreaNames.Add("18,교차이격");
            result.HitAreaNames.Add("19,청정");
            result.HitAreaNames.Add("1A,운하");
            result.HitAreaNames.Add("1B,등궁");
            result.HitAreaNames.Add("1C,노");
            result.HitAreaNames.Add("1D,참월");
            result.HitAreaNames.Add("1E,사방죽궁");
            result.HitAreaNames.Add("1F,남만궁");
            result.HitAreaNames.Add("20,12격");
        }

        protected virtual void CreateEffectAreaNames()
        {
            result.EffAreaNames.Add("00,무");
            result.EffAreaNames.Add("01,십자");
            result.EffAreaNames.Add("02,구궁");
            result.EffAreaNames.Add("03,몰우전");
            result.EffAreaNames.Add("04,이격");
            result.EffAreaNames.Add("05,육격");
            result.EffAreaNames.Add("06,대몰우전");
            result.EffAreaNames.Add("07,삼격");
            result.EffAreaNames.Add("08,방괴");
        }

        protected virtual void CreateSpecialEffects()
        {
        }

        protected virtual void CreateSpecialSkillNames()
        {
        }

        protected virtual void CreateCodeEffectNames()
        {
        }

        protected virtual void CreateCodes()
        {
        }
    }
}
