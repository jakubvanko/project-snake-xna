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

namespace SnakeV2.Classes
{
    class GameObjectButton : GameObject
    {
        public GameObjectButton(Texture2D texture, Rectangle position)
        {
            Position = position;
            Texture = texture;
        }
    }
}
