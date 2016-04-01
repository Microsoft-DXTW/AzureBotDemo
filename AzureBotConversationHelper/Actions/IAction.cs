using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureBotConversationHelper.Actions
{
    public interface IAction
    {
        string DoAction(string request);
    }

    public abstract class ActionBase : IAction
    {
        public ActionBase (string [] queries) { }

        public abstract string DoAction(string request);
    }
}
