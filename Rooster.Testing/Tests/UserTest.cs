using System;
using Xunit;
using Rooster.Domain.Models;

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
            var errand = new Errand(DateTime.Now);
            var sut = new User("email", "password");
            sut.addErrand(errand);
            Assert.False(sut.addErrand(errand));
        }

        
    }
}
