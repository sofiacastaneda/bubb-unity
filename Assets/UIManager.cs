using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.MagicLeap;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{

    private MLInput.Controller controller;
    public GameObject BienvUsuario;
    public GameObject controllerInput;

    public GameObject controllerCanvas;
    public GameObject[] Objects;
    public GameObject[] ObjectsText;
    // Start is called before the first frame update
    void Start()
    {
        MLInput.Start();
        controller = MLInput.GetController(MLInput.Hand.Left);
        controllerCanvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(controller.TriggerValue > 0.5f)
        {
            RaycastHit hit;
            if(Physics.Raycast(controllerInput.transform.position, controllerInput.transform.forward, out hit))
            {
                if(hit.transform.gameObject.name == "startButton")
                {
                    StartApp();
                }
            }
        }

        UpdateTouchPad();
    }

    void StartApp()
    {
        BienvUsuario.SetActive(false);
        controllerCanvas.SetActive(true);
    }

    private void OnDestroy()
    {

        MLInput.Stop();
    }

    void UpdateTouchPad()
    {
        if(controller.Touch1Active)
        {
            float x = controller.Touch1PosAndForce.x;
            float y = controller.Touch1PosAndForce.y;
            float force = controller.Touch1PosAndForce.z;

            if(force > 0)
            {
                if (x < 0.2 && y > 0.2) //top left
                {
                    //controllerInput.GetComponent<placeObj>().ObjectToPlace = Objects[0];
                    ObjectsText[0].GetComponent<TextMeshProUGUI>().color = Color.magenta;
                    ObjectsText[1].GetComponent<TextMeshProUGUI>().color = Color.white;
                }
                else if (x > 0.2 && y > 0.2) //top right
                {
                    //controllerInput.GetComponent<placeObj>().ObjectToPlace = Objects[1];
                    ObjectsText[0].GetComponent<TextMeshProUGUI>().color = Color.white;
                    ObjectsText[1].GetComponent<TextMeshProUGUI>().color = Color.magenta;
                }
            }
        }
    }
}
