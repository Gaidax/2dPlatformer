using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

    private GameObject _checkPoint;
    public int Points;
    public PlayerScript player;


    public GameObject CheckPoint {
        get {
            return _checkPoint;
        }
        set
        {
            _checkPoint = value;
        }
        }

    public void respawn()
    {
        player.transform.position = CheckPoint.transform.position;
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
