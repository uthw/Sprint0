using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Sprint0_2.Game.Command;
using Sprint0_2.Game.Entity;
using Sprint0_2.Game.Graphics;
using Sprint0_2.Game.Input;

namespace Sprint0_2;

public class Game1 : Microsoft.Xna.Framework.Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    
    private Player _player;
    
    private KeyboardController _keyboardController;
    private MouseController _mouseController;

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        _keyboardController = new KeyboardController();
        _mouseController = new MouseController();
        
        _player = new Player();
        
        // Bind commands to button presses
        _keyboardController.RegisterCommand(Keys.D, new SetWalkingPlayerSpriteCommand(_player));
        _mouseController.RegisterCommand(MouseButton.LeftButton, new SetRockingPlayerSpriteCommand(_player));
        
        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice); // Texture rendering
        
        SpriteFactory.Instance.LoadAllAssets(Content); // Player sprites
        TextCreator.Initialize(Content);

        _player.Sprite = SpriteFactory.Instance.CreateIdlePlayerSprite();
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
            Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();
        
        _player.Update(gameTime);
        _mouseController.Update();
        _keyboardController.Update();

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);
        
        _spriteBatch.Begin();
        TextCreator.CreateSprint0Text(Window, _spriteBatch);
        _player.Draw(_spriteBatch, new Vector2(100, 100));
        _spriteBatch.End();

        base.Draw(gameTime);
    }
}