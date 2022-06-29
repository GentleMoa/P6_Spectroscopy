using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtrudeConveyorWizard : MonoBehaviour
{

    public GameObject flapPrefab;
    public int numberOfObjs = 4;
    public float length;
    public float radius;
    public float speed;

    public void Generate()
    {
        if (flapPrefab == null)
        {
            Debug.LogError("Need a Flap Prefab");
            return;
        }
        Clear();
        // Create a series of flaps
        for (int i = 0; i < numberOfObjs; i++)
        {
            GameObject offset = new GameObject();
            offset.transform.SetParent(transform, false);
            offset.name = "offset";
            //Allow prefab to sit (offset=radius) away from the center
            GameObject flap = Instantiate(flapPrefab, offset.transform, false) as GameObject;
            flap.transform.localPosition = new Vector3(0f, radius, 0f);
            flap.transform.localRotation = Quaternion.identity;

            ExtrudedConveyor conv = offset.AddComponent<ExtrudedConveyor>();
            conv.conveyorRadius = radius;
            conv.conveyorLength = length;
            conv.speed = speed;
            conv.progress = i * (1f / numberOfObjs);

            //update each flap
            conv.UpdateTransform();
            conv.PositionHandler();
        }
    }

    public void Clear()
    {
        // Clear all children
        while (transform.childCount != 0)
            DestroyImmediate(transform.GetChild(0).gameObject);
    }
}
