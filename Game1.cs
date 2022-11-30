using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MonoGame_1._5_Summative_Animation
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        Texture2D redCarTexture;
        Rectangle redCarRect;
        Texture2D copCarTexture;
        Rectangle copCarRect;
        KeyboardState keyboardState;
        Screen screen;
        Texture2D introTexture;
        Rectangle introRect;
        SpriteFont font;
        enum Screen
        {
            Intro,
            Race,
            Outro,
        }

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            this.Window.Title = "MonoGame Pt1-5";
            _graphics.PreferredBackBufferHeight = 500;
            _graphics.PreferredBackBufferWidth = 800;
            redCarRect = new Rectangle(50, 50, 500, 500);
            copCarRect = new Rectangle(100, 100, 400, 500);
            introRect = new Rectangle(0, 0, _graphics.PreferredBackBufferWidth, _graphics.PreferredBackBufferHeight+50);
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            redCarTexture = Content.Load<Texture2D>("redCar");
            copCarTexture = Content.Load<Texture2D>("copCar");
            introTexture = Content.Load<Texture2D>("Intro2");
            font = Content.Load<SpriteFont>("font");
            // TODO: use this.Content to load your game content here 
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);
            _spriteBatch.Begin();
            if (screen == Screen.Intro)
            {
                _spriteBatch.Draw(introTexture, introRect, Color.White);
                _spriteBatch.DrawString(font, "Click Enter to watch the great escape", new Vector2(250, 150), Color.White);
                
            }
            else if (screen == Screen.Race)
            {
                _spriteBatch.Draw(redCarTexture, redCarRect, Color.White);
                _spriteBatch.Draw(copCarTexture, copCarRect, Color.White);

            }
         
            _spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}