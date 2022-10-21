//public, protected ou private - definem se a classe pode ser vista externamente
//abstract - usada como base e não pode ser instanciada
//instanciar - criar um objeto baseado na classe

//abstract - DEVE ser implementada em todas as classes, porém todas devem definir COMO fazer com override
//virtual - DEVE ser implementada em todas, porém se não for definida com override, segue o padrão da classe pai
//se deixar sem nada, NÃO PODE SOFRER OVERRIDE




public abstract class Player
{
    public int Moeda { get; protected set; } = 1; //o set é protected para garantir que não seja possível setar ele por classes maiores. O "=10" define um valor padrão para iniciar
    public abstract bool Decidir();  //abstract pois cada player *DEVE* decidir, porém uma decisão *DIFERENTE*. Bool pois ela retorna um true ou false. Void não retorna nada
    public virtual void Recebe(int valor)  //virtual pois todos *DEVEM* receber, porém a maioria vai receber *DA MESMA FORMA* (possui comportamento padrão, mas pode sofrer override)
    {
            this.Moeda += valor;
    }
}