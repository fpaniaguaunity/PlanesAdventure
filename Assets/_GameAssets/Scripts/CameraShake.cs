using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using System.Collections;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace fpaniaguaformacion
{
	public class CameraShake : MonoBehaviour
	{
		public float duration;
		public float magnitude;
		public void ShakeCamera()
		{
			StartCoroutine(Shake());
		}
		IEnumerator Shake()
		{
			float elapsed = 0.0f;
			while (elapsed < duration)
			{
				float x = Random.Range(-1f, 1f) * magnitude;
				float y = Random.Range(-1f, 1f) * magnitude;
				transform.position = new Vector3(transform.position.x+x, transform.position.y+y, transform.position.z);
				elapsed+=Time.deltaTime;
				yield return null;
			}
		}
	}
}
