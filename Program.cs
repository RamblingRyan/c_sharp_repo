using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

class Result
{

    /*
     * Complete the 'missingNumbers' function below.
     *
     * The function is expected to return an INTEGER_ARRAY.
     * The function accepts following parameters:
     *  1. INTEGER_ARRAY arr
     *  2. INTEGER_ARRAY brr
     */

    public static List<int> missingNumbers(List<int> arr, List<int> brr)
    {
        List<int> myAnswer = new List<int>();

        Hashtable ht = new Hashtable();

        Console.WriteLine("arr");
        var arrGroups = arr.GroupBy(i => i);
        foreach (var grp in arrGroups)
        {
            var number = grp.Key;
            var count = grp.Count();
            ht.Add(number, count);
            Console.WriteLine("number {0} has count {1}", number, count);
        }

        Console.WriteLine("brr");
        var brrGroups = brr.GroupBy(i => i);
        foreach (var grp in brrGroups)
        {
            var number = grp.Key;
            var count = grp.Count();
            Console.WriteLine("number {0} has count {1}", number, count);
            var lookup = ht[number];
            bool matched = false;
            if (lookup is not null)
            {
                if (count == (int)lookup)
                {
                    Console.WriteLine("matched");
                    matched = true;
                } else {
                    Console.WriteLine("not matched {0}", lookup);
                }


            }
            if (!(matched)){
                myAnswer.Add(number);
            }
        }

        myAnswer.Sort();

        return myAnswer;

    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter("./output.log", true);


        string[] lines = File.ReadAllLines("input.txt");

        int n = Convert.ToInt32(lines[0].Trim());

        List<int> arr = lines[1].TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();

        int m = Convert.ToInt32(lines[2].Trim());

        List<int> brr = lines[3].TrimEnd().Split(' ').ToList().Select(brrTemp => Convert.ToInt32(brrTemp)).ToList();

        Console.WriteLine("n is {0}", n);


        List<int> result = Result.missingNumbers(arr, brr);

        Console.WriteLine("the result is on the next line");
        Console.WriteLine(String.Join(" ", result));
        textWriter.WriteLine(String.Join(" ", result));

        textWriter.Flush();
        textWriter.Close();
    }
}