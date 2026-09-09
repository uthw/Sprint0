using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0_2.Game.Graphics;

namespace Sprint0_2.Content.Game;

public class Player
{
    public Vector2 Position;
    
    // Animation data
    private Sprite _sprite;
    private SpriteAnimation _startAnim;
    private SpriteAnimation _walkAnim;

    public Player(Texture2D texture)
    {
        Position = Vector2.Zero;
        
        _sprite = new Sprite(texture);
        _sprite.Scale = new Vector2(2.0f);

        var width = 39;
        var height = 44;
        var count = 16;
        var duration = 0.08f;

        _walkAnim = new SpriteAnimation(_sprite, width, height, count, duration);
    }

    public virtual void Update(GameTime gameTime)
    {
        // TODO input goes here
        
        _walkAnim.Update(gameTime);
    }

    public void Draw(SpriteBatch spriteBatch, Vector2 position)
    {
        _sprite.Draw(spriteBatch, position);
    }
}