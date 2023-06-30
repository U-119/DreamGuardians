using System.Collections;
using System.Collections.Generic;
using DreamGuardian.Core;
using UnityEngine;

namespace DreamGuardian.ElementMechanic
{
    public class Orb : MonoBehaviour
    {
        [SerializeField] private GameEnum.Element elementType;

        public GameEnum.Element ElementType => elementType;

        public bool CanCollectable { get; set; } = true;
    }
}
