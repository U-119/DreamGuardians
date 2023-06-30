using UnityEngine;

namespace DreamGuardian.Core
{
    public class GameEnum 
    {
        public enum NodeState
        {
            Available,
            Current,
            Completed
        }

        public enum Element
        {
            None,
            Water,
            Fire,
            Earth,
            Air
        }
    }
}
