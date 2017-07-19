using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataSource
{
    public interface IRepository
    {
        List<Autobot> GetAllAction();
        Autobot GetActionById(int actionId);
        void InsertAction(Autobot action);
        void DeleteAction(int actionId);
        void UpdateAction(Autobot action);
        Autobot GetActionByAction(string action);
    }
}
