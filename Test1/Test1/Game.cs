using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
using System.Drawing;

namespace Test1
{
    class Game : GameWindow
    {
        #region Fields

        int[] _textures = new int[100];
        Room _currentRoom;
        List<Level> _levels = new List<Level>();
        RoomDrawer roomDrawer;
        Player _player;
        PlayerDrawer playerDrawer;
        LevelSupervisor _levelSupervisor;
        bool _isPausing = true;
        Menu _currentMenu;
        Menu _mainMenu;
        Menu _pauseMenu;
        Menu _winnerMenu;
        Menu _loserMenu;
        Menu _controlMenu;
        Menu _prevMenu;
        int _currentLevel;
        List<string> _firstLevelFileNames = new List<string>();
        List<string> _secondLevelFileNames = new List<string>();
        List<string> _thirdLevelFileNames = new List<string>();

        List<ILevelTemplate> _firstLevelTemplates = new List<ILevelTemplate>();
        List<ILevelTemplate> _secondLevelTemplates = new List<ILevelTemplate>();
        List<ILevelTemplate> _thirdLevelTemplates = new List<ILevelTemplate>();

        Dictionary<string, Item.ItemEffect> _itemEffects = new Dictionary<string,Item.ItemEffect>();
        List<string> _itemNames = new List<string>();

        #endregion

        public void UnPause()
        {
            _isPausing = false;
        }

        public void Win()
        {
            _currentMenu = _winnerMenu;
            _isPausing = true;
        }

        public void ShowControls()
        {
            _currentMenu = _controlMenu;
        }

        public void GoToPrevMenu()
        {
            _currentMenu = _prevMenu;
        }

        public void GoToMainMenu()
        {
            _currentMenu = _mainMenu;
            _prevMenu = _mainMenu;
        }

        public void StartGame()
        {
            _itemNames.Clear();
            _levels.Clear();

            _itemNames.Add("Boot");
            _itemNames.Add("Pizza");
            _itemNames.Add("BigHeart");
            _itemNames.Add("Glasses");
            _itemNames.Add("Zelie");
            _itemNames.Add("Pulemet");
            _itemNames.Add("Milk");
            _itemNames.Add("Molotok");

            _player = new Player(-0.4f, 0.0f, 359.0f / 4000, 982.0f / 4000, 0.4f / 60, 1000, 86, 87,
                  new ShotCharacteristics("Fireball.f"), 7, 2, 0.4f / 60, 0.5f, "Boy");

            var levelGenerator = new LevelGenerator(_firstLevelTemplates);
            _levels.Add(levelGenerator.Generate(_itemNames, _itemEffects, _firstLevelFileNames));
            levelGenerator = new LevelGenerator(_secondLevelTemplates);
            _levels.Add(levelGenerator.Generate(_itemNames, _itemEffects, _secondLevelFileNames));
            levelGenerator = new LevelGenerator(_thirdLevelTemplates);
            _levels.Add(levelGenerator.Generate(_itemNames, _itemEffects, _thirdLevelFileNames));

            _levels[_levels.Count - 1].BossRoom.Boss.IsFinal = true;

            _currentLevel = 0;
            _currentRoom = _levels[_currentLevel].Rooms[0];
            _currentRoom.Player = _player;
            _levelSupervisor = new LevelSupervisor(this);
            _isPausing = false;
        }

        #region Constructors

        public Game(int width, int height) : base(width, height)
        {
            _itemEffects["Boot"] = ItemEffect.UpSpeed;
            _itemEffects["Pizza"] = ItemEffect.UpMaxHealth;
            _itemEffects["BigHeart"] = ItemEffect.UpMaxHealth;
            _itemEffects["Glasses"] = ItemEffect.UpRange;
            _itemEffects["Zelie"] = ItemEffect.UpAttackSpeed;
            _itemEffects["Pulemet"] = ItemEffect.UpAttackSpeed;
            _itemEffects["Milk"] = ItemEffect.UpDamage;
            _itemEffects["Molotok"] = ItemEffect.UpDamage;
            _itemEffects["Heart"] = ItemEffect.UpHealth;

            _itemNames.Add("Boot");
            _itemNames.Add("Pizza");
            _itemNames.Add("BigHeart");
            _itemNames.Add("Glasses");
            _itemNames.Add("Zelie");
            _itemNames.Add("Pulemet");
            _itemNames.Add("Milk");
            _itemNames.Add("Molotok");

            _firstLevelFileNames.Add("Room1.f");
            _firstLevelFileNames.Add("Room2.f");
            _firstLevelFileNames.Add("Room2Snake.f");
            _firstLevelFileNames.Add("Room2Tree.f");
            _firstLevelFileNames.Add("RoomTreeSnake.f");

            _secondLevelFileNames.Add("Room2GhostSkeleton.f");
            _secondLevelFileNames.Add("RoomSkeletonGhostCenter.f");
            _secondLevelFileNames.Add("RoomGhostsDog.f");
            _secondLevelFileNames.Add("Room2Skeleton.f");

            _thirdLevelFileNames.Add("Room2Bag.f");
            _thirdLevelFileNames.Add("RoomBagBlackboard.f");
            _thirdLevelFileNames.Add("Room2Blackboard.f");


            _firstLevelTemplates.Add(new FirstLevelTemplate());
            _firstLevelTemplates.Add(new FirstLevelTemplate2());

            _secondLevelTemplates.Add(new SecondLevelTemplate1());
            _secondLevelTemplates.Add(new SecondLevelTemplate2());

            _thirdLevelTemplates.Add(new ThirdLevelTemplate());


            var w = Width;
            var h = Height;

            _mainMenu = new Menu(new RectangleF(-1.0f*w/h, 1, 2.0f*w/h, -2), 14);
            
            _mainMenu.Buttons.Add(new Button(new RectangleF(-0.3f, 0.2f, 0.6f, -0.2f), StartGame, 15, 60));
            _mainMenu.Buttons.Add(new Button(new RectangleF(-0.3f, -0.2f, 0.6f, -0.2f), ShowControls, 65, 66));
            _mainMenu.Buttons.Add(new Button(new RectangleF(-0.3f, -0.6f, 0.6f, -0.2f), Exit, 63, 64));

            _currentMenu = _mainMenu;

            _pauseMenu = new Menu(new RectangleF(-1.0f * w / h, 1, 2.0f * w / h, -2), 14);
            _pauseMenu.Buttons.Add(new Button(new RectangleF(-0.3f, 0.2f, 0.6f, -0.2f), UnPause, 61, 62));
            _pauseMenu.Buttons.Add(new Button(new RectangleF(-0.3f, -0.2f, 0.6f, -0.2f), ShowControls, 65, 66));
            _pauseMenu.Buttons.Add(new Button(new RectangleF(-0.3f, -0.6f, 0.6f, -0.2f), GoToMainMenu, 67, 68));

            _winnerMenu = new Menu(new RectangleF(-1.0f * w / h, 1, 2.0f * w / h, -2), 73);
            _winnerMenu.Buttons.Add(new Button(new RectangleF(-0.3f, -0.6f, 0.6f, -0.2f), GoToMainMenu, 67, 68));

            _loserMenu = new Menu(new RectangleF(-1.0f * w / h, 1, 2.0f * w / h, -2), 74);
            _loserMenu.Buttons.Add(new Button(new RectangleF(-0.3f, -0.6f, 0.6f, -0.2f), GoToMainMenu, 67, 68));

            _controlMenu = new Menu(new RectangleF(-1.0f * w / h, 1, 2.0f * w / h, -2), 72);
            _controlMenu.Buttons.Add(new Button(new RectangleF(-0.3f, -0.6f, 0.6f, -0.2f), GoToPrevMenu, 67, 68));
            _prevMenu = _mainMenu;
            
        }

        #endregion

        #region Methods

        public void GoToNextLevel()
        {
            _currentLevel++;
            _currentRoom = _levels[_currentLevel].Rooms[_levels[_currentLevel].StartRoomIndex];
            _currentRoom.Player = _player;
            _player.MoveTo(-0.4f, 0);
            _levelSupervisor = new LevelSupervisor(this);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            GL.Enable(EnableCap.Texture2D);
            _textures[0] = new TextureLoader().LoadTexture("Textures/wood.png");
            _textures[1] = new TextureLoader().LoadTexture("Textures/water.png");
            _textures[2] = new TextureLoader().LoadTexture("Textures/Kover.png");
            _textures[3] = new TextureLoader().LoadTexture("Textures/grass.png");
            _textures[4] = new TextureLoader().LoadTexture("Textures/DogLeft.png");
            _textures[5] = new TextureLoader().LoadTexture("Textures/fireball2.png");
            _textures[6] = new TextureLoader().LoadTexture("Textures/dust1.png");
            _textures[7] = new TextureLoader().LoadTexture("Textures/CancerLeft.png");
            _textures[8] = new TextureLoader().LoadTexture("Textures/portal1.png");
            _textures[9] = new TextureLoader().LoadTexture("Textures/Boot.png");
            _textures[10] = new TextureLoader().LoadTexture("Textures/Arka11.png");
            _textures[11] = new TextureLoader().LoadTexture("Textures/Arka21.png");
            _textures[12] = new TextureLoader().LoadTexture("Textures/Arka31.png");
            _textures[13] = new TextureLoader().LoadTexture("Textures/Arka41.png");
            _textures[14] = new TextureLoader().LoadTexture("Textures/Background.png");
            _textures[15] = new TextureLoader().LoadTexture("Textures/newgame.png");
            _textures[16] = new TextureLoader().LoadTexture("Textures/CancerRight.png");
            _textures[17] = new TextureLoader().LoadTexture("Textures/DogRight.png");
            _textures[18] = new TextureLoader().LoadTexture("Textures/Pizza.png");
            _textures[19] = new TextureLoader().LoadTexture("Textures/BigHeart.png");
            _textures[20] = new TextureLoader().LoadTexture("Textures/Glasses.png");
            _textures[21] = new TextureLoader().LoadTexture("Textures/Zelie.png");
            _textures[22] = new TextureLoader().LoadTexture("Textures/Pulemet.png");
            _textures[23] = new TextureLoader().LoadTexture("Textures/Milk.png");
            _textures[24] = new TextureLoader().LoadTexture("Textures/Molotok.png");
            _textures[25] = new TextureLoader().LoadTexture("Textures/Heart.png");
            _textures[26] = new TextureLoader().LoadTexture("Textures/WolfLeft.png");
            _textures[27] = new TextureLoader().LoadTexture("Textures/WolfRight.png");
            _textures[28] = new TextureLoader().LoadTexture("Textures/SnakeLeft.png");
            _textures[29] = new TextureLoader().LoadTexture("Textures/SnakeRight.png");
            _textures[30] = new TextureLoader().LoadTexture("Textures/TreeLeft.png");
            _textures[31] = new TextureLoader().LoadTexture("Textures/TreeRight.png");
            _textures[32] = new TextureLoader().LoadTexture("Textures/SkeletonLeft.png");
            _textures[33] = new TextureLoader().LoadTexture("Textures/SkeletonRight.png");
            _textures[34] = new TextureLoader().LoadTexture("Textures/GhostLeft.png");
            _textures[35] = new TextureLoader().LoadTexture("Textures/GhostRight.png");
            _textures[36] = new TextureLoader().LoadTexture("Textures/PoisonLeft.png");
            _textures[37] = new TextureLoader().LoadTexture("Textures/PoisonRight.png");
            _textures[38] = new TextureLoader().LoadTexture("Textures/JeludLeft.png");
            _textures[39] = new TextureLoader().LoadTexture("Textures/JeludRight.png");
            _textures[40] = new TextureLoader().LoadTexture("Textures/Grass1.png");
            _textures[41] = new TextureLoader().LoadTexture("Textures/Bone.png");
            _textures[42] = new TextureLoader().LoadTexture("Textures/Energy.png");
            _textures[43] = new TextureLoader().LoadTexture("Textures/StoneFloor1.png");
            _textures[44] = new TextureLoader().LoadTexture("Textures/StoneFloor2.png");
            _textures[45] = new TextureLoader().LoadTexture("Textures/StoneWall1.png");
            _textures[46] = new TextureLoader().LoadTexture("Textures/StoneWall2.png");
            _textures[47] = new TextureLoader().LoadTexture("Textures/DeathLeft.png");
            _textures[48] = new TextureLoader().LoadTexture("Textures/DeathRight.png");
            _textures[49] = new TextureLoader().LoadTexture("Textures/MelLeft.png");
            _textures[50] = new TextureLoader().LoadTexture("Textures/MelRight.png");
            _textures[51] = new TextureLoader().LoadTexture("Textures/BlackboardLeft.png");
            _textures[52] = new TextureLoader().LoadTexture("Textures/BlackboardRight.png");
            _textures[53] = new TextureLoader().LoadTexture("Textures/Bag1Left.png");
            _textures[54] = new TextureLoader().LoadTexture("Textures/Bag1Right.png");
            _textures[55] = new TextureLoader().LoadTexture("Textures/BagLeft.png");
            _textures[56] = new TextureLoader().LoadTexture("Textures/BagRight.png");
            _textures[57] = new TextureLoader().LoadTexture("Textures/BookLeft.png");
            _textures[58] = new TextureLoader().LoadTexture("Textures/Linoleum.png");
            _textures[59] = new TextureLoader().LoadTexture("Textures/SchoolWall.png");
            _textures[60] = new TextureLoader().LoadTexture("Textures/Newgameh.png");
            _textures[61] = new TextureLoader().LoadTexture("Textures/Continue.png");
            _textures[62] = new TextureLoader().LoadTexture("Textures/Continueh.png");
            _textures[63] = new TextureLoader().LoadTexture("Textures/Exit.png");
            _textures[64] = new TextureLoader().LoadTexture("Textures/Exith.png");
            _textures[65] = new TextureLoader().LoadTexture("Textures/Controls.png");
            _textures[66] = new TextureLoader().LoadTexture("Textures/Controlsh.png");
            _textures[67] = new TextureLoader().LoadTexture("Textures/Mainmenu.png");
            _textures[68] = new TextureLoader().LoadTexture("Textures/Mainmenuh.png");
            _textures[69] = new TextureLoader().LoadTexture("Textures/LeverLeft.png");
            _textures[70] = new TextureLoader().LoadTexture("Textures/LeverMid.png");
            _textures[71] = new TextureLoader().LoadTexture("Textures/LeverRight.png");
            _textures[72] = new TextureLoader().LoadTexture("Textures/ControlBackground.png");
            _textures[73] = new TextureLoader().LoadTexture("Textures/Win.png");
            _textures[74] = new TextureLoader().LoadTexture("Textures/Lose1.png");
            _textures[75] = new TextureLoader().LoadTexture("Textures/Paper.png");
            _textures[76] = new TextureLoader().LoadTexture("Textures/Task1.png");
            _textures[77] = new TextureLoader().LoadTexture("Textures/Task2.png");
            _textures[78] = new TextureLoader().LoadTexture("Textures/DamageText.png");
            _textures[79] = new TextureLoader().LoadTexture("Textures/SpeedText.png");
            _textures[80] = new TextureLoader().LoadTexture("Textures/RangeText.png");
            _textures[81] = new TextureLoader().LoadTexture("Textures/EmptyHeart.png");
            _textures[82] = new TextureLoader().LoadTexture("Textures/Arkac11.png");
            _textures[83] = new TextureLoader().LoadTexture("Textures/Arkac21.png");
            _textures[84] = new TextureLoader().LoadTexture("Textures/Arkac31.png");
            _textures[85] = new TextureLoader().LoadTexture("Textures/Arkac41.png");
            _textures[86] = new TextureLoader().LoadTexture("Textures/BoyLeft.png");
            _textures[87] = new TextureLoader().LoadTexture("Textures/BoyRight.png");
            _textures[88] = new TextureLoader().LoadTexture("Textures/NextRooms.png");
            _textures[89] = new TextureLoader().LoadTexture("Textures/ThisRoom.png");
            

            roomDrawer = new RoomDrawer(_textures);
            playerDrawer = new PlayerDrawer(_textures);
        }

