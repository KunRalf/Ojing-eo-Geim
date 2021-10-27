using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DollAnimator : MonoBehaviour
{
    [SerializeField] private Animator _mainAnimator;
    [SerializeField] private Animator _headAnimator;

    private float _delayBeforeRotateToPlayer = 5;
    private float _delayBeforeRotateToWood = 4;

    private bool _isRotateToPlayer = false;
    private bool _isRotateToWood = false;

    private Coroutine _toPlayer;
    private Coroutine _toWood;

    private const string ROTATE_TO_PLAYER = "_isRotateToPlayer";
    private const string ROTATE_TO_WOOD = "_isRotateToWood";

    private void Start()
    {
        _toPlayer = StartCoroutine(ToPlayer(_delayBeforeRotateToPlayer));
    }

    private void Update()
    {
        RotateToPlayer();
        RotateToWood();
    }

    public void RotateToPlayer()
    {
        if (_isRotateToPlayer)
        {
            StopCoroutine(_toPlayer);
            _toWood = StartCoroutine(ToWood(_delayBeforeRotateToWood));
            _delayBeforeRotateToPlayer = 5;
            _isRotateToPlayer = false;
        }
    }

    public void RotateToWood()
    {
        if (_isRotateToWood)
        {
            StopCoroutine(_toWood);
            _toPlayer = StartCoroutine(ToPlayer(_delayBeforeRotateToPlayer));
            _isRotateToWood = false;
        }
    }

    private IEnumerator ToPlayer(float time)
    {
        yield return new WaitForSeconds(time);
        _headAnimator.SetTrigger(ROTATE_TO_PLAYER);
        _isRotateToPlayer = true;
    }

    private IEnumerator ToWood(float time)
    {
        yield return new WaitForSeconds(time);
        _headAnimator.SetTrigger(ROTATE_TO_WOOD);
        _isRotateToWood = true;
    }
}
