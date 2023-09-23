using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class ItemColado : MonoBehaviour, IDropHandler
{

    public AudioSource soundCongratulation;
    public AudioSource soundWrong;

    // private void Awake()
    // {
    //     soundCongratulation = GetComponent<AudioSource>();
    //     soundWrong = GetComponent<AudioSource>();
    // }
    public void OnDrop(PointerEventData eventData)
    {

        if (eventData.pointerDrag != null)
        {
            //Debug.Log("Ondrop do objeto");
            //!verifica se as tags coincidem, 
            //!se sim, ele passsa para o codigo de colagem
            if (eventData.pointerDrag.gameObject.tag.Equals(gameObject.tag))
            {
                //!código de colagem
                eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;

                DragDrop.coloucerto = true;
                //Debug.Log("ITEM COLADO COLOUCERTO: " + DragDrop.coloucerto);
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
