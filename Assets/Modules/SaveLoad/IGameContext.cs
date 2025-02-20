namespace HomeworkSaveLoad.SaveSystem
{
    public interface IGameContext
    {
        T GetService<T>();
    }
}