using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtrudedConveyor : MonoBehaviour
{

    public float conveyorLength = 1f;
    public float conveyorRadius = .125f;

    [Range(0f, 1f)]
    public float progress = 0f;
    public float speed;

    private float perimiter;
    private float cutoff1; //start of first loop
    private float cutoff2; //end of first loop
    private float cutoff3; //start of second loop

    private Vector3 backPos;
    private Vector3 frontPos;

    [Tooltip("Allow parent to update Transform at runtime")]
    public bool dynamicMode = true;


    // Use this for initialization
    void Start()
    {
        UpdateTransform();
    }

    public void UpdateTransform()
    {
        // Update perimeter and cutoff locations
        float flatLength = (conveyorLength - conveyorRadius * 2f);
        perimiter = 2f * flatLength + Mathf.PI * conveyorRadius * 2f;
        cutoff1 = flatLength / perimiter;
        cutoff2 = (flatLength + Mathf.PI * conveyorRadius) / perimiter;
        cutoff3 = (2f * flatLength + Mathf.PI * conveyorRadius) / perimiter;

        //adjust to parent position
        float length = conveyorLength / 2f - conveyorRadius;
        backPos = transform.parent.position - transform.parent.forward * length;
        frontPos = transform.parent.position + transform.parent.forward * length;
    }

    // Update is called once per frame
    void Update()
    {
        //Account for movement in object root
        if (dynamicMode)
            UpdateTransform();

        // Move each flap along the path
        progress += Time.deltaTime * speed / perimiter;
        progress %= 1f;

        PositionHandler();
    }

    public void PositionHandler()
    {
        if (progress < cutoff1)
        { //Flat top
            transform.localRotation = Quaternion.AngleAxis(0f, Vector3.right);
            transform.position = Vector3.Lerp(backPos, frontPos, (progress / cutoff1));
        }
        else if (progress < cutoff2)
        { // first half circle
            transform.localRotation = Quaternion.Lerp(Quaternion.identity, Quaternion.AngleAxis(179f, Vector3.right), (progress - cutoff1) / (cutoff2 - cutoff1));
        }
        else if (progress < cutoff3)
        { // flat bottom
            transform.localRotation = Quaternion.AngleAxis(180f, Vector3.right);
            transform.position = Vector3.Lerp(frontPos, backPos, ((progress - cutoff2) / (cutoff3 - cutoff2)));
        }
        else
        { //final half circle
            transform.localRotation = Quaternion.Lerp(Quaternion.AngleAxis(180f, Vector3.right), Quaternion.identity, (progress - cutoff3) / (1f - cutoff3));
        }

    }
}
