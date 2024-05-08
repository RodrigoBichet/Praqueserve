using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI; // Adicionando para acessar componentes de UI

public class ItemColado : MonoBehaviour, IDropHandler
{
    public AudioSource soundCongratulation;
    public AudioSource soundWrong;
    public GameObject imagemAtivada; // Referência à imagem ativada
    public GameObject imagemDesativada; // Referência à imagem desativada

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            if (eventData.pointerDrag.gameObject.tag.Equals(gameObject.tag))
            {
                // Verifica se a referência à imagem ativada não é nula
                if (imagemAtivada != null)
                {
                    // Desativa a imagem inicial
                    gameObject.SetActive(false);

                    // Ativa a imagem substituta
                    imagemAtivada.SetActive(true);

                    // Obtém a RectTransform da imagem ativada
                    RectTransform rtAtivada = imagemAtivada.GetComponent<Image>().rectTransform;

                    // Obtém a RectTransform do item arrastado
                    RectTransform rtItemArrastado = eventData.pointerDrag.GetComponent<Image>().rectTransform;

                    // Centraliza o item arrastado na imagem ativada
                    rtItemArrastado.anchoredPosition = rtAtivada.anchoredPosition;
                }
                else
                {
                    Debug.LogError("A referência à imagem ativada é nula!");
                }

                DragDrop.coloucerto = true;
                PlayerPrefs.SetInt("faseAtual", SceneManager.GetActiveScene().buildIndex);

                soundCongratulation.Play();
            }
            else
            {
                soundWrong.Play();
            }
        }
    }
}
