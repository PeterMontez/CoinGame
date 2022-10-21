public class Copiador : Player
{
    private bool vouAjudar { get; set; } = true;
    public override bool Decidir()
    {
        return this.vouAjudar;
    }

    public override void Recebe(int valor)
    {
        this.vouAjudar = valor > 0;  //valor > 0 resulta em um valor booleano igual a jogada do oponente. se valor < = 0, o outro jogador não ajudou. Se valor > 0, ele ajudou
        base.Recebe(valor);  // repete exatamente o que foi definido na classe pai
    }
}
