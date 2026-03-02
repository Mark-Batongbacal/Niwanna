using System;

namespace Niwanna.Models
{
    public class IponEntry
    {
        public int IponEntryId { get; set; }
        public string Name { get; set; }
        public int Amount { get; set; }
        public string Note { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;

        // Foreign key
        public int IponId { get; set; }
        public Ipon Ipon { get; set; }
    }
}
