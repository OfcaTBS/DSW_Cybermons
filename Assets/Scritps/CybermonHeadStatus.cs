using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CMType;

public class CybermonHeadStatus : MonoBehaviour
{
    // Start is called before the first frame update
    public Camera camera;
    public Cybermon targetedCybermon;
    public Text cbNameLevelText;
    public Image typeImage;
    public GameObject HPBarBox;
    public Image HPBarImage;
    public Text HPBarPointsText;
    public Gradient HPBarColorGradient;
    public GameObject EXPBarBox;
    public GameObject StatusesBox;
    public GameObject BurnStatus;
    public GameObject SleepStatus;
    public GameObject ParalyzedStatus;
    public GameObject PoisonedStatus;
    public GameObject FrozenStatus;
    public bool isEXPBarBoxHidden;
    public bool isStatusesBoxShowing;
    public Image CybermonsHeadStatusImage;

    public void HPBarBoxUpdate()
    {
        HPBarImage.fillAmount = (0f + targetedCybermon.currentHealth) / (0f + targetedCybermon.maxHealth);
        HPBarImage.color = HPBarColorGradient.Evaluate((0f + targetedCybermon.currentHealth) / (0f + targetedCybermon.maxHealth));
        HPBarPointsText.text = targetedCybermon.currentHealth.ToString() + "/" + targetedCybermon.maxHealth.ToString();
    }

    public void PositionUpdate()
    {
        transform.position = camera.WorldToScreenPoint(targetedCybermon.headPosition.transform.position + new Vector3(0,0.3F,0));
    }

    public void UpdateNameAndLevel()
    {
        cbNameLevelText.text = targetedCybermon.cmName + " Lvl. " + targetedCybermon.level;
    }

    public void AddStatusesBoxSection()
    {
        CybermonsHeadStatusImage.rectTransform.sizeDelta = new Vector2(CybermonsHeadStatusImage.rectTransform.rect.width, CybermonsHeadStatusImage.rectTransform.rect.height + StatusesBox.GetComponent<Image>().rectTransform.rect.height + 10);
    }

    public void RemoveStatusesBoxSection()
    {
        CybermonsHeadStatusImage.rectTransform.sizeDelta = new Vector2(CybermonsHeadStatusImage.rectTransform.rect.width, CybermonsHeadStatusImage.rectTransform.rect.height - (StatusesBox.GetComponent<Image>().rectTransform.rect.height + 10));
    }

    public void RemoveEXPBoxSection()
    {
        CybermonsHeadStatusImage.rectTransform.sizeDelta = new Vector2(CybermonsHeadStatusImage.rectTransform.rect.width, CybermonsHeadStatusImage.rectTransform.rect.height - (EXPBarBox.GetComponent<Image>().rectTransform.rect.height + 10));
        EXPBarBox.SetActive(false);
    }

    public void AddEXPBoxSection()
    {
        CybermonsHeadStatusImage.rectTransform.sizeDelta = new Vector2(CybermonsHeadStatusImage.rectTransform.rect.width, CybermonsHeadStatusImage.rectTransform.rect.height + EXPBarBox.GetComponent<Image>().rectTransform.rect.height + 10);
        EXPBarBox.SetActive(true);
    }


    public void UpdateTypeImage()
    {
        Debug.Log("kurwa");
        /*switch (targetedCybermon.typeOfCybermon)
        {
            case TypeOfCybermon.Dark:
                typeImage.color = new Color(46, 43, 43);
                break;
            case TypeOfCybermon.Death:
                typeImage.color = new Color(0, 0, 0);
                break;
            case TypeOfCybermon.Fire:
                typeImage.color = new Color(217, 67, 2);
                break;
            case TypeOfCybermon.Grass:
                typeImage.color = new Color(0, 191, 45);
                break;
            case TypeOfCybermon.Ground:
                typeImage.color = new Color(97, 44, 0);
                break;
            case TypeOfCybermon.Ice:
                typeImage.color = new Color(90, 239, 255);
                break;
            case TypeOfCybermon.Life:
                typeImage.color = new Color(255, 248, 117);
                break;
            case TypeOfCybermon.Normal:
                typeImage.color = new Color(230, 230, 230);
                break;
            case TypeOfCybermon.Poison:
                typeImage.color = new Color(98, 0, 217);
                break;
            case TypeOfCybermon.Tech:
                typeImage.color = new Color(0, 43, 4);
                break;
            case TypeOfCybermon.Water:
                typeImage.color = new Color(0, 132, 255);
                break;
        }*/

    }
    
