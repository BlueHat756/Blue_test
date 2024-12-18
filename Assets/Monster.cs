using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Monster : MonoBehaviour
{
    //몬스터 기본 정보
    public string MonName;
    public float MonMaxHp;
    public float MonAtkPower;
    public int revive;

    public Image HpImage;
    public Monster target;
    public TextMeshProUGUI hpText;
    public TextMeshProUGUI reviveCount;

    public float MonCurHp;
    public float cooltime;
    public string die;




    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<TextMeshProUGUI>().text = MonName;
        MonCurHp = MonMaxHp;
        hpText.text = MonCurHp + " / " + MonMaxHp;
        reviveCount.text = revive.ToString() ;
    }

    float cTime;

    // Update is called once per frame
    void Update()
    {
        if(MonCurHp > 0)
        {

            if (cTime >= cooltime)
            {
                target.OnDamage(MonAtkPower);
                cTime = 0;
            }
            else
            {
                cTime += Time.deltaTime;
            }
        }
    }

    public void OnDamage(float _MonAtkPower)
    {
        MonCurHp -= _MonAtkPower;
        if (MonCurHp <= 0)
        {
            if(revive > 0)
            {
                MonCurHp = MonMaxHp * 0.5f;
                revive--;
                hpText.text = MonCurHp + " / " + MonMaxHp;
                reviveCount.text = revive.ToString();
            }
            else
            {
                hpText.text = die;
            }
        }
        else
        {
            hpText.text = MonCurHp + " / " + MonMaxHp;
            reviveCount.text = revive.ToString();
        }
        float fill = MonCurHp / MonMaxHp;
        HpImage.fillAmount = fill;
    }

}
