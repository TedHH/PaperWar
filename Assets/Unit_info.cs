using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit_info : MonoBehaviour
{


    // Use this for initialization
    public double hp;
    public double moveSpeed;
    public double attSpeed;
    public double attDmg;
    public double attRange;
    public double currIntercept;
    public bool isMoving, isAtting, isWorking, isSelect;


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



    public void Create(int which)
    {
        switch (which)
        {
            case 0:
                CreateFamer();
                break;
            case 1:
                break;
        }
    }

    void CreateFamer()
    {

        hp = 100000;
        moveSpeed = 5;
        attSpeed = 2;
        attDmg = 5;
        attRange = 5;
        currIntercept = 0;
        isMoving = false;
        isAtting = false;
        isWorking = false;
        isSelect = false;
    }
}
