using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Should;
using ToyRobot.Common;
using ToyRobot.Core;
using ToyRobot.Models;

namespace ToyRobot.Tests
{
    [TestClass]
    public class CommandTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AnyCommand_TableNotInitalized_ShouldThrowException()
        {
            ///////// Arrange

            PlaceCommand command = new PlaceCommand();
            Table table = null;
            var logger = new Mock<ILogger>();


            ///////// Act

            command.Execute(table, logger.Object);

            ///////// Assert
            
        }

        [TestMethod]
        public void PlaceCommand_InsideTable_ShouldCreateRobot()
        {
            ///////// Arrange

            PlaceCommand command = new PlaceCommand();
            var mockTable = new Mock<Table>();
            var mockLogger = new Mock<ILogger>();

            mockTable.Setup(t => t.IsValidPoint(It.IsAny<int>(), It.IsAny<int>())).Returns(true);

            ///////// Act

            command.Execute(mockTable.Object, mockLogger.Object);

            ///////// Assert

            mockTable
                .Verify(t => t.CreateRobot(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<Orientation>()), Times.Once);
        }

        [TestMethod]
        public void PlaceCommand_OutsideTable_ShouldNotCreateRobot()
        {
            ///////// Arrange

            PlaceCommand command = new PlaceCommand();
            var mockTable = new Mock<Table>();
            var mockLogger = new Mock<ILogger>();

            mockTable.Setup(t => t.IsValidPoint(It.IsAny<int>(),It.IsAny<int>())).Returns(false);

            ///////// Act

            command.Execute(mockTable.Object, mockLogger.Object);

            ///////// Assert

            mockTable
               .Verify(t => t.CreateRobot(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<Orientation>()), Times.Never);
        }

        [TestMethod]
        public void TurnLeftCommand_ShouldTurnLeft()
        {
            ///////// Arrange

            LeftCommand command = new LeftCommand();
            var mockTable = new Mock<Table>();
            var mockLogger = new Mock<ILogger>();

            mockTable
                .Setup(t => t.Robot)
                .Returns(new Robot(It.IsAny<int>(), It.IsAny<int>(), Orientation.NORTH));
            mockTable
                .Setup(t => t.IsValidPoint(It.IsAny<Point>()))
                .Returns(true);

            ///////// Act

            command.Execute(mockTable.Object, mockLogger.Object);

            ///////// Assert

            mockTable.Object.Robot.Location.Orientation.ShouldEqual(Orientation.WEST);
            mockTable.Object.Robot.Location.Position.X.ShouldEqual(0);
            mockTable.Object.Robot.Location.Position.Y.ShouldEqual(0);
        }

        [TestMethod]
        public void TurnRightCommand_ShouldTurnRight()
        {
            ///////// Arrange

            RightCommand command = new RightCommand();
            var mockTable = new Mock<Table>();
            var mockLogger = new Mock<ILogger>();

            mockTable
                .Setup(t => t.Robot)
                .Returns(new Robot(It.IsAny<int>(), It.IsAny<int>(), Orientation.WEST));
            mockTable
                .Setup(t => t.IsValidPoint(It.IsAny<Point>()))
                .Returns(true);

            ///////// Act

            command.Execute(mockTable.Object, mockLogger.Object);

            ///////// Assert

            mockTable.Object.Robot.Location.Orientation.ShouldEqual(Orientation.NORTH);
            mockTable.Object.Robot.Location.Position.X.ShouldEqual(0);
            mockTable.Object.Robot.Location.Position.Y.ShouldEqual(0);
        }

        [TestMethod]
        public void ReportCommand_ShouldLog()
        {
            ///////// Arrange

            ReportCommand command = new ReportCommand();
            var mockTable = new Mock<Table>();
            var mockLogger = new Mock<ILogger>();

            mockTable
                .Setup(t => t.Robot)
                .Returns(new Robot(It.IsAny<int>(), It.IsAny<int>(), Orientation.WEST));

            ///////// Act

            command.Execute(mockTable.Object, mockLogger.Object);

            ///////// Assert

            mockLogger
                .Verify(l => l.Log(It.IsAny<string>()), Times.Once);
        }

