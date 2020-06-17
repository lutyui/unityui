using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class logger : MonoBehaviour
{
    utils3D util3D = new utils3D();
    loggerCSV position_logger;
    loggerCSV position_logger2;
    public GameObject[] cubes = new GameObject[3];
    public GameObject src;
    public GameObject dst;
    public GameObject target;
    // Start is called before the first frame update
    private LineRenderer line;
    void OnEnable()
    {
        position_logger = this.GetComponents<loggerCSV>()[0];
        position_logger2 = this.GetComponents<loggerCSV>()[1];
    }
    void Start()
    {
        util3D.hello_world();

        float[] array = { 3f, 1f, 4f };
        line = util3D.draw_line(src, dst, length: 10f, radius: 0.001f);
        line.material = new Material(Shader.Find("Mobile/Particles/Additive"));
        //line.material = new Material(Shader.Find("Mobile/Particles/Additive"));
        var a = position_logger.write_line("x,y,x");
        var b = position_logger2.write_line("ax,ay,ax");

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
        util3D.update_line(line, src, dst, length: 10f);
        Debug.Log(util3D.distance_from_line(src.transform.position, dst.transform.position, target.transform.position));
        if (Input.GetKey(KeyCode.C))
        {
            line.startColor = Color.blue;
            line.endColor = Color.blue;

            Debug.Log("color changed");
        }
        float[] array = new float[3];
        for (int i = 0; i < 3; i++)
        {
            array[i] = target.transform.position[i];
        }
        var a = position_logger.write_line_float(array);
        var b = position_logger2.write_line_float(array);

    }
}
