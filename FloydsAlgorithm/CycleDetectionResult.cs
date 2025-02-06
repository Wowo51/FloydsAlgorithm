using System;

namespace FloydsAlgorithm
{
    /// <summary>
    /// Represents the result of cycle detection using Floyd's cycle-finding algorithm.
    /// </summary>
    /// <typeparam name = "T">The type of the element in the cycle.</typeparam>
    public class CycleDetectionResult<T>
    {
        /// <summary>
        /// Gets or sets the element at the start of the cycle.
        /// </summary>
        public T CycleStart { get; set; } = default !;
        /// <summary>
        /// Gets or sets the length of the cycle.
        /// </summary>
        public int CycleLength { get; set; }
        /// <summary>
        /// Gets or sets the length of the non-cyclic part before the cycle starts.
        /// </summary>
        public int NonCycleLength { get; set; }
    }
}