using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DollHead : MonoBehaviour
{
    [SerializeField] private GameController _gameController;
    private bool _isActivateAttack = false;

    private void Start()
    {
        _gameController = FindObjectOfType<GameController>();
    }

    public void ActivateAttack()
    {
        _isActivateAttack = true;
    }

    public void DiactivateAttack()
    {
        _isActivateAttack = false;
    }

    private void Update()
    {
        if (_isActivateAttack)
        {
            if (_gameController.PlayersCount > 0)
            {
                _gameController.KillMovement();
            }
            
        }
    }
}
