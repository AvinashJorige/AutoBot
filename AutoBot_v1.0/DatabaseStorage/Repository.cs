using System;
using System.Collections;
using System.Collections.Specialized;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Text;
using System.ComponentModel;
using Entities;

namespace DatabaseStorage
{
    public class Repository
    {
        private AutobotStorageDataContext _context;

        public Repository()
        {
            _context = new AutobotStorageDataContext();
        }


        // Get All the data
        public Autobot fetchIndexes(Autobot entities)
        {
            Autobot actionRst = new Autobot();
            try
            {
                actionRst = (from c in _context.AutobotDataSources
                             where c.Indexes.Equals(entities.Indexes)
                             select new Autobot {
                                 Action = c.Action
                             }).SingleOrDefault();
            }
            catch (Exception ex)
            {
                
            }
            return actionRst;
        }

        public void saveIndexesAction(Autobot entities)
        {
            try
            {
                AutobotDataSource _ds = new AutobotDataSource()
                {
                    Action = entities.Action,
                    Indexes = entities.Indexes,
                    ActionDates = DateTime.Now
                };

                _context.AutobotDataSources.InsertOnSubmit(_ds);
                _context.SubmitChanges();
            }
            catch (Exception ex)
            {

            }
        }
       
    }
}
