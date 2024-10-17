using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    Animator anim;
    
    int atkVal;
    public int AtkVal
    {
        get
        {
            return atkVal;
        }
        set
        {
            atkVal = value;
        }
    }
    
    bool reAttack = true;
    public bool ReAttack
    {
        get
        {
            return reAttack;
        }
        set
        {
            reAttack = value;
        }
    }
    
    bool isAttack = false;
    public bool IsAttack
    {
        get
        {
            return isAttack;
        }
        set
        {
            isAttack = value;
        }
    }

    int atkCache = 0;
    public int AtkCache
    {
        get
        {
            return atkCache;
        }
        set
        {
            atkCache = value;
        }
    }
    
    public Cooldown cd;
    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && reAttack)
        {
            atkVal = atkVal == 0 ? 1 : atkCache;
            anim.SetTrigger("atk");
            reAttack = false;
            cd.StartCooldown();
        }


        anim.SetInteger("intVal", atkVal);
        anim.SetBool("inAtk", isAttack);

        if (isAttack) cd.StartCooldown();
        if (cd.isCoolingdown) return;
        atkVal = 0;
    }

    int AttackValueLogic(int num)
    {
        return num < 3 ? num + 1 : 1;
    }

    public void NextAttack()
    {
        atkVal = AttackValueLogic(atkVal);
        atkCache = atkVal;
    }

    public void CheckAttack()
    {
        if (!isAttack)
        {
            atkVal = 0;
        }
    }
}