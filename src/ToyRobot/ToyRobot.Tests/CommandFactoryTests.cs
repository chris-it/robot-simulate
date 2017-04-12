using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ToyRobot.Common;
using ToyRobot.Core;
using Should;

namespace ToyRobot.Tests
{
    [TestClass]
    public class CommandFactoryTests
    {
        [TestMethod]
        public void InvalidCommandLine_ShouldReturnNullCommand()
        {
            ///////// Arrange

            var mockCommandLine = new Mock<InputCommandLine>();
            mockCommandLine.Setup(c => c.IsValid).Returns(false);
            
            CommandFactory factory = new CommandFactory();

            ///////// Act

            ICommand command = factory.CreateCommand(mockCommandLine.Object);

            ///////// Assert
            command.ShouldBeNull();
        }

        [TestMethod]
        public void NullCommandLine_ShouldReturnNullCommand()
        {
            ///////// Arrange

            InputCommandLine commandLine = null;

            CommandFactory factory = new CommandFactory();

            ///////// Act

            ICommand command = factory.CreateCommand(commandLine);

            ///////// Assert
            command.ShouldBeNull();
        }

        [TestMethod]
        public void PlaceCommandLine_ShouldReturnPlaceCommand()
        {
            ///////// Arrange

            var mockCommandLine = new Mock<InputCommandLine>();
            mockCommandLine.Setup(c => c.CommandType).Returns(CommandType.PLACE);
            mockCommandLine.Setup(c => c.X).Returns(It.IsAny<int>());
            mockCommandLine.Setup(c => c.Y).Returns(It.IsAny<int>());
            mockCommandLine.Setup(c => c.Orientation).Returns(It.IsAny<Orientation>());
            mockCommandLine.Setup(c => c.IsValid).Returns(true);

            CommandFactory factory = new CommandFactory();

            ///////// Act

            ICommand command = factory.CreateCommand(mockCommandLine.Object);

            ///////// Assert
            command.ShouldBeType(typeof(PlaceCommand));
            PlaceCommand placeCommand = (PlaceCommand)command;

            placeCommand.X.ShouldEqual(mockCommandLine.Object.X);
            placeCommand.Y.ShouldEqual(mockCommandLine.Object.Y);
            placeCommand.Orientation.ShouldEqual(mockCommandLine.Object.Orientation);
        }

        [TestMethod]
        public void RightCommandLine_ShouldReturnRightCommand()
        {
            ///////// Arrange

            var mockCommandLine = new Mock<InputCommandLine>();
            mockCommandLine.Setup(c => c.CommandType).Returns(CommandType.RIGHT);
            mockCommandLine.Setup(c => c.IsValid).Returns(true);

            CommandFactory factory = new CommandFactory();

            ///////// Act

            ICommand command = factory.CreateCommand(mockCommandLine.Object);

            ///////// Assert
            command.ShouldBeType(typeof(RightCommand));
        }

        [TestMethod]
        public void LeftCommandLine_ShouldReturnLeftCommand()
        {
            ///////// Arrange

            var mockCommandLine = new Mock<InputCommandLine>();
            mockCommandLine.Setup(c => c.CommandType).Returns(CommandType.LEFT);
            mockCommandLine.Setup(c => c.IsValid).Returns(true);

            CommandFactory factory = new CommandFactory();

            ///////// Act

            ICommand command = factory.CreateCommand(mockCommandLine.Object);

            ///////// Assert
            command.ShouldBeType(typeof(LeftCommand));
        }

        [TestMethod]
        public void MoveCommandLine_ShouldReturnMoveCommand()
        {
            ///////// Arrange

            var mockCommandLine = new Mock<InputCommandLine>();
            mockCommandLine.Setup(c => c.CommandType).Returns(CommandType.MOVE);
            mockCommandLine.Setup(c => c.IsValid).Returns(true);

            CommandFactory factory = new CommandFactory();

            ///////// Act

            ICommand command = factory.CreateCommand(mockCommandLine.Object);

            ///////// Assert
            command.ShouldBeType(typeof(MoveCommand));
        }

        [TestMethod]
        public void ReportCommandLine_ShouldReturnReportCommand()
        {
            ///////// Arrange

            var mockCommandLine = new Mock<InputCommandLine>();
            mockCommandLine.Setup(c => c.CommandType).Returns(CommandType.REPORT);
            mockCommandLine.Setup(c => c.IsValid).Returns(true);

            CommandFactory factory = new CommandFactory();

            ///////// Act

            ICommand command = factory.CreateCommand(mockCommandLine.Object);

            ///////// Assert
            command.ShouldBeType(typeof(ReportCommand));
        }
    }
}
