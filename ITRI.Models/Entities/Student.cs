using System;
using System.Collections.Generic;

namespace ITRI.Models.Entities
{
    public partial class Student
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public byte Status { get; set; }
        public int Number { get; set; }
        public int? CardNumber { get; set; }
        public string ChineseName { get; set; }
        public string EnglishName { get; set; }
        public DateTimeOffset? CreateDate { get; set; }
        public DateTimeOffset? ModifyDate { get; set; }
        public byte[] Qrcode { get; set; }
        public byte? Gender { get; set; }
        public int? Year { get; set; }
        public string Class { get; set; }
        public int? ClassNumber { get; set; }
        public int? GoOutWeekends { get; set; }
        public int? GoOutWeekdays { get; set; }
        public int? OvernightWeekends { get; set; }
        public byte? GoOutWeekendsT { get; set; }
        public byte? GoOutWeekdaysT { get; set; }
        public byte? OvernightWeekendsT { get; set; }
        public DateTimeOffset? GoOutWeekendsTime { get; set; }
        public DateTimeOffset? GoOutWeekdaysTime { get; set; }
        public DateTimeOffset? OvernightWeekendsTime { get; set; }
    }
}
