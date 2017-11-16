using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace _Scripts
{
	public class DialogueManager : MonoBehaviour
	{
		[SerializeField]private Text _name;
		[SerializeField]private Text _dialogue;
		[SerializeField]private Animator _animator;

		private Queue<string> _sentences;

		private bool _notPaused = true;

		public bool GetPaused
		{
			get { return _notPaused; }
		}
		
		private void Start () {
			_sentences = new Queue<string>();
		}
		
		//Starts up the Dialogue by 'opening' the dialogue box and Queuing up the sentences
		public void StartDialogue (Dialogue dialogue)
		{
			_animator.SetBool("textOpen", true);
			_notPaused = false;
			_name.text = dialogue.Name;

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
			
			var sentence = _sentences.Dequeue();
			StopAllCoroutines();
			StartCoroutine(TypeSentence(sentence));
		}
		
		//Makes the text appear in the dialogue box letter by letter.
		private IEnumerator TypeSentence (string sentence)
		{
			_dialogue.text = "";
			//if (!_animator.GetCurrentAnimatorStateInfo(0).IsName("up")) yield return new WaitForSeconds(_animator.GetCurrentAnimatorStateInfo(0).length+_animator.GetCurrentAnimatorStateInfo(0).normalizedTime);
			yield return new WaitForSeconds(0.5f);
			foreach (var letter in sentence.ToCharArray())
			{
				_dialogue.text += letter;
				yield return new WaitForSeconds(0.02f);
			}
		}
		
		private void EndDialogue()
		{
			_notPaused = true;
			_animator.SetBool("textOpen", false);
		}

	}
}