using System;

namespace GameOfLife.Library
{
    internal class Rules : IGameRules
    {
        public bool WillBeAliveNextGeneration(ExtendedCellStatusInfo cell)
        {
            if (cell == null) throw new ArgumentNullException("cell");
            if (IsOverCrowded(cell))
            {
                //Any live cell with more than three live neighbours dies, as if by overcrowding.
                return false;
            }
            else if (IsSurvivable(cell))
            {
                //Any live cell with two or three live neighbours lives on to the next generation.
                return true;
            }
            else if (IsUnderPopulated(cell))
            {
                //Any live cell with fewer than two live neighbours dies, as if caused by under-population.
                return false;
            }
            else if (IsReproduciable(cell))
            {
                //Any dead cell with exactly three live neighbours becomes a live cell, as if by reproduction
                return true;
            }
            else
            {
                return false;
            }
        }


        public bool IsReproduciable(ExtendedCellStatusInfo cell)
        {
            return cell.Alive == false && (cell.NumberOfLivingAdjacentCells == 3);
        }

        public bool IsUnderPopulated(ExtendedCellStatusInfo cell)
        {
            return cell.Alive && (cell.NumberOfLivingAdjacentCells < 2);
        }

        public bool IsSurvivable(ExtendedCellStatusInfo cell)
        {
            return cell.Alive && (cell.NumberOfLivingAdjacentCells == 2 || cell.NumberOfLivingAdjacentCells == 3);
        }


        public bool IsOverCrowded(ExtendedCellStatusInfo extendedGridCell)
        {
            return extendedGridCell.Alive && extendedGridCell.NumberOfLivingAdjacentCells > 3;
        }

    }
}