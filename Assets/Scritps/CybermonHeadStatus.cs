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
        Debug.Log("");
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
            isStatusesBoxShowing = false;
        }
    }

    public void CheckIfOwnerOfaTargetedCybermonIsAPlayer()
    {
        if (targetedCybermon.isOwnerAPlayer == false)
        {
            isEXPBarBoxHidden = true;
            RemoveEXPBoxSection();
        }
    }

    public void UpdateCybermonHeadStatusImageColor()
    {
        CybermonsHeadStatusImage.color = TypesOfCybermon.TypeColor(targetedCybermon.typeOfCybermon);
    }

    void Start()
    {
        camera = GameObject.Find("Main Camera").GetComponent<Camera>();      

        isEXPBarBoxHidden = true;
        isStatusesBoxShowing = true;
        CheckAllOfStatuses();

        UpdateNameAndLevel();
        CheckIfOwnerOfaTargetedCybermonIsAPlayer();
        UpdateCybermonHeadStatusImageColor();
        
        targetedCybermon.OnTypeChange.AddListener(UpdateTypeImage);
        targetedCybermon.OnAnyStatusAdd.AddListener(CheckAllOfStatuses);
        targetedCybermon.OnAnyStatusRemove.AddListener(CheckAllOfStatuses);
        targetedCybermon.OnGainHealth.AddListener(HPBarBoxUpdate);
        targetedCybermon.OnTakeDamage.AddListener(HPBarBoxUpdate);
        
        StartCoroutine(LateStart(1));
    }

    IEnumerator LateStart(int secs)
    {
        yield return new WaitForSeconds(secs);
        targetedCybermon.OnTypeChange.AddListener(UpdateTypeImage);
        Debug.Log(gameObject.name + ": wykonano LateStart");
    }

    void Update()
    {
        PositionUpdate();
        HPBarBoxUpdate();
        UpdateCybermonHeadStatusImageColor();
    }
}
