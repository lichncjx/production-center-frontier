using System;
using System.Collections.Generic;
using Abp.Domain.Values;
using CentersFrontier.Production.Workshops;
using Microsoft.EntityFrameworkCore;

namespace CentersFrontier.Production.Tasks
{
    [Owned]
    [Obsolete]
    public class TaskCode : ValueObject
    {
        public TaskCode(string classification, Workshop mainWorkshop, string sequenceNumber)
        {
            Classification = classification;
            MainWorkshop = mainWorkshop;
            SequenceNumber = sequenceNumber;
        }

        public string Classification { get; set; }
        public Workshop MainWorkshop { get; set; }
        public string SequenceNumber { get; set; }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Classification;
            yield return MainWorkshop;
            yield return SequenceNumber;
        }
    }
}