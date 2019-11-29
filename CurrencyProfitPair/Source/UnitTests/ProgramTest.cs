using System;
using System.Collections.Generic;
using CurrencyProfitPair;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
  [TestClass]
  public class ProgramTest
  {
    [TestMethod]
    public void GetArrayFromConsole_InsertWrongArray_ReturnValidArray()
    {
      string[] arr = { "1", "0", "22", "Rt1", "null", "", "99" };
      int[] arrExpected =  { 1, 22, 99 };

      int[] arrActual = Program.GetArrayFromConsole(arr);

      CollectionAssert.AreEqual(arrExpected, arrActual);
    }

    [TestMethod]
    public void GetArrayFromConsole_InsertDuplicateValuesWrongArray_ReturnEmptyArray()
    {
      string[] arr = { "12", "12", "12" };
      int[] arrExpected = new int[]{};

      int[] arrActual = Program.GetArrayFromConsole(arr);

      CollectionAssert.AreEqual(arrExpected, arrActual);
    }

    [TestMethod]
    public void GetArrayWithMaxValue_InsertArray_ReturnPartOfArray()
    {
      int[] arr = { 100, 1, 22, 99, 3, 44, 2 };
      int[] arrExpected = { 22, 99, 3, 44, 2 };

      int[] arrActual = Program.GetArrayWithMaxValue(arr, 1);

      CollectionAssert.AreEqual(arrExpected, arrActual);
    }

    [TestMethod]
    public void FindPairsWithMaxProfit_InsertArray_ReturnProfitArrayValues()
    {
      int[] arr = { 100, 1, 22, 99, 3, 44, 2 };
      int[] expectedProfitItem = { 1, 99, 98 };

      KeyValuePair<int[], int> profitItemActual = Program.FindPairsWithMaxProfit(arr);
      int[] arrActual = profitItemActual.Key;

      CollectionAssert.AreEqual(expectedProfitItem, arrActual);
    }

    [TestMethod]
    public void FindPairsWithMaxProfit_InsertWrongArray_ReturnNull()
    {
      int[] arr = { 12, 11, 10 };

      KeyValuePair<int[], int> profitItemActual = Program.FindPairsWithMaxProfit(arr);
      int[] arrActual = profitItemActual.Key;

      CollectionAssert.AreEqual(null, arrActual);
    }
  }
}


