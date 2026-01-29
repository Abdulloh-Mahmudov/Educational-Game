using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    private Transform _camera;
    private Camera _main;
    // Start is called before the first frame update
    void Start()
    {
        _camera = GetComponent<Transform>();
        _main = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        _camera.LookAt(_main.transform);
    }
}
