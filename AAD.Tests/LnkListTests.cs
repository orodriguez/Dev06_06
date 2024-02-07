using System;
using Xunit;

namespace AAD.Tests
{
    public class SimpleLinkedListTests
    {
        [Fact]
        public void Add_ElementToEmptyList()
        {
            // Arrange
            var linkedList = new LnkList<string>();

            // Act
            linkedList.Add("One");

            // Assert
            Assert.Equal(new[] { "One" }, linkedList.ToArray());
            // Time Complexity: O(1)
        }

        [Fact]
        public void Add_MultipleElementsToList()
        {
            var linkedList = LnkList<int>.From(1, 2, 3);

            linkedList.Add(4);

            Assert.Equal(new[] { 1, 2, 3, 4 }, linkedList.ToArray());
            // Time Complexity: O(n) 
        }

        [Fact]
        public void Insert_ElementInEmptyList()
        {
            var linkedList = new LnkList<string>();

            linkedList.Insert(0, "Juan");

            Assert.Equal(Array.Empty<string>(), linkedList.ToArray());
            // Time Complexity: O(1)
        }

        [Fact]
        public void Insert_ElementAtBeginning()
        {
            var linkedList = LnkList<string>.From("Pablo");

            linkedList.Insert(0, "Juan");

            Assert.Equal(new[] { "Juan", "Pablo" }, linkedList.ToArray());
            // Time Complexity: O(1)
        }

        [Fact]
        public void Insert_ElementAtSpecificPosition()
        {
            var linkedList = LnkList<string>.From("Juan", "Duarte");

            linkedList.Insert(1, "Pablo");

            Assert.Equal(new[] { "Juan", "Pablo", "Duarte" }, linkedList.ToArray());
            // Time Complexity: O(n)
        }

        [Fact]
        public void Count_EmptyList()
        {
            var linkedList = new LnkList<int>();

            Assert.Equal(0, linkedList.Count());
            // Time Complexity: O(1) 
        }

        [Fact]
        public void Count_ListWithElements()
        {
            var linkedList = LnkList<int>.From(1, 2, 3, 4);

            Assert.Equal(4, linkedList.Count());
            // Time Complexity: O(1)
        }

        [Fact]
        public void ConvertFromArrayToList()
        {
            var linkedList = LnkList<int>.From(1, 2, 3);

            Assert.Equal(new[] { 1, 2, 3 }, linkedList.ToArray());
            // Time Complexity: O(n)
        }

        [Fact]
        public void ConvertEmptyListToArray()
        { 
            var linkedList = new LnkList<int>();

            Assert.Equal(Array.Empty<int>(), linkedList.ToArray());
            // Time Complexity: O(1)
        }

        [Fact]
        public void ConvertListWithOneElementToArray()
        {
            var linkedList = LnkList<int>.From(1);

            Assert.Equal(new[] { 1 }, linkedList.ToArray());
            // Time Complexity: O(1)
        }

        [Fact]
        public void ConvertListWithTwoElementsToArray()
        {
            var linkedList = LnkList<int>.From(1, 2);

            Assert.Equal(new[] { 1, 2 }, linkedList.ToArray());
            // Time Complexity: O(2)
        }

        [Fact]
        public void ConvertListWithMultipleElementsToArray()
        {
            var linkedList = LnkList<int>.From(1, 2, 3, 4);

            Assert.Equal(new[] { 1, 2, 3, 4 }, linkedList.ToArray());
            // Time Complexity: O(n)
        }
    }
}
