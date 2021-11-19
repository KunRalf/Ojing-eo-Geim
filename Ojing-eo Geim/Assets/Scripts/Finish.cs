using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    [SerializeField] private GameController _gameController;
    [SerializeField] private GameObject _finishText;

    private void Update()
    {
        if (_gameController.IsStartGame)
        {
            _finishText.SetActive(true);
        }
        Debug.Log(!_gameController.IsStartGame);
    }

    private void OnTriggerExit(Collider other)
    {
        PlayerController players = other.GetComponent<PlayerController>();
        if (players != null)
        {
            players.Winner();
            if (players.gameObject.GetComponent<PlayerMove>())
            {
                EventService.Instance.CallOnWin();
            }
            
        }
    }
}
