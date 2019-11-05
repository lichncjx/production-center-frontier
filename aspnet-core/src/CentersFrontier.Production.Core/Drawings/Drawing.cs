using System.Collections.Generic;
using Abp.Domain.Values;
using CentersFrontier.Production.Entities;
using CentersFrontier.Production.Models;
using Microsoft.EntityFrameworkCore;

namespace CentersFrontier.Production.Drawings
{
    public abstract class Drawing : SimpleCndEntity
    {
        public DevelopmentStage Stage { get; set; }
    }

    public class Part : Drawing
    {
        public PartSort Sort { get; set; }
    }

    public class Assembly : Drawing
    {
        public ICollection<AssemblyDetail> AssemblyDetails { get; set; } = new List<AssemblyDetail>();
    }

    [Owned]
    public class AssemblyDetail : ValueObject
    {
        public int Ordinal { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public string Material { get; set; }
        public float? UnitWeight { get; set; }
        public float? TotalWeight { get; set; }
        public bool Borrowed { get; set; }
        public Drawing Drawing { get; set; }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Ordinal;
            yield return Code;
            yield return Name;
            yield return Quantity;
            yield return Material;
            yield return UnitWeight;
            yield return Borrowed;
        }
    }
}