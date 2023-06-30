using System;
using System.Collections.Generic;
using DreamGuardian.DoorMechanic;
using UnityEngine;

namespace DreamGuardian.Player
{
    public class PlayerKeyController : MonoBehaviour
    {
        private readonly List<int> _collectedKeys = new List<int>();
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Key key))
            {
                key.KeyCollected();

                if (!_collectedKeys.Contains(key.Id))
                {
                    _collectedKeys.Add(key.Id);
                }
            }

            if (other.TryGetComponent(out Door door))
            {
                if (_collectedKeys.Contains(door.Id)) // Anahtarımız uyuştu kapıyı açabiliriz
                {
                    _collectedKeys.Remove(door.Id);
                    door.OpenTheDoor();
                }
                else // Bu kapıya ait anahtar elimizde yok
                {
                    // Give feedback
                    Debug.Log($"Elinde doğru anahtar yok! Bu kapıyı açmak için {door.Id} numaralı anahatara sahip olman gerek.");
                }
            }
        }
    }
}
