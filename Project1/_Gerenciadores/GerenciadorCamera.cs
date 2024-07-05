using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Project1._Gerenciadores;

public class GerenciadorCamera
{
    private Vector2 _posicao;
    private Vector2 _ultimaPosicaoMouse;

    // fator de escala para definir a velocidade de translação da câmera
    private const float FatorEscala = 0.1f;

    public Matrix Transformacao
    {
        get { return Matrix.CreateTranslation(new Vector3(-_posicao, 0)); }
    }

    public void Update()
    {
        var estadoMouse = Mouse.GetState();

        // Se o botão direito do mouse estiver pressionado
        if (estadoMouse.RightButton == ButtonState.Pressed)
        {
            // Se é a primeira vez que o botão direito do mouse é pressionado
            if (_ultimaPosicaoMouse == Vector2.Zero)
            {
                _ultimaPosicaoMouse = new Vector2(estadoMouse.X, estadoMouse.Y);
            }

            // Calcula a diferença entre a posição atual do mouse e a última posição do mouse
            var diferenca = _ultimaPosicaoMouse - new Vector2(estadoMouse.X, estadoMouse.Y);

            // Atualiza a posição da câmera
            _posicao += diferenca * FatorEscala;
        }
        else
        {
            // Se o botão direito do mouse não estiver pressionado, zera a última posição do mouse
            _ultimaPosicaoMouse = Vector2.Zero;
        }
    }
}
