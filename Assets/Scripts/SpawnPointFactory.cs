using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPointFactory
{
    public SpawnPointFactory()
    {

    }

    public Dictionary<PointType, List<Vector3>> Build(Vector3 diamondPos, Vector3 playerPos, float width, float maxHeight)
    {
        var pointsDict = new Dictionary<PointType, List<Vector3>>();

        pointsDict.Add(PointType.Top, new List<Vector3>() { new Vector3(diamondPos.x, diamondPos.y + maxHeight, diamondPos.z) });

        List<PointType> pointTypes = new List<PointType>() { PointType.High, PointType.Medium, PointType.Low };
        List<float> percentages = new List<float>() { 0.9f, 0.5f, 0f };

        for (int i = 0; i < percentages.Count; i++)
        {
            float y = GetYAtPercent(diamondPos.y, maxHeight, percentages[i]);
            pointsDict.Add(pointTypes[i], GetPointsAtYLevel( diamondPos, playerPos, y, width));
        }

        return pointsDict;
    }

    private float GetYAtPercent(float baseY, float maxHeight, float percentage)
    {
        float difference = maxHeight - baseY;
        float percentDiffernce = difference * percentage;
        return baseY + percentDiffernce;
    }

    private List<Vector3> GetPointsAtYLevel(Vector3 diamondPos, Vector3 playerPos, float y, float width)
    {
        return new List<Vector3>()
        {
            GetPointAtAngle(90,  width, y, diamondPos, playerPos),
            GetPointAtAngle(180, width, y, diamondPos, playerPos),
            GetPointAtAngle(0,   width, y, diamondPos, playerPos)
        };
    }

    private Vector3 GetPointAtAngle(float degrees, float radius, float y, Vector3 diamondPos, Vector3 playerPos)
    {
        degrees += GetPlayerAngle(diamondPos, playerPos);

        var radians = degrees * Mathf.Deg2Rad;
        var x = Mathf.Cos(radians);
        var z = Mathf.Sin(radians);
        var pos = new Vector3(x, y, z);
        var posWRadius = pos * radius;

        return diamondPos + posWRadius;
    }

    private float GetPlayerAngle(Vector3 diamondPos, Vector3 playerPos)
    {
        var dot = Vector3.Dot(diamondPos, playerPos);
        dot /= (diamondPos.magnitude * playerPos.magnitude);

        var acos = Mathf.Acos(dot);
        var angle = acos * 180 / Mathf.PI;

        var diamondAngle = Vector3.Angle(diamondPos, playerPos);
        var playerAngle = Vector3.Angle(playerPos, diamondPos);

        return angle;
    }


}

public enum PointType
{
    Top,
    High,
    Medium,
    Low
}
