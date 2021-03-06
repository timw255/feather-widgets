﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using FeatherWidgets.TestUtilities.CommonOperations;
using Telerik.Sitefinity.Frontend.TestUtilities.CommonOperations;
using Telerik.Sitefinity.TestUI.Arrangements.Framework;
using Telerik.Sitefinity.TestUI.Arrangements.Framework.Attributes;
using Telerik.Sitefinity.TestUtilities.CommonOperations;

namespace FeatherWidgets.TestUI.Arrangements
{
    /// <summary>
    /// Arrangement methods for VerifySearchResults_BootstrapTemplate
    /// </summary>
    public class VerifySearchResults_BootstrapTemplate : ITestArrangement
    {
        /// <summary>
        /// Server side set up.
        /// </summary>
        [ServerSetUp]
        public void SetUp()
        {
            ServerOperations.News().CreateNewsItem(NewsTitle1);
            ServerOperations.News().CreateNewsItem(NewsTitle2);

            Guid searchIndexId = ServerOperations.Search().CreateSearchIndex(SearchIndexName, new[] { SearchContentType.News });
            ServerOperations.Search().Reindex(searchIndexId);

            Guid templateId = ServerOperationsFeather.TemplateOperations().GetTemplateIdByTitle(PageTemplateName);
            ServerOperations.Pages().CreatePage(SearchPageTitle, templateId);
            Guid newsPageId = ServerOperations.Pages().CreatePage(NewsPageTitle);
            ServerOperationsFeather.Pages().AddNewsWidgetToPage(newsPageId);
        }

        /// <summary>
        /// Tears down.
        /// </summary>
        [ServerTearDown]
        public void TearDown()
        {
            ServerOperations.Pages().DeleteAllPages();
            ServerOperations.Search().DeleteAllIndexes();
            ServerOperations.News().DeleteAllNews();
        }

        private const string SearchIndexName = "news index";
        private const string NewsTitle1 = "test news";
        private const string NewsTitle2 = "another news";
        private const string SearchPageTitle = "BootstrapPage";
        private const string PageTemplateName = "Bootstrap.default";
        private const string NewsPageTitle = "NewsPage";
    }
}
