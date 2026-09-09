using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0_2.Game.Graphics;

namespace Sprint0_2.Game.Entity;

public class Player
{
    public Vector2 Position;
    
    // Animation data
    public Sprite Sprite { get; set; }
    public SpriteAnimation Animation { get; set; }

    public Player()
    {
        Sprite = SpriteFactory.Instance.CreateIdlePlayerSprite();
    }
    
    public Player(Sprite sprite)
    {
        Sprite = sprite;
    }

    public virtual void Update(GameTime gameTime)
    {
        // TODO input goes here

        Animation?.Update(gameTime);
    }

    public void Draw(SpriteBatch spriteBatch, Vector2 position)
    {
        Sprite.Draw(spriteBatch, position);
    }
}