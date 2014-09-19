using UnityEngine;
using System.Collections;

public class PlayerMovementControls_SCR : MonoBehaviour 
{
    /* Public  */

    // Speed at which the player moves
    public float movementSpeed;


    /* Private */

    
	// Use this for initialization
	void Start () 
    {
        StartCoroutine(MoveTo(Vector3.zero));
	}
	
	// Update is called once per frame
	void Update () 
    {
        // Move to where the mouse clicked
	    if (Input.GetMouseButtonDown(0))
        {
            Vector3 movePos = GetClickWorldLocation();
            StartCoroutine(MoveTo(movePos));
        }

	}

    // Gets the world position where the mouse clicked.
    Vector3 GetClickWorldLocation()
    {
        // Default Vector3 null
        Vector3 blankVector = new Vector3(1000,1000,1000);

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100))
        {
            return hit.point;
        }

        // Give the result
        return blankVector;
    }

    // Moves to the given position.
    IEnumerator MoveTo(Vector3 positionMovingTo)
    {
        // Don't do anything if given a null vector
        if (positionMovingTo.x != 1000)
        {
            // Move towards the given position
            bool going = true;
            float lastDist = 1000f;
            while (going) 
            {
                // Let things pass
                yield return null;

                // Get the new position
                Vector3 localPos = positionMovingTo - this.transform.position;

                Vector3 direction = localPos;
                direction.Normalize();

                //bug.Log(direction);
                Vector3 newPos = this.transform.position + (direction * movementSpeed) * 0.1f;
                newPos.y = 1;

                //Set the new position
                this.transform.position = newPos;

                // Stop going when close to the given position
                if (Vector3.Distance(this.transform.position, positionMovingTo) > lastDist)
                {
                    going = false;
                }
                lastDist = Vector3.Distance(this.transform.position, positionMovingTo);
            } 
        }
    }
}