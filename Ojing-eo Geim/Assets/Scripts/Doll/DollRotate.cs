using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DollRotate : MonoBehaviour
{
    [SerializeField] private float _rotSpeed = 1.5f;
    private GameController _gameController;

    private Quaternion _startRot;

    private void Start()
    {
        _gameController = FindObjectOfType<GameController>();
        _startRot = transform.rotation;
    }

    private void Update()
    {
        if(_gameController.IsStartGame)
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.identity, _rotSpeed * Time.deltaTime);
    }

}
