using UnityEditor;
using UnityEngine;

public class KirthosUtils
{
	[MenuItem("KirthosUtils/FixInvisibleObjects")]
	private static void FixInvisibleObjects()
	{
		Shader.EnableKeyword ("NO_CURVE");
	}
}
