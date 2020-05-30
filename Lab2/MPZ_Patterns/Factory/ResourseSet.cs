namespace MPZ_Patterns.Factory
{

    public class ResourseSet
    {
        public enum ResourceType
        {
            Powder,
            Cannonshot,
            GoldCoin,
            SilverCoin
        }

        public ResourseSet(int powder, int cannonshot, int goldCoin, int silverCoin)
        {
            Powder = powder;
            Cannonshot = cannonshot;
            GoldCoin = goldCoin;
            SilverCoin = silverCoin;
        }

        public int Powder { get; set; }
        public int Cannonshot { get; set; }
        public int GoldCoin { get; set; }
        public int SilverCoin { get; set; }
    }
}