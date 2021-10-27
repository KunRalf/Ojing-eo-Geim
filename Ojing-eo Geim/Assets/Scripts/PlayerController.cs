using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private CapsuleCollider _collider;
    private GameController _gameController;
    private Rigidbody _rgb;
    private bool _isAlive = true;
    public bool IsMove => !_rgb.IsSleeping();
    public bool IsAlive => _isAlive;

    private void OnEnable()
    {
        _gameController.AddToPlayers(this);
    }

    private void Awake()
    {
        _gameController = FindObjectOfType<GameController>();
        
    }

    private void Start()
    {
        _rgb = GetComponent<Rigidbody>();
    }

    public void Death()
    {
        _isAlive = false;
        _gameController.RemoveFromPlayers(this);
        _collider.enabled = false;
        _rgb.useGravity = false;
        Debug.Log("322");
    }


}