        [TestMethod]
        public void MoveCommand_North_ShouldMoveRobot()
        {
            ///////// Arrange

            MoveCommand command = new MoveCommand();
            var mockTable = new Mock<Table>();
            var mockLogger = new Mock<ILogger>();

            mockTable
                .Setup(t => t.Robot)
                .Returns(new Robot(It.IsAny<int>(), It.IsAny<int>(), Orientation.NORTH));
            mockTable
                .Setup(t => t.IsValidPoint(It.IsAny<Point>()))
                .Returns(true);

            ///////// Act

            command.Execute(mockTable.Object, mockLogger.Object);

            ///////// Assert

            mockTable.Object.Robot.Location.Orientation.ShouldEqual(Orientation.NORTH);
            mockTable.Object.Robot.Location.Position.X.ShouldEqual(0);
            mockTable.Object.Robot.Location.Position.Y.ShouldEqual(1);
        }

        [TestMethod]
        public void MoveCommand_East_ShouldMoveRobot()
        {
            ///////// Arrange

            MoveCommand command = new MoveCommand();
            var mockTable = new Mock<Table>();
            var mockLogger = new Mock<ILogger>();

            mockTable
                .Setup(t => t.Robot)
                .Returns(new Robot(It.IsAny<int>(), It.IsAny<int>(), Orientation.EAST));
            mockTable
                .Setup(t => t.IsValidPoint(It.IsAny<Point>()))
                .Returns(true);

            ///////// Act

            command.Execute(mockTable.Object, mockLogger.Object);

            ///////// Assert

            mockTable.Object.Robot.Location.Orientation.ShouldEqual(Orientation.EAST);
            mockTable.Object.Robot.Location.Position.X.ShouldEqual(1);
            mockTable.Object.Robot.Location.Position.Y.ShouldEqual(0);
        }

        [TestMethod]
        public void MoveCommand_South_ShouldMoveRobot()
        {
            ///////// Arrange

            MoveCommand command = new MoveCommand();
            var mockTable = new Mock<Table>();
            var mockLogger = new Mock<ILogger>();

            mockTable
                .Setup(t => t.Robot)
                .Returns(new Robot(It.IsAny<int>(), It.IsAny<int>(), Orientation.SOUTH));
            mockTable
                .Setup(t => t.IsValidPoint(It.IsAny<Point>()))
                .Returns(true);

            ///////// Act

            command.Execute(mockTable.Object, mockLogger.Object);

            ///////// Assert

            mockTable.Object.Robot.Location.Orientation.ShouldEqual(Orientation.SOUTH);
            mockTable.Object.Robot.Location.Position.X.ShouldEqual(0);
            mockTable.Object.Robot.Location.Position.Y.ShouldEqual(-1);
        }

        [TestMethod]
        public void MoveCommand_West_ShouldMoveRobot()
        {
            ///////// Arrange

            MoveCommand command = new MoveCommand();
            var mockTable = new Mock<Table>();
            var mockLogger = new Mock<ILogger>();

            mockTable
                .Setup(t => t.Robot)
                .Returns(new Robot(It.IsAny<int>(), It.IsAny<int>(), Orientation.WEST));
            mockTable
                .Setup(t => t.IsValidPoint(It.IsAny<Point>()))
                .Returns(true);

            ///////// Act

            command.Execute(mockTable.Object, mockLogger.Object);

            ///////// Assert

            mockTable.Object.Robot.Location.Orientation.ShouldEqual(Orientation.WEST);
            mockTable.Object.Robot.Location.Position.X.ShouldEqual(-1);
            mockTable.Object.Robot.Location.Position.Y.ShouldEqual(0);
        }

