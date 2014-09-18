using UnityEngine;
using System.Collections;

public class CameraFollowPlayer_SCR : MonoBehaviour 
{
    // Privates
    private GameObject player;
    private Vector3 playerPositionOffset;

	// Use this for initialization
	void Start () 
    {
	    // Get intialize
        player = GameObject.Find("Player");
        playerPositionOffset = this.transform.position - player.transform.position;
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}

    void FollowPlayer()
    {
        this.transform.position = player.transform.position + playerPositionOffset;
    }
}
