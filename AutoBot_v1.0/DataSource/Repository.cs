using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataSource
{
    public class Repository : IRepository
    {
        #region -- connection

        private DatabaseContextDataContext _dataContext;

        public Repository()
        {
            _dataContext = new DatabaseContextDataContext();
        }

        #endregion

        #region -- actions -- 

        public List<Autobot> GetAllAction()
        {
            List<Autobot> actionList = new List<Autobot>();
            var query = from action1 in _dataContext.Data1s
                        select action1;
            var action = query.ToList();
            foreach (var actionData in action)
            {
                actionList.Add(new Autobot()
                {
                    Id = actionData.Id,
                    Action = actionData.Action,
                    Indexes = actionData.Indexes,
                    ActionDate = actionData.ActionDate
                });
            }
            return actionList;
        }
        public Autobot GetActionById(int actionId)
        {
            var query = from u in _dataContext.Data1s
                        where u.Id == actionId
                        select u;
            var actionData = query.FirstOrDefault();
            var model = new Autobot()
            {
                Id = actionId,
                Action = actionData.Action,
                Indexes = actionData.Indexes,
                ActionDate = actionData.ActionDate
            };
            return model;
        }


        public Autobot GetActionByAction(string action)
        {
            var query = from u in _dataContext.Data1s
                        where u.Action == action
                        select u;
            var actionData = query.FirstOrDefault();
            var model = new Autobot()
            {
                Id = actionData.Id,
                Indexes = actionData.Indexes,
                Action = actionData.Action,
                ActionDate = actionData.ActionDate
            };
            return model;
        }

        public void InsertAction(Autobot action)
        {
            var actionData = new Data1()
            {
                Id = action.Id,
                Action = action.Action,
                Indexes = action.Indexes,
                ActionDate = DateTime.Now
            };
            _dataContext.Data1s.InsertOnSubmit(actionData);
            _dataContext.SubmitChanges();
        }
        public void DeleteAction(int actionId)
        {
            Data1 action = _dataContext.Data1s.Where(u => u.Id == actionId).SingleOrDefault();
            _dataContext.Data1s.DeleteOnSubmit(action);
            _dataContext.SubmitChanges();
        }
        public void UpdateAction(Autobot action)
        {
            Data1 actionData = _dataContext.Data1s.Where(u => u.Id == action.Id).SingleOrDefault();
            actionData.Id = action.Id;
            actionData.Action = action.Action;
            actionData.ActionDate = DateTime.Now;
            actionData.Indexes = action.Indexes;
            _dataContext.SubmitChanges();
        }

        #endregion

    }
}
