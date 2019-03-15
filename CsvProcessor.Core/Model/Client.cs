using Data.Repository.Base;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ScvProcessor.Core.Model
{
    [Table("Clients")]
    public class Client : EntityBase<Guid>
    {
        [Column("Client_Name")]
        public string ClientName { get; set; }
        [Column("Client_Address")]
        public string ClientAddress { get; set; }
    }
}
