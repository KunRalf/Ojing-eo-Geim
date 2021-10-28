using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class StartGame : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private GameObject _startScreen;
    [SerializeField] private GameObject _ui;
    [SerializeField] private GameObject _colors;
    [SerializeField] private GameController _gameController;

    public void OnPointerDown(PointerEventData eventData)
    {
        _startScreen.SetActive(false);
        _ui.SetActive(true);
        _colors.SetActive(true);
        _gameController.StartGame();
    }

}
