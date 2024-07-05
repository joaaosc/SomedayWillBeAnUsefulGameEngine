using Project1._Modelos;

namespace Project1._Gerenciadores;

public class GerenciadorGame
{
    private readonly Mapa _mapa= new();
    
    public void Update()
    {
        GerenciadorInput.Update();
        _mapa.Update();
    }
    
    public void Draw()
    {
        _mapa.Draw();
    }
}