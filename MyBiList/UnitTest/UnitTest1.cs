using System;
using Xunit;
using MyBiList.ViewModel;

namespace UnitTest
{
    public class UnitTest1
    {
        [Fact]
        public  void Test1()
        {
            var vm = new EnterBiListViewModel();
            vm.Name = null;


        }
    }
}
