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
            var Event = new Event(DateTime.Now);
            var sut = new User("email", "password");
            sut.addEvent(Event);
            Assert.False(sut.addEvent(Event));
        }

        
    }
}
