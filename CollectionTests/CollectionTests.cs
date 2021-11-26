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
        public void Indexer_WhenGetValue_ShouldReturnProperlyValue()
        {
            Collection<float> collection = new Collection<float>();
            collection.Add(0.1f);
            collection.Add(0.2f);
            collection.Add(0.3f);

            float num = collection[2];

            Assert.AreEqual(0.3f, num);
        }

        [TestMethod]
        public void Indexer_WhenSetNewValue_ShouldUpdateOldValue()
        {
            Collection<int> collection = new Collection<int>();
            collection.Add(1);
            collection[0] = 2;

            Assert.AreEqual(2, collection[0]);
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
        public void AddByIndex_WhenIndexIsValid_ShouldMoveElementsRight()
        {
            Collection<int> collection = new Collection<int>();
            collection.Add(1);
            collection.Add(2);
            collection.Add(4);

            Assert.AreEqual(3, collection.Count);

            collection.Add(3, 2);

            Assert.AreEqual(4, collection.Count);
            Assert.AreEqual(3, collection[2]);
            Assert.AreEqual(4, collection[3]);
        }

        [TestMethod]
        public void AddByIndex_WhenArrayIsFull_ShouldResizeArrayAndMoveElementsRight()
        {
            Collection<int> collection = new Collection<int>();
            collection.Add(1);
            collection.Add(2);
            collection.Add(3);
            collection.Add(5);

            Assert.AreEqual(4, collection.Count);

            collection.Add(4, 3);

            Assert.AreEqual(5, collection.Count);
            Assert.AreEqual(4, collection[3]);
            Assert.AreEqual(5, collection[4]);
        }

        [TestMethod]
        public void AddToEnd_WhenArrayIsFull_ShouldResizeArray()
        {
            Random random = new Random();
            Collection<double> collection = new Collection<double>();

            collection.Add(random.NextDouble());
            collection.Add(random.NextDouble());
            collection.Add(random.NextDouble());
            collection.Add(random.NextDouble());

            Assert.AreEqual(4, collection.Count);

            double num = random.NextDouble();
            collection.Add(num);

            Assert.AreEqual(5, collection.Count);
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

        [TestMethod]
        public void RemoveByValue_WhenFindFirstSuchValue_MoveElementsLeft()
        { 
            Collection<int> collection = new Collection<int>();

            collection.Add(1);
            collection.Add(2);
            collection.Add(3); // 3
            collection.Add(4);
            collection.Add(5);
            collection.Add(3); // 3
            collection.Add(6);
            collection.Add(7);
            collection.Add(8);
            collection.Add(3); // 3
            collection.Add(9);

            int collectionLenght = collection.Count;
            Assert.AreEqual(collectionLenght, collection.Count);

            collection.RemoveFirst(3);
            collection.RemoveFirst(3);

            int count = 0;

            foreach (int element in collection)
            {
                if (element == 3)
                    count++;
            }

            Assert.AreEqual(4, collection[2]);
            Assert.AreEqual(6, collection[4]);
            Assert.AreEqual(collectionLenght - 2, collection.Count);
            Assert.AreEqual(1, count);
        }

        [TestMethod]
        public void RemoveByValue_WhenDoNotFind_ReturnFalse()
        {
            Collection<int> collection = new Collection<int>();

            collection.Add(1);
            collection.Add(2);
            collection.Add(3);
            collection.Add(4);
            collection.Add(5);
           
            Assert.AreEqual(false, collection.RemoveFirst(10));
        }

        [TestMethod]
        public void RemoveByIndex_WhenFindElement_MoveElementsLeft()
        {
            Collection<int> collection = new Collection<int>();

            collection.Add(1);
            collection.Add(2);
            collection.Add(3);
            collection.Add(4);
            collection.Add(5);

            Assert.AreEqual(5, collection.Count);

            collection.Remove(3);

            Assert.AreEqual(5, collection[3]);
            Assert.AreEqual(4, collection.Count);
        }

        [TestMethod]
        public void GetMax_WhenCollectionIsNotEmpty_ShouldReturnTheBiggestValue()
        {
            Collection<double> collection = new Collection<double>();

            collection.Add(0.13123d);
            collection.Add(2.23422d);
            collection.Add(-23.2342d);
            collection.Add(24.2321d);

            Assert.AreEqual(24.2321d, collection.GetMax);
        }
        
        [TestMethod]
        public void GetMax_WhenCollectionIsEmpty_ShouldThrowException()
        {
            Collection<double> collection = new Collection<double>();

            Assert.ThrowsException<System.Exception>(() => collection.GetMax);
        }

        [TestMethod]
        public void GetMax_WhenRemoveByIndexMaxItem_ShouldReturnPrevMaxItem()
        {
            Collection<double> collection = new Collection<double>();

            collection.Add(0.13123d);
            collection.Add(2.23422d);
            collection.Add(-23.2342d);
            collection.Add(24.2321d);

            collection.Remove(3);

            Assert.AreEqual(2.23422d, collection.GetMax);
        }

        [TestMethod]
        public void GetMax_WhenRemoveByItemMaxItem_ShouldReturnPrevMaxItem()
        {
            Collection<double> collection = new Collection<double>();

            collection.Add(0.13123d);
            collection.Add(2.23422d);
            collection.Add(-23.2342d);
            collection.Add(24.2321d);

            collection.RemoveFirst(24.2321d);

            Assert.AreEqual(2.23422d, collection.GetMax);
        }

        [TestMethod]
        public void GetMax_WhenRemoveNotMaxItems_ShouldReturnNotChangedMaxValue()
        {
            Collection<double> collection = new Collection<double>();

            collection.Add(0.13123d);
            collection.Add(2.23422d);
            collection.Add(-23.2342d);
            collection.Add(24.2321d);

            collection.RemoveFirst(0.13123d);
            collection.Remove(0);

            Assert.AreEqual(24.2321d, collection.GetMax);
        }
    }
}