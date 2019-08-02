using Diabetes.Models;
using FluentAssertions;
using Xunit;

namespace Tests.Models
{
    public class Users
    {
        [Fact]
        public void NewUser_InitializesNames()
        {
            // arrange

            // act
            var actual = new User();

            // assert
            actual.Name.Should().NotBeNull("the Name should be constructed when the User is initialized");
            actual.Name.First.Should().NotBeNull("the names should be initialized to an empty string");
            actual.Name.Middle.Should().NotBeNull("the names should be initialized to an empty string");
            actual.Name.Last.Should().NotBeNull("the names should be initialized to an empty string");
        }
    }
}
