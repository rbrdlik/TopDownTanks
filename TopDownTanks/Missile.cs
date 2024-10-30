using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
// ReSharper disable All

namespace TopDownTanks;

public class Missile
{
    private Texture2D _texture;
    private Vector2 _position;
    private Vector2 _direction;
    private float _speed = 300f;
    private const int MissileSize = 10;

    public bool IsVisible => _position.X >= 0 && _position.X <= 1280 && _position.Y >= 0 && _position.Y <= 720;

    public Missile(Texture2D texture, Vector2 startPosition, Vector2 direction)
    {
        _texture = texture;
        _position = startPosition;
        _direction = direction;
    }

    public void Update(GameTime gameTime)
    {
        float dt = (float)gameTime.ElapsedGameTime.TotalSeconds;
        _position += _direction * _speed * dt;
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(_texture, new Rectangle((int)_position.X, (int)_position.Y, MissileSize, MissileSize), Color.Red);
    }
}