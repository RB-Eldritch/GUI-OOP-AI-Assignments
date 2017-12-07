﻿using UnityEngine;

public class Item {

    #region Private Vars

    private int _idNum;
    private string _name;
    private int _value;
    private string _description;
    private Texture2D _icon;
    private string _mesh;
    private ItemType _type;

    #endregion

    public void ItemConstructor(int itemID, string itemName, Texture2D itemIcon, ItemType itemType) {

        _idNum = itemID;
        _name = itemName;
        _icon = itemIcon;
        _type = itemType;
    }

    #region Public Vars

    public int ID {
        get { return _idNum; }
        set { _idNum = value; }
    }

    public string Name {
        get { return _name; }
        set { _name = value; }
    }

    public int Value {
        get { return _value; }
        set { _value = value; }
    }

    public string Description {
        get { return _description; }
        set { _description = value; }
    }

    public Texture2D Icon {
        get { return _icon; }
        set { _icon = value; }
    }

    public string Mesh {
        get { return _mesh; }
        set { _mesh = value; }
    }

    public ItemType Type {
        get { return _type; }
        set { _type = value; }
    }

    #endregion
}

public enum ItemType {

    Food,
    Weapon,
    Apparel,
    Crafting,
    Quest,
    Money,
    Ingredients,
    Potions,
    Scrolls
}
