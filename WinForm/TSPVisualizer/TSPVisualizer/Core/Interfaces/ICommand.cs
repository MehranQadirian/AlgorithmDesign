namespace TSPVisualizer.Core.Interfaces
{
    public interface ICommand
    {
        void Execute();      // اجرا
        void Undo();         // خنثی‌سازی
    }
}
