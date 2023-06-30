using System;
using DreamGuardian.Core;
using DreamGuardian.Level;
using UnityEngine;

namespace DreamGuardian.Player
{
    public class PlayerDreamPartCollector : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out DreamPart dreamPart))
            {
                if (GameManager.Instance != null)
                {
                    GameManager.Instance.Level++;
                    GameManager.Instance.LoadCurrentLevel();
                }
                else
                {
                    Debug.Log("Level bitti ancak sahnede GameManager yok. Yeni levele geçmek için oyunu MainMenu sahnesinden başlatmalısın");
                }
                
            }
        }
    }
}
