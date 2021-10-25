using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField] private PlayerMove _player;

    private float _lerpSpeed = 5f;
    private Vector3 toPosition;
    public Vector3 _offset;


    private void Start()
    {
        _player = FindObjectOfType<PlayerMove>();
        _offset = _player.transform.position - transform.position;
    }

    private void Update()
    {
        toPosition = _player.transform.position - _offset;
        transform.position = Vector3.Lerp(transform.position, toPosition, _lerpSpeed * Time.deltaTime);
    }

}
