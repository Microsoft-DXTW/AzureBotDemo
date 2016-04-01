using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AzureBotConversationHelper.Actions
{
    public class SearchEngineAction : ActionBase
    {
        private string [] queryTexts = null;
        public SearchEngineAction(string [] queries):base(queries)
        {
            queryTexts = queries;
        }


        public override string DoAction(string request)
        {
            string url = $"http://www.google.com.tw/search?hl=zh-TW&q={queryTexts[0]}";
            var wc = new WebClient();
            using (var stream = wc.OpenRead(url))
            {
                using (var sr = new StreamReader(stream))
                {
                    var html = sr.ReadToEnd();
                    var matches = Regex.Matches(html, "<a class=\"fl\" href=[\"](?<href>.+?)[\"].+?>");
                    if(matches.Count > 0)
                    {
                        var sb = new StringBuilder();
                        foreach(Match match in matches)
                        {
                            sb.Append(match.Value).Append(Environment.NewLine);
                        }

                        return sb.ToString();
                    }
                }
            }
            return null;
        }
    }
}
