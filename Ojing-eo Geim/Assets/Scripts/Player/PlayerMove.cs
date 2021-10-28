using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private float _gravity = 0;
    [SerializeField] protected DynamicJoystick _joystick;
    private PlayerController _playerController;

    private Vector3 _playerDirection;
    private float _rotateSpeed = 0.1f;
    private Rigidbody _playerRgb;

    private void Start()
    {
        _playerRgb = GetComponent<Rigidbody>();
        _playerController = GetComponent<PlayerController>();
    }

    private void FixedUpdate()
    {
        if (_playerController.IsAlive && !_playerController.IsWin)
        {
            _playerDirection.y = 0;
            _playerDirection.x = _joystick.Horizontal;
            _playerDirection.z = _joystick.Vertical;

            Vector3 moveDirection = Vector3.RotateTowards(transform.forward, _playerDirection, _rotateSpeed, 0f);
            transform.rotation = Quaternion.LookRotation(moveDirection);

            _playerRgb.velocity = new Vector3(_playerDirection.normalized.x * _moveSpeed, _playerRgb.velocity.y - _gravity, _playerDirection.normalized.z * _moveSpeed);
        }
        else
        {
            _playerRgb.velocity = Vector3.zero;
        }
    }

    public bool IsStop()
    {
        return _playerDirection == Vector3.zero;
    }
}
