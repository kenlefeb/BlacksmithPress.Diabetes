using Bogus;
using Bogus.Extensions;
using Diabetes.Models;
using FluentAssertions;
using System;
using Xunit;

namespace Tests.Models
{
    public class Users
    {
        private static Random _seed = new Random(2435407);
        private Faker<Name> _faker;

        public Users()
        {
            Randomizer.Seed = _seed;
            _faker = new Faker<Name>()
                .RuleFor(n => n.First, f => f.Name.FirstName())
                .RuleFor(n => n.Middle, m => m.Name.FirstName().OrNull(m))
                .RuleFor(n => n.Last, l => l.Name.LastName());
        }

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

        [Theory]
        [InlineData("John", "Q", "Public", "John Q. Public")]
        [InlineData("John ", "Q", "Public", "John Q. Public")]
        [InlineData("John", "Q ", "Public", "John Q. Public")]
        [InlineData("John", "Q", "Public ", "John Q. Public")]
        public void CastNameToString_ConcatenatesFirstMiddleLast(string first, string middle, string last, string expected)
        {
            // arrange isolation

            // arrange test
            var subject = new Name
            {
                First = first,
                Middle = middle,
                Last = last
            };

            // act
            var actual = $"{subject}";

            // assert
            actual.Should().Be(expected);

            // clean-up
        }

        [Fact]
        public void Equality_UsesAllThreeNames()
        {
            // arrange isolation

            // arrange test
            var name1 = _faker.Generate();
            var name2 = new Name
            {
                First = name1.First,
                Middle = name1.Middle,
                Last = name1.Last
            };

            // act
            var actual = (Equals(name1, name2));

            // assert
            actual.Should().BeTrue();

            // clean-up
        }

        [Fact]
        public void Inequality_UsesAllThreeNames()
        {
            // arrange isolation

            // arrange test
            var name1 = _faker.Generate();
            var name2 = _faker.Generate();

            // act
            var actual = (name1 == name2);

            // assert
            actual.Should().BeFalse();

            // clean-up
        }

        [Fact]
        public void GetHashCode_UsesAllThreeNames()
        {
            // arrange isolation

            // arrange test
            var name = _faker.Generate();
            var expected = name.ToString().GetHashCode();

            // act
            var actual = name.GetHashCode();

            // assert
            actual.Should().Be(expected);

            // clean-up
        }
    }
}