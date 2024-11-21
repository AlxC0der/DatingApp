using System;
using System.Collections.Generic;
using System.Text.Json;
using API.DTOs;
using Xunit;

namespace API.UnitTests.DTOs
{
    public class MemberResponseTests
    {
        [Fact]
        public void MemberResponse_ShouldInitializeWithDefaultValues()
        {
            // Arrange & Act
            var member = new MemberResponse();

            // Assert
            Assert.Equal(0, member.Id);
            Assert.Null(member.UserName);
            Assert.Equal(0, member.Age);
            Assert.Null(member.PhotoUrl);
            Assert.Null(member.KnownAs);
            Assert.Equal(default(DateTime), member.Created);
            Assert.Equal(default(DateTime), member.LastActive);
            Assert.Null(member.Gender);
            Assert.Null(member.Introduction);
            Assert.Null(member.Interests);
            Assert.Null(member.LookingFor);
            Assert.Null(member.City);
            Assert.Null(member.Country);
            Assert.Null(member.Photos);
        }

        [Fact]
        public void MemberResponse_ShouldAllowPropertyAssignment()
        {
            // Arrange
            var photos = new List<PhotoResponse>
            {
                new PhotoResponse { Id = 1, Url = "http://example.com/photo1.jpg", IsMain = true },
                new PhotoResponse { Id = 2, Url = "http://example.com/photo2.jpg", IsMain = false }
            };

            var createdDate = DateTime.Now;
            var lastActiveDate = DateTime.Now.AddMinutes(-30);

            // Act
            var member = new MemberResponse
            {
                Id = 1,
                UserName = "TestUser",
                Age = 25,
                PhotoUrl = "http://example.com/photo.jpg",
                KnownAs = "Tester",
                Created = createdDate,
                LastActive = lastActiveDate,
                Gender = "Male",
                Introduction = "Hello, I am a test user.",
                Interests = "Testing, Coding",
                LookingFor = "Friends",
                City = "TestCity",
                Country = "TestCountry",
                Photos = photos
            };

            // Assert
            Assert.Equal(1, member.Id);
            Assert.Equal("TestUser", member.UserName);
            Assert.Equal(25, member.Age);
            Assert.Equal("http://example.com/photo.jpg", member.PhotoUrl);
            Assert.Equal("Tester", member.KnownAs);
            Assert.Equal(createdDate, member.Created);
            Assert.Equal(lastActiveDate, member.LastActive);
            Assert.Equal("Male", member.Gender);
            Assert.Equal("Hello, I am a test user.", member.Introduction);
            Assert.Equal("Testing, Coding", member.Interests);
            Assert.Equal("Friends", member.LookingFor);
            Assert.Equal("TestCity", member.City);
            Assert.Equal("TestCountry", member.Country);
            Assert.NotNull(member.Photos);
            Assert.Equal(2, member.Photos.Count);
        }

        [Fact]
        public void MemberResponse_ShouldSerializeToJson()
        {
            // Arrange
            var member = new MemberResponse
            {
                Id = 1,
                UserName = "TestUser",
                Age = 25,
                PhotoUrl = "http://example.com/photo.jpg",
                KnownAs = "Tester",
                Created = DateTime.UtcNow,
                LastActive = DateTime.UtcNow.AddMinutes(-30),
                Gender = "Male",
                Introduction = "Hello, I am a test user.",
                Interests = "Testing, Coding",
                LookingFor = "Friends",
                City = "TestCity",
                Country = "TestCountry",
                Photos = new List<PhotoResponse>
                {
                    new PhotoResponse { Id = 1, Url = "http://example.com/photo1.jpg", IsMain = true }
                }
            };

            // Act
            var json = JsonSerializer.Serialize(member);

            // Assert
            Assert.NotNull(json);
            Assert.Contains("\"UserName\":\"TestUser\"", json);
            Assert.Contains("\"Photos\":[", json);
        }

    }
}
