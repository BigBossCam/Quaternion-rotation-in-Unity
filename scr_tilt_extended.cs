using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_tilt_extended : MonoBehaviour
{

	// Declare rotation angles and current angle.
	// Instead of seperatly declaring multiple angles we only need to set the starting angle,
	// and then set a maximum rotation angle.

	Quaternion startingAngle = Quaternion.Euler(0,0,0);
	public Quaternion currentAngle;
	public float maxRotationAngle = 20;

	// To reset the position, add a bool to act as a trigger later in the IEnumerator.

	public bool trigger = true;

	// There's also some extra options to add, such as the rotation speed
	// and wait time until returning to the starting position.

	public float rotateSpd = 0.05f;
	public float waitTime = 0.3f;


    void Start()
    {
    	// Start by setting the current angle to 0.

    	currentAngle = startingAngle;
    }

    void Update()
    {

    	// If the current angle is not the same as the starting angle, and
    	// if the trigger is set to true, then return the object to the starting position.
    	// This will save some computing power.

    	if (currentAngle != startingAngle)
    	{
    		if (trigger == true){
        		this.transform.rotation = Quaternion.Slerp(this.transform.rotation, startingAngle, rotateSpd/2);
        		currentAngle = startingAngle;
        	}
    	}

    	// Input for all keys. Unfortunetly, it's not possible to do a switch statement with key input afaik.

    	// Nevertheless, each key calls "ChangeCurrentAngle(Quaternion.Euler(0,0,-maxRotationAngle));",
    	// which is the rotation function.

        if(Input.GetKeyDown(KeyCode.A))
  		{
  			ChangeCurrentAngle(Quaternion.Euler(0,0,maxRotationAngle));
  		}
  		else if (Input.GetKeyDown(KeyCode.D))
  		{
  			ChangeCurrentAngle(Quaternion.Euler(0,0,-maxRotationAngle));
  		}
  		else if (Input.GetKeyDown(KeyCode.W))
  		{
  			ChangeCurrentAngle(Quaternion.Euler(maxRotationAngle,0,0));
  		}
 		else if (Input.GetKeyDown(KeyCode.S))
  		{
  			ChangeCurrentAngle(Quaternion.Euler(-maxRotationAngle,0,0));
  		}

  		// Rotate object to the new position.

  		this.transform.rotation = Quaternion.Slerp(this.transform.rotation, currentAngle, rotateSpd);
    }


    // When ChangeCurrentAngle is called, it first of all stops the coroutine, 
    // then changes the angle, and then restarts the coroutine.

    public void ChangeCurrentAngle(Quaternion angleToChange)
    {
		StopCoroutine("WaitToResetPosition");
    	currentAngle = angleToChange;
    	StartCoroutine("WaitToResetPosition");
    	
    }

    public IEnumerator WaitToResetPosition() {
    	trigger = false;
    	yield return new WaitForSeconds(waitTime);
    	trigger = true;
 	}


 	// Hope this helps :)
}
