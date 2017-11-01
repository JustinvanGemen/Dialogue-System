using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace _Scripts
{
	public class DialogueManager : MonoBehaviour {

		[SerializeField]private Text _nameText;
		[SerializeField]private Text _dialogueText;
		//TODO: Make animations to take care of the textbox visibility.
		//Een Serialized Animator 

		private Queue<string> _sentences;

		private void Start () {
			_sentences = new Queue<string>();
		}
		
		//Starts up the Dialogue by 'opening' the dialogue box and Queuing up the sentences
		public void StartDialogue (Dialogue dialogue)
		{
			//Animator Bool openDialogue naar true

			_nameText.text = dialogue.Name;

			_sentences.Clear();

			foreach (var sentence in dialogue.Sentences)
			{
				_sentences.Enqueue(sentence);
			}

			DisplayNextSentence();
		}
		
		//Simply displays the next sentence in the dialogue box.
		public void DisplayNextSentence ()
		{
			if (_sentences.Count == 0)
			{
				EndDialogue();
				return;
			}
			
			Debug.Log("Passie");
			var sentence = _sentences.Dequeue();
			StopAllCoroutines();
			StartCoroutine(TypeSentence(sentence));
		}
		
		//Makes the text appear in the dialogue box letter by letter.
		private IEnumerator TypeSentence (string sentence)
		{
			_dialogueText.text = "";
			foreach (var letter in sentence.ToCharArray())
			{
				_dialogueText.text += letter;
				yield return new WaitForSeconds(0.05f);
			}
		}
		
		//Soon2be animation for the dialogue box to leave the screen.
		private void EndDialogue()
		{
			//Animator Bool openDialogue naar false
		}

	}
}