using UnityEngine;

public class MathUtils
{
    public static bool AlmostEquals(float a, float b, float threshold)
    {
	    return ((a - b) < 0 ? ((a - b) * -1) : (a - b)) <= threshold;
    }

    public static float ClampAngle360(float angle) 
    {
    if(angle < 0f)
	    return angle + (360f * ((angle / 360f) + 1));
    else if(angle > 360f)
	    return angle - (360f * (angle / 360f));
    else
	    return angle;
    }

    public static float ClampAngle(float a, float start, float end) 
    {
    float width = end - start; 
    float offsetValue = a - start;

    return (offsetValue - (Mathf.Floor(offsetValue / width) * width)) + start;
    }

    public static float GetHeading2d(Transform transform)
    {
        return Mathf.Atan2(transform.forward.y, transform.forward.x) * Mathf.Rad2Deg;
    }

    public static float GetHeading2d(float y, float x)
    {
        return Mathf.Atan2(y, x) * Mathf.Rad2Deg;
    }

    public static float GetRelativeHeading2d(Transform origin, Vector3 targetPos)
    {
        Vector3 direction = origin.position - targetPos;
        return ClampAngle360(GetHeading2d(origin) - GetHeading2d(direction.y, direction.x));
    }
}