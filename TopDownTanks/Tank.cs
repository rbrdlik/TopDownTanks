using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
// ReSharper disable All

namespace TopDownTanks;

public class Tank
{
    private Texture2D _texture;
    private Vector2 _position;
    private float _speed;
    private int _screenWidth;
    private int _screenHeight;
    private List<Missile> _missiles;
    private Texture2D _missileTexture;
    private bool _isShooting;

    public Tank(Texture2D texture, Vector2 position, float speed, int screenWidth, int screenHeight, List<Missile> missiles, Texture2D missileTexture)
    {
        _texture = texture;
        _position = position;
        _speed = speed;
        _screenWidth = screenWidth;
        _screenHeight = screenHeight;
        _missiles = missiles;
        _missileTexture = missileTexture;
        _isShooting = false;
    }

    public void Update(GameTime gameTime)
    {
        float dt = (float)gameTime.ElapsedGameTime.TotalSeconds;
        var keyboardState = Keyboard.GetState();
        var mouseState = Mouse.GetState();
        
        if (keyboardState.IsKeyDown(Keys.W) && _position.Y > 0)
        {
            _position.Y -= _speed * dt;
        }
        if (keyboardState.IsKeyDown(Keys.S) && _position.Y < _screenHeight - _texture.Height)
        {
            _position.Y += _speed * dt;
        }
        if (keyboardState.IsKeyDown(Keys.A) && _position.X > 0)
        {
            _position.X -= _speed * dt;
        }
        if (keyboardState.IsKeyDown(Keys.D) && _position.X < _screenWidth - _texture.Width)
        {
            _position.X += _speed * dt;
        }
        
        if (mouseState.LeftButton == ButtonState.Pressed && !_isShooting)
        {
            Shoot(new Vector2(mouseState.X, mouseState.Y));
            _isShooting = true;
        }
        else if (mouseState.LeftButton == ButtonState.Released)
        {
            _isShooting = false;
        }
    }

    private void Shoot(Vector2 targetPosition)
    {
        Vector2 tankRightCenter = new Vector2(_position.X + _texture.Width, _position.Y + _texture.Height / 2);
        Vector2 direction = targetPosition - tankRightCenter;
        direction.Normalize();

        _missiles.Add(new Missile(_missileTexture, tankRightCenter, direction));
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(_texture, _position, Color.White);
    }
}
