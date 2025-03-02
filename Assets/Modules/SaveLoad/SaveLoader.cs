namespace HomeworkSaveLoad.SaveSystem
{
    public abstract class SaveLoader<TData, TService> : ISaveLoader
    {
        public void SaveGame(IGameContext gameContext, IGameRepository gameRepository)
        {
            var service = gameContext.GetService<TService>();
            var data = ConvertToData(service);
            gameRepository.SetData(data);
        }


        public void LoadGame(IGameContext gameContext, IGameRepository gameRepository)
        {
            if (!gameRepository.TryGetData(out TData data))
            {
                return;
            }
            
            var service = gameContext.GetService<TService>();
            SetupData(service, data);
        }

        protected abstract void SetupData(TService service, TData data);

        protected abstract TData ConvertToData(TService service);
    }
}