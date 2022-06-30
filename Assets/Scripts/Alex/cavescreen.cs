using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class cavescreen : MonoBehaviour
{
    public Camera cam;
    public bool up;
    public float near = 1.0f;
    public float far = 1000.0f;

    float top;
    float right;
    float bottom;
    float left;

    public GameObject camrig;
    public GameObject topRightFront;
    public GameObject bottomLeftBack;


    // Start is called before the first frame update
    void Start()
    {
    }
    // code taken from https://docs.unity3d.com/ScriptReference/Camera-projectionMatrix.html
    // Description https://www.scratchapixel.com/lessons/3d-basic-rendering/perspective-and-orthographic-projection-matrix/opengl-perspective-projection-matrix
    // or https://www.proggen.org/doku.php?id=theory:math:matrix:projection
    static Matrix4x4 PerspectiveOffCenter(float left, float right, float bottom, float top, float near, float far)
    {
        float x = 2.0F * near / (right - left);
        float y = 2.0F * near / (top - bottom);
        float a = (right + left) / (right - left);
        float b = (top + bottom) / (top - bottom);
        float c = -(far + near) / (far - near);
        float d = -(2.0F * far * near) / (far - near);
        float e = -1.0F;
        Matrix4x4 m = new Matrix4x4();
        m[0, 0] = x;
        m[0, 1] = 0;
        m[0, 2] = a;
        m[0, 3] = 0;
        m[1, 0] = 0;
        m[1, 1] = y;
        m[1, 2] = b;
        m[1, 3] = 0;
        m[2, 0] = 0;
        m[2, 1] = 0;
        m[2, 2] = c;
        m[2, 3] = d;
        m[3, 0] = 0;
        m[3, 1] = 0;
        m[3, 2] = e;
        m[3, 3] = 0;
        return m;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 trf = topRightFront.transform.position - Quaternion.Euler( 0, -cam.transform.rotation.eulerAngles.y, 0) * camrig.transform.position;
        Vector3 blb = bottomLeftBack.transform.position - Quaternion.Euler(0, -cam.transform.rotation.eulerAngles.y, 0) * camrig.transform.position;
        
        right = trf.x;
        left = blb.x;
        near = trf.z;

		if (up)
		{
			top = trf.y;
			bottom = 0;
		}
		else //bottom
		{
			top = 0;
			bottom = blb.y;
		}

		Matrix4x4 m = PerspectiveOffCenter(left, right, bottom, top, near, far);
        cam.projectionMatrix = m;
    }
}

