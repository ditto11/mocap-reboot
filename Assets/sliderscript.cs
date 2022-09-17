using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sliderscript : MonoBehaviour
{
    private static GameObject cameraGO;
    private static Camera cameraC;
    private Slider mySlider;
    private static GameObject actorOne;
    private static GameObject actorTwo;
    private static float yInitialOne;
    private static float yInitialTwo;

    public enum SliderType {
        ActorOne, ActorTwo, FOV
    }

    public SliderType sliderType;

    // Start is called before the first frame update
    void Start()
    {
        cameraGO = GameObject.Find("Main Camera");
        cameraC = cameraGO.GetComponent<Camera>();
        mySlider = gameObject.GetComponent<Slider>();
        actorOne = GameObject.Find("Actor One");
        yInitialOne = actorOne.transform.position.y;
        actorTwo = GameObject.Find("Actor Two");
        yInitialTwo = actorTwo.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnChanged() {
        if(sliderType == SliderType.FOV) {
            cameraC.fieldOfView = mySlider.value;
        }
        else if(sliderType == SliderType.ActorOne) {
            actorOne.transform.position = new Vector3(actorOne.transform.position.x,yInitialOne+mySlider.value,actorOne.transform.position.z);
        }
        else if(sliderType == SliderType.ActorTwo) {
            actorTwo.transform.position = new Vector3(actorTwo.transform.position.x,yInitialTwo+mySlider.value,actorTwo.transform.position.z);
        }
    }

}
