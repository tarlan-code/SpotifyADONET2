using Spotifty.Contexts;
using Spotifty.Menu;
using Spotifty.Models;
using Spotifty.Services;
using Spotifty.Validations;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using System.Text;

namespace Spotifty
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Context context = new Context();


            bool breakpoint = true;

            do
            {
                MenuText.MainMenu();
                MenuText.EnterKey();
                int.TryParse(Console.ReadLine(), out int key);

                switch (key)
                {

                    case 1:
                        #region Usercase
                        Console.Clear();
                        Console.WriteLine("User commands");
                        MenuText.SubMenu();
                        MenuText.EnterKey();
                        int.TryParse(Console.ReadLine(), out int subkey);
                        switch (subkey)
                        {
                            case 1:
                                Console.Clear();
                                foreach (Users user in context.Users.GetData())
                                {
                                    Console.WriteLine($"\nID:{user.Id}\tFullname: {user.Name}  {user.Surname}\nUsername: {user.Username}\nPassword: {user.Password}\nGender: {user.Gender}\t\tRole: {user.RoleType}\n");
                                }

                                break;


                            case 2:
                                Console.Clear();
                                MenuText.EnterID();
                                int.TryParse(Console.ReadLine(), out int id);
                                if (id == 0) Console.WriteLine("Yanlış daxil edilmiş ID zəhmət olmazsa yenidən yoxlayın");
                                else
                                {
                                    Users user = context.Users.GetById(id);
                                    Console.Clear();
                                    if (user == null) Console.WriteLine("Bu ID-yə uyğun user yoxdur");
                                    else Console.WriteLine($"\nID:{user.Id}\tFullname: {user.Name}  {user.Surname}\nUsername: {user.Username}\nPassword: {user.Password}\nGender: {user.Gender}\t\tRole: {user.RoleType}\n");
                                }
                                break;
                            case 3:
                                string name = "";
                                string surname = "";
                                string username = "";
                                string password = "";
                                string gender = "";
                                int roleid = 0;

                                while (true)
                                {
                                    bool checkpoint = true;

                                    do
                                    {
                                        MenuText.EnterZero();
                                        Console.WriteLine("Ad: ");
                                        name = Console.ReadLine().Trim();

                                        if (name == "0")
                                        {
                                            checkpoint = false;
                                            Console.Clear();
                                            break;
                                        }
                                        else if (name.CheckNull() || !name.CheckLen(20, 2))
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Zəhmət olmasa 'Adı' qaydalara uyğun daxil edin Uzunluq(2-20) Boş qoyula bilməz");
                                            continue;
                                        }

                                        else break;
                                    }
                                    while (true);
                                    if (!checkpoint) break;


                                    do
                                    {
                                        MenuText.EnterZero();
                                        Console.WriteLine("Soyad: ");
                                        surname = Console.ReadLine().Trim();
                                        if (surname == "0")
                                        {
                                            checkpoint = false;
                                            Console.Clear();
                                            break;
                                        }
                                        else if (surname.CheckNull() || !surname.CheckLen(25, 2))
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Zəhmət olmasa 'Soyadı' qaydalara uyğun daxil edin Uzunluq(2-25)");
                                            continue;
                                        }

                                        else break;
                                    } while (true);
                                    if (!checkpoint) break;


                                    do
                                    {
                                        MenuText.EnterZero();
                                        Console.WriteLine("Username: ");
                                        username = Console.ReadLine().Trim();
                                        if (username == "0")
                                        {
                                            checkpoint = false;
                                            Console.Clear();
                                            break;
                                        }
                                        else if (username.CheckNull() || !username.CheckLen(30, 1))
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Zəhmət olmasa 'Username'-i qaydalara uyğun daxil edin Uzunluq(2-30) Boş qoyula bilməz");
                                            continue;
                                        }

                                        else break;
                                    } while (true);
                                    if (!checkpoint) break;


                                    do
                                    {
                                        MenuText.EnterZero();
                                        Console.WriteLine("Şifrə: ");
                                        password = Console.ReadLine();
                                        if (password == "0")
                                        {
                                            checkpoint = false;
                                            Console.Clear();
                                            break;
                                        }
                                        else if (password.CheckNull() || !password.CheckLen(30, 8))
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Zəhmət olmasa 'Şifrəni' qaydalara uyğun daxil edin Uzunluq(8-30) Boş qoyula bilməz");
                                        }

                                        else break;
                                    } while (true);
                                    if (!checkpoint) break;


                                    do
                                    {
                                        MenuText.EnterZero();
                                        Console.WriteLine("Cins: ");
                                        gender = Console.ReadLine().Trim();
                                        if (gender == "0")
                                        {
                                            checkpoint = false;
                                            Console.Clear();
                                            break;
                                        }
                                        else if (gender.CheckNull() || !gender.CheckLen(6, 1))
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Zəhmət olmasa 'Cinsi' qaydalara uyğun daxil edin Uzunluq(1-6)//Boş qoyula bilməz//Yalnız ingilis hərfləri");
                                        }

                                        else break;
                                    } while (true);
                                    if (!checkpoint) break;



                                    do
                                    {
                                        checkpoint = true;
                                        foreach (Roles item in context.Roles.GetData())
                                        {
                                            Console.WriteLine($"{item.Id}. {item.Type}");
                                        }
                                        MenuText.EnterZero();
                                        Console.WriteLine("Role Id-ni daxil edin: ");
                                        string roleids = Console.ReadLine().Trim();
                                        if (roleids == "0")
                                        {
                                            checkpoint = false;
                                            Console.Clear();
                                            break;
                                        }
                                        int.TryParse(roleids, out int roleidg);


                                        foreach (Roles item in context.Roles.GetData())
                                        {
                                            if (item.Id == roleidg)
                                            {
                                                checkpoint = false;
                                                roleid = roleidg;
                                                break;
                                            }
                                        }

                                        if (roleid == 0)
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Bu ID-yə uyğun rol yoxdur zəhmət olmasa yenidən daxil edin");
                                        }

                                        else break;

                                    } while (true);
                                    if (!checkpoint) break;
                                }

                                if (roleid > 0)
                                {
                                    context.Users.Add(new Users()
                                    {
                                        Name = name,
                                        Surname = surname,
                                        Username = username,
                                        Password = password,
                                        Gender = gender,
                                        RoleId = roleid,
                                    });

                                }
                                break;
                            case 4:
                                bool check = false;
                                do
                                {
                                    MenuText.EnterZero();
                                    Console.WriteLine("Adın dəyişmək istədiyiniz userin ID-ni daxil edin: ");
                                    string userids = Console.ReadLine();
                                    if (userids == "0")
                                    {
                                        Console.Clear();
                                        break;
                                    }
                                    int.TryParse(userids, out int userid);
                                    if (userid == 0) Console.WriteLine("Yanlış daxil edilmiş ID zəhmət olmazsa yenidən yoxlayın");
                                    else
                                    {
                                        Users user = context.Users.GetById(userid);
                                        Console.Clear();
                                        if (user == null) Console.WriteLine("Bu ID-yə uyğun user yoxdur");
                                        else
                                        {
                                            do
                                            {
                                                MenuText.EnterZero();
                                                Console.WriteLine("Dəyişələcək adı daxil edin: ");

                                                name = Console.ReadLine().Trim();

                                                if (name == "0")
                                                {
                                                    Console.Clear();
                                                    break;
                                                }
                                                else if (name.CheckNull() || !name.CheckLen(20, 2))
                                                {
                                                    Console.Clear();
                                                    Console.WriteLine("Zəhmət olmasa 'Adı' qaydalara uyğun daxil edin Uzunluq(2-20) Boş qoyula bilməz");
                                                    continue;
                                                }

                                                else
                                                {
                                                    check = true;
                                                    break;
                                                }
                                            }
                                            while (true);


                                            if (check)
                                            {
                                                context.Users.Update(user, name);
                                                break;
                                            }

                                            else break;
                                        }
                                    }
                                } while (true);

                                break;
                            case 5:

                                do
                                {
                                    MenuText.EnterZero();
                                    Console.WriteLine("Silmək istədiyiniz Userin ID-ni daxil edin: ");
                                    string userids = Console.ReadLine();
                                    if (userids == "0")
                                    {
                                        Console.Clear();
                                        break;
                                    }
                                    int.TryParse(userids, out int userid);
                                    Console.Clear();
                                    if (userid == 0) Console.WriteLine("Yanlış daxil edilmiş ID zəhmət olmazsa yenidən yoxlayın");
                                    else
                                    {
                                        context.Users.Remove(userid);
                                        break;
                                    }
                                } while (true);

                                break;
                            case 6:
                                Console.Clear();
                                break;
                            default:
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Yanlış komanda daxil edilib!!");
                                Console.ForegroundColor = ConsoleColor.White;
                                break;
                        }
                        break;
                    #endregion


                    case 2:
                        #region Musiccase
                        Console.Clear();
                        Console.WriteLine("Musics commands");
                        MenuText.SubMenu();
                        MenuText.EnterKey();
                        int.TryParse(Console.ReadLine(), out int subkeym);
                        switch (subkeym)
                        {
                            case 1:
                                Console.Clear();
                                foreach (Musics music in context.Musics.GetData())
                                {
                                    Console.WriteLine($"\nID:{music.Id}\tMusic name: {music.Name}  Time:{music.GetDuration}\n");
                                }

                                break;
                            case 2:
                                Console.Clear();
                                MenuText.EnterID();
                                int.TryParse(Console.ReadLine(), out int id);
                                if (id == 0) Console.WriteLine("Yanlış daxil edilmiş ID zəhmət olmazsa yenidən yoxlayın");
                                else
                                {
                                    Musics music = context.Musics.GetById(id);
                                    Console.Clear();
                                    if (music == null) Console.WriteLine("Bu ID-yə uyğun music yoxdur");
                                    else Console.WriteLine($"\nID:{music.Id}\tMusic name: {music.Name}  Time:{music.GetDuration}\n");
                                }
                                break;
                            case 3:
                                string name = "";
                                int duration = 0;
                                int categoryid = 0;
                                bool checkCatId = false;

                                while (true)
                                {
                                    bool checkpoint = true;

                                    do
                                    {
                                        checkpoint = true;
                                        MenuText.EnterZero();
                                        Console.WriteLine("Musiqi adı: ");
                                        name = Console.ReadLine().Trim();

                                        if (name == "0")
                                        {
                                            checkpoint = false;
                                            Console.Clear();
                                            break;
                                        }
                                        else if (name.CheckNull() || !name.CheckLen(30, 1))
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Zəhmət olmasa 'Musiqi adını' qaydalara uyğun daxil edin Uzunluq(1-30) Boş qoyula bilməz");
                                            continue;
                                        }

                                        else break;
                                    }
                                    while (true);
                                    if (!checkpoint) break;

                                    do
                                    {
                                        checkpoint = true;
                                        MenuText.EnterZero();
                                        Console.WriteLine("Time: ");
                                        string times = Console.ReadLine();
                                        if (times == "0")
                                        {
                                            checkpoint = false;
                                            break;
                                        }
                                        int.TryParse(times, out int time);


                                        if (time <= 0)
                                        {
                                            Console.WriteLine("Yanlış daxil etmə mahnı uzunluğu 0 ola bilməz");
                                            Console.WriteLine("Zəhmət olmazsa yenidən daxil edin");
                                        }

                                        else
                                        {
                                            duration = time;
                                            break;

                                        }

                                    } while (true);
                                    if (!checkpoint) break;


                                    do
                                    {
                                        checkpoint = true;
                                        foreach (Categories item in context.Categories.GetData())
                                        {
                                            Console.WriteLine($"{item.Id}. {item.Name}");
                                        }
                                        MenuText.EnterZero();
                                        Console.WriteLine("Kateqoriya Id-ni daxil edin: ");
                                        string catids = Console.ReadLine().Trim();
                                        if (catids == "0")
                                        {
                                            checkpoint = false;
                                            Console.Clear();
                                            break;
                                        }
                                        int.TryParse(catids, out int catid);


                                        foreach (Categories item in context.Categories.GetData())
                                        {
                                            if (item.Id == catid)
                                            {
                                                checkCatId = true;
                                                categoryid = catid;
                                                break;
                                            }
                                        }

                                        if (!checkCatId)
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Bu ID-yə uyğun kateqoriya yoxdur zəhmət olmasa yenidən daxil edin");
                                            continue;
                                        }

                                        else break;

                                    } while (true);
                                    if (!checkpoint || categoryid > 0) break;
                                }

                                if (categoryid > 0)
                                {
                                    context.Musics.Add(new Musics()
                                    {
                                        Name = name,
                                        Duration = duration,
                                        CategoryId = categoryid
                                    });
                                }

                                break;
                            case 4:
                                bool check = false;
                                do
                                {
                                    MenuText.EnterZero();
                                    Console.WriteLine("Adın dəyişmək istədiyiniz Musqinin ID-ni daxil edin: ");
                                    string musids = Console.ReadLine();
                                    if (musids == "0")
                                    {
                                        Console.Clear();
                                        break;
                                    }
                                    int.TryParse(musids, out int musid);
                                    if (musid == 0) Console.WriteLine("Yanlış daxil edilmiş ID zəhmət olmazsa yenidən yoxlayın");
                                    else
                                    {
                                        Musics music = context.Musics.GetById(musid);
                                        Console.Clear();
                                        if (music == null) Console.WriteLine("Bu ID-yə uyğun musiqi yoxdur");
                                        else
                                        {
                                            do
                                            {
                                                MenuText.EnterZero();
                                                Console.WriteLine("Dəyişələcək adı daxil edin: ");

                                                name = Console.ReadLine().Trim();

                                                if (name == "0")
                                                {
                                                    Console.Clear();
                                                    break;
                                                }
                                                else if (name.CheckNull() || !name.CheckLen(30, 1))
                                                {
                                                    Console.Clear();
                                                    Console.WriteLine("Zəhmət olmasa 'Musiqi adını' qaydalara uyğun daxil edin Uzunluq(1-30) Boş qoyula bilməz");
                                                    continue;
                                                }

                                                else
                                                {
                                                    check = true;
                                                    break;
                                                }
                                            }
                                            while (true);


                                            if (check)
                                            {
                                                context.Musics.Update(music, name);
                                                break;
                                            }

                                            else break;
                                        }
                                    }
                                } while (true);

                                break;
                            case 5:

                                do
                                {
                                    MenuText.EnterZero();
                                    Console.WriteLine("Silmək istədiyiniz Msiqinin ID-ni daxil edin: ");
                                    string musids = Console.ReadLine();
                                    if (musids == "0")
                                    {
                                        Console.Clear();
                                        break;
                                    }
                                    int.TryParse(musids, out int musid);
                                    Console.Clear();
                                    if (musid == 0) Console.WriteLine("Yanlış daxil edilmiş ID zəhmət olmazsa yenidən yoxlayın");
                                    else
                                    {
                                        context.Musics.Remove(musid);
                                        break;
                                    }
                                } while (true);

                                break;
                            case 6:
                                Console.Clear();
                                break;
                            default:
                                Console.ForegroundColor = ConsoleColor.Red;
                                MenuText.WrongCommand();
                                Console.ForegroundColor = ConsoleColor.White;
                                break;
                        }
                        break;
                    #endregion
                    case 3:
                        break;
                    case 4:
                        break;
                    case 5:
                        #region Artistcase
                        Console.Clear();
                        Console.WriteLine("Artist commands");
                        MenuText.SubMenu();
                        MenuText.EnterKey();
                        int.TryParse(Console.ReadLine(), out int subkeya);
                        switch (subkeya)
                        {
                            case 1:
                                Console.Clear();
                                foreach (Artists artist in context.Artists.GetData())
                                {
                                    Console.WriteLine($"\nID:{artist.Id}\tFullname: {artist.Name}  {artist.Surname}\nBirthdya: {artist.BirthDay}\nGender: {artist.Gender}\n");
                                }
                                break;


                            case 2:
                                Console.Clear();
                                MenuText.EnterID();
                                int.TryParse(Console.ReadLine(), out int id);
                                if (id == 0) Console.WriteLine("Yanlış daxil edilmiş ID zəhmət olmazsa yenidən yoxlayın");
                                else
                                {
                                    Artists artist = context.Artists.GetById(id);
                                    Console.Clear();
                                    if (artist == null) Console.WriteLine("Bu ID-yə uyğun artist yoxdur");
                                    else Console.WriteLine($"\nID:{artist.Id}\tFullname: {artist.Name}  {artist.Surname}\nBirthdya: {artist.BirthDay}\nGender: {artist.Gender}\n");

                                }
                                break;
                            case 3:
                                string name = "";
                                string surname = "";
                                DateTime birthday = new DateTime();
                                string gender = "";

                                while (true)
                                {
                                    bool checkpoint = true;

                                    do
                                    {
                                        MenuText.EnterZero();
                                        Console.WriteLine("Ad: ");
                                        name = Console.ReadLine().Trim();

                                        if (name == "0")
                                        {
                                            checkpoint = false;
                                            Console.Clear();
                                            break;
                                        }
                                        else if (name.CheckNull() || !name.CheckLen(20, 2))
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Zəhmət olmasa 'Adı' qaydalara uyğun daxil edin Uzunluq(2-20) Boş qoyula bilməz");
                                            continue;
                                        }

                                        else break;
                                    }
                                    while (true);
                                    if (!checkpoint) break;


                                    do
                                    {
                                        MenuText.EnterZero();
                                        Console.WriteLine("Soyad: ");
                                        surname = Console.ReadLine().Trim();
                                        if (surname == "0")
                                        {
                                            checkpoint = false;
                                            Console.Clear();
                                            break;
                                        }
                                        else if (surname.CheckNull() || !surname.CheckLen(25, 2))
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Zəhmət olmasa 'Soyadı' qaydalara uyğun daxil edin Uzunluq(2-25)");
                                            continue;
                                        }

                                        else break;
                                    } while (true);
                                    if (!checkpoint) break;




                                    do
                                    {
                                        MenuText.EnterZero();
                                        Console.WriteLine("Birthday('1991-09-24'): ");
                                        string birthdays = Console.ReadLine().Trim();
                                        if (birthdays == "0")
                                        {
                                            checkpoint = false;
                                            Console.Clear();
                                            break;
                                        }

                                        bool IsDate = DateTime.TryParse(birthdays, out DateTime birthdayParse);
                                        if (IsDate)
                                        {
                                            birthday = birthdayParse;
                                            break;
                                        }
                                        else
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Yanlış tarix formatı zəhmət olmazsa yenidən daxil edin");
                                        }
                                    } while (true);
                                    if (!checkpoint) break;



                                    do
                                    {
                                        MenuText.EnterZero();
                                        Console.WriteLine("Cins: ");
                                        gender = Console.ReadLine().Trim();
                                        if (gender == "0")
                                        {
                                            checkpoint = false;
                                            Console.Clear();
                                            break;
                                        }
                                        else if (gender.CheckNull() || !gender.CheckLen(6, 1))
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Zəhmət olmasa 'Cinsi' qaydalara uyğun daxil edin Uzunluq(1-6)//Boş qoyula bilməz//Yalnız ingilis hərfləri");
                                        }

                                        else break;
                                    } while (true);
                                    if (!checkpoint || gender.Length > 0) break;

                                }

                                if (gender.Length > 0)
                                {
                                    context.Artists.Add(new Artists()
                                    {
                                        Name = name,
                                        Surname = surname,
                                        BirthDay = birthday,
                                        Gender = gender
                                    });

                                }
                                break;
                            case 4:
                                bool check = false;
                                do
                                {
                                    MenuText.EnterZero();
                                    Console.WriteLine("Adın dəyişmək istədiyiniz artistin ID-ni daxil edin: ");
                                    string artistids = Console.ReadLine();
                                    if (artistids == "0")
                                    {
                                        Console.Clear();
                                        break;
                                    }
                                    int.TryParse(artistids, out int artistid);
                                    if (artistid == 0) Console.WriteLine("Yanlış daxil edilmiş ID zəhmət olmazsa yenidən yoxlayın");
                                    else
                                    {
                                        Artists artist = context.Artists.GetById(artistid);
                                        Console.Clear();
                                        if (artist == null) Console.WriteLine("Bu ID-yə uyğun artist yoxdur");
                                        else
                                        {
                                            do
                                            {
                                                MenuText.EnterZero();
                                                Console.WriteLine("Dəyişələcək adı daxil edin: ");

                                                name = Console.ReadLine().Trim();

                                                if (name == "0")
                                                {
                                                    Console.Clear();
                                                    break;
                                                }
                                                else if (name.CheckNull() || !name.CheckLen(20, 2))
                                                {
                                                    Console.Clear();
                                                    Console.WriteLine("Zəhmət olmasa 'Adı' qaydalara uyğun daxil edin Uzunluq(2-20) Boş qoyula bilməz");
                                                    continue;
                                                }

                                                else
                                                {
                                                    check = true;
                                                    break;
                                                }
                                            }
                                            while (true);


                                            if (check)
                                            {
                                                context.Artists.Update(artist, name);
                                                break;
                                            }
                                            else break;
                                        }
                                    }
                                } while (true);

                                break;
                            case 5:

                                do
                                {
                                    MenuText.EnterZero();
                                    Console.WriteLine("Silmək istədiyiniz Artistin ID-ni daxil edin: ");
                                    string artistids = Console.ReadLine();
                                    if (artistids == "0")
                                    {
                                        Console.Clear();
                                        break;
                                    }
                                    int.TryParse(artistids, out int artistid);
                                    Console.Clear();
                                    if (artistid == 0) Console.WriteLine("Yanlış daxil edilmiş ID zəhmət olmazsa yenidən yoxlayın");
                                    else
                                    {
                                        context.Artists.Remove(artistid);
                                        break;
                                    }
                                } while (true);

                                break;
                            case 6:
                                Console.Clear();
                                break;
                            default:
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Yanlış komanda daxil edilib!!");
                                Console.ForegroundColor = ConsoleColor.White;
                                break;
                            
                        }

                        break;

                    #endregion
                    case 6:
                        break;
                    case 7:
                        break;
                    case 8:
                        break;

                    case 9:
                        breakpoint = false;
                        break;

                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        MenuText.WrongCommand();
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                }
            } while (breakpoint);








            #region Music Add,Remove,CW,GetById

            //MusicServices mss = new MusicServices();

            //ADD
            //context.Music.Add(new Musics()
            //{
            //    Name = "Shadow",
            //    Duration = 250,
            //    CategoryId = 2
            //});


            //REMOVE
            //mss.Remove(12);

            //CW
            //foreach (Music music in mss.GetData())
            //{
            //    Console.WriteLine($"{music.Id}. {music.Name}   {music.GetDuration}");
            //}



            //GetById
            //Music music = mss.GetById(1);
            //Console.WriteLine($"{music.Id}. {music.Name}   {music.GetDuration}");

            #endregion


            #region Artist  Add,Remove,CW,GetById
            //ArtistServices ase = new ArtistServices();

            //ADD
            //ase.Add(new Artist()
            //{
            //    Name = "Tankurtttt",
            //    Surname = "Manas",
            //    BirthDay = DateTime.Parse("1991-09-12"),
            //    Gender = "Male"

            //});


            //REMOVE
            //ase.Remove(32);


            //CW
            //foreach (Artists artist in context.Artist.GetData())
            //{
            //    Console.WriteLine($"{artist.Id}.{artist.Name}---{artist.Surname}---{artist.BirthDay.ToString().Substring(0, artist.BirthDay.ToString().Length - 12)}---{artist.Gender}");
            //}


            //GetById
            //Artist artist = ase.GetById(1);
            //Console.WriteLine($"{artist.Id}.{artist.Name}---{artist.Surname}---{artist.BirthDay.ToString().Substring(0, artist.BirthDay.ToString().Length - 12)}---{artist.Gender}");

            //Update
            //context.Artist.Update(context.Artist.GetById(1), "Caged");
            #endregion

        }
    }
}