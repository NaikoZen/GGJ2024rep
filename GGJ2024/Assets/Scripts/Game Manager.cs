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
        if (cliked.idNeonronios == colorsSequence[0] && Input.GetMouseButton(0)) 
        {
            Debug.Log("Objeto correto");
            colorsSequence.RemoveAt(0);
            neonRoniosList.Add(cliked);
            cliked.emissionObj.gameObject.SetActive(true);
        }
        
        else if (cliked.idNeonronios != colorsSequence[0] && Input.GetMouseButton(0))
        {
            foreach (NeonRonios neon in neonRoniosList)
            {
                neon.Enablelight(false);
            }
            colorsSequence = new List<int>(sequeneCopy);
            //cliked.emissionObj.gameObject.SetActive(false);
            Debug.Log("Objeto errado!");           
        }
    }

    public void ColorRandom()
    {
        while (colorsSequence.Count < 7)
        {
            int temp = (Random.Range(0, 7));

            if (!colorsSequence.Contains(temp))
            {
                colorsSequence.Add(temp);
            }
        }
    }
}
