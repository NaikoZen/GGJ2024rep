using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class TimerController : MonoBehaviour
{
    public float remTime = 0f;
    public bool checkTemp = true;
    public TMP_Text tmp;

    void Start()
    {
        checkTemp = true;
    }

    void Update()
    {
        if (checkTemp)
        {
            if (remTime > 0f)
            {
                remTime -= Time.deltaTime;
                Mostrador(remTime);
            }
            else
            {
                remTime = 0f;
                checkTemp = false;
                GameOver();
            }
        }
    }

    void Mostrador(float tempoMostrador)
    {
        float minutos = Mathf.FloorToInt(tempoMostrador / 60);
        float segundos = Mathf.FloorToInt(tempoMostrador % 60);
        tmp.text = string.Format("{0:00} : {1:00}", minutos, segundos);
    }

    void GameOver()
    {
        GameManager.luzesAcesas = 0;
        DragDrop.canosConectados = 0;
        Vencer.porta = 0;
        SceneManager.LoadScene("GameKallebe");
    }
}
