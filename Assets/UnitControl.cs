using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitControl : MonoBehaviour
{
    GameObject selection;

    // Start is called before the first frame update
    void Start()
    {
        selection = this.transform.Find("SelectionIndicator").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<Unit_info>().isSelect == true)
        {
            selection.SetActive(true);
        }
        else
        {
            selection.SetActive(false);
        }
    }

}
