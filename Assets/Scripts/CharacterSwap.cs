using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Neuron;

public class CharacterSwap : MonoBehaviour, SwapInterface
{
    [SerializeField] GameObject actor;
    List<GameObject> allChoices = new List<GameObject>();
    [SerializeField] int actorID;

    private int currentChoice;
    private NeuronTransformsInstance transformInstance;

    // Start is called before the first frame update
    void Start()
    {
        transformInstance = actor.GetComponent<NeuronTransformsInstance>();
        StartCoroutine(startInactiveDelay());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetChoice(int choiceIndex)
    {
        foreach (GameObject child in allChoices) {
            child.SetActive(false);
        }
        allChoices[choiceIndex].SetActive(true);
    }

    IEnumerator setChoiceDelay(int choiceIndex) {
        yield return new WaitForSeconds(.1f);
        //transformInstance.Bind(actor.transform.GetChild(0), "");
    }

    IEnumerator startInactiveDelay() {
        yield return new WaitForSeconds(0.1f);
        foreach (Transform child in actor.transform) {
            allChoices.Add(child.gameObject);
            child.gameObject.SetActive(false);
        }
    }

    public List<GameObject> ReturnChoices()
    {
        return(allChoices);
    }
}
