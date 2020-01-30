using System;

namespace Cotecna.Inspections.Abstractions.Entities
{
    public class Inspection
    {
        public int Id { get; set; }
        public DateTime InspectionDate { get; set; }
        public string Customer { get; set; }
        public string Observations { get; set; }
        public int  Status { get; set; }
        public Inspector Inspector { get; set; }
    }
}
