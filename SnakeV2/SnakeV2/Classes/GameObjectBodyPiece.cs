using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace SnakeV2
{
    abstract class GameObjectBodyPiece: GameObject
    {
        public enum MovementDirection { up, right, down, left }
        public MovementDirection ObjectMovementDirection { get; protected set; }
        protected Rectangle position;
        public override Rectangle Position
        {
            get
            {
                //Pri vyžiadaní súradníc (pravdepodobne pre vykreslenie), skontroluje, či nie sú za hranicami
                if (position.X > (windowWidthX))
                {
                    position = new Rectangle(0, position.Y, 25, 25);
                }
                else if (position.X < 0)
                {
                    position = new Rectangle(windowWidthX, position.Y, 25, 25);
                }
                else if (position.Y > (windowHeightY))
                {
                    position = new Rectangle(position.X, 0, 25, 25);
                }
                else if (position.Y < 0)
                {
                    position = new Rectangle(position.X, windowHeightY, 25, 25);
                }

                return position;
            }
            protected set
            {
                position = value;
            }
        } 
        private static int speed;
        public static int defaultSpeed;
        public static int Speed
        {
            get
            {
                return speed;
            }

            set
            {
                if (value >= 0)
                    speed = value;
                else
                    speed = defaultSpeed;
            }
        }


        protected void MoveBodyPiece()
        {
            switch (ObjectMovementDirection)
            {
                case MovementDirection.right:
                    Position = new Rectangle(Position.X + Speed, Position.Y, 25, 25);
                    break;

                case MovementDirection.left:
                    Position = new Rectangle(Position.X - Speed, Position.Y, 25, 25);
                    break;

                case MovementDirection.up:
                    Position = new Rectangle(Position.X, Position.Y - Speed, 25, 25);
                    break;

                case MovementDirection.down:
                    Position = new Rectangle(Position.X, Position.Y + Speed, 25, 25);
                    break;
            }
        }




    }
}
