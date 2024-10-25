using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using TMPro;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Dialogue : MonoBehaviour
{
    public GameObject dialoguePanel;
    public TextMeshProUGUI dialogueText;
    public string[] dialogue;
    private int index = 0;

    public float wordSpeed;
    public bool playerIsClose;

    public GameObject button;

    public Image Characterface;
    public Sprite[] imageFromDialogue;

    public bool isEnding;
    private Animator transitionAnimator;

    public Timer timer;
    int sceneIndex;

    public GameManager gameManager;

    public bool isPesonalidad;
    public bool isDepre;
    public bool isEsquizo;

    private Coroutine typingCoroutine;

    private void Awake()
    {
       
    }
    private void Start()
    {
        // Aseguramos que se use la referencia del inspector si ya fue asignada
        if (Characterface == null)
        {
            Characterface = GetComponent<Image>();
        }
        // Inicializamos la primera imagen correspondiente al primer diálogo
        UpdateCharacterImage();
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
        transitionAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && playerIsClose)
        {
            if (dialoguePanel.activeInHierarchy)
            {
                zeroText();
            }
            else
            {
                dialoguePanel.SetActive(true);
                StartTyping();
            }
        }
        if (dialogueText.text == dialogue[index])
        {
            button.SetActive(true);
        }

    }

    public void zeroText() 
    {
        dialogueText.text = "";
        index = 0;
        dialoguePanel.SetActive(false);
    }

    public void NextLine() 
    {
        button.SetActive(false);
        if (index < dialogue.Length - 1)
        {
            index++;
            dialogueText.text = "";
            StartTyping();
            UpdateCharacterImage();
        }
        else
        {
            zeroText();
            if (isEnding)
            {
                Debug.Log("FINALE");
                if (isPesonalidad)
                {
                    gameManager.deadPersonalidad = true;
                }
                if (isDepre)
                {
                    gameManager.deadDepre = true;
                }
                if (isEsquizo)
                {
                    gameManager.deadEsquizo = true;
                }
                timer.Yeepe();
            }
        }
    }

    private void StartTyping()
    {
        // Cancela la corutina actual si existe
        if (typingCoroutine != null)
        {
            StopCoroutine(typingCoroutine);
        }
        typingCoroutine = StartCoroutine(Typing());
    }

    IEnumerator Typing() 
    {
        dialogueText.text = ""; // Reinicia el texto antes de empezar a escribir
        foreach (char letter in dialogue[index].ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(wordSpeed);
        }
    }

    private void UpdateCharacterImage()
    {
        // Aseguramos que el índice está dentro del rango del array de imágenes
        if (index < imageFromDialogue.Length)
        {
            Characterface.sprite = imageFromDialogue[index];
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) 
        {
            playerIsClose = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerIsClose = false;
            zeroText();
        }
    }
}
