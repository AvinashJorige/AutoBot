using ServiceLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entities;

namespace AutoBot_v1._0
{
    public partial class AutobotTest_1 : System.Web.UI.Page
    {
        private static ActionService _service;
        public AutobotTest_1()
        {
            _service = new ActionService();
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static object ActionInTake(string intakeContent)
        {
            IndexesObj _indexesObj = new IndexesObj();
            var obj = new { status = 400, message = string.Empty, value = new IndexesObj() };


            Autobot _autobot = new Autobot();
            _autobot.Indexes = intakeContent;
            // check in the database for the user input: 
            // If no result gets then insert it as new action/
            // Else fetch the action for the indexes and then return.
            _autobot = _service.GetActionByAction(_autobot);
            if (_autobot != null && !string.IsNullOrEmpty(_autobot.Action))
            {
                _indexesObj.Indexes = string.Empty;
                _indexesObj.returnValue = _autobot.Action;

                // If there is a action to return then call the speech return function.
                obj = new { status = 200, message = "valid", value = _indexesObj };
            }
            else
            {
                _indexesObj.Indexes = intakeContent;
                _indexesObj.returnValue = "Sorry ! I don't know what you say. Can you tell me, what should i say for it.";

                // If no action is to return then insert the indexes with proper action.
                obj = new { status = 400, message = "fails", value = _indexesObj };
            }
            return obj;
        }

        [WebMethod]
        public static object UserActionSave(IndexesObj response)
        {
            var obj = new { status = 400, message = string.Empty, value = new IndexesObj() };

            try
            {
                Autobot _autobot = new Autobot();
                _autobot.Indexes = response.Indexes;
                _autobot.Action = response.ActionResponse;
                _service.InsertAction(_autobot);

                response.returnValue = "Sure Buddy...";

                obj = new { status = 200, message = "valid", value = response };
            }
            catch (Exception ex)
            {

            }
            return obj;
        }
    }
}