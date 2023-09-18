using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneControl : MonoBehaviour
{
    public GameObject scene1;
    public GameObject scene2;
    public GameObject scene3;
    public GameObject scene4;
    public GameObject scene5;


    void Start()
    {
        // Inicialize o jogo com a Cena 1 ativa e a Cena 2 desativada
        scene1.SetActive(true);
        scene2.SetActive(false);
        scene3.SetActive(false);
        scene4.SetActive(false);
        scene5.SetActive(false);
    }


    public void IrParaCena1()
    {
        AtivarCena(1);
    }
    public void IrParaCena2()
    {
        AtivarCena(2);
    }

    public void IrParaCena3()
    {
        AtivarCena(3);
    }

    public void IrParaCena4()
    {
        AtivarCena(4);
    }

    public void IrParaCena5()
    {
        AtivarCena(5);
    }

    // void AtivarCena(int cenaAtiva)
    // {
    //     // Desativa todas as cenas
    //     scene1.SetActive(false);
    //     scene2.SetActive(false);
    //     scene3.SetActive(false);
    //     scene4.SetActive(false);
    //     scene5.SetActive(false);

    //     // Ativa apenas a cena desejada
    //     switch (cenaAtiva)
    //     {
    //         case 1:
    //             scene1.SetActive(true);
    //             break;
    //         case 2:
    //             scene2.SetActive(true);
    //             break;
    //         case 3:
    //             scene3.SetActive(true);
    //             break;
    //         case 4:
    //             scene4.SetActive(true);
    //             break;
    //         case 5:
    //             scene5.SetActive(true);
    //             break;
    //     }
    // }
    void AtivarCena(int cenaAtiva)
    {
        // Crie um array para armazenar todas as cenas
        GameObject[] cenas = { scene1, scene2, scene3, scene4, scene5 };

        // Desativa todas as cenas
        foreach (var cena in cenas)
        {
            cena.SetActive(false);
        }

        // Ativa apenas a cena desejada
        cenas[cenaAtiva - 1].SetActive(true);
    }
}