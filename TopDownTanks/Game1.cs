using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
// ReSharper disable All

namespace TopDownTanks;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    private Tank _tank;
    private Texture2D _backgroundTexture;
    private List<Missile> _missiles;
    private Texture2D _missileTexture;

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        _graphics.PreferredBackBufferWidth = 1280; 
        _graphics.PreferredBackBufferHeight = 720; 
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        _missiles = new List<Missile>();
        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        Texture2D tankTexture = Content.Load<Texture2D>("tank");
        _backgroundTexture = Content.Load<Texture2D>("background");
        
        _missileTexture = new Texture2D(GraphicsDevice, 1, 1);
        _missileTexture.SetData(new[] { Color.White });

        Vector2 startPosition = new Vector2(40, 290);
        float tankSpeed = 200f;
        _tank = new Tank(tankTexture, startPosition, tankSpeed, _graphics.PreferredBackBufferWidth, _graphics.PreferredBackBufferHeight, _missiles, _missileTexture);
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
            Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        _tank.Update(gameTime);
        
        for (int i = _missiles.Count - 1; i >= 0; i--)
        {
            _missiles[i].Update(gameTime);
            if (!_missiles[i].IsVisible)
            {
                _missiles.RemoveAt(i);
            }
        }

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        _spriteBatch.Begin();
        _spriteBatch.Draw(_backgroundTexture, new Rectangle(0, 0, _graphics.PreferredBackBufferWidth, _graphics.PreferredBackBufferHeight), Color.White);
        _tank.Draw(_spriteBatch);
        
        foreach (var missile in _missiles)
        {
            missile.Draw(_spriteBatch);
        }

        _spriteBatch.End();
        base.Draw(gameTime);
    }
}
