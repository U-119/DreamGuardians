using System;
using System.Collections;
using System.Collections.Generic;
using DreamGuardian.Core;
using DreamGuardian.ElementMechanic;
using UnityEngine;

namespace DreamGuardian.Player
{
    public class PlayerElementCollector : MonoBehaviour
    {
        [SerializeField] private Transform handTransform;
        [SerializeField] private float collectSpeed;
        [SerializeField] private float throwSpeed;

        private Orb _collectedOrb;
        private WaitForSeconds _waitCooldown = new WaitForSeconds(1);

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Orb orb))
            {
                if (!orb.CanCollectable) return;

                if (_collectedOrb != null)
                {
                    StartCoroutine(ThrowAwayOrb(_collectedOrb, orb.transform.position));
                }

                orb.CanCollectable = false;
                orb.transform.parent = handTransform;
                _collectedOrb = orb;
                StartCoroutine(MoveHandCoroutine());
            }

            if (other.TryGetComponent(out Gate gate))
            {
                if (_collectedOrb == null) return;

                if (gate.ElementType == _collectedOrb.ElementType) // Gate açılır
                {
                    gate.OpenTheGate();
                }
                else // Elimizde doğru element yok
                {
                    // Give feedback
                    Debug.Log($"Elinde doğru element yok. Bu gate için {gate.ElementType} elementine ihtiyacın var.");
                }
            }
        }

        private IEnumerator MoveHandCoroutine() // Yeni orbu elimize alıcaz
        {
            while (Vector3.Distance(_collectedOrb.transform.localPosition, Vector3.zero) > 0)
            {
                _collectedOrb.transform.localPosition = Vector3.Lerp(_collectedOrb.transform.localPosition, Vector3.zero, Time.deltaTime * collectSpeed);
                yield return null;
            }
        }
        
        private IEnumerator ThrowAwayOrb(Orb orb, Vector3 position) // Eski orbu yere bırakıcaz
        {
            orb.transform.parent = null;
            while (Vector3.Distance(orb.transform.position, position) > 1)
            {
                orb.transform.position = Vector3.Lerp(orb.transform.position, position, Time.deltaTime * throwSpeed);
                yield return null;
            }

            yield return _waitCooldown;

            orb.CanCollectable = true;
        }
    }
}
