﻿using csharp_coding_playground.DataStructures;
using csharp_coding_playground.Infrastructure;
using NUnit.Framework;

namespace csharp_coding_playground.unit_tests.DataStructures
{
    public class BinarySearchTreeTests
    {
        [Test]
        public void ShouldReturnCorrectHeightWhenOnlyRoot()
        {
            var bst = new BinarySearchTree<int>();
            bst.Insert(7);

            Assert.AreEqual(1, bst.Height);
        }

        [Test]
        public void ShouldReturnCorrectHeightWhenBSTIsEmpty()
        {
            var bst = new BinarySearchTree<int>();

            Assert.AreEqual(0, bst.Height);
        }

        [Test]
        public void ShouldReturnCorrectHeightWhenBSTIsNotEmpty()
        {
            var bst = new BinarySearchTree<int>();
            bst.Insert(7);
            bst.Insert(9);
            bst.Insert(4);
            bst.Insert(5);
            bst.Insert(3);
            bst.Insert(2);

            Assert.AreEqual(4, bst.Height);
        }

        [Test]
        public void ShouldReturnMinValueOnMinWhenBSTIsNotEmpty()
        {
            var bst = new BinarySearchTree<int>();
            bst.Insert(7);
            bst.Insert(9);
            bst.Insert(4);
            bst.Insert(5);
            bst.Insert(3);
            bst.Insert(2);

            Assert.AreEqual(2, bst.Min());
        }

        [Test]
        public void ShouldReturnDefaultOnMinWhenBSTIsEmpty()
        {
            var bst = new BinarySearchTree<int>();

            Assert.AreEqual(default(int), bst.Min());
        }

        [Test]
        public void ShouldReturnMaxValueOnMaxWhenBSTIsNotEmpty()
        {
            var bst = new BinarySearchTree<int>();
            bst.Insert(7);
            bst.Insert(9);
            bst.Insert(4);
            bst.Insert(5);
            bst.Insert(3);
            bst.Insert(2);

            Assert.AreEqual(9, bst.Max());
        }

        [Test]
        public void ShouldReturnDefaultOnMaxWhenBSTIsEmpty()
        {
            var bst = new BinarySearchTree<int>();

            Assert.AreEqual(default(int), bst.Max());
        }

        [Test]
        public void ShouldThrowExceptionOnInsertWhenValueExists()
        {
            var bst = new BinarySearchTree<int>();

            bst.Insert(7);
            Assert.Throws<ValidationException>(() => bst.Insert(7));

            bst.Insert(9);
            Assert.Throws<ValidationException>(() => bst.Insert(7));
            Assert.Throws<ValidationException>(() => bst.Insert(9));

            bst.Insert(4);
            Assert.Throws<ValidationException>(() => bst.Insert(9));
            Assert.Throws<ValidationException>(() => bst.Insert(7));
            Assert.Throws<ValidationException>(() => bst.Insert(4));

            bst.Insert(3);
            Assert.Throws<ValidationException>(() => bst.Insert(9));
            Assert.Throws<ValidationException>(() => bst.Insert(7));
            Assert.Throws<ValidationException>(() => bst.Insert(4));
            Assert.Throws<ValidationException>(() => bst.Insert(3));
        }

        [Test]
        public void ShouldThrowExceptionOnSuccessorWhenNodeDoesNotExist()
        {
            var bst = new BinarySearchTree<int>();
            Assert.Throws<ValidationException>(() => bst.Successor(7));

            bst.Insert(7);
            bst.Insert(9);
            bst.Insert(4);
            Assert.Throws<ValidationException>(() => bst.Successor(12));
        }

        [Test]
        public void ShouldReturnNextHighestValueOnSuccessorWhenNodeHasNoRightElement()
        {
            var bst = new BinarySearchTree<int>();
            bst.Insert(7);
            bst.Insert(9);
            bst.Insert(4);

            Assert.AreEqual(7, bst.Successor(4));
        }

        [Test]
        public void ShouldReturnNextHighestValueOnSuccessorWhenNodeHasRightElement()
        {
            var bst = new BinarySearchTree<int>();
            bst.Insert(7);
            bst.Insert(9);
            bst.Insert(4);
            bst.Insert(5);

            Assert.AreEqual(5, bst.Successor(4));
        }

        [Test]
        public void ShouldReturnNextHighestValueOnSuccessorWhenNodeHasMultipleRightElements()
        {
            var bst = new BinarySearchTree<int>();
            bst.Insert(7);
            bst.Insert(9);
            bst.Insert(4);
            bst.Insert(5);
            bst.Insert(6);

            Assert.AreEqual(5, bst.Successor(4));
        }

