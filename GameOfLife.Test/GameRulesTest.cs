using GameOfLife.Core;
using GameOfLife.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using GameOfLife.Contracts;
using Moq;
using Moq.AutoMock;

namespace GameOfLife.Test
{
    
    
    /// <summary>
    ///This is a test class for GameRulesTest and is intended
    ///to contain all GameRulesTest Unit Tests
    ///</summary>
    [TestClass()]
    public class GameRulesTest
    {

        private static IGrid _grid;
        
        private readonly AutoMocker _mocker = new AutoMocker();
        private TestContext testContextInstance;

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
            _grid = Helper.Helper.PreConfiguredGrid();
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
        ///A test for GameRules Constructor
        ///</summary>
        [TestMethod()]
        public void GameRulesConstructorTest()
        {
            var instance = _mocker.CreateInstance<GameRules>();
            Assert.IsNotNull(instance);
        }

        /// <summary>
        ///A test for IsOverCrowded
        ///</summary>
        [TestMethod()]
        public void IsOverCrowdedTest()
        {
            var cell =_grid.GetCurrentCellInfo(new Position(2, 1));
            var gameRule = new Mock<IGameRules>().Object.IsOverCrowded(_grid,cell);
            Assert.IsTrue(!gameRule);
        }

        /// <summary>
        ///A test for IsReproduciable
        ///</summary>
        [TestMethod()]
        public void IsReproduciableTest()
        {
            var cell = _grid.GetCurrentCellInfo(new Position(2, 1));
            var gameRule = new Mock<IGameRules>().Object.IsReproduciable(_grid, cell);
            Assert.IsTrue(!gameRule);
        }

        /// <summary>
        ///A test for IsSurvivable
        ///</summary>
        [TestMethod()]
        public void IsSurvivableTest()
        {
            var cell = _grid.GetCurrentCellInfo(new Position(2, 1));
            var gameRule = new Mock<IGameRules>().Object.IsSurvivable(_grid, cell);
            Assert.IsTrue(!gameRule);
        }

        /// <summary>
        ///A test for IsUnderPopulated
        ///</summary>
        [TestMethod()]
        public void IsUnderPopulatedTest()
        {
            var cell = _grid.GetCurrentCellInfo(new Position(2, 1));
            var gameRule = new Mock<IGameRules>().Object.IsUnderPopulated(_grid, cell);
            Assert.IsTrue(!gameRule);
        }

        /// <summary>
        ///A test for WillBeAliveInNextGeneration
        ///</summary>
        [TestMethod()]
        public void WillBeAliveInNextGenerationTest()
        {
            var cell = _grid.GetCurrentCellInfo(new Position(2, 1));
            var gameRule = new Mock<IGameRules>().Object.WillBeAliveInNextGeneration(_grid, cell);
            Assert.IsTrue(!gameRule);
        }
    }
}
