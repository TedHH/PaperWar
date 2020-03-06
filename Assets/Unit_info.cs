using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit_info : MonoBehaviour
{

    // Use this for initialization
    public double hp;
    public double maxHp ;
    public double moveSpeed;
    public double attSpeed;
    public double attDmg;
    public double attRange;
    public double currIntercept;
    public bool isMoving, isAtting, isWorking, isSelect;

    public bool canBuild, canMove, canAttack, canSelect;

    public int belongTo;

    GameObject UI;

    public Unit_info()
    {
        isMoving = false;
        isAtting = false;
        isWorking = false;
        isSelect = false;
        //???????????????????????????????
        //UI.SetActive(false);
    }


    public void SetHp(int sethp)
    {
        hp = sethp;
    }


    private void OnMouseDown()
    {
        //isSelect = true;
        //UI.GetComponent<>().switchTo();
        //GetComponentInParent<>().
    }



    public void CreateFamer(int who)
    {
        hp = 1000;
        maxHp = 1000;
        moveSpeed = 5;
        attSpeed = 2;
        attDmg = 5;
        attRange = 5;
        currIntercept = 0;
        isMoving = false;
        isAtting = false;
        isWorking = false;
        isSelect = false;
        belongTo = who;
    }


    public void CreateBase(int who)
    {
        hp = 1000;
        maxHp = 1000;
        moveSpeed = 0;
        attSpeed = 0;
        attDmg = 0;
        attRange = 0;
        currIntercept = 10;
        isMoving = false;
        isAtting = false;
        isWorking = false;
        isSelect = false;
        belongTo = who;
    }
}
