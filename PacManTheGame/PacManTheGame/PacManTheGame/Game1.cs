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


namespace PacManTheGame
{
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        private Player playerPacMan;

        Texture2D fieldTileCenterTexture2D, fieldTileRightTexture2D, fieldTileLeftTexture2D;
        Texture2D coinTexture2D;

     
        List<Coin> coins;

        private static Game1 instance;

        private Field gameField;

        private Ghost ghostsYellow, ghostsBlue, ghostsPink, ghostsRed;

        private CharacterDirection playerDir, ghostDir;


        private Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            // Задаем ширину и Высоту нашего экрана
            graphics.PreferredBackBufferHeight = 700;
            graphics.PreferredBackBufferWidth = 1050;
            
           // graphics.IsFullScreen = true;  // Запускает приложение на всеь экран

            IsMouseVisible = true; // Добавляет курсор на экран 
        }



       public static Game1 GetInstance()
       {
           if (instance == null)
	        {
                instance = new Game1();
		 
	        }
           
           return instance;
       
       
       }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

          // gameCoins = new Coin[4];

         

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Создание обьекта SpriteBatch для вывода 2D графики на экран.
            spriteBatch = new SpriteBatch(GraphicsDevice);


            playerPacMan = new Player(Content.Load<Texture2D>("Pacman_HD"), new Rectangle(510, 490, 35, 35));  //500 501
            gameField = new Field(Content.Load<Texture2D>("fieldTile"), new Rectangle(0,0,35,35));
            fieldTileCenterTexture2D = Content.Load<Texture2D>("fieldTileCenter");

            fieldTileLeftTexture2D = Content.Load<Texture2D>("fieldTileLeft");
            fieldTileRightTexture2D = Content.Load<Texture2D>("fieldTileRight");


          
            
                ghostsRed = new Ghost(Content.Load<Texture2D>("GhostRed"), new Rectangle(455, 320, 35, 35));
                ghostsYellow = new Ghost(Content.Load<Texture2D>("GhostYellow"), new Rectangle(490, 320, 35, 35));
                ghostsBlue = new Ghost(Content.Load<Texture2D>("GhostBlue"), new Rectangle(525, 320, 35, 35));
                ghostsPink = new Ghost(Content.Load<Texture2D>("GhostPink"), new Rectangle(560, 320, 35, 35));

                ghostsRed.SetSpriteBanch(spriteBatch);
                ghostsYellow.SetSpriteBanch(spriteBatch);
                ghostsBlue.SetSpriteBanch(spriteBatch);
                ghostsPink.SetSpriteBanch(spriteBatch);

            
            playerPacMan.SetSpriteBanch(spriteBatch);

            playerPacMan.SetLeftImage(Content.Load<Texture2D>("Pacman_HD_left"));
            playerPacMan.SetRightImage(Content.Load<Texture2D>("Pacman_HD_right"));
            playerPacMan.SetDownImage(Content.Load<Texture2D>("Pacman_HD_down"));
            playerPacMan.SetUpImage(Content.Load<Texture2D>("Pacman_HD_up"));

           

            //CreateField();

            playerPacMan.SetCurrentField(gameField);
            ghostsRed.SetCurrentField(gameField);
            ghostsYellow.SetCurrentField(gameField);
            ghostsBlue.SetCurrentField(gameField);
            ghostsPink.SetCurrentField(gameField);

            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
           
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)  
        {
            // Выход из игры при нажатии клавиши Escape
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                this.Exit();

            // Если PacMan сталкивается с  привидением то игра закрывается 

            if (playerPacMan.characterBackGroundRectangle.Intersects(ghostsRed.characterBackGroundRectangle) == true)
                this.Exit();

            if (playerPacMan.characterBackGroundRectangle.Intersects(ghostsYellow.characterBackGroundRectangle) == true)
                this.Exit();

            if (playerPacMan.characterBackGroundRectangle.Intersects(ghostsBlue.characterBackGroundRectangle) == true)
                this.Exit();

            if (playerPacMan.characterBackGroundRectangle.Intersects(ghostsPink.characterBackGroundRectangle) == true)
                this.Exit();
    
        
            
    
        
         /*   
              //Управление с помощью джойстика XBox360
              
            if (GamePad.GetState(PlayerIndex.One).ThumbSticks.Right.X > 0.5) 
                playerDir = PlayerDirection.playerUpRight;
                playerPacMan.changeDirection(playerDir);

            if (GamePad.GetState(PlayerIndex.One).ThumbSticks.Right.X < -0.5) 
                playerDir = PlayerDirection.playerUpLeft;
                playerPacMan.changeDirection(playerDir);

            if (GamePad.GetState(PlayerIndex.One).ThumbSticks.Right.Y > 0.5) 
                 playerDir = PlayerDirection.playerUp;
                 playerPacMan.changeDirection(playerDir);

            if (GamePad.GetState(PlayerIndex.One).ThumbSticks.Right.Y < -0.5) 
                playerDir = PlayerDirection.playerUpDown;
                playerPacMan.changeDirection(playerDir);
           
        */

                if (Keyboard.GetState().IsKeyDown(Keys.Right))
                {
                   playerDir = CharacterDirection.characterUpRight;
                   playerPacMan.changeDirection(playerDir);
                   
                }

                if (Keyboard.GetState().IsKeyDown(Keys.Left))
                {
                    playerDir = CharacterDirection.characterUpLeft;
                    playerPacMan.changeDirection(playerDir);
                }

                if (Keyboard.GetState().IsKeyDown(Keys.Up))
                {
                    playerDir = CharacterDirection.characterUp;
                    playerPacMan.changeDirection(playerDir);
                }

                if (Keyboard.GetState().IsKeyDown(Keys.Down))
                {
                   playerDir = CharacterDirection.characterUpDown;
                   playerPacMan.changeDirection(playerDir);
                }

           Character.UpdateCharacters( gameField);
           
           
            // If PacMan doesn't collide with the maze allow the PacMan to move.
            if ( true)
            {
                if (Keyboard.GetState().IsKeyDown(Keys.Left))
                {
                    playerDir = CharacterDirection.characterUpLeft;
                    playerPacMan.changeDirection(playerDir);
                   
                                                         
                   
                }
                else if (Keyboard.GetState().IsKeyDown(Keys.Right))
                {
                    playerDir = CharacterDirection.characterUpRight;
                    playerPacMan.changeDirection(playerDir);
                   

                }
                else if (Keyboard.GetState().IsKeyDown(Keys.Up))
                {
                    playerDir = CharacterDirection.characterUp;
                    playerPacMan.changeDirection(playerDir);
                    
                }
                else if (Keyboard.GetState().IsKeyDown(Keys.Down))
                {
                    playerDir = CharacterDirection.characterUpDown;
                    playerPacMan.changeDirection(playerDir);
                   
                }
               
            } 

            // TODO: Add your update logic here



            base.Update(gameTime);
        }

     
        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            spriteBatch.Begin(); // Начало прорисовки



            gameField.Draw(spriteBatch);

           
            Character.DrawCharacters(); // Прорисовка персонажей 

            spriteBatch.End(); // Конец прорисовки

            base.Draw(gameTime);
        }


    }
}
