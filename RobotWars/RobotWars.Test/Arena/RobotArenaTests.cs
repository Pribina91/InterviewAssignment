using Moq;
using NUnit;
using NUnit.Framework;
using NUnit.Framework.Internal;
using RobotWars.Core.Arena;
using RobotWars.Core.Robot;

namespace RobotWars.Test.Arena
{
    [TestFixture]
    public class RobotArenaTests
    {
        [Test]
        public void Should_CreateArena()
        {
            var arenaFactory = new SimpleRobotArenaFactory(5, 5);
            var arena = new RobotArena(arenaFactory);

            Assert.Pass();
        }

        [Test]
        [TestCase(1, 1)]
        [TestCase(3, 1)]
        [TestCase(1, 3)]
        [TestCase(0, 0)]
        [TestCase(0, 3)]
        [TestCase(3, 0)]
        public void Should_PlaceRobot(int positionX, int positionY)
        {
            Mock<IRobot> robotMock = new Mock<IRobot>();
            robotMock.Setup(m => m.GetPosition()).Returns(new PositionPoint(positionX, positionY));
            robotMock.Setup(m => m.GetDirection()).Returns(Direction.S);

            var arenaFactory = new SimpleRobotArenaFactory(3, 3);
            var arena = new RobotArena(arenaFactory);

            var actual = arena.CheckInitPlaceInArena(robotMock.Object);

            Assert.IsTrue(actual);
        }

        [Test]
        [TestCase(-1, 1)]
        [TestCase(0, -1)]
        [TestCase(4, 1)]
        [TestCase(1, 4)]
        [TestCase(4, 4)]
        public void Should_NOT_PlaceRobot(int positionX, int positionY)
        {
            Mock<IRobot> robotMock = new Mock<IRobot>();
            robotMock.Setup(m => m.GetPosition()).Returns(new PositionPoint(positionX, positionY));
            robotMock.Setup(m => m.GetDirection()).Returns(Direction.S);

            var arenaFactory = new SimpleRobotArenaFactory(3, 3);
            var arena = new RobotArena(arenaFactory);

            var actual = arena.CheckInitPlaceInArena(robotMock.Object);

            Assert.IsFalse(actual);
        }


        [Test]
        [TestCase(1, 1)]
        [TestCase(3, 1)]
        [TestCase(1, 3)]
        [TestCase(0, 0)]
        [TestCase(0, 3)]
        [TestCase(3, 0)]
        public void Should_MoveRobot(int positionX, int positionY)
        {
            var arenaFactory = new SimpleRobotArenaFactory(3, 3);
            var arena = new RobotArena(arenaFactory);

            var actual = arena.CanRobotMoveHere(positionX, positionY);

            Assert.IsTrue(actual);
        }

        [Test]
        [TestCase(-1, 1)]
        [TestCase(0, -1)]
        [TestCase(4, 1)]
        [TestCase(1, 4)]
        [TestCase(4, 4)]
        public void Should_NOT_MoveRobot(int positionX, int positionY)
        {
            var arenaFactory = new SimpleRobotArenaFactory(3, 3);
            var arena = new RobotArena(arenaFactory);

            var actual = arena.CanRobotMoveHere(positionX, positionY);

            Assert.IsFalse(actual);
        }
    }
}