    public void CheckAllOfStatuses()
    {
        if (targetedCybermon.isBurned)
        {
            BurnStatus.SetActive(true);
        }
        else
        {
            BurnStatus.SetActive(false);
        }

        if (targetedCybermon.isSleeping)
        {
            SleepStatus.SetActive(true);
        }
        else
        {
            SleepStatus.SetActive(false);
        }

        if (targetedCybermon.isParalyzed)
        {
            ParalyzedStatus.SetActive(true);
        }
        else
        {
            ParalyzedStatus.SetActive(false);
        }

        if (targetedCybermon.isPoisoned)
        {
            PoisonedStatus.SetActive(true);
        }
        else
        {
            PoisonedStatus.SetActive(false);
        }

        if (targetedCybermon.isFrozen)
        {
            FrozenStatus.SetActive(true);
        }
        else
        {
            FrozenStatus.SetActive(false);
        }

        if (targetedCybermon.HasAnyStatuses() && !isStatusesBoxShowing)
        {
            AddStatusesBoxSection();
            isStatusesBoxShowing = true;
        }
        else if (!targetedCybermon.HasAnyStatuses() && isStatusesBoxShowing)
        {
            RemoveStatusesBoxSection();
            isStatusesBoxShowing = true;
        }
    }

    public void CheckIfOwnerOfaTargetedCybermonIsAPlayer()
    {
        if (targetedCybermon.isOwnerAPlayer == false)
        {
            RemoveEXPBoxSection();
        }
    }

    public void UpdateCybermonHeadStatusImageColor()
    {
        CybermonsHeadStatusImage.color = TypesOfCybermon.TypeColor(targetedCybermon.typeOfCybermon);
        Debug.Log(targetedCybermon.typeOfCybermon);
    }

    void Start()
    {
        //targetedCybermon = GameObject.Find("Cube").GetComponent<Cybermon>();
        camera = GameObject.Find("Main Camera").GetComponent<Camera>();
        //cbNameLevelText = GameObject.Find("CBNameLevelText").GetComponent<Text>();
        //typeImage = GameObject.Find("TypeImage").GetComponent<Image>();
        
        
        

        isEXPBarBoxHidden = false;
        isStatusesBoxShowing = true;
        
        UpdateNameAndLevel();
        CheckAllOfStatuses();
        CheckIfOwnerOfaTargetedCybermonIsAPlayer();
        UpdateCybermonHeadStatusImageColor();
        

        targetedCybermon.OnTypeChange.AddListener(UpdateTypeImage);
        targetedCybermon.OnStatusAdd.AddListener(CheckAllOfStatuses);
        
        StartCoroutine(LateStart(1));
    }

    IEnumerator LateStart(int secs)
    {
        yield return new WaitForSeconds(secs);
        targetedCybermon.OnTypeChange.AddListener(UpdateTypeImage);
        Debug.Log(gameObject.name + ": wykonano LateStart");
    }

    private void Awake()
    {
        //targetedCybermon.OnTypeChange.AddListener(UpdateTypeImage);
    }


    // Update is called once per frame
    void Update()
    {
        PositionUpdate();
        HPBarBoxUpdate();
        //CheckAllOfStatuses();
        UpdateCybermonHeadStatusImageColor();
    }
}
