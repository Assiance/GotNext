//using GotNext.Domain.Managers.Interfaces;
//using GotNext.Web.Infrastructure.Tasks;

//namespace GotNext.Web
//{
//    public class SeedData : IRunAtStartup
//    {
//        private readonly IMemberManager _memberManager;

//        public SeedData(IMemberManager memberManager)
//        {
//            //Todo: Recode this to use the repositories
//            //Todo: Create SeedData for other Context
//            _memberManager = memberManager;
//        }

//        //CREATE SEED-MANAGER
//        public void Execute()
//        {
//            //var passwordHash = new PasswordHasher();
//            //string password = passwordHash.HashPassword("test");
//            //if (!_memberManager.Users.Any())
//            //{
//            //    _memberManager.CreateUser(new User()
//            //    {
//            //        UserName = "TestUser",
//            //        Email = "Foo@Test.com",
//            //        EmailConfirmed = true,
//            //        PasswordHash = password
//            //    });
//            //}
//        }
//    }
//}