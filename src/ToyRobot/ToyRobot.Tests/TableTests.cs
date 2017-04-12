using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ToyRobot.Common;
using ToyRobot.Models;
using Should;

namespace ToyRobot.Tests
{
    [TestClass]
    public class TableTests
    {
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void CreateRobotOutsideTable_ShouldThrowException()
        {
            ///////// Arrange

            Table table = new Table(5);

            ///////// Act

            table.CreateRobot(-1, -1, Orientation.NORTH);

            ///////// Assert
            // Check exception
        }

        [TestMethod]
        public void IsValidPoint_PointOutsideTable_ShouldReturnFalse()
        {
            ///////// Arrange

            Table table = new Table(5);

            ///////// Act

            bool isValid = table.IsValidPoint(10, 10);

            ///////// Assert

            isValid.ShouldBeFalse();
        }

        [TestMethod]
        public void IsValidPoint_LeftMostPoint_ShouldReturnTrue()
        {
            ///////// Arrange
            int minCoordinate = 0;
            Table table = new Table(minCoordinate);

            ///////// Act

            bool isValid = table.IsValidPoint(minCoordinate, minCoordinate);

            ///////// Assert

            isValid.ShouldBeTrue();
        }

        [TestMethod]
        public void IsValidPoint_RightMostPoint_ShouldReturnTrue()
        {
            ///////// Arrange

            int length = 5;
            Table table = new Table(length);

            ///////// Act

            bool isValid = table.IsValidPoint(length, length);

            ///////// Assert

            isValid.ShouldBeTrue();
        }
    }
}
