using System;

namespace _10._The_Heigan_Dance
{
    class Program
    {
        static void Main(string[] args)
        {
            var playerDamage = double.Parse(Console.ReadLine());

            int playerRow = 7;
            int playerCol = 7;

            int playerHp = 18500;
            double heiganHp = 3000000;
            string lastSpell = "";

            while (true)
            {
                if (playerHp >=0)
                {
                    heiganHp -= playerDamage;
                }
                if (lastSpell == "Cloud")
                {
                    playerHp -= 3500;
                }
                if (heiganHp <= 0 || playerHp <= 0)
                {
                    break;
                }
                var input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                string currentSpell = input[0];
                int targetRow = int.Parse(input[1]);
                int targetCol = int.Parse(input[2]);

                if (IsInDamageArea(targetRow,targetCol, playerRow , playerCol))
                {
                    if (!IsInDamageArea(targetRow, targetCol, playerRow - 1,playerCol) && !IsWall(playerRow - 1))
                    {
                        playerRow--;
                        lastSpell = "";
                    }
                    else if (!IsInDamageArea(targetRow, targetCol, playerRow, playerCol + 1) && !IsWall(playerCol + 1))
                    {
                        playerCol++;
                        lastSpell = "";
                    }
                    else if (!IsInDamageArea(targetRow, targetCol, playerRow + 1, playerCol) && !IsWall(playerRow + 1))
                    {
                        playerRow++;
                        lastSpell = "";
                    }
                    else if (!IsInDamageArea(targetRow, targetCol, playerRow, playerCol - 1) && !IsWall(playerCol - 1))
                    {
                        playerCol--;
                        lastSpell = "";
                    }
                    else 
                    {
                        if (currentSpell == "Cloud")
                        {
                            playerHp -= 3500;
                            lastSpell = "Cloud";
                        }
                        else if (currentSpell == "Eruption")
                        {
                            playerHp -= 6000;
                            lastSpell = "Eruption";
                        }
                    }
                }
            }
            lastSpell = lastSpell == "Cloud" ? "Plague Cloud" : "Eruption";
            string heiganState = heiganHp <= 0 ? "Heigan: Defeated!" : String.Format("Heigan: {0:F2}", heiganHp);
            string playerState = playerHp <= 0 ? String.Format("Player: Killed by {0}", lastSpell) :
                  String.Format("Player: {0}", playerHp);
            string playerEndCoordinationes = String.Format("Final position: {0}, {1}", playerRow, playerCol);

            Console.WriteLine(heiganState);
            Console.WriteLine(playerState);
            Console.WriteLine(playerEndCoordinationes);

        }

        private static bool IsWall(int v)
        {
            return v < 0 || v >= 15;
        }

        private static bool IsInDamageArea(int targetRow, int targetCol, int moveRow, int moveCol)
        {
            return ((targetRow - 1 <= moveRow && moveRow <= targetRow + 1) &&
                    (targetCol - 1 <= moveCol && moveCol <= targetCol + 1));
        }
    }
}