        [Test]
        public void ShouldReturnSameValueOnSuccessorWhenNodeIsMaxInTheTree()
        {
            var bst = new BinarySearchTree<int>();
            bst.Insert(7);
            bst.Insert(9);
            bst.Insert(4);
            bst.Insert(5);
            bst.Insert(6);

            Assert.AreEqual(9, bst.Successor(9));
        }

        [Test]
        public void ShouldInitializeLengthWithValue0()
        {
            var bst = new BinarySearchTree<int>();

            Assert.AreEqual(0, bst.Length);
        }

        [Test]
        public void ShouldAddElementAtCorrectPositionOnInsert()
        {
            var bst = new BinarySearchTree<int>();
            bst.Insert(7);
            bst.Insert(9);
            bst.Insert(4);
            bst.Insert(5);
            bst.Insert(3);
            bst.Insert(2);
            bst.Insert(11);
            bst.Insert(12);
            bst.Insert(10);
            bst.Insert(6);
            bst.Insert(8);
            bst.Insert(1);
            bst.Insert(0);

            var array = bst.DFS(DFSStrategy.InOrder);

            Assert.AreEqual(13, array.Length);
            Assert.AreEqual(array.Length, bst.Length);
            Assert.AreEqual(0, array.ElementAt(0));
            Assert.AreEqual(1, array.ElementAt(1));
            Assert.AreEqual(2, array.ElementAt(2));
            Assert.AreEqual(3, array.ElementAt(3));
            Assert.AreEqual(4, array.ElementAt(4));
            Assert.AreEqual(5, array.ElementAt(5));
            Assert.AreEqual(6, array.ElementAt(6));
            Assert.AreEqual(7, array.ElementAt(7));
            Assert.AreEqual(8, array.ElementAt(8));
            Assert.AreEqual(9, array.ElementAt(9));
            Assert.AreEqual(10, array.ElementAt(10));
            Assert.AreEqual(11, array.ElementAt(11));
            Assert.AreEqual(12, array.ElementAt(12));
        }

        [Test]
        public void ShouldReturnCorrectResultOnBFS()
        {
            var bst = new BinarySearchTree<int>();
            bst.Insert(7);
            bst.Insert(9);
            bst.Insert(4);
            bst.Insert(5);
            bst.Insert(3);
            bst.Insert(2);
            bst.Insert(11);
            bst.Insert(12);
            bst.Insert(10);
            bst.Insert(6);
            bst.Insert(8);
            bst.Insert(1);
            bst.Insert(0);

            var array = bst.BFS();

            Assert.AreEqual(13, array.Length);
            Assert.AreEqual(7, array.ElementAt(0));
            Assert.AreEqual(4, array.ElementAt(1));
            Assert.AreEqual(9, array.ElementAt(2));
            Assert.AreEqual(3, array.ElementAt(3));
            Assert.AreEqual(5, array.ElementAt(4));
            Assert.AreEqual(8, array.ElementAt(5));
            Assert.AreEqual(11, array.ElementAt(6));
            Assert.AreEqual(2, array.ElementAt(7));
            Assert.AreEqual(6, array.ElementAt(8));
            Assert.AreEqual(10, array.ElementAt(9));
            Assert.AreEqual(12, array.ElementAt(10));
            Assert.AreEqual(1, array.ElementAt(11));
            Assert.AreEqual(0, array.ElementAt(12));
        }

        [Test]
        public void ShouldReturnCorrectResultOnDFSWhenStrategyInOrder()
        {
            var bst = new BinarySearchTree<int>();
            bst.Insert(7);
            bst.Insert(9);
            bst.Insert(4);
            bst.Insert(5);
            bst.Insert(3);
            bst.Insert(2);
            bst.Insert(11);
            bst.Insert(12);
            bst.Insert(10);
            bst.Insert(6);
            bst.Insert(8);
            bst.Insert(1);
            bst.Insert(0);

            var array = bst.DFS(DFSStrategy.InOrder);

            Assert.AreEqual(13, array.Length);
            Assert.AreEqual(0, array.ElementAt(0));
            Assert.AreEqual(1, array.ElementAt(1));
            Assert.AreEqual(2, array.ElementAt(2));
            Assert.AreEqual(3, array.ElementAt(3));
            Assert.AreEqual(4, array.ElementAt(4));
            Assert.AreEqual(5, array.ElementAt(5));
            Assert.AreEqual(6, array.ElementAt(6));
            Assert.AreEqual(7, array.ElementAt(7));
            Assert.AreEqual(8, array.ElementAt(8));
            Assert.AreEqual(9, array.ElementAt(9));
            Assert.AreEqual(10, array.ElementAt(10));
            Assert.AreEqual(11, array.ElementAt(11));
            Assert.AreEqual(12, array.ElementAt(12));
        }

