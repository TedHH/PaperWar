using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{
    private List<GameObject> ControlledUnit;
    private List<GameObject> SelectedUnit;
    public int playerID;
    public Color color;
    private GameObject gc;

    public Player(int id, Color c) {
        playerID = id;
        color = c;
        ControlledUnit = new List<GameObject>();
        SelectedUnit = new List<GameObject>();  
    }

    public bool Equals(Player other) {
        return playerID == other.playerID;
    }
    public void clearSelect()
    {
        for (int i=0; i<SelectedUnit.Count; i++)
        {
            SelectedUnit[i].GetComponent<Unit_info>().isSelect = false;
        }

        SelectedUnit.Clear();
    }

    public void addSelected(GameObject g)
    {
        SelectedUnit.Add(g);
        g.GetComponent<Unit_info>().isSelect = true;
    }
}
