using System;
using OpenTK.Input;
using System.Timers;

namespace Test1
{
    class MenuSupervisor
    {
        #region Fields

        Game _game;
        static Timer _timer;
        static bool _canClick = true;


        #endregion

        #region Constructors

        public MenuSupervisor(Game game)
        {
            _game = game;
            _timer = new Timer(200);
            _timer.AutoReset = false;
            _timer.Elapsed += OnTimedEvent;
        }

        #endregion

        #region Methods

        private void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            _canClick = true;
        }

        public void Run(Menu menu)
        {
            var state = OpenTK.Input.Mouse.GetState();
            var pos = OpenTK.Input.Mouse.GetCursorState();
            var w = _game.Width;
            var h = _game.Height;
            var x = -1.0f * w / h + 2.0f * pos.X / h;
            var y = 1.0f - 2.0f * pos.Y / h;
           
            foreach(var t in menu.Buttons)
            {
                if (x > t.Form.Left && x < t.Form.Right && y > t.Form.Bottom && y < t.Form.Top)
                {
                    t.HighlightTexture();
                    if (state[MouseButton.Left])
                    {
                        if (_canClick)
                        {
                            t.Action.Invoke();
                            _canClick = false;
                            _timer.Start();
                        }
                    }
                }
                else
                {
                    t.UnHighlightTexture();
                }
            }
        }

        #endregion
    }
}
