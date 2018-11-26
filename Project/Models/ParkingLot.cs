using System;
using System.Collections.Generic;

namespace Project.Models
{
    public partial class ParkingLot
    {
        public string LotId { get; set; }
        public string SpotId { get; set; }
        public string LotName { get; set; }
        public int LotStreetNumber { get; set; }
        public string LotStreetName { get; set; }
        public string LotCity { get; set; }
        public decimal LotHourlyRate { get; set; }
        public decimal LotDailyRate { get; set; }
        public decimal LotWeeklyRate { get; set; }
        public decimal LotMonthlyRate { get; set; }
        public decimal LotYearlyRate { get; set; }
    }
}
