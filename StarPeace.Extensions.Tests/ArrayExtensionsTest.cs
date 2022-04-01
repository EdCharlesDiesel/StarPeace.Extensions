using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StarPeace.Extensions;
using StarPeace.Extentions;

namespace StarPeace.Extensions.Tests
{
    [TestClass]
    public class ProgramTest
    {
        [TestMethod]
        public void IndexMultipliedByFiveTest()
        {
            //Arrange           
            var expectedArray = new int[] { 0, 5, 10, 15, 20, 25, 30, 35, 40, 45, 50, 55, 60, 65, 70, 75, 80, 85, 90, 95 };
            int[] arr = new int[expectedArray.Length];
            
            //Act
            var actual = arr.IndexMultipliedByFive();
            
            //Assert
            for (int i = 0; i < arr.Length; i++)
            {
                Assert.AreEqual(expectedArray[i], actual[i]);    
            }            
        }

        [TestMethod]
        public void CompareTwoArrays_ReturnsTrue_WhenEqual()
        {
            //Arrange           
            var expectedArrayOne = new int[] { 0, 5, 10, 15, 20};
            var expectedArrayTwo = new int[] { 0, 5, 10, 15, 20 };            

            //Act
            var actual = expectedArrayOne.CompareTwoArrays(expectedArrayTwo);

            //Assert
            Assert.IsTrue( actual);
        }

        [TestMethod]
        public void CompareTwoArrays_ReturnsFalse_WhenNotEqual()
        {
            //Arrange           
            var expectedArrayOne = new int[] { 0, 5, 10, 15, 20 };
            var expectedArrayTwo = new int[] { 0, 5, 10, 15 };

            //Act
            var actual = expectedArrayOne.CompareTwoArrays(expectedArrayTwo);

            //Assert
            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void MaxSequenceEqualElements_Returns_MaxSeqElements()
        {
            //Arrange           
            var array = new int[] { 2, 1, 1, 2, 3, 3, 2, 2, 2, 1 };
            var expected = new int[] {2 ,2, 2};

            //Act
            var actual = array.MaxSequenceEqualElements();

            //Assert
            for (int i = 0; i < actual.Length; i++)
            {
                Assert.AreEqual(expected[i], actual[i]);
            }
        }

        [TestMethod]
        public void LongestIncreasingSequence_Returns_MaxSeqElements()
        {
            //Arrange           
            var array = new int[] { 3, 2, 3, 4, 2, 2, 4 };
            var expected = new int[] {0 , 2, 3 };

            //Act
            var actual = array.LongestIncreasingSequence();

            //Assert
            for (int i = 0; i < actual.Length; i++)
            {
                Assert.AreEqual(expected[i], actual[i]);
            }
        }
    }
}
