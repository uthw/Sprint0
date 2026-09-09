using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Sprint0_2.Game.Command;
using Sprint0_2.Game.Entity;
using Sprint0_2.Game.Graphics;

namespace Sprint0_2;

public class Game1 : Microsoft.Xna.Framework.Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    private Texture2D PlayerWalkTexture { get; set; }
    private Player _player;

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here

        base.Initialize();
    }

    protected override void LoadContent()
    {
        // Create a SpriteBatch used to render textures
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        // Load player textures
        SpriteFactory.Instance.LoadAllAssets(Content);
        
        // Create a Player instance with the texture
        _player = new Player();
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
            Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();
        
        _player.Update(gameTime);

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);
        
        _spriteBatch.Begin();
        _player.Draw(_spriteBatch, new Vector2(100, 100));
        _spriteBatch.End();

        base.Draw(gameTime);
    }
}