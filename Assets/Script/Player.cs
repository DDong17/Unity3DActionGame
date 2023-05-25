using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed; //public 사용하면 유니티에 업로드 됌
    float hAxis;
    float vAxis;

    Vector3 moveVec;

    void Start()
    {
        
    }

    
    void Update()
    {
        hAxis = Input.GetAxisRaw("Horizontal");
        vAxis = Input.GetAxisRaw("Vertical");

        moveVec = new Vector3(hAxis,0,vAxis).normalized; //대각선 움직임까지 진행할때 사용하는 normalized

        transform.position += moveVec*speed*Time.deltaTime;
    }
}
