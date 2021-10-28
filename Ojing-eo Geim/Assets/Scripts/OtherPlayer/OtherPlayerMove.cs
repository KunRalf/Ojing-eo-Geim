using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OtherPlayerMove : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private float _delayBeforeRotate = 1f;
    private float _timer;
    private int _rndValue = 90;
    private PlayerController _playerController;
    private GameController _gameController;
    private EventService _eventService;
    private Quaternion _rotate;

    private void Awake()
    {
        _playerController = GetComponent<PlayerController>();
        _gameController = FindObjectOfType<GameController>();
        _eventService = FindObjectOfType<EventService>();
        _eventService.OnRandomValue += RNDValue;
        _eventService.OnMove += ToMove;
    }

    private void OnDisable()
    {
        _eventService.OnRandomValue -= RNDValue;
        _eventService.OnMove -= ToMove;
    }

    private bool IsStop()
    {
        if (_rndValue > 50)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void FixedUpdate()
    {
        if (IsStop())
        {
            if (_playerController.IsAlive && _gameController.IsStartGame && !_playerController.IsWin)
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

    private void ToMove()
    {
        _rndValue = 90;
    }

    private void RNDValue()
    {
        _rndValue = Random.Range(0, 101);
    }
}
