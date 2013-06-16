using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BlacksmithPress.Diabetes.WinRT.DesignTime;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;

namespace Tests
{
    [TestClass]
    public class MainPageViewModel_DesignTime
    {
        [TestMethod]
        public void Instantiation_creates_DailyTileViewModels()
        {
            // arrange

            // act
            var vm = new MainPageViewModel();

            // assert
            CollectionAssert.AllItemsAreInstancesOfType(vm.DailyTiles.ToList(), typeof (DailyTileViewModel));
            Assert.AreNotEqual(0, vm.DailyTiles.Count());
        }
    }
}
