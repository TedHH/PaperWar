using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class testMovement : MonoBehaviour
{
    private NavMeshAgent man;
    RaycastHit hit = new RaycastHit();
    double Attrange;
    bool Attack;

    GameObject tester;
    GameObject myBullet;
    bool CanCreate;
    public float targetSize;

    public int Status;
    //1 = rest; 2 = attact; 3 = move
    // Start is called before the first frame update
    void Start()
    {
        man = GetComponent<NavMeshAgent>();
        Attrange = 60;
        Attack = false;
        tester = GameObject.Find("Cube");
        CanCreate = true;
        targetSize = 6.9f;
        Status = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1) && !Input.GetKey(KeyCode.LeftShift))
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray.origin, ray.direction, out hit))
            {
                MoveTo(hit.point);
            }
        }
        Status = 2;
        StatusCheck();

    }

    void StatusCheck()
    {
        if (tester == null)
        {
            Status = 1;
        }
        switch (Status)
        {
            case 1:
                //rest
                break;
            case 2:
                //attack
                AttackRanger(tester);
                DoAttack(tester);
                if (!CanCreate)
                {
                    CheckHit(tester);
                }
                break;
            case 3:
                //move
                break;
            default:
                break;
        }
    }
    public void DoNoAction()
    {
        tester = null;
        Status = 1;
    }

    public void MoveTo(Vector3 pos)
    {
        man.destination = pos;
        Status = 3;
    }

    public void AttactTo(GameObject target)
    {
        tester = target;
        Status = 2;


    }

    void AttackRanger(GameObject target)
    {
        var dist = Vector3.Distance(target.transform.position, transform.position);
        if (dist <= Attrange)
        {
            Attack = true;
        }
        else
        {
            Attack = false;
        }
    }

    void DoAttack(GameObject target)
    {

        if (Attack)
        {

            CreateBullet(target);
        }
    }

    void CreateBullet(GameObject target)
    {
        if (CanCreate)
        {
            //Debug.Log("shooting");
            myBullet = (GameObject)Instantiate(Resources.Load("but"));
            myBullet.transform.position = transform.position;
            myBullet.GetComponent<Bullet_script>().target = target;
            CanCreate = false;
        }
    }

    void CheckHit(GameObject target)
    {
        if (myBullet == null)
        {
            CanCreate = true;
        }
    }
}
