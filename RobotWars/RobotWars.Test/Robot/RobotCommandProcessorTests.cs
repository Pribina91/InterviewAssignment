using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using NUnit.Framework.Internal;
using RobotWars.Core.Arena;
using RobotWars.Core.Robot;

namespace RobotWars.Test.Robot
{
    [TestFixture]
    public class RobotCommandProcessorTests
    {
        public Mock<IRobotArena> CreateDefaultArena()
        {
            var mockRobotArena = new Mock<IRobotArena>();
            mockRobotArena.Setup(m => m.CheckInitPlaceInArena(It.IsAny<IRobot>())).Returns(true);
            mockRobotArena.Setup(m => m.CanRobotMoveHere(It.IsAny<int>(), It.IsAny<int>())).Returns(true);
            return mockRobotArena;
        }

        [Test()]
        [TestCase(null)]
        [TestCase("")]
        [TestCase("1 1 ")]
        [TestCase("1 1 N dsa")]
        [TestCase("a a N")]
        [TestCase("1 a N")]
        [TestCase("a 2 N")]
        [TestCase("2 2 22")]
        public void Should_PlaceRobotInArena_ThrowException_For_Command(string input)
        {
            Mock<IRobotArena> mockRobotArena = CreateDefaultArena();
            var processor = new RobotCommandProcessor(mockRobotArena.Object);

            Assert.Throws(
                Is.TypeOf<ArgumentException>().With.Property("ParamName").EqualTo("command"),
                () => processor.PlaceRobotInArena(input));
        }

        [Test()]
        [TestCase("0 0 N")]
        [TestCase("2 2 N")]
        [TestCase("2 2 E")]
        [TestCase("2 2 S")]
        [TestCase("2 2 W")]
        public void Should_PlaceRobotInArena_Place_For_Command(string input)
        {
            Mock<IRobotArena> mockRobotArena = CreateDefaultArena();
            var processor = new RobotCommandProcessor(mockRobotArena.Object);

            processor.PlaceRobotInArena(input);
            Assert.Pass();
        }

        [Test()]
        [TestCase(null)]
        [TestCase("")]
        [TestCase("lmmmg")]
        [TestCase("RLMMN")]
        public void Should_MoveRobotAroundArena_ThrowException_For_Command(string input)
        {
            Mock<IRobotArena> mockRobotArena = CreateDefaultArena();
            var processor = new RobotCommandProcessor(mockRobotArena.Object);
            processor.PlaceRobotInArena("0 0 N");
            Assert.Throws(
                Is.TypeOf<ArgumentException>().With.Property("ParamName").EqualTo("command"),
                () => processor.MoveRobotAroundArena(input));
        }

        [Test()]
        [TestCase("L")]
        [TestCase("R")]
        [TestCase("M")]
        [TestCase("LLLLL")]
        [TestCase("RRRRR")]
        [TestCase("MLR")]
        public void Should_MoveRobotAroundArena_Move_For_Command(string input)
        {
            Mock<IRobotArena> mockRobotArena = CreateDefaultArena();
            var processor = new RobotCommandProcessor(mockRobotArena.Object);
            processor.PlaceRobotInArena("0 0 N");
            processor.MoveRobotAroundArena(input);
            Assert.Pass();
        }

        [Test()]
        [TestCase("L", "1 1 W")]
        [TestCase("LL", "1 1 S")]
        [TestCase("R", "1 1 E")]
        [TestCase("M", "1 2 N")]
        [TestCase("MM", "1 3 N")]
        [TestCase("MMR", "1 3 E")]
        [TestCase("MMRL", "1 3 N")]
        [TestCase("MMRLL", "1 3 W")]
        [TestCase("MMRLLL", "1 3 S")]
        [TestCase("MMRLLLM", "1 2 S")]
        [TestCase("MMRLLLMR", "1 2 W")]
        [TestCase("MMRLLLMRM", "0 2 W")]
        [TestCase("MMRLLLMRML", "0 2 S")]
        [TestCase("MMRLLLMRMLM", "0 1 S")]
        public void Should_MoveRobotAroundArena_MoveMulti_For_Command(string input, string output)
        {
            Mock<IRobotArena> mockRobotArena = CreateDefaultArena();
            var processor = new RobotCommandProcessor(mockRobotArena.Object);
            processor.PlaceRobotInArena("1 1 N");
            var actualOutput = processor.MoveRobotAroundArena(input);
            Assert.AreEqual(output, actualOutput);
        }

        [Test()]
        [TestCase("L")]
        public void Should_MoveRobotAroundArena_Throws_Exception_RobotNotPlaced(string input)
        {
            Mock<IRobotArena> mockRobotArena = CreateDefaultArena();
            var processor = new RobotCommandProcessor(mockRobotArena.Object);

            Assert.Throws(
                Is.TypeOf<ArgumentException>().With.Property("ParamName").EqualTo("robot"),
                () => processor.MoveRobotAroundArena(input));
        }
    }
}