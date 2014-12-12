using UnityEngine;
using System.Collections;

public class FollowPlayer : MonoBehaviour {

    public GameObject Player;
    public float ChangeX;

	void Update ()
	{
	    if (ChangeX > 5)
	    {
	        ChangeX = 5;
	    }
        if (ChangeX < -5)
        {
            ChangeX = -5;
        }

            transform.position = Player.transform.position;
            transform.Translate(ChangeX, 0, 0);

	}
}
