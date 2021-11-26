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
            
            try
            {
                collection[-1] = 1;
            }
            catch (ArgumentOutOfRangeException e)
            {
                StringAssert.Contains(e.Message, Collection<int>.IndexerIndexLessThanZeroMessage);
                return;
            }

            Assert.Fail("The expected exception was not thrown.");
        } 

        [TestMethod]
        public void Indexer_WhenIndexIsMoreThanLastElement_ShouldThrowOutOfRange()
        {
            Collection<int> collection = new Collection<int>();
            collection.Add(1);

            try
            {
                collection[2] = 2;
            }
            catch (ArgumentOutOfRangeException e)
            {
                StringAssert.Contains(e.Message, Collection<int>.IndexerIndexExceedsNumberOfElementsMessage);
                return;
            }

            Assert.Fail("The expected exception was not thrown.");
        }

        [TestMethod]
        public void AddByIndex_WhenIndexIsLessThanZero_ShouldThrowOutOfRange()
        {
            Collection<int> collection = new Collection<int>();

            try
            {
                collection.Add(0, -1);
            }
            catch (ArgumentOutOfRangeException e)
            {
                StringAssert.Contains(e.Message, Collection<int>.IndexLessThanZeroMessage);
                return;
            }

            Assert.Fail("The expected exception was not thrown.");
        }

        [TestMethod]
        public void AddByIndex_WhenIndexIsMoreThanLastElement_ShouldThrowOutOfRange()
        {
            Collection<int> collection = new Collection<int>();
            collection.Add(1); // index = 0
            collection.Add(2); // index = 1
            collection.Add(3); // index = 2

            try
            {
                collection.Add(4, 3); // move elements with index >= 3 and try to add new element by index = 3
            }
            catch (ArgumentOutOfRangeException e)
            {
                StringAssert.Contains(e.Message, Collection<int>.IndexExceedsNumberOfElementsMessage);
                return;
            }

            Assert.Fail("The expected exception was not thrown.");
        }

        [TestMethod]
        public void RemoveByIndex_WhenIndexIsLessThanZero_ShouldThrowOutOfRange()
        {
            Collection<int> collection = new Collection<int>();
            
            try
            {
                collection.Remove(-1);
            }
            catch (ArgumentOutOfRangeException e)
            {
                StringAssert.Contains(e.Message, Collection<int>.IndexLessThanZeroMessage);
                return;
            }

            Assert.Fail("The expected exception was not thrown.");
        }

        [TestMethod]
        public void RemoveByIndex_WhenIndexIsMoreThanLastElement_ShouldThrowOutOfRange()
        {
            Collection<int> collection = new Collection<int>();
            collection.Add(1); // index = 0
            collection.Add(2); // index = 1
            collection.Add(3); // index = 2

            try
            {
                collection.Remove(3); // remove by index = 3
            }
            catch (ArgumentOutOfRangeException e)
            {
                StringAssert.Contains(e.Message, Collection<int>.IndexExceedsNumberOfElementsMessage);
                return;
            }

            Assert.Fail("The expected exception was not thrown.");
        }
    }
}
