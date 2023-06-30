using System;
using UnityEngine;

namespace  DreamGuardian.DoorMechanic
{
    public class Door : MonoBehaviour
    {
        [SerializeField] private int id;
        [SerializeField] private GameObject mainDoorObject;

        public int Id => id;

        public void OpenTheDoor()
        {
            mainDoorObject.SetActive(false);
        }
    }
}
