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
    class GameObjectFood: GameObject
    {
        private Random foodPositionGenerator;


        public GameObjectFood(Texture2D foodTexture)
        {
            Texture = foodTexture;
            foodPositionGenerator = new Random();
            NewFood();
        }


        public void NewFood()
        {
            Position = new Rectangle(foodPositionGenerator.Next(0, (GameObject.windowWidthX - 14)), foodPositionGenerator.Next(0, (GameObject.windowHeightY - 14)), 15, 15);
        }


    }
}
