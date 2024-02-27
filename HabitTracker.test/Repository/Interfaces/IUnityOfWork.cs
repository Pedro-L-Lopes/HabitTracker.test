// Extrair e agrupar as informações relacionadas aos repositórios e fazer a persistencia

namespace HabitTracker.test.Repository.Interfaces;
public interface IUnityOfWork
{
    IHabitRepository HabitRepository { get; }
    Task Commit();
}
