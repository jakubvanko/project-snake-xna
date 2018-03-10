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

    public class ComponentMainGame : Microsoft.Xna.Framework.DrawableGameComponent
    {
        private SnakeGame snakeGame;
        private Texture2D spr_food;
        private Texture2D spr_head;
        public Texture2D spr_deadOutline1;
        public Texture2D spr_deadOutline2;
        private Texture2D spr_menuButton;
        private Rectangle menuButtonPosition;
        private Texture2D background_gamePaused;
        private List<Texture2D> fleshTextureList;
        private List<Texture2D> deadFleshTextureList;
        private List<GameObjectFood> foodList;
        private List<GameObjectBodyPiece> bodyPieceList;
        private bool setupNewGame;
        private bool gameStarted;
        private bool gameOver;
        private bool gamePaused;
        private GameObjectBodyHead gameObjectBodyHead;
        private KeyboardState actualKeyboardState;
        private KeyboardState oldKeyboardState;
        private int points = 0;
        public int Points
        {
            get
            {
                return points;
            }
            private set
            {
                points = value;
            }
        }





        public ComponentMainGame(SnakeGame snakeGame)
            : base(snakeGame)
        {
            this.snakeGame = snakeGame;
        }


        public override void Initialize()
        {
            fleshTextureList = new List<Texture2D>();
            deadFleshTextureList = new List<Texture2D>();
            GameObjectBodyPiece.Speed = 0;
            GameObjectBodyPiece.defaultSpeed = 5;
            actualKeyboardState = Keyboard.GetState();
            oldKeyboardState = Keyboard.GetState();
            setupNewGame = true;


            base.Initialize();
        }


        protected override void LoadContent()
        {
            spr_food = snakeGame.Content.Load<Texture2D>(@"Sprits\spr_food");
            spr_head = snakeGame.Content.Load<Texture2D>(@"Sprits\spr_head");
            spr_deadOutline1 = snakeGame.Content.Load<Texture2D>(@"Sprits\spr_deadOutline1");
            spr_deadOutline2 = snakeGame.Content.Load<Texture2D>(@"Sprits\spr_deadOutline2");
            fleshTextureList.Add(snakeGame.Content.Load<Texture2D>(@"Sprits\spr_body1"));
            fleshTextureList.Add(snakeGame.Content.Load<Texture2D>(@"Sprits\spr_body2"));
            deadFleshTextureList.Add(snakeGame.Content.Load<Texture2D>(@"Sprits\spr_body1_dead"));
            background_gamePaused = snakeGame.Content.Load<Texture2D>(@"Backgrounds\background_gamePaused");
            spr_menuButton = snakeGame.Content.Load<Texture2D>(@"Sprits\spr_menuButton");



            base.LoadContent();
        }


        public override void Update(GameTime gameTime)
        {
            GameObject.windowWidthX = GraphicsDevice.Viewport.Width;
            GameObject.windowHeightY = GraphicsDevice.Viewport.Height;
            actualKeyboardState = Keyboard.GetState();

            if (actualKeyboardState != oldKeyboardState)
            {
                if (actualKeyboardState.IsKeyDown(Keys.Space))
                {
                    if (gameOver == true)
                    {
                        setupNewGame = true;
                        gameOver = false;
                    }

                    if (gameStarted == false)
                    {
                        GameObjectBodyPiece.Speed = GameObjectBodyPiece.defaultSpeed;
                        gameStarted = true;
                    }
                }

                if (actualKeyboardState.IsKeyDown(Keys.Escape))
                {
                    if (gamePaused == false)
                    {
                        gamePaused = true;
                        GameObjectBodyPiece.Speed = 0;
                        snakeGame.IsMouseVisible = true;
                    }
                    else
                    {
                        gamePaused = false;
                        snakeGame.IsMouseVisible = false;
                        if (gameStarted == false)
                        {
                            GameObjectBodyPiece.Speed = 0;
                        }
                        else
                        GameObjectBodyPiece.Speed = GameObjectBodyPiece.defaultSpeed; 
                    }
                }

                oldKeyboardState = actualKeyboardState;
            }

            if (gamePaused == false)
            {

                if (setupNewGame == true)
                {
                    foodList = new List<GameObjectFood>();
                    foodList.Add(new GameObjectFood(spr_food));
                    bodyPieceList = new List<GameObjectBodyPiece>();
                    gameObjectBodyHead = new GameObjectBodyHead(spr_head);
                    bodyPieceList.Add(gameObjectBodyHead);
                    Points = 0;
                    gameStarted = false;
                    actualKeyboardState = Keyboard.GetState();
                    setupNewGame = false;
                }

                foreach (GameObjectBodyPiece bodyPiece in bodyPieceList)
                {
                    if (bodyPiece is GameObjectBodyHead)
                    {
                        gameObjectBodyHead.MoveBodyHead();
                    }
                    else
                    {
                        GameObjectBodyFlesh tempBodyFlesh = (GameObjectBodyFlesh)bodyPiece;
                        tempBodyFlesh.MoveBodyFlesh();

                        if (gameObjectBodyHead.Position.Intersects(bodyPiece.Position) && (bodyPiece != bodyPieceList[1]) && (bodyPiece != bodyPieceList[2]))
                        {
                            bodyPiece.Texture = deadFleshTextureList[0];
                            GameObjectBodyPiece.Speed = 0;
                            gameOver = true;
                        }

                    }
                }


                foreach (GameObjectFood food in foodList)
                {
                    if (bodyPieceList[0].Position.Intersects(food.Position))
                    {
                        Points++;
                        int temp = bodyPieceList.Count;
                        temp--;
                        bodyPieceList.Add(new GameObjectBodyFlesh(fleshTextureList, bodyPieceList[temp]));
                        food.NewFood();
                    }
                }

            }

            base.Update(gameTime);
        }


        public override void Draw(GameTime gameTime)
        {
            snakeGame.spriteBatch.Begin();

            foreach (GameObjectBodyPiece bodyPiece in bodyPieceList.AsEnumerable().Reverse())
            {
                snakeGame.spriteBatch.Draw(bodyPiece.Texture, bodyPiece.Position, Color.White);
            }

            foreach(GameObjectFood food in foodList)
            {
                snakeGame.spriteBatch.Draw(food.Texture, food.Position, Color.White);
            }

            if (gameStarted == false)
            {
                snakeGame.spriteBatch.DrawString(snakeGame.font, "Press SPACE start the game!", new Vector2(270, 350), Color.Red);
            }

            if (gameOver == true)
            {
                GraphicsDevice.Clear(Color.Gray);
                snakeGame.spriteBatch.DrawString(snakeGame.font, String.Format(" Game Over! \n Your score is {0}! \n Press SPACE to load new game!", Points), new Vector2(270, (GameObject.windowHeightY / 2)), Color.Cyan);
            }

            snakeGame.spriteBatch.DrawString(snakeGame.font, "Points: " + Points.ToString(), new Vector2(10, 30), Color.Aquamarine);
            snakeGame.spriteBatch.DrawString(snakeGame.font, String.Format("Food: X: {0}, Y: {1}",foodList[0].Position.X, foodList[0].Position.Y), new Vector2(10,50), Color.GreenYellow);


            if (gamePaused == true)
            {
                snakeGame.spriteBatch.Draw(background_gamePaused, new Vector2(0, 0), Color.White);
                snakeGame.spriteBatch.Draw(spr_menuButton, new Vector2((GameObject.windowWidthX / 2) - (0.5f * spr_menuButton.Width), 100), Color.White);
            }

            snakeGame.spriteBatch.End();
            base.Draw(gameTime);
        }




    }
}
