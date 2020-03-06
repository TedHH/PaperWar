using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    private GameObject gc;

    // Start is called before the first frame update
    void Start()
    {
        gc = GameObject.Find("GameController");
    }

    // Update is called once per frame
    void Update()
    {
        transform.Find("Flag").gameObject.transform.Find("Box001").GetComponent<SkinnedMeshRenderer>().material.color = gc.GetComponent<GameControl>().players[GetComponent<Unit_info>().belongTo].color;
    }
}
