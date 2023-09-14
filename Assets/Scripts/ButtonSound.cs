using UnityEngine;
using UnityEngine.UI;

public class BotaoComSom : MonoBehaviour
{
    public AudioSource somBotao;

    void Start()
    {
        // Adiciona uma função ao evento de clique do botão
        GetComponent<Button>().onClick.AddListener(PlaySound);
    }

    void PlaySound()
    {
        // Toca o som
        somBotao.Play();
    }
}
