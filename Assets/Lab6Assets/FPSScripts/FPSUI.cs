using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class FPSUI : MonoBehaviour {
    [SerializeField] private Image healthBar;
    [SerializeField] private TMP_Text enemyDefeatText;
    public void ShowHealthFraction(float fraction) {
        healthBar.fillAmount = fraction;
    }

    public void ShowEnemyDefeatCount(int count) {
        enemyDefeatText.text = "Enemies Slain: " + count;
    }
}