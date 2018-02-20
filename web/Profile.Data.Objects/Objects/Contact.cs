using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Profile.Common.Entities;

namespace Profile.Data.Objects.Objects
{
    [Table("Contacts")]
    public class Contact : BaseEntity
    {
        [Key]
        public long Id { get; set; }

        public string From { get; set; }

        public string Subject { get; set; }

        public string Message { get; set; }
    }
}
