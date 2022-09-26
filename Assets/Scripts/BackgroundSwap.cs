using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Neuron;

public class BackgroundSwap : MonoBehaviour, SwapInterface
{
    [SerializeField] List<GameObject> allChoices;
    [SerializeField] GameObject camera;

    private int currentChoice;
    private NeuronTransformsInstance transformInstance;
    private Skybox greenBox;

    // Start is called before the first frame update
    void Start()
    {
        camera = Camera.main.gameObject;
        greenBox = camera.GetComponent<Skybox>();

        SetChoice(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetChoice(int choiceIndex)
    {
        if (allChoices[choiceIndex] == camera) {
            for(int i=0; i<allChoices.Count; i++) {
                if(i!=choiceIndex) {
                    allChoices[i].SetActive(false);
                }
            }
            greenBox.enabled = true;
        }
        else {
            for(int i=0; i<allChoices.Count; i++) {
                if(i==choiceIndex || i==0) {
                    allChoices[i].SetActive(true);
                }
                else {
                    allChoices[i].SetActive(false);
                }
            }
            greenBox.enabled = false;
        }
        currentChoice = choiceIndex;
    }   

    public List<GameObject> ReturnChoices()
    {
        return(allChoices);
    }
}
