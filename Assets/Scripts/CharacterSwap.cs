using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Neuron;

public class CharacterSwap : MonoBehaviour, SwapInterface
{
    [SerializeField] GameObject actor;
    [SerializeField] List<GameObject> allChoices = new List<GameObject>();

    private int currentChoice;
    private NeuronTransformsInstance transformInstance;

    // Start is called before the first frame update
    void Start()
    {
        transformInstance = actor.GetComponent<NeuronTransformsInstance>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetChoice(int choiceIndex)
    {
        foreach (Transform child in actor.transform) {
            GameObject.Destroy(child.gameObject);
        }
        StartCoroutine(setChoiceDelay(choiceIndex));
    }

    IEnumerator setChoiceDelay(int choiceIndex) {
        yield return new WaitForSeconds(.1f);
        GameObject newModel = Instantiate(allChoices[choiceIndex], actor.transform);
        transformInstance.Bind(newModel.transform, "");
    }

    public List<GameObject> ReturnChoices()
    {
        return(allChoices);
    }
}
