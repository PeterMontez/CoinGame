using System;

//static - Permite criar a classe, funções, e usa-las sem precisar instanciar.

public static class Mundo
{
    public static Player[] Players { get; private set; } = new Player[1000];  //Todo método em classe static deve ser static | Cria uma lista de 1000 players
    private static int index { get; set; }
    public static int Falidos { get; private set; }
    public static int TotalMoedas { get; private set; } = Mundo.Players.Length;
    public static int Rodada { get; private set; } = 0;
    public static void Jogada()
    {
        Random r = new Random();  //função que define "r" coomo um objeto random
        Player jogador1, jogador2;
        while(true)
        {
            jogador1 = Mundo.Players[r.Next(Mundo.Players.Length)];  //função Next = randint do python, porém vai por padrão de 0 até o (tamanho da lista)
            jogador2 = Mundo.Players[r.Next(Mundo.Players.Length)];
            if ((jogador1.Moeda > 0 && jogador2.Moeda > 0) && jogador1 != jogador2)  //testa se os jogadores tem moedas e que não são o mesmo
            {
                break;
            }
        }
        int moedasIniciais = jogador1.Moeda + jogador2.Moeda;
        if (jogador1.Decidir() && jogador2.Decidir())
        {
            jogador1.Recebe(1);
            jogador2.Recebe(1);
        }
        else if (jogador1.Decidir() && !jogador2.Decidir())
        {
            jogador1.Recebe(-1);
            jogador2.Recebe(4);
        }
        else if (!jogador1.Decidir() && jogador2.Decidir())
        {
            jogador1.Recebe(4);
            jogador2.Recebe(-1);
        }
        else
        {
            jogador1.Recebe(0);
            jogador2.Recebe(0);
        }

        if (jogador1.Moeda == 0)
            Mundo.Falidos++;
        if (jogador2.Moeda == 0)
            Mundo.Falidos++;

        int moedasFinais = jogador1.Moeda + jogador2.Moeda;
        int novasMoedas = moedasFinais - moedasIniciais;
        Mundo.TotalMoedas += novasMoedas;

        Mundo.Rodada += 1;
    }

    private static void AddJogador(Player jogador)
    {
        Mundo.Players[Mundo.index] = jogador;
        Mundo.index += 1;
    }

    public static void GerarJogadores(int cooperadores, int trapaceiros, int copiadores)
    {
        if (cooperadores + trapaceiros + copiadores > Mundo.Players.Length)
            throw new Exception();

        for (int i = 0; i < cooperadores; i++)
            Mundo.AddJogador(new Cooperador());
        for (int i = 0; i < trapaceiros; i++)
            Mundo.AddJogador(new Trapaceiro());
        for (int i = 0; i < copiadores; i++)
            Mundo.AddJogador(new Copiador());
    }

}