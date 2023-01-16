using Data;

namespace Infrastructure.Services.PersistentProgress.PersistentProgressService
{
    public interface ISavedProgressReader
    {
        void LoadProgress(PlayerProgress progressServiceProgress);
    }

    public interface ISavedProgress : ISavedProgressReader
    {
        void UpdateProgress(PlayerProgress progress);
    }
}