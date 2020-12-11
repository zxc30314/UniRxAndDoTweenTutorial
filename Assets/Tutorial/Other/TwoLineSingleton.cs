namespace NinjaCode
{
    public class TwoLineSingleton
    {
        private static TwoLineSingleton instance;
        public static TwoLineSingleton Instance => instance = instance ?? new TwoLineSingleton();
    }
}
