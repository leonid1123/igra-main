using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject bullet;

    public Transform startPos;

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            Instantiate(bullet, startPos.position, Quaternion.identity);
        }
    }    
}
