using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_tilt : MonoBehaviour
{

	// Script by "Quick Tutorial"
	// Found at: https://www.youtube.com/watch?v=FGiCejM743g

	// Declare rotation angles and current angle.

	Quaternion targetAngle_90 = Quaternion.Euler(0,0,90);
	Quaternion targetAngle_0 = Quaternion.Euler(0,0,0);
	public Quaternion currentAngle;

    void Start()
    {

    	// Start by setting the current angle to 0.

    	currentAngle = targetAngle_0;
    }

    void Update()
    {

    	// Check for Player input using space bar.

        if(Input.GetKeyDown(KeyCode.Space))
  		{

  			// Call the rotation function.

  			ChangeCurrentAngle();
  		}

  		// Rotate object to the new position.

  		this.transform.rotation = Quaternion.Slerp(this.transform.rotation, currentAngle, 0.2f);
    }

    void ChangeCurrentAngle()
    {

    	// Check the current z angle.
    	// If the z angle matches our starting angle, then set it to 90.
    	// else, switch back to 0.

    	if (currentAngle.eulerAngles.z == targetAngle_0.eulerAngles.z)
    	{
    		currentAngle = targetAngle_90;
    	}
    	else 
    	{
    		currentAngle = targetAngle_0;
    	}
    }
}