        [Test]
        public void ShouldReturnCorrectResultOnDFSWhenStrategyPreOrder()
        {
            var bst = new BinarySearchTree<int>();
            bst.Insert(7);
            bst.Insert(9);
            bst.Insert(4);
            bst.Insert(5);
            bst.Insert(3);
            bst.Insert(2);
            bst.Insert(11);
            bst.Insert(12);
            bst.Insert(10);
            bst.Insert(6);
            bst.Insert(8);
            bst.Insert(1);
            bst.Insert(0);

            var array = bst.DFS(DFSStrategy.PreOrder);

            Assert.AreEqual(13, array.Length);
            Assert.AreEqual(7, array.ElementAt(0));
            Assert.AreEqual(4, array.ElementAt(1));
            Assert.AreEqual(3, array.ElementAt(2));
            Assert.AreEqual(2, array.ElementAt(3));
            Assert.AreEqual(1, array.ElementAt(4));
            Assert.AreEqual(0, array.ElementAt(5));
            Assert.AreEqual(5, array.ElementAt(6));
            Assert.AreEqual(6, array.ElementAt(7));
            Assert.AreEqual(9, array.ElementAt(8));
            Assert.AreEqual(8, array.ElementAt(9));
            Assert.AreEqual(11, array.ElementAt(10));
            Assert.AreEqual(10, array.ElementAt(11));
            Assert.AreEqual(12, array.ElementAt(12));
        }

        [Test]
        public void ShouldReturnCorrectResultOnDFSWhenStrategyPostOrder()
        {
            var bst = new BinarySearchTree<int>();
            bst.Insert(7);
            bst.Insert(9);
            bst.Insert(4);
            bst.Insert(5);
            bst.Insert(3);
            bst.Insert(2);
            bst.Insert(11);
            bst.Insert(12);
            bst.Insert(10);
            bst.Insert(6);
            bst.Insert(8);
            bst.Insert(1);
            bst.Insert(0);

            var array = bst.DFS(DFSStrategy.PostOrder);

            Assert.AreEqual(13, array.Length);
            Assert.AreEqual(0, array.ElementAt(0));
            Assert.AreEqual(1, array.ElementAt(1));
            Assert.AreEqual(2, array.ElementAt(2));
            Assert.AreEqual(3, array.ElementAt(3));
            Assert.AreEqual(6, array.ElementAt(4));
            Assert.AreEqual(5, array.ElementAt(5));
            Assert.AreEqual(4, array.ElementAt(6));
            Assert.AreEqual(8, array.ElementAt(7));
            Assert.AreEqual(10, array.ElementAt(8));
            Assert.AreEqual(12, array.ElementAt(9));
            Assert.AreEqual(11, array.ElementAt(10));
            Assert.AreEqual(9, array.ElementAt(11));
            Assert.AreEqual(7, array.ElementAt(12));
        }

        [Test]
        public void ShouldReturnCorrectResultOnDFSWhenStrategyIsNotProvided()
        {
            var bst = new BinarySearchTree<int>();
            bst.Insert(7);
            bst.Insert(9);
            bst.Insert(4);
            bst.Insert(5);
            bst.Insert(3);
            bst.Insert(2);
            bst.Insert(11);
            bst.Insert(12);
            bst.Insert(10);
            bst.Insert(6);
            bst.Insert(8);
            bst.Insert(1);
            bst.Insert(0);

            var array = bst.DFS();

            Assert.AreEqual(13, array.Length);
            Assert.AreEqual(0, array.ElementAt(0));
            Assert.AreEqual(1, array.ElementAt(1));
            Assert.AreEqual(2, array.ElementAt(2));
            Assert.AreEqual(3, array.ElementAt(3));
            Assert.AreEqual(4, array.ElementAt(4));
            Assert.AreEqual(5, array.ElementAt(5));
            Assert.AreEqual(6, array.ElementAt(6));
            Assert.AreEqual(7, array.ElementAt(7));
            Assert.AreEqual(8, array.ElementAt(8));
            Assert.AreEqual(9, array.ElementAt(9));
            Assert.AreEqual(10, array.ElementAt(10));
            Assert.AreEqual(11, array.ElementAt(11));
            Assert.AreEqual(12, array.ElementAt(12));
        }

