#region

using LeagueSharp.Common;

#endregion

namespace Yasuo
{
    public class YasuoMenu
    {
        /* FIELDS */
        private static Menu _menu;
        private readonly Orbwalking.Orbwalker orbwalker;
        private static int _spacerCount = -1;

        /* MAIN */
        private const string MenuDisplayName = "Yasuo the Unforgiven";
        public const string RootName = "wp.yasuo";

        /* TARGET SELECTOR */
        private const string TargetSelector = "TargetSelector";
        private const string TargetSelectorLoc = ".ts";

        /* ORBWALKER */
        private const string Orbwalker = "Orbwalker";
        private const string OrbwalkerLoc = ".orbwalker";

        /* COMBO */
        private const string Combo = "Combo Settings";
        private const string ComboLoc = ".combo";
        private const string ComboQ = "Use Steel Tempest (Q)";
        public const string ComboQLoc = ComboLoc + ".useq";
        private const string ComboE = "Use Sweeping Blade (E)";
        public const string ComboELoc = ComboLoc + ".usee";
        private const string ComboR = "Use Last Breath (R)";
        public const string ComboRLoc = ComboLoc + ".user";
        private const string ComboRDelay = "Delay before using Last Breath (R)";
        public const string ComboRDelayLoc = ".userdelay";
        private const string ComboREnemies = "Last Breath (R) Min. Enemies";
        public const string ComboREnemiesLoc = ComboLoc + ".renemies";
        private const string ComboREnemyPercent = "Last Breath (R) Min. Target Health Percent";
        public const string ComboREnemyPercentLoc = ComboLoc + ".renemypercent";
        private const string ComboRTarget = "Last Breath (R) if Target is Knocked Up";
        public const string ComboRTargetLoc = ".rtargetknockedup";
        private const string ComboREnemiesPercent = "Last Breath (R) Min. Enemies Health Percent";
        public const string ComboREnemiesPercentLoc = ComboLoc + ".renemiespercent";
        private const string ComboRKnockType = "Last Breath (R) Self knocked up enemies only";
        public const string ComboRKnockTypeLoc = ComboLoc + ".renemiesknocktypeonly";
        private const string ComboItems = "Use Items";
        public const string ComboItemsLoc = ComboLoc + ".useitems";
        private const string ComboGapcloserMode = "Base Gapcloser on";
        public const string ComboGapcloserModeLoc = ComboLoc + ".basegapcloser";
        private const string ComboGapcloserEMode = "Keep Dashing even if in attack range";
        public const string ComboGapcloserEModeLoc = ComboLoc + ".basegapcloserenemy";

        /* HARASS */
        private const string Harass = "Harass Settings";
        private const string HarassLoc = ".harass";

        /* Killsteal */
        private const string Killsteal = "Killsteal Settings";
        private const string KillstealLoc = ".ks";
        private const string KillstealActive = "Enable Killsteal";
        public const string KillstealActiveLoc = KillstealLoc + ".active";
        private const string KillstealQ = "Use Steel Tempest (Q)";
        public const string KillstealQLoc = KillstealLoc + ".useq";
        private const string KillstealE = "Use Sweeping Blade (E)";
        public const string KillstealELoc = KillstealLoc + ".usee";

        /* FARMING */
        private const string Farming = "Farming Settings";
        private const string FarmingLoc = ".farming";
        private const string FarmingLastHitQ = "[Last Hit] Use Steel Tempest (Q)";
        public const string FarmingLastHitQLoc = KillstealLoc + ".lhuseq";
        private const string FarmingLastHitQWind = "[Last Hit] Use Whirlwind (3rd Q)";
        public const string FarmingLastHitQWindLoc = KillstealLoc + ".lhuseqw";
        private const string FarmingLastHitE = "[Last Hit] Use Sweeping Blade (E)";
        public const string FarmingLastHitELoc = KillstealLoc + ".lhusee";
        private const string FarmingLaneClearQ = "[Lane Clear] Use Steel Tempest (Q)";
        public const string FarmingLaneClearQLoc = KillstealLoc + ".lcuseq";
        private const string FarmingLaneClearQWind = "[Lane Clear] Use Whirlwind (3rd Q)";
        public const string FarmingLaneClearQWindLoc = KillstealLoc + ".lcuseqw";
        private const string FarmingLaneClearItems = "[Lane Clear] Use Items";
        public const string FarmingLaneClearItemsLoc = KillstealLoc + ".lcuseitems";
        private const string FarmingLaneClearMinItems = "[Lane Clear] Min. Minions to Use Items";
        public const string FarmingLaneClearMinItemsLoc = ".minmitems";

        /* FLEE */
        private const string Flee = "Flee Settings";
        private const string FleeLoc = ".flee";
        private const string FleeUse = "Use Flee";
        public const string FleeUseLoc = FleeLoc + ".use";
        private const string FleeKey = "Flee Key";
        public const string FleeKeyLoc = FleeLoc + ".key";
        private const string FleeTowers = "Flee into enemy towers";
        public const string FleeTowersLoc = FleeLoc + ".towers";

        /* AUTO WINDWALL */
        public static Menu AutoWindMenu;
        private const string AutoWindWall = "Auto Windwall Settings";
        public const string AutoWindWallLoc = ".autoww";
        private const string AutoWindWallUse = "Use Auto Windwall";
        public const string AutoWindWallUseLoc = AutoWindWallLoc + ".usew";
        private const string AutoWindWallDelay = "Windwall Delay";
        public const string AutoWindWallDelayLoc = AutoWindWallLoc + ".delay";

        /* EVADE */
        public static Menu EvadeMenu;
        private const string Evade = "Evade Settings";
        public const string EvadeLoc = ".evade";
        private const string EvadeUse = "Use Sweeping Blade (E) to Evade";
        public const string EvadeUseLoc = EvadeLoc + ".use";

        /* AUTO */
        private const string Auto = "Auto Settings";
        private const string AutoLoc = ".auto";
        private const string AutoQ = "Use Steel Tempest (Q)";
        public const string AutoQLoc = AutoLoc + ".useq";

        /* ITEMS */
        private const string Items = "Items Settings";
        private const string ItemsLoc = ".items";
        private const string ItemsTiamat = "Tiamat (Melee Only)";
        public const string ItemsTiamatLoc = ".tiamat";
        private const string ItemsHydra = "Ravenous Hydra (Melee Only)";
        public const string ItemsHydraLoc = ".hydra";
        private const string ItemsBilgewater = "Bilgewater Cutlass";
        public const string ItemsBilgewaterLoc = ".bilgewater";
        private const string ItemsBlade = "Blade of the Ruined King";
        public const string ItemsBladeLoc = ".blade";

        /* MISC */
        private const string Misc = "Miscellaneous Settings";
        private const string MiscLoc = ".misc";
        private const string MiscPackets = "Use Packets";
        public const string MiscPacketsLoc = MiscLoc + ".packets";

