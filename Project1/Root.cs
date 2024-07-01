using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Project1._Modelos;

namespace Project1;

public class Root : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    private _Gerenciadores.GerenciadorGame _gameManager;
    private Mapa _mapa;

    public Root()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        _graphics.PreferredBackBufferWidth = 1024;
        _graphics.PreferredBackBufferHeight = 768;
        _graphics.ApplyChanges();

        Globais.Cm = Content;

        _gameManager = new();

        base.Initialize();

    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);
        Globais.Sb = _spriteBatch;
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
            Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();
        
        _gameManager.Update();

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.Black);

        _spriteBatch.Begin();
        _gameManager.Draw();
        _spriteBatch.End();

        base.Draw(gameTime);
    }
}