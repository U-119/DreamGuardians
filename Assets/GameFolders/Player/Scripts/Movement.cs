using System;
using DreamGuardian.Core;
using UnityEngine;

namespace DreamGuardian.Player
{
    public class Movement : MonoBehaviour
    {
        [SerializeField] private float moveSpeed;
        [SerializeField] private float smoothTime = 0.05f;

        private Rigidbody _rigidBody;

        private Vector3 _input;
        private float _horizontal;
        private float _vertical;
        private float _currentVelocity;

        private void Awake()
        {
            _rigidBody = GetComponent<Rigidbody>();
        }

        private void FixedUpdate()
        {
            _rigidBody.velocity = new Vector3(_input.x, 0, _input.z) * moveSpeed;
        }

        private void Update()
        {
            _input = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            
            if (_input.sqrMagnitude == 0) return;
            
            float targetAngle = Mathf.Atan2(_input.x, _input.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref _currentVelocity, smoothTime);
            
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
        }
    }
}
