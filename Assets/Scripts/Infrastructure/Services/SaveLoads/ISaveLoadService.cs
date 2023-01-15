using Data;

namespace Infrastructure.Services.SaveLoads
{
    public interface ISaveLoadService : IService
    {
        void SaveProgress();
        PlayerProgress LoadProgress();
    }
}