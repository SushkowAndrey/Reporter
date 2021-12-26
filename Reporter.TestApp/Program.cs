using System;
using System.Diagnostics;
using System.IO;
using Reporter.Lib;

namespace Reporter.TestApp
{
    internal static class Program
    {
        private static void Main()
        {
            using var input = new StreamReader("test.json");
            var json = input.ReadToEnd();

            IParser parser = new JsonParser();
            IGenerator generator = new GeneratorHtml();

            var html = generator.Generator(parser.Parsing(json));

            using var output = new StreamWriter("test.html", append: false);
            output.Write(html);
        }
    }
}