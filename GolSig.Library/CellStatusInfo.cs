using System;
namespace GameOfLife.Library
{
    internal class CellStatusInfo :  IEquatable<CellStatusInfo>, ICellStatusInfo
    {
         public bool Alive { get; private set; }

         public CellStatusInfo(bool alive)
         {
             Alive = alive;
         }

         public bool Equals(CellStatusInfo other)
         {
             if (other == null) return false;
             if (other.Alive != this.Alive) return false;
             return true;
         }
    }
}