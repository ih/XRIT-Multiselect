using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class MultiselectTest : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject testCube;
    void Start()
    {
        CreateTestObjects();
    }
    void CreateTestObjects()
    { 
        testCube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        testCube.AddComponent<Rigidbody>();
        testCube.AddComponent<XRSimpleInteractable>();
        testCube.AddComponent<SimpleSelectable>();
        testCube.transform.position = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
