using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Murder.Tests
{
	[TestClass]
	public class DBUnitTests
	{
		[TestMethod]
		public void TestGetUser()
		{
			using (var context = new ItsOnlyHeroesEntities())
			{
				var expectedUserName = "Matt";
				var heroUser = context.Users.Find(1);

				Assert.AreEqual(expectedUserName, heroUser.UserName);				
			}
		}

        [TestMethod]
        public void TestAddUser()
        {
            User newUser = new User();

            newUser.Active = true;
            newUser.DisplayName = "MCubed";
            newUser.LastLogin = DateTime.UtcNow;
            newUser.UserName = "Matt";

            using (var context = new ItsOnlyHeroesEntities())
            {
                var heroUser = context.Users.Add(newUser);
                context.SaveChanges();
                Assert.IsNotNull(heroUser.UserId);
                Assert.IsTrue(heroUser.UserId > 0);
            }
        }
    }

   
}
