using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureBotConversationHelper.Actions
{
    public class EchoAction : IAction
    {
        public string DoAction(string request)
        {
            return "I hear you said :" + request;
        }
    }
}
