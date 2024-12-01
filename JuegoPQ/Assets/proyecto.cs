using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class proyecto : MonoBehaviour
{
    [SerializeField] int q = 0;
    [SerializeField] int p = 0;
    [SerializeField] int qMarcador = 0;
    [SerializeField] int pMarcador = 0;
    [SerializeField] int WinSize = 125;
    [SerializeField] int LoseSize = 75;
    [SerializeField] int EvenSize = 100;
    [SerializeField] TMP_Text qPressingsUI;
    [SerializeField] TMP_Text pPressingsUI;
    [SerializeField] TMP_Text qTextoVictoriaUI;
    [SerializeField] TMP_Text pTextoVictoriaUI;
    [SerializeField] TMP_Text qTextoMarcadorUI;
    [SerializeField] TMP_Text pTextoMarcadorUI;
    [SerializeField] TMP_Text TextoReinicioUI;

    private bool juegoDetenido = false;

    private Color WinColor = new Color(0.047f, 0.600f, 0f);
    private Color LoseColor = new Color(0.655f, 0.031f, 0.031f);
    private Color EvenColor = Color.black;

    void Start()
    {
        PrintValues();
        TextoReinicioUI.gameObject.SetActive(false);
        qTextoVictoriaUI.gameObject.SetActive(false);
        pTextoVictoriaUI.gameObject.SetActive(false);
    }

    void Update()
    {
        if (juegoDetenido)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Reiniciojuego();
            }
            return; //Hace que al llegar a 10 no siga sumando
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            q++;
            ValidarVictoria();
            PrintValues();
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            p++;
            ValidarVictoria();
            PrintValues();
        }
    }

    void ValidarVictoria()
    {
        if (q == 10)
        {
            qMarcador++;
            qTextoVictoriaUI.gameObject.SetActive(true);
            TextoReinicioUI.gameObject.SetActive(true);
            juegoDetenido = true;
        }
        else if (p == 10)
        {
            pMarcador++;
            pTextoVictoriaUI.gameObject.SetActive(true);
            TextoReinicioUI.gameObject.SetActive(true);
            juegoDetenido = true;
        }
    }

    void Reiniciojuego()
    {
        q = 0;
        p = 0;
        juegoDetenido = false;
        TextoReinicioUI.gameObject.SetActive(false);
        qTextoVictoriaUI.gameObject.SetActive(false);
        pTextoVictoriaUI.gameObject.SetActive(false);
        qTextoMarcadorUI.text = qMarcador.ToString();
        pTextoMarcadorUI.text = pMarcador.ToString();

        PrintValues();
    }

    void PrintValues()
    {
        if (q < p)
        {
            qPressingsUI.fontSize = LoseSize;
            pPressingsUI.fontSize = WinSize;
            qPressingsUI.color = LoseColor;
            pPressingsUI.color = WinColor;
        }
        else if (q > p)
        {
            qPressingsUI.fontSize = WinSize;
            pPressingsUI.fontSize = LoseSize;
            qPressingsUI.color = WinColor;
            pPressingsUI.color = LoseColor;
        }
        else
        {
            qPressingsUI.fontSize = EvenSize;
            pPressingsUI.fontSize = EvenSize;
            qPressingsUI.color = EvenColor;
            pPressingsUI.color = EvenColor;
        }

        qPressingsUI.text = q.ToString();
        pPressingsUI.text = p.ToString();
    }
}

