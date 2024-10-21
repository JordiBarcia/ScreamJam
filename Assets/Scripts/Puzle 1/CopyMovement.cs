using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopyMovement : MonoBehaviour
{
    public GameObject player;
    public GameObject copycat;

    // Start is called before the first frame update
    void Start()
    {
                    
    }

    // Update is called once per frame
    void Update()
    {
        copycat.transform.position = new Vector2((player.transform.position.x), -1 * ((player.transform.position.y) - 2.5f));
    }
}
