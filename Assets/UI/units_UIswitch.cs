using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class units_UIswitch : MonoBehaviour
{
    // = true if player select one unit     =   UI of the unit
    // = false if player select more unit   =   UI of formation  
    bool JustOneUnitSelect;

    // Start is called before the first frame update
    void Start()
    {
        JustOneUnitSelect = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
