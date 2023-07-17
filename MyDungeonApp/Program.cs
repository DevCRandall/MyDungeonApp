using System.Numerics;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using DungeonLibrary;

namespace MyDungeonApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Introduction
            //TODO Intro
            Console.WriteLine("Hello Adventurer! Welcome to the Dungeon of Doom!");
            #endregion

            
            //Player Creation, after we've learned how to create custom Datatypes.
            //Reference the notes in the TestHarness for some ideas of how to expand player creation.

            //Potential expansion - Let the user choose from a list of pre-made weapons.

            #region Select Player Name
            Console.WriteLine("What is your name?");
            string playerName = Console.ReadLine();
            Console.Clear();
            Console.WriteLine($"Hello {playerName}!\n");
            #endregion Select Player Name

            #region Player Race Selection

            

            List<Race> PlayerRaces = Enum.GetValues(typeof(Race)).OfType<Race>().ToList();
            //Dictionary<DungeonLibrary.RaceName, RaceBonus> races = new Dictionary<DungeonLibrary.RaceName, RaceBonus>();
            //races[DungeonLibrary.RaceName.Human] = new DungeonLibrary.Race(DungeonLibrary.RaceName.Human, 5, 0, 0);
            //races[DungeonLibrary.RaceName.Human] = new DungeonLibrary.Race(DungeonLibrary.RaceName.Dragonborn, 5, 0, 0);
            //races[DungeonLibrary.RaceName.Human] = new DungeonLibrary.Race(DungeonLibrary.RaceName.Fairy, 5, 0, 0);
            //races[DungeonLibrary.RaceName.Human] = new DungeonLibrary.Race(DungeonLibrary.RaceName.Dwarf, 5, 0, 0);
            //races[DungeonLibrary.RaceName.Human] = new DungeonLibrary.Race(DungeonLibrary.RaceName.Barbarian, 5, 0, 0);
            //races[DungeonLibrary.RaceName.Human] = new DungeonLibrary.Race(DungeonLibrary.RaceName.Druid, 5, 0, 0);
            foreach (Race race in PlayerRaces)
            {
                Console.WriteLine(Player.GetRaceDesc(race));
            }
            Console.WriteLine("What kind of Adventurer are you?");
            Race validSelectedRace = Race.Human;
            

            #endregion Player Race Selection

            bool inputInvalid = true;
            while(inputInvalid)
            {
                
                string selectedRace = Common.convertToPascal(Console.ReadLine());
                

                if (Enum.TryParse(selectedRace, out Race selectedRaceEnum))
                {
                    validSelectedRace = selectedRaceEnum;
                    inputInvalid = !inputInvalid;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid Race, Try again.");
                    Console.ResetColor();
                }
            }
            Console.Clear();
            #region Weapon Selection
            

            

            //Potential Expansion - Let the user choose their name and Race
            //Player player = new($"{playerName}", races[DungeonLibrary.RaceName.Human], club);
            Player player = new($"{playerName}", validSelectedRace, new Weapon("Lightsaber", 1, 8, 10, 0, WeaponType.Club), false);
            Common.changeWeapon(player, "What weapon are you taking with you?");

            player.Score = 0;

            #endregion Weapon Selection

            //Outer Loop
            bool quit = false;
            do
            {
                #region Monster and room generation
                //We need to generate a new monster and a new room for each encounter.                
                // Generate a room - random string description
                Console.WriteLine("You come up to a door: " + GetRoom());//Room # is temporary until you add room descriptions.
                //TODO Generate a Monster (custom datatype) 
                Monster monster = Monster.GetMonster();
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("\n In this room is a " + monster.Name);
                Console.ResetColor();
                #endregion 

                #region Encounter Loop                
                //This menu repeats until either the monster dies or the player quits, dies, or runs away.
                bool reload = false;//set to true to "reload" the monster & the room
                do
                {
                    #region Menu
                    Console.WriteLine("\nPlease choose an action:\n" +
                        "1) Attack\n" +
                        "2) Run away\n" +
                        "3) Player Info\n" +
                        "4) Monster Info\n" +
                        "5) Weapon\n" +
                        "6) Health Potion\n" +
                        "7) Exit\n");

                    char action = Console.ReadKey(true).KeyChar;
                    Console.Clear();
                    switch (action)
                    {
                        case '1':
                            Console.WriteLine("Attack!");
                            // Combat functionality

                            reload = Combat.DoBattle(player, monster);
                            break;
                        case '2':
                            Console.WriteLine("Run Away!!");
                            // Give the monster a free attack chance
                            Combat.DoAttack(monster, player);

                            //Leave the inner loop (reload the room) and get a new room & monster.
                            reload = true;
                            break;
                        case '3':
                            Console.WriteLine("Player info: ");
                            // print player details to the screen
                            Console.WriteLine(player);
                            break;

                        case '4':
                            Console.WriteLine("Monster info: ");
                            // Print monster details to the screen
                            Console.WriteLine(monster);
                            break;

                        case '5':
                            Common.changeWeapon(player, "What do you want to change your weapon to?");
                            break;

                        case '6':
                            Console.WriteLine("You attemtped to heal");
                            player.CalcHeal();
                            Combat.DoAttack(monster, player);
                            break;

                        case '7':
                            //quit the whole game. "reload = true;" gives us a new room and monster, "quit = true" quits the game, leaving both the inner AND outer loops.
                            Console.WriteLine("No one likes a quitter!");
                            quit = true;
                            break;

                        default:
                            Console.WriteLine("Do you think this is a game?? Quit playing around!");
                            break;
                    }//end switch
                    #endregion Menu
                    // Check Player Life. If they are dead, quit the game and show them their score.
                    if (player.Life < +0)
                    {
                        Console.WriteLine("You died...\a");
                        quit = true; //Leaves both loops.
                    }

                } while (!reload && !quit); //While reload and quit are both FALSE (!true), keep looping. If either becomes true, leave the inner loop.
                #endregion Encounter Loop


            } while (!quit);
            #region Exit
            //TODO output the final score
            Console.WriteLine("You defeated " + player.Score + " monster" + (player.Score == 1 ? "." : "s."));
            #endregion


            
        }//End Main()

        

        #region GetRoom
        private static string GetRoom()
        {
            string[] rooms =
            {
                "The door is made of fir planks, it has a carved wooden knob and angled iron ventilation slats near the bottom of the door. This room has stone blocks that have been fitted together into tiles for the floor. Several deep scrapes in the floor lead away from the room's entrance. The ceiling is a flat ceiling with coved edges and appears broken and cracked. The cracks are from the width or a hair to that of a fist, but don't go more than an arm's length deep.\r\n\r\nA large section of one wall shows sign of massive heat damage. It is scorched black and the stone has melted smooth. The entire room smells of wildflowers as if you were standing in a large meadow at the height of spring.\r\n\r\nThe air in the room is steamy. The room smells salty and wet. A faint footsteps noise can be heard.",
                "The door is made of slate, it has a double-sided wooden bolt with keyed lock and any creature that approaches within five feet of this door casts a dark shadow upon it, regardless of nearby light sources. This room has a roughly hewn stone floor that has small gravel and dirt strewn around. A pit has been carved into the stone of the floor near one wall. It is about two feet wide, five feet long and three feet wide. The ceiling is a faceted (ceiling is broken into flat facets similar to a dome) and that seems to glow with a faint red light.\r\n\r\nCarved in relief at waist height around the room is an elaborate scrollwork style molding. About a dozen rusting climbing spikes protrude from the walls in seemingly in random places.\r\n\r\nThe air in the room is clear, with mist covering the floor. The room smells acrid. A faint drumming noise can be heard.",
                "The door is made of fir planks, it has a turning handle with keyed lock and is covered with flicking magical flames on the outside. They give off the light of a torch, but are cool to the touch. This room has a smoothly hewn natural stone floor that have been polished smooth. A stylized sun burst is centered in the floor of this room. Close inspection reveals that it is made from one continuous piece of black obsidian that has been formed into grooves etched about two inches deep. The ceiling is a flat and with the tattered remains of what once must have been colorful streamers hanging down to about eight feet from the floor.\r\n\r\nCrudely sketched upon the wall in charcoal is a lake with a large carnivorous fish in the middle. A length of thin rope with a dead rat tied to it every few feet lies discarded on the floor.\r\n\r\nThe air in the room is steamy. The room smells stale. A faint clashing noise can be heard.",
                "The door is made of redwood planks with iron bands, it has a turning handle with no lock and a mat made of woven moss about two by three feet lies in front of this door. This room has a hard-packed dirt floor. Numerous lines are etched into the floor of this room. They are less than a finger's width wide and have been filled and obscured by dirt and wear. It appears that this may have once been a map or mural, but is now indistinguishable. The ceiling is a barrel vaulted with ribs (regular rounded ribs support this barrel vault ceiling) and that has a bas relief eight-pointed star carved into the center.\r\n\r\nMost of one wall is a large mural, on the right side is a giant earth elemental with its arms stretched wide around many small humanoids, while on the left is a raging earth elemental surrounded with lifeless corpses A wooden hoop about two feet in diameter hangs upon the wall. It is laced with yarn in intricate patterns similar to a spider web.\r\n\r\nThe air in the room is hazy and humid. The room smells acrid. A faint clanking noise can be heard.",
                "The door is made of limestone, it has a carved wooden knob and a hand-sized \"x\" has been chalked upon the outside of the door. This room has clay bricks that have been laid down to form a solid floor. Line traces of violet light appear and disappear randomly across the floor. The ceiling is a flat trayed ceiling (concentric tiered recesses) and that looks like it was once plastered smooth and painted. Only small sections of plaster remain with the paints faded to obscurity.\r\n\r\nThe walls of this room are covered in rude graffiti and sayings in common. The remains of half a dozen smashed ceramic jars are scattered across the floor.\r\n\r\nThe air in the room is clear but cold. The room smells sulfurous. A faint chiming noise can be heard."
            };

            Random rand = new Random();
            //rooms.Length
            int index = rand.Next(rooms.Length);
            string room = rooms[index];
            return room;

            //Refactor:
            //return rooms[new Random().Next(rooms.Length)];
        }//End GetRoom()
        #endregion GetRoom
    }
    
}
