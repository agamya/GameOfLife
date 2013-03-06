using GameOfLife.Data;
using GameOfLife.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using GameOfLife.Contracts;
using Moq;
using Moq.AutoMock;
namespace GameOfLife.Test
{


    /// <summary>
    ///This is a test class for GridStorageTest and is intended
    ///to contain all GridStorageTest Unit Tests
    ///</summary>
    [TestClass()]
    public class GridStorageTest
    {

        private readonly AutoMocker _mocker = new AutoMocker();
        private TestContext testContextInstance;
        private static GridStorage gridStorage;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        [ClassInitialize()]
        public static void MyClassInitialize(TestContext testContext)
        {
            gridStorage = new GridStorage(new GridSize(4, 3));
            gridStorage.SetCell(new GridPosition(new Position(2, 2)), true);
            gridStorage.SetCell(new GridPosition(new Position(3, 1)), true);
        }
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///A test for GridStorage Constructor
        ///</summary>
        [TestMethod()]
        public void GridStorageConstructorTest()
        {
            Assert.AreEqual(gridStorage.Rows, 4);
            Assert.AreEqual(gridStorage.Columns, 3);
        }

        /// <summary>
        ///A test for GetCell
        ///</summary>
        [TestMethod()]
        public void GetCellTest()
        {
            var liveCell = gridStorage.GetCell(new GridPosition(new Position(2, 2)));
            var deadCell = gridStorage.GetCell(new GridPosition(new Position(1, 1)));

            Assert.IsTrue(liveCell.Alive);
            Assert.IsTrue(!deadCell.Alive);
        }

        /// <summary>
        ///A test for IsCellAlive
        ///</summary>
        [TestMethod()]
        public void IsCellAliveTest()
        {
            Assert.IsTrue(gridStorage.IsCellAlive(new GridPosition(new Position(2,2))));
        }

        /// <summary>
        ///A test for SetCell
        ///</summary>
        [TestMethod()]
        public void SetCellTest()
        {
            var gridPosition = new GridPosition(new Position(3, 1));
            gridStorage.SetCell(gridPosition, true);
            Assert.IsTrue(gridStorage.IsCellAlive(gridPosition));

        }
    }
}
