using System;
using System.Threading;
using NExpect;
using NUnit.Framework;
using static NExpect.Expectations;

namespace TDD101.Workshops.DatetimeProvider
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void ShouldReturnUtcDateTime()
        {
            // Arrange
            var sut = Create();
            // Act
            var result = sut.UtcNow;
            // Assert
            Expect(result).Not.To.Equal(DateTime.MinValue);
            Expect(result.Kind)
                .To.Equal(DateTimeKind.Utc);
        }

        [Test]
        [Repeat(50)]
        public void ShouldReturnDifferentDateEveryTime()
        {
            // Arrange
            var sut = Create();
            // Act
            var result1 = sut.UtcNow;
            Thread.Sleep(120);
            var result2 = sut.UtcNow;
            // Assert;
            Expect(result2).To.Be.Greater.Than(result1);
        }

        [Test]
        public void ShouldReturnCorrectDateTime()
        {
            // Arrange
            var sut = Create();
            var expectedStart = DateTime.UtcNow;
            
            // Act
            var result = sut.UtcNow;
            var expectedEnd = DateTime.UtcNow;
            // Assert
            Expect(result).To.Be.Greater.Than.Or.Equal.To(expectedStart)
                .And.To.Be.Less.Than.Or.Equal.To(expectedEnd);
        }
       
        private static IDateTimeProvider Create()
        {
            return new DateTimeProvider();
        }
        
    }


    public interface IDateTimeProvider
    {
        public DateTime UtcNow { get; }
    }
}
