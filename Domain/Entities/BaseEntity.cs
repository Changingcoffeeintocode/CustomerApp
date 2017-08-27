using System.ComponentModel.DataAnnotations;

namespace Domain.Entieties
{
    public abstract class BaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}