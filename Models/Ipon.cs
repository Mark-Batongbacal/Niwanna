using System.Collections.Generic;
using System.Linq;

namespace Niwanna.Models
{
    public class Ipon
    {
        public int IponId { get; set; }
        public string Name { get; set; } = "Shared Ipon";

        public List<IponEntry> Entries { get; set; } = new List<IponEntry>();

        public int Total => Entries.Sum(e => e.Amount);
    }
}
