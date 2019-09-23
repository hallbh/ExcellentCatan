using System.Collections.Generic;

namespace Catan.Model
{
    public class Harbor
    {
        public readonly Item Resource;
        public readonly List<Intersection> AdjacentIntersections;

        public Harbor(Item exchangeType, List<Intersection> adjacentIntersections)
        {
            Resource = exchangeType;
            AdjacentIntersections = adjacentIntersections;
        }

        public virtual Player GetOwner()
        {
            foreach (var intersection in AdjacentIntersections)
                if (intersection.HasSettlement || intersection.HasCity)
                    return intersection.GetOwner();

            return null;
        }
    }
}
