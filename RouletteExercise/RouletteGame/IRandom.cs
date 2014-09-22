namespace RouletteGame
{
    public interface IRandomize
    {
        int RandomInt(int from, int to);
    }

    public class Randomize : IRandomize
    {
        public int RandomInt(int from, int to)
        {
            var n = (int)new System.Random().Next(from, to);
            return n;
        }
    }
}