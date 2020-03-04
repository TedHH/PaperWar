using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_script : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject target;
    public double targetSize;
    public float speed;
    void Start()
    {
        speed = 10f;
        targetSize = 6;
    }

    // Update is called once per frame
    void Update()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, step);
        Colliorcheck();
    }

    public void Colliorcheck()
    {
        var dist = Vector3.Distance(target.transform.position, transform.position);
        if (dist < targetSize)
        {
            kill();

        }
    }

    public void kill()
    {
        // target decrase health here;

        //=================================
        Destroy(gameObject);

    }
}
