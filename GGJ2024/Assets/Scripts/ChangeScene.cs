using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public void LoadScene(string cena)
    {
        SceneManager.LoadScene("GameKallebe");
    }

    public void Voltar(string cena)
    {
        SceneManager.LoadScene("Menu");
    }

    public void Creditos(string cena)
    {
        SceneManager.LoadScene("Creditos");
    }

    public void Sair(string cena)
    {
       // SceneManager.LoadScene("GameKallebe");
    }
}
