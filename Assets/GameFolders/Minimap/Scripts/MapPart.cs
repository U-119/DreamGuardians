using System;
using UnityEngine;

namespace DreamGuardian.MiniMap
{
    public class MapPart : MonoBehaviour
    {
        public void Break()
        {
            gameObject.SetActive(false);
        }
    }
}
