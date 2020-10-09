using System.ComponentModel.DataAnnotations;

namespace Onion.Data.Common
{
    public abstract class BaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}
