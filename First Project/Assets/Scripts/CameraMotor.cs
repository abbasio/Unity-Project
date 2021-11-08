using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMotor : MonoBehaviour
{
    public Transform lookAt;
    public float boundX = 0.15f;
    public float boundY = 0.05f;

    private void LateUpdate()
    {
        Vector3 delta = Vector3.zero; //Difference between current and next frame

        //Check out of bounds on X axis
        float deltaX = lookAt.position.x - transform.position.x;
        if (deltaX > boundX || deltaX < -boundX) //if the player is out of bounds on the left or right
        {
            if (transform.position.x < lookAt.position.x) //Checks if the center camera position is left of the lookAt position
            {
                delta.x = deltaX - boundX;
            }
            else //If we're on the right
            {
                delta.x = deltaX + boundX;
            }
        }

        //Check out of bounds on Y axis
        float deltaY = lookAt.position.y - transform.position.y;
        if (deltaY > boundY || deltaY < -boundY) //if the player is out of bounds up or down
        {
            if (transform.position.y < lookAt.position.y) //Checks if the center camera position is smaller than the lookAt position
            {
                delta.y = deltaY - boundY;
            }
            else //If we're on the other side
            {
                delta.y = deltaY + boundY;
            }
        }

        transform.position += new Vector3(delta.x, delta.y, 0);
    }
}
