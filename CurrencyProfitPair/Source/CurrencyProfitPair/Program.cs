using System;
using System.Collections.Generic;
using System.Linq;

namespace CurrencyProfitPair
{
  public static class Program
  {
    /// <summary>
    /// Defines the entry point of the application.
    /// </summary>
    /// <param name="args">The arguments.</param>
    static void Main(string[] args)
    {
      try
      {
        Console.WriteLine("Please, insert integer values separated with space:");
        string[] inputConsoleArray = Console.ReadLine().Split(' ');

        int[] resultArray = GetArrayFromConsole(inputConsoleArray);

        // validate empty array
        if (resultArray.Length == 0)
        {
          FailureMessage();

          return;
        }

        KeyValuePair<int[], int> maxProfitValues = FindPairsWithMaxProfit(resultArray);

        // validate null result
        if(maxProfitValues.Key == null)
        {
          FailureMessage();

          return;
        }

        Console.WriteLine($"buy at {maxProfitValues.Key[0]} and sell at " +
                          $"{maxProfitValues.Key[1]} for a maximum profit of {maxProfitValues.Key[2]}");
        Console.ReadKey();
      }
      catch (Exception e)
      {
        Console.Write($"Error {e.Message}");
        Console.ReadKey();
      }
    }

    /// <summary>
    /// Gets the array from console.
    /// </summary>
    public static int[] GetArrayFromConsole(string[] inputArray)
    {
      var list = new List<int>();

      // exclude collection with less then 2 values
      if (inputArray.Length < 2)
      {
        return list.ToArray();
      }

      // check if all values are the same/equal
      if (!inputArray.ToList().Distinct().Skip(1).Any())
      {
        return list.ToArray();
      }

      for (int i = 0; i < inputArray.Length; i++)
      {
        // validate integer values
        int outResult;
        if(int.TryParse(inputArray[i], out outResult))
        {
          int result = int.Parse(inputArray[i]);

          // exclude values with 0 and negative
          if(result > 0)
          {
            list.Add(int.Parse(inputArray[i]));
          }
        }
      }

      // exclude collection with less then 2 values
      if (list.Count < 2)
      {
        return new List<int>().ToArray();
      }

      return list.ToArray();
    }

    /// <summary>
    /// Finds the pairs with maximum profit.
    /// </summary>
    /// <param name="arrCurrencyValues">The array of currency values.</param>
    public static KeyValuePair<int[],int> FindPairsWithMaxProfit(int[] arrCurrencyValues)
    {
      var dictProfits = new Dictionary<int[], int>();
      foreach (int i in arrCurrencyValues)
      {
        int minValue = i;
        int indexMin = Array.IndexOf(arrCurrencyValues, minValue);
        int[] arrayTemp = GetArrayWithMaxValue(arrCurrencyValues, indexMin);
        if (arrayTemp.Length > 0)
        {
          int maxValue = arrayTemp.Max();
          int profit = maxValue - minValue;
          if (profit > 0)
          {
            var arrayCase = new int[] { minValue, maxValue, profit };
            dictProfits.Add(arrayCase, profit);
          }
        }
      }

      if (dictProfits.Count > 0)
      {
        var itemMaxProfit = dictProfits.FirstOrDefault(x => x.Value == dictProfits.Values.Max());

        return itemMaxProfit;
      }
      
      return new KeyValuePair<int[], int>();
    }

    /// <summary>
    /// Generate the array for 
    /// find the max value.
    /// </summary>
    /// <param name="arrValues">The array of currency values.</param>
    /// <param name="indexMin">The index of minimal value.</param>
    public static int[] GetArrayWithMaxValue(int[] arrValues, int indexMin)
    {
      var listTemp = new List<int>();
      for (int n = indexMin + 1; n < arrValues.Length; n++)
      {
        listTemp.Add(arrValues[n]);
      }

      return listTemp.ToArray();
    }

    /// <summary>
    /// Failures the message.
    /// </summary>
    private static void FailureMessage()
    {
      Console.WriteLine("system doesn't find acceptable values");
      Console.ReadKey();
    }
  }
}

