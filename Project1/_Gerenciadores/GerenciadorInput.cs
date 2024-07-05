using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Project1._Gerenciadores;

public static class GerenciadorInput
{
    private static KeyboardState _lastKs;
    
    private static Point _direcao;
    public static Point Direcao => _direcao;
    
    public static Point Posicao_do_Mouse => Mouse.GetState().Position;
    
    
    // Adiciona um contador de frames
    private static int _contadorFrames = 0;

    // Adiciona uma variável de velocidade
    private static float _velocidade { get; set; } = 4f;

    public static void Update()
    {
        var ks = Keyboard.GetState();

        // Atualiza o contador de frames
        _contadorFrames++;

        // Permite o movimento apenas se o contador de frames for maior que a velocidade
        if (_contadorFrames > _velocidade)
        {
            if (ks.IsKeyDown(Keys.W)) _direcao.Y--;
            else if (ks.IsKeyDown(Keys.S)) _direcao.Y++;
            else if (ks.IsKeyDown(Keys.A)) _direcao.X--;
            else if (ks.IsKeyDown(Keys.D)) _direcao.X++;
            else _direcao = Point.Zero; // Zera a direção se nenhuma tecla direcional estiver sendo pressionada

            // Redefine o contador de frames
            _contadorFrames = 0;
        }

        _lastKs = ks;
    }

    public static void ZerarDirecao()
    {
        _direcao = Point.Zero;
    }

}