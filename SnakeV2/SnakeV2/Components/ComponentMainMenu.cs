using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System.Threading;


namespace SnakeV2
{

    public class ComponentMainMenu : Microsoft.Xna.Framework.DrawableGameComponent
    {
        private SnakeGame snakeGame;





        public ComponentMainMenu(SnakeGame snakeGame)
            : base(snakeGame)
        {
            this.snakeGame = snakeGame;
        }


        public override void Initialize()
        {


            base.Initialize();
        }


        protected override void LoadContent()
        {


            base.LoadContent();
        }


        public override void Update(GameTime gameTime)
        {
            

            base.Update(gameTime);
        }


        public override void Draw(GameTime gameTime)
        {
            snakeGame.spriteBatch.Begin();

            


            snakeGame.spriteBatch.End();
            base.Draw(gameTime);
        }




    }
}
