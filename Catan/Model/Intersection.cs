using System.Collections.Generic;

namespace Catan.Model
{
    public class Intersection
    {
        private readonly List<Path> paths;
        private Player owner;
        public virtual bool HasSettlement { get; private set; }
        public virtual bool HasCity { get; private set; }

        public Intersection()
        {
            paths = new List<Path>();
        }

        public void AddPath(Path p)
        {
            paths.Add(p);
        }

        public List<Path> GetPaths()
        {
            return paths;
        }
        
        public void UpgradeToCity() {
            HasCity = true;
            HasSettlement = false;
        }

        public virtual Player GetOwner() {
            return owner;
        }

        public void SetOwner(Player player) {
            owner = player;
            HasSettlement = true;
        }
    }
}
