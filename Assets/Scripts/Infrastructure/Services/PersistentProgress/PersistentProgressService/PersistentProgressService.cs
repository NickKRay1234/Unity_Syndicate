using Data;

namespace Infrastructure.Services.PersistentProgress.PersistentProgressService
{
    public class PersistentProgressService : IPersistentProgressService
    {
        public PlayerProgress Progress { get; set; }
    }
}