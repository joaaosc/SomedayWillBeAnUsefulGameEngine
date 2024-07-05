using Project1._Modelos;

namespace Project1._Gerenciadores;

public class GerenciadorGame
{
    private readonly Mapa _mapa= new();
    private readonly GerenciadorCamera _camera = new();
    
    public void Update()
    {
        GerenciadorInput.Update();
        _camera.Update();
        _mapa.Update();
    }
    
    public void Draw()
    {
        Globais.Sb.End();
        Globais.Sb.Begin(transformMatrix: _camera.Transformacao);
        _mapa.Draw();

    }
}