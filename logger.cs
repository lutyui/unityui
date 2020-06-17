using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class logger : MonoBehaviour
{
    utils3D util3D = new utils3D();
    public GameObject[] cubes = new GameObject[3];
    public GameObject src;
    public GameObject dst;
    public GameObject target;
    // Start is called before the first frame update
    private LineRenderer line;
    void Start()
    {
        util3D.hello_world();

        float[] array = {3f, 1f, 4f};
        line = util3D.draw_line(src, dst, length:10f, radius:0.001f);
        line.material = new Material(Shader.Find("Mobile/Particles/Additive"));
        //line.material = new Material(Shader.Find("Mobile/Particles/Additive"));

    }
    // Update is called once per frame
    void Update()
    {
        //  distance from plane
        /*
        double[] plane_equation = new double[4];
        plane_equation = util3D.calc_plane_from_3objects_position(cubes[0].transform.position, cubes[1].transform.position, cubes[2].transform.position);
        Debug.Log(util3D.distance_from_plane(plane_equation, target.transform.position));
        */
        util3D.update_line(line, src, dst, length:10f);
        Debug.Log(util3D.distance_from_line(src.transform.position , dst.transform.position, target.transform.position));
        if (Input.GetKey(KeyCode.C))
        {
            line.startColor = Color.blue;
            line.endColor = Color.blue;

            Debug.Log("color changed");
        }

    }
}
