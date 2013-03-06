#region File Header

//  ***********************************************************************
// Project           : GameOfLife.Console
// Author           : Ajay Singh
// Created          : 06/03/2013
// 
// Last Modified By : Ajay Singh
// Last Modified On : 06/03/2013
// ***********************************************************************
//  <copyright file="GameOfLife.cs" company="Ajay Singh">
//      Copyright (c) Ajay Singh. All rights reserved.
// </copyright>
// <summary></summary>
//  ***********************************************************************

#endregion

#region

using System;
using System.Collections.Generic;
using System.Diagnostics;
using GameOfLife.Contracts;
using GameofLife.Logging;

#endregion

namespace GameOfLife.Console.Helpers
{
    public class GameOfLife
    {
        #region Private Fields

        private readonly IGameRules _gameRules;

        /// <summary>
        ///     Variable to store Grid instance
        /// </summary>
        private IGrid _grid;

        /// <summary>
        ///     Size of Grid to work
        /// </summary>
        private IGridSize _gridSize;

        /// <summary>
        ///     Live cells information for first time from user to start the game
        /// </summary>
        private IEnumerable<ICell> _liveCells;

        /// <summary>
        ///     Total number of generations
        /// </summary>
        private int _totalGenerations;

        #endregion

        #region Construtor

        public GameOfLife(IGameRules gameRules)
        {
            _gameRules = gameRules;
        }

        #endregion

        #region Public Methods

        /// <summary>
        ///     Start the Game of Life App
        /// </summary>
        public void Start()
        {
            do
            {
                PrintInstructionsToScreen();

                // Input for gridsize
                while (!TakeGridSizeFromUser())
                {
                    PrintInvalidInputMessage();
                }
                //Input for live cell
                while (!TakeLiveCellsFromUser())
                {
                    PrintInvalidInputMessage();
                }
                while (!TakeGenerationNumbersFromUser())
                {
                    PrintInvalidInputMessage();
                }
                System.Console.WriteLine("Following grid will be used:");
                //Create Grid
                _grid = GridHelper.CreateGrid(_gridSize, _liveCells);
                //Displaying the grid on UI
                System.Console.WriteLine(_grid.ToConsoleFormattedString());
                System.Console.WriteLine("Press Enter key to continue.");
                System.Console.ReadLine();
                //Start the generations
                StartGenerations();
            } while (GetUserConfirmation());
        }

        #endregion

        #region Private Methods

        private void StartGenerations()
        {
            for (int count = 0; count < _totalGenerations; count++)
            {
                System.Console.WriteLine("Grid after {0} evolution(s).\nPress enter to continue", count + 1);
                System.Console.WriteLine(GridHelper.GetNextGenerationGrid(_grid, _gameRules).ToConsoleFormattedString());
                System.Console.ReadLine();
            }
        }

        private void PrintInvalidInputMessage()
        {
            System.Console.WriteLine("Invalid input. Please enter again");
        }

        private void PrintInstructionsToScreen()
        {
            System.Console.WriteLine("---------------------Welcome to The Game Of Life---------------------------\n");
            System.Console.WriteLine(
                "To start you will have to specify the size of the grid,\nthe initial live cells in the grid and\nthe number of times you want the grid to evolve.\n");
            System.Console.WriteLine("Specify the Grid Size in the format : RowNumber,ColunmNumber for e.g 5,5 \n");
            System.Console.WriteLine(
                "Specify the live cells in the format : RowIndex,Colunmindex | RowIndex,Colunmindex for e.g 2,2 | 3,1\n");
            System.Console.WriteLine("A live cell is represented by X and ");
            System.Console.WriteLine("A dead cell is represented by - \n");
            System.Console.WriteLine("Please follow the below messages carefully to execute without any problem.\n");
            System.Console.WriteLine("--------------------------------------------------------------------------\n");
        }

        /// <summary>
        ///     Get the grid size information from user in rownumber,columnnumber format
        ///     Populate the gridsize field with parsed information
        /// </summary>
        /// <returns> True or false based on whether procesing is successful or not </returns>
        private bool TakeGridSizeFromUser()
        {
            System.Console.Write("Enter Grid Size in (RowNumber,ColumnNumber) format  followed by Enter key : ");
            ApplicationLogger.LogMessage(1, "Start getting the Grid size from user", LogCategory.Business,
                                         TraceEventType.Information);
            var userInput = System.Console.ReadLine();
            var result = false;
            try
            {
                _gridSize = userInput.GetGridSize();
                result = true;
            }
            catch (ArgumentException ex)
            {
                System.Console.WriteLine("Following error occurred : " + ex.Message);
                ApplicationLogger.LogException(1, ex, LogCategory.Business, TraceEventType.Error);
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Unknown error occurred : " + ex.Message);
                ApplicationLogger.LogException(1, ex, LogCategory.Business, TraceEventType.Error);
            }
            return result;
        }

        /// <summary>
        ///     Get the live cells information from user in rownumber,columnnumber | rownumber,columnnumber format
        ///     Populate the gridsize field with parsed information
        /// </summary>
        /// <returns> True or false based on whether procesing is successful or not </returns>
        private bool TakeLiveCellsFromUser()
        {
            System.Console.Write(
                "Enter live cells in the ( rowIndex,colIndex | rowIndex,colIndex ) format followed by Enter key : ");
            ApplicationLogger.LogMessage(1, "Start getting the live cells information from user", LogCategory.Business,
                                         TraceEventType.Information);
            var userInput = System.Console.ReadLine();
            var result = false;
            try
            {
                _liveCells = userInput.ParseLiveCell(_gridSize);
                result = true;
            }
            catch (ArgumentException ex)
            {
                System.Console.WriteLine("Following error occurred : " + ex.Message);
                ApplicationLogger.LogException(1, ex, LogCategory.Business, TraceEventType.Error);
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Unknown error occurred : " + ex.Message);
                ApplicationLogger.LogException(1, ex, LogCategory.Business, TraceEventType.Error);
            }
            return result;
        }

        private bool TakeGenerationNumbersFromUser()
        {
            System.Console.Write("Enter number of generations followed by Enter key : ");
            ApplicationLogger.LogMessage(1, "Start getting the total generations information from user",
                                         LogCategory.Business, TraceEventType.Information);
            var userInput = System.Console.ReadLine();
            return Int32.TryParse(userInput, out _totalGenerations);
        }

        /// <summary>
        ///     Function used to get the info from user whether he/she wants to continue of not
        /// </summary>
        /// <returns> </returns>
        private bool GetUserConfirmation()
        {
            System.Console.WriteLine("Press C followed by the Enter key to continue.");
            var userInput = System.Console.ReadLine();
            if (userInput != null)
            {
                if (string.Equals(userInput.Trim(), "C", StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
                return false;
            }
            return false;
        }

        #endregion
    }
}