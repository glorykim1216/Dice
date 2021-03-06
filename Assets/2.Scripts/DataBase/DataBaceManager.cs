﻿using System.Collections.Generic;
using SQLite.Attribute;

public class DB
{
    [PrimaryKey] public int ID { get; set; }
    public int gold { get; set; }

    public override string ToString()
    {
        return string.Format("[DatabaseTable: ID={0}, Gold={1}]", this.ID, this.gold);
    }
}

public class DatabaseManager : MonoSingleton<DatabaseManager>
{
    public DB ItemList;  // db에 있는 아이템을 저장할 리스트

    string m_NameDB = "MyDB.db";  // db 파일 이름

    DataService ds;

    public void CreateTable()
    {
        ds = new DataService(m_NameDB);

        ds.CreateDB();
    }
    public bool Load()
    {
        ds = new DataService(m_NameDB);

        IEnumerable<DB> DBs = ds.GetDB();

        if (DBs != null)
        {
            foreach (DB DB in DBs)
                ItemList = DB;
        }
        return true;
    }

    public void UpdateItemTable(int _gold)
    {
        IEnumerable<DB> DBs = ds.GetDB();

        if (DBs != null)
        {
            foreach (DB DB in DBs)
            {
                DB.gold = _gold;

                ItemList = DB;
            }
            ds._connection.UpdateAll(DBs);
        }
    }
}
