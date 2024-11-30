using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public Vector2 moveVec;
    public float speed;
    Vector2 nextVec;

    Rigidbody2D playerRigid;
    SpriteRenderer spriter;
    Animator anim;


    // Start is called before the first frame update
    void Awake()
    {
        playerRigid = GetComponent<Rigidbody2D>();
        spriter = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        nextVec = moveVec * speed * Time.fixedDeltaTime;
        playerRigid.MovePosition(playerRigid.position + nextVec);
    }

    void OnMove(InputValue value)
    {
        moveVec = value.Get<Vector2>();
    }

    void LateUpdate()
    {
        anim.SetFloat("SpeedX",Mathf.Abs(moveVec.x));
        anim.SetFloat("SpeedY",moveVec.y);
        if(moveVec.y !=0) {
            anim.SetBool("MoveVertical",true);
        } else {
            anim.SetBool("MoveVertical",false);
        }
        if(moveVec.x != 0) {
            spriter.flipX = moveVec.x < 0;
        }
    }
}
