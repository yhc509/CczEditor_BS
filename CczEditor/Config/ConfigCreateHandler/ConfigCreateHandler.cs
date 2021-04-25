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
            result.HitAreaNames.Add("군웅 경기병");
            result.HitAreaNames.Add("보병");
            result.HitAreaNames.Add("궁병 노기병");
            result.HitAreaNames.Add("노병");
            result.HitAreaNames.Add("연노병");
            result.HitAreaNames.Add("폭염");
            result.HitAreaNames.Add("몰우전");
            result.HitAreaNames.Add("경포차");
            result.HitAreaNames.Add("벽력차");
            result.HitAreaNames.Add("궁기병");
            result.HitAreaNames.Add("전체");
            result.HitAreaNames.Add("무공격");
            result.HitAreaNames.Add("대몰우전");
            result.HitAreaNames.Add("거대몰우전");
            result.HitAreaNames.Add("특수");
            result.HitAreaNames.Add("대방괴");
            result.HitAreaNames.Add("자객1");
            result.HitAreaNames.Add("자객2");
            result.HitAreaNames.Add("자객3");
            result.HitAreaNames.Add("대폭염");
            result.HitAreaNames.Add("방괴1");
            result.HitAreaNames.Add("방괴2");
            result.HitAreaNames.Add("방괴3");
            result.HitAreaNames.Add("교차일격");
            result.HitAreaNames.Add("교차이격");
            result.HitAreaNames.Add("청정");
            result.HitAreaNames.Add("운하");
            result.HitAreaNames.Add("등궁");
            result.HitAreaNames.Add("노");
            result.HitAreaNames.Add("참월");
            result.HitAreaNames.Add("사방죽궁");
            result.HitAreaNames.Add("남만궁");
            result.HitAreaNames.Add("12격");
        }

        protected virtual void CreateEffectAreaNames()
        {
            result.EffAreaNames.Add("무");
            result.EffAreaNames.Add("십자");
            result.EffAreaNames.Add("구궁");
            result.EffAreaNames.Add("몰우전");
            result.EffAreaNames.Add("이격");
            result.EffAreaNames.Add("육격");
            result.EffAreaNames.Add("대몰우전");
            result.EffAreaNames.Add("삼격");
            result.EffAreaNames.Add("방괴");
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
