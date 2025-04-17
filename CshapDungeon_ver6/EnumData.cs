using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CshapDungeon_ver6
{
    public enum ItemType
    {
        Head = 0, //머리
        Body, //몸
        Hand, //손
        Reggings, //바지
        Shoes, //발
        Ring, //반지
        NeckRing //목걸이
    }
    public enum StatType //4주차
    {
        Hp = 0,     //체력
        Atk = 1,    //공격력
        Def = 2,    //방어력

    }

    public enum PlaceType //VillageSection
    {
        Village, //마을 
        Inventory, //인벤토리
        Shop, //상점
        Status, //능력치 확인
        Dungeon, //던전입장
        Rest //휴식하기
    }

    //장착개선에 쓰일 코드

    public enum DungeonStage
    {
        Easy = 1,
        Normal,
        Hard
    }
}
