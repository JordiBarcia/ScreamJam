using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    //Variables dels objectes guardar-ho aquí

    public bool hasMirror;
    public bool hasMatches;
    public bool hasKeyDoctor;
    public bool hasBottleWine;
    public bool hasKeyWardrobe;

    void Start()
    {
      
    }
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
