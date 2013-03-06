
namespace GameOfLife.Common
{
    /// <summary>
    /// This enum represents the state of cell at a particular moment of time.
    /// In classical Conway's Life algorithm there are only two states -
    /// Dead and Alive. 
    /// You can even add some others for e.f. overcrowded
    /// </summary>
    public enum CellState
    {
        /// <summary>
        /// Cell is marked as Dead
        /// </summary>
        Dead=0,
        /// <summary>
        /// Cell is marked as Live
        /// </summary>
        Alive=1

    }
}
