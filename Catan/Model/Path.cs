using System.Collections.Generic;

namespace Catan.Model
{
    public class Path
    {
        private readonly List<Intersection> intersections;
        private Player owner;
        private bool hasRoad;

        public Path(List<Intersection> intersections)
        {
            this.intersections = intersections;
            foreach (var intersection in intersections)
            {
                intersection.AddPath(this);
            }
        }
   
        public virtual Player GetOwner() {
            return owner;
        }

        public void SetOwner(Player player) {
            owner = player;
            hasRoad = true;
        }

        public bool HasRoad() {
            return hasRoad;
        }

        public List<Intersection> GetIntersections() {
            return intersections;
        }
    }
}
