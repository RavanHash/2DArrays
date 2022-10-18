internal class Program
{
    private static void Main(string[] args)
    {
        int n = InputInt(); 
        int m = InputInt();

        Console.WriteLine();

        int[,] array = Random2DArray(n, m);
        //int[,] array = Input2DArray(n, m);
        
        Output2DArray(array);
        Console.WriteLine();

        // 1. Console.WriteLine(MinElementOf2DArray(array));
        /* 4. int[] minIndex = MinIndexOf2DArray(array);
              Console.WriteLine("(" + minIndex[0] + ", " + minIndex[1] + ")");*/
        // 5. Console.WriteLine(AmountOfBiggerNeighbor(array));
        // 6. Mirror2DArray(array);
        // 8. OutputArray(ProductOfElemInRows(array));
        // 9. SaddlePointIn2DArray(array);
        // 10. Output2DArray(SpiralFillOf2DArray(n));
    }

    #region Useful functions
    private static int InputInt()
    {
        int number;

        Console.Write("Enter integer number: ");

        while (!int.TryParse(Console.ReadLine(), out number))
        {
            Console.Write("This is not valid input. Please enter an integer value: ");
        }

        return number;
    }

    private static int[,] Input2DArray(int arrayHeight, int arrayWidth)
    {
        int[,] matrix = new int[arrayHeight, arrayWidth];

        for (int i = 0; i < arrayHeight; i++)
        {
            for (int j = 0; j < arrayWidth; j++)
            {
                Console.Write("[" + i + ", " + j + "] ");
                matrix[i, j] = InputInt();
            }
        }
        Console.WriteLine();

        return matrix;
    }

    private static int[,] Random2DArray(int arrayHeight, int arrayWidth)
    {
        int[,] randomArray = new int [arrayHeight, arrayWidth];
        Random random = new Random();

        for (int i = 0; i < arrayHeight; i++)
        {
            for (int j = 0; j < arrayWidth; j++)
            {
                randomArray[i, j] = random.Next(-10, 20);
            }
        }

        return randomArray;
    }

    private static void Output2DArray(int[,] matrix)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                Console.Write("  " + matrix[i, j] + "\t");
            }
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
        }
    }

    private static void OutputArray(int[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            Console.Write(array[i] + " ");
        }
    }
    #endregion

    // 1. Find out minimal element.
    private static int MinElementOf2DArray(int[,] matrix)
    {
        int min = matrix[0, 0];

        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if(matrix[i, j] < min)
                    min = matrix[i, j];
            }
        }

        return min;
    }
    
    // 4. Find out minimal element.
    private static int[] MinIndexOf2DArray(int[,] matrix)
    {
        int min = matrix[0, 0];
        int[] minIndex = new int[2];

        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if(matrix[i, j] < min)
                {
                    min = matrix[i, j];
                    minIndex[0] = i;
                    minIndex[1] = j;
                }
            }
        }

        return minIndex;
    }

    // 5. Find out amount of elements that are bigger than every it’s neighbor.	
    private static int AmountOfBiggerNeighbor(int[,] matrix)
    {
        int amount = 0;

        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 1; j < matrix.GetLength(1) - 1; j++)
            {
                if (matrix[i, j] > matrix[i, j + 1] && matrix[i, j] > matrix[i, j - 1])
                {
                    amount++;
                }
            }
        }

        return amount;
    }

    // 6. Mirror array from it’s main diagonal.
    private static void Mirror2DArray(int[,] matrix)
    {
        for (int i = 0; i < matrix.GetLength(1); i++)
        {
            for (int j = 0; j < matrix.GetLength(0); j++)
            {
                Console.Write("  " + matrix[j, i] + "\t");
            }
            Console.WriteLine();
        }
    }

    // 7. не понял условие задания

    // 8. Using integer array n*m create 1-d arrays with elements equals to: b. Product of elements in all rows;
    private static int[] ProductOfElemInRows(int[,] matrix)
    {
        int[] result = new int[matrix.GetLength(0)];

        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            result[i] = 1;

            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                result[i] *= matrix[i, j];
            }
        }

        return result;
    }

    // 9. Find out indexes of every saddle point in integer array n*m.
    private static void SaddlePointIn2DArray(int[,] matrix)
    {
        int minInRow = matrix[0, 0];
        int maxCol = matrix[0, 0];
        int colIndex = 0;
        int rowIndex = 0;

        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            minInRow = matrix[i, 0];
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if(matrix[i, j] < minInRow)
                {
                    minInRow = matrix[i, j];
                    colIndex = j;
                }
            }

            maxCol = matrix[0, colIndex];
            for (int k = 0; k < matrix.GetLength(0); k++)
            {
                if (matrix[k, colIndex] > maxCol)
                {
                    maxCol = matrix[k, colIndex];
                    rowIndex = k;
                }
            }

            if(maxCol == minInRow)
                Console.Write("(" + rowIndex + "; " + colIndex + ")");
        }
    }

    // 10. не понял условие задания
    // 11. не понял условие задания

    // 12. Fill 2-d array n*n with numbers from 1 to n*n arranged a spiral, starting from upper left corner and moving clockwise https://www.youtube.com/watch?v=J9Whmip4XB8
    private static int[,] SpiralFillOf2DArray(int n)
    {
        int[,] array = new int[n, n];
        int num = 1;

        for (int delta = 0; delta < n - 2; delta++)
        {
            for (int i = 0 + delta; i < n - delta; i++)
            {
                array[0 + delta, i] = num;
                num++;
            }
            num--;

            for (int i = 0 + delta; i < n - delta; i++)
            {
                array[i, n - 1 - delta] = num;
                num++;

            }
            num--;

            for (int i = n - 1 - delta; i >= 0 + delta; i--)
            {
                array[n - 1 - delta, i] = num;
                num++;

            }
            num--;

            for (int i = n - 1 - delta; i >= 1 + delta; i--)
            {
                array[i, 0 + delta] = num;
                num++;
            }
        }  

        return array;
    }
}