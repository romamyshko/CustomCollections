using Microsoft.VisualStudio.TestTools.UnitTesting;
using CustomCollections;
using System;

namespace CollectionTests
{
    [TestClass]
    public class CollectionTests
    {
        [TestMethod]
        public void Indexer_WhenIndexIsLessThanZero_ShouldThrowOutOfRange()
        {
            Collection<int> collection = new Collection<int>();

            Assert.ThrowsException<System.ArgumentOutOfRangeException>(() => collection[-1] = 1);
        } 

        [TestMethod]
        public void Indexer_WhenIndexIsMoreThanLastElement_ShouldThrowOutOfRange()
        {
            Collection<int> collection = new Collection<int>();
            collection.Add(1);

            Assert.ThrowsException<System.ArgumentOutOfRangeException>(() => collection[2] = 2);
        }

        [TestMethod]
        public void AddByIndex_WhenIndexIsLessThanZero_ShouldThrowOutOfRange()
        {
            Collection<int> collection = new Collection<int>();

            Assert.ThrowsException<System.ArgumentOutOfRangeException>(() => collection.Add(0, -1));
        }

        [TestMethod]
        public void AddByIndex_WhenIndexIsMoreThanLastElement_ShouldThrowOutOfRange()
        {
            Collection<int> collection = new Collection<int>();
            collection.Add(1); // index = 0
            collection.Add(2); // index = 1
            collection.Add(3); // index = 2

            // move elements with index >= 3 and try to add new element by index = 3
            Assert.ThrowsException<System.ArgumentOutOfRangeException>(() => collection.Add(4, 3));
        }

        [TestMethod]
        public void RemoveByIndex_WhenIndexIsLessThanZero_ShouldThrowOutOfRange()
        {
            Collection<int> collection = new Collection<int>();

            Assert.ThrowsException<System.ArgumentOutOfRangeException>(() => collection.Remove(-1));
        }

        [TestMethod]
        public void RemoveByIndex_WhenIndexIsMoreThanLastElement_ShouldThrowOutOfRange()
        {
            Collection<int> collection = new Collection<int>();
            collection.Add(1); // index = 0
            collection.Add(2); // index = 1
            collection.Add(3); // index = 2

            Assert.ThrowsException<System.ArgumentOutOfRangeException>(() => collection.Remove(3)); // remove by index = 3
        }

        [TestMethod]
        public void Constructor_WhenInitArrOfTypeStruct_ShouldThrowTypeAccess()
        {
            Assert.ThrowsException<System.TypeAccessException>(() => new Collection<DateTime>());
        }
    }
}