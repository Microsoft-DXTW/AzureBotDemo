using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using AzureBotConversationHelper.Actions.IMPL;
using Newtonsoft.Json;

namespace AzureBotConversationHelper.Actions
{
    public class ActionFactory
    {
        private static string url = "https://api.projectoxford.ai/luis/v1/application?id=decdd292-13cc-4efb-bb8e-4cc5a4d6f11b&subscription-key=74e66a7b03ad4cd1ab1ee04b90734eea&q={0}";
        private static LUISResults ParseResult(string result)
        {
            if (!string.IsNullOrEmpty(result))
            {
                var luis = JsonConvert.DeserializeObject<LUISResults>(result);
                return luis;
            }
            return null;
        }
        private static IAction LUIS(string utterance)
        {
            var wc = new WebClient();
            using (var stream = wc.OpenRead(string.Format(url, utterance)))
            {
                using (var sr = new StreamReader(stream))
                {
                    var result = sr.ReadToEnd();
                    var luisResult = ParseResult(result);

                    if(luisResult.intents.Count == 0)
                    {
                        throw new ArgumentOutOfRangeException("Can't find proper intents");
                    }
                    var type = Type.GetType($"AzureBotConversationHelper.Actions.IMPL.{luisResult.intents[0].intent.Replace("$", "")}_Action");
                    IAction action = Activator.CreateInstance(type, new object[] { new string[] { (string)luisResult.entities[0].entity } }) as IAction;
                    
                    return action;

                }
            }

        }
        public static IAction FindAction(string message)
        {
            return LUIS(message);
        }
    }
}
