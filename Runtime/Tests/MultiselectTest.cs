using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class MultiselectTest : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject testCube;

    private void Start()
    {
        CreateTestObjects();
    }

    // Update is called once per frame
    private void Update()
    {
    }

    private void CreateTestObjects()
    {
        testCube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        testCube.AddComponent<Rigidbody>();
        testCube.AddComponent<XRSimpleInteractable>();
        testCube.AddComponent<BaseSelectable>();
        testCube.transform.position = transform.position;
    }
}