using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class ParcheminTuto : MonoBehaviour
{
    private bool ouvert;
    public static AudioClip notifBlinker;
    public static AudioClip parchemin;
    public AudioMixerGroup soundEffectAutres;
    void Start()
    {
        ouvert = false;
        parchemin = Resources.Load<AudioClip>("Parchemin");

        var hits = Physics.RaycastAll(transform.position + Vector3.up, Vector3.down, 10f);
        foreach (var hit in hits)
        {
            if (hit.collider.gameObject == transform.gameObject)
                continue;

            transform.position = hit.point;
            break;
        }
    }

    void OnMouseDown()
    {
        if ((GetComponent<Transform>().position - ClickToMove.playerPosition).magnitude < 9)
        {
            if (!ouvert)
            {
                GameObject player = GameObject.FindGameObjectWithTag("Player");
                player.GetComponent<ImprovedSpellInput>().newSpellBlinker.enabled = true;
                ouvert = true;
                player.GetComponent<ImprovedSpellInput>().SonNotifBlinker();
                GetComponent<AudioSource>().outputAudioMixerGroup = soundEffectAutres;
                GetComponent<AudioSource>().PlayOneShot(parchemin, 0.5f);
                gameObject.transform.GetChild(0).GetComponent<Animator>().SetBool("Read", true);
            }
        }
    }
}
 