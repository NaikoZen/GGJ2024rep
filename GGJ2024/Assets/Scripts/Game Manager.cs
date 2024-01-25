using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private List<NeonRonios> neonRoniosList = new List<NeonRonios>();
    [SerializeField] private List<int> colorsSequence = new List<int>();
    [SerializeField] private List<int> sequeneCopy = new List<int>();

    public Transform newPosition;
    #region SINGLETON

    public static GameManager instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    #endregion

    private void Start()
    {
        ColorRandom();
        sequeneCopy = new List<int>(colorsSequence);
    }

    public void TryDick(NeonRonios cliked)
    {
        if (cliked.idNeonronios == colorsSequence[0])
        {
            Debug.Log("Objeto correto");
            colorsSequence.RemoveAt(0);
            cliked.gameObject.transform.position = newPosition.position;
            neonRoniosList.Add(cliked);
        }

        else
        {
            foreach (NeonRonios neon in neonRoniosList)
            {
                neon.transform.position = neon.positionObj;
            }
            colorsSequence = new List<int>(sequeneCopy);
            //colorsSequence = sequeneCopy;
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
