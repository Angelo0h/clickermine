using UnityEngine;
public class UIManager : MonoBehaviour
{

    public void ClickStats()
    {
        Input.GetMouseButtonDown(0);
        MapValueToPlayer();
    }

    void MapValueToPlayer()
    {
        Player player = GameObject.FindObjectOfType<Player>();
        Click click = GameObject.FindObjectOfType<Click>();
        ItemManager[] itemManagers = GameObject.FindObjectsOfType<ItemManager>();
        UpgradeManager[] upgradeManagers = GameObject.FindObjectsOfType<UpgradeManager>();
        GoldPerSec goldPerSec = GameObject.FindObjectOfType<GoldPerSec>();
        Shop shop = GameObject.FindObjectOfType<Shop>();

        player.myStats.gold = float.Parse(click.gold.ToString());
        player.myStats.money = float.Parse(click.money.ToString());
        player.myStats.goldperClick = int.Parse(click.goldperClick.ToString());
        player.myStats.goldPerSec = int.Parse(goldPerSec.GetGoldPerSec().ToString());

        var i = 0;
        foreach(UpgradeManager el in upgradeManagers) 
        {
            player.myStats.state[i] = new Block("UpgradeManager",el.name, el.cost, el.count);
            //Debug.Log($"#{i}, #{el.name}, #{el.cost}, ${el.count}");
            i++;
        }
        foreach(ItemManager el in itemManagers) 
        {
            player.myStats.state[i] = new Block("ItemManager",el.name, el.cost, el.count);
            //Debug.Log($"#{i}, #{el.name}, #{el.cost}, ${el.count}");
            i++;
        }
    }
}