        public YasuoMenu()
        {
            // Menu start
            _menu = new Menu(MenuDisplayName, RootName, true);

            // TargetSelector
            LeagueSharp.Common.TargetSelector.AddToMenu(AddSubMenu(TargetSelector, TargetSelectorLoc));

            // Orbwalker
            orbwalker = new Orbwalking.Orbwalker(AddSubMenu(Orbwalker, OrbwalkerLoc));

            // Combo
            var combo = AddSubMenu(Combo, ComboLoc); // => Combo
            AddItem(combo, ComboQ, ComboQLoc).SetValue(true); // => Q
            AddItem(combo, ComboE, ComboELoc).SetValue(true); // => E
            AddItem(combo, ComboR, ComboRLoc).SetValue(true); // => R
            AddSpacer(combo); // => SPACER
            AddItem(combo, ComboRDelay, ComboRDelayLoc).SetValue(new Slider(25, 15)); // => R Casting Delay
            AddItem(combo, ComboREnemies, ComboREnemiesLoc).SetValue(new Slider(1, 1, 5)); // => R Enemies Requirement
            AddItem(combo, ComboREnemiesPercent, ComboREnemiesPercentLoc).SetValue(new Slider(40, 10)); // => R Enemies Health Percent Requirement
            AddItem(combo, ComboRTarget, ComboRTargetLoc).SetValue(true); // => R Selected Target Mode
            AddItem(combo, ComboREnemyPercent, ComboREnemyPercentLoc).SetValue(new Slider(40, 10)); // => R Enemy Health Percent Requirement
            AddItem(combo, ComboRKnockType, ComboRKnockTypeLoc).SetValue(false); // => R Knockup Type Blink
            AddSpacer(combo); // => SPACER
            AddItem(combo, ComboItems, ComboItemsLoc).SetValue(true); // => Use Items
            AddItem(combo, ComboGapcloserMode, ComboGapcloserModeLoc)
                .SetValue(new StringList(new[] { "Mouse", "Target" })); // => Gapcloser Mode
            AddItem(combo, ComboGapcloserEMode, ComboGapcloserEModeLoc).SetValue(true); // => Keep gapclosing even if in AA range

            // Harass
            var harass = AddSubMenu(Harass, HarassLoc); // => Harass
            /*AddItem(harass, HarassUse, HarassUseLoc).SetValue(true); // => Use
            AddItem(harass, HarassQ, HarassQLoc).SetValue(true); // => Q
            AddItem(harass, HarassE, HarassELoc).SetValue(true); // => E
            AddSpacer(harass); // => SPACER
            AddItem(harass, HarassQRange, HarassQRangeLoc).SetValue(new Slider(475, 475, 525)); // => Q Range
            AddItem(harass, HarassMinE, HarassMinELoc).SetValue(new Slider(2, 2, 8)); // => Min. Minions Requirement
            AddItem(harass, HarassItems, HarassItemsLoc).SetValue(true); // => Use Items
            AddItem(harass, HarassEGapcloser, HarassEGapcloserLoc).SetValue(true); // => Use gapcloser
            AddItem(harass, HarassQeCombo, HarassQeComboLoc).SetValue(true); // => use Q+E*/
            AddItem(harass, "Harass Not Working Currently :(", ".harass.notworking");

            // Killsteal
            var ks = AddSubMenu(Killsteal, KillstealLoc); // => Killsteal
            AddItem(ks, KillstealActive, KillstealActiveLoc).SetValue(true); // => Use
            AddItem(ks, KillstealQ, KillstealQLoc).SetValue(true); // => Q
            AddItem(ks, KillstealE, KillstealELoc).SetValue(true); // => E

            // Farming
            var farming = AddSubMenu(Farming, FarmingLoc); // => Farming
            AddItem(farming, FarmingLastHitQ, FarmingLastHitQLoc).SetValue(true); // => Lasthit Q
            AddItem(farming, FarmingLastHitQWind, FarmingLastHitQWindLoc).SetValue(true); // => Lasthit whirlwind Q
            AddItem(farming, FarmingLastHitE, FarmingLastHitELoc).SetValue(true); // => Lasthit E
            AddSpacer(farming); // => SPACER
            AddItem(farming, FarmingLaneClearQ, FarmingLaneClearQLoc).SetValue(true); // => Laneclear Q
            AddItem(farming, FarmingLaneClearQWind, FarmingLaneClearQWindLoc).SetValue(true); // => Laneclear whirlwind Q
            AddItem(farming, FarmingLaneClearItems, FarmingLaneClearItemsLoc).SetValue(true); // => Laneclear Items
            AddItem(farming, FarmingLaneClearMinItems, FarmingLaneClearMinItemsLoc).SetValue(new Slider(3, 1, 8)); // => Laneclear Items

            // Flee
            var flee = AddSubMenu(Flee, FleeLoc); // => Flee
            AddItem(flee, FleeUse, FleeUseLoc).SetValue(true); // => Use
            AddItem(flee, FleeKey, FleeKeyLoc).SetValue(new KeyBind("Z".ToCharArray()[0], KeyBindType.Press)); // => Key
            AddItem(flee, FleeTowers, FleeTowersLoc).SetValue(true); // => Towers

            // Auto Windwall
            var aww = AutoWindMenu = AddSubMenu(AutoWindWall, AutoWindWallLoc); // => Auto Windwall
            AddItem(aww, AutoWindWallUse, AutoWindWallUseLoc).SetValue(true); // => Use
            AddItem(aww, AutoWindWallDelay, AutoWindWallDelayLoc).SetValue(new Slider(500, 150, 2000)); // => Windwall Delay
            AddSpacer(aww); // => SPACER

            // Evade
            var evade = EvadeMenu = AddSubMenu(Evade, EvadeLoc); // => Evade
            AddItem(evade, EvadeUse, EvadeUseLoc).SetValue(true); // => Use
            AddSpacer(evade); // => SPACER

            // Auto
            var auto = AddSubMenu(Auto, AutoLoc); // => Auto
            AddItem(auto, AutoQ, AutoQLoc).SetValue(true); // => Q

            // Items
            var items = AddSubMenu(Items, ItemsLoc);
            AddItem(items, ItemsTiamat, ItemsTiamatLoc).SetValue(true); // => Tiamat
            AddItem(items, ItemsHydra, ItemsHydraLoc).SetValue(true); // => Hydra
            AddItem(items, ItemsBilgewater, ItemsBilgewaterLoc).SetValue(true); // =? Bilgewater
            AddItem(items, ItemsBlade, ItemsBladeLoc).SetValue(true); // => Blade

            // Misc
            var misc = AddSubMenu(Misc, MiscLoc); // => Misc
            AddItem(misc, MiscPackets, MiscPacketsLoc).SetValue(true); // => Packets

            // Footer
            AddSpacer(_menu); // => Spacer
            AddSpacer(_menu, "Yasuo the Unforgiven"); // => Footer description

            _menu.AddToMainMenu();
        }