        [Test]
        public void ShouldThrowExceptionOnDFSWhenStrategyIsUnknow()
        {
            var bst = new BinarySearchTree<int>();
            bst.Insert(7);
            bst.Insert(9);
            bst.Insert(4);
            bst.Insert(5);
            bst.Insert(3);
            bst.Insert(2);
            bst.Insert(11);
            bst.Insert(12);
            bst.Insert(10);
            bst.Insert(6);
            bst.Insert(8);
            bst.Insert(1);
            bst.Insert(0);

            Assert.Throws<ValidationException>(() => bst.DFS((DFSStrategy)(-1)));
        }

        [Test]
        public void ShouldReturnCorrectValueOnSearchWhenValueExists()
        {
            var bst = new BinarySearchTree<int>();
            bst.Insert(7);
            bst.Insert(9);
            bst.Insert(4);
            bst.Insert(5);
            bst.Insert(3);
            bst.Insert(2);
            bst.Insert(11);
            bst.Insert(12);
            bst.Insert(10);
            bst.Insert(6);
            bst.Insert(8);
            bst.Insert(1);
            bst.Insert(0);

            Assert.AreEqual(0, bst.Search(0));
            Assert.AreEqual(1, bst.Search(1));
            Assert.AreEqual(2, bst.Search(2));
            Assert.AreEqual(3, bst.Search(3));
            Assert.AreEqual(4, bst.Search(4));
            Assert.AreEqual(5, bst.Search(5));
            Assert.AreEqual(6, bst.Search(6));
            Assert.AreEqual(7, bst.Search(7));
            Assert.AreEqual(8, bst.Search(8));
            Assert.AreEqual(9, bst.Search(9));
            Assert.AreEqual(10, bst.Search(10));
            Assert.AreEqual(11, bst.Search(11));
            Assert.AreEqual(12, bst.Search(12));
        }

        [Test]
        public void ShouldReturnDefaultValueOnSeachWhenValueDoesNotExist()
        {
            var bst = new BinarySearchTree<int>();
            bst.Insert(7);
            bst.Insert(9);
            bst.Insert(4);
            bst.Insert(5);
            bst.Insert(3);
            bst.Insert(2);
            bst.Insert(11);
            bst.Insert(12);
            bst.Insert(10);
            bst.Insert(6);
            bst.Insert(8);
            bst.Insert(1);
            bst.Insert(0);


            Assert.AreEqual(default(int), bst.Search(200));
        }

        [Test]
        public void ShouldRemoveCorrectElementOnRemoveWhenElementHasNoChildAndIsNotRoot()
        {
            var bst = new BinarySearchTree<int>();
            bst.Insert(7);
            bst.Insert(9);
            bst.Insert(4);

            var array = bst.DFS(DFSStrategy.InOrder);
            Assert.AreEqual(array.Length, 3);
            Assert.AreEqual(4, array.ElementAt(0));
            Assert.AreEqual(7, array.ElementAt(1));
            Assert.AreEqual(9, array.ElementAt(2));

            bst.Remove(4);
            array = bst.DFS(DFSStrategy.InOrder);
            Assert.AreEqual(array.Length, 2);
            Assert.AreEqual(7, array.ElementAt(0));
            Assert.AreEqual(9, array.ElementAt(1));
        }

        [Test]
        public void ShouldRemoveCorrectElementOnRemoveWhenElementHasNoChildAndIsRoot()
        {
            var bst = new BinarySearchTree<int>();
            bst.Insert(7);

            var array = bst.DFS(DFSStrategy.InOrder);
            Assert.AreEqual(array.Length, bst.Length);
            Assert.AreEqual(array.Length, 1);
            Assert.AreEqual(7, array.ElementAt(0));

            bst.Remove(7);
            array = bst.DFS(DFSStrategy.InOrder);
            Assert.AreEqual(array.Length, bst.Length);
            Assert.AreEqual(array.Length, 0);
        }

