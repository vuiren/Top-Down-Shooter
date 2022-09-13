using System.Collections.Generic;
using _Scripts.Services;

namespace Client.Components.Navigation
{
    public struct Path
    {
        public Queue<Cell> Value;

        public override string ToString()
        {
            return Value.Count.ToString();
        }
    }
}