using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0_2.Game.Graphics;

namespace Sprint0_2.Game.Entity;

public class Player
{
    // Animation data
    public Sprite Sprite { get; set; }
    public SpriteAnimation Animation { get; set; }
    public bool IsWalking { get; set; }
    
    // Motion
    private const float Speed = 5.0f;
    private Vector2 Position { get; set; }
    private bool _previouslyFacingRight = true;
    private bool _isFlippedHorizontally;

    public Player()
    {
        Sprite = SpriteFactory.Instance.CreateIdlePlayerSprite();
        Position = new Vector2(200, 100);
    }
    
    public Player(Sprite sprite)
    {
        Sprite = sprite;
        Position = new Vector2(200, 100);
    }

    public void MoveHorizontal(bool isToTheRight)
    {
        Position = isToTheRight
            ? new Vector2(Position.X + Speed, Position.Y)
            : new Vector2(Position.X - Speed, Position.Y);
        
        // Flip the sprite if the direction changes
        if (isToTheRight != _previouslyFacingRight)
        {
            _isFlippedHorizontally = !_isFlippedHorizontally;
        }
        
        _previouslyFacingRight = isToTheRight;
    }

    public virtual void Update(GameTime gameTime)
    {
        Animation?.Update(gameTime);
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        Sprite.Draw(spriteBatch, Position, _isFlippedHorizontally);
    }
}