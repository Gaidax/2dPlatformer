using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

    private GameObject _checkPoint;
    private int _points;
    public UnityEngine.UI.Text ScoreLabel;
    public PlayerScript player;
    public GameObject deathParticle;
    public GameObject respawnParticle;
    public GameObject pointsParticle;


    public GameObject CheckPoint {
        get {
            return _checkPoint;
        }
        set
        {
            _checkPoint = value;
        }
        }

    public int PointsValue
    {
        get
        {
            return _points;
        }

        set
        {
            _points = value;
            Instantiate(pointsParticle, player.transform.position, player.transform.rotation);
            ScoreLabel.text = "Bonus: " + _points;
        }
    }

    public void respawn()
    {
        StartCoroutine("respawnPlayerDelay");
    }

	// Use this for initialization
	void Start () {
       PointsValue = 0;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public IEnumerator respawnPlayerDelay()
    {
        Instantiate(deathParticle, player.transform.position, player.transform.rotation);
        hidePlayer(false);
        yield return new WaitForSeconds(0.4f);
        player.transform.position = CheckPoint.transform.position;
        hidePlayer(true);
        Instantiate(respawnParticle, CheckPoint.transform.position, CheckPoint.transform.rotation);
    }

    private void hidePlayer(bool b)
    {
        player.enabled = b;
        player.GetComponent<Renderer>().enabled = b;
    }
}
