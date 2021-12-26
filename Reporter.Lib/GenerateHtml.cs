using System;
using System.Text;
using Reporter.Lib.Dom;

namespace Reporter.Lib
{
    public class GeneratorHtml : IGenerator
    {
        public string Generator(Dom.Dom dom)
        {
            var output = new StringBuilder();

            output.Append(CreateHeadHtml());
            
            foreach (var element in dom.GetDom())
            {
                output.Append(ParseElement(element));
            }

            output.Append(CreateFooterHtml());

            return output.ToString();
        }

        private string ParseElement(Element element)
        {
            return element.Key switch
            {
                "header" => CreateHeader(element.Value),
                "paragraph" => CreateParagraph(element.Value),
                "important" => CreateImportant(element.Value),
                _ => string.Empty
            };
        }

        private string CreateHeader(string value)
        {
            return $"<h1 class=\"header\">{value}</h1>";
        }
        
        private string CreateParagraph(string value)
        {
            return $"<p class=\"paragraph\">{value}</p>";
        }
        
        private string CreateImportant(string value)
        {
            return $"<p class=\"important\">{value}</p>";
        }

        private string CreateHeadHtml()
        {
            var html = new StringBuilder();

            html.Append("<!DOCTYPE html>");
            html.Append("<html lang=\"ru\">");
            html.Append("<head>");
            html.Append("<meta charset=\"UTF-8\">");
            html.Append("<meta http-equiv=\"X-UA-Compatible\" content=\"IE=edge\">");
            html.Append("<meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\">");
            html.Append("<title>ReporterGenerator</title>");
            html.Append("<link rel=\"stylesheet\" href=\"normalize.css\">");
            html.Append("<link rel=\"stylesheet\" href=\"defaults.css\">");
            html.Append("</head>");
            html.Append("<body>");

            return html.ToString();
        }

        private string CreateFooterHtml()
        {
            var html = new StringBuilder();

            html.Append("</body>");
            html.Append("</html>");
            
            return html.ToString();
        }
    }
}