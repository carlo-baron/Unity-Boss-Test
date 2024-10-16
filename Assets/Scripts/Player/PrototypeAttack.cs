using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrototypeAttack : MonoBehaviour
{
    Animator anim;
    public int atkVal;
    bool firstAtk = true;
    public bool isAttack = false;
    public bool canAttack = true;
    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        anim.SetInteger("intVal", atkVal);
        anim.SetBool("inAtk", isAttack);
        if(Input.GetMouseButtonDown(0) && firstAtk){
            anim.SetTrigger("newAtk");
            atkVal = 1;
            firstAtk = false;
        }
    }

    public void NextAttack(){
        atkVal = atkVal < 3 ? atkVal+1 : 1;
    }

    public void CheckAttack(){
        if(!isAttack){
            atkVal = 0;
            print("reset");
        }
    }
}
