using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CMType;

public class CybermonHeadStatus : MonoBehaviour
{
    [SerializeField] private Text cybermonNameLevelText;
    [SerializeField] private Image hpBarImage;
    [SerializeField] private Image hpBarMaskImage;
    [SerializeField] private Text hpBarPointsText;
    [SerializeField] private Gradient hpBarColorGradient;
    [SerializeField] private GameObject statusesBoxGameObject;
    [SerializeField] private GameObject burnStatusGameObject;
    [SerializeField] private GameObject sleepStatusGameObject;
    [SerializeField] private GameObject paralyzedStatusGameObject;
    [SerializeField] private GameObject poisonedStatusGameObject;
    [SerializeField] private GameObject frozenStatusGameObject;
    [SerializeField] private Image cybermonsHeadStatusImage;

    [SerializeField] private string cybermonName;
    [SerializeField] private int cybermonLevel;
    [SerializeField] private int cybermonMaxHP;
    [SerializeField] private int cybermonCurrentHP;
    [SerializeField] private bool burnStatus;
    [SerializeField] private bool sleepStatus;
    [SerializeField] private bool paralyzedStatus;
    [SerializeField] private bool poisonedStatus;
    [SerializeField] private bool frozenStatus;
    [SerializeField] private TypeOfCybermon cybermonType;
    [SerializeField] private Vector3 headPosition;
    [SerializeField] private string cybermonID;

    public void SetCybermonHeadStatusVariables(string _cybermonName, int _cybermonLevel, int _cybermonMaxHP, int _cybermonCurrentHP, bool _burnStatus, bool _sleepStatus, bool _paralyzedStatus, bool _poisonedStatus, bool _frozenStatus, TypeOfCybermon _cybermonType, Vector3 _headPosition, string _cybermonID)
    {
        cybermonName = _cybermonName;
        cybermonLevel = _cybermonLevel;
        cybermonMaxHP = _cybermonMaxHP;
        cybermonCurrentHP = _cybermonCurrentHP;
        burnStatus = _burnStatus;
        sleepStatus = _sleepStatus;
        paralyzedStatus = _paralyzedStatus;
        poisonedStatus = _poisonedStatus;
        frozenStatus = _frozenStatus;
        cybermonType = _cybermonType;
        headPosition = _headPosition;
        cybermonID = _cybermonID;
    }

    public string GetCybermonID()
    {
        return cybermonID;
    }

    public static GameObject CreateCybermonHeadStatus(Cybermon _targetedCybermon, Transform _parent)
    {
        var cybermonHeadStatus = Instantiate(Resources.Load("Prefabs/UI/CybermonHeadStatus") as GameObject, _parent);
        cybermonHeadStatus.GetComponent<CybermonHeadStatus>().SetCybermonHeadStatusVariables(_targetedCybermon.cybermonStatsAndVariables.GetCybermonName(), _targetedCybermon.cybermonStatsAndVariables.GetLevel(), _targetedCybermon.cybermonStatsAndVariables.GetMaxHealth(), _targetedCybermon.cybermonStatsAndVariables.GetCurrentHealth(), _targetedCybermon.cybermonStatsAndVariables.IsBurned(), _targetedCybermon.cybermonStatsAndVariables.IsSleeping(), _targetedCybermon.cybermonStatsAndVariables.IsParalyzed(), _targetedCybermon.cybermonStatsAndVariables.IsPoisoned(), _targetedCybermon.cybermonStatsAndVariables.IsFrozen(), _targetedCybermon.cybermonStatsAndVariables.GetTypeOfCybermon(), _targetedCybermon.cybermonStatsAndVariables.GetHeadPosition(), _targetedCybermon.cybermonStatsAndVariables.GetCybermonID());
        return cybermonHeadStatus;
    }

    public void CurrentHPUpdate(Cybermon _cybermon)
    {
        cybermonCurrentHP = _cybermon.cybermonStatsAndVariables.GetCurrentHealth();
        HPBarBoxUpdate();
    }

