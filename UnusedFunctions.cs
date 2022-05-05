using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//MOTHALLED CODE
public class UnusedFunctions : MonoBehaviour
{
    // Start is called before the first frame update
	public void presspause()
	{
		if(Input.anyKey)
		{ 	
			
			Time.timeScale = 1;
			Debug.Log("UNPAUSED");
		}
		else
		{
			Time.timeScale = 0; 
			Debug.Log("PAUSED");
		}
	
	}
	public void TimeScaleNum(float num)
	{
		Time.timeScale = num; 
	}
	public void TimeScaleOne()
	{
		Time.timeScale = 1; 
	}
	public void TimeScaleHalf()
	{
		Time.timeScale = 0.5f; 
	}
	
	public void TimeScaleZero()
	{
		Time.timeScale = 0; 
	}
	//All Coroutines I'm trying to get to work. 
	IEnumerator JUSTWAITLOCAL(float num)
	{
		Time.timeScale = 1; 
		Debug.Log(Time.timeScale);
		Debug.Log("JustWaitUsed");
		yield return new WaitForSeconds(num);
		
	}
	//This tests to see if the coroutines are working.
	IEnumerator TestExample() 
	{
		print(Time.time);
		print(Time.timeScale);
		yield return new WaitForSeconds(5);
		print(Time.time);
	}
	
	IEnumerator WaitTheseSeconds(float num)
	{
		// Pause the game
		Time.timeScale = 0f;
		yield return new WaitForSecondsRealtime(num);
		print("You can't stop me");
	}
	
	IEnumerator WaitFiveSeconds()
	{
		// Pause the game
		Time.timeScale = 0;
		yield return new WaitForSecondsRealtime(5);
		print("You can't stop me");
	}
	
	public IEnumerator WaitForAnswer()
	{
		for (;;)
		{
			if (Input.anyKey)
			{
				break;
			} 
			yield return null;
		}

		yield return null;
	}
	
}
