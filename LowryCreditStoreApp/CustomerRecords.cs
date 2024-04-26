using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LowryCreditStoreApp
{
    public class CustomerRecords
    {
        public Guid CustomerID { get; set; }
        //private fields with default values, so app doesnt crush from user mistake
        private string _ApplicantName = "FullName";
        private bool _EmploymentStatus = false;
        private int _YearsInCurrentJob = 0;
        private int _YearsAtCurrentResidence = 0;
        private double _MonthlySalary = 0.00;
        private double _AmountOfNonMortageDebt = 0.00;
        private int _NumberOfChildren = 0;

        //Constructor of this class, calling public fields of the private fields
        public CustomerRecords(string applicantName, bool employmentStatus, int yearsInCurrentJob, int yearsAtCurrentResidence, double monthlySalary, double amountOfNonMortageDebt, int numberOfChildren)
        {
            _ApplicantName = applicantName;
            _EmploymentStatus = employmentStatus;
            _YearsInCurrentJob = yearsInCurrentJob;
            _YearsAtCurrentResidence = yearsAtCurrentResidence;
            _MonthlySalary = monthlySalary;
            _AmountOfNonMortageDebt = amountOfNonMortageDebt;
            _NumberOfChildren = numberOfChildren;
        }

        //Public fields with validation
        public string ApplicantName
        {
            get { return _ApplicantName; }
            set
            {
                if (_ApplicantName != value)
                {
                    _ApplicantName = value;
                }
                else
                {
                    throw new ArgumentException("Invalid value for Applicant Name");
                }
            }
        }

        public bool EmploymentStatus
        {
            get { return _EmploymentStatus; }
            set
            {
                if (value == true || value == false)
                {
                    _EmploymentStatus = value;
                }
                else
                {
                    throw new ArgumentException("Invalid value for EmploymentStatus. Please enter either true or false.");
                }
            }

        }

        public int YearsInCurrentJob 
        {
            get { return _YearsInCurrentJob; }
            set
            {
                if (_YearsInCurrentJob != value)
                {
                    if (value >= 0) // Check if the value is non-negative
                    {
                        _YearsInCurrentJob = value;
                    }
                    else
                    {
                        throw new ArgumentException("You didn't enter a valid number of children. Please enter a non-negative integer.");
                    }
                }
            }
        }

        public int YearsAtCurrentResidence
        {
            get { return _YearsAtCurrentResidence; }
            set
            {
                if (_YearsAtCurrentResidence != value)
                {
                    if (value >= 0) // Check if the value is non-negative
                    {
                        _YearsAtCurrentResidence = value;
                    }
                    else
                    {
                        throw new ArgumentException("You didn't enter a valid number of children. Please enter a non-negative integer.");
                    }
                }
            }
        }

        public double MonthlySalary
        {
            get { return _MonthlySalary; }
            set
            {
                if (_MonthlySalary != value)
                {
                    if (value >= 0) // Check if the value is non-negative
                    {
                        _MonthlySalary = value;
                    }
                    else
                    {
                        throw new ArgumentException("You didn't enter a valid number of children. Please enter a non-negative integer.");
                    }
                }
            }
        }

        public double AmountOfNonMortageDebt
        {
            get { return _AmountOfNonMortageDebt; }
            set
            {
                if (_MonthlySalary != value)
                {
                    if (value >= 0) // Check if the value is non-negative
                    {
                        _MonthlySalary = value;
                    }
                    else
                    {
                        throw new ArgumentException("You didn't enter a valid number of children. Please enter a non-negative integer.");
                    }
                }
            }
        }

        public int NumberOfChildren
        {
            get { return _NumberOfChildren; }
            set
            {
                if (_NumberOfChildren != value)
                {
                    if (value >= 0) // Check if the value is non-negative
                    {
                        _NumberOfChildren = value;
                    }
                    else
                    {
                        throw new ArgumentException("You didn't enter a valid number of children. Please enter a non-negative integer.");
                    }
                }
            }
        }


    }
}
