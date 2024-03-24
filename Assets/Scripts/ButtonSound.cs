using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BotaoComSom : MonoBehaviour
{
    public AudioSource somBotao;
    public GameObject fotoDesativada;
    public TMP_Text textoAtivar; // Usando TMP_Text do TextMeshPro

    void Start()
    {
        // Adiciona uma função ao evento de clique do botão
        GetComponent<Button>().onClick.AddListener(AtivarElementos);
    }

    void AtivarElementos()
    {
        // Ativa a foto desativada
        fotoDesativada.SetActive(true);

        // Ativa o texto usando TextMeshPro
        textoAtivar.gameObject.SetActive(true);

        // Toca o som
        somBotao.Play();
    }
}
