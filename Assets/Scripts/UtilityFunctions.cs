using System;
using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;

public static class UtilityFunctions 
{
	public static T FindClosest<T>(Vector3 position) where T : MonoBehaviour 
	{
		T closest = null;

		foreach(T thing in GameObject.FindObjectsOfType<T>()){
			if(closest == null){
				closest = thing;
			} else if(Vector3.Distance(position, thing.transform.position) < Vector3.Distance(position, closest.transform.position)){
				closest = thing;
			}
		}

		return closest;
	}

	public static List<T> FindAllObjectsWithinRange<T>(Vector3 position, float distance) where T : MonoBehaviour
	{
		List<T> objects = new List<T>();

		foreach(T thing in GameObject.FindObjectsOfType<T>()){
			if (Vector3.Distance(position, thing.transform.position) < distance){
				objects.Add(thing);
			}
		}

		return objects;
	}

	public static GameObject FindGameObjectThroughNetID(NetworkInstanceId id)
	{
		NetworkIdentity[] NetworkIdentities = GameObject.FindObjectsOfType<NetworkIdentity>();
		foreach (NetworkIdentity netID in NetworkIdentities) {
			if(netID.netId == id){
				return netID.gameObject;
			}
		}

		return null;
	}

	public static T FindGameObjectThroughNetID<T>(NetworkInstanceId id) where T : MonoBehaviour 
	{
		return FindGameObjectThroughNetID(id).GetComponent<T>();
	}

	public static void Shuffle<T>(this IList<T> list)  
	{  
		int n = list.Count;  
		while (n > 1) {  
			n--;  
			int k = RNG.Next(0, n + 1);  
			T value = list[k];  
			list[k] = list[n];  
			list[n] = value;  
		}  
	}

	public static float TrigToAngleRAD(float sine, float cosine)
	{
		double asin = Math.Asin (sine);
		double acos = Math.Acos (cosine);
		
		if (asin >= 0) {
			return (float)(acos);
		} else {
			return (float)((Math.PI*2) - acos);
		}
	}
	
	public static float TrigToAngleDEG(float sine, float cosine){
		return TrigToAngleRAD(sine, cosine) * RADTODEG;
	}
	
	public const float RADTODEG = (float)(180/Math.PI);
}
