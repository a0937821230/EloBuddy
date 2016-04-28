using System;
using System.Collections.Generic;
using System.Linq;
using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Menu.Values;

namespace Thresh
{
    public static class MenuManager
    {
        public static Menu AddonMenu;
        public static Dictionary<string, Menu> SubMenu = new Dictionary<string, Menu>();

        public static Menu MiscMenu
        {
            get { return GetSubMenu("Misc"); }
        }

        public static Menu PredictionMenu
        {
            get { return GetSubMenu("Prediction"); }
        }

        public static Menu DrawingsMenu
        {
            get { return GetSubMenu("Drawings"); }
        }

        public static void Init(EventArgs args)
        {
            var addonName = Champion.AddonName;
            var author = Champion.Author;
            AddonMenu = MainMenu.AddMenu("瑟雷西", "瑟雷西" + " by " + author + " v1.0000");
            AddonMenu.AddLabel("♫ 祝你玩得愉快 ♫");
            AddonMenu.AddLabel("作者：" + addonName + " made by " + author);
            AddonMenu.AddLabel("繁化：MAX ఠ_ఠ");

            SubMenu["預判"] = AddonMenu.AddSubMenu("預判", "預判 2.0");
            SubMenu["預判"].AddGroupLabel("Q 設定");
            SubMenu["預判"].Add("QCombo", new Slider("連招 命中率", 70));
            SubMenu["預判"].Add("QHarass", new Slider("騷擾 命中率", 75));
            SubMenu["預判"].AddGroupLabel("E 設定");
            SubMenu["預判"].Add("ECombo", new Slider("連招 命中率", 90));
            SubMenu["預判"].Add("EHarass", new Slider("騷擾 命中率", 95));

            SubMenu["連招"] = AddonMenu.AddSubMenu("連招", "連招");
            SubMenu["連招"].AddGroupLabel("Q 設定");
            SubMenu["連招"].AddStringList("Q1", "使用 Q1", new[] {"不使用", "只對選取目標", "對任何敵人"}, 1);
            SubMenu["連招"].AddStringList("Q2", "使用 Q2",
                new[] {"不使用", "有勾到人才Q2", "如果很接近目標才Q2"}, 1);
            SubMenu["連招"].AddGroupLabel("W 設定");
            SubMenu["連招"].AddStringList("W1", "使用 W", new[] {"不使用", "有勾到人才丟給隊友", "每次都丟"}, 1);
            SubMenu["連招"].Add("W2", new Slider("隊友血量小於 {0}% 使用 W", 20));
            SubMenu["連招"].AddStringList("E1", "E 刷的方向設定", new[] {"不使用", "拉", "推", "看隊伍整體血量來決定" }, 1);
            SubMenu["連招"].AddStringList("E2", "使用 E", new[] {"不使用", "只對選取目標", "對任何敵人"}, 3);
            SubMenu["連招"].AddGroupLabel("R 設定");
            SubMenu["連招"].Add("R1", new Slider("血量小於 {0}% 使用 R", 15));
            SubMenu["連招"].Add("R2", new Slider("敵人人數大於 {0} 個 使用 R", 3, 0, 5));

            SubMenu["騷擾"] = AddonMenu.AddSubMenu("騷擾", "騷擾");
            SubMenu["騷擾"].AddStringList("Q1", "使用 Q1", new[] {"不對任何人", "只對選取目標", "對任何敵人"}, 1);
            SubMenu["騷擾"].AddStringList("Q2", "使用 Q2",
                new[] {"不使用", "有勾到人才Q2", "如果很接近目標才Q2"}, 1);
            SubMenu["騷擾"].AddStringList("W1", "使用 W", new[] {"不使用", "有勾到人才 W 給隊友", "每次都丟"}, 1);
            SubMenu["騷擾"].Add("W2", new Slider("隊友血量小於 {0}% 使用 W", 35));
            SubMenu["騷擾"].AddStringList("E1", "E 刷的方向設定", new[] {"不使用", "拉", "推", "看隊伍整體血量來決定" }, 3);
            SubMenu["騷擾"].AddStringList("E2", "使用 E", new[] {"不使用", "只對選取目標", "對任何敵人"}, 3);
            SubMenu["騷擾"].Add("Mana", new Slider("藍量低於 {0}% 不騷擾:", 20));

            SubMenu["清野"] = AddonMenu.AddSubMenu("清野", "清野");
            SubMenu["清野"].Add("Q", new CheckBox("使用 Q"));
            SubMenu["清野"].Add("E", new CheckBox("使用 E"));
            SubMenu["清野"].Add("Mana", new Slider("藍量%:", 20));

            SubMenu["搶頭"] = AddonMenu.AddSubMenu("搶頭", "搶頭");
            SubMenu["搶頭"].Add("Q", new CheckBox("使用 Q", false));
            SubMenu["搶頭"].Add("E", new CheckBox("使用 E", false));
            SubMenu["搶頭"].Add("R", new CheckBox("使用 R", false));
            SubMenu["搶頭"].Add("Ignite", new CheckBox("使用 點燃"));

            SubMenu["逃跑"] = AddonMenu.AddSubMenu("逃跑", "逃跑");
            SubMenu["逃跑"].Add("W", new CheckBox("使用 W 給隊友"));
            SubMenu["逃跑"].Add("E", new CheckBox("使用 E 推敵人"));

            SubMenu["顯示"] = AddonMenu.AddSubMenu("顯示", "顯示");
            SubMenu["顯示"].Add("Disable", new CheckBox("停用所有顯示", false));
            SubMenu["顯示"].AddSeparator();
            SubMenu["顯示"].Add("Q", new CheckBox("顯示 Q 範圍"));
            SubMenu["顯示"].Add("W", new CheckBox("顯示 W 範圍", false));
            SubMenu["顯示"].Add("E", new CheckBox("顯示 E 範圍"));
            SubMenu["顯示"].Add("R", new CheckBox("顯示 R 範圍", false));
            SubMenu["顯示"].Add("Enemy.Target", new CheckBox("顯示敵人範圍"));
            SubMenu["顯示"].Add("Ally.Target", new CheckBox("顯示隊友範圍"));

            SubMenu["其他"] = AddonMenu.AddSubMenu("其他", "其他");
            SubMenu["其他"].Add("W", new Slider("對隊友使用 W，如果敵人超過 {0} 個", 3, 0, 5));
            SubMenu["其他"].Add("GapCloser.E", new CheckBox("用 E 來中斷技能 (推或拉)"));
            SubMenu["其他"].Add("GapCloser.Q", new CheckBox("用 Q 來中斷逃跑"));
            SubMenu["其他"].Add("Interrupter", new CheckBox("用 Q/E 來中斷持續施法"));
            SubMenu["其他"].Add("Turret.Q", new CheckBox("敵人在塔下 允許用 Q"));
            SubMenu["其他"].Add("Turret.E", new CheckBox("敵人在塔下 允許用 E"));
        }

        public static int GetSliderValue(this Menu m, string s)
        {
            if (m != null)
                return m[s].Cast<Slider>().CurrentValue;
            return -1;
        }

        public static bool GetCheckBoxValue(this Menu m, string s)
        {
            return m != null && m[s].Cast<CheckBox>().CurrentValue;
        }

        public static bool GetKeyBindValue(this Menu m, string s)
        {
            return m != null && m[s].Cast<KeyBind>().CurrentValue;
        }

        public static void AddStringList(this Menu m, string uniqueId, string displayName, string[] values,
            int defaultValue = 0)
        {
            var mode = m.Add(uniqueId, new Slider(displayName, defaultValue, 0, values.Length - 1));
            mode.DisplayName = displayName + ": " + values[mode.CurrentValue];
            mode.OnValueChange +=
                delegate(ValueBase<int> sender, ValueBase<int>.ValueChangeArgs args)
                {
                    sender.DisplayName = displayName + ": " + values[args.NewValue];
                };
        }

        public static Menu GetSubMenu(string s)
        {
            return (from t in SubMenu where t.Key.Equals(s) select t.Value).FirstOrDefault();
        }
    }
}
