using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteoritoMove : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Vector3 aceleration, velocity, dirPlaneta,dirDesplazamiento,dirDesplazamientoDesviado;
    [SerializeField] float masa, magnitudFuerzaPlaneta, magnitudFuerzaDesplazamiento,maximaVelocidad;
    [Range(0,360)]
    [SerializeField] float tetha,radio;
    float radian,radianSumado;
    [SerializeField] Transform jugador;
    [SerializeField] bool enOrbita,mover;
    void Start()
    {
        enOrbita = false;

        tetha = 180;
        //dirDesplazamiento = planeta.position-transform.position;
        //Debug.Log(AnguloDelVector(dirDesplazamiento));
        dirDesplazamiento = jugador.position - transform.position;
        radian = tetha * Mathf.PI / 180;
        radianSumado = radian + AnguloDelVector(dirDesplazamiento);
        dirDesplazamientoDesviado = PolarToCartesian(1, radianSumado)+jugador.position-transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();


        //Debug.DrawLine(transform.position, dirDesplazamientoDesviado, Color.red);
        Debug.DrawLine(transform.position, dirPlaneta, Color.green);
        Debug.DrawLine(transform.position, velocity + transform.position, Color.blue);
    }
    private void Move()
    {
        
        if (mover == true)
        {
            aceleration = Vector3.zero;

            dirPlaneta = Vector3.zero-transform.position;
            if (enOrbita == true)
            {
                ApplyForce(dirPlaneta, magnitudFuerzaPlaneta);
                ApplyForce(dirDesplazamientoDesviado, magnitudFuerzaDesplazamiento);
            }
            else
            {
                ApplyForce(dirDesplazamientoDesviado, magnitudFuerzaDesplazamiento);
            }
            
            LimitarVelocidad();
            transform.position += velocity * Time.deltaTime;
        }
        
    }

    void LimitarVelocidad()
    {
        velocity += aceleration * Time.deltaTime;
        if (velocity.magnitude > maximaVelocidad)
        {
            velocity = velocity.normalized * maximaVelocidad;
        }
    }

    void ApplyForce(Vector3 direccion,float fuerza)
    {
        aceleration += direccion.normalized*fuerza / masa;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Orbita")
        {
            enOrbita = true;
        }
    }
    Vector3 PolarToCartesian(float radio, float tetha)
    {
        return new Vector3(radio * Mathf.Cos(tetha), radio * Mathf.Sin(tetha));
    }
    float AnguloDelVector(Vector3 objetoAjeno)
    {
        return Mathf.Atan2(objetoAjeno.x, objetoAjeno.y);
    }
}