        [Test]
        public void ShouldRemoveCorrectElementOnRemoveWhenElementHasOneChildOnLeftAndIsNotRoot()
        {
            //Node is on parent left
            var bst = new BinarySearchTree<int>();
            bst.Insert(7);
            bst.Insert(4);
            bst.Insert(3);
            bst.Insert(8);

            var array = bst.DFS(DFSStrategy.InOrder);
            Assert.AreEqual(array.Length, 4);
            Assert.AreEqual(array.Length, bst.Length);
            Assert.AreEqual(3, array.ElementAt(0));
            Assert.AreEqual(4, array.ElementAt(1));
            Assert.AreEqual(7, array.ElementAt(2));
            Assert.AreEqual(8, array.ElementAt(3));

            bst.Remove(4);
            array = bst.DFS(DFSStrategy.InOrder);
            Assert.AreEqual(array.Length, 3);
            Assert.AreEqual(array.Length, bst.Length);
            Assert.AreEqual(3, array.ElementAt(0));
            Assert.AreEqual(7, array.ElementAt(1));
            Assert.AreEqual(8, array.ElementAt(2));

            //Node is on parent right
            bst = new BinarySearchTree<int>();
            bst.Insert(7);
            bst.Insert(9);
            bst.Insert(8);
            bst.Insert(4);

            array = bst.DFS(DFSStrategy.InOrder);
            Assert.AreEqual(array.Length, 4);
            Assert.AreEqual(array.Length, bst.Length);
            Assert.AreEqual(4, array.ElementAt(0));
            Assert.AreEqual(7, array.ElementAt(1));
            Assert.AreEqual(8, array.ElementAt(2));
            Assert.AreEqual(9, array.ElementAt(3));

            bst.Remove(9);
            array = bst.DFS(DFSStrategy.InOrder);
            Assert.AreEqual(array.Length, 3);
            Assert.AreEqual(array.Length, bst.Length);
            Assert.AreEqual(4, array.ElementAt(0));
            Assert.AreEqual(7, array.ElementAt(1));
            Assert.AreEqual(8, array.ElementAt(2));
        }

        [Test]
        public void ShouldRemoveCorrectElementOnRemoveWhenElementHasOneChildOnLeftAndIsRoot()
        {
            var bst = new BinarySearchTree<int>();
            bst.Insert(7);
            bst.Insert(3);

            var array = bst.DFS(DFSStrategy.InOrder);
            Assert.AreEqual(array.Length, 2);
            Assert.AreEqual(array.Length, bst.Length);
            Assert.AreEqual(3, array.ElementAt(0));
            Assert.AreEqual(7, array.ElementAt(1));

            bst.Remove(7);
            array = bst.DFS(DFSStrategy.InOrder);
            Assert.AreEqual(array.Length, 1);
            Assert.AreEqual(array.Length, bst.Length);
            Assert.AreEqual(3, array.ElementAt(0));
        }

        [Test]
        public void ShouldRemoveCorrectElementOnRemoveWhenElementHasOneChildOnRightAndIsNotRoot()
        {
            // Node is on parent left
            var bst = new BinarySearchTree<int>();
            bst.Insert(7);
            bst.Insert(4);
            bst.Insert(5);
            bst.Insert(8);

            var array = bst.DFS(DFSStrategy.InOrder);
            Assert.AreEqual(array.Length, 4);
            Assert.AreEqual(array.Length, bst.Length);
            Assert.AreEqual(4, array.ElementAt(0));
            Assert.AreEqual(5, array.ElementAt(1));
            Assert.AreEqual(7, array.ElementAt(2));
            Assert.AreEqual(8, array.ElementAt(3));

            bst.Remove(4);
            array = bst.DFS(DFSStrategy.InOrder);
            Assert.AreEqual(array.Length, 3);
            Assert.AreEqual(array.Length, bst.Length);
            Assert.AreEqual(5, array.ElementAt(0));
            Assert.AreEqual(7, array.ElementAt(1));
            Assert.AreEqual(8, array.ElementAt(2));

            //Node is on parent right
            bst = new BinarySearchTree<int>();
            bst.Insert(7);
            bst.Insert(9);
            bst.Insert(10);
            bst.Insert(4);

            array = bst.DFS(DFSStrategy.InOrder);
            Assert.AreEqual(array.Length, 4);
            Assert.AreEqual(array.Length, bst.Length);
            Assert.AreEqual(4, array.ElementAt(0));
            Assert.AreEqual(7, array.ElementAt(1));
            Assert.AreEqual(9, array.ElementAt(2));
            Assert.AreEqual(10, array.ElementAt(3));

            bst.Remove(9);
            array = bst.DFS(DFSStrategy.InOrder);
            Assert.AreEqual(array.Length, 3);
            Assert.AreEqual(array.Length, bst.Length);
            Assert.AreEqual(4, array.ElementAt(0));
            Assert.AreEqual(7, array.ElementAt(1));
            Assert.AreEqual(10, array.ElementAt(2));
        }

