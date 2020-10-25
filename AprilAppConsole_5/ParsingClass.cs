using System;
using RestSharp;
using AngleSharp;
using AngleSharp.Html.Parser;
using AngleSharp.Html.Dom;
using AngleSharp.Dom;
using System.Linq;

namespace AprilAppConsole_5
{
    class ParsingClass: Product
    {
        public ParsingClass GetProduct(string url)
        {
            try
            {
                var client = new RestClient(url);
                var request = new RestRequest();
                var response = client.Get(request);

                IHtmlDocument parser = new HtmlParser().ParseDocument(response.Content);

                foreach (IElement element in parser.QuerySelectorAll("main").Where(item => item.ClassName != null && item.ClassName.Contains("v-product container")))
                {
                    foreach (IElement elem in element.QuerySelectorAll("section").Where(item => item.ClassName != null && item.ClassName.Contains("info")))
                    {
                        name = elem.QuerySelector("h1").TextContent;

                        foreach (IElement el in elem.QuerySelectorAll("li").Where(item => item.ClassName != null && item.ClassName.Contains("property")))
                        {
                            if (el.Children[0].TextContent == "Производитель")
                            {
                                foreach (IElement man in el.QuerySelectorAll("span").Where(item => item.ClassName != null && item.ClassName.Contains("search")))
                                {
                                    manufacturer = man.TextContent;
                                    break;
                                }
                            }
                        }
                        break;
                    }
                }

                foreach (IElement buyElement in parser.QuerySelectorAll("section").Where(item => item.ClassName != null && item.ClassName.Contains("buy")))
                {
                    discontPrice = float.Parse(buyElement.Children[0].Children[0].Children[1].TextContent.Remove(buyElement.Children[0].Children[0].Children[1].TextContent.Length - 2, 2));
                    price = float.Parse(buyElement.Children[0].Children[1].Children[1].TextContent.Remove(buyElement.Children[0].Children[1].Children[1].TextContent.Length - 2, 2));
                }

                return this;
            }
            catch(Exception ex)
            {
                Console.WriteLine($"\nПроизошла ошибка: \n{ex.Message}");
                return null;
            }
        }
    }
}
