using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private List<NeonRonios> neonRoniosList = new List<NeonRonios>();
    [SerializeField] private List<int> colorsSequence = new List<int>();

    public static GameManager instance;
    private void Awake()
    {
        instance = this;
        ColorRandom();
    }

    public void TryDick(NeonRonios cliked)
    {
        if (cliked.idNeonronios == colorsSequence[0])
        {
            Debug.Log("Objeto correto");
            colorsSequence.RemoveAt(0);
            Destroy(cliked.gameObject);
        }

        else
        {
            Debug.Log("Objeto errado!");
        }

    }

    public void ColorRandom()
    {
        while (colorsSequence.Count < 6)
        {
            int temp = (Random.Range(0, 6));

            if (!colorsSequence.Contains(temp))
            {
                colorsSequence.Add(temp);
            }
        }
    }
}

