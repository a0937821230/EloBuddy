using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Menu.Values;
using SharpDX;
using EloBuddy.Sandbox;

namespace AutoBuddy.Utilities.AutoShop
{
    internal class BuildCreator
    {
        private readonly string buildFile;
        private readonly CheckBox enabled;
        private readonly Label l;
        private readonly Menu menu;

        private readonly List<BuildElement> myBuild;
        private readonly PropertyInfo property;
        private readonly EasyShopV2 shop;
        private readonly string sugBuild;

        private readonly CheckBox toDefault;

        public BuildCreator(Menu parentMenu, string dir, string build="")
        {
            sugBuild = build;
            property = typeof(CheckBox).GetProperty("Position");


            string specialPath = null;
         
           specialPath = SandboxConfig.DataDirectory + "AutoBuddy\\Builds\\";
           

            // OLD buildFile = Path.Combine(specialPath + "\\" + AutoWalker.p.ChampionName + "-" + Game.MapId + ".txt");
            buildFile = Path.Combine(specialPath + AutoWalker.p.ChampionName + "-" + Game.MapId + ".txt");
            l = new Label("購買清單" + Game.MapId);
            enabled = new CheckBox("自動買裝", true);
            myBuild = new List<BuildElement>();

            menu = parentMenu.AddSubMenu("自動買裝: " + AutoWalker.p.ChampionName, "AB_SHOP_" + AutoWalker.p.ChampionName);
            menu.Add("eeewgrververv", l);
            menu.Add(AutoWalker.p.ChampionName + "啟用", enabled);
            LoadBuild();
            shop = new EasyShopV2(myBuild, enabled);







            Menu info = parentMenu.AddSubMenu("商店-說明");
            toDefault=new CheckBox("刪除自訂設置，並重置回默認 ADC 文件", false);

            PropertyInfo property2 = typeof(CheckBox).GetProperty("Size");

            property2.GetSetMethod(true).Invoke(toDefault, new object[] { new Vector2(400, 25) });
            info.Add("defbuild", toDefault);
            info.AddSeparator(150);
            info.AddLabel(
                @"



 由 TheYasuoMain 更新

輸入指令(聊天室中):

/b 物品名稱  :購買裝備，你不用精確的打出全名, 只需要打出物品開頭
 例如：弒血者 (BT): /b thebloodt   (當然你要知道物品DER英文溜~)

/s 物品名稱 : 要賣掉的項目

/buyhp:繼續購買血罐(如果角色還沒有血罐)
/stophp : 停止購買血罐，且不保留血罐(如果角色有血罐則會賣出)

AUTOSHOP WILL STOP WORKING IF FINDS ANY ITEMS IN INVENTORY THAT AREN'T
IN THE SEQUENCE.

Don't add to the list items that you can't buy, for example jungle items without smite.

Autoshop will stop if you have items that are not listed, so it's recommended
to sell whole inventory after changing list.

Builds are saved in C:\Users\Username\AppData\Roaming\EloBuddy\AutoBuddy\Builds
you can copy/share them.

             
Ａ
Abyssal Scepter            深淵杖
Aegis of the Legion        軍團盾
Amplifying Tome            20AP書.435($)AP書 
Archangel's Staff          大天使
Atma's Impaler             阿它馬
Avarice Blade              爆刀
Ｂ
B. F. Sword                BF                    
Banshee's Veil             護身符.女妖.十字架    
Berserker's Greaves        攻速鞋
Bilgewater Cutlass         母災
Blasting Wand              40AP杖.860($)AP杖
Boots of Mobility          2/5鞋
Boots of Speed             1速鞋
Boots of Swiftness         3速鞋
Brawler's Gloves           爆擊拳套
Ｃ
Catalyst the Protector     催化神石
Chain Vest                 700甲
Chalice of Harmony         聖杯.酒杯
Cloak of Agility           爆擊披風
Cloth Armor                300甲
Ｄ
Dagger                     攻速小刀
Deathfire Grasp            冥火.死火
Doran's Blade              多蘭劍
Doran's Ring               多蘭戒
Doran's Shield             多蘭盾
Ｅ
Elixir of Agility          大綠
Elixir of Brilliance       大藍
Elixir of Fortitude        大紅
Emblem of Valour           吸血腰帶.吸血牌
Executioner's Calling      劊子手
Ｆ
Faerie Charm               仙女護符
Fiendish Codex             惡魔法典
Force of Nature            自然之力
Frozen Heart               冰心
Frozen Mallet              冰槌
Ｇ
Giant's Belt               (巨人)腰帶.1110腰帶
Glacial Shroud             壽衣
Guardian Angel             復活甲
Guinsoo's Rageblade        鋼索
Ｈ
Haunting Guise             (小丑)面具
Health Potion              小紅
Heart of Gold              龜殼
Hextech Gunblade           槍刀
Hextech Revolver           手槍
Ｉ
Infinity Edge              無限(劍)
Innervating Locket         愛心盒子.愛心便當
Ｋ
Kage's Lucky Pick          升錢AP刀
Kindlegem                  這啥?火球?
Ｌ
Last Whisper               破防弓.(最後的)耳語
Leviathan                  魂甲.疊甲
Lich Bane                  無
Long Sword                 長劍
Ｍ
Madred's Bloodrazor        綠爪.血手.鬼手.鬼爪
Madred's Razors            CP爪.紅爪
Malady                     病毒刀
Mana Manipulator           燈泡
Mana Potion                小藍
Manamune                   水滴刀.+魔刀
Mejai's Soulstealer        魂書.疊書
Meki Pendant               (390)回魔棒
Mercury's Treads           水銀鞋.魔防鞋
Ｎ
Nashor's Tooth             巴龍牙
Needlessly Large Rod       無用杖.烏龜杖
Negatron Cloak             魔防披風
Ninja Tabi                 閃避鞋.忍者鞋
Null-Magic Mantle          小斗篷
Ｏ
Oracle's Elixir            Oracle.隱形藥水
Ｐ
Phage                      小鎚.木槌
Phantom Dancer             鬼舞者.紅雙刀
Philosopher's Stone        賢者之石.跳錢石
Pickaxe                    鋤頭
Ｑ
Quicksilver Sash           頭巾
Ｒ
Randuin's Omen             Omen.新盾
Recurve Bow                攻速弓
Regrowth Pendant           (回血)令牌 
Rejuvenation Bead          無 
Rod of Ages                ROA.時光杖
Ruby Crystal               紅寶石
Rylai's Crystal Scepter    冰杖
Ｓ
Sapphire Crystal           藍寶石
Sheen                      Sheen
Shurelya's Reverie         孫子
Sight Ward                 (綠)眼
Sorcerer's Shoes           魔穿鞋
Soul Shroud                黃金甲
Spirit Visage              SV
Stark's Fervor             斯達克(的狂熱)
Stinger                    刺針
Sunfire Cape               火斗.日炎             +450HP.45AR 周圍法傷40/sec
Sword of the Divine        SOTD.SOD              +AS.100法傷/每4下 主動+30物穿
Sword of the Occult        魂刀.疊刀             +10AD.5AD/層 殺人2層助攻1層
Ｔ
Tear of the Goddess        水滴.眼淚             +350MANA.7回魔/sec 施法+4MANA
The Black Cleaver          破防斧                +75AD -12AR/每下 最多扣五次
The Bloodthirster          吸血劍                +60AD.15%吸血 另外打怪可再疊
The Brutalizer             布魯托.物穿杖.骨頭杖  +25AD.20物穿.-CD10%
Thornmail                  反彈甲                +100AR 反彈30%物傷
Tiamat                     擴散斧                +42AD.回血.回魔 普攻會擴散
Trinity Force              三向(之力)            全部都+ 主動緩速.on hit增傷
Ｖ
Vampiric Scepter           吸血鐮刀              +12%吸血
Vision Ward                紫眼.隱形眼           有視野而且可看隱形3.5min
Void Staff                 魔穿棒.魔穿罐         +70AP.40%魔穿
Ｗ
Warden's Mail              無                    +60AR.回血 緩AS.跑速/on hit
Warmog's Armor             好戰者                +770HP.回血 另外打怪可再疊
Will of the Ancients       母災                  +40AP 靈氣+30AP.15%法術吸血
Wit's End                  吸魔刀.抽魔刀         +40%AS.30MR 每下抽42MANA&HP
Wriggle's Lantern          燈籠                  +AD.AR.吸血 小怪機率-500.Ward
Ｙ
Youmuu's Ghostblade        鬼刀.妖刀.幽冥刀      +AD.爆擊.-CD 主動+物穿.AS.跑速
Ｚ
Zeal                       黃雙刀                +10%爆擊.20%AS.8%跑速
Zhonya's Ring              龍牙.眾亞.小金人      +120AP 法傷提高25% 主動無敵2s

            ");






            toDefault.OnValueChange += toDefault_OnValueChange;
            Chat.OnInput += Chat_OnInput;
            Drawing.OnEndScene += Drawing_OnEndScene;

        }

        private void toDefault_OnValueChange(ValueBase<bool> sender, ValueBase<bool>.ValueChangeArgs args)
        {
            if (!args.NewValue) return;

            
            Core.DelayAction(() => { toDefault.CurrentValue = false; }, 200);
            Reset();
            LoadBuild();
        }

        private void Reset()
        {
            if(File.Exists(buildFile))
                File.Delete(buildFile);
            foreach (BuildElement buildElement in myBuild)
            {
                buildElement.Remove(menu);
            }
            myBuild.Clear();
        }

        private void AddElement(LoLItem it, ShopActionType ty)
        {
            if (ty != ShopActionType.Buy || ty != ShopActionType.Sell)
            {
                int hp = myBuild.Count(e => e.action == ShopActionType.StartHpPot) -
                         myBuild.Count(e => e.action == ShopActionType.StopHpPot);
                if (ty == ShopActionType.StartHpPot && hp != 0) return;
                if (ty == ShopActionType.StopHpPot && hp == 0) return;
            }

            BuildElement b = new BuildElement(this, menu, it, myBuild.Any() ? myBuild.Max(a => a.position) + 1 : 1, ty);

            List<LoLItem> c = new List<LoLItem>();
            BrutalItemInfo.InventorySimulator(myBuild, c);
            b.cost = BrutalItemInfo.InventorySimulator(new List<BuildElement> { b }, c);
            b.freeSlots = 7 - c.Count;
            b.updateText();
            if (b.freeSlots == -1)
            {
                Chat.Print("Couldn't add " + it + ", inventory is full.");
                b.Remove(menu);
            }
            else
                myBuild.Add(b);
        }

        private void LoadBuild()
        {
           if (!File.Exists(buildFile))
              
            {
                Chat.Print("Custom build doesn't exist: " + buildFile);
                if (!sugBuild.Equals(string.Empty))
                {
                    LoadInternalBuild();
                }
                return;
            }
            try
            {
                string s = File.ReadAllText(buildFile);
                if (s.Equals(string.Empty))
                {
                    Chat.Print("AutoBuddy: the build is empty.");
                    LoadInternalBuild();
                    return;
                }
                foreach (ItemAction ac in DeserializeBuild(s))
                {
                    AddElement(BrutalItemInfo.GetItemByID(ac.item), ac.t);
                    Console.Write("Custom Build Loading ");
                }
                Chat.Print("Loaded build from: " + buildFile);
            }
            catch (Exception e)
            {
                Chat.Print("AutoBuddy: couldn't load the build.");
              
                LoadInternalBuild();
                Console.WriteLine(e.Message);
            }

        }

        private void LoadInternalBuild()
        {
            try
            {
                if (sugBuild.Equals(string.Empty))
                {
                    Chat.Print("AutoBuddy: internal build is empty.");
                    return;
                }
                foreach (ItemAction ac in DeserializeBuild(sugBuild))
                {
                    AddElement(BrutalItemInfo.GetItemByID(ac.item), ac.t);
                }
            }
            catch (Exception e)
            {
                Chat.Print("AutoBuddy: internal build load failed.");
                Console.WriteLine(e.Message);
            }
            Chat.Print("AutoBuddy: Internal build loaded.");
        }

        private void SaveBuild()
        {
            File.WriteAllText(buildFile, SerializeBuild());
        }

        private string SerializeBuild()
        {
            string s = string.Empty;
            foreach (BuildElement el in myBuild.OrderBy(el => el.position))
            {
                s += el.item.id + ":" + el.action + ",";
            }
            return s.Equals(string.Empty) ? s : s.Substring(0, s.Length - 1);
        }

        private IEnumerable<ItemAction> DeserializeBuild(string serialized)
        {
            List<ItemAction> b = new List<ItemAction>();
            foreach (string s in serialized.Split(','))
            {
                ItemAction ac = new ItemAction { item = -1 };
                foreach (string s2 in s.Split(':'))
                {
                    if (ac.item == -1)
                        ac.item = int.Parse(s2);
                    else
                        ac.t = (ShopActionType)Enum.Parse(typeof(ShopActionType), s2, true);
                }
                b.Add(ac);
            }
            return b;
        }

        private void Drawing_OnEndScene(EventArgs args)
        {
            if (!MainMenu.IsVisible) return;
            property.GetSetMethod(true).Invoke(enabled, new object[] { l.Position + new Vector2(433, 0) });
            foreach (BuildElement ele in myBuild)
            {
                ele.UpdatePos(new Vector2(l.Position.X, l.Position.Y + 10));
            }
        }

        public void MoveUp(int index)
        {
            if (index <= 2) return;
            BuildElement th = myBuild.First(ele => ele.position == index);
            BuildElement up = myBuild.First(ele => ele.position == index - 1);
            th.position--;
            up.position++;

            foreach (BuildElement el in myBuild.OrderBy(b => b.position))
            {
                List<LoLItem> c = new List<LoLItem>();
                BrutalItemInfo.InventorySimulator(myBuild, c, el.position - 1);
                el.cost = BrutalItemInfo.InventorySimulator(new List<BuildElement> { el }, c);
                el.freeSlots = 7 - c.Count;
                el.updateText();
            }
            SaveBuild();
        }

        public void MoveDown(int index)
        {
            if (index == myBuild.Count || index == 2) return;
            BuildElement th = myBuild.First(ele => ele.position == index);
            BuildElement dn = myBuild.First(ele => ele.position == index + 1);
            th.position++;
            dn.position--;

            SaveBuild();
        }

        public bool Remove(int index)
        {
            if (myBuild.Count > 1 && index == 1) return false;
            BuildElement th = myBuild.First(ele => ele.position == index);
            myBuild.Remove(th);
            th.Remove(menu);
            foreach (BuildElement el in myBuild.OrderBy(b => b.position).Where(b => b.position > index))
            {
                el.position--;


                List<LoLItem> c = new List<LoLItem>();
                BrutalItemInfo.InventorySimulator(myBuild, c, el.position - 1);
                el.cost = BrutalItemInfo.InventorySimulator(new List<BuildElement> { el }, c);
                el.freeSlots = 7 - c.Count;
                el.updateText();
            }


            SaveBuild();
            return true;
        }

        private void Chat_OnInput(ChatInputEventArgs args)
        {
            if (args.Input.ToLower().StartsWith("/b "))
            {
                args.Process = false;
                string itemName = args.Input.Substring(2);
                LoLItem i = BrutalItemInfo.FindBestItem(itemName);
                Chat.Print("Buy " + i.name);

                if (myBuild.Count == 0 && !i.groups.Equals("RelicBase"))
                {
                    AddElement(BrutalItemInfo.GetItemByID(3340), ShopActionType.Buy);
                    Chat.Print("Added also warding totem.");
                }
                AddElement(i, ShopActionType.Buy);
                SaveBuild();
            }
            else if (args.Input.ToLower().StartsWith("/s "))
            {
                args.Process = false;
                string itemName = args.Input.Substring(2);
                LoLItem i = BrutalItemInfo.FindBestItemAll(itemName);
                Chat.Print("Sell " + i.name);

                AddElement(i, ShopActionType.Sell);
                SaveBuild();
            }
            else if (args.Input.ToLower().Equals("/buyhp"))
            {
                if (myBuild.Count == 0)
                {
                    AddElement(BrutalItemInfo.GetItemByID(3340), ShopActionType.Buy);
                    Chat.Print("Added also warding totem.");
                }
                AddElement(BrutalItemInfo.GetItemByID(2003), ShopActionType.StartHpPot);
                SaveBuild();
                args.Process = false;
            }
            else if (args.Input.ToLower().Equals("/stophp"))
            {
                if (myBuild.Count == 0)
                {
                    AddElement(BrutalItemInfo.GetItemByID(3340), ShopActionType.Buy);
                    Chat.Print("Added also warding totem.");
                }
                AddElement(BrutalItemInfo.GetItemByID(2003), ShopActionType.StopHpPot);
                SaveBuild();
                args.Process = false;
            }
        }

        private struct ItemAction
        {
            public ShopActionType t;
            public int item;
        }
    }
}
