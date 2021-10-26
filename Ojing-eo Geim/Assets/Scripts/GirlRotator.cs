using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GirlRotator : MonoBehaviour
{
    [SerializeField] private float _rotSpeed = 1.5f;

    private Quaternion _startRot;

    private void Start()
    {
        _startRot = transform.rotation;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.B))
           transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.identity, _rotSpeed * Time.deltaTime);
        if (Input.GetKey(KeyCode.N))
            transform.rotation = Quaternion.Lerp(transform.rotation, _startRot, _rotSpeed * Time.deltaTime);
    }

}
