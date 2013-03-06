using GameOfLife.Core;
using GameOfLife.Data;
using GameOfLife.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using GameOfLife.Contracts;
using System.Collections.Generic;
using Moq.AutoMock;

namespace GameOfLife.Test
{


    /// <summary>
    ///This is a test class for GridTest and is intended
    ///to contain all GridTest Unit Tests
    ///</summary>
    [TestClass()]
    public class GridTest
    {

        private readonly AutoMocker _mocker = new AutoMocker();
        private TestContext testContextInstance;
        private static IGrid _grid;
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
            _grid= Helper.Helper.PreConfiguredGrid();
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
        ///A test for Grid Constructor
        ///</summary>
        [TestMethod()]
        public void GridConstructorTest()
        {
            var instance = _mocker.CreateInstance<Grid>();
            Assert.IsNotNull(instance);
        }

        /// <summary>
        ///A test for Copy
        ///</summary>
        [TestMethod()]
        public void CopyTest()
        {
            var newGrid = _grid.Copy(_grid);

            var liveCell = newGrid.GetCurrentCellInfo(new Position(2, 2));
            var deadCell = newGrid.GetCurrentCellInfo(new Position(1, 1));
            Assert.AreEqual(newGrid.GridSize.Rows, 4);
            Assert.IsTrue(liveCell.Alive);
            Assert.IsTrue(!deadCell.Alive);
        }

        /// <summary>
        ///A test for GetAllCurrentCellInfo
        ///</summary>
        [TestMethod()]
        public void GetAllCurrentCellInfoTest()
        {
            var allCells = _grid.GetAllCurrentCellInfo();
            Assert.IsNotNull(allCells);
        }

        /// <summary>
        ///A test for GetCurrentCellInfo
        ///</summary>
        [TestMethod()]
        public void GetCurrentCellInfoTest()
        {
            var liveCell = _grid.GetCurrentCellInfo(new Position(2, 2));
            var deadCell = _grid.GetCurrentCellInfo(new Position(1, 1));
            Assert.IsTrue(liveCell.Alive);
            Assert.IsTrue(!deadCell.Alive);
        }

        /// <summary>
        ///A test for Initialize
        ///</summary>
        [TestMethod()]
        public void InitializeTest()
        {
            var cell = new List<ICell> { new Cell(new Position(1, 1), true) };
            _grid.Initialize(cell);
            var liveCell = _grid.GetCurrentCellInfo(new Position(1, 1));
            Assert.IsTrue(liveCell.Alive);
        }


        /// <summary>
        ///A test for MakeCell
        ///</summary>
        [TestMethod()]
        public void MakeCellTest()
        {
            var cell = new Cell(new Position(2, 1), true);
            _grid.MakeCell(cell);
            Assert.IsTrue(_grid.GetCurrentCellInfo(cell.Position).Alive);
        }

        /// <summary>
        ///A test for GridSize
        ///</summary>
        [TestMethod()]
        public void GridSizeTest()
        {
            var gridSize = _grid.GridSize;
            Assert.AreSame(gridSize, _grid.GridSize);
        }
    }
}
