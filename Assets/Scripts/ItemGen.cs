using UnityEngine;

public static class ItemGen
{
    public static Item CreateItem(int itemID)
    {
        Item temp = new Item();
        #region Variables 
        string name = "";
        int value = 0;
        string description = "";
        string icon = "";
        string mesh = "";
        ItemType type = ItemType.Food;
        #endregion
        #region Switch Item Data
        switch(itemID)
        {
            #region Food 0-99
            case 0:
                name = "Apple";
                value = 5;
                description = "Munchies and Crunchies";
                icon = "Apple";
                mesh = "Apple";
                type = ItemType.Food;
                break;
            case 1:
                name = "Meat";
                value = 7;
                description = "Meaty Goodness";
                icon = "Meat";
                mesh = "Meat";
                type = ItemType.Food;
                break;
            #endregion
            #region Weapon 100-199
            case 100:
                name = "Rifle";
                value = 15;
                description = "";
                icon = "Rifle";
                mesh = "Rifle";
                type = ItemType.Weapon;
                break;
            case 101:
                name = "Shotty";
                value = 25;
                description = "";
                icon = "Shotty";
                mesh = "Shotty";
                type = ItemType.Weapon;
                break;
            case 102:
                name = "Pistol";
                value = 50;
                description = "";
                icon = "Pistol";
                mesh = "Pistol";
                type = ItemType.Weapon;
                break;
            case 103:
                name = "SledgeHammer";
                value = 10;
                description = "";
                icon = "Hammer";
                mesh = "Hammer";
                type = ItemType.Weapon;
                break;
            #endregion
            #region Apparel 200-299
            case 200:
                name = "Armour";
                value = 75;
                description = "";
                icon = "Armour";
                mesh = "Armour";
                type = ItemType.Apparel;
                break;
            case 201:
                name = "Shirt";
                value = 3;
                description = "";
                icon = "Shirt";
                mesh = "Shirt";
                type = ItemType.Apparel;
                break;
            case 202:
                name = "Boots";
                value = 5;
                description = "";
                icon = "Boots";
                mesh = "Boots";
                type = ItemType.Apparel;
                break;
            case 203:
                name = "Bracers";
                value = 10;
                description = "";
                icon = "Bracers";
                mesh = "Bracers";
                type = ItemType.Apparel;
                break;
            case 204:
                name = "Cloak";
                value = 6;
                description = "";
                icon = "Cloak";
                mesh = "Cloak";
                type = ItemType.Apparel;
                break;
            case 205:
                name = "Gloves";
                value = 15;
                description = "";
                icon = "Gloves";
                mesh = "Gloves";
                type = ItemType.Apparel;
                break;
            case 206:
                name = "Hats";
                value = 25;
                description = "";
                icon = "Hats";
                mesh = "Hats";
                type = ItemType.Apparel;
                break;
            case 207:
                name = "Necklace";
                value = 100;
                description = "";
                icon = "Necklace";
                mesh = "Necklace";
                type = ItemType.Apparel;
                break;
            case 208:
                name = "Pants";
                value = 5;
                description = "";
                icon = "Pants";
                mesh = "Pants";
                type = ItemType.Apparel;
                break;
            case 209:
                name = "Ring";
                value = 5;
                description = "";
                icon = "Ring";
                mesh = "Ring";
                type = ItemType.Apparel;
                break;
            case 210:
                name = "Shoulders";
                value = 5;
                description = "";
                icon = "Shoulders";
                mesh = "Shoulders";
                type = ItemType.Apparel;
                break;
            #endregion
            #region Crafting 300-399
            case 300:
                name = "Ingots";
                value = 50;
                description = "";
                icon = "Ingots";
                mesh = "Ingots";
                type = ItemType.Crafting;
                break;
            case 301:
                name = "Gem";
                value = 60;
                description = "";
                icon = "Gem";
                mesh = "Gem";
                type = ItemType.Crafting;
                break;
            #endregion
            #region Quest 400-499
            #endregion
            #region Money 500-599
            case 500:
                name = "Coins";
                value = 1;
                description = "";
                icon = "Coins";
                mesh = "Coins";
                type = ItemType.Money;
                break;
            #endregion
            #region Ingredients 600-699
            #endregion
            #region Potions 700-799
            case 700:
                name = "HP";
                value = 100;
                description = "";
                icon = "HP";
                mesh = "HP";
                type = ItemType.Potions;
                break;
            case 701:
                name = "SP";
                value = 100;
                description = "";
                icon = "SP";
                mesh = "SP";
                type = ItemType.Potions;
                break;
            #endregion
            #region Scrolls 800-899
            case 800:
                name = "Scroll";
                value = 75;
                description = "";
                icon = "Scroll";
                mesh = "Scroll";
                type = ItemType.Scrolls;
                break;
            #endregion
            default:
                itemID = 0;
                name = "Apple";
                value = 5;
                description = "Munchies and Crunchies";
                icon = "Apple";
                mesh = "Apple";
                type = ItemType.Food;
                break;
        }
        #endregion
        #region Temp Connect
        temp.ID = itemID;
        temp.Name = name;
        temp.Value = value;
        temp.Description = description;
        temp.Icon = Resources.Load("Icons/" + icon) as Texture2D;
        temp.Mesh = mesh;
        temp.Type = type;
        #endregion
        return temp;
    }
}
