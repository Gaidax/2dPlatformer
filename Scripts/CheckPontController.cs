using UnityEngine;
using System.Collections;

public class CheckPontController : MonoBehaviour {
    public GameController gameController;
	// Use this for initialization
	void Start () {
        CircleCollider2D myCollider = transform.GetComponent<CircleCollider2D>();
        myCollider.radius = 5.0f;
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            gameController.CheckPoint = gameObject;

        }

    }
}
