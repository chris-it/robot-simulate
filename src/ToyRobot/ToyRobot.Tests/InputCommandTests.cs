using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ToyRobot.Common;
using Should;

namespace ToyRobot.Tests
{
    [TestClass]
    public class InputCommandTests
    {
        [TestMethod]
        public void PlaceCommand_ShouldParse()
        {
            ///////// Arrange

            string command = "PLACE 1,2,NORTH";

            ///////// Act

            InputCommandLine commandLine = InputCommandLine.ParseCommand(command);

            ///////// Assert
            commandLine.CommandType.ShouldEqual(CommandType.PLACE);
            commandLine.X.ShouldEqual(1);
            commandLine.Y.ShouldEqual(2);
            commandLine.Orientation.ShouldEqual(Orientation.NORTH);
            commandLine.IsValid.ShouldBeTrue();
        }

        [TestMethod]
        public void LeftCommand_ShouldParse()
        {
            ///////// Arrange

            string command = "LEFT";

            ///////// Act

            InputCommandLine commandLine = InputCommandLine.ParseCommand(command);

            ///////// Assert
            commandLine.CommandType.ShouldEqual(CommandType.LEFT);
            commandLine.IsValid.ShouldBeTrue();
        }

        [TestMethod]
        public void RightCommand_ShouldParse()
        {
            ///////// Arrange

            string command = "  RIGHT ";

            ///////// Act

            InputCommandLine commandLine = InputCommandLine.ParseCommand(command);

            ///////// Assert
            commandLine.CommandType.ShouldEqual(CommandType.RIGHT);
            commandLine.IsValid.ShouldBeTrue();
        }

        [TestMethod]
        public void MoveCommand_ShouldParse()
        {
            ///////// Arrange

            string command = "MOVE";

            ///////// Act

            InputCommandLine commandLine = InputCommandLine.ParseCommand(command);

            ///////// Assert
            commandLine.CommandType.ShouldEqual(CommandType.MOVE);
            commandLine.IsValid.ShouldBeTrue();
        }

        [TestMethod]
        public void PlaceCommand_WithoutOtherParameters_ShouldDefaultToZeroAndNorth()
        {
            ///////// Arrange

            string command = "PLACE"; //Place without coordinates will be invalid

            ///////// Act

            InputCommandLine commandLine = InputCommandLine.ParseCommand(command);

            ///////// Assert
            commandLine.CommandType.ShouldEqual(CommandType.PLACE);
            commandLine.X.ShouldEqual(0);
            commandLine.Y.ShouldEqual(0);
            commandLine.Orientation.ShouldEqual(Orientation.NORTH);
            commandLine.IsValid.ShouldBeTrue();
        }

        [TestMethod]
        public void InvalidCommand_ShouldBeInvalid()
        {
            ///////// Arrange

            string command = "OTHER"; //Place without coordinates will be invalid

            ///////// Act

            InputCommandLine commandLine = InputCommandLine.ParseCommand(command);

            ///////// Assert
            commandLine.IsValid.ShouldBeFalse();
        }

        [TestMethod]
        public void EmptyCommand_ShouldBeInvalid()
        {
            ///////// Arrange

            string command = ""; //Place without coordinates will be invalid

            ///////// Act

            InputCommandLine commandLine = InputCommandLine.ParseCommand(command);

            ///////// Assert
            commandLine.IsValid.ShouldBeFalse();
        }
    }
}
