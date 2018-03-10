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
    class GameObjectBodyFlesh: GameObjectBodyPiece
    {
        private GameObjectBodyPiece previousBodyPiece;
        private MovementDirection previousBodyPieceMovementDirection;
        public int pointsToChangeDirection = 0;
        public static int defaultPointsToChangeDirection = 5;
        private Random fleshTextureGenerator;

        public GameObjectBodyFlesh(List<Texture2D> textureList ,GameObjectBodyPiece previousBodyPiece)
        {
            fleshTextureGenerator = new Random();
            Texture = textureList[fleshTextureGenerator.Next(0, textureList.Count)];
            this.previousBodyPiece = previousBodyPiece;
            previousBodyPieceMovementDirection = previousBodyPiece.ObjectMovementDirection;
            ObjectMovementDirection = previousBodyPiece.ObjectMovementDirection;
            switch(previousBodyPiece.ObjectMovementDirection)
            {
                case MovementDirection.down:
                    Position = new Rectangle(previousBodyPiece.Position.X, previousBodyPiece.Position.Y - 20, 25, 25);
                    break;
                case MovementDirection.up:
                    Position = new Rectangle(previousBodyPiece.Position.X, previousBodyPiece.Position.Y + 20, 25, 25);
                    break;
                case MovementDirection.left:
                    Position = new Rectangle(previousBodyPiece.Position.X + 20, previousBodyPiece.Position.Y, 25, 25);
                    break;
                case MovementDirection.right:
                    Position = new Rectangle(previousBodyPiece.Position.X - 20, previousBodyPiece.Position.Y, 25, 25);
                    break;
            }
        }

        public void MoveBodyFlesh()
        {
            if ((previousBodyPieceMovementDirection != previousBodyPiece.ObjectMovementDirection) && (pointsToChangeDirection == 0))
            {
                previousBodyPieceMovementDirection = previousBodyPiece.ObjectMovementDirection;
                pointsToChangeDirection = defaultPointsToChangeDirection;
            }
           
            if (pointsToChangeDirection > 0)
            {
              pointsToChangeDirection--;
                if (pointsToChangeDirection == 0)
                {
                    ObjectMovementDirection = previousBodyPieceMovementDirection;
                    previousBodyPieceMovementDirection = previousBodyPiece.ObjectMovementDirection;
                }
            }

            MoveBodyPiece();
        }
        



    }
}
