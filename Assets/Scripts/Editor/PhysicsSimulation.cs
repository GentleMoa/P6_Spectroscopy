// Added by Sebastian Kostur //
// Source found online //

// Runs physic simulations for x steps in the editor to position physics objects automatically and in correct positions //

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PhysicsSimulation : MonoBehaviour
{
    public int maxIterations = 1000;
    SimulatedBody[] simulatedBodies;

    [ContextMenu("Run Simulation")]
    public void RunSimulation()
    {
         simulatedBodies = FindObjectsOfType<Rigidbody>().Select(rb => new SimulatedBody(rb)).ToArray();
        Physics.autoSimulation = false;
        for (int i = 0; i< maxIterations; i++)
        {
            Physics.Simulate(Time.fixedDeltaTime);
            if (simulatedBodies.All(body => body.rigidbody.IsSleeping()))
            {
                Debug.Log(i);
                break;
            }
        }
        Physics.autoSimulation = true;
    }

    [ContextMenu("Reset")]
    public void ResetAllBodies()
    {
        if (simulatedBodies != null)
        {
            foreach (SimulatedBody body in simulatedBodies)
            {
                body.Reset();
            }
        }
    }

    struct SimulatedBody
    {
        public readonly Rigidbody rigidbody;
        readonly Vector3 originalPosition;
        readonly Quaternion originalRotation;
        readonly Transform transform;

        public SimulatedBody(Rigidbody rigidbody) : this()
        {
            this.rigidbody = rigidbody;
            transform = rigidbody.transform;
            originalPosition = rigidbody.position;
            originalRotation = rigidbody.rotation;
        }

        public void Reset()
        {
            transform.position = originalPosition;
            transform.rotation = originalRotation;
            rigidbody.velocity = Vector3.zero;
            rigidbody.angularVelocity = Vector3.zero;
        }
    }
}
