using System;
using Microsoft.VisualBasic.CompilerServices;

namespace WebApiDemo
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string Phone { get; set; }

        public int CompanyId { get; set; }
        public string PassportType { get; set; }
        public string PassportNumber { get; set; }

//public struct PassportStruct {
//    public string Type { get; set; }
//    public string Number { get; set; }
//}
//public PassportStruct Passport { get; set; }

    }
}