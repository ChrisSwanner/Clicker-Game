using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goldpersec : MonoBehaviour {

    public UnityEngine.UI.Text gpsText;
    public Click click;
    public ItemManager[] items;

    private void Start()
    {
        StartCoroutine(AutoTick());
    }

    void Update()
    {
        gpsText.text = GetGPS() + " gold/sec";
    }
    public int GetGPS()
    {
        int tick = 0;
        foreach (ItemManager item in items)
        {
            tick += item.count * item.tickValue;
        }
        return tick;
    }

    public void AutoGoldPerSec()
    {
        click.gold += GetGPS();
    }

    IEnumerator AutoTick()
    {
        while(true)
        {
            AutoGoldPerSec();
            yield return new WaitForSeconds(1);
        }
    }
		
	}
