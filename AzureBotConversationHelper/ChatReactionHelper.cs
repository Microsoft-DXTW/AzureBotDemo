using AzureBotConversationHelper.Actions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace AzureBotConversationHelper
{
    public class ChatReactionHelper
    {
        public static IAction FindAction(string message)
        {
            return ActionFactory.FindAction(message);
        }
    }
}
