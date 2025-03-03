using HomeworkSaveLoad.SaveSystem;
using VContainer;

namespace FPSShooter.Game.Core.SaveLoaders
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public class VContainerGameContext : IGameContext
    {
        private readonly IObjectResolver _resolver;
        
        public VContainerGameContext(IObjectResolver resolver)
        {
            _resolver = resolver;
        }
        
        public T GetService<T>()
        {
            return _resolver.Resolve<T>();
        }
    }
}