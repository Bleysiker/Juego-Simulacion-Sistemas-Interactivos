using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteoritoMove : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Vector3 aceleration, velocity, dirPlaneta,dirDesplazamiento;
    [SerializeField] float masa, magnitudFuerzaPlaneta, magnitudFuerzaDesplazamiento,maximaVelocidad;

    [SerializeField] int num;
    
    [SerializeField] bool enOrbita,mover;

    [SerializeField] vectoresJugador jugador;
    [SerializeField] Vector3 tamaño;
    [SerializeField] GameObject fuego;
    float valorTamaño;
    GameObject explosion;
    [SerializeField]int cont;
    [SerializeField] Eventos ganarPuntos;
    [SerializeField] bool perseguidor;
    //[SerializeField] AudioClip[] audios; // 0. fuego, 1. choque 
    void Awake()
    {
        enOrbita = false;
        PosicionRandom();
        if (perseguidor == true)
        {
            cont = 0;
        }
        else
        {
            cont = 1;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
        


        Move();


        Debug.DrawLine(transform.position, dirDesplazamiento, Color.red);
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
                ApplyForce(dirDesplazamiento, magnitudFuerzaDesplazamiento);
            }
            else
            {
                ApplyForce(dirDesplazamiento, magnitudFuerzaDesplazamiento);
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
            fuego.SetActive(true);
        }
        if (collision.tag == "Planeta" )
        {

            
            Explotar();
            fuego.SetActive(false);
            PosicionRandom();
            cont++;
            //Debug.Log("choco con planeta");
            enOrbita = false;
            aceleration = Vector3.zero;
            velocity = Vector3.zero;
            if (cont > 1)
            {
                ganarPuntos.FireEvent();
            }
           

        }
        
        
    }
    void velocidadMaximaRandom()
    {
        maximaVelocidad = Random.RandomRange(2, 5);
        masa = Random.RandomRange(0.1f, 0.2f);
        valorTamaño = Random.RandomRange(0.05f, 0.1f);
        tamaño.x = valorTamaño;
        tamaño.y = valorTamaño;
        transform.localScale = tamaño;
    }
  /*  void CambiarSonidos(bool deVuelta)
    {
        meteorito.Stop();
        if (deVuelta == true)
        {
            meteorito.clip = audios[0];
        }
        else
        {
            meteorito.clip = audios[1];
        }
    }*/
    void PosicionRandom()
    {
        velocidadMaximaRandom();
        num = Random.Range(1, 10);
        if (num < 6)
        {
            transform.position = jugador.spawnMeteoritoIz;
        }
        else
        {
            transform.position = jugador.spawnMeteoritoD;
        }
        dirDesplazamiento = jugador.direccionJug - transform.position;
       
        
    }
    void Explotar()
    {
        explosion= PoolExplosiones.SharedInstance.GetPooledObject();
        if (explosion != null)
        {
            explosion.transform.position = transform.position;
            explosion.transform.rotation = transform.rotation;
            explosion.SetActive(true);
            explosion.GetComponent<ParticleSystem>().Play();
        }
    }
}
