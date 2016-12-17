﻿using System;
using OpenTK;

namespace Test1
{
    class Player : Person
    {
        readonly PlayerController _controller = new PlayerController();
        //private int _id;

        #region Constructors

        public Player(float x, float y, float width, float height, float speed, double attackSpeed, 
            int leftTexture, int rightTexture, ShotCharacteristics shotChar, int hp, int damage,
            float shotSpeed, float shotRange, string name) 
            : base(x, y, width, height, speed, attackSpeed, leftTexture, rightTexture, shotChar, hp, damage, 
            shotSpeed, shotRange, name)
        {
            
            
        }

        public Player(float x, float y, float width, float height, int texture)
        {
            _x = x;
            _y = y;
            _width = width;
            _height = height;
            _currentTexture = texture;
        }    

        public override bool CanMove(Vector2 direction, Room room)
        {
            var collisionChecker = new CollisionChecker();
            direction.Normalize();
            var movedPlayer = new Player(_x + _speed * direction.X, _y + _speed * direction.Y,
                _width, _height, _speed, _attackSpeed, _leftTexture, _rightTexture, _shotChar, _hp, _damage, 
                _shotSpeed, _shotRange, _name);
            if (collisionChecker.IsCollided(movedPlayer, room))
            {
                return false;
            }
            foreach (var t in room.Obstacles)
            {
                if (collisionChecker.IsCollided(movedPlayer, t))
                {
                    return false;
                }
            }
            foreach (var t in room.Enemies)
            {
                if (collisionChecker.IsCollided(movedPlayer, t))
                {
                    return false;
                }
            }

            if(room is ChallengeRoom)
            {
                var chalRoom = room as ChallengeRoom;
                foreach(var t in chalRoom.Levers)
                {
                    if (collisionChecker.IsCollided(movedPlayer, t))
                    {
                        Console.WriteLine("Collision");
                        return false;
                    }
                }
            }
            return base.CanMove(direction, room);
        }

        #endregion

        public PlayerController Controller
        {
            get { return _controller; }
        }

        public override float YAttack
        {
            get { return Form.Bottom - Form.Height / 2 + 300.0f/3000; }
        }

    }
}
