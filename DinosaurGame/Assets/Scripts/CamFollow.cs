using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform player;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        //pos = distance - transform.position.x - player.transform.position.x;
        //
            transform.position = new Vector3( player.position.x + 10, transform.position.y, transform.position.z);
        //}
    }
}
