using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Shooter.Game1;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;
namespace Shooter
{
    public class TexturePack
    {
        public static Texture2D iron;
        public static Texture2D robot;
        public static Texture2D bulletTex;
        public static Texture2D blasterTex;
        public static Texture2D monsterTex;
        public static Texture2D rocketTex;
        public static SpriteFont font;     
        public static Texture2D PlayP;
        public static Texture2D PlayAct;
        public static Texture2D ExitP;
        public static Texture2D ExitAct;
        public static Texture2D SettingsTex;
        public static Texture2D SettingsTexAct;
        public static Texture2D CrModP;
        public static Texture2D CrModAct;
        public static Texture2D MainMenuTex;
        public static Texture2D PauseTex;
        public static Texture2D LoadGameTex;
        public static Texture2D NewGameTex;
        public static Texture2D tick;
        public static Texture2D backTex;
        public static Texture2D mainMenuButTex;
   
        public static SoundEffect piu;
        public static Song MainSound;
        public static SoundEffect blasterSound;
        public static SoundEffect saberSound;
        public static SoundEffect rocketSound;
        public static SoundEffect damageHeroSound;
        public static SoundEffect damageMonSound;
        public static SoundEffect NewGameSound;
        public static SoundEffect WallBreakSound;
        public TexturePack(Game1 game)
        {
            iron = game.Content.Load<Texture2D>("iron");
            robot = game.Content.Load<Texture2D>("robot");
            bulletTex = game.Content.Load<Texture2D>("bullet");
            blasterTex = game.Content.Load<Texture2D>("blaster");
            rocketTex = game.Content.Load<Texture2D>("rocket");
            monsterTex = game.Content.Load<Texture2D>("monster");
            font = game.Content.Load<SpriteFont>("Font");
            PlayP = game.Content.Load<Texture2D>("PlayP");
            PlayAct = game.Content.Load<Texture2D>("PlayAct");
            ExitP = game.Content.Load<Texture2D>("ExitP");
            ExitAct = game.Content.Load<Texture2D>("ExitAct");
            SettingsTex = game.Content.Load<Texture2D>("SettingsTex");
            SettingsTexAct = game.Content.Load<Texture2D>("SettingsTexAct");
            CrModP = game.Content.Load<Texture2D>("CrMod");
            CrModAct = game.Content.Load<Texture2D>("CrModAct");
            MainMenuTex = game.Content.Load<Texture2D>("MainMenuTex");
            PauseTex = game.Content.Load<Texture2D>("PauseTex");
            NewGameTex = game.Content.Load<Texture2D>("NewGameTex");
            LoadGameTex = game.Content.Load<Texture2D>("LoadGameTex");
            tick = game.Content.Load<Texture2D>("tick");
            backTex = game.Content.Load<Texture2D>("backT");
            mainMenuButTex = game.Content.Load<Texture2D>("mainMenuButTex");
            piu = game.Content.Load<SoundEffect>("piu");
            MainSound = game.Content.Load<Song>("MainSound");
            blasterSound= game.Content.Load<SoundEffect>("blasterSound");
            rocketSound = game.Content.Load<SoundEffect>("rocketSound");
            saberSound = game.Content.Load<SoundEffect>("saberSound");
            damageHeroSound = game.Content.Load<SoundEffect>("damageHeroSound");
            damageMonSound = game.Content.Load<SoundEffect>("damageMonSound");
            NewGameSound = game.Content.Load<SoundEffect>("NewGameSound");
            WallBreakSound = game.Content.Load<SoundEffect>("WallBreakSound");
        }
    }
}
