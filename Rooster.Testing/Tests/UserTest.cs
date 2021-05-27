using System;
using Rooster.Domain.Models;
using Xunit;

namespace Rooster.Test
{
  public class UserTest
  {
    [Fact]
    public void UserConstructor()
    {
      var email = "email";
      var password = "password";
      var sut = new User(email, password);
      Assert.True(sut.Email == email && sut.Password == password);
    }

    [Fact]
    public void DuplicateEvents()
    {
      var errand = new Errand(DateTime.Now, "Test");
      var sut = new User("email", "password");
      sut.addErrand(errand);
      Assert.False(sut.addErrand(errand));
    }
  }
}
