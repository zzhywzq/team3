using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DrawStar : MonoBehaviour
{


    public Material _mat;
    public Color _starColor;


    const float minDistance = 1.5f;
    const float maxDistance = 8f;


    public float length = 2.5f;
    float distance = minDistance;

    public float increaseSpeed = 5f;

    Vector2[] offset;

    private void Start()
    {
        offset = new Vector2[16];
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            distance += Time.deltaTime * increaseSpeed;
        }
        else
        {
            distance -= Time.deltaTime * increaseSpeed;
        }

        if (distance < minDistance)
        {
            distance = minDistance;
        }
        else if (distance > maxDistance)
        {
            distance = maxDistance;
        }


    }


    private void OnPostRender()
    {
        DrawLine(Input.mousePosition);
    }

    void DrawLine(Vector2 center)
    {
        GL.PushMatrix();
        _mat.SetPass(0);
        GL.LoadOrtho();
        GL.Begin(GL.LINES);
        GL.Color(_starColor);

        offset[0] = new Vector2(-distance - length, distance);
        offset[1] = new Vector2(-distance, distance);
        offset[2] = new Vector2(distance + length, distance);
        offset[3] = new Vector2(distance, distance);

        for (int j = 0; j < 2; j++)
        {
            int isY = j % 2 == 0 ? 1 : -1;
            for (int i = 0; i < 4; i += 2)
            {
                int isX = i % 4 > 1 ? 1 : -1;
                offset[j * 4 + i] = new Vector2(isX * (distance + length), isY * distance);
                offset[j * 4 + i + 1] = new Vector2(isX * distance, isY * distance);
            }
        }

        for (int i = 0; i < 8; i++)
        {
            offset[i + 8].x = offset[i].y;
            offset[i + 8].y = offset[i].x;
        }



        for (int i = 0; i < offset.Length; i += 2)
        {
            DrawLine(center + offset[i], center + offset[i + 1]);
        }

        GL.End();
        GL.PopMatrix();

    }

    void DrawLine(Vector2 start, Vector2 end)
    {
        GL.Vertex3(start.x / Screen.width, start.y / Screen.height - (float)0.05, 0);
        GL.Vertex3(end.x / Screen.width, end.y / Screen.height - (float)0.05, 0);
    }
}
