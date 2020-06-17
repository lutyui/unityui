using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;
using System;

public class loggerCSV : MonoBehaviour
{
    [SerializeField]
    private string dirname = "";
    [SerializeField]
    private string filename = "log";
    private StreamWriter stream_writer;
    void OnEnable()
    {
        if (dirname == "")
        {
            dirname = "Assets/Data/CSV/";
        }
        if (!Directory.Exists(dirname))
        {
            Directory.CreateDirectory(dirname);
        }
        var file_full_path = dirname + filename + ".csv";
        int file_index = 0;
        while (true)
        {
            if (!File.Exists(file_full_path))
            {
                stream_writer = new StreamWriter(file_full_path, append: true);
                break;
            }
            else
            {
                file_full_path = dirname + filename + file_index.ToString() + ".csv";
                file_index += 1;
            }
        }
    }

    void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {

    }
    public int write_line(string str)
    {
        stream_writer.WriteLine(str);
        return 0;
    }

    public int write_line_string(string[] array)
    {
        string log_string = String.Join(",", array);
        stream_writer.WriteLine(log_string);
        return 0;
    }
    public int write_line_float(float[] array)
    {
        int length = array.Length;
        string[] str = new string[length];
        for (int i = 0; i < length; i++)
        {
            str[i] = array[i].ToString();
        }
        string log_string = String.Join(",", array);
        stream_writer.WriteLine(log_string);
        return 0;
    }
    void OnApplicationQuit()
    {
        stream_writer.Flush();
        stream_writer.Close();
    }
}
