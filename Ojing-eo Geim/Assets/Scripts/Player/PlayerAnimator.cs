using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] protected DynamicJoystick _joystick;
    private Animator _animator;

    private const string RUNNING_ANIMATION = "_isRun";
    private const string DEATH_ANIMATION = "_isDeath";


    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void RunningAnimation()
    {
        if (_joystick.Horizontal != 0 || _joystick.Vertical != 0)
        {
            _animator.SetBool(RUNNING_ANIMATION, true);
        }
        else
        {
            _animator.SetBool(RUNNING_ANIMATION, false);
        }
    }

    private void Update()
    {
        RunningAnimation();
    }

}
