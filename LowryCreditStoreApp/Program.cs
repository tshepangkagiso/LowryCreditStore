using System;
using System.Collections.Generic;

namespace LowryCreditStoreApp
{
    public enum Menu
    {
        Capture_Details = 1,
        Check_Credit_Qualification,
        Show_Qualification_Stats,
        Exit_The_Program
    }

    public class Program
    {
        static void Main(string[] args)
        {
            // Variables and Data Structure Declaration
            int userChoice;
            string userDecision;
            bool choice = true;
            Menu item1 = LowryCreditStoreApp.Menu.Capture_Details;
            Menu item2 = LowryCreditStoreApp.Menu.Check_Credit_Qualification;
            Menu item3 = LowryCreditStoreApp.Menu.Show_Qualification_Stats;
            Menu item4 = LowryCreditStoreApp.Menu.Exit_The_Program;

            string menu = "Welcome To Lowry Store\n " +
                          "=============================\n" +
                          $"\n1) {Enum.GetName(typeof(Menu), item1)}" +
                          $"\n2) {Enum.GetName(typeof(Menu), item2)}" +
                          $"\n3) {Enum.GetName(typeof(Menu), item3)}" +
                          $"\n4)  {Enum.GetName(typeof(Menu), item4)}" +
                          "\n=============================";

            List<CustomerRecords> records = new List<CustomerRecords>();
            List<CustomerRecords> QualifyingApplicants = new List<CustomerRecords>();

            // Application Logic
            while (true)
            {
                Console.WriteLine($"{menu}");
                Console.Write("\n Enter your choice: ");
                if (int.TryParse(Console.ReadLine(), out userChoice))
                {

                    switch(userChoice)
                    {
                        case 1:
                            while(choice == true)
                            {
                                CaptureDetails(records);
                                Console.Write("Do you want to continue, press Y for yes and N for no: ");
                                userDecision = Console.ReadLine().Trim().ToLower();

                                if (userDecision != null && (userDecision == "yes" || userDecision == "y" || userDecision == "ye"))
                                {
                                    continue;
                                }
                                else if (userDecision != null && (userDecision == "no" || userDecision == "n"))
                                {
                                    choice = false;
                                    break;
                                }
                            }
                            break;

                        case 2:
                            CheckCreditQualification(QualifyingApplicants, records);
                            break;

                        case 3:
                            ShowQualificationStats(QualifyingApplicants);
                            break;

                        case 4:
                            ExitTheProgram();
                            break;

                        default:
                            Console.WriteLine("Invalid Input, try again!");
                             break;

                    }
                    continue;

                }
                else
                {
                    Console.WriteLine("Value you have entered is invalid, try again!");
                    continue;
                }
            }

        }

        //Methods
        public static List<CustomerRecords> CaptureDetails(List<CustomerRecords> records)
        {
            Console.Write("Enter your Full Name: ");
            string applicantName = Console.ReadLine();

            Console.Write("Are you currently working? true or false: ");
            bool employmentStatus;
            if (Boolean.TryParse(Console.ReadLine(), out employmentStatus))
            {
            }
            else
            {
                employmentStatus = false;
            }

            Console.Write("How long have you been working there? e.g 1 or 2: ");
            int yearsInCurrentJob;
            if (int.TryParse(Console.ReadLine(), out yearsInCurrentJob))
            {
            }
            else
            {
                yearsInCurrentJob = 0;
            }

            Console.Write("How long have you been living in current home or location? e.g 1 or 2: ");
            int yearsAtCurrentResidence;
            if (int.TryParse(Console.ReadLine(), out yearsAtCurrentResidence))
            {
            }
            else
            {
                yearsAtCurrentResidence = 0;
            }

            Console.Write("How much do you earn per month? e.g 100.00 : ");
            double monthlySalary;
            if (double.TryParse(Console.ReadLine(), out monthlySalary))
            {
            }
            else
            {
                monthlySalary = 0.00;
            }

            Console.Write("How much in total is your current mortage debt? e.g 100.00 : ");
            double amountOfNonMortageDebt;
            if (double.TryParse(Console.ReadLine(), out amountOfNonMortageDebt))
            {
            }
            else
            {
                amountOfNonMortageDebt = 0.00;
            }

            Console.Write("How many children do you have? e.g 1 or 2: ");
            int numberOfChildren;
            if (int.TryParse(Console.ReadLine(), out numberOfChildren))
            {
            }
            else
            {
                numberOfChildren = 0;
            }

            CustomerRecords CustomerDetail = new CustomerRecords(applicantName, employmentStatus, yearsInCurrentJob, yearsAtCurrentResidence, monthlySalary, amountOfNonMortageDebt, numberOfChildren);
            records.Add(CustomerDetail);
            Console.WriteLine("Customer has been added!\n");

            return records;
        }

        public static List<CustomerRecords> CheckCreditQualification(List<CustomerRecords> QualifyingApplicants, List<CustomerRecords> records)
        {
            int qualifies = 0;
            int notQualified = 0;
            foreach (CustomerRecords rec in records)
            {
                if (rec.EmploymentStatus == true && rec.YearsInCurrentJob >= 1 && rec.YearsAtCurrentResidence >= 2)
                {
                    Console.WriteLine($"{rec.ApplicantName} has been approved\n");
                    CustomerRecords CustomerDetail = new CustomerRecords(rec.ApplicantName, rec.EmploymentStatus, rec.YearsInCurrentJob, rec.YearsAtCurrentResidence, rec.MonthlySalary, rec.AmountOfNonMortageDebt, rec.NumberOfChildren);

                    QualifyingApplicants.Add(CustomerDetail);
                    qualifies++;
                }
                else if (rec.MonthlySalary * 2 > rec.AmountOfNonMortageDebt || rec.NumberOfChildren > 6)
                {
                    Console.WriteLine($"{rec.ApplicantName} has been denied credit\n");
                    notQualified++;
                }
                else
                {
                    Console.WriteLine($"{rec.ApplicantName} does not meet qualification or denial criteria\n");
                    notQualified++;
                }
            }
            Console.WriteLine($"Number of applicants that qualify: {qualifies}");
            Console.WriteLine($"Number of applicants that don't qualify: {notQualified}");
            return QualifyingApplicants;
        }


        public static void ShowQualificationStats(List<CustomerRecords> QualifyingApplicants)
        {
            int QualifyingCount = 1;

            Console.WriteLine("\n These are all the Applicants Qualify: ");
            Console.WriteLine("========================\n");

            foreach (CustomerRecords rec in QualifyingApplicants)
            {
                Console.WriteLine($"{QualifyingCount}: {rec.ApplicantName}");
                QualifyingCount++;
            }

            Console.WriteLine("========================\n");
        }

        public static void ExitTheProgram()
        {
            string answer;
            Console.Write("Do you want to exit the progam, please enter \'y\' to confirm: ");
            answer = Console.ReadLine().Trim().ToLower();
            if(answer != null || answer == "yes" || answer == "y" || answer == "ye")
            {
                Console.WriteLine("GoodBye!");
                Environment.Exit(0);
            }
        }

    }
}
