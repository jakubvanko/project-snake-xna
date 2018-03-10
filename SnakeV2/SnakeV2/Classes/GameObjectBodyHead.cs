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
    class GameObjectBodyHead: GameObjectBodyPiece
    {
        private KeyboardState keyboard;
        private int counterToChangeDirection = 0;
        public int defaultCounterToChangeDirection = 5;

        public GameObjectBodyHead(Texture2D headTexture)
        {
            Texture = headTexture;
            Position = new Rectangle(GameObject.windowWidthX / 2, GameObject.windowHeightY / 2, 25, 25);
            ObjectMovementDirection = MovementDirection.right;
        }

        private void CheckMovementDirectionChange()
        {
            KeyboardState keyboardChanged = Keyboard.GetState();
            if (keyboard != keyboardChanged)
            {
                counterToChangeDirection = defaultCounterToChangeDirection;
                keyboard = keyboardChanged;
                if ((keyboard.IsKeyDown(Keys.Up) || keyboard.IsKeyDown(Keys.W)) && ObjectMovementDirection != MovementDirection.down)
                {
                    ObjectMovementDirection = MovementDirection.up;
                }
                else
                if ((keyboard.IsKeyDown(Keys.Down) || keyboard.IsKeyDown(Keys.S)) && ObjectMovementDirection != MovementDirection.up)
                {
                    ObjectMovementDirection = MovementDirection.down;
                }
                else
                if ((keyboard.IsKeyDown(Keys.Right) || keyboard.IsKeyDown(Keys.D)) && ObjectMovementDirection != MovementDirection.left)
                {
                    ObjectMovementDirection = MovementDirection.right;
                }
                else
                if ((keyboard.IsKeyDown(Keys.Left) || keyboard.IsKeyDown(Keys.A)) && ObjectMovementDirection != MovementDirection.right)
                {
                    ObjectMovementDirection = MovementDirection.left;
                }
            }
        }

        public void MoveBodyHead()
        {
            if (counterToChangeDirection == 0)
            {
                CheckMovementDirectionChange();
            }
            if (counterToChangeDirection > 0)
            {
                counterToChangeDirection--;
            }

            MoveBodyPiece();
        }


    }
}
