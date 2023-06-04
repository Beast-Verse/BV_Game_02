using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cameramovement : MonoBehaviour
{

    public Transform target;

    [SerializeField]
    private float _mouseSensitivity = 3.0f;

    [SerializeField]
    private float _rotationY;
    [SerializeField]
    private float _rotationX;

    [SerializeField]
    private float _distanceFromTarget = 10.0f;
    
  
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X")* _mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y")* _mouseSensitivity;

        _rotationY += mouseX;
        _rotationX -= mouseY;

        _rotationX = Mathf.Clamp(_rotationX, -5, 60);

        transform.localEulerAngles = new Vector3(_rotationX , _rotationY, 0);

        transform.position = target.position - transform.forward*_distanceFromTarget;
    }
}
