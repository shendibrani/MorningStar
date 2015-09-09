using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StatSelector : Selector
{
	[SerializeField] List<CharacterStats> statSets;

	public CharacterStats currentStats{ get {return statSets[state];} }
}

[System.Serializable]
public struct CharacterStats 
{
	public float health, speed, reach, damage;

	public static CharacterStats operator + (CharacterStats a, CharacterStats b){
		CharacterStats total;
		total.health = a.health+b.health;
		total.speed = a.speed+b.speed;
		total.reach = a.reach+b.reach;
		total.damage = a.damage+b.damage;
		return total;
	}

	public static implicit operator float[] (CharacterStats a){
		float[] array = new float[4];
		array[0] = a.health;
		array[1] = a.speed;
		array[2] = a.reach;
		array[3] = a.damage;
		return array;
	}
}

