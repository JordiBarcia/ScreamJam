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

    public void TriggerMirror() 
    {
        hasMirror = true;
    }
    public void TriggerMatches()
    {
        hasMatches = true;
    }
    public void TriggerDoctor()
    {
        hasKeyDoctor = true;
    }
    public void TriggerBottleWine()
    {
        hasBottleWine = true;
    }
    public void TriggerWardrobe()
    {
        hasKeyWardrobe = true;
    }
}
