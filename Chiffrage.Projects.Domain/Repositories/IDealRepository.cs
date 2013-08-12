using System.Collections.Generic;

namespace Chiffrage.Projects.Domain.Repositories
{
    public interface IDealRepository
    {
        Deal FindById(int dealId);

        IList<Deal> FindAll();

        void Save(Deal deal);

        void Delete(Deal deal);
    }
}