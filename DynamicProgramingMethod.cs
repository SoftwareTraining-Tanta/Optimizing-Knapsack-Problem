Dictionary<int, int> dp = new();
int RecursiveKnapsack(int[] weights, int[] values, int capacity)
{
    if (dp.ContainsKey(capacity)) return dp[capacity];
    if (capacity == 0 || weights.Length == 0) return 0;
    //if weight of first item is greater than capacity, skip it and recurse
    if (weights[0] > capacity) return RecursiveKnapsack(weights.Skip(1).ToArray(), values.Skip(1).ToArray(), capacity);
    //return maximum between the last item value and the last item value + the value of the current item and skip the first element for iteration until the capacity iss 0 then it will exit
    dp[capacity] = Math.Max(
        values[0] + RecursiveKnapsack(weights.Skip(1).ToArray(), values.Skip(1).ToArray(), capacity - weights[0])
        , RecursiveKnapsack(weights.Skip(1).ToArray(), values.Skip(1).ToArray(), capacity));
    return dp[capacity];
}

int Knapsack(int[] weights, int[] values, int capacity)
{
    // 2 dimensional array represents the weight of the item and the capacity of the knapsack
    int[,] dp = new int[weights.Length + 1, capacity + 1];
    if (weights.Length == 0 || capacity == 0)
    {
        return 0;
    }
    //iterator on the number of items
    for (int i = 1; i <= weights.Length; i++)
    {//iterator on the capacity of the knapsack to check if the current item i-1 can be added in the current capacity j
        for (int j = 1; j <= capacity; j++)
        {
            if (weights[i - 1] > j)
            {
                dp[i, j] = dp[i - 1, j]; //get the last item value (profit) if it can't be added in the current capacity
            }
            else
            {// get the max between the max of the last item value and the last item value + the value of the current item
                dp[i, j] = Math.Max(dp[i - 1, j], dp[i - 1, j - weights[i - 1]] + values[i - 1]);
            }
        }
    }
    return dp[weights.Length, capacity];//return the last item value as it will be the max value (profit) among them
}
Console.WriteLine(RecursiveKnapsack(new int[] { 2, 3, 4, 5 }, new int[] { 1, 2, 5, 6 }, 8));
Console.WriteLine(Knapsack(new int[] { 2, 3, 4, 5 }, new int[] { 1, 2, 5, 6 }, 8));

/*
0 0 0 0 0 0 0 0 0
0 0 1 1 1 1 1 1 1
0 0 1 2 2 3 3 3 3
0 0 1 2 5 5 6 7 7
0 0 1 2 5 6 6 7 8 <--(max value(profit))
*/

