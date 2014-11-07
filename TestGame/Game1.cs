using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TestGame
{
   public class Game1 : Game
   {
      private readonly Camera _camera;
      private readonly GraphicsDeviceManager _graphics;
      private readonly InputState _inputState;
      private SpriteBatch _spriteBatch;
      private Player _player;
      private SpriteFont _font;

      public Game1(Camera camera)
      {
         _camera = camera;
         _graphics = new GraphicsDeviceManager(this);
         Content.RootDirectory = "Content";
         _inputState = new InputState();
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
         _camera.ViewportWidth = _graphics.GraphicsDevice.Viewport.Width;
         _camera.ViewportHeight = _graphics.GraphicsDevice.Viewport.Height;

         base.Initialize();
      }

      /// <summary>
      /// LoadContent will be called once per game and is the place to load
      /// all of your content.
      /// </summary>
      protected override void LoadContent()
      {
         // Create a new SpriteBatch, which can be used to draw textures.
         _spriteBatch = new SpriteBatch(GraphicsDevice);

         _player = new Player
         {
            X = 0,
            Y = 0,
            Sprite = Content.Load<Texture2D>("Player"),
            Name = "Mr. Rogue"
         };
         _camera.CenterOn(new Vector2(0, 0));
         _font = Content.Load<SpriteFont>("MyFont");
      }

      /// <summary>
      /// UnloadContent will be called once per game and is the place to unload
      /// all content.
      /// </summary>
      protected override void UnloadContent()
      {
         // TODO: Unload any non ContentManager content here
      }

      /// <summary>
      /// Allows the game to run logic such as updating the world,
      /// checking for collisions, gathering input, and playing audio.
      /// </summary>
      /// <param name="gameTime">Provides a snapshot of timing values.</param>
      protected override void Update(GameTime gameTime)
      {
         if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

         // TODO: Add your update logic here
         _inputState.Update();
         _camera.HandleInput(_inputState, PlayerIndex.One);
         //_player.HandleInput(_inputState);

         var x = gameTime.TotalGameTime.TotalMilliseconds;
         _player.X = (float)(1f * Math.Sin((float)x / 100f));
         _player.Y = (float)(1f * Math.Cos((float)x / 100f));
         base.Update(gameTime);
      }

      /// <summary>
      /// This is called when the game should draw itself.
      /// </summary>
      /// <param name="gameTime">Provides a snapshot of timing values.</param>
      protected override void Draw(GameTime gameTime)
      {
         GraphicsDevice.Clear(Color.CornflowerBlue);

         // TODO: Add your drawing code here
         _spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend, null, null, null, null, _camera.TranslationMatrix);
         
         _player.Draw(_spriteBatch);
         //_spriteBatch.DrawString(_font, _pos.ToString(), new Vector2(100, 100), Color.Red);

         _spriteBatch.End();

         base.Draw(gameTime);
      }
   }
}
