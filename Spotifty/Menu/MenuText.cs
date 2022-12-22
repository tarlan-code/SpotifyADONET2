using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotifty.Menu
{
    public static class MenuText
    {
        public static void MainMenu()
        {
            Console.WriteLine("\n1.User\n2.Music\n3.Role\n4.Category\n5.Artist\n6.Playlist\n7.Playlist Musics\n8.Artist Musics\n9.Exit\n");
        }
        public static void SubMenu()
        {
            Console.WriteLine("\n1. Get All\n2. Get By Id\n3. Create\n4. Update\n5. Delete\n6.Main Menu\n");
        }

        public static void EnterKey()
        {
            Console.Write("Komandanı daxil edin: ");
        }
        

        public static void EnterID()
        {
            Console.WriteLine("ID-ni daxil edin: ");
        }

        public static void EnterZero()
        {
            Console.WriteLine("\nÇıxış üçün 0 daxil edin");

        }

        public static void WrongCommand()
        {
            Console.WriteLine("Yanlış komanda daxil edilib!!");
        }
    }
}
