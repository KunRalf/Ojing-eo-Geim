using UnityEngine;

public class SkyBoxRotator : MonoBehaviour
{
    [SerializeField] private float _changeRotateSpeed = 1.5f;

    private void Update()
    {
       RenderSettings.skybox.SetFloat("_Rotation", Time.time * _changeRotateSpeed);
    }
}
