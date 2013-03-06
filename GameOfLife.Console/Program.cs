#region File Header

//  ***********************************************************************
// Project           : GameOfLife.Console
// Author           : Ajay Singh
// Created          : 06/03/2013
// 
// Last Modified By : Ajay Singh
// Last Modified On : 06/03/2013
// ***********************************************************************
//  <copyright file="Program.cs" company="Ajay Singh">
//      Copyright (c) Ajay Singh. All rights reserved.
// </copyright>
// <summary></summary>
//  ***********************************************************************

#endregion

using GameOfLife.Core;

namespace GameOfLife.Console
{
    public static class Program
    {
        private static void Main(string[] args)
        {
            var gameRule = new GameRules();
            var gameOfLife = new Console.Helpers.GameOfLife(gameRule);
            gameOfLife.Start();

            System.Console.ReadLine();
        }
    }
}