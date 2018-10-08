using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales501
{
    public class UI
    {
        static void TransactionFunction(TransactionManager tm)
        {
            while (true)
            {
                Console.WriteLine("Creating new transaction: ");
                Console.WriteLine("Please enter the year");
                int year;
                Int32.TryParse(Console.ReadLine(), out year);
                Console.WriteLine("Please enter the month (in numbers)");
                int month;
                Int32.TryParse(Console.ReadLine(), out month);
                Console.WriteLine("Please enter the day");
                int day;
                Int32.TryParse(Console.ReadLine(), out day);

                Transaction t = new Transaction(year, month, day, tm.IDGenerator());

                while (true)
                {

                    Console.WriteLine("Please enter the items");

                    Console.WriteLine("Please enter name");
                    string name = Console.ReadLine();
                    Console.WriteLine("Please enter price");
                    double value = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("Please enter ID");
                    int code;
                    Int32.TryParse(Console.ReadLine(), out code);

                    Item item = new Item(name, value, code);

                    t.AddItem(item);
                    Console.WriteLine("Add another item or checkout? 1. Add 2. Checkout");
                    int reply;
                    Int32.TryParse(Console.ReadLine(), out reply);
                    if (reply == 2)
                    {
                        break;
                    }
                }
                tm.CheckOut(t);
                Console.WriteLine(t.ToString());
                Console.WriteLine("\n");
                Console.WriteLine("What would you like to do? 1. Add another transaction 2. Return to previous step");
                int response;
                Int32.TryParse(Console.ReadLine(), out response);
                if (response == 2)
                {
                    break;
                }
            }
        }

        static void ReturnFunction(TransactionManager tm)
        {
            while (true)
            {
                Console.WriteLine("Return process: ");
                Console.WriteLine("Please enter the transaction ID: ");
                int n;
                Int32.TryParse(Console.ReadLine(), out n);
                Transaction rt = tm.GetTransaction(n);
                if (rt == null)
                {
                    Console.WriteLine("This transaction doesn't exist.");
                }
                else
                {
                    Console.WriteLine("What would you like to do?  1. Return several items  2. Return all items");
                    int r;
                    Int32.TryParse(Console.ReadLine(), out r);
                    if (r == 1)
                    {
                        while (true)
                        {
                            Console.WriteLine("Please enter item name:");
                            string name = Console.ReadLine();
                            if (rt.CheckItemByName(name))
                            {
                                tm.ChangeTransaction(n, name);
                            }
                            else
                                Console.WriteLine("This item doesn't exist.");

                            Console.WriteLine("Return another item? y or n");
                            Char s = Convert.ToChar(Console.ReadLine().ToLower());
                            if (s == 'n')
                            {
                                break;
                            }
                        }
                        Console.WriteLine(rt.ToString());
                    }
                    else if (r == 2)
                    {
                        tm.DeleteTransaction(n);
                    }

                    Console.WriteLine("\n");
                    Console.WriteLine("What would you like to do?  1. Delete another transaction 2. Return previous step");
                    int nn;
                    Int32.TryParse(Console.ReadLine(), out nn);
                    if (nn == 2)
                    {
                        break;
                    }
                }
            }
        }

        static void DealRebate(TransactionManager tm, RebateManager rm)
        {
            while (true)
            {
                Console.WriteLine("Rebate \n Date must be before 7/15: ");

                Console.WriteLine("Please enter rebate year: ");
                int year;
                Int32.TryParse(Console.ReadLine(), out year);
                Console.WriteLine("Please enter transaction ID: ");
                int n;
                Int32.TryParse(Console.ReadLine(), out n);

                Transaction trans = tm.GetTransaction(n);
                if (trans == null)
                {
                    Console.WriteLine("This transaction doesn't exist.");
                }
                else
                {
                    if (tm.CheckTransactionStatus(n))
                    {
                        Console.WriteLine("This Transaction has been rebated.");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Please enter customer name: ");
                        string name = Console.ReadLine();
                        Console.WriteLine("Please enter customer address: ");
                        string add = Console.ReadLine();
                        Rebate rebate = null;
                        if (trans.Year == year && trans.Month == 6)
                        {
                            double amount = trans.GetTotal() * 0.11;
                            rebate = new Rebate(year, name, add, n, amount);
                        }
                        if (rebate != null)
                        {

                            string s = "Rebated";
                            trans.ChangeStatus(s);
                            rm.AddRebate(rebate);
                            Console.WriteLine(trans.ToString() + "\n" + "the rebate amount: " + rebate.Amount);
                        }
                        else
                        {
                            Console.WriteLine("At this date, the rebate is not valid.");
                        }
                    }
                }

                Console.WriteLine("\n");
                Console.WriteLine("What do you plan to do next:  1. Rabate another transaction 2. return previous step");
                int nn;
                Int32.TryParse(Console.ReadLine(), out nn);
                if (nn == 2)
                {
                    break;
                }
            }
        }

        static void CheckGenerator(RebateManager rm)
        {
            while (true)
            {
                Console.WriteLine("How many checks would you like generated? 1. One   2. All");
                int n;
                Int32.TryParse(Console.ReadLine(), out n);
                if (n == 1)
                {
                    Console.WriteLine("Please enter the transaction ID: ");
                    int nn;
                    Int32.TryParse(Console.ReadLine(), out nn);
                    Rebate r = rm.RebateNumberSearch(nn);
                    if (r != null)
                    {
                        Console.WriteLine(rm.GenerateOneCheck(nn));
                    }
                    else
                        Console.WriteLine("This rebate is not recorded.");
                    break;

                }
                else if (n == 2)
                {
                    Console.WriteLine(rm.GenerateAllChecks());
                }
                else
                    Console.WriteLine("Your input must be 1 or 2.");
            }

        }

        public static void Start(string[] args)
        {
            TransactionManager tm = new TransactionManager();
            RebateManager rm = new RebateManager();
            while (true)
            {
                Console.WriteLine("What would you like to do? 1. Transaction  2. Return  3. Rebate  4. Generate Rebate Check");
                int input;
                Int32.TryParse(Console.ReadLine(), out input);

                if (input == 1)
                {
                    TransactionFunction(tm);
                }
                else if (input == 2)
                {
                    ReturnFunction(tm);
                }
                else if (input == 3)
                {
                    DealRebate(tm, rm);
                }
                else if (input == 4)
                {
                    CheckGenerator(rm);
                }
                else
                    Console.WriteLine("Your input must be 1 or 2 or 3 or 4.");
            }

        }
    }
}
