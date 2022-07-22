using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Neuron;

public class BackgroundSwap : MonoBehaviour, SwapInterface
{
    List<GameObject> walls = new List<GameObject>();
    // Walls in order are: back, left, right, floor
    [SerializeField] List<GameObject> allChoices;

    private int currentChoice;
    private NeuronTransformsInstance transformInstance;

    // Start is called before the first frame update
    void Start()
    {
        foreach (Transform child in transform) {
            walls.Add(child.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetChoice(int choiceIndex)
    {
        BackgroundSet newSet = allChoices[choiceIndex].GetComponent<BackgroundSet>();
        walls[0].GetComponent<Renderer>().material = newSet.wallImage;
        walls[1].GetComponent<Renderer>().material = newSet.wallImage;
        walls[2].GetComponent<Renderer>().material = newSet.wallImage;
        walls[3].GetComponent<Renderer>().material = newSet.floorImage;
        currentChoice = choiceIndex;
    }   

    public List<GameObject> ReturnChoices()
    {
        return(allChoices);
    }
}
