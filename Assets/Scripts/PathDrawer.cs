using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PathDrawer
{
    public void LinePointReached(LineRenderer lineRenderer)
    {
        for (int i = 1; i < lineRenderer.positionCount - 1; i++)
        {
            lineRenderer.SetPosition(i, lineRenderer.GetPosition(i + 1));
        }
        lineRenderer.positionCount--;
    }

    public void LinePointAdded(LineRenderer lineRenderer, Vector2 position)
    {
        lineRenderer.positionCount++;
        lineRenderer.SetPosition(lineRenderer.positionCount - 1, position);
    }
}
