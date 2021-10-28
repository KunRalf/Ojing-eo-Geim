using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerResult : MonoBehaviour
{
    private PlayerController _playerController;
    private GameController _gameController;

    private void Start()
    {
        _playerController = GetComponent<PlayerController>();
        _gameController = FindObjectOfType<GameController>();
    }

    private void Update()
    {

    }

}
