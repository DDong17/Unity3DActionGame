using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed; //public 사용하면 유니티에 업로드 됌
    float hAxis;
    float vAxis;
    bool wDown;

    Vector3 moveVec;

    Animator anim;

    void Awake()
    {
        anim = GetComponentInChildren<Animator>();
    }

    
    void Update()
    {
        hAxis = Input.GetAxisRaw("Horizontal");
        vAxis = Input.GetAxisRaw("Vertical");
        wDown = Input.GetButton("Walk");

        moveVec = new Vector3(hAxis,0,vAxis).normalized; //대각선 움직임까지 진행할때 사용하는 normalized

        transform.position += moveVec*speed* (wDown ? 0.3f : 1f) *Time.deltaTime;

        anim.SetBool("isRun",moveVec != Vector3.zero);
        anim.SetBool("isWalk",wDown);

        //LookAt: 지정된 벡터를 향해서 회전시켜주는 함수
        transform.LookAt(transform.position+moveVec);
    }
}
