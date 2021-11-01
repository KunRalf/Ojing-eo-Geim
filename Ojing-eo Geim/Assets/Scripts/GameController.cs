using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private EventService _eventService;
    [SerializeField] private List<PlayerController> _players;
    [SerializeField] private AudioSource _shootAudio;
    private bool _isStartGame = false;
    private bool _isFreeze = false;
    private bool _isWin = false;
    private bool _isLose = false;
    private Coroutine _shoot;
    

    public int PlayersCount => _players.Count;
    public bool IsStartGame => _isStartGame;
    public bool IsWin => _isWin;
    public bool IsLose => _isLose;

    private void Start()
    {
        _shootAudio = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        _eventService.OnStart += StartGame;
        _eventService.OnWin += WinScreen;
        _eventService.OnLose += LoseScreen;
    }

    private void OnDisable()
    {
        _eventService.OnStart -= StartGame;
        _eventService.OnWin -= WinScreen;
        _eventService.OnLose -= LoseScreen;
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
        int count = 0;
        for (int i = 0; i < _players.Count; i++)
        {
            if (_players[i].gameObject.GetComponent<PlayerResult>() && !_players[i].gameObject.GetComponent<PlayerMove>().IsStop())
            {
                _shootAudio.Play();
                _players[i].Death();
                _eventService.CallOnLose();
                break;
            }
            if (_players[i].IsMove && _players[i].gameObject.GetComponent<OtherPlayerMove>())
            {
                _players[i].Death();
                count++;
            }
        }
        _shoot = StartCoroutine(Shooting(count));
    }

    public void StartGame()
    {
        _isStartGame = true;
    }

    public void IsFreezeOn()
    {
        _isFreeze = true;
    }

    public void IsFreezeOff()
    {
        
        _isFreeze = false;
    }

    private IEnumerator Shooting(int count)
    {
        for (int i = 0; i < count; i++)
        {
            _shootAudio.Play();
            yield return new WaitForSeconds(0.1f);
        }
    }

    public void WinScreen()
    {
        _isWin = true;
    }

    public void LoseScreen()
    {
        _isLose = true;
    }
}
