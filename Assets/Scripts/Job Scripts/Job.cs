using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Job : ScriptableObject{
	public int jobID;
	public string jobName;
	public Sprite sprite;
	public string text;
	public int jobIDUnlocks;
	public int attack;
	public int defense;
	public int time;
}