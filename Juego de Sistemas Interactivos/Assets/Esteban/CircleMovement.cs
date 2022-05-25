using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleMovement : MonoBehaviour
{
    public Transform rotationcenter;
    [SerializeField] private Vector3 izq, der;

    public float angularspeed, rotationRadius;
    private float posX, posY, angle = 0;
    [SerializeField] private Animator animator;
    


    // Start is called before the first frame update
    void Start()
    {
        
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("Dino", Mathf.Abs(angle));
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.localScale = izq;
            MovimientoCircularNegativo();
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.localScale = der;
            
            MovimientoCircular();

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
