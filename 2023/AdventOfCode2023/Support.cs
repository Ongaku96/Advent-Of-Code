namespace Support
{

    public abstract class Exercise
    {
        public Exercise()
        { }
        public abstract void Part1(bool test = true);
        public abstract void Part2(bool test = false);
    }

    public class Test<T, O>
    {
        public T input { get; set; }
        public O expected { get; set; }
    }
}