using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RobotApp;

namespace robotTest
{
    [TestClass]
    public class robotTest
    {
        [TestMethod]
        public void TestUnPlacedRobot()
        {
            robotPresenter p = new robotPresenter(5);
            string result;

            Assert.AreEqual(p.PosX, 0);
            Assert.AreEqual(p.PosY, 0);
            Assert.AreEqual(p.PosFace, robotPresenter.direction.North);

            result = p.Command("MOVE");
            Assert.AreEqual(result, "Robot not placed");
        }

        [TestMethod]
        public void TestPlacedRobot()
        {
            robotPresenter p = new robotPresenter(5);
            p.Command("PLACE 2,1,NORTH");

            Assert.AreEqual(p.PosX, 2);
            Assert.AreEqual(p.PosY, 1);
            Assert.AreEqual(p.PosFace, robotPresenter.direction.North);
        }

        [TestMethod]
        public void TestReport()
        {
            robotPresenter p = new robotPresenter(5);
            string result;
            p.Command("PLACE 2,1,NORTH");
            result = p.Command("REPORT");

            Assert.AreEqual(result, "2, 1, North");
            Assert.AreEqual(p.PosX, 2);
            Assert.AreEqual(p.PosY, 1);
            Assert.AreEqual(p.PosFace, robotPresenter.direction.North);
        }

        [TestMethod]
        public void TestMovedNorth()
        {
            robotPresenter p = new robotPresenter(5);
            p.Command("PLACE 2,2,NORTH");
            p.Command("MOVE");

            Assert.AreEqual(p.PosX, 2);
            Assert.AreEqual(p.PosY, 3);
            Assert.AreEqual(p.PosFace, robotPresenter.direction.North);
        }

        [TestMethod]
        public void TestMovedSouth()
        {
            robotPresenter p = new robotPresenter(5);
            p.Command("PLACE 2,2,SOUTH");
            p.Command("MOVE");

            Assert.AreEqual(p.PosX, 2);
            Assert.AreEqual(p.PosY, 1);
            Assert.AreEqual(p.PosFace, robotPresenter.direction.South);
        }

        [TestMethod]
        public void TestMovedEast()
        {
            robotPresenter p = new robotPresenter(5);
            p.Command("PLACE 2,2,EAST");
            p.Command("MOVE");

            Assert.AreEqual(p.PosX, 3);
            Assert.AreEqual(p.PosY, 2);
            Assert.AreEqual(p.PosFace, robotPresenter.direction.East);
        }

        [TestMethod]
        public void TestMovedWest()
        {
            robotPresenter p = new robotPresenter(5);
            p.Command("PLACE 2,2,WEST");
            p.Command("MOVE");

            Assert.AreEqual(p.PosX, 1);
            Assert.AreEqual(p.PosY, 2);
            Assert.AreEqual(p.PosFace, robotPresenter.direction.West);
        }

        [TestMethod]
        public void TestLeftRotatedRobot()
        {
            robotPresenter p = new robotPresenter(5);
            p.Command("PLACE 2,2,NORTH");
            p.Command("LEFT");

            Assert.AreEqual(p.PosX, 2);
            Assert.AreEqual(p.PosY, 2);
            Assert.AreEqual(p.PosFace, robotPresenter.direction.West);
        }

        [TestMethod]
        public void TestRightRotatedRobot()
        {
            robotPresenter p = new robotPresenter(5);
            p.Command("PLACE 2,2,NORTH");
            p.Command("RIGHT");

            Assert.AreEqual(p.PosX, 2);
            Assert.AreEqual(p.PosY, 2);
            Assert.AreEqual(p.PosFace, robotPresenter.direction.East);
        }

        [TestMethod]
        public void TestOutOfBoundsXMin()
        {
            robotPresenter p = new robotPresenter(5);
            string result;

            p.Command("PLACE 1,1,WEST");
            p.Command("MOVE");

            Assert.AreEqual(p.PosX, 0);
            Assert.AreEqual(p.PosY, 1);
            Assert.AreEqual(p.PosFace, robotPresenter.direction.West);

            result = p.Command("MOVE");

            Assert.AreEqual(result, "Invalid Move");
            Assert.AreEqual(p.PosX, 0);
            Assert.AreEqual(p.PosY, 1);
            Assert.AreEqual(p.PosFace, robotPresenter.direction.West);
        }

        [TestMethod]
        public void TestOutOfBoundsXMax()
        {
            robotPresenter p = new robotPresenter(5);
            string result;

            p.Command("PLACE 3,1,EAST");
            p.Command("MOVE");

            Assert.AreEqual(p.PosX, 4);
            Assert.AreEqual(p.PosY, 1);
            Assert.AreEqual(p.PosFace, robotPresenter.direction.East);

            result = p.Command("MOVE");

            Assert.AreEqual(result, "Invalid Move");
            Assert.AreEqual(p.PosX, 4);
            Assert.AreEqual(p.PosY, 1);
            Assert.AreEqual(p.PosFace, robotPresenter.direction.East);
        }

        [TestMethod]
        public void TestOutOfBoundsYMin()
        {
            robotPresenter p = new robotPresenter(5);
            string result;

            p.Command("PLACE 1,1,SOUTH");
            p.Command("MOVE");

            Assert.AreEqual(p.PosX, 1);
            Assert.AreEqual(p.PosY, 0);
            Assert.AreEqual(p.PosFace, robotPresenter.direction.South);

            result = p.Command("MOVE");

            Assert.AreEqual(result, "Invalid Move");
            Assert.AreEqual(p.PosX, 1);
            Assert.AreEqual(p.PosY, 0);
            Assert.AreEqual(p.PosFace, robotPresenter.direction.South);
        }

        [TestMethod]
        public void TestOutOfBoundsYMax()
        {
            robotPresenter p = new robotPresenter(5);
            string result;

            p.Command("PLACE 1,3,NORTH");
            p.Command("MOVE");

            Assert.AreEqual(p.PosX, 1);
            Assert.AreEqual(p.PosY, 4);
            Assert.AreEqual(p.PosFace, robotPresenter.direction.North);

            result = p.Command("MOVE");

            Assert.AreEqual(result, "Invalid Move");
            Assert.AreEqual(p.PosX, 1);
            Assert.AreEqual(p.PosY, 4);
            Assert.AreEqual(p.PosFace, robotPresenter.direction.North);
        }
    }
}
