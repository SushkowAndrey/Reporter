using System.Text.Json;

namespace Reporter.Lib
{
    public class JsonParser : IParser
    {
        public Dom.Dom Parsing(string str)
        {
            var dom = new Dom.Dom();
            
            var jsonDoc = JsonDocument.Parse(str);
            var root = jsonDoc.RootElement;

            var elements = root.EnumerateObject();
            foreach (var element in elements)
            {
                dom.Add(element.Name, element.Value.GetString());
            }

            return dom;
        }
    }
}