using System;
using System.Collections.Generic;
using Abp.Domain.Values;
using Microsoft.EntityFrameworkCore;

namespace CentersFrontier.Production.Tasks
{
    [Owned]
    [Obsolete]
    public class TaskCode : ValueObject
    {
        public TaskCode(string classification, Manufacturer mainWorkshop, string sequenceNumber)
        {
            Classification = classification;
            MainWorkshop = mainWorkshop;
            SequenceNumber = sequenceNumber;
        }

        public string Classification { get; set; }
        public Manufacturer MainWorkshop { get; set; }
        public string SequenceNumber { get; set; }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Classification;
            yield return MainWorkshop;
            yield return SequenceNumber;
        }
    }
}