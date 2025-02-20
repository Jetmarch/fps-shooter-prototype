namespace HomeworkSaveLoad.SaveSystem
{
    public interface ISaveLoader
    {
        void SaveGame(IGameContext gameContext, IGameRepository gameRepository);
        void LoadGame(IGameContext gameContext, IGameRepository gameRepository);
    }
}