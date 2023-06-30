using System.Collections;
using System.Collections.Generic;
using DreamGuardian.Core;
using UnityEngine;

public class Gate : MonoBehaviour
{
    [SerializeField] private GameEnum.Element elementType;
    [SerializeField] private Collider collider;
    
    public GameEnum.Element ElementType => elementType;

    public void OpenTheGate()
    {
        collider.enabled = false;
    }
}
