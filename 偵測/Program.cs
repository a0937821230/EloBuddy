namespace CowAwareness
{
    using CowAwareness.Detectors;
    using CowAwareness.Drawings;
    using CowAwareness.Features;
    using CowAwareness.Trackers;

    public class Program
    {
        #region Public Methods and Operators

        public static void Main(string[] args)
        {
            var addon =
                new Addon("偵測").Add(new Clock())
                    .Add(new Clone())
                    .Add(new TowerRange())
                    .Add(new Gank())
                    .Add(new Teleport())
                    .Add(new Cooldown())
                    .Add(new Ward())
                    .Add(new WatermarkDisabler());

            addon.MenuInitialized += menu =>
                {
                    menu.AddGroupLabel("版本(腳本)");
                    menu.AddLabel("1.0.2");

                    menu.AddSeparator();
                    menu.AddGroupLabel("代辦事項");
                    menu.AddLabel("- 嘗試修復 某些特殊角色 冷卻時間顯示");

                    menu.AddSeparator();
                    menu.AddGroupLabel("Credits");
                    menu.AddLabel("This project comes from lots of different sources");
                    menu.AddLabel(" if you think I should credit you, message me on EB");
                    menu.AddLabel("- Lizzaran for SFXUtility, got lots of nice things from him");
                    menu.AddLabel("- Kurttuu for the thread design");
                    menu.AddLabel("- MrArticuno's Tower Range code (with small improvements by me)");
                    menu.AddLabel("- Addon by strcow from elobuddy.net");
                    menu.AddLabel("作者EB網站：https://www.elobuddy.net/topic/8526-cowawareness-utility-aio-my-way-always-updated");
               		
                };
        }

        #endregion
    }
}