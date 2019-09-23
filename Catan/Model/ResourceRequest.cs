namespace Catan.Model
{

    public struct ResourceRequest
    {
        public ResourceRequest(Player player, Item resource, int amt)
        {
            Player = player;
            Resource = resource;
            Amount = amt;
        }

        public readonly Player Player;
        public readonly Item Resource;
        public readonly int Amount;
    }
}
