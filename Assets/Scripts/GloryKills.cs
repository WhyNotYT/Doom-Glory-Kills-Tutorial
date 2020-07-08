/* Copyright (c) Yumish R. Niroula 
	2017 
*/
using UnityEngine;
public class GloryKills : MonoBehaviour {
	public float GloryKillDistance;
	public float GloryKilllAngle;
	public Camera mainCam;
	public Animator anim;
	private Demon[] demons;

	private void Update()
	{
		if(Input.GetMouseButtonDown(0))
		{
			demons = FindObjectsOfType<Demon>();
			for (int i = 0; i < demons.Length; i++)
			{
				//Debug.Log((demons[i].transform.position - mainCam.transform.position).sqrMagnitude);
				if ((demons[i].transform.position - mainCam.transform.position).sqrMagnitude < GloryKillDistance)
				{
					//Debug.Log(Vector3.Angle((demons[i].transform.position - mainCam.transform.position), mainCam.transform.forward));
					if (Vector3.Angle((demons[i].transform.position - mainCam.transform.position), mainCam.transform.forward) < GloryKilllAngle)
					{
						if(demons[i].type == DemonType.Imp)
						{
							anim.Play("Imp_GloryKill_Front");
							Destroy(demons[i].gameObject);
							return;
						}
						else if(demons[i].type == DemonType.Caco)
						{
							if(Vector3.Angle((mainCam.transform.position - demons[i].transform.position), demons[i].transform.forward) < 100)
							{
								anim.Play("Blob_GloryKill_Front");
							}
							else
							{
								anim.Play("Blob_GloryKill_Back");
							}
							Destroy(demons[i].gameObject);
							return;
						}
					}
				}
			}
		}
	}

}
