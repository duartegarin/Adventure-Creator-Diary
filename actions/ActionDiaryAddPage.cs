/*
 *
 *	The Seven Tides
 *	by Duarte Garin, 06-2016
 *	
 *	"ActionDiaryAddPage.cs"
 * 
 *	Action to add a new page to the diary.
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
	public class ActionDiaryAddPage : Action
	{
		public Sprite page;
		// The game object that holds the emitter
		public GameObject diary;
		public Transform journal;

		public void Awake(){

		}

		//Constructor defining the action
		public ActionDiaryAddPage ()
		{
			this.isDisplayed = true;
			category = ActionCategory.Custom;
			title = "Diary: Add Page";
			description = "Adds a new page to this journal.";
		}

		//Runs the action
		override public float Run ()
		{
			diary = GameObject.Find ("DiaryCanvas");
			journal = diary.transform.Find ("Diary");
			Diary book = journal.GetComponent<Diary>();
			book.addPage (page);
			//Wraps up the action
			return 0f;
		}


		#if UNITY_EDITOR

		override public void ShowGUI ()
		{
			//Widget to select the name of the parameter
			page = (Sprite) EditorGUILayout.ObjectField ("Texture file:", page, typeof (Sprite),true);
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