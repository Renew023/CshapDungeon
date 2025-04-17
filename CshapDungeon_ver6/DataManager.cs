using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CshapDungeon_ver6
{
    internal class DataManager
    {
        public void SaveData(Player player)
        {
            string FilePath = "./PlayerData.json"; // 파일경로설정
            try
            {
                string json = JsonConvert.SerializeObject(player, Newtonsoft.Json.Formatting.Indented);
                File.WriteAllText(FilePath, json);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving data: {ex.Message}");
            }
        }

        public Player LoadData()
        {
            string FilePath = "../../PlayerData.json"; // 데이터 저장한 파일 경로 설정
            try
            {
                if (File.Exists(FilePath))
                {
                    string json = File.ReadAllText(FilePath);
                    return JsonConvert.DeserializeObject<Player>(json);
                }
                else
                {
                    // 파일 미 존재 시 기본 데이터 설정
                    return new Player();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error Load data: {ex.Message}");
                // JsonConver 오류 발생 시 기본 데이터 설정 
                return new Player();
            }
        }
    }
}

