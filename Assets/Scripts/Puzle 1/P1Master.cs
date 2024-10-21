using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.Rendering.Universal;

public class P1Master : MonoBehaviour
{
    public Light2D[] sinks;  // Luces que el jugador debe encender
    public Light2D[] reflectedSinks;  // Luces que se encienden y apagan automáticamente
    public GameObject reward;  // Objeto que se dará si el jugador lo hace bien

    private bool playerIsClose;
    private int playerIndex = 0;  // Índice del jugador para encender luces
    private List<int> lightOrder = new List<int>();  // Lista del orden de encendido
    private List<int> playerOrder = new List<int>();  // Lista del orden de encendido del jugador
    private float timeBetweenLight = 1f;  // Tiempo entre encendido de luces
    private float lightTimer;
    private bool puzzleSolved = false;
    private int reflectedIndex = 0;  // Índice de las luces automáticas

    // Start is called before the first frame update
    void Start()
    {
        ResetLights(reflectedSinks);
        ResetLights(sinks);

        // Crear el orden de las luces automáticas (reflectedSinks)
        for (int i = 0; i < reflectedSinks.Length; i++)
        {
            lightOrder.Add(i);  // Orden: 0, 1, 2, 3, ... 
        }

        lightTimer = timeBetweenLight;
    }

    // Update is called once per frame
    void Update()
    {
        if (!puzzleSolved)
        {
            LightsOnAndOffAutomatic();

            if (Input.GetKeyDown(KeyCode.E) && playerIsClose)
            {
                LightsOnByPlayer();
            }
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
        }
    }

    // Función que enciende y apaga las luces en el array reflectedSinks en orden, en bucle
    void LightsOnAndOffAutomatic()
    {
        if (lightTimer <= 0)
        {
            reflectedSinks[reflectedIndex].intensity = 10;

            // Apaga la luz anterior si no es la primera
            if (reflectedIndex > 0)
            {
                reflectedSinks[reflectedIndex - 1].intensity = 0;
            }

            reflectedIndex++;
            if (reflectedIndex >= reflectedSinks.Length)
            {
                // Apaga la última luz cuando el ciclo vuelve al inicio
                reflectedSinks[reflectedSinks.Length - 1].intensity = 0;
                reflectedIndex = 0;
            }

            lightTimer = timeBetweenLight;  // Reiniciar el temporizador
        }
        else
        {
            lightTimer -= Time.deltaTime;
        }
    }

    // Lógica cuando el jugador presiona "E" para encender una luz
    void LightsOnByPlayer()
    {
        if (playerIndex < sinks.Length)
        {
            sinks[playerIndex].intensity = 10;  // Enciende la luz de sinks en el índice actual

            // Agregar la luz encendida a la lista de orden del jugador
            playerOrder.Add(playerIndex);

            // Verificar si el jugador sigue el mismo orden que las luces automáticas
            if (playerOrder[playerIndex] == lightOrder[playerIndex])
            {
                playerIndex++;

                // Si el jugador ha encendido todas las luces en el orden correcto
                if (playerIndex == sinks.Length)
                {
                    puzzleSolved = true;
                    GiveReward();
                }
            }
            else
            {
                // Si el jugador se equivoca en el orden, reseteamos el puzzle
                ResetPuzzle();
            }
        }
    }

    // Función que entrega la recompensa
    void GiveReward()
    {
        if (reward != null)
        {
            reward.SetActive(true);  // Activamos la recompensa
        }
        Debug.Log("¡Puzzle resuelto! Recompensa otorgada.");
    }

    // Función que resetea el puzzle si el jugador falla en el orden
    void ResetPuzzle()
    {
        playerIndex = 0;  // Reiniciar el índice del jugador
        playerOrder.Clear();  // Vaciar la lista del orden del jugador
        ResetLights(sinks);  // Apagar todas las luces de sinks
        Debug.Log("Orden incorrecto, puzzle reseteado.");
    }

    // Función auxiliar para apagar todas las luces en un array de Light2D
    void ResetLights(Light2D[] lightsArray)
    {
        foreach (Light2D light in lightsArray)
        {
            light.intensity = 0;
        }
    }
}
