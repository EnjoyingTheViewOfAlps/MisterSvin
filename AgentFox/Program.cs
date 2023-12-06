using System;
using System.Collections.Generic;
using System.Linq;
using AgentFox;
class Program
{
    static void Main()
    {
        Deck deck = new Deck();
        deck.Shuffle();

        Player player = new Player("Игрок");
        Player computer = new Player("Компьютер");

        player.DrawCards(deck, 6);
        computer.DrawCards(deck, 6);

        bool gameOver = false;

        while (!gameOver)
        {
            Console.WriteLine($"{player.Name}'s ход:");
            player.PlayTurn(computer);
            player.DisplayHand();

            Console.WriteLine($"{computer.Name}'s ход:");
            computer.PlayTurn(player);
            computer.DisplayHand();

            gameOver = player.HasWon() || computer.HasWon();
        }

        if (player.HasWon())
        {
            Console.WriteLine($"{player.Name} выиграл!");
        }
        else if (computer.HasWon())
        {
            Console.WriteLine($"{computer.Name} выиграл!");
        }
        else
        {
            Console.WriteLine("Ничья!");
        }
    }
}
