using UnityEngine;

namespace _Scripts
{
	public class DialogueStarter : MonoBehaviour {

		[SerializeField]private Dialogue _dialogue;

		public void StartDialogue ()
		{
			FindObjectOfType<DialogueManager>().StartDialogue(_dialogue);
		}

	}
}