using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script should be put on the flying enemies
// This script is for the flying AIs

public class SplineLogic : MonoBehaviour
{
    [SerializeField] Transform flightPath;
    // The object will start at the second point and will end at the second last point
    [HideInInspector][SerializeField] List<GameObject> flightPathWayPoints;
    // speed is the speed of the object
    [SerializeField] float speed = 0.005f;
    float t = 0.0f;
    int nHead = 0;
    public enum eSplineType
    {
        ST_CATMULLROM
    }
    [SerializeField] eSplineType spline_type = eSplineType.ST_CATMULLROM;
    // flyingEnemy is the flying enemy
    GameObject flyingEnemy;

    // Use this for initialization
    void Start()
    {
        nHead = 0;
        // Set flyingEnemy to the gameObject that the script is on
        flyingEnemy = gameObject;
        for (int i = 0; i < flightPath.childCount; i++)
        {
            flightPathWayPoints.Add(flightPath.GetChild(i).gameObject);
        }
    }

    Vector3 PointOnCurve(float t, Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3)
    {
        Vector3 vOut = new Vector3(0.0f, 0.0f, 0.0f);

        float t2 = t * t;
        float t3 = t2 * t;
        vOut.x = 0.5f * ((2.0f * p1.x) + (-p0.x + p2.x) * t + (2.0f * p0.x - 5.0f * p1.x + 4 * p2.x - p3.x) * t2 +
                    (-p0.x + 3.0f * p1.x - 3.0f * p2.x + p3.x) * t3);
        vOut.y = 0.5f * ((2.0f * p1.y) + (-p0.y + p2.y) * t + (2.0f * p0.y - 5.0f * p1.y + 4 * p2.y - p3.y) * t2 +
                    (-p0.y + 3.0f * p1.y - 3.0f * p2.y + p3.y) * t3);
        vOut.z = 0.5f * ((2.0f * p1.z) + (-p0.z + p2.z) * t + (2.0f * p0.z - 5.0f * p1.z + 4 * p2.z - p3.z) * t2 +
                    (-p0.z + 3.0f * p1.z - 3.0f * p2.z + p3.z) * t3);

        return vOut;
    }

    public void SplineLogicUpdate()
    {
        // Update state, wrap when t exceeds end of curve segment
        t += speed;
        if (t > 1.0f)
        {
            t -= 1.0f;
            nHead++;
        }

        // Reset nHead once we reach end
        if (nHead == (flightPathWayPoints.Count - 2 - 1))
        {
            t = 0.0f;
            nHead = 0;
        }

        Vector3 position0 = flightPathWayPoints[nHead].transform.position;
        Vector3 position1 = flightPathWayPoints[nHead + 1].transform.position;
        Vector3 position2 = flightPathWayPoints[nHead + 2].transform.position;
        Vector3 position3 = flightPathWayPoints[nHead + 3].transform.position;

        Vector3 vOut = PointOnCurve(t, position0, position1, position2, position3);
        if (flyingEnemy)
        {
            flyingEnemy.transform.position = vOut;
        }
    }

    void Update()
    {
        SplineLogicUpdate();
    }
}
