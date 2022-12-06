using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MonoGame_1._5_Summative_Animation
{
    public class Game1 : Game
    {
       
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
       
        Texture2D redCarTexture, copCarTexture;
        Rectangle redCarRect, copCarRect;
        KeyboardState KeyboardState;
        KeyboardState State;
        Screen screen;
        float seconds, startTime;
        Texture2D introTexture,intro2Texture,OutroTexture;
        Rectangle introRect,intro2Rect,OutroRect;
        SpriteFont font,raceFont,timerFont,outroFont;
        Vector2 copSpeed, redSpeed;
        SoundEffect policeSiren,raceCar;
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
            screen = Screen.Intro;
            this.Window.Title = "MonoGame Pt1-5";
            _graphics.PreferredBackBufferHeight = 500;
            _graphics.PreferredBackBufferWidth = 800;
            redCarRect = new Rectangle(40,370, 150, 50);
            redSpeed = new Vector2(3, 3);
            copCarRect = new Rectangle(0, 370, 90, 50);
            copSpeed = new Vector2(2, 2);
            introRect = new Rectangle(0, 0, _graphics.PreferredBackBufferWidth, _graphics.PreferredBackBufferHeight+50);
            intro2Rect = new Rectangle(0, 0, _graphics.PreferredBackBufferWidth, _graphics.PreferredBackBufferHeight+20);
            OutroRect = new Rectangle(0, 0, _graphics.PreferredBackBufferWidth, _graphics.PreferredBackBufferHeight+20);
            
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            redCarTexture = Content.Load<Texture2D>("redCar");
            copCarTexture = Content.Load<Texture2D>("copCar");
            introTexture = Content.Load<Texture2D>("Intro2");
            intro2Texture = Content.Load<Texture2D>("BackgroundRace");
            OutroTexture = Content.Load<Texture2D>("Outro");
            font = Content.Load<SpriteFont>("font");
            raceFont = Content.Load<SpriteFont>("raceFont");
            timerFont = Content.Load<SpriteFont>("timerFont");
            outroFont = Content.Load<SpriteFont>("outroFont");
            policeSiren = Content.Load<SoundEffect>("policeSiren");
            raceCar= Content.Load<SoundEffect>("raceCar");


            // TODO: use this.Content to load your game content here 
        }

        protected override void Update(GameTime gameTime)
        {
            seconds = (float)gameTime.TotalGameTime.TotalSeconds - startTime;
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            KeyboardState = Keyboard.GetState();
            if (screen == Screen.Intro)
            {
                if (KeyboardState.IsKeyDown(Keys.Enter))
                {
                    screen = Screen.Race;
                    policeSiren.Play();
                    raceCar.Play();
                }
            }
            else if (screen == Screen.Race)
            {
                redCarRect.X += (int)redSpeed.X;
                if (redCarRect.X > _graphics.PreferredBackBufferWidth)
                {
                    screen=Screen.Outro;
                    policeSiren.Dispose();
                    raceCar.Dispose();  
                }
               
                copCarRect.X += (int)copSpeed.X;
                base.Update(gameTime);
            }
            
        }
            
               
            
         
        

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);
            _spriteBatch.Begin();
            if (screen == Screen.Intro)
            {
                _spriteBatch.Draw(introTexture, introRect, Color.White);
                _spriteBatch.DrawString(font, "The Great Escape", new Vector2(225, 30), Color.White);
                _spriteBatch.DrawString(raceFont, "Click enter to begin ", new Vector2(300, 70), Color.White);
            }
            else if (screen == Screen.Race)
            {
                _spriteBatch.Draw(intro2Texture, intro2Rect, Color.White);
                _spriteBatch.Draw(redCarTexture, redCarRect, Color.White);
                _spriteBatch.Draw(copCarTexture, copCarRect, Color.White);
                _spriteBatch.DrawString(timerFont, (0 + seconds).ToString("00:00"), new Vector2(270, 100), Color.Black);

            }
            else if(screen == Screen.Outro) 
            {
                _spriteBatch.Draw(OutroTexture,OutroRect, Color.White);
                _spriteBatch.DrawString(outroFont, "You've escaped your ticket! ", new Vector2(300, 70), Color.Black);
            }

            _spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}