Mundo.GerarJogadores(333, 334, 333);

while (Mundo.Rodada < 50000)
{
    Mundo.Jogada();
}

Console.WriteLine($"Rodada: {Mundo.Rodada}!");
Console.WriteLine($"Falidos: {Mundo.Falidos}!");
Console.WriteLine($"Total de Moedas: {Mundo.TotalMoedas}!");
