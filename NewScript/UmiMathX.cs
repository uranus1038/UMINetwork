using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UmiMathX : MonoBehaviour
{
	public static Vector3 rotateH(Vector3 mVector, float mAngle)
	{
		float x = mVector.x * Mathf.Cos(mAngle * 0.017453292f) - mVector.z * Mathf.Sin(mAngle * 0.017453292f);
		float z = mVector.z * Mathf.Cos(mAngle * 0.017453292f) + mVector.x * Mathf.Sin(mAngle * 0.017453292f);
		return new Vector3(x, mVector.y, z);
	}
	
}
