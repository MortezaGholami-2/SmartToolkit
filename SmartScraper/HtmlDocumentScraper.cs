using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace GeniusSoft.GeniusMovieOrganizer_WPF.Library.Scrapers
{
    public class HtmlDocumentScraper
    {

        public static Task<HtmlDocument> GetHtmlDocumentByDocumentPathAsync(string documentPath)
        {
            return Task.Run(() => GetHtmlDocumentByDocumentPath(documentPath));
        }

        public static HtmlDocument GetHtmlDocumentByDocumentPath(string documentPath)
        {
            HtmlDocument document = new HtmlDocument();
            document.Load(documentPath);
            return document;
        }

        public static Task<HtmlDocument> GetHtmlDocumentByWebPageUrlAsync(string webPageUrl)
        {
            return Task.Run(() => GetHtmlDocumentByWebPageUrl(webPageUrl));
        }

        public static HtmlDocument GetHtmlDocumentByWebPageUrl(string webPageUrl)
        {
            //ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
            try
            {
                HtmlWeb web = new HtmlWeb();
                //web.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/34.0.1847.137 Safari/537.36";
                HtmlDocument document = web.Load(webPageUrl);
                return document;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static Task<HtmlDocument> GetHtmlDocumentByHtmlStringAsync(string html)
        {
            return Task.Run(() => GetHtmlDocumentByHtmlString(html));
        }

        public static HtmlDocument GetHtmlDocumentByHtmlString(string html)
        {
            HtmlDocument document = new HtmlDocument();
            document.LoadHtml(html);
            return document;
        }
    }
}
