using UnityEngine;
using System.Collections;

public class TBehaviour : MonoBehaviour {

	protected TromboneController trombone;
	protected EmbouchureController embo;
	protected Pause pause;
	
	public virtual void Awake()
	{
		trombone = (TromboneController)GameObject.FindObjectOfType( typeof(TromboneController) );
		embo = (EmbouchureController)GameObject.FindObjectOfType( typeof(EmbouchureController) );
		pause = (Pause)GameObject.FindObjectOfType( typeof(Pause) );
	}
}
