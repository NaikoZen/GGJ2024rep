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
        foreach(var neonronio  in neonRoniosList)
        {
            if (neonronio.idNeonronios == cliked.idNeonronios) return;
        }
        neonRoniosList.Add(cliked);
    }

    public void ColorRandom()
    {
        for (int i = 6; i > 0; i++)
        {
            colorsSequence.Add(Random.Range(0, 5)); 
        }
    }
}