        [Test]
        public void ShouldRemoveCorrectElementOnRemoveWhenElementHasOneChildOnRightAndIsRoot()
        {
            var bst = new BinarySearchTree<int>();
            bst.Insert(7);
            bst.Insert(8);

            var array = bst.DFS(DFSStrategy.InOrder);
            Assert.AreEqual(array.Length, 2);
            Assert.AreEqual(array.Length, bst.Length);
            Assert.AreEqual(7, array.ElementAt(0));
            Assert.AreEqual(8, array.ElementAt(1));

            bst.Remove(7);
            array = bst.DFS(DFSStrategy.InOrder);
            Assert.AreEqual(array.Length, 1);
            Assert.AreEqual(array.Length, bst.Length);
            Assert.AreEqual(8, array.ElementAt(0));
        }

        [Test]
        public void ShouldRemoveCorrectElementOnRemoveWhenElementHasTwoChildrenAndIsNotRoot()
        {
            var bst = new BinarySearchTree<int>();
            bst.Insert(7);
            bst.Insert(4);
            bst.Insert(5);
            bst.Insert(6);
            bst.Insert(8);

            var array = bst.DFS(DFSStrategy.InOrder);
            Assert.AreEqual(array.Length, 5);
            Assert.AreEqual(array.Length, bst.Length);
            Assert.AreEqual(4, array.ElementAt(0));
            Assert.AreEqual(5, array.ElementAt(1));
            Assert.AreEqual(6, array.ElementAt(2));
            Assert.AreEqual(7, array.ElementAt(3));
            Assert.AreEqual(8, array.ElementAt(4));

            bst.Remove(4);
            array = bst.DFS(DFSStrategy.InOrder);
            Assert.AreEqual(array.Length, 4);
            Assert.AreEqual(array.Length, bst.Length);
            Assert.AreEqual(5, array.ElementAt(0));
            Assert.AreEqual(6, array.ElementAt(1));
            Assert.AreEqual(7, array.ElementAt(2));
            Assert.AreEqual(8, array.ElementAt(3));
        }

        [Test]
        public void ShouldRemoveCorrectElementOnRemoveWhenElementHasTwoChildrenAndIsRoot()
        {
            var bst = new BinarySearchTree<int>();
            bst.Insert(7);
            bst.Insert(8);
            bst.Insert(6);

            var array = bst.DFS(DFSStrategy.InOrder);
            Assert.AreEqual(array.Length, 3);
            Assert.AreEqual(array.Length, bst.Length);
            Assert.AreEqual(6, array.ElementAt(0));
            Assert.AreEqual(7, array.ElementAt(1));
            Assert.AreEqual(8, array.ElementAt(2));

            bst.Remove(7);
            array = bst.DFS(DFSStrategy.InOrder);
            Assert.AreEqual(array.Length, 2);
            Assert.AreEqual(array.Length, bst.Length);
            Assert.AreEqual(6, array.ElementAt(0));
            Assert.AreEqual(8, array.ElementAt(1));
        }

