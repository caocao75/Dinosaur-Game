using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorGen : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject floor;
    void Start()
    {
        floor = Resources.Load<GameObject>("FloorPrefab/Floor");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            Instantiate(floor, new Vector2(transform.position.x + 35, 0), Quaternion.identity);
            //gameObject.GetComponent<BoxCollider2D>().enabled = false;
            //Debug.Log("Spawned");
        }
    }
}
