using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vectoresJugador : MonoBehaviour
{
    public Vector3 direccionJug,spawnMeteoritoD,spawnMeteoritoIz;
    [SerializeField] float magnitudVector,magnitudD,magnitudIz;
    [SerializeField] Transform jugador;
    void Start()
    {
        direccionJug = jugador.position - transform.position;
        direccionJug = direccionJug.normalized * magnitudVector;

        spawnMeteoritoD = Perpendicular(direccionJug, true, magnitudD);
        spawnMeteoritoIz = Perpendicular(direccionJug, false, magnitudIz);
    }

    // Update is called once per frame
    void Update()
    {
        direccionJug = jugador.position-transform.position;
        direccionJug = direccionJug.normalized * magnitudVector;

        spawnMeteoritoD= Perpendicular(direccionJug, true,magnitudD);
        spawnMeteoritoIz = Perpendicular(direccionJug, false,magnitudIz);
        Debug.DrawLine(transform.position, direccionJug, Color.red);
        Debug.DrawLine(transform.position, spawnMeteoritoIz, Color.blue);
        Debug.DrawLine(transform.position, spawnMeteoritoD, Color.green);
    }
    Vector3 Perpendicular(Vector3 vectorOriginal, bool contrario, float magnitud)
    {
        Vector3 perpendicular = new Vector3();
        if (contrario == true)
        {
            perpendicular.x = vectorOriginal.y;
            perpendicular.y = -vectorOriginal.x;
        }
        else
        {
            perpendicular.x = -vectorOriginal.y;
            perpendicular.y = vectorOriginal.x;
        }

        perpendicular = perpendicular.normalized * magnitud;
        
        return perpendicular;
    }
}
