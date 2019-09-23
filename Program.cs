using System;

namespace Assignment1_F19
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 1, b = 22;
            printSelfDividingNumbers(a, b);

            int n2 = 5;
            printSeries(n2);

            int n3 = 5;
            printTriangle(n3);

            int[] J = new int[] { 1, 3 };
            int[] S = new int[] { 1, 3, 3, 2, 2, 2, 2, 2 };
            int r4 = numJewelsInStones(J, S);
            Console.WriteLine(r4 + "\n");


            int[] arr1 = new int[] { 1, 2, 5, 6, 7, 8, 9 };
            int[] arr2 = new int[] { 1, 2, 3, 4, 5 };
            //int[] r5 = 
            getLargestCommonSubArray(arr1, arr2);
            //Console.WriteLine(r5);

            solvePuzzle();
        }

        public static void printSelfDividingNumbers(int x, int y)
        {
            try
            {
                Console.Write("The self diving numbers between" + " " + x + " and " + y + " are\n");
                //looping through all the values between x and y
                for (int i = x; i <= y; i++)
                {
                    if (isSelfDividing(i))//Check if a nuber is self dividing or not
                    {
                        Console.Write(i);// Print self diving number.
                        if (i < y - 1)
                        {
                            Console.Write(",");
                        }
                    }
                }


                bool isSelfDividing(int z)
                {
                    if (z == 0) return false; //If number is equal to 0 then return false i.e. not self dividing
                    if (z < 0) z = Math.Abs(z); //For a negative nuber assign its absolute value to the nuber instead

                    int tempnum = z;
                    while (z != 0)
                    {
                        int rem = z % 10; //calculate the mod 10 of the number.this will separate the number into its digits.
                        if (rem == 0 || tempnum % rem != 0)  // check if either a digit is 0 or if the number isn't divisible by the digit and return false.
                        {
                            return false;
                        }
                        z = z / 10;//removes the units digit to run the above check for remaining digits.
                    }
                    return true; //returns true for self dividing numbers after iterating through all the digits of the number.
                }
            }
            catch
            {
                Console.WriteLine("Exception occured while computing printSelfDividingNumbers()");
            }
        }

        public static void printSeries(int n)
        {
            try
            {

                int z = 1;
                Console.Write("\n\nThe series with the number of terms in ther series equal to " + n + " is\n");
                if (n == 1)//check if n equals 1 and print 1 as the series.
                    Console.Write("1");
                else

                    for (int i = 1; i <= n; i++) //loop starting from 1 until n to print a series starting from 1 containing n numbers
                    {
                        for (int j = i; j > 0; j--)
                        {
                            if (z <= n)
                                Console.Write(i);
                            if (z < n)
                                Console.Write(",");
                            z = z + 1;
                        }
                    }
            }
            catch
            {
                Console.WriteLine("Exception occured while computing printSeries()");
            }
        }


        public static void printTriangle(int n)
        {
            try
            {
                Console.Write("\n\nInverted Triangle pattern for value of n=" + n + " will print below\n");
                for (int i = n; i > 0; i--)  // prints n nuber of rows
                {
                    for (int j = 0; j <= n - i; j++) // prints n-rownumber of spaces before each line of *s.
                        Console.Write(" ");
                    for (int k = 1; k <= 2 * i - 1; k++)  //prints 2*row_number -1 number of stars in each row
                        Console.Write("*");
                    Console.Write("\n");
                }
            }
            catch
            {
                Console.WriteLine("Exception occured while computing printTriangle()");
            }
        }

        public static int numJewelsInStones(int[] J, int[] S)
        {
            try
            {
                int countofjewels = 0;
                Console.Write("\n\n Number of stones that are also jewels is ");
                for (int x = 0; x < J.Length; x++) //for all the values of jewel
                {
                    for (int y = 0; y < S.Length; y++)// for all the values in stone
                    {
                        if (S[y] == J[x])  //check if a stone matches a value in jewels increment the count of jewels.
                        {
                            countofjewels++;
                        }
                    }
                }
                return countofjewels;
            }
            catch
            {
                Console.WriteLine("Exception occured while computing numJewelsInStones()");
            }

            return 0;
        }
        public static void getLargestCommonSubArray(int[] a, int[] b)
        {
            try
            {
                int max_length = 0, len = 0, x = 0, y = 0, z = 0, array_end = 0, start_index = 0;

                while (x < a.Length && y < b.Length)
                {
                    if (a[x] == b[y])//if elements within the 2 arrays match then length increases until continuous elements match
                    {
                        len++;
                        x++;
                        y++;
                    }
                    else
                    {
                        if (a[x] < b[y])
                            x++;          //increase the index and compare next elements
                        else if (b[y] < a[x])
                            y++;
                        if (len >= max_length)
                        {
                            max_length = len;
                            array_end = x;
                        }
                        len = 0;

                    }

                    if (x >= a.Length || y >= b.Length)
                    {
                        if (len >= max_length) //if either of the arrays end assign value of length to max_length if length is greater than max_length
                        {
                            max_length = len;
                            array_end = x;  //store the index of the last value of common array.

                        }
                    }
                }
                start_index = array_end - max_length; //result array would start from index equal difference of last element index and length of result array.
                int[] Common_Array = new int[max_length]; //result array of size same as length of longest array
                Console.Write("The largest common contiguous sub array is: ");
                for (z = 0; z < max_length; z++)
                {
                    Common_Array[z] = a[start_index]; // Add elements to result array starting from element at start_index in array a and insert max_length nuber of elements.

                    start_index++;
                }
                for (x = 0; x < Common_Array.Length; x++)
                    Console.Write(Common_Array[x] + ","); //print result array.
                Console.Write("\n");

            }
            catch
            {
                Console.WriteLine("Exception occured while computing getLargestCommonSubArray()");
            }
        }



        public static void solvePuzzle()
        {
            try
            {   //accept input from user for input and output strings
                Console.Write("Enter  input String 1");
                string str1 = Console.ReadLine();
                Console.Write("Enter  input String 2");
                string str2 = Console.ReadLine();
                Console.Write("Enter output String ");
                string str3 = Console.ReadLine();
                int Input1, Input2, Input3;

                //brute force method of assigning values to each distict character from all the strings
                for (int u = 0; u <= 9; u++)
                {
                    for (int b = 0; b <= 9; b++)
                    {

                        for (int e = 0; e <= 9; e++)
                        {
                            for (int r = 0; r <= 9; r++)

                            {
                                for (int c = 0; c <= 9; c++)
                                {
                                    for (int o = 0; o <= 9; o++)
                                    {
                                        for (int l = 0; l <= 9; l++)
                                        {
                                            for (int n = 0; n <= 9; n++)
                                            {// calculate value of each string 
                                                Input1 = u * 1000 + b * 100 + e * 10 + r * 1;
                                                Input2 = c * 1000 + o * 100 + o * 10 + l * 1;
                                                Input3 = u * 10000 + n * 1000 + c * 100 + l * 10 + e * 1;
                                             // check for which values string1+ string2 =output string and print them
                                                if ((Input1 + Input2 == Input3) && (u != b) && (u != e) && (u != r) && (u != c) && (u != o) && (u != l) && (u != n) && (b != e) && (b != r) && (b != c) && (b != o) && (b != l) && (b != n) && (e != r) && (e != c) && (e != o) && (e != l) && (e != n) && (r != c) && (r != o) && (r != l) && (r != n) && (c != o) && (c != l) && (c != n) && (o != l) && (o != n) && (l != n))
                                                {
                                                    Console.Write(str1 + "  = " + Input1 + "  " + str2 + " = " + Input2 + " " + str3 + " = " + Input3);
                                                    Console.Write("\n");
                                                    Console.Write(str1 + " + " + str2 + " = " + (Input1 + Input2) + "  : " + Input3 + " = " + str3);

                                                    Console.Write("\nvalue of u is " + u);
                                                    Console.Write("\n");


                                                }




                                            }




                                        }
                                    }
                                }

                            }
                        }
                    }
                }

            }
            catch
            {
                Console.WriteLine("Exception occured while computing solvePuzzle()");
            }
        }

        
         
        
    }
}

