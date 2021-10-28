using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] private GameController _gameController;
    [SerializeField] private GameObject _hud;
    [SerializeField] private GameObject _restartButton;

    private void Update()
    {
        if (_gameController.IsWin)
        {
            _hud.SetActive(false);
            _restartButton.SetActive(true);
        }
        if (_gameController.IsLose)
        {
            _hud.SetActive(false);
            _restartButton.SetActive(true);
        }
    }
}
