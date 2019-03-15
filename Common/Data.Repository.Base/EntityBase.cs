using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Repository.Base
{
    public abstract class EntityBase<TKey>
    {
        [Column("Id")]
        public TKey Id { get; set; }
    }
}
