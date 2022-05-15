using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleMovement : MonoBehaviour
{
    public Transform rotationcenter;
    public float angularspeed, rotationRadius;
    private float posX, posY, angle = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            MovimientoCircular();
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            MovimientoCircularNegativo();
        }
    }

    public void MovimientoCircular()
    {
        posX = rotationcenter.position.x + Mathf.Cos(angle) * rotationRadius;
        posY = rotationcenter.position.y + Mathf.Sin(angle) * rotationRadius;
        transform.position = new Vector2(posX, posY);
        angle = angle + Time.deltaTime * angularspeed;

        if (angle == 360)
        {
            angle = 0;
        }


    }
    public void MovimientoCircularNegativo()
    {
        posX = rotationcenter.position.x + Mathf.Cos(angle) * rotationRadius;
        posY = rotationcenter.position.y + Mathf.Sin(angle) * rotationRadius;
        transform.position = new Vector2(posX, posY);
        angle = angle + Time.deltaTime * -angularspeed;

        if (angle == 360)
        {
            angle = 0;
        }


    }


}