        /// <summary>
        ///     Quick reference to add a Yasuo Sub Menu.
        /// </summary>
        /// <param name="displayName">Menu Display Name</param>
        /// <param name="name">Menu Location Name</param>
        /// <returns>The created menu</returns>
        public Menu AddSubMenu(string displayName, string name)
        {
            return _menu == null ? null : _menu.AddSubMenu(new Menu(displayName, RootName + name));
        }

        /// <summary>
        ///     Quick reference to add a Yasuo Item.
        /// </summary>
        /// <param name="menu">Menu</param>
        /// <param name="displayName">Menu Display Name</param>
        /// <param name="name">Menu Location Name</param>
        /// <returns>The created item</returns>
        public MenuItem AddItem(Menu menu, string displayName, string name)
        {
            return menu == null ? null : menu.AddItem(new MenuItem(RootName + name, displayName));
        }

        /// <summary>
        ///     Quick reference to add a Spacer.
        /// </summary>
        /// <param name="menu">Menu</param>
        /// <param name="display">Spacer Display Name</param>
        /// <returns>The created spacer in MenuItem instance</returns>
        public static MenuItem AddSpacer(Menu menu, string display = "")
        {
            ++_spacerCount;
            return menu == null ? null : menu.AddItem(new MenuItem(".spacer" + _spacerCount, display));
        }

        /// <summary>
        ///     Quick reference to fetch the orbwalker
        /// </summary>
        /// <returns>The orbwalker instance</returns>
        public Orbwalking.Orbwalker GetOrbwalker()
        {
            return orbwalker;
        }

        /// <summary>
        ///     Quick reference to fetch the menu
        /// </summary>
        /// <returns>Yasuo Menu</returns>
        public Menu GetMenu()
        {
            return _menu;
        }

        /// <summary>
        ///     Quick reference to fetch a submenu
        /// </summary>
        /// <param name="args">Sub Menu Location</param>
        /// <returns></returns>
        public Menu GetSubMenu(string args)
        {
            return _menu.SubMenu(args);
        }

        /// <summary>
        ///     Quick reference to fetch an item value
        /// </summary>
        /// <typeparam name="T">Any</typeparam>
        /// <param name="str">Item Location</param>
        /// <returns>Item Value</returns>
        public T GetItemValue<T>(string str)
        {
            return _menu.Item(RootName + str).GetValue<T>();
        }

        /// <summary>
        ///     Quick reference to fetch the item
        /// </summary>
        /// <param name="str">Item Location</param>
        /// <returns>Item</returns>
        public MenuItem GetItem(string str)
        {
            return _menu.Item(RootName + str);
        }
    }
}
