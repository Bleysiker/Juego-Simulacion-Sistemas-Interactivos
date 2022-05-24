using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour
{
    [SerializeField]Vector3 diff,perpendicular;
    [SerializeField] float angulo;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Rotar();
    }

    public void Rotar()
    {
        diff = Vector3.zero - transform.position;
        perpendicular.x = diff.y;
        perpendicular.y = -diff.x;
        angulo = Mathf.Atan2(perpendicular.y, perpendicular.x);
        transform.rotation = Quaternion.Euler(0f, 0f, angulo * Mathf.Rad2Deg );

    }

}
