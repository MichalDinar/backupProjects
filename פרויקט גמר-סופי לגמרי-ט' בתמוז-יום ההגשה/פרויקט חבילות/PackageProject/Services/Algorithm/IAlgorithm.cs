namespace Services.Algoritm
{
    public interface IAlgorithm
    {
        //יש פעמים-בפרויקט אלגוריתם וכאן
        Task<int> RunningTheAlgorithm(DateTime open, DateTime close);
    }
    public class MyDay
    {
        public DateTime Open { get; set; }
        public DateTime Close { get; set; }
    }
}