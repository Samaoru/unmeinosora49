using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using GameStateManagement;
using GameStateManagementSample;

namespace Game1
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        Texture2D textureBall;
        Texture2D background;
        Vector2 ballPosition;
        float ballSpeed;
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        SpriteBatch mapBatch;
        Rectangle clientWindow;
        Rectangle mainFrame;
        String saveFolder = "C:\\Users\\Chris\\Desktop\\";
        States gameState;
        ScreenManager screenManager;
        ScreenFactory screenFactory;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            //graphics.PreferredBackBufferHeight = 768;
            //graphics.PreferredBackBufferWidth = 1366;
            Content.RootDirectory = "Content";

            // Create the screen factory and add it to the Services
            screenFactory = new ScreenFactory();
            Services.AddService(typeof(IScreenFactory), screenFactory);

            // Create the screen manager component.
            screenManager = new ScreenManager(this);
            Components.Add(screenManager);

            // On Windows and Xbox we just add the initial screens
            AddInitialScreens();
        }

        private void AddInitialScreens()
        {
            // Activate the first screens.
            screenManager.AddScreen(new BackgroundScreen(), null);
            screenManager.AddScreen(new MainMenuScreen(), null);

        }

        public enum States
        {
            Title, Play
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
            //ballPosition = new Vector2(graphics.PreferredBackBufferWidth / 2,graphics.PreferredBackBufferHeight / 2);
            ballPosition = new Vector2(10, 10);
            ballSpeed = 400f;

            //this.TargetElapsedTime = TimeSpan.FromSeconds(1.0f / 30.0f);
            this.IsMouseVisible = true;
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            mapBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            textureBall = Content.Load<Texture2D>("ball");
            background = Content.Load<Texture2D>("map");
            mainFrame = new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height);
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
            Console.WriteLine("Exiting, final position:"+ballPosition.X+","+ballPosition.Y);
        }

        private void newGame()
        {

        }

        /*
        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            //clientWindow = GraphicsDevice.Viewport.Bounds;
            clientWindow = Window.ClientBounds;
            float startingX = ballPosition.X;
            float startingY = ballPosition.Y;

            // TODO: Add your update logic here
            var kstate = Keyboard.GetState();
            float absDistance = ballSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (kstate.IsKeyDown(Keys.Up))
                ballPosition.Y -= absDistance;

            if (kstate.IsKeyDown(Keys.Down))
                ballPosition.Y += absDistance;

            if (kstate.IsKeyDown(Keys.Left))
                ballPosition.X -= absDistance;

            if (kstate.IsKeyDown(Keys.Right))
                ballPosition.X += absDistance;

            if(ballPosition.X+textureBall.Width>clientWindow.Width || ballPosition.X<0) {
                    ballPosition.X = startingX;
            }
            if(ballPosition.Y+textureBall.Height>clientWindow.Height || ballPosition.Y<0) {
                ballPosition.Y = startingY;
            }

            //Move the camera to the right the speed at which the ball is moving
            if ((startingX < ballPosition.X) && ballPosition.X + textureBall.Width/2 > clientWindow.Width/2 && (mainFrame.X + mainFrame.Width < background.Width))
            {
                //mainFrame = new Rectangle(mainFrame.X + (int)(ballPosition.X-startingX), mainFrame.Y, mainFrame.Width, mainFrame.Height);
                mainFrame = new Rectangle(mainFrame.X + (int)absDistance, mainFrame.Y, mainFrame.Width, mainFrame.Height);
                Console.WriteLine("Moving right: "+mainFrame.X);
                ballPosition.X = startingX;
            }

            if ((startingX > ballPosition.X) && ballPosition.X + textureBall.Width / 2 < clientWindow.Width / 2 && (mainFrame.X > 0))
            {
                //mainFrame = new Rectangle(mainFrame.X + (int)(ballPosition.X-startingX), mainFrame.Y, mainFrame.Width, mainFrame.Height);
                mainFrame = new Rectangle(mainFrame.X - (int)absDistance, mainFrame.Y, mainFrame.Width, mainFrame.Height);
                Console.WriteLine("Moving left: " + mainFrame.X);
                ballPosition.X = startingX;
            }

            base.Update(gameTime);
        }
        */

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here


            
            //mapBatch.Begin();
            //mapBatch.Draw(background, new Rectangle(0-mainFrame.X, 0, background.Width, background.Height), Color.White);
            //mapBatch.End();

            //spriteBatch.Begin();
            //spriteBatch.Draw(textureBall, new Vector2(10, 10), Color.White);
            //spriteBatch.Draw(textureBall,ballPosition, null,Color.White,0f,
                            //new Vector2(textureBall.Width / 2, textureBall.Height / 2),Vector2.One,SpriteEffects.None,0f);
            //                new Vector2(0,0), Vector2.One, SpriteEffects.None, 0f);
            //spriteBatch.End();

            

            base.Draw(gameTime);
        }
    }
}
