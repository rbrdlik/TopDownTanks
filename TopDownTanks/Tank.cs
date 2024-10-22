namespace TopDownTanks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

public class Tank
{
    private Texture2D _texture;
    private Vector2 _position;
    private float _speed;

    public Tank(Texture2D texture, Vector2 position, float speed)
    {
        _texture = texture;
        _position = position;
        _speed = speed;
    }

    public void Update(GameTime gameTime)
    {
        float dt = (float)gameTime.ElapsedGameTime.TotalSeconds;
        var keyboardState = Keyboard.GetState();

        if (keyboardState.IsKeyDown(Keys.W))
        {
            _position.Y -= _speed * dt;
        }
        if (keyboardState.IsKeyDown(Keys.S))
        {
            _position.Y += _speed * dt;
        }
        if (keyboardState.IsKeyDown(Keys.A))
        {
            _position.X -= _speed * dt;
        }
        if (keyboardState.IsKeyDown(Keys.D))
        {
            _position.X += _speed * dt;
        }
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(_texture, _position, null, Color.White);
    }
}