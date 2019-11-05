using System.Collections.Generic;
using CentersFrontier.Production.Entities;
using CentersFrontier.Production.Launches;

namespace CentersFrontier.Production.Models
{
    public class Model : SimpleCndEntity
    {
        public Series Series { get; set; }

        public string DerivedFrom { get; set; }
        public ICollection<Model> Derivatives { get; set; } = new List<Model>();

        public ICollection<Launch> Launches { get; set; }
    }

    public class Series : SimpleCndEntity
    {
        public ICollection<Model> Models { get; set; } = new List<Model>();
    }
}