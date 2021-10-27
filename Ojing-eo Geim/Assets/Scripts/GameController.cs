using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private EventService _eventService;
    [SerializeField] private List<PlayerController> _players;
    private bool _isStartGame = false;

    public int PlayersCount => _players.Count;
    public bool IsStartGame => _isStartGame;

    private void Start()
    {
     
    }

    private void OnEnable()
    {
        _eventService.OnStart += StartGame;
    }

    private void OnDisable()
    {
        _eventService.OnStart -= StartGame;
    }

    public void AddToPlayers(PlayerController player)
    {
        _players.Add(player);
    }

    public void RemoveFromPlayers(PlayerController player)
    {
        _players.Remove(player);
    }

    private void Update()
    {

    }

    public void KillMovement()
    {
        for (int i = 0; i < _players.Count; i++)
        {
            if (_players[i].gameObject.GetComponent<PlayerResult>() && !_players[i].gameObject.GetComponent<PlayerMove>().IsStop())
            {
                _players[i].gameObject.GetComponent<PlayerResult>().Lose();
                _players[i].Death();
                break;
            }
            if (_players[i].IsMove && _players[i].gameObject.GetComponent<OtherPlayerMove>())
            {
                _players[i].Death();
            }
        }
    }

    public void StartGame()
    {
        _isStartGame = true;
    }
}
