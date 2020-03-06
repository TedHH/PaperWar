using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserInput : MonoBehaviour
{
    public GameObject hoveredObject;

    public GameObject selectedObject;

    private GameObject gc;

    // Start is called before the first frame update
    
    void Start()
    {
        gc = GameObject.Find("GameController");
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        
        RaycastHit hitInfo;
        RaycastHit[] hits = Physics.RaycastAll(ray);
        if (Physics.Raycast(ray, out hitInfo))
        {
            //Debug.Log("Mouse is over: " + hitInfo.collider.name);
            GameObject hitObject = hitInfo.transform.root.gameObject;

            HoveredObject(hitObject);
        }
        else
        {
            ClearHover();
        }

        if (Input.GetMouseButtonDown(0)) {
            if (hoveredObject != null && hoveredObject.name != "Desktop" 
                && hoveredObject.GetComponent<Unit_info>().belongTo == gc.GetComponent<GameControl>().currentPlayer.playerID)
            {
                selectedObject = hoveredObject;
            }

            else {

            }

        }

        if (Input.GetMouseButtonUp(0))
        {
            if (selectedObject == hoveredObject)
            {
                // the unit is really selected
                Debug.Log("Yes! the object selected is " + selectedObject.name);

                gc.GetComponent<GameControl>().currentPlayer.addSelected(selectedObject);
            }

            else
            {
                gc.GetComponent<GameControl>().currentPlayer.clearSelect();

            }
        }
    }


    void HoveredObject(GameObject obj)
    {
        if (hoveredObject != null)
        {
            if(obj == hoveredObject)
                return;
        }

        hoveredObject = obj;
    }

    void ClearHover()
    {
        hoveredObject = null;
    }

}
