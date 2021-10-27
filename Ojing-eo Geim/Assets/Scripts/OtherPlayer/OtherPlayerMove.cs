using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OtherPlayerMove : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private float _delayBeforeRotate = 1f;
    private float _timer;
    private PlayerController _playerController;
    private GameController _gameController;
    private Rigidbody _rgb;
    private Quaternion _rotate;

    private void Awake()
    {
        _rgb = GetComponent<Rigidbody>();
        _playerController = GetComponent<PlayerController>();
        _gameController = FindObjectOfType<GameController>();
    }

    private void Start()
    {

    }

    private void FixedUpdate()
    {
        if (_playerController.IsAlive && _gameController.IsStartGame)
        {
            _timer += Time.deltaTime;
            if (_timer > _delayBeforeRotate)
            {
                _timer = 0f;
                ChangeRotate();
            }
            transform.Translate(0, 0, _moveSpeed * Time.deltaTime);
        }

    }

    private void ChangeRotate()
    {
        Vector3 rot;

        rot.x = 0;
        rot.y = Random.Range(-30.0f, 30.0f);
        rot.z = 0;

        _rotate = Quaternion.Euler(rot);

        transform.rotation = _rotate;
    }
}
