using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MovieDbLite.MVC.Models;
using MovieDbLite.MVC.Profiles;
using MovieDbLite.MVC.ViewModels;

namespace MovieDbLite.MvcTest
{
    [TestClass]
    public class AwardProfileTests
    {
        private IMapper Mapper { get; set; }

        [TestInitialize]
        public void Initialize()
        {
            Mapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AwardProfile());
            }).CreateMapper();
        }

        [TestMethod]
        public void AwardProfile_WillMapCorrectly_WhenAwardShowNameFilledIn()
        {
            var award = new Award()
            {
                Id = 5,
                AwardName = "Foo Bar",
                AwardShowId = 30,
                Description = "An award description",
                AwardShow = new AwardShow()
                {
                    Id = 1,
                    ShowName = "Test Show Name"
                }
            };

            var viewModel = Mapper.Map<AwardViewModel>(award);

            Assert.AreEqual(award.Id, viewModel.Id);
            Assert.AreEqual(award.AwardName, viewModel.AwardName);
            Assert.AreEqual(award.AwardShowId, viewModel.AwardShowId);
            Assert.AreEqual(award.Description, viewModel.Description);
            Assert.AreEqual(award.AwardShow.ShowName, viewModel.AwardShowName);
            Assert.AreEqual(viewModel.FriendlyName, "Foo Bar (Test Show Name)");
        }

        public void AwardProfile_WillMapCorrectly_WhenAwardShowNameIsNotFilledIn()
        {
            var award = new Award()
            {
                Id = 5,
                AwardName = "Foo Bar",
                AwardShowId = 30,
                Description = "An award description",
                AwardShow = null
            };

            var viewModel = Mapper.Map<AwardViewModel>(award);

            Assert.AreEqual(award.Id, viewModel.Id);
            Assert.AreEqual(award.AwardName, viewModel.AwardName);
            Assert.AreEqual(award.AwardShowId, viewModel.AwardShowId);
            Assert.AreEqual(award.Description, viewModel.Description);
            Assert.AreEqual(null, viewModel.AwardShowName);
            Assert.AreEqual(viewModel.FriendlyName, "Foo Bar");
        }
    }
}
