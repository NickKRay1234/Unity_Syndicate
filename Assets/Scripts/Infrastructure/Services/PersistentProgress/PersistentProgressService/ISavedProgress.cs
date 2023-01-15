using Data;

namespace Infrastructure.Services.PersistentProgress.PersistentProgressService
{
    public interface ISavedProgressReader
    {
        void UpdateProgress(PlayerProgress progress);
    }

    public interface ISavedProgress : ISavedProgressReader
    {
        void LoadProgress(PlayerProgress progress);
    }
}