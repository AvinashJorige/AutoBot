using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseStorage;
using Entities;

namespace ServiceLogic
{
    public class ActionService
    {

        private Repository _repo;
        
        public ActionService()
        {
            _repo = new Repository();
        }

        public Autobot GetActionByAction(Autobot action)
        {
            Autobot _autobot = new Autobot();
            try
            {
                _autobot = _repo.fetchIndexes(action);
            }
            catch (Exception ex)
            {
                _autobot.Except = ex.Message;
                return _autobot;
            }

            return _autobot;
        }

        public Autobot InsertAction(Autobot autobot)
        {
            Autobot _autobot = new Autobot();
            try
            {
                 _repo.saveIndexesAction(autobot);
            }
            catch (Exception ex)
            {
                _autobot.Except = ex.Message;
                return _autobot;
            }

            return _autobot;
        }
    }
}
