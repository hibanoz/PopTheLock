using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FXRotate : MonoBehaviour
{
    [SerializeField] private PlayerController _playerController;
    public float Rotation;

    void Update() { 
     if (_playerController.RotDirection == PlayerController.Direction.Clockwise) {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }

        else {

         transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
    }
}
