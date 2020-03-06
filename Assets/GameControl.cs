using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour
{

    private Definitions.GameStatus currentStatus;
    string errorFileLocalion;

    public List<Player> players;

    public Player currentPlayer;

    private GameObject units;
    // Start is called before the first frame update
    void Start()
    {
        players = new List<Player>();
        currentStatus = (Definitions.GameStatus)1;
        //SwitchStatus(1);
        errorFileLocalion = "Error in GameControl class, ";
        units = GameObject.Find("Unit(s)");
        currentPlayer = new Player(0,Color.red);
        InitialBase(currentPlayer.playerID);
        players.Add(currentPlayer);

        Player another = new Player(1, Color.blue);
        InitialBase(another.playerID);
        players.Add(another);

    }

    // Update is called once per frame
    void Update()
    {
        //============test================
        if (currentStatus == Definitions.GameStatus.Ingame) {
            GetComponent<MeshRenderer>().material.color = Color.red;
        }
        //======================================

        if (true) {
            units.SetActive(false);
        }
    }

    public void SwitchStatus(Definitions.GameStatus status) {
        currentStatus = status;
    }

    public void StatusCheck() {
        switch (currentStatus) {
            case Definitions.GameStatus.Ingame:
                if (IngameScreen() <0) {
                    Debug.Log(errorFileLocalion + "IngameScreen method. returning error");
                }
                break;
            case Definitions.GameStatus.Meau:
                if (MeauScreen() < 0)
                {
                    Debug.Log(errorFileLocalion + "MeauScreen method. returning error");
                }
                break;

            case Definitions.GameStatus.EndScreen:
                if (EndScreen() < 0)
                {
                    Debug.Log(errorFileLocalion + "EndScreen method. returning error");
                }
                break;
            default:
                Debug.Log("Error in StatusCheck class, StatusCheck method. did not find status in cases");
                break;
        }

    }

    public int IngameScreen() {
        //1 is running correct, <0 will be catch error
        return 1;
    }

    public int MeauScreen() {
        return 1;
    }

    public int EndScreen() {
        return 1;
    }

    public void InitialBase(int who) {
        GameObject prefab = Resources.Load("Models/Base/Base_level1") as GameObject;
        Instantiate(prefab);
        int offset = who;
        prefab.transform.position = new Vector3(offset*200f, 0, offset*-200f);
        prefab.GetComponent<Unit_info>().CreateBase(who);
    }

}
