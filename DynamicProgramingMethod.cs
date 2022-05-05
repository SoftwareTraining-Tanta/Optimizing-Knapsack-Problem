int Knapsack(int[] weights, int[] values, int capacity)
{

    int[,] dp = new int[weights.Length + 1, capacity + 1];
    if (weights.Length == 0 || capacity == 0)
    {
        return 0;
    }

    for (int i = 1; i <= weights.Length; i++)
    {
        for (int j = 1; j <= capacity; j++)
        {
            if (weights[i - 1] > j)
            {
                dp[i, j] = dp[i - 1, j];
            }
            else
            {
                dp[i, j] = Math.Max(dp[i - 1, j], dp[i - 1, j - weights[i - 1]] + values[i - 1]);
            }
        }
    }
    return dp[weights.Length, capacity];
}
Console.WriteLine(Knapsack(new int[] { 2, 3, 4, 5 }, new int[] { 1, 2, 5, 6 }, 8));
