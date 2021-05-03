using System;

namespace activity_12
{
    class Program
    {
        public int n { get; set; }
        public int c { get; set; }
        public int d { get; set; }
          public void TakeCreditInputs()
        {
            int[] CardNum = new int[16];
            int[] CvvNum = new int[3];
            Console.WriteLine("please enter the card number");
            for (int i = 0; i < CardNum.Length; i++)
            {
                CardNum[i] = Convert.ToInt32(Console.ReadLine());
            }
            Console.WriteLine("please enter the cvv number by digits ");
            for (int i = 0; i < CvvNum.Length; i++)
            {
                CvvNum[i] = Convert.ToInt32(Console.ReadLine());
            }
            Console.WriteLine("please enter the expiry date");
            int expiryDate = Convert.ToInt32(Console.ReadLine());
            if (expiryDate < 01052021)
                Console.WriteLine("invalid expirydate");
            else
                Console.WriteLine("valid expirydate");
            int[] REVCardNum = new int[16];
            for (c = REVCardNum.Length - 1, d = 0; c >= 0; c--, d++)
            {
                REVCardNum[d] = CardNum[c];
            }
            Console.WriteLine("the reversed card number is :");
            for (int i = 0; i < REVCardNum.Length; i++)
            {
                Console.WriteLine(REVCardNum[i]);
            }
            Console.WriteLine("changing the even position");
            for (int i = 0; i < REVCardNum.Length; i++)
            {
                if (i % 2 == 0)
                {
                    REVCardNum[i+1] = REVCardNum[i+1] * 2;
                }
                Console.WriteLine(REVCardNum[i]); 
            }
            Console.WriteLine("changing the even position sum into a single digit");
            for (int i = 0; i < REVCardNum.Length; i++)
            {
                int sum = 0;
                if (i % 2 == 0)
                {
                   if (REVCardNum[i + 1]>10 )
                    {
                        while (REVCardNum[i + 1] > 0)
                        {
                            n = REVCardNum[i + 1] % 10;
                            sum = sum + n;
                            REVCardNum[i + 1] = (REVCardNum[i + 1] / 10);
                        }
                        REVCardNum[i + 1] = sum;
                    }
                }
                Console.WriteLine(REVCardNum[i]);
            }
            Console.WriteLine(" calculating the total sum of the card number.....");
            int sum1 = 0;
            for (int i = 0; i < REVCardNum.Length; i++)
            {
                sum1 = REVCardNum[i] + sum1;
            }
            Console.WriteLine("the total sum is " + sum1);
            if (sum1 % 10==0)
                Console.WriteLine("the given card number is valid");
            else
                Console.WriteLine("the card number is not valid");
        }

        static void Main(string[] args)
        {
            new Program().TakeCreditInputs();

        }
    }
}

