using Microsoft.VisualStudio.TestPlatform.TestHost;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NASARover;

namespace RoverTest1
{
    [TestClass]
    public class UnitTest1
    {
        //Positive testcase with all valid data
        [TestMethod]
        public void SimpleMove()
        {
            int xPosition = 0;
            int yPosition = 0;
            char destination = 'Q';
            Rover r = new Rover(5, 5, 1, 2, 'N', "LMRM");
            r.MoveRoverToDestination();
            r.GetFinalDestination(ref xPosition, ref yPosition, ref destination);
            //for above test output should be 0 3 N
            Assert.AreEqual(0, xPosition);
            Assert.AreEqual(3, yPosition);
            Assert.AreEqual('N', destination);
        }
        //Negative testing with x y coordinates out of range
        [TestMethod]
        public void InvalidXYCoordinates()
        {
            int xPosition = 0;
            int yPosition = 0;
            char destination = 'Q';
            bool flag = true;
            try
            {
                Rover r = new Rover(5, 5, 6, 9, 'N', "LMRM");
            }
            catch (InvalidDataException e)
            {
                flag = false;
            }
            Assert.IsFalse(flag);            
        }

        //Negative testing with x y coordinates out of range
        [TestMethod]
        public void InvalidDirection()
        {
            int xPosition = 0;
            int yPosition = 0;
            char destination = 'Q';
            bool flag = true;
            try
            {
                Rover r = new Rover(5, 5, 3, 2, 'r', "LMRM");
            }
            catch (InvalidDataException e)
            {
                flag = false;
            }
            Assert.IsFalse(flag);
        }
        //Positive testcase with all valid data
        [TestMethod]
        public void ValidData1()
        {
            int xPosition = 0;
            int yPosition = 0;
            char destination = 'Q';
            Rover r = new Rover(5, 5, 1, 2, 'N', "LMLMLMLMM");
            r.MoveRoverToDestination();
            r.GetFinalDestination(ref xPosition, ref yPosition, ref destination);
            //for above test output should be 1 3 N
            Assert.AreEqual(1, xPosition);
            Assert.AreEqual(3, yPosition);
            Assert.AreEqual('N', destination);
        }
        //Positive testcase with all valid data
        [TestMethod]
        public void ValidData2()
        {
            int xPosition = 0;
            int yPosition = 0;
            char destination = 'Q';
            Rover r = new Rover(5, 5, 3, 3, 'E', "MMRMMRMRRM");
            r.MoveRoverToDestination();
            r.GetFinalDestination(ref xPosition, ref yPosition, ref destination);
            //for above test output should be 5 1 E
            Assert.AreEqual(5, xPosition);
            Assert.AreEqual(1, yPosition);
            Assert.AreEqual('E', destination);
        }

        //Positive testcase with all valid data
        [TestMethod]
        public void ValidData3()
        {
            int xPosition = 0;
            int yPosition = 0;
            char destination = 'Q';
            Rover r = new Rover(6, 6, 2, 1, 'W', "RMMLMRRMMMMLMMM");
            r.MoveRoverToDestination();
            r.GetFinalDestination(ref xPosition, ref yPosition, ref destination);
            //for above test output should be 5 6 N
            Assert.AreEqual(5, xPosition);
            Assert.AreEqual(6, yPosition);
            Assert.AreEqual('N', destination);
        }

        //Positive testcase with all valid data
        [TestMethod]
        public void ValidData4()
        {
            int xPosition = 0;
            int yPosition = 0;
            char destination = 'Q';
            Rover r = new Rover(5, 5, 4, 4, 'W', "MLMLMRML");
            r.MoveRoverToDestination();
            r.GetFinalDestination(ref xPosition, ref yPosition, ref destination);
            //for above test output should be 4 2 E
            Assert.AreEqual(4, xPosition);
            Assert.AreEqual(2, yPosition);
            Assert.AreEqual('E', destination);
        }

        // Negative Test with invalid moves except(L,R,M) 
        [TestMethod]
        public void InvalidMovementPath()
        {
            int xPosition = 0;
            int yPosition = 0;
            char destination = 'Q';
            bool flag = true;
            Rover r = new Rover(5, 5, 1, 2, 'N', "LMRQQM");
            flag = r.MoveRoverToDestination();
            Assert.IsFalse(flag); 
        }

        //Negative Testing with no further moves left in the graph
        [TestMethod]
        public void OutofBoundMove() 
        { 
            int xPosition = 0;
            int yPosition = 0;
            char destination = 'Q';
            bool flag = true;
            Rover r = new Rover(5, 5, 1, 2, 'N', "LMMMMMMMM");
            flag = r.MoveRoverToDestination();
            Assert.IsFalse(flag);
        }

        //Positive testcase Multiple Rover with valid data
        [TestMethod]
        public void MultipleRoverMove()
        {
            int xPosition = 0;
            int yPosition = 0;
            char destination = 'Q';
            Rover r1 = new Rover(9, 5, 4, 4, 'W', "LRLRMM");
            r1.MoveRoverToDestination();
            r1.GetFinalDestination(ref xPosition, ref yPosition, ref destination);
            //for above test output should be 2 4 W
            Assert.AreEqual(2, xPosition);
            Assert.AreEqual(4, yPosition);
            Assert.AreEqual('W', destination);
            int rover2XPosition = 0;
            int rover2YPosition = 0;
            char R2destination = 'Q';
            Rover r2 = new Rover(10, 10, 4, 4, 'E', "MLMLMRML");
            r2.MoveRoverToDestination();
            r2.GetFinalDestination(ref rover2XPosition, ref rover2YPosition, ref R2destination);
            //for above test output should be 4 6 W
            Assert.AreEqual(4, rover2XPosition);
            Assert.AreEqual(6, rover2YPosition);
            Assert.AreEqual('W', R2destination);
        }

        //Positive testcase with all valid data
        [TestMethod]
        public void MultipleRoverOneFailOnePass()
        {
            int xPosition = 0;
            int yPosition = 0;
            char destination = 'Q';
            bool flag = true;
            try
            {
                Rover r1 = new Rover(5, 5, 3, 2, 'r', "LMRM");
            }
            catch (InvalidDataException e)
            {
                flag = false;
            }
            Assert.IsFalse(flag);
           
            int rover2XPosition = 0;
            int rover2YPosition = 0;
            char R2destination = 'Q';
            Rover r2 = new Rover(10, 10, 4, 4, 'E', "MLMLMRML");
            r2.MoveRoverToDestination();
            r2.GetFinalDestination(ref rover2XPosition, ref rover2YPosition, ref R2destination);
            //for above test output should be 4 6 W
            Assert.AreEqual(4, rover2XPosition);
            Assert.AreEqual(6, rover2YPosition);
            Assert.AreEqual('W', R2destination);
        }


    }
}