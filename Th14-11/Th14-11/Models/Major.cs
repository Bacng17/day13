using System.Collections.Generic;
namespace Th14_11.Models
{
    public class Major
    {
        public Major()
        {
            Learners = new HashSet<Learner>();
        }
        public int MajorID { get; set; }
        public string MajorName { get; set; }

        public virtual ICollection<Learner> Learners { get; set; }
    }
}
