using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Project1._Gerenciadores;

public static class GerenciadorInput
{
    private static KeyboardState _lastKs;
    
    private static Point _direcao;
    public static Point Direcao => _direcao;
    
    public static Point Posicao_do_Mouse => Mouse.GetState().Position;

    public static void Update()
    {
        var ks = Keyboard.GetState();
        _direcao = Point.Zero;

        if (ks.IsKeyDown(Keys.W) && _lastKs.IsKeyUp(Keys.W)) _direcao.Y--;
        if (ks.IsKeyDown(Keys.S) && _lastKs.IsKeyUp(Keys.S)) _direcao.Y++;
        if (ks.IsKeyDown(Keys.A) && _lastKs.IsKeyUp(Keys.A)) _direcao.X--;
        if (ks.IsKeyDown(Keys.D) && _lastKs.IsKeyUp(Keys.D)) _direcao.X++;

        _lastKs = ks;
    }

}