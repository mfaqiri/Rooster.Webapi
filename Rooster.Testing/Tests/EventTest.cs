using System;
using Xunit;
using Rooster.Domain.Models;

namespace Rooster.Test
{
    public class EventTest
    {
        [Fact]
        public void EventCreation()
        {
            DateTime test = DateTime.Now;
            var sut = new Event(test);
            Assert.True(sut.EventStart
              == test);
        }

        [Fact]
        public void FailSetEndTime()
        {
            DateTime end = DateTime.Now;
            DateTime start = DateTime.Now;
            var sut = new Event(start);
            Assert.False(sut.SetEnd(end));
        }


    }
}
