using System;
using UnityEngine;

namespace DreamGuardian.MiniMap
{
    public class MapPartBreaker : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out MapPart mapPart))
            {
                mapPart.Break();
            }
        }
    }
}
