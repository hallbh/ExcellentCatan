using System.Collections.Generic;
using static Catan.Model.Item;

namespace Catan.Model
{
    public class Hex
    {
        private readonly List<Intersection> intersections;
        public bool HasRobber;
        public readonly Item Resource;
        public int RollNumber { get; }

        public Hex(List<Intersection> intersections, Item resourceType, int rollNumber)
        {
            this.intersections = intersections;
            Resource = resourceType;
            RollNumber = rollNumber;
        }

        public List<Intersection> GetIntersections()
        {
            return intersections;
        }


        public List<ResourceRequest> DistributeDieRollResources(int dieVal)
        {
            return dieVal != RollNumber ? new List<ResourceRequest>() : DistributeInitialResources();
        }

        public List<ResourceRequest> DistributeInitialResources()
        {
            var requests = new List<ResourceRequest>();
            foreach (var intersection in intersections)
            {
                AddRequestForIntersection(intersection, requests);
            }

            return requests;
        }

        private void AddRequestForIntersection(Intersection intersection, ICollection<ResourceRequest> requests)
        {
            if (HasRobber || Resource == Desert)
            {
                return;
            }

            if (intersection.HasSettlement)
            {
                requests.Add(new ResourceRequest(intersection.GetOwner(), Resource, 1));
            }
            else if (intersection.HasCity)
            {
                requests.Add(new ResourceRequest(intersection.GetOwner(), Resource, 2));
            }
        }
    }
}