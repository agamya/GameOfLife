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
    ///This is a test class for GenerationTest and is intended
    ///to contain all GenerationTest Unit Tests
    ///</summary>
    [TestClass()]
    public class GenerationTest
    {
        private readonly AutoMocker _mocker = new AutoMocker();
        private static IGrid _grid;
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
        ///A test for Generation Constructor
        ///</summary>
        [TestMethod()]
        public void GenerationConstructorTest()
        {
            var instance = _mocker.CreateInstance<Generation>();
            Assert.IsNotNull(instance);
        }

        /// <summary>
        ///A test for GetNextGeneration
        ///</summary>
        [TestMethod()]
        public void GetNextGenerationTest()
        {
            var gameRules = new Mock<IGameRules>();
            var newGrid = _mocker.CreateInstance<Generation>().GetNextGeneration(_grid,gameRules.Object);
            var cell = newGrid.GetCurrentCellInfo(new Position(2, 2));
            Assert.IsTrue(!cell.Alive);
        }
    }
}
