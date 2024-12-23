using System;

class DiceSum
{
    // Solution 1: Dynamic Programming Approach
    // This approach uses a DP table to compute the number of ways to achieve the sum X with n dice and m faces.
    public static int CountWaysDP(int n, int m, int X)
    {
        int[,] dp = new int[n + 1, X + 1];

        // Base case: 1 way to achieve sum 0 with 0 dice
        dp[0, 0] = 1;

        for (int dice = 1; dice <= n; dice++)
        {
            for (int target = 1; target <= X; target++)
            {
                for (int face = 1; face <= m; face++)
                {
                    if (target - face >= 0)
                    {
                        dp[dice, target] += dp[dice - 1, target - face];
                    }
                }
            }
        }

        return dp[n, X];
    }

    // Solution 2: Recursive Approach with Memoization
    // This approach uses recursion and memoization to reduce redundant calculations.
    public static int CountWaysRecursiveMemo(int n, int m, int X, int[,] memo = null)
    {
        if (memo == null)
        {
            memo = new int[n + 1, X + 1];
            for (int i = 0; i <= n; i++)
                for (int j = 0; j <= X; j++)
                    memo[i, j] = -1;
        }

        if (n == 0)
            return X == 0 ? 1 : 0;

        if (X < 0)
            return 0;

        if (memo[n, X] != -1)
            return memo[n, X];

        int ways = 0;
        for (int face = 1; face <= m; face++)
        {
            ways += CountWaysRecursiveMemo(n - 1, m, X - face, memo);
        }

        memo[n, X] = ways;
        return ways;
    }

    // Solution 3: Recursive Approach without Memoization
    // This approach uses plain recursion without storing intermediate results.
    public static int CountWaysRecursive(int n, int m, int X)
    {
        if (n == 0)
            return X == 0 ? 1 : 0;

        if (X < 0)
            return 0;

        int ways = 0;
        for (int face = 1; face <= m; face++)
        {
            ways += CountWaysRecursive(n - 1, m, X - face);
        }

        return ways;
    }

    static void Main(string[] args)
    {
        Console.WriteLine("Dynamic Programming Approach:");
        Console.WriteLine(CountWaysDP(4, 2, 1));
        Console.WriteLine(CountWaysDP(4, 2, 5));
        Console.WriteLine(CountWaysDP(4, 3, 5));

        Console.WriteLine("\nRecursive Approach with Memoization:");
        Console.WriteLine(CountWaysRecursiveMemo(4, 2, 1));
        Console.WriteLine(CountWaysRecursiveMemo(4, 2, 5));
        Console.WriteLine(CountWaysRecursiveMemo(4, 3, 5));

        Console.WriteLine("\nRecursive Approach without Memoization:");
        Console.WriteLine(CountWaysRecursive(4, 2, 1));
        Console.WriteLine(CountWaysRecursive(4, 2, 5));
        Console.WriteLine(CountWaysRecursive(4, 3, 5));
    }
}