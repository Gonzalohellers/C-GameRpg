using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Engine
{
    public static class Mundo
    {
        public static readonly List<Objeto> Items = new List<Objeto>();
        public static readonly List<Monstruo> Monsters = new List<Monstruo>();
        public static readonly List<Busqueda> Quests = new List<Busqueda>();
        public static readonly List<Ubicacion> Locations = new List<Ubicacion>();

        public const int ITEM_ID_RUSTY_SWORD = 1;
        public const int ITEM_ID_RAT_TAIL = 2;
        public const int ITEM_ID_PIECE_OF_FUR = 3;
        public const int ITEM_ID_SNAKE_FANG = 4;
        public const int ITEM_ID_SNAKESKIN = 5;
        public const int ITEM_ID_CLUB = 6;
        public const int ITEM_ID_HEALING_POTION = 7;
        public const int ITEM_ID_SPIDER_FANG = 8;
        public const int ITEM_ID_SPIDER_SILK = 9;
        public const int ITEM_ID_ADVENTURER_PASS = 10;

        public const int MONSTER_ID_RAT = 1;
        public const int MONSTER_ID_SNAKE = 2;
        public const int MONSTER_ID_GIANT_SPIDER = 3;

        public const int QUEST_ID_CLEAR_ALCHEMIST_GARDEN = 1;
        public const int QUEST_ID_CLEAR_FARMERS_FIELD = 2;

        public const int LOCATION_ID_HOME = 1;
        public const int LOCATION_ID_TOWN_SQUARE = 2;
        public const int LOCATION_ID_GUARD_POST = 3;
        public const int LOCATION_ID_ALCHEMIST_HUT = 4;
        public const int LOCATION_ID_ALCHEMISTS_GARDEN = 5;
        public const int LOCATION_ID_FARMHOUSE = 6;
        public const int LOCATION_ID_FARM_FIELD = 7;
        public const int LOCATION_ID_BRIDGE = 8;
        public const int LOCATION_ID_SPIDER_FIELD = 9;

        static Mundo()
        {
            PopulateItems();
            PopulateMonsters();
            PopulateQuests();
            PopulateLocations();
        }

        private static void PopulateItems()
        {
            Items.Add(new Arma(ITEM_ID_RUSTY_SWORD, "Espada oxidada", "Espadas oxidadas", 0, 5));
            Items.Add(new Objeto(ITEM_ID_RAT_TAIL, "Cola de rata", "Colas de rata"));
            Items.Add(new Objeto(ITEM_ID_PIECE_OF_FUR, "Trozo de pelaje", "Trozos de pelaje"));
            Items.Add(new Objeto(ITEM_ID_SNAKE_FANG, "Colmillo de serpiente", "Colmillos de serpiente"));
            Items.Add(new Objeto(ITEM_ID_SNAKESKIN, "Piel de serpiente", "Pieles de serpiente"));
            Items.Add(new Arma(ITEM_ID_CLUB, "Garrote", "Garrotes", 3, 10));
            Items.Add(new PocionDeSalud(ITEM_ID_HEALING_POTION, "Poción de salud", "Pociones de salud", 5));
            Items.Add(new Objeto(ITEM_ID_SPIDER_FANG, "Colmillo de araña", "Colmillos de araña"));
            Items.Add(new Objeto(ITEM_ID_SPIDER_SILK, "Seda de araña", "Sedas de araña"));
            Items.Add(new Objeto(ITEM_ID_ADVENTURER_PASS, "Pase de aventurero", "Pases de aventurero"));
        }

        private static void PopulateMonsters()
        {
            Monstruo rat = new Monstruo(MONSTER_ID_RAT, "Rata", 5, 3, 10, 3, 3);
            rat.TableroDeItems.Add(new ItemDelBotin(ItemByID(ITEM_ID_RAT_TAIL), 75, false));
            rat.TableroDeItems.Add(new ItemDelBotin(ItemByID(ITEM_ID_PIECE_OF_FUR), 75, true));

            Monstruo snake = new Monstruo(MONSTER_ID_SNAKE, "Serpiente", 5, 3, 10, 3, 3);
            snake.TableroDeItems.Add(new ItemDelBotin(ItemByID(ITEM_ID_SNAKE_FANG), 75, false));
            snake.TableroDeItems.Add(new ItemDelBotin(ItemByID(ITEM_ID_SNAKESKIN), 75, true));

            Monstruo giantSpider = new Monstruo(MONSTER_ID_GIANT_SPIDER, "Araña Gigante", 20, 5, 40, 10, 10);
            giantSpider.TableroDeItems.Add(new ItemDelBotin(ItemByID(ITEM_ID_SPIDER_FANG), 75, true));
            giantSpider.TableroDeItems.Add(new ItemDelBotin(ItemByID(ITEM_ID_SPIDER_SILK), 25, false));

            Monsters.Add(rat);
            Monsters.Add(snake);
            Monsters.Add(giantSpider);
        }

        private static void PopulateQuests()
        {
            Busqueda clearAlchemistGarden =
        new Busqueda(
            QUEST_ID_CLEAR_ALCHEMIST_GARDEN,
            "Limpiar el jardín del alquimista",
            "Mata ratas en el jardín del alquimista y trae de vuelta 3 colas de rata. Recibirás una poción de salud y 10 piezas de oro.", 20, 10);

            clearAlchemistGarden.QuestCompletionItems.Add(new ArticuloDeFinalizacionMision(ItemByID(ITEM_ID_RAT_TAIL), 3));

            clearAlchemistGarden.RewardItem = ItemByID(ITEM_ID_HEALING_POTION);

            Busqueda clearFarmersField =
                new Busqueda(
                    QUEST_ID_CLEAR_FARMERS_FIELD,
                    "Limpiar el campo del agricultor",
                    "Mata serpientes en el campo del agricultor y trae de vuelta 3 colmillos de serpiente. Recibirás un pase de aventurero y 20 piezas de oro.", 20, 20);

            clearFarmersField.QuestCompletionItems.Add(new ArticuloDeFinalizacionMision(ItemByID(ITEM_ID_SNAKE_FANG), 3));

            clearFarmersField.RewardItem = ItemByID(ITEM_ID_ADVENTURER_PASS);

            Quests.Add(clearAlchemistGarden);
            Quests.Add(clearFarmersField);
        }

        private static void PopulateLocations()
        {
            // Create each location
            Ubicacion home = new Ubicacion(LOCATION_ID_HOME, "Casa", "Tu casa. Realmente necesitas limpiar el lugar.");

            Ubicacion townSquare = new Ubicacion(LOCATION_ID_TOWN_SQUARE, "Plaza del pueblo", "Ves una fuente.");

            Ubicacion alchemistHut = new Ubicacion(LOCATION_ID_ALCHEMIST_HUT, "Cabaña del alquimista", "Hay muchas plantas extrañas en los estantes.");
            alchemistHut.QuestAvailableHere = QuestByID(QUEST_ID_CLEAR_ALCHEMIST_GARDEN);

            Ubicacion alchemistsGarden = new Ubicacion(LOCATION_ID_ALCHEMISTS_GARDEN, "Jardín del alquimista", "Muchas plantas están creciendo aquí.");
            alchemistsGarden.MonsterLivingHere = MonsterByID(MONSTER_ID_RAT);

            Ubicacion farmhouse = new Ubicacion(LOCATION_ID_FARMHOUSE, "Casa del agricultor", "Hay una pequeña casa de campo, con un agricultor al frente.");
            farmhouse.QuestAvailableHere = QuestByID(QUEST_ID_CLEAR_FARMERS_FIELD);

            Ubicacion farmersField = new Ubicacion(LOCATION_ID_FARM_FIELD, "Campo del agricultor", "Ves filas de vegetales creciendo aquí.");
            farmersField.MonsterLivingHere = MonsterByID(MONSTER_ID_SNAKE);

            Ubicacion guardPost = new Ubicacion(LOCATION_ID_GUARD_POST, "Puesto de guardia", "Hay un guardia grande y fornido aquí.", ItemByID(ITEM_ID_ADVENTURER_PASS));

            Ubicacion bridge = new Ubicacion(LOCATION_ID_BRIDGE, "Puente", "Un puente de piedra cruza un ancho río.");

            Ubicacion spiderField = new Ubicacion(LOCATION_ID_SPIDER_FIELD, "Bosque", "Ves telas de araña cubriendo los árboles en este bosque.");
            spiderField.MonsterLivingHere = MonsterByID(MONSTER_ID_GIANT_SPIDER);


            // Link the locations together
            home.LocationToNorth = townSquare;

            townSquare.LocationToNorth = alchemistHut;
            townSquare.LocationToSouth = home;
            townSquare.LocationToEast = guardPost;
            townSquare.LocationToWest = farmhouse;

            farmhouse.LocationToEast = townSquare;
            farmhouse.LocationToWest = farmersField;

            farmersField.LocationToEast = farmhouse;

            alchemistHut.LocationToSouth = townSquare;
            alchemistHut.LocationToNorth = alchemistsGarden;

            alchemistsGarden.LocationToSouth = alchemistHut;

            guardPost.LocationToEast = bridge;
            guardPost.LocationToWest = townSquare;

            bridge.LocationToWest = guardPost;
            bridge.LocationToEast = spiderField;

            spiderField.LocationToWest = bridge;

            // Add the locations to the static list
            Locations.Add(home);
            Locations.Add(townSquare);
            Locations.Add(guardPost);
            Locations.Add(alchemistHut);
            Locations.Add(alchemistsGarden);
            Locations.Add(farmhouse);
            Locations.Add(farmersField);
            Locations.Add(bridge);
            Locations.Add(spiderField);
        }

        public static Objeto ItemByID(int id)
        {
            foreach (Objeto item in Items)
            {
                if (item.ID == id)
                {
                    return item;
                }
            }
            return null;
        }

        public static Monstruo MonsterByID(int id)
        {
            foreach (Monstruo monster in Monsters)
            {
                if (monster.ID == id)
                {
                    return monster;
                }
            }
            return null;
        }

        public static Busqueda QuestByID(int id)
        {
            foreach (Busqueda quest in Quests)
            {
                if (quest.ID == id)
                {
                    return quest;
                }
            }

            return null;
        }

        public static Ubicacion LocationByID(int id)
        {
            foreach (Ubicacion location in Locations)
            {
                if (location.ID == id)
                {
                    return location;
                }
            }

            return null;
        }
    }
}
