using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitControl : MonoBehaviour
{
    GameObject selection;
    GameObject healthBar = null;

    // Start is called before the first frame update
    void Start()
    {
        selection = this.transform.Find("SelectionIndicator").gameObject;
        try
        {
            healthBar = this.transform.Find("HealthBar").gameObject;
        }
        catch { }
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

        if (healthBar) {
            healthBar.GetComponent<HealthBar_FillControl>().Fill = GetComponent<Unit_info>().hp / GetComponent<Unit_info>().maxHp;
        }
    }

}
