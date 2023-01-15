using Data;

namespace Infrastructure.Services.PersistentProgress.PersistentProgressService
{
    public interface IPersistentProgressService : IService
    {
        PlayerProgress Progress { get; set; }
    }
}