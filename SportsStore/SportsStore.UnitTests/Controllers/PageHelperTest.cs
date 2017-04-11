using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SportsStore.WebUI.HtmlHelpers;
using SportsStore.WebUI.Models;

namespace SportsStore.UnitTests.Controllers
{
   
   partial class HomeControllerTest
    {
        [TestMethod]
        public void Can_Paginate1()
        {
            // Arrange - define an HTML helper - we need to do this
            // in order to apply the extension method
            // Arrange - create PagingInfo data
            PagingInfo pagingInfo = new PagingInfo
            {
                CurrentPage = 2,
                TotalItems = 28,
                ItemsPerPage = 10
            };
            // Arrange - set up the delegate using a lambda expression
            Func<int, string> pageUrlDelegate = i => "Page" + i;
            // Act
            MvcHtmlString result = ((HtmlHelper) null).PageLinks(pagingInfo, pageUrlDelegate);
            // Assert
            Assert.AreEqual(result.ToString(), @"<a href=""Page1"">1</a>"
            + @"<a class=""selected"" href=""Page2"">2</a>"
            + @"<a href=""Page3"">3</a>");
        }
    }
}
