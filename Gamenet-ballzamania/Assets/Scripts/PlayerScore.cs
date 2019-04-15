﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerScore : NetworkBehaviour {

    [SerializeField] private const int maxHealth = 5;
    [SyncVar]private int health = maxHealth;

    public void OnChangehealth(int healthDeduction)
    {
        health -= healthDeduction;
        health = Mathf.Clamp(health, 0, maxHealth);

        if (health == 0)
            StartCoroutine(DisplayLose());
    }

    IEnumerator DisplayLose()
    {
        SimpleSceneData.singleton.YouLoseText.SetActive(true);

        Time.timeScale = 0;
        yield return new WaitForSecondsRealtime(2f);

        Time.timeScale = 1;
        NetworkManager.singleton.StopClient();
    }
}
