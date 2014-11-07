using System;
using System.Collections.Generic;
using System.Linq;
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
      private SpriteFont _font;
      private readonly List<Figure> _denizens = new List<Figure>();

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

         var playerSprite = Content.Load<Texture2D>("Player");

         _denizens.Add(new Mass
         {
            Position = new Vector2(0, 0),
            Sprite = playerSprite,
            Name = "Mr. Rogue"
         });

         _denizens.Add(new Mass
         {
            Position = new Vector2(20, 0),
            Sprite = playerSprite,
            Name = "Mr. Rogue"
         });

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
         _camera.HandleInput(_inputState);

         foreach (var denizen in _denizens)
         {
            var currentDenizen = denizen;
            var intention = currentDenizen.Act(_denizens.Where(i => i != currentDenizen));
            //currentDenizen.Position += (intention.Direction / 10);
         }

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

         foreach (var denizen in _denizens)
         {
            denizen.Draw(_spriteBatch);
         }
         //_spriteBatch.DrawString(_font, _pos.ToString(), new Vector2(100, 100), Color.Red);

         _spriteBatch.End();

         base.Draw(gameTime);
      }
   }
}
