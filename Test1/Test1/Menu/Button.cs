﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Timers;

namespace Test1
{
    class Button
    {
        #region Fields

        RectangleF _form;
        Action _action;
        int _texture;
        int _highlightedtexture;
        int _currentTexture;
        //Timer _timer;
        //bool _canClick;
        

        #endregion

        #region Constructors

        public Button(RectangleF form, Action action, int texture, int highTexture)
        {
            _form = form;
            _action = action;
            _texture = texture;
            _highlightedtexture = highTexture;
            _currentTexture = _texture;
            //_timer = new Timer(200);
            //_timer.AutoReset = false;
            //_timer.Elapsed += OnTimedEvent;
            //_canClick = true ;
        }

        #endregion

        #region Properties

        public RectangleF Form
        {
            get { return _form; }
        }

        public Action Action
        {
            get { return _action; }
        }

        public int Texture
        {
            get { return _currentTexture; }
        }

        public int HighTexture
        {
            get { return _highlightedtexture; }
        }

        //public Timer Timer
        //{
        //    get { return _timer; }
        //}

        //public bool CanClick
        //{
        //    get { return _canClick; }
        //}

        #endregion

        #region Methods

        //private void OnTimedEvent(Object source, ElapsedEventArgs e)
        //{
        //    _canClick = true;
        //}

        public void HighlightTexture()
        {
            _currentTexture = _highlightedtexture;
        }

        public void UnHighlightTexture()
        {
            _currentTexture = _texture;
        }

        #endregion


    }
}
