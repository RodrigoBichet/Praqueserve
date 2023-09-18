using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundMenu : MonoBehaviour
{
    // Referência para o componente AudioSource
    public AudioSource audioSource;

    void Awake()
    {
        // Mantém este objeto ao mudar de cena
        DontDestroyOnLoad(gameObject);

        // Obtém a referência para o componente AudioSource
        audioSource = GetComponent<AudioSource>();

        // Inicia a reprodução da música
        audioSource.Play();
    }
}
