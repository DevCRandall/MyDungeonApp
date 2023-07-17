using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public static class Common
    {
        public static string convertToPascal(string s)
        {
            // Only works on single words
            s = s.ToLower();
            char[] sChars = s.ToCharArray();
            sChars[0] = sChars[0].ToString().ToUpper()[0];
            string result = string.Empty;
            foreach (var c in sChars)
            {
                result += c;
            }
            return result;
        }

        public static void changeWeapon(Player player, string question)
        {
            Console.WriteLine(question);

            List<WeaponType> WeaponChoice = Enum.GetValues(typeof(WeaponType)).OfType<WeaponType>().ToList();

            foreach (WeaponType weapontype in WeaponChoice)
            {
                Console.WriteLine(Weapon.GetWeaponDesc(weapontype));
            }

            WeaponType validSelectedWeapon = WeaponType.Club;
            bool inputInvalidWeapon = true;
            while (inputInvalidWeapon)
            {
                Console.WriteLine(question);
                string weaponChoice = Common.convertToPascal(Console.ReadLine());


                if (Enum.TryParse(weaponChoice, out WeaponType selectedWeaponEnum))
                {
                    validSelectedWeapon = selectedWeaponEnum;
                    inputInvalidWeapon = !inputInvalidWeapon;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid Weapon, Try again.");
                    Console.ResetColor();
                }
            }


            Weapon playersChosenWeapon = new Weapon("Lightsaber", 1, 8, 10, 0, WeaponType.Club);

            if (validSelectedWeapon == WeaponType.Club)
            {
                playersChosenWeapon = new("Club", 1, 8, 10, 0, WeaponType.Club);
            }
            else if (validSelectedWeapon == WeaponType.Longsword)
            {
                playersChosenWeapon = new("Longsword", 1, 8, 10, 0, WeaponType.Longsword);
            }
            else if (validSelectedWeapon == WeaponType.Longbow)
            {
                playersChosenWeapon = new("LongBow", 1, 8, 10, 0, WeaponType.Longbow);
            }
            else if (validSelectedWeapon == WeaponType.Trident)
            {
                playersChosenWeapon = new("Trident", 1, 8, 10, 0, WeaponType.Trident);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid Weapon, Try again.");
                Console.ResetColor();
            }

            player.EquippedWeapon = playersChosenWeapon;

        }
        
    }

}
