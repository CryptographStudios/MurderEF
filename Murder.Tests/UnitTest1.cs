using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Murder.Tests
{
	[TestClass]
	public class DBUnitTests
	{
		[TestMethod]
		public void TestUser()
		{
			using (var context = new ItsOnlyHeroesEntities())
			{
				var expectedUserName = "Will";
				var heroUser = context.Users.Find(1);

				Assert.AreEqual(expectedUserName, heroUser.UserName);				
			}
		}
	}
}
