using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System;

public class SaveManager : MonoBehaviour
{

    private Player _player;

    Shop shop;

    public void Awake()
    {
        _player = GameObject.FindObjectOfType<Player>();
        Load();
    }

    public void Save()
    {

        FileStream file = new FileStream(Application.persistentDataPath + "/Player.aaf", FileMode.OpenOrCreate);

        try
        {
            Shop shop = GameObject.FindObjectOfType<Shop>();
            BinaryFormatter formatter = new BinaryFormatter();

            formatter.Serialize(file, _player.myStats);

            Debug.Log("Foi!!!!!!!!!!!!");
        }
        catch (SerializationException e)
        {
            Debug.LogError("Erro:" + e.Message);
        }
        finally
        {
            file.Close();
        }
    }

    public void Load()
    {
        FileStream file = new FileStream(Application.persistentDataPath + "/Player.aaf", FileMode.Open);
        try
        {
            BinaryFormatter formatter = new BinaryFormatter();
            _player.myStats = (Stats)formatter.Deserialize(file);
            Debug.Log($"Carregou {_player.myStats.state.Length}");
            this.MapToUI(_player.myStats);
        }
        catch (SerializationException e)
        {
            Debug.LogError("Erro D:" + e.Message);
        }
        finally
        {
            file.Close();
        }
    }

    public void MapToUI(Stats stats)
    {
        Click click = GameObject.FindObjectOfType<Click>();
        GoldPerSec goldPerSec = GameObject.FindObjectOfType<GoldPerSec>();

        foreach (var item in stats.state)
        {
            click.gold = stats.gold;
            click.money = stats.money;
            click.goldperClick = stats.goldperClick;
            
            switch (item.type)
            {
                case "ItemManager":
                    this.mapItemManager(item); 
                break;
                case "UpgradeManager":
                    this.mapUpgradeManager(item); 
                break;
            }
        }
    }

    private void mapUpgradeManager(Block item)
    {
        UpgradeManager[] upgradeManagers = GameObject.FindObjectsOfType<UpgradeManager>();
        foreach (var obj in upgradeManagers)
        {
            if(obj.name == item.id){
                obj.cost = item.cost;
                obj.count = item.count;
            }
        }
    }

    private void mapItemManager(Block item)
    {
        ItemManager[] itemManagers = GameObject.FindObjectsOfType<ItemManager>();
        foreach (var obj in itemManagers)
        {
            if(obj.name == item.id){
                obj.cost = item.cost;
                obj.count = item.count;
            }
        }
    }
}
