using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Job : ScriptableObject{
	public int jobID;
	public string jobName;
	public Sprite sprite;
	public string text;
	public int displayedDifficulty;
	public int hiddenDifficultyValue;
	public float time;
	public int goldReward;
}