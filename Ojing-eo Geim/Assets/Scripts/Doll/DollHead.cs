using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DollHead : MonoBehaviour
{
    [SerializeField] private GameController _gameController;
    [SerializeField] private GameObject _redColor;
    [SerializeField] private GameObject _greenColor;
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

    public void FreezeOn()
    {
        _redColor.SetActive(true);
        _greenColor.SetActive(false);
        EventService.Instance.SetRandomValue();
        _gameController.IsFreezeOn();
    }

    public void FreezeOff()
    {
        _greenColor.SetActive(true);
        _redColor.SetActive(false);
        _gameController.IsFreezeOff();
    }

    public void StopShooting()
    {
        EventService.Instance.ToMove();
    }

    private void Update()
    {
        if (_isActivateAttack && _gameController.PlayersCount > 0)
        {
            _gameController.KillMovement();
        }
    }
}
