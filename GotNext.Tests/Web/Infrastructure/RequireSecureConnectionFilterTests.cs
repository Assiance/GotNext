using System;
using System.Collections.Specialized;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

using GotNext.Web.Infrastructure.Security;

using NSubstitute;

using NUnit.Framework;

namespace GotNext.Tests.Web.Infrastructure
{
    [TestFixture]
    public class RequireSecureConnectionFilterTests
    {
        private readonly HttpRequestBase _request;
        private readonly AuthorizationContext _filterContext;
        private readonly RequireSecureConnectionFilter _filter;

        public RequireSecureConnectionFilterTests()
        {
            var @params = new NameValueCollection();
            var responseHeaders = new NameValueCollection();

            _request = Substitute.For<HttpRequestBase>();
            _request.Params.Returns(@params);

            var response = Substitute.For<HttpResponseBase>();
            response.Headers.Returns(responseHeaders);

            var context = Substitute.For<HttpContextBase>();
            context.Request.Returns(_request);
            context.Response.Returns(response);

            var controller = Substitute.For<ControllerBase>();

            var actionDescriptor = Substitute.For<ActionDescriptor>();
            var controllerContext = new ControllerContext(context, new RouteData(), controller);
            _filterContext = new AuthorizationContext(controllerContext, actionDescriptor);

            _filter = new RequireSecureConnectionFilter();
        }

        [Test]
        public void Should_ThrowException_When_AuthorizationHasNoContext()
        {
            Assert.Throws<ArgumentNullException>(() => _filter.OnAuthorization(null));
        }

        [Test]
        public void Should_NotRedirectToHTTPS_When_RequestIsLocal()
        {
            //Arrange
            _request.IsLocal.Returns(true);

            // Act
            _filter.OnAuthorization(_filterContext);

            // Assert - checking if we are not being redirected
            var redirectResult = _filterContext.Result as RedirectResult;
            Assert.Null(redirectResult);    
        }

        [Test]
        public void Should_RedirectToHTTPS_When_RequestIsNotLocal()
        {
            //Arrange
            _request.IsLocal.Returns(false);

            // Act && Assert 
            // here we check if controll is passed down to RequireHttpsAttribute code
            // and we are not testing for Microsoft code.
            Assert.Throws<InvalidOperationException>(() => _filter.OnAuthorization(_filterContext));
        }
    }
}