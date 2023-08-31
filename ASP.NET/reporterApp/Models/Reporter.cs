using System.ComponentModel.DataAnnotations;

namespace Report.Models
{
    public class Reporter
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public string Text { get; set; }
        public int result { get; set; }
    }
}
