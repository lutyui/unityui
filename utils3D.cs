using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class utils3D : MonoBehaviour
{
        // section:calc
        public float[] calc_plane_from_3objects_position(Vector3 a, Vector3 b, Vector3 c){
            // return [a, b, c, d] : ax + by + cz + d = 1
            float[] solution = new float[4];
            Vector3 ab = b - a;
            Vector3 ac = c - a;
            Vector3 cross = Vector3.Cross(ab, ac);
            for(int i = 0; i < 3; i++){
                solution[i] = cross[i];
            } 
            solution[3] = - Vector3.Dot(a, cross);
            return solution;
        }
        public float distance_from_line(Vector3 line_src, Vector3 line_dst, Vector3 pos){
            Vector3 v = line_dst - line_src;
            Vector3 line_src2p = pos - line_src;
            return (Vector3.Cross(v, line_src2p)).magnitude / v.magnitude;
        }
        public float distance_from_plane(float[] plane, Vector3 pos){
            Vector3 abc = new Vector3(plane[0], plane[1], plane[2]);
            float distance = Math.Abs(plane[0] * pos.x + plane[1]  * pos.y + plane[2] * pos.z + plane[3]) / abc.magnitude;
            return distance;
        }
        // section:object controll
        public void duplicate_object(GameObject original, int x_num, int z_num, float x_duration, float z_duration){
           var duplicated_object = new GameObject[z_num, x_num];
            for(int i = 0; i < z_num; i++){
                for(int j = 0; j < x_num; j++){
                    duplicated_object[i, j] = Instantiate(original);
                    duplicated_object[i, j].transform.position = new Vector3(x_duration * j, 0, z_duration * i);
                }
            }
            return;
        }
        public LineRenderer draw_line(GameObject src_object, GameObject dst_object, float length=-1, float radius=0.1f){
            Vector3 src_pos = src_object.transform.position;
            Vector3 dst_pos = dst_object.transform.position;
            if(length == -1){
                length = (dst_pos - src_pos).magnitude; 
            }
            GameObject tmp = new GameObject();
            //tmp.transform.parent = transform;
            LineRenderer line = new LineRenderer();
            line = tmp.AddComponent<LineRenderer>();
            line.SetWidth(radius, radius);
            line.SetVertexCount(2);
            line.SetPosition(0, src_pos);
            line.SetPosition(1, (dst_pos - src_pos).normalized * length + src_pos);
            line.material = new Material(Shader.Find("Mobile/Particles/Additive"));
            return line;
        }
        public void update_line(LineRenderer line, GameObject src_object, GameObject dst_object, float length=-1, float radius=0.1f){
            Vector3 src_pos = src_object.transform.position;
            Vector3 dst_pos = dst_object.transform.position;
            if(length == -1){
                length = (dst_pos - src_pos).magnitude; 
            }
            if(radius != -1){
                line.SetWidth(radius, radius);
            }
            line.SetPosition(0, src_pos);
            line.SetPosition(1, (dst_pos - src_pos).normalized * length + src_pos);
        }
        // section:debug
        public void hello_world(){
            Debug.Log("hello world");
        }
        public void show_arrayf(float[] array){
            string tmp = "";
            for(int i = 0; i < array.Length - 1; i++){
                tmp += array[i].ToString() + " : ";
            }
            tmp += array[array.Length-1].ToString();
            Debug.Log(tmp);
        }

}
