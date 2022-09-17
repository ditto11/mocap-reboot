using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Neuron;

public class BackgroundSwap : MonoBehaviour, SwapInterface
{
    [SerializeField] List<GameObject> allChoices;

    private int currentChoice;
    private NeuronTransformsInstance transformInstance;

    // Start is called before the first frame update
    void Start()
    {
        SetChoice(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetChoice(int choiceIndex)
    {
        for(int i=0; i<allChoices.Count; i++) {
            if(i==choiceIndex) {
                allChoices[i].SetActive(true);
            }
            else {
                allChoices[i].SetActive(false);
            }
        }
        currentChoice = choiceIndex;
    }   

    public List<GameObject> ReturnChoices()
    {
        return(allChoices);
    }
}
