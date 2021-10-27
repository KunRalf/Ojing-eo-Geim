using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OtherPlayerAnimator : MonoBehaviour
{
    private Animator _animator;
    private PlayerController _playerController;
    private GameController _gameController;

    private const string RUNNING_ANIMATION = "_isRun";
    private const string DEATH_ANIMATION = "_isDeath";


    private void Start()
    {
        _animator = GetComponent<Animator>();
        _playerController = GetComponent<PlayerController>();
        _gameController = FindObjectOfType<GameController>();
    }

    private void RunningAnimation()
    {
        if (_playerController.IsMove && _playerController.IsAlive && _gameController.IsStartGame)
        {
            _animator.SetBool(RUNNING_ANIMATION, true);
        }
        else
        {
            _animator.SetBool(RUNNING_ANIMATION, false);
        }
    }

    private void DeathAnimation()
    {
        if (!_playerController.IsAlive)
        {
            _animator.SetBool(DEATH_ANIMATION, true);
        }
    }

    private void Update()
    {
        RunningAnimation();
        DeathAnimation();
    }

}