        [Test]
        public void ShouldRemoveCorrectElementOnRemoveWhenElementHasTwoChildrenWithChildrenAndIsNotRoot()
        {
            // Right -> Right case
            var bst = new BinarySearchTree<int>();
            bst.Insert(10);
            bst.Insert(4);
            bst.Insert(3);
            bst.Insert(5);
            bst.Insert(6);
            bst.Insert(11);
            bst.Insert(12);

            var array = bst.DFS(DFSStrategy.InOrder);
            Assert.AreEqual(array.Length, 7);
            Assert.AreEqual(array.Length, bst.Length);
            Assert.AreEqual(3, array.ElementAt(0));
            Assert.AreEqual(4, array.ElementAt(1));
            Assert.AreEqual(5, array.ElementAt(2));
            Assert.AreEqual(6, array.ElementAt(3));
            Assert.AreEqual(10, array.ElementAt(4));
            Assert.AreEqual(11, array.ElementAt(5));
            Assert.AreEqual(12, array.ElementAt(6));

            bst.Remove(4);
            array = bst.DFS(DFSStrategy.InOrder);
            Assert.AreEqual(array.Length, 6);
            Assert.AreEqual(array.Length, bst.Length);
            Assert.AreEqual(3, array.ElementAt(0));
            Assert.AreEqual(5, array.ElementAt(1));
            Assert.AreEqual(6, array.ElementAt(2));
            Assert.AreEqual(10, array.ElementAt(3));
            Assert.AreEqual(11, array.ElementAt(4));
            Assert.AreEqual(12, array.ElementAt(5));

            // Right -> Left -> Right case
            bst = new BinarySearchTree<int>();
            bst.Insert(10);
            bst.Insert(4);
            bst.Insert(3);
            bst.Insert(8);
            bst.Insert(6);
            bst.Insert(7);
            bst.Insert(9);
            bst.Insert(11);
            bst.Insert(12);

            array = bst.DFS(DFSStrategy.InOrder);
            Assert.AreEqual(array.Length, 9);
            Assert.AreEqual(array.Length, bst.Length);
            Assert.AreEqual(3, array.ElementAt(0));
            Assert.AreEqual(4, array.ElementAt(1));
            Assert.AreEqual(6, array.ElementAt(2));
            Assert.AreEqual(7, array.ElementAt(3));
            Assert.AreEqual(8, array.ElementAt(4));
            Assert.AreEqual(9, array.ElementAt(5));
            Assert.AreEqual(10, array.ElementAt(6));
            Assert.AreEqual(11, array.ElementAt(7));
            Assert.AreEqual(12, array.ElementAt(8));

            bst.Remove(4);
            array = bst.DFS(DFSStrategy.InOrder);
            Assert.AreEqual(array.Length, 8);
            Assert.AreEqual(array.Length, bst.Length);
            Assert.AreEqual(3, array.ElementAt(0));
            Assert.AreEqual(6, array.ElementAt(1));
            Assert.AreEqual(7, array.ElementAt(2));
            Assert.AreEqual(8, array.ElementAt(3));
            Assert.AreEqual(9, array.ElementAt(4));
            Assert.AreEqual(10, array.ElementAt(5));
            Assert.AreEqual(11, array.ElementAt(6));
            Assert.AreEqual(12, array.ElementAt(7));

            // Right and Left case
            bst = new BinarySearchTree<int>();
            bst.Insert(10);
            bst.Insert(4);
            bst.Insert(3);
            bst.Insert(5);
            bst.Insert(11);
            bst.Insert(12);

            array = bst.DFS(DFSStrategy.InOrder);
            Assert.AreEqual(array.Length, 6);
            Assert.AreEqual(array.Length, bst.Length);
            Assert.AreEqual(3, array.ElementAt(0));
            Assert.AreEqual(4, array.ElementAt(1));
            Assert.AreEqual(5, array.ElementAt(2));
            Assert.AreEqual(10, array.ElementAt(3));
            Assert.AreEqual(11, array.ElementAt(4));
            Assert.AreEqual(12, array.ElementAt(5));

            bst.Remove(4);
            array = bst.DFS(DFSStrategy.InOrder);
            Assert.AreEqual(array.Length, 5);
            Assert.AreEqual(array.Length, bst.Length);
            Assert.AreEqual(3, array.ElementAt(0));
            Assert.AreEqual(5, array.ElementAt(1));
            Assert.AreEqual(10, array.ElementAt(2));
            Assert.AreEqual(11, array.ElementAt(3));
            Assert.AreEqual(12, array.ElementAt(4));
        }

