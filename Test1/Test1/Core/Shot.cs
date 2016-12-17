using System.Drawing;
using OpenTK;

namespace Test1
{
    class Shot
    {
        #region Fields

        float _x;
        float _y;
        Vector2 _direction;
        bool _isRemoved;
        readonly Person _owner;
        float _range;
        int _damage;
        float _speed;
        private int _texture;
        private readonly float _width;
        private readonly float _height;

        #endregion

        #region Constructors

        public Shot(float x, float y, Vector2 direction, Person owner)
        {
            _x = x;
            _y = y;
            _direction = direction;
            _isRemoved = false;
            _owner = owner;
            _range = owner.ShotRange;
            _damage = owner.Damage;
            _speed = owner.ShotSpeed;
            _texture = _owner.Texture;
            _width = _owner.Width;
            _height = Owner.Height;
        }

        public Shot(float x, float y, float width, float height,  int texture)
        {
            _x = x;
            _y = y;
            _width = width;
            _height = height;
            _texture = texture;
        }

        #endregion

        #region Properties

        public float X
        {
            get { return _x; }
        }

        public float Y
        {
            get { return _y; }
        }

        public float Width
        {
            //get { return _owner.ShotChar.Width; }
            get { return _width; }
        }

        public float Height
        {
            //get { return _owner.ShotChar.Height; }
            get { return _height; }
        }

        public RectangleF Form
        {
            get { return new RectangleF(_x, _y, Width, -Height); }
        }

        public float Speed
        {
            get
            {
                if (_owner != null)
                {
                    return _owner.ShotSpeed;
                }
                return 0;
            }
        }

        public int Texture
        {
            //get { return _owner.ShotChar.Texture; }
            //set { _owner.ShotChar.Texture = value; }
            get { return _texture; }
            set { _texture = value; }
        }

        public float Range
        {
            get { return _range; }
        }

        public int Damage
        {
            get { return _owner.Damage; }
        }

        public bool IsRemoved
        {
            get { return _isRemoved; }
            set { _isRemoved = value; }
        }

        public Person Owner
        {
            get { return _owner; }
        }



        #endregion

        #region Methods

        public void Move()
        {
            _direction.Normalize();
            _x += Speed * _direction.X;
            _y += Speed * _direction.Y;
            _range -= Speed;
        }

        #endregion

        public void MoveTo(float x, float y)
        {
            _x = x;
            _y = y;
        }
    }
}
