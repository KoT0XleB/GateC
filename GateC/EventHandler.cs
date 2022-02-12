using MEC;
using Qurre.API;
using Qurre.API.Addons.Textures;
using Qurre.API.Controllers;
using Qurre.API.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace GateC
{
    public class EventHandler
    {
        public static List<GameObject> gameObjects = new List<GameObject>();
        public static IReadOnlyList<GameObject> GameObjects => gameObjects;
        public static void RoundStarted()
        {
            CreateGateC();
            CreatingLamps();
            CreateMenu();
            CreateDoor();
            CreateExits();
            Timing.RunCoroutine(Teleports(), "tp");
        }
        public static void CreateExits()
        {
            Exit(new Vector3(-80.17f, 988.83f, -51.55f), new Vector3(0, 180, 0));
            Exit(new Vector3(-56.68f, 992.04f, -52.65f), new Vector3(0, 90, 0));
        }
        public static void Exit(Vector3 pos, Vector3 rot)
        {
            var Model = new Model("Exit", pos, rot);
            var quad = PrimitiveType.Quad;
            var quadrot = new Vector3(0, 180, 0);
            Model.AddPart(new ModelPrimitive(Model, PrimitiveType.Cube, Color.green, new Vector3(0.13f, 0.01049805f, -0.19f), new Vector3(0, 90, 0), new Vector3(1f, 1.84f, 4.68f)));
            Model.AddPart(new ModelPrimitive(Model, quad, Color.white, new Vector3(1.8822f, 0f, 0.312f), quadrot, new Vector3(0.272f, 1.274f, 1f)));
            Model.AddPart(new ModelPrimitive(Model, quad, Color.white, new Vector3(1.533f, 0.5252f, 0.312f), quadrot, new Vector3(0.4352f, 0.208f, 1f)));
            Model.AddPart(new ModelPrimitive(Model, quad, Color.white, new Vector3(1.533f, -0.01f, 0.312f), quadrot, new Vector3(0.4352f, 0.208f, 1f)));
            Model.AddPart(new ModelPrimitive(Model, quad, Color.white, new Vector3(1.533f, -0.5277f, 0.312f), quadrot, new Vector3(0.4352f, 0.208f, 1f)));
            Model.AddPart(new ModelPrimitive(Model, quad, Color.white, new Vector3(0.5276f, 0f, 0.312f), new Vector3(0, 180, 30f), new Vector3(0.25887f, 1.40263f, 1f)));
            Model.AddPart(new ModelPrimitive(Model, quad, Color.white, new Vector3(0.5276f, 0f, 0.312f), new Vector3(0, 180, -30f), new Vector3(0.25887f, 1.40263f, 1f)));
            Model.AddPart(new ModelPrimitive(Model, quad, Color.white, new Vector3(-0.4896f, 0f, 0.312f), quadrot, new Vector3(0.272f, 1.274f, 1f)));
            Model.AddPart(new ModelPrimitive(Model, quad, Color.white, new Vector3(-1.5123f, 0f, 0.312f), quadrot, new Vector3(0.272f, 1.274f, 1f)));
            Model.AddPart(new ModelPrimitive(Model, quad, Color.white, new Vector3(-1.5123f, 0.5927f, 0.312f), new Vector3(0, 180, 90), new Vector3(0.13f, 1.0336f, 1f)));
            Model.AddPart(new ModelLight(Model, Color.grey, new Vector3(0.223f, -0.26f, 1.02f), 1, 5));
        }
        public static void CreateDoor()
        {
            foreach (Door doors in Map.Doors)
            {
                if (doors.Type == DoorType.Escape_Secondary)
                {
                    doors.Position = new Vector3(-181.248f, 987.7f, -82.9f);
                }
            }
        }
        public static void CreateGateC()
        {
            var Model = new Model("GateC", new Vector3(0, 0, 0));
            var quad = PrimitiveType.Quad;
            var alpha = new Color32(255, 255, 255, 0);

            Model.AddPart(new ModelPrimitive(Model, quad, alpha, new Vector3(-172.5f, 987.45f, -59.4f), new Vector3(90, 90, 0), new Vector3(108.5f, 64.5f, 1f))); // 1
            Model.AddPart(new ModelPrimitive(Model, quad, alpha, new Vector3(-124.92f, 984.65f, -62.74f), new Vector3(100.4f, 90, 0), new Vector3(22.92f, 31.3f, 1f))); // 2
            Model.AddPart(new ModelPrimitive(Model, quad, alpha, new Vector3(-188.33f, 993.17f, -51.93f), new Vector3(0, -90, 0), new Vector3(62.8f, 16.6f, 1f))); // 3
            Model.AddPart(new ModelPrimitive(Model, quad, alpha, new Vector3(-157.91f, 992.92f, -73.13f), new Vector3(0, 180, 0), new Vector3(32.4f, 17.93f, 1f))); // 4
            Model.AddPart(new ModelPrimitive(Model, quad, alpha, new Vector3(-157.6f, 992.92f, -45.07f), new Vector3(0, 0, 0), new Vector3(32.4f, 17.93f, 1f))); // 5
            Model.AddPart(new ModelPrimitive(Model, quad, alpha, new Vector3(-173.8f, 992.92f, -35.79f), new Vector3(0, 90, 0), new Vector3(18.8f, 17.93f, 1f))); // 6
            Model.AddPart(new ModelPrimitive(Model, quad, alpha, new Vector3(-182.08f, 993.3f, -36.61f), new Vector3(0, 0, 0), new Vector3(18.8f, 17.93f, 1f))); // 7
            Model.AddPart(new ModelPrimitive(Model, quad, alpha, new Vector3(-174.13f, 992.92f, -82.38f), new Vector3(0, 90, 0), new Vector3(18.8f, 17.93f, 1f))); // 8
            //Model.AddPart(new ModelPrimitive(Model, quad, Color.white, new Vector3(-182.36f, 992.92f, -82.11f), new Vector3(0, 180, 0), new Vector3(18.8f, 17.93f, 1f))); // 9 //
            Model.AddPart(new ModelPrimitive(Model, quad, alpha, new Vector3(-141.64f, 992.92f, -48.26f), new Vector3(0, 90, 0), new Vector3(6.57f, 17.93f, 1f))); // 10
            Model.AddPart(new ModelPrimitive(Model, quad, alpha, new Vector3(-141.64f, 992.92f, -71.67f), new Vector3(0, 90, 0), new Vector3(3.55f, 17.93f, 1f))); // 11
            Model.AddPart(new ModelPrimitive(Model, quad, Color.white, new Vector3(-160.04f, 987.9f, -33.31f), new Vector3(90, 90, 0), new Vector3(33.6f, 36.94f, 1f))); // 12
            Model.AddPart(new ModelPrimitive(Model, quad, Color.white, new Vector3(-133f, 987.9f, -74.88f), new Vector3(90, 90, 0), new Vector3(16.7f, 113f, 1f))); // 13
            Model.AddPart(new ModelPrimitive(Model, quad, alpha, new Vector3(-112.25f, 988.09f, -51.5f), new Vector3(0, 0, 0), new Vector3(58.7f, 15.7f, 1f))); // 14
            Model.AddPart(new ModelPrimitive(Model, quad, alpha, new Vector3(-109.44f, 984.88f, -66.37f), new Vector3(0, 180, 0), new Vector3(66.09f, 5.9f, 1f))); // 15
            Model.AddPart(new ModelPrimitive(Model, quad, alpha, new Vector3(-68.54f, 988.09f, -51.5f), new Vector3(0, 0, 0), new Vector3(17.76f, 15.7f, 1f))); // 16
            Model.AddPart(new ModelPrimitive(Model, quad, alpha, new Vector3(-68.73f, 988.09f, -70.45f), new Vector3(0, 180, 0), new Vector3(15.9f, 15.7f, 1f))); // 17
            Model.AddPart(new ModelPrimitive(Model, quad, alpha, new Vector3(-76.47f, 985.1f, -68.42f), new Vector3(0, -90, 0), new Vector3(4.1f, 5.64f, 1f))); // 18
            Model.AddPart(new ModelPrimitive(Model, quad, alpha, new Vector3(-84.02f, 990.03f, -71.96f), new Vector3(0, -90, 0), new Vector3(4.1f, 4.81f, 1f))); // 19
            Model.AddPart(new ModelPrimitive(Model, quad, alpha, new Vector3(-76.673f, 990.03f, -71.996f), new Vector3(0, 90, 0), new Vector3(3.1f, 4.81f, 1f))); // 20
            Model.AddPart(new ModelPrimitive(Model, quad, alpha, new Vector3(-80.36f, 990.03f, -73.44f), new Vector3(0, 180, 0), new Vector3(7.42f, 4.81f, 1f))); // 21
            Model.AddPart(new ModelPrimitive(Model, quad, alpha, new Vector3(-85.04f, 982.24f, -58.66f), new Vector3(90, 90, 0), new Vector3(26.4f, 53.3f, 1f))); // 22
            Model.AddPart(new ModelPrimitive(Model, quad, alpha, new Vector3(-80.18f, 984.84f, -47.22f), new Vector3(0, 0, 0), new Vector3(5.72f, 5.4f, 1f))); // 23
            Model.AddPart(new ModelPrimitive(Model, quad, alpha, new Vector3(-77.39f, 984.84f, -49.38f), new Vector3(0, 90, 0), new Vector3(4.23f, 5.4f, 1f))); // 24
            Model.AddPart(new ModelPrimitive(Model, quad, alpha, new Vector3(-82.93f, 984.84f, -49.396f), new Vector3(0, -90, 0), new Vector3(4.2f, 5.4f, 1f))); // 25
            Model.AddPart(new ModelPrimitive(Model, quad, Color.black, new Vector3(-80.18f, 987.473f, -49.063f), new Vector3(-90, 0, 0), new Vector3(5.72f, 4.42f, 1f))); // 26
            Model.AddPart(new ModelPrimitive(Model, quad, alpha, new Vector3(-112.81f, 995.06f, -69.87f), new Vector3(0, 180, 0), new Vector3(57.55f, 15.7f, 1f))); // 27
            Model.AddPart(new ModelPrimitive(Model, quad, Color.black, new Vector3(-61.35f, 986.59f, -69.58f), new Vector3(0, 130, 0), new Vector3(4.15f, 11f, 1f))); // 28
            Model.AddPart(new ModelPrimitive(Model, quad, alpha, new Vector3(-134.14f, 987.82f, -51.25f), new Vector3(-16.09f, 0, 0), new Vector3(14.7f, 15.7f, 1f))); // 29
            Model.AddPart(new ModelPrimitive(Model, quad, alpha, new Vector3(-177.24f, 992.92f, -82.14f), new Vector3(0, 180, 0), new Vector3(1.6f, 17.93f, 1f))); // 31
            Model.AddPart(new ModelPrimitive(Model, quad, alpha, new Vector3(-185.11f, 992.92f, -82.14f), new Vector3(0, 180, 0), new Vector3(1.6f, 17.93f, 1f))); // 32
            Model.AddPart(new ModelPrimitive(Model, PrimitiveType.Cube, Color.gray, new Vector3(-189.32f, 990.6f, -82.9f), new Vector3(0, 0, 0), new Vector3(14.3f, 12f, 0.59f))); // Cube
            Model.AddPart(new ModelPrimitive(Model, PrimitiveType.Cube, Color.gray, new Vector3(-177.51f, 990.6f, -82.87f), new Vector3(0, 0, 0), new Vector3(5.46f, 11.5f, 0.64f))); // Cube
            Model.AddPart(new ModelPrimitive(Model, PrimitiveType.Cube, Color.gray, new Vector3(-181.19f, 994.85f, -82.88f), new Vector3(0, 0, 0), new Vector3(18.06f, 7.7f, 0.64f))); // Cube

            Model.AddPart(new ModelLight(Model, Color.yellow, new Vector3(-88.34f, 992.2f, -59.22f), 1, 15));

            gameObjects.Add(Model.gameObject);
        }
        public static IEnumerator<float> Teleports()
        {
            var TpBack = new Model("TeleportBack", new Vector3(-80.31f, 984.75f, -47.28f));
            var TpGateC = new Model("TeleportToGateC", new Vector3(-55.07f, 989.62f, -49.73f));
            while (!Round.Ended)
            {
                foreach (Player player in Player.List)
                {
                    if (Vector3.Distance(TpBack.gameObject.transform.position, player.Position) < 5)
                    {
                        player.Position = new Vector3(-48.78f, 989.62f, -49.73f);
                    }
                    if (Vector3.Distance(TpGateC.gameObject.transform.position, player.Position) < 5)
                    {
                        player.Position = new Vector3(-80.31f, 984.65f, -53.48f);
                    }
                }
                yield return Timing.WaitForSeconds(1f);
            }
            yield break;
        }
        public static void CreatingLamps()
        {
            Lamp(new Vector3(-180.62f, 986.94f, -16.08f), new Vector3(0, 0, 0), Color.grey, 1f, 20);
            Lamp(new Vector3(-176.4f, 987.37f, -47.4f), new Vector3(0, 0, 0), Color.grey, 0.8f, 15);
            Lamp(new Vector3(-175.26f, 987.38f, -78.44f), new Vector3(0, 90, 0), Color.gray, 0.7f, 20);
            Lamp(new Vector3(-163.59f, 987.38f, -69.05f), new Vector3(0, 0, 0), Color.gray, 0.8f, 15);
            Lamp(new Vector3(-151.78f, 987.38f, -47.68f), new Vector3(0, 0, 0), Color.grey, 0.8f, 15);
            Lamp(new Vector3(-129.3f, 984.84f, -58.93f), new Vector3(0, 90, 0), Color.gray, 1f, 20);
            Lamp(new Vector3(-104.66f, 981.7f, -58.93f), new Vector3(0, 90, 0), Color.grey, 1f, 20);
            Lamp(new Vector3(-77.49f, 987.37f, -67.07f), new Vector3(0, 90, 0), Color.gray, 0.8f, 20);
        }
        public static void Lamp(Vector3 pos, Vector3 rot, Color colorLight, float intensive, float range)
        {
            var color = new Color32(70, 70, 70, 255);
            var Model = new Model("Lamp", pos, rot);
            Model.AddPart(new ModelPrimitive(Model, PrimitiveType.Cylinder, color, new Vector3(0f, 1.36f, 0f), Vector3.zero, new Vector3(0.5f, 0.98f, 0.5f)));
            Model.AddPart(new ModelPrimitive(Model, PrimitiveType.Cylinder, color, new Vector3(0f, 2.986f, 0f), Vector3.zero, new Vector3(0.2f, 2.67f, 0.2f)));
            Model.AddPart(new ModelPrimitive(Model, PrimitiveType.Cylinder, color, new Vector3(0f, 5.636f, 0f), new Vector3(0, 0, 90), new Vector3(0.2f, 0.73f, 0.2f)));
            Model.AddPart(new ModelPrimitive(Model, PrimitiveType.Sphere, color, new Vector3(1.015f, 5.639f, 0f), new Vector3(0, 0, 0), new Vector3(1f, 0.18f, 1f)));
            Model.AddPart(new ModelPrimitive(Model, PrimitiveType.Sphere, new Color32(0, 0, 0, 50), new Vector3(1.032f, 5.328f, 0f), new Vector3(0, 0, 0), new Vector3(0.7f, 0.7f, 0.7f)));
            Model.AddPart(new ModelPrimitive(Model, PrimitiveType.Sphere, color, new Vector3(-1.015f, 5.639f, 0f), new Vector3(0, 0, 0), new Vector3(1f, 0.18f, 1f)));
            Model.AddPart(new ModelPrimitive(Model, PrimitiveType.Sphere, new Color32(0, 0, 0, 50), new Vector3(-1.032f, 5.328f, 0f), new Vector3(0, 0, 0), new Vector3(0.7f, 0.7f, 0.7f)));
            Model.AddPart(new ModelLight(Model, colorLight, new Vector3(1.032f, 5.328f, 0), intensive, range));
            Model.AddPart(new ModelLight(Model, colorLight, new Vector3(-1.032f, 5.328f, 0), intensive, range));
            gameObjects.Add(Model.gameObject);
        }
        public static void CreateMenu()
        {
            MenuRoom(new Vector3(-185.24f, 988f, -94.12f), new Vector3(0, 0, 0));
            Panel(new Vector3(-190.0421f, 991.25879f, -83.15673f), new Vector3(0, 0, 0));
            Projector(new Vector3(-189.697f, 989.124f, -92.944f), new Vector3(-180, -90, 168.467f));
            Table(new Vector3(-184.7177f, 988.012f, -93.02543f), new Vector3(0, 0, 0));
            Table(new Vector3(-190.3304f, 988.012f, -93.22376f), new Vector3(0, 81.31f, 0));
            Table(new Vector3(-184.7177f, 988.012f, -88.17338f), new Vector3(0, 0, 0));
        }
        public static void MenuRoom(Vector3 pos, Vector3 rot)
        {
            var Model = new Model("MenuRoom", pos, rot);
            Model.AddPart(new ModelPrimitive(Model, PrimitiveType.Quad, Color.gray, new Vector3(0f, 0f, 0f), new Vector3(90f, 90f, 0f), new Vector3(23f, 20.5f, 1f)));
            Model.AddPart(new ModelPrimitive(Model, PrimitiveType.Quad, Color.gray, new Vector3(0f, 0f, -11.3f), new Vector3(0f, 180f, 0f), new Vector3(20.9f, 20.5f, 1f)));
            Model.AddPart(new ModelPrimitive(Model, PrimitiveType.Quad, Color.gray, new Vector3(10.39f, 0f, -0.39f), new Vector3(0f, 90f, 0f), new Vector3(22.6f, 20.5f, 1f)));
            Model.AddPart(new ModelPrimitive(Model, PrimitiveType.Quad, Color.gray, new Vector3(0f, 8.32f, -0.39f), new Vector3(-90f, 0f, 0f), new Vector3(23f, 22.5f, 1f)));
            Model.AddPart(new ModelPrimitive(Model, PrimitiveType.Quad, Color.gray, new Vector3(-10.25f, 0f, -0.39f), new Vector3(0f, -90f, 0f), new Vector3(22.6f, 20.5f, 1f)));
            Model.AddPart(new ModelLight(Model, Color.white, new Vector3(0f, 8.33f, 0f), 1f, 15));
            gameObjects.Add(Model.gameObject);
        }
        public static void Projector(Vector3 pos, Vector3 rot)
        {
            var Model = new Model("Projector", pos, rot);
            Model.AddPart(new ModelPrimitive(Model, PrimitiveType.Cube, Color.gray, new Vector3(-0.029f, 0.351f, -0.156f), new Vector3(-1.217f, -90f, 0f), new Vector3(0.264f, 0.49f, 0.9f)));
            Model.AddPart(new ModelPrimitive(Model, PrimitiveType.Cube, Color.black, new Vector3(-0.352f, -0.018f, -0.16f), new Vector3(-1.217f, -90f, 0f), new Vector3(0.1f, 0.28f, 0.15f)));
            Model.AddPart(new ModelPrimitive(Model, PrimitiveType.Cylinder, Color.black, new Vector3(0.425f, 0.784f, 0.008f), new Vector3(78.467f, 90f, 90f), new Vector3(0.7f, 0.05f, 0.7f)));
            Model.AddPart(new ModelPrimitive(Model, PrimitiveType.Cylinder, Color.black, new Vector3(-0.434f, 0.855f, 0f), new Vector3(78.467f, 90f, 90f), new Vector3(0.7f, 0.05f, 0.7f)));
            Model.AddPart(new ModelPrimitive(Model, PrimitiveType.Cylinder, Color.gray, new Vector3(-0.622f, 0.378f, -0.154f), new Vector3(88.233f, -90f, 0f), new Vector3(0.15f, 0.15f, 0.15f)));
            Model.AddPart(new ModelPrimitive(Model, PrimitiveType.Cylinder, Color.gray, new Vector3(-0.809f, 0.38f, -0.157f), new Vector3(88.233f, -90f, 0f), new Vector3(0.2f, 0.11f, 0.2f)));
            Model.AddPart(new ModelPrimitive(Model, PrimitiveType.Cube, Color.black, new Vector3(0.002f, 0.838f, -0.098f), new Vector3(-5.86f, -90f, 0f), new Vector3(0.1f, 0.1f, 1f)));
            Model.AddPart(new ModelLight(Model, Color.blue, new Vector3(-0.025f, 0.344f, 0.167f), 0.3f, 3));
            gameObjects.Add(Model.gameObject);
        }
        public static void Table(Vector3 pos, Vector3 rot)
        {
            //var gray = new Color32(70, 70, 70, 255);
            var Model = new Model("Table", pos, rot);
            Model.AddPart(new ModelPrimitive(Model, PrimitiveType.Cube, Color.gray, new Vector3(-0.142106f, 1.08f, 0.0265f), new Vector3(0f, 0f, 0f), new Vector3(2.29f, 0.092f, 1.9424f)));
            Model.AddPart(new ModelPrimitive(Model, PrimitiveType.Cube, Color.black, new Vector3(0.964f, 0.524f, 0.0276f), new Vector3(0f, 0f, 90f), new Vector3(1.186f, 0.092f, 1.942f)));
            Model.AddPart(new ModelPrimitive(Model, PrimitiveType.Cube, Color.black, new Vector3(-1.238f, 0.5244f, 0.0276f), new Vector3(0f, 0f, 90f), new Vector3(1.186f, 0.092f, 1.942f)));
            Model.AddPart(new ModelPrimitive(Model, PrimitiveType.Cube, Color.gray, new Vector3(-0.129f, 1.1276f, 0.0276f), new Vector3(0f, 90f, 90f), new Vector3(1.4312f, 0.092f, 2.218f)));
            Model.AddPart(new ModelPrimitive(Model, PrimitiveType.Cube, Color.black, new Vector3(-0.1298f, 1.591f, -0.166f), new Vector3(0f, 90f, 90f), new Vector3(0.5f, 0.05f, 1f)));
            Model.AddPart(new ModelPrimitive(Model, PrimitiveType.Cube, Color.black, new Vector3(-0.1298f, 1.299f, -0.166f), new Vector3(0f, 90f, 90f), new Vector3(0.26f, 0.04f, 0.05f)));
            Model.AddPart(new ModelPrimitive(Model, PrimitiveType.Cube, Color.black, new Vector3(-0.1298f, 1.178f, -0.166f), new Vector3(0f, 90f, 90f), new Vector3(0.1f, 0.28f, 0.53f)));
            Model.AddPart(new ModelPrimitive(Model, PrimitiveType.Cube, Color.black, new Vector3(-0.096f, 1.178f, -0.618f), new Vector3(0f, 90f, 90f), new Vector3(0.05f, 0.28f, 0.89f)));
            gameObjects.Add(Model.gameObject);
        }
        public static void Panel(Vector3 pos, Vector3 rot)
        {
            var Model = new Model("Panel", pos, rot);
            Model.AddPart(new ModelPrimitive(Model, PrimitiveType.Cube, Color.black, new Vector3(0.17f, 0.22f, -0.29f), new Vector3(0f, 0f, 0f), new Vector3(6.97f, 5f, 0.48f)));
            Model.AddPart(new ModelPrimitive(Model, PrimitiveType.Quad, Color.white, new Vector3(0.16f, 0.27f, -0.54f), new Vector3(0f, 0f, 0f), new Vector3(6.68f, 4.69f, 1f)));
            gameObjects.Add(Model.gameObject);
        }
        public static void OnRoundRestarted()
        {
            foreach (GameObject gameObject in GameObjects)
            {
                GameObject.Destroy(gameObject);
            }
        }
    }
}
