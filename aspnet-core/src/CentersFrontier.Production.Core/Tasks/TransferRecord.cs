using System;
using Abp.Domain.Entities;
using CentersFrontier.Production.Entities;
using CentersFrontier.Production.Quality;

namespace CentersFrontier.Production.Tasks
{
    public class TransferRecord : Entity, IReceptionAudited
    {
        public string CertificateId { get; set; }
        public Certificate Certificate { get; set; }

        public string Remark { get; set; }

        public bool IsReceived { get; set; }
        public DateTime ReceptionTime { get; set; }
        public long? RecipientUserId { get; set; }
    }
}