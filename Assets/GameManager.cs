using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
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
    public bool hasKeyLunch;
    public bool hasKeySalon;

    public bool deadPersonalidad;
    public bool deadDepre;
    public bool deadEsquizo;

    GameObject personalidad;
    public GameObject personalidad2;
    GameObject depre;
    public GameObject depre2;
    GameObject esquizo;
    public GameObject esquiz2;

    public GameObject doorsWardrobe;
    public GameObject doorsDoctor;
    public GameObject doorsLunch;
    public GameObject doorSalon;

    public GameObject deathBedpersonalidad;
    public GameObject deathBedDepre;
    public GameObject deathBedEsquizo;

    public GameObject keyDoctor;
    public GameObject keyWardrobe;
    public GameObject keyLunch;
    public GameObject keySalon;

    public GameObject ForbiddenDoctor;
    public GameObject ForbiddenWardrobe;
    public GameObject ForbiddenLunch;
    public GameObject ForbiddenSalon;
    

    bool donePersonalidad;
    bool doneDepre;
    bool doneEsquizo;
    private float timeBeforeDead;

    private static GameManager instance;

    void Start()
    {
        donePersonalidad = false;
        doneDepre = false;
        doneEsquizo = false;
        timeBeforeDead = 2.5f;
    }
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        personalidad = GameObject.FindWithTag("T.Personalidad");
        depre = GameObject.FindWithTag("Depre");
        esquizo = GameObject.FindWithTag("Esquizo");
    }
    // Update is called once per frame
    void Update()
    {
        if (hasMirror) 
        {
            if (deadPersonalidad && !donePersonalidad)
            {
                timeBeforeDead -= Time.deltaTime;
                if (timeBeforeDead < 0) { 
                    personalidad.SetActive(false);
                    personalidad2.SetActive(false);
                    deathBedpersonalidad.SetActive(true);
                    keyWardrobe.SetActive(true);
                    donePersonalidad = true;
                    timeBeforeDead = 2.5f;
                }
            }
            else if(!donePersonalidad)
            {
                personalidad.SetActive(false);
                personalidad2.SetActive(true);
            }
            if (donePersonalidad)
            {
                personalidad.SetActive(false);
                personalidad2.SetActive(false);
            }
        }
        if (hasMatches) {
            if (deadDepre && !doneDepre)
            {
                timeBeforeDead -= Time.deltaTime;
                if (timeBeforeDead < 0)
                {
                    depre.SetActive(false);
                    depre2.SetActive(false);
                    deathBedDepre.SetActive(true);
                    keyLunch.SetActive(true);
                    doneDepre = true;
                    timeBeforeDead = 2.5f;
                }
            }
            else if(!doneDepre)
            {
                depre.SetActive(false);
                depre2.SetActive(true);
            }
            if (doneDepre)
            {
                depre.SetActive(false);
                depre2.SetActive(false);
            }
        }
        if (hasBottleWine) {
            if (deadEsquizo && !doneEsquizo)
            {
                timeBeforeDead -= Time.deltaTime;
                if (timeBeforeDead < 0)
                {
                    esquizo.SetActive(false);
                    esquiz2.SetActive(false);
                    deathBedEsquizo.SetActive(true);
                    keyDoctor.SetActive(true);
                    doneEsquizo = true;
                    timeBeforeDead = 2.5f;
                }
            }
            else if (!doneEsquizo)
            {
                esquizo.SetActive(false);
                esquiz2.SetActive(true);
            }
            if (doneEsquizo)
            {
                esquizo.SetActive(false);
                esquiz2.SetActive(false);
            }
        }
        if (hasKeyWardrobe) {
            doorsWardrobe.SetActive(false);
            ForbiddenWardrobe.SetActive(false);
        }
        if (hasKeyDoctor) {
            doorsDoctor.SetActive(false);
            ForbiddenDoctor.SetActive(false);
        }

        if (hasKeyLunch)
        {
            doorsLunch.SetActive(false);
            ForbiddenLunch.SetActive(false);
        }

        if (hasKeySalon) 
        {
            doorSalon.SetActive(false);
            ForbiddenSalon.SetActive(false);
        }
    }

    void SetNPCS() 
    {
        personalidad = GameObject.FindWithTag("T.Personalidad");
        personalidad2 = GameObject.FindWithTag("T.Personalidad2");
        depre = GameObject.FindWithTag("Depre");
        depre2 = GameObject.FindWithTag("Depre2");
        esquizo = GameObject.FindWithTag("Esquizo");
        esquiz2 = GameObject.FindWithTag("Esquizo2");
    }

    public void TriggerMirror() 
    {
        hasMirror = true;
        personalidad.SetActive(false);
        personalidad2.SetActive(true);
    }
    public void TriggerMatches()
    {
        hasMatches = true;
        depre.SetActive(false);
        depre2.SetActive(true);
    }
    public void TriggerDoctor()
    {
        hasKeyDoctor = true;
        doorsDoctor.SetActive(false);
    }
    public void TriggerBottleWine()
    {
        hasBottleWine = true;
        esquizo.SetActive(false);   
        esquiz2.SetActive(true);   
    }
    public void TriggerWardrobe()
    {
        hasKeyWardrobe = true;
        doorsWardrobe.SetActive(false);
    }
    public void TriggerLunch() 
    {
        hasKeyLunch = true;
        doorsLunch.SetActive(true);
    }
    public void MotherSalon() 
    {
        hasKeySalon = true;
        doorSalon.SetActive(false);
    }
}
