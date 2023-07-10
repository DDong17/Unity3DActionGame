using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed; //public 사용하면 유니티에 업로드 됌
    float hAxis;
    float vAxis;
    bool wDown;
    bool jDown;

    Vector3 moveVec;
    Rigidbody rigid;// 물리 효과를 위해 Rigidbody 변수 선언 후 초기화
    Animator anim;

    void Awake()
    {
        rigid = GetComponent<Rigidbody>();
        anim = GetComponentInChildren<Animator>();
    }


    void Update()
    {
        GetInput();
        Move();
        Turn();
        Jump();

    }
    void GetInput()
    {
        hAxis = Input.GetAxisRaw("Horizontal");
        vAxis = Input.GetAxisRaw("Vertical");
        wDown = Input.GetButton("Walk");
        jDown = Input.GetButtonDown("Jump");
    }

    void Move()
    {
        moveVec = new Vector3(hAxis, 0, vAxis).normalized; //대각선 움직임까지 진행할때 사용하는 normalized

        transform.position += moveVec * speed * (wDown ? 0.3f : 1f) * Time.deltaTime;

        anim.SetBool("isRun", moveVec != Vector3.zero);
        anim.SetBool("isWalk", wDown);
    }

    void Turn()
    {
        //LookAt: 지정된 벡터를 향해서 회전시켜주는 함수
        transform.LookAt(transform.position + moveVec);
    }

    void Jump()
    {
        if (jDown){
            rigid.AddForce(Vector3.up * 15,ForceMode.Impulse);
        }
    }
}
