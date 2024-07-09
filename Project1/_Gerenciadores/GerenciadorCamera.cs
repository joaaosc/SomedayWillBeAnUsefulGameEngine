using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Project1._Gerenciadores;

public class GerenciadorCamera
{
    private Vector2 _posicao;
    private Vector2 _ultimaPosicaoMouse;
    private float _zoom = 1f;

    // fator de escala para definir a velocidade de translação da câmera
    private const float FatorEscala = 0.1f;
    private const float FatorZoom = 0.00005f; // novo fator para controlar a velocidade do zoom

    // limites para o zoom
    private const float ZoomMaximo = 2f;
    private const float ZoomMinimo = 0.5f;

    public Matrix Transformacao =>  Matrix.CreateScale(_zoom) * Matrix.CreateTranslation(new Vector3(-_posicao, 0));

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
        
        // Ajusta o zoom com a roda do mouse
        _zoom += estadoMouse.ScrollWheelValue * FatorZoom;

        // Aplica os limites de zoom
        _zoom = MathHelper.Clamp(_zoom, ZoomMinimo, ZoomMaximo);
    }
}