        /// <summary>
        /// Start from 0,0,SOUTH.
        /// Then try to move robot. 
        /// Should not move the robot because it will fall out the table.
        /// </summary>
        [TestMethod]
        public void MoveCommand_MoveOutsideTable_ShouldNotMove()
        {
            ///////// Arrange

            MoveCommand command = new MoveCommand();
            var mockTable = new Mock<Table>();
            var mockLogger = new Mock<ILogger>();

            mockTable
                .Setup(t => t.Robot)
                .Returns(new Robot(It.IsAny<int>(), It.IsAny<int>(), Orientation.SOUTH));

            ///////// Act

            command.Execute(mockTable.Object, mockLogger.Object);

            ///////// Assert

            mockTable.Object.Robot.Location.Orientation.ShouldEqual(Orientation.SOUTH);
            mockTable.Object.Robot.Location.Position.X.ShouldEqual(0);
            mockTable.Object.Robot.Location.Position.Y.ShouldEqual(0);
        }

        [TestMethod]
        public void MixCommands_PlaceMultipleTimes_ShouldPlaceRobotInNewPosition()
        {
            ///////// Arrange

            Table table = new Table(5);

            PlaceCommand place_1 = new PlaceCommand(5, 5, Orientation.SOUTH);
            MoveCommand move_1 = new MoveCommand();
            PlaceCommand place_2 = new PlaceCommand(1, 1, Orientation.NORTH);
            MoveCommand move_2 = new MoveCommand();

            var mockLogger = new Mock<ILogger>();

            ///////// Act

            place_1.Execute(table, mockLogger.Object);
            move_1.Execute(table, mockLogger.Object);
            place_2.Execute(table, mockLogger.Object);
            move_2.Execute(table, mockLogger.Object);

            ///////// Assert

            table.Robot.Location.Orientation.ShouldEqual(Orientation.NORTH);
            table.Robot.Location.Position.X.ShouldEqual(1);
            table.Robot.Location.Position.Y.ShouldEqual(2);
        }

        [TestMethod]
        public void MixCommands_MoveFirstPlaceSecond_ShouldDiscardAllCommandsBeforePlace()
        {
            ///////// Arrange

            Table table = new Table(5);

            MoveCommand move = new MoveCommand();
            PlaceCommand place = new PlaceCommand(5, 5, Orientation.SOUTH);
            RightCommand right = new RightCommand();

            var mockLogger = new Mock<ILogger>();

            ///////// Act

            move.Execute(table, mockLogger.Object);
            place.Execute(table, mockLogger.Object);
            right.Execute(table, mockLogger.Object);

            ///////// Assert

            table.Robot.Location.Orientation.ShouldEqual(Orientation.WEST);
            table.Robot.Location.Position.X.ShouldEqual(5);
            table.Robot.Location.Position.Y.ShouldEqual(5);
        }

        [TestMethod]
        public void MixCommands_PlaceOutsideTable_AllCommandsShouldBeIgnored()
        {
            ///////// Arrange

            Table table = new Table(5);

            PlaceCommand place = new PlaceCommand(10, 10, Orientation.NORTH);
            MoveCommand move = new MoveCommand();
            LeftCommand left = new LeftCommand();

            var mockLogger = new Mock<ILogger>();

            ///////// Act

            place.Execute(table, mockLogger.Object);
            move.Execute(table, mockLogger.Object);
            left.Execute(table, mockLogger.Object);

            ///////// Assert

            // 
            table.Robot.ShouldBeNull();
        }

        /// <summary>
        /// - Place the robot inside the table at the very end
        /// - move robot. This should not move the robot
        /// - Then send another valid command like left, should move the robot.
        /// </summary>
        [TestMethod]
        public void MixCommands_PlaceInsideTableAndTryMoveOut_AnyMoveOutCommandsShouldBeIgnored()
        {
            ///////// Arrange

            Table table = new Table(5);

            PlaceCommand place = new PlaceCommand(5, 5, Orientation.NORTH);
            MoveCommand move = new MoveCommand();
            LeftCommand left = new LeftCommand();

            var mockLogger = new Mock<ILogger>();

            ///////// Act

            place.Execute(table, mockLogger.Object);
            move.Execute(table, mockLogger.Object);
            left.Execute(table, mockLogger.Object);

            ///////// Assert

            table.Robot.ShouldNotBeNull();
            table.Robot.Location.Orientation.ShouldEqual(Orientation.WEST);
            table.Robot.Location.Position.X.ShouldEqual(5);
            table.Robot.Location.Position.Y.ShouldEqual(5);
        }
    }
}
