/*
 *
 *	The Seven Tides
 *	by Duarte Garin, 06-2016
 *	
 *	"ActionDiaryToggle.cs"
 * 
 *	Action to toggle the Diary on and off.
 * 
 */

using UnityEngine;
using System.Collections;
using FMODUnity;
using FMOD;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace AC
{

	[System.Serializable]
	public class ActionDiaryToggle : Action
	{
		// The game object that holds the emitter
		public GameObject diary;
		public Transform journal;

		public void Awake(){

		}

		//Constructor defining the action
		public ActionDiaryToggle ()
		{
			this.isDisplayed = true;
			category = ActionCategory.Custom;
			title = "Diary: Toggle";
			description = "Toggles the diary on and off.";
		}

		//Runs the action
		override public float Run ()
		{
			diary = GameObject.Find ("DiaryCanvas");
			var alpha = diary.GetComponent<CanvasGroup> ().alpha;
			//If we have an alpha==1 it means we want to hide our Diary
			if (alpha == 1) {
				//Hiding the Diary Canvas element
				diary.GetComponent<CanvasGroup> ().alpha = 0;
				//Disabling all AC handlers so we can't interact with anything outside of the Diary
				KickStarter.stateHandler.SetInteractionSystem (true);
				KickStarter.stateHandler.SetPlayerSystem (true);
				KickStarter.stateHandler.SetMovementSystem (true);
			} else {
				//Showing the Diary Canvas element
				diary.GetComponent<CanvasGroup> ().alpha = 1;
				//Enabling back all AC handlers so we can resume interaction
				KickStarter.stateHandler.SetInteractionSystem (false);
				KickStarter.stateHandler.SetPlayerSystem (false);
				KickStarter.stateHandler.SetMovementSystem (false);
			}
			//Wraps up the action
			return 0f;
		}


		#if UNITY_EDITOR

		override public void ShowGUI ()
		{
	
		}	


		public override string SetLabel ()
		{
			// Return a string used to describe the specific action's job.
			string labelAdd = "";
			return labelAdd;
		}

		#endif

	}

}