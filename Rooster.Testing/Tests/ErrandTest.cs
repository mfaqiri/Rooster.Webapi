using System;
using Rooster.Domain.Models;
using Xunit;

namespace Rooster.Test
{
  public class EventTest
  {
    [Fact]
    public void ErrandCreation()
    {
      DateTime test = DateTime.Now;
      var sut = new Errand(test, "Test");
      Assert.True(sut.ErrandStart
        == test);
    }

    [Fact]
    public void FailSetEndTime()
    {
      DateTime end = DateTime.Now;
      DateTime start = DateTime.Now;
      var sut = new Errand(start, "Test");
      Assert.False(sut.SetEnd(end));
    }


  }
}