        [Test]
        public void ShouldRemoveCorrectElementOnRemoveWhenElementHasTwoChildrenWithChildrenAndIsRoot()
        {
            // Right -> Left -> Right case
            var bst = new BinarySearchTree<int>();
            bst.Insert(10);
            bst.Insert(9);
            bst.Insert(8);
            bst.Insert(13);
            bst.Insert(11);
            bst.Insert(12);

            var array = bst.DFS(DFSStrategy.InOrder);
            Assert.AreEqual(array.Length, 6);
            Assert.AreEqual(array.Length, bst.Length);
            Assert.AreEqual(8, array.ElementAt(0));
            Assert.AreEqual(9, array.ElementAt(1));
            Assert.AreEqual(10, array.ElementAt(2));
            Assert.AreEqual(11, array.ElementAt(3));
            Assert.AreEqual(12, array.ElementAt(4));
            Assert.AreEqual(13, array.ElementAt(5));

            bst.Remove(10);
            array = bst.DFS(DFSStrategy.InOrder);
            Assert.AreEqual(array.Length, 5);
            Assert.AreEqual(array.Length, bst.Length);
            Assert.AreEqual(8, array.ElementAt(0));
            Assert.AreEqual(9, array.ElementAt(1));
            Assert.AreEqual(11, array.ElementAt(2));
            Assert.AreEqual(12, array.ElementAt(3));
            Assert.AreEqual(13, array.ElementAt(4));

            // Right and Left case
            bst = new BinarySearchTree<int>();
            bst.Insert(11);
            bst.Insert(9);
            bst.Insert(8);
            bst.Insert(10);
            bst.Insert(14);
            bst.Insert(13);
            bst.Insert(15);

            array = bst.DFS(DFSStrategy.InOrder);
            Assert.AreEqual(array.Length, 7);
            Assert.AreEqual(array.Length, bst.Length);
            Assert.AreEqual(8, array.ElementAt(0));
            Assert.AreEqual(9, array.ElementAt(1));
            Assert.AreEqual(10, array.ElementAt(2));
            Assert.AreEqual(11, array.ElementAt(3));
            Assert.AreEqual(13, array.ElementAt(4));
            Assert.AreEqual(14, array.ElementAt(5));
            Assert.AreEqual(15, array.ElementAt(6));

            bst.Remove(10);
            array = bst.DFS(DFSStrategy.InOrder);
            Assert.AreEqual(array.Length, 6);
            Assert.AreEqual(array.Length, bst.Length);
            Assert.AreEqual(8, array.ElementAt(0));
            Assert.AreEqual(9, array.ElementAt(1));
            Assert.AreEqual(11, array.ElementAt(2));
            Assert.AreEqual(13, array.ElementAt(3));
            Assert.AreEqual(14, array.ElementAt(4));
            Assert.AreEqual(15, array.ElementAt(5));

            // Right -> Right case
            bst = new BinarySearchTree<int>();
            bst.Insert(11);
            bst.Insert(9);
            bst.Insert(8);
            bst.Insert(10);
            bst.Insert(14);
            bst.Insert(15);

            array = bst.DFS(DFSStrategy.InOrder);
            Assert.AreEqual(array.Length, 6);
            Assert.AreEqual(array.Length, bst.Length);
            Assert.AreEqual(8, array.ElementAt(0));
            Assert.AreEqual(9, array.ElementAt(1));
            Assert.AreEqual(10, array.ElementAt(2));
            Assert.AreEqual(11, array.ElementAt(3));
            Assert.AreEqual(14, array.ElementAt(4));
            Assert.AreEqual(15, array.ElementAt(5));

            bst.Remove(10);
            array = bst.DFS(DFSStrategy.InOrder);
            Assert.AreEqual(array.Length, 5);
            Assert.AreEqual(array.Length, bst.Length);
            Assert.AreEqual(8, array.ElementAt(0));
            Assert.AreEqual(9, array.ElementAt(1));
            Assert.AreEqual(11, array.ElementAt(2));
            Assert.AreEqual(14, array.ElementAt(3));
            Assert.AreEqual(15, array.ElementAt(4));
        }

        [Test]
        public void ShouldNotDeleteAnythingOnRemoveWhenElementDoesNotExist()
        {
            var bst = new BinarySearchTree<int>();
            bst.Insert(7);
            bst.Insert(9);
            bst.Insert(4);
            bst.Insert(5);
            bst.Insert(3);
            bst.Insert(2);
            bst.Insert(11);
            bst.Insert(12);
            bst.Insert(10);
            bst.Insert(6);
            bst.Insert(8);
            bst.Insert(1);
            bst.Insert(0);

            var array = bst.DFS(DFSStrategy.InOrder);
            bst.Remove(200);

            Assert.AreEqual(13, array.Length);
            Assert.AreEqual(array.Length, bst.Length);
            Assert.AreEqual(0, array.ElementAt(0));
            Assert.AreEqual(1, array.ElementAt(1));
            Assert.AreEqual(2, array.ElementAt(2));
            Assert.AreEqual(3, array.ElementAt(3));
            Assert.AreEqual(4, array.ElementAt(4));
            Assert.AreEqual(5, array.ElementAt(5));
            Assert.AreEqual(6, array.ElementAt(6));
            Assert.AreEqual(7, array.ElementAt(7));
            Assert.AreEqual(8, array.ElementAt(8));
            Assert.AreEqual(9, array.ElementAt(9));
            Assert.AreEqual(10, array.ElementAt(10));
            Assert.AreEqual(11, array.ElementAt(11));
            Assert.AreEqual(12, array.ElementAt(12));
        }
    }
}