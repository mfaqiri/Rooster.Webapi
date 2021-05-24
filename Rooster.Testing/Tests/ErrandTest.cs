using System;
using Xunit;
using Rooster.Domain.Models;

namespace Rooster.Test
{
    public class EventTest
    {
        [Fact]
        public void ErrandCreation()
        {
            DateTime test = DateTime.Now;
            var sut = new Errand(test);
            Assert.True(sut.ErrandStart
              == test);
        }

        [Fact]
        public void FailSetEndTime()
        {
            DateTime end = DateTime.Now;
            DateTime start = DateTime.Now;
            var sut = new Errand(start);
            Assert.False(sut.SetEnd(end));
        }


    }
}
