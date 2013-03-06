GameOfLife
==========

GameOfLife Implementation in .Net

This application is the console (command line) implementation of convey's Game of Life. 
Game of Life is a cellular automata exercise created by mathematician John H. Conway in 1970. 
It's not really a game in the traditional sense since the outcome is decided solely by the initial set up
and there aren't any players. A better description might be that it is a simulation. 

Rules of Game of Life
The universe of the Game of Life is an infinite two-dimensional orthogonal grid of square cells, each of which is in one of two possible states, live or dead. Every cell interacts with its eight neighbors, which are the cells that are horizontally, vertically, or diagonally adjacent. At each step in time, the following transitions occur:
1. Any live cell with fewer than 2 live neighbors dies, as if caused by under-population.
2. Any live cell with 2 or 3 live neighbors’ lives on to the next generation.
3. Any live cell with more than 3 live neighbors dies, as if by overcrowding.
4. Any dead cell with exactly 3 live neighbors becomes a live cell, as if by reproduction.

The initial pattern constitutes the seed of the system. The first generation is created by applying the above 
rules simultaneously to every cell in the seed—births and deaths occur simultaneously, and the discrete moment 
at which this happens is sometimes called a tick (in other words, each generation is a pure function of the preceding one). 
The rules continue to be applied repeatedly to create further generations.
