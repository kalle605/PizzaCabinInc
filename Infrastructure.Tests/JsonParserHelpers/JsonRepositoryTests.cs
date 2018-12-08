using Microsoft.VisualStudio.TestTools.UnitTesting;
using PizzaCabinInc.Infrastructure.JsonParserHelpers;

namespace PizzaCabinIncTests.InfrastructureTests.JsonParserHelpers
{
	[TestClass]
	public class JsonRepositoryTests
	{
		private const string Url = "http://pizzacabininc.azurewebsites.net/PizzaCabinInc.svc/schedule/2015-12-14";
		private JsonRepository respository;

		[TestInitialize]
		public void TestInitialize()
		{
			this.respository = new JsonRepository();
		}

		[TestMethod]
		public void ShouldBeAbleToParse()
		{
			var response = this.respository.Get(Url);

			Assert.IsNotNull(response);
		}
	}
}
