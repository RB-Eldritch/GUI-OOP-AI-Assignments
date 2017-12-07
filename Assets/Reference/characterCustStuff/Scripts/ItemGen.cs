using UnityEngine;

public static class ItemGen {

    public static Item CreateItem(int itemID) {

        Item temp = new Item();

        string name = "";
        int value = 0;
        string description = "";
        string icon = "";
        string mesh = "";
        ItemType type = ItemType.Food;

        switch (itemID) {

            #region Food 0-99

            case 0:
                name = "Meat";
                value = 5;
                description = "Tenderised by Rocky himself";
                icon = "Meat";
                mesh = "Meat";
                type = ItemType.Food;
                break;

            case 1:
                name = "Apple";
                value = 5;
                description = "Guaranteed no worms";
                icon = "Apple";
                mesh = "Apple";
                type = ItemType.Food;
                break;

            #endregion

            #region Weapons 100-199

            case 100:
                name = "Axe";
                value = 5;
                description = "Let me axe you a question";
                icon = "Axe";
                mesh = "Axe";
                type = ItemType.Weapon;
                break;

            case 101:
                name = "Bow";
                value = 5;
                description = "Stick thrower";
                icon = "Bow";
                mesh = "Bow";
                type = ItemType.Weapon;
                break;

            case 102:
                name = "Sword";
                value = 5;
                description = "An elegant weapon, from a less civilised age";
                icon = "Sword";
                mesh = "Sword";
                type = ItemType.Weapon;
                break;

            case 103:
                name = "Shield";
                value = 5;
                description = "It can be used offensively ... sometimes";
                icon = "Shield";
                mesh = "Shield";
                type = ItemType.Weapon;
                break;

            #endregion

            #region Apparel 200-299

            case 200:
                name = "Armour";
                value = 5;
                description = "Second Skin";
                icon = "Armour";
                mesh = "Armour";
                type = ItemType.Apparel;
                break;

            case 201:
                name = "Belt";
                value = 5;
                description = "More than 2 and you're an anime character";
                icon = "Belt";
                mesh = "Belt";
                type = ItemType.Apparel;
                break;

            case 202:
                name = "Boots";
                value = 5;
                description = "Made for walking";
                icon = "Boots";
                mesh = "Boots";
                type = ItemType.Apparel;
                break;

            case 203:
                name = "Bracers";
                value = 5;
                description = "Blade not included";
                icon = "Bracers";
                mesh = "Bracers";
                type = ItemType.Apparel;
                break;

            case 204:
                name = "Cloak";
                value = 5;
                description = "Very much visible";
                icon = "Cloak";
                mesh = "Cloak";
                type = ItemType.Apparel;
                break;

            case 205:
                name = "Gloves";
                value = 5;
                description = "Hide the mark";
                icon = "Gloves";
                mesh = "Gloves";
                type = ItemType.Apparel;
                break;

            case 206:
                name = "Helmet";
                value = 5;
                description = "If you get hit in the helmet, do not take it off";
                icon = "Helmet";
                mesh = "Helmet";
                type = ItemType.Apparel;
                break;

            case 207:
                name = "Necklace";
                value = 5;
                description = "To lace your neck";
                icon = "Necklace";
                mesh = "Necklace";
                type = ItemType.Apparel;
                break;

            case 208:
                name = "Pants";
                value = 5;
                description = "Keep them on";
                icon = "Pants";
                mesh = "Pants";
                type = ItemType.Apparel;
                break;

            case 209:
                name = "Pauldrons";
                value = 5;
                description = "Shrug";
                icon = "Pauldrons";
                mesh = "Pauldrons";
                type = ItemType.Apparel;
                break;

            case 210:
                name = "Ring";
                value = 5;
                description = "There is more than One";
                icon = "Ring";
                mesh = "Ring";
                type = ItemType.Apparel;
                break;

            #endregion

            #region Crafting 300-399

            case 300:
                name = "Ingot";
                value = 5;
                description = "Unproportional";
                icon = "Ingot";
                mesh = "Ingot";
                type = ItemType.Crafting;
                break;

            case 301:
                name = "Gem";
                value = 5;
                description = "Pretty rock";
                icon = "Gem";
                mesh = "Gem";
                type = ItemType.Crafting;
                break;

            #endregion

            #region Quest 400-499

            //Quest Items

            #endregion

            #region Ingredients 500-599

            //Giant Toes and stuff

            #endregion

            #region Potions 600-699

            case 400:
                name = "Health Potion";
                value = 5;
                description = "A potion for health";
                icon = "HP";
                mesh = "HP";
                type = ItemType.Potions;
                break;

            case 401:
                name = "Mana Potion";
                value = 5;
                description = "A potion for Mana";
                icon = "MP";
                mesh = "MP";
                type = ItemType.Potions;
                break;

            #endregion

            #region Scrolls 700-799

            case 500:
                name = "Scroll";
                value = 5;
                description = "Paper with power";
                icon = "Scroll";
                mesh = "Scroll";
                type = ItemType.Scrolls;
                break;

            #endregion Coins - 800

            case 800:
                name = "Coins";
                value = 8;
                description = "Money money moneeey, MOOONEEY";
                icon = "Coins";
                mesh = "Coins";
                type = ItemType.Money;
                break;

            #region Money 



            #endregion

            default:
                name = "Apple";
                value = 5;
                description = "Munchies and Crunchies";
                icon = "Apple";
                mesh = "Apple";
                type = ItemType.Food;
                break;
        }

        temp.ID = itemID;
        temp.Name = name;
        temp.Value = value;
        temp.Description = description;
        temp.Icon = Resources.Load("Icons/" + icon) as Texture2D;
        temp.Mesh = mesh;
        temp.Type = type;

        return temp;
    }
}
