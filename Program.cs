using System;

class TicTacToe
{
    static string[,] tabla = new string[3, 3];
    static string[] jatekosok = new string[2];
    static int mozdul;

    static void Main()
    {
        Console.WriteLine("=== Tic Tac Toe ===");

        for (int i = 0; i < 2; i++)
        {
            Console.Write($"{i + 1}. játékos neve vagy szimbóluma (pl. 'Messi' vagy '{(i == 0 ? "X" : "O")}'): ");
            jatekosok[i] = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(jatekosok[i]))
                jatekosok[i] = i == 0 ? "X" : "O"; // alapértelmezett értékek
        }

        Resettabla();
        string winner = null; // győztes változó inicializálása

        while (true)
        {
            Printtabla();
            string Jatekos = jatekosok[mozdul % 2];
            Console.WriteLine($"{Jatekos} következik.");
            Console.Write("Add meg a sor és oszlop számát (1-3, szóközzel elválasztva): ");

            var input = Console.ReadLine()?.Split(' ');
            if (input?.Length != 2 ||
                !int.TryParse(input[0], out int row) || // sor szám ellenőrzése
                !int.TryParse(input[1], out int col) || // oszlop szám ellenőrzése
                row is < 1 or > 3 || // sor szám ellenőrzése megint
                col is < 1 or > 3 || // oszlop szám ellenőrzése megint 
                tabla[row - 1, col - 1] != " ")
            {
                Console.WriteLine(" Hibás vagy foglalt mező! Próbáld újra.");
                continue;
            }
            tabla[row - 1, col - 1] = Jatekos; // lépés végrehajtása
            mozdul++;
            if (CheckWin(Jatekos))
            {
                winner = Jatekos;
                break;
            }
            if (mozdul == 9) break;
        }
        Printtabla();
        Console.WriteLine(winner != null ? $"Győztes: {winner}!" : "Döntetlen!"); // döntetlen esetén
    }
    static void Resettabla()
    {
        for (int i = 0; i < 3; i++)
            for (int j = 0; j < 3; j++)
                tabla[i, j] = " ";
        mozdul = 0;
    }
    static void Printtabla()
    {
        Console.Clear();
        Console.WriteLine("   1   2   3 ");
        for (int i = 0; i < 3; i++)
        {
            Console.Write($" {i + 1} ");
            for (int j = 0; j < 3; j++)
            {
                Console.Write($" {tabla[i, j]} ");
                if (j < 2) Console.Write("|");
            }
            Console.WriteLine();
            if (i < 2) Console.WriteLine("  ---+---+---");
        }
        Console.WriteLine();
    }
    static bool CheckWin(string p)
    {
        for (int i = 0; i < 3; i++)
            if ((tabla[i, 0] == p && tabla[i, 1] == p && tabla[i, 2] == p) || //ez a sorok ellenőrzése
                (tabla[0, i] == p && tabla[1, i] == p && tabla[2, i] == p)) //ez az oszlopok ellenőrzése
                return true;
        return (tabla[0, 0] == p && tabla[1, 1] == p && tabla[2, 2] == p) || //ez az átlók ellenőrzése
               (tabla[0, 2] == p && tabla[1, 1] == p && tabla[2, 0] == p); //ez az átlók ellenőrzése szinten
    }
}