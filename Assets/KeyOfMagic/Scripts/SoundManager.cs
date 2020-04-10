using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip enemyA,bouclier,sortCourt,coffre, sortLong, GameOver,hitP;
    public static new AudioSource audio;

    // Start is called before the first frame update
    void Start()
    {
        enemyA = Resources.Load<AudioClip>("Woosh");
        hitP = Resources.Load<AudioClip>("HitP");
        bouclier = Resources.Load<AudioClip>("Def");
        sortCourt = Resources.Load<AudioClip>("SortCourt");
        sortLong= Resources.Load<AudioClip>("SortLong");
        coffre = Resources.Load<AudioClip>("Coffre");
        GameOver = Resources.Load<AudioClip>("GameOver");
        audio = GetComponent<AudioSource>();    
    }

    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "hitP":
                audio.PlayOneShot(hitP);
                break;
            case "GameOver":
                audio.PlayOneShot(GameOver);
                break;
            case "Coffre":
                audio.PlayOneShot(coffre);
                break;
            case "enemyA":
                audio.PlayOneShot(enemyA);
                break;
                //SORTS
            case "awali":
                audio.PlayOneShot(sortCourt);
                break;
            case "AWALI":
                audio.PlayOneShot(bouclier);
                break;
            case "aloni":
                audio.PlayOneShot(sortCourt);
                break;
            case "ALONI":
                audio.PlayOneShot(bouclier);
                break;
            case "atosophila":
                audio.PlayOneShot(sortLong);
                break;
            case "ATOSOPHILA":
                audio.PlayOneShot(bouclier);
                break;
            case "aliquamira":
                audio.PlayOneShot(sortLong);
                break;
            case "ALIQUAMIRA":
                audio.PlayOneShot(bouclier);
                break;
            case "urbex":
                audio.PlayOneShot(sortCourt);
                break;
            case "URBEX":
                audio.PlayOneShot(bouclier);
                break;
            case "ustus":
                audio.PlayOneShot(sortCourt);
                break;
            case "USTUS":
                audio.PlayOneShot(bouclier);
                break;
            case "unifulopa":
                audio.PlayOneShot(sortLong);
                break;
            case "UNIFULOPA":
                audio.PlayOneShot(bouclier);
                break;
            case "ugnimaril":
                audio.PlayOneShot(sortLong);
                break;
            case "UGNIMARIL":
                audio.PlayOneShot(bouclier);
                break;
            case "estek":
                audio.PlayOneShot(sortCourt);
                break;
            case "ESTEK":
                audio.PlayOneShot(bouclier);
                break;
            case "eario":
                audio.PlayOneShot(sortCourt);
                break;
            case "EARIO":
                audio.PlayOneShot(bouclier);
                break;
            case "eminitasi":
                audio.PlayOneShot(sortLong);
                break;
            case "EMINITASI":
                audio.PlayOneShot(bouclier);
                break;
            case "eterialam":
                audio.PlayOneShot(sortLong);
                break;
            case "ETERIALAM":
                audio.PlayOneShot(bouclier);
                break;
            case "otera":
                audio.PlayOneShot(sortCourt);
                break;
            case "OTERA":
                audio.PlayOneShot(bouclier);
                break;
            case "oreca":
                audio.PlayOneShot(sortCourt);
                break;
            case "ORECA":
                audio.PlayOneShot(bouclier);
                break;
            case "opinalica":
                audio.PlayOneShot(sortLong);
                break;
            case "OPINALICA":
                audio.PlayOneShot(bouclier);
                break;
            case "omistera":
                audio.PlayOneShot(sortLong);
                break;
            case "OMISTERIA":
                audio.PlayOneShot(bouclier);
                break;
            case "inuji":
                audio.PlayOneShot(sortCourt);
                break;
            case "INUJI":
                audio.PlayOneShot(bouclier);
                break;
            case "iobre":
                audio.PlayOneShot(sortCourt);
                break;
            case "IOBRE":
                audio.PlayOneShot(bouclier);
                break;
            case "istaliplo":
                audio.PlayOneShot(sortLong);
                break;
            case "ISTALIPLO":
                audio.PlayOneShot(bouclier);
                break;
            case "ilectrame":
                audio.PlayOneShot(sortLong);
                break;
            case "ILECTRAME":
                audio.PlayOneShot(bouclier);
                break;
        }
    }
}
