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
    abstract class GameObject
    {
        public Texture2D Texture { get; set; }
        public virtual Rectangle Position { get; protected set; }
        public static int windowWidthX;
        public static int windowHeightY;

    }
}