        protected override void OnKeyDown(KeyboardKeyEventArgs e)
        {
            base.OnKeyDown(e);
            var state = OpenTK.Input.Keyboard.GetState();
            
            if (state[Key.Escape])
            {
                if (!_isPausing)
                {
                    _currentMenu = _pauseMenu;
                    _prevMenu = _pauseMenu;
                    _isPausing = true;
                }
            }

        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            var nRange = 1.0f;
            int w = this.Width;
            int h = this.Height;
            GL.Viewport(0, 0, w, h);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            if (w <= h)
            {
                GL.Ortho(-nRange, nRange, -nRange * h / w, nRange * h / w, -nRange, nRange);
            }
            else
            {
                GL.Ortho(-nRange * w / h, nRange * w / h, -nRange, nRange, -nRange, nRange);
            }
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            GL.MatrixMode(MatrixMode.Modelview);
            var menuSupervisor = new MenuSupervisor(this);
            if (_isPausing)
            {
                new MenuDrawer(_textures).Draw(_currentMenu);
                menuSupervisor.Run(_currentMenu);
            }
            else
            {
                
                _levelSupervisor.Run(_levels[_currentLevel]);


                if (_player.Hp <= 0)
                {
                    _currentMenu = _loserMenu;
                    _isPausing = true;
                }
            }

                       
            SwapBuffers();
            
        }

        #endregion

        public Player Player
        {
            get { return _player; }
        }

        public Room CurrentRoom
        {
            get { return _currentRoom; }
        }

        public int[] Textures
        {
            get {return _textures;}
        }
    }
}