    public void MaxHPUpdate(Cybermon _cybermon)
    {
        cybermonMaxHP = _cybermon.cybermonStatsAndVariables.GetMaxHealth();
        HPBarBoxUpdate();
    }

    private void HPBarBoxUpdate()
    {
        hpBarMaskImage.fillAmount = (0f + cybermonCurrentHP) / (0f + cybermonMaxHP);
        hpBarImage.color = hpBarColorGradient.Evaluate((0f + cybermonCurrentHP) / (0f + cybermonMaxHP));
        hpBarPointsText.text = cybermonCurrentHP + "/" + cybermonMaxHP;
    }

    public void HeadPositionUpdate(Cybermon _cybermon)
    {
        headPosition = _cybermon.cybermonStatsAndVariables.GetHeadPosition();
        PositionUpdate();
    }

    private void PositionUpdate()
    {
        transform.position = Camera.main.WorldToScreenPoint(headPosition + new Vector3(0, 0.3F, 0));
    }

    public void TypeUpdate(Cybermon _cybermon)
    {
        cybermonType = _cybermon.cybermonStatsAndVariables.GetTypeOfCybermon();
        CybermonHeadStatusImageColorUpdate();
    }

    public void SetCybermonNameAndLevel(Cybermon _cybermon)
    {
        cybermonName = _cybermon.cybermonStatsAndVariables.GetCybermonName();
        cybermonLevel = _cybermon.cybermonStatsAndVariables.GetLevel();
        NameAndLevelUpdate();
    }

    public void NameUpdate(Cybermon _cybermon)
    {
        cybermonName = _cybermon.cybermonStatsAndVariables.GetCybermonName();
        NameAndLevelUpdate();
    }

    public void LevelUpdate(Cybermon _cybermon)
    {
        cybermonLevel = _cybermon.cybermonStatsAndVariables.GetLevel();
        NameAndLevelUpdate();
    }
    private void NameAndLevelUpdate()
    {
        cybermonNameLevelText.text = cybermonName + " Lvl. " + cybermonLevel;
    }

    private void CybermonHeadStatusImageColorUpdate()
    {
        cybermonsHeadStatusImage.color = TypesOfCybermon.GetColorByType(cybermonType);
    }

    public void BurnStatusUpdate(Cybermon _cybermon)
    {
        burnStatus = _cybermon.cybermonStatsAndVariables.IsBurned();
        UpdateAllStatusesGameObjects();
    }

    public void SleepStatusUpdate(Cybermon _cybermon)
    {
        sleepStatus = _cybermon.cybermonStatsAndVariables.IsSleeping();
        UpdateAllStatusesGameObjects();
    }

    public void ParalyzedStatusUpdate(Cybermon _cybermon)
    {
        paralyzedStatus = _cybermon.cybermonStatsAndVariables.IsParalyzed();
        UpdateAllStatusesGameObjects();
    }

    public void PoisonedStatusUpdate(Cybermon _cybermon)
    {
        poisonedStatus = _cybermon.cybermonStatsAndVariables.IsPoisoned();
        UpdateAllStatusesGameObjects();
    }

    public void FrozenStatusUpdate(Cybermon _cybermon)
    {
        frozenStatus = _cybermon.cybermonStatsAndVariables.IsFrozen();
        UpdateAllStatusesGameObjects();
    }

    public void UpdateAllStatusesGameObjects()
    {
        burnStatusGameObject.SetActive(burnStatus);
        sleepStatusGameObject.SetActive(sleepStatus);
        paralyzedStatusGameObject.SetActive(paralyzedStatus);
        poisonedStatusGameObject.SetActive(poisonedStatus);
        frozenStatusGameObject.SetActive(frozenStatus);

        if (burnStatus || sleepStatus || paralyzedStatus || poisonedStatus || frozenStatus)
        {
            statusesBoxGameObject.SetActive(true);
        }
        else
        {
            statusesBoxGameObject.SetActive(false);
        }
    }

    void Start()
    {
        NameAndLevelUpdate();
        HPBarBoxUpdate();
        UpdateAllStatusesGameObjects();
        CybermonHeadStatusImageColorUpdate();
    }
}
