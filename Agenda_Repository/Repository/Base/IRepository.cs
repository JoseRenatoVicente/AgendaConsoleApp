namespace Agenda_Repository.Repository.Base
{
    public interface IRepository<TEntity>
    {
        TEntity[] GetAll();
        TEntity[] GetByName(string name);
        TEntity Add(TEntity entity);
        void Remove(int id);
    }
}
