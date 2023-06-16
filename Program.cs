using System;
namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            char[,] numbers = { { 'e', 'e', 'e' }, { 'e', 'e', 'e' }, { 'e', 'e', 'e' } };
            PrintTableIndex(numbers);
            Console.WriteLine("Write index of table (example 01)");
            int count = 0;
            while (true)
            {


                if (count % 2 == 0) Console.Write("Player 1: ");
                else Console.Write("Player 2: ");
                string index = Console.ReadLine();
                while (CheckElement(numbers, index) != true)
                {
                    Console.Write("Index is taken or its out of range, try again: ");
                    index = Console.ReadLine();
                }
                Console.Clear();
                numbers = ChangeTableValue(numbers, index, count);
                count++;
                PrintTableIndex(numbers);
                if (FirstCheckStatus(numbers) == true)
                {
                    Console.WriteLine("Winner is PLAYER1!!!");
                    break;
                }
                if (SecondCheckStatus(numbers) == true)
                {
                    Console.WriteLine("Winner is PLAYER2!!!");
                    break;
                }
                if (CheckDrawStatus(numbers) == true)
                {
                    Console.WriteLine("Its a DRAW...");
                    break;
                }

            }
            Console.ReadLine();

        }

        static void PrintTableIndex(char[,] emptyTable)//Prints table
        {
            for (int i = 0; i < emptyTable.GetLength(0); i++)
            {
                for (int j = 0; j < emptyTable.GetLength(1); j++)
                {
                    if (emptyTable[i, j] == 'e') Console.Write($"[{i}][{j}] ");
                    else Console.Write($"  ({emptyTable[i, j]})  ");
                }
                Console.WriteLine();
            }
        }
        static char[,] ChangeTableValue(char[,] tableValue, string indexArr, int count)//Changes table values
        {

            int indexI = ConvertStringElementToInt(indexArr, 0);
            int indexJ = ConvertStringElementToInt(indexArr, 1);

            for (int i = 0; i < tableValue.GetLength(0); i++)
            {
                for (int j = 0; j < tableValue.GetLength(1); j++)
                {
                    if (i == indexI && j == indexJ)
                    {
                        tableValue[i, j] = PlayerTurn(count);
                    }
                }
            }
            return tableValue;
        }
        static char PlayerTurn(int count)//Check player turn
        {
            if (count % 2 == 0) return 'x';
            else return 'o';
        }
        static bool FirstCheckStatus(char[,] table)
        {
            char element = 'x';

            if (element == table[0, 0] && element == table[0, 1] && element == table[0, 2]) return true;
            else if (element == table[1, 0] && element == table[1, 1] && element == table[1, 2]) return true;
            else if (element == table[2, 0] && element == table[2, 1] && element == table[2, 2]) return true;
            else if (element == table[0, 0] && element == table[1, 0] && element == table[2, 0]) return true;
            else if (element == table[0, 1] && element == table[1, 1] && element == table[2, 1]) return true;
            else if (element == table[0, 2] && element == table[1, 2] && element == table[2, 2]) return true;
            else if (element == table[0, 0] && element == table[1, 1] && element == table[2, 2]) return true;
            else if (element == table[0, 2] && element == table[1, 1] && element == table[2, 0]) return true;
            else return false;
        } //Manual Check
        static bool SecondCheckStatus(char[,] table)
        {
            char element = 'o';

            if (element == table[0, 0] && element == table[0, 1] && element == table[0, 2]) return true;
            else if (element == table[1, 0] && element == table[1, 1] && element == table[1, 2]) return true;
            else if (element == table[2, 0] && element == table[2, 1] && element == table[2, 2]) return true;
            else if (element == table[0, 0] && element == table[1, 0] && element == table[2, 0]) return true;
            else if (element == table[0, 1] && element == table[1, 1] && element == table[2, 1]) return true;
            else if (element == table[0, 2] && element == table[1, 2] && element == table[2, 2]) return true;
            else if (element == table[0, 0] && element == table[1, 1] && element == table[2, 2]) return true;
            else if (element == table[0, 2] && element == table[1, 1] && element == table[2, 0]) return true;
            else return false;
        }//Manual Check
        static bool CheckElement(char[,] table, string index)//Checks Element if its typed correctly
        {
            int indexI = ConvertStringElementToInt(index, 0);
            int indexJ = ConvertStringElementToInt(index, 1);
            if (indexI <= table.GetLength(0) && indexJ <= table.GetLength(1))
            {
                if (table[indexI, indexJ] == 'e') return true;
                else return false;
            }
            else return false;
        }
        static bool CheckDrawStatus(char[,] table)//Checks if its draw
        {
            int count = 0;
            for (int i = 0; i < table.GetLength(0); i++)
            {
                for (int j = 0; j < table.GetLength(1); j++)
                {
                    if (table[i, j] == 'e') count++;
                }
            }
            if (count == 0) return true;
            else return false;
        }
        static int ConvertStringElementToInt(string index, int i)//Converts one element of string to int
        {
            char[] indexChar = index.ToCharArray();
            string indexStrI = indexChar[i].ToString();
            int indexI = ConvertStringToInt(indexStrI);
            return indexI;
        }
        static int ConvertStringToInt(string toBeConvertedNumber)//Converts String to int
        {
            int convertInt;
            if (int.TryParse(toBeConvertedNumber, out convertInt) != false)
            {
                return convertInt;
            }
            else
            {
                Console.WriteLine($"{toBeConvertedNumber} is not a number");
                return 0;
            }
        }
        static bool FirstCheckGameStatus(char[,] table) //Auto Check DOES NOT WORKING // NOT IN USE
        {
            bool status = false;
            char firstElement = 'x';
            int[] statuses = { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            for (int i = 0; i < table.GetLength(0); i++)
            {
                for (int j = 0; j < table.GetLength(1); j++)
                {
                    if (firstElement == table[0, j]) { statuses[0]++; if (statuses[0] == 3) status = true; }
                    else if (firstElement == table[1, j]) { statuses[1]++; if (statuses[1] == 3) status = true; }
                    else if (firstElement == table[2, j]) { statuses[2]++; if (statuses[2] == 3) status = true; }
                    else if ((i == j) && (firstElement == table[i, j])) { statuses[6]++; if (statuses[6] == 3) status = true; }
                    //    else if ((i + j == table.GetLength(0) - 1) && (firstElement == table[i, j])) { statuses[7]++; if (statuses[7] == 3) status = true; }
                    else status = false;
                }
                if (firstElement == table[i, 0]) { statuses[3]++; if (statuses[3] == 3) status = true; }
                else if (firstElement == table[i, 1]) { statuses[4]++; if (statuses[4] == 3) status = true; }
                else if (firstElement == table[i, 2]) { statuses[5]++; if (statuses[5] == 3) status = true; }
                else status = false;
            }
            return status;
        }
        static bool SecondCheckGameStatus(char[,] table) //Auto Check DOES NOT WORKING // NOT IN USE
        {
            bool status = false;
            char secondElement = 'o';
            int[] statuses = { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            for (int i = 0; i < table.GetLength(0); i++)
            {
                for (int j = 0; j < table.GetLength(1); j++)
                {
                    if (secondElement == table[0, j]) { statuses[0]++; if (statuses[0] == 3) status = true; }
                    else if (secondElement == table[1, j]) { statuses[1]++; if (statuses[1] == 3) status = true; }
                    else if (secondElement == table[2, j]) { statuses[2]++; if (statuses[2] == 3) status = true; }
                    else if ((i == j) && secondElement == table[i, j]) { statuses[6]++; if (statuses[6] == 3) status = true; }
                    //else if ((i + j == table.GetLength(0) - 1) && (secondElement == table[i, j])) { statuses[7]++; if (statuses[7] == 3) status = true; }
                    else status = false;
                }
                if (secondElement == table[i, 0]) { statuses[3]++; if (statuses[3] == 3) status = true; }
                else if (secondElement == table[i, 1]) { statuses[4]++; if (statuses[4] == 3) status = true; }
                else if (secondElement == table[i, 2]) { statuses[5]++; if (statuses[5] == 3) status = true; }
            }
            return status;
        }
    }
}
