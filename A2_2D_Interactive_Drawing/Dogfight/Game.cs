
using System;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Intrinsics.X86;
using System.Security.Principal;
using System.Threading;

// The namespace your code is in.
namespace MohawkGame2D;

public class Game
{
    // Game values
    Color BackgroundColor = new Color(0);
    float Score = 0;
    float Speed = 0.5f;
    float BulletSpeed = 20.0f;

    int GameState = 0;

    bool Debug = false;

    // Frame Count
    int FC = 0;

    Vector3[] BulletCoords = new Vector3[200];

    // Enemy values
    Vector4[] EnemyCoords = new Vector4[100];// Location X , Location Y , HP , Enemy Type

    int MaxEnemyTypes = 3;
    int num = 60 / 4;
    int SEOnFrame = 14;// Spawn enemy on frame

    // Player values
    Color PlayerColor = Color.Blue;

    float PlayerX = 0;
    float PlayerY = 0;
    float PlayerSize = 11;

    bool CanFire = true;

    int Lives = 3;

    int MenuHP = 10;

    float LifeTime = 0;

    // Number of times the player can fire per secent
    int FireRate = 60 / 10; // 60 is the Frame Rate.
    int FireCount = 0;

    public void Setup()
    {
        Window.SetTitle("Dogfight!");
        Window.SetSize(800, 600);

        // Caped at 60 to keep me sane
        Window.TargetFPS = 60;

        // Remove outlines
        Draw.LineColor = Color.Black;
        Draw.LineSize = 2;
    }


    void MainMenu()// Draws the Main Menu
    {
        Lives = 3;

        Console.Clear();
        Console.WriteLine($"You Survived {LifeTime} Seconds");

        PlayerX = Input.GetMouseX();
        PlayerY = Input.GetMouseY();

        Draw.FillColor = Color.White;
        Draw.Rectangle(325, 125, 150, 200);

        if (Input.IsMouseButtonDown(MouseInput.Left))
            Draw.FillColor = Color.Red;
        else
            Draw.FillColor = Color.Gray;

        Draw.Rectangle(325, 125, 75, 100);

        Draw.FillColor = Color.DarkGray;
        Draw.Capsule(new Vector2(400, 200), new Vector2(400, 230), 10);

        for (int i = 0; i < EnemyCoords.Length; i++) 
        {
            EnemyCoords[i] = new Vector4();
        }

        // Draw Target
        float TarR = 100;
        for (int i = 0; i < MenuHP; i++)
        {
            float M = ((float)MenuHP);

            float R = TarR * (M - i) / 10f;

            if (i % 2 == 0)
                Draw.FillColor = Color.Red;

            else Draw.FillColor = Color.White;

            Draw.Circle(700, 400, R);

            for (int c = 0; c < BulletCoords.Length; c++)
            {
                // Dis cal
                float DisX = BulletCoords[c].X - 700;
                float DisY = BulletCoords[c].Y - 400;

                // If DisX is nagtive
                if (DisX < 0)
                {
                    DisX = DisX * -1;
                }

                // If DisY is nagtive
                if (DisY < 0)
                {
                    DisY = DisY * -1;
                }

                float Dis = DisX + DisY;

                // Check if hitting Target
                if (Dis <= R * 2)
                {
                    MenuHP--;

                    BulletCoords[c] = new Vector3(0, 0, 0);
                }

            }

            if (MenuHP <= 0)
            {
                LifeTime = 0;
                GameState = 1;
            }
        }

        // Goes through all Bullets and Draws them
        for (int i = 0; i < BulletCoords.Length; i++)
        {
            // If Bullet is't at 0,0 
            if (BulletCoords[i] != new Vector3(0, 0, 0))
            {
                // Then Draw
                DrawBullet(i);
            }


        }

        if (CanFire)
        {
            if (Input.IsMouseButtonDown(MouseInput.Left))
            {
                SpawnBullet(PlayerX + PlayerSize + 20, PlayerY, BulletSpeed);
                CanFire = false;
                FireCount = 0;
            }
        }

        if (!CanFire)
        {
            FireCount++;
            if (FireCount >= FireRate)
            {
                CanFire = true;
                FireCount = 0;
            }
        }

        DrawPlayer(PlayerX, PlayerY);
    }

    bool CalTiggerPerSec(int Rate, int CurrentFrame)
    {
        if (Rate <= 0)
            return false;

        int FKf = 60 / Rate - 1;
        bool Can = false;

        // Goes throgh all Rate to find if FKf is even to the Current Frame.
        // If so return true.
        for (int i = 0; i < Rate; i++)
        {
            if (FKf == CurrentFrame)
            {
                Can = true;
                return true;
            }
            else
                FKf = FKf + (60 / Rate) - 1;


        }
        return false;
    }


    // Draws Player at mouse location
    void DrawPlayer(float X, float Y)
    {
        Draw.FillColor = PlayerColor;
        Draw.Circle(X, Y, PlayerSize);
    }

    void SpawnBullet(float X, float Y, float S)
    {
        // Find free Bullet Slot
        int index = Array.IndexOf(BulletCoords, new Vector3(0, 0, 0));

        if (Debug == true)
            Console.WriteLine(index);

        // If Can't find a slot
        if (index == -1)
        {
            // Take Random slot
            index = Random.Integer(0, BulletCoords.Length);
        }

        // Sets new enemy in EnemyCoords Array.
        BulletCoords[index] = new Vector3(X, Y, S);
    }

    void DrawBullet(int Bindex)
    {
        // Base Values
        float Size = 15;


        if (BulletCoords[Bindex].Z < 0)
        {// Enemy Bullet
            Draw.FillColor = Color.White;
        }

        if (BulletCoords[Bindex].Z > 0)
        {// Player Bullet
            Draw.FillColor = Color.LightGray;
        }

        // Update Location.
        BulletCoords[Bindex] = new Vector3(BulletCoords[Bindex].Z + BulletCoords[Bindex].X, BulletCoords[Bindex].Y, BulletCoords[Bindex].Z);


        // Draw Bullet
        Draw.Circle(BulletCoords[Bindex].X, BulletCoords[Bindex].Y, Size);

        // Dis cal
        float DisX = BulletCoords[Bindex].X - PlayerX;
        float DisY = BulletCoords[Bindex].Y - PlayerY;

        // If DisX is nagtive
        if (DisX < 0)
        {
            DisX = DisX * -1;
        }

        // If DisY is nagtive
        if (DisY < 0)
        {
            DisY = DisY * -1;
        }

        float Dis = DisX + DisY;


        if (BulletCoords[Bindex].Z < 0)
        {
            // Check if hitting Player
            if (Dis <= PlayerSize * 2)
            {
                // If Yes Damage Player
                Damage(true, 0);

                BulletCoords[Bindex] = new Vector3(0, 0, 0);
            }
        }


        if (BulletCoords[Bindex].Z > 0)
        {
            for (int i = 0; i < EnemyCoords.Length; i++)
            {
                DisX = BulletCoords[Bindex].X - EnemyCoords[i].X;
                DisY = BulletCoords[Bindex].Y - EnemyCoords[i].Y;
                // If DisX is nagtive
                if (DisX < 0)
                {
                    DisX = DisX * -1;
                }

                // If DisY is nagtive
                if (DisY < 0)
                {
                    DisY = DisY * -1;
                }

                Dis = DisX + DisY;

                if (Dis <= 22 * 2)
                {
                    Damage(false, i);
                    BulletCoords[Bindex] = new Vector3(0, 0, 0);
                }
            }
        }




        // Check if off Screen
        if (BulletCoords[Bindex].X < 10 || BulletCoords[Bindex].X > 820)
        {
            // If Yes Kill self
            BulletCoords[Bindex] = new Vector3(0, 0, 0);
        }
    }

    // Damageds Player or Enemy
    void Damage(bool Player, int EnemyIndex)
    {
        if (Player)
        {
            Lives--;
            if (Debug)
                Console.WriteLine("Damage " + Lives);
        }
        else
        {
            EnemyCoords[EnemyIndex] = new Vector4(EnemyCoords[EnemyIndex].X, EnemyCoords[EnemyIndex].Y, EnemyCoords[EnemyIndex].Z - 1, EnemyCoords[EnemyIndex].W);
        }
    }


    // Spawn new Enemy
    void SpawnEnemy(bool random, int EnemyType)
    {
        // Find free Enemy Slot
        int index = Array.IndexOf(EnemyCoords, new Vector4(0, 0, 0, 0));

        if (Debug == true)
            Console.WriteLine(index);

        // If Can't find a slot
        if (index == -1)
        {
            // Take Random slot
            index = Random.Integer(0, EnemyCoords.Length);
        }

        // Sets new enemy in EnemyCoords Array.
        if (random == true)
            EnemyCoords[index] = new Vector4(810, Random.Float(0, 600), 99, Random.Integer(0, MaxEnemyTypes));
        else
            EnemyCoords[index] = new Vector4(810, Random.Float(0, 600), 99, EnemyType);
    }

    // Draws Enemy at Location
    void DrawEnemy(int ArrayIndex)
    {
        int EnemyType = ((int)EnemyCoords[ArrayIndex].W);

        if (EnemyCoords[ArrayIndex].Z <= 0)
        {
            Score = Score + 100;
            EnemyCoords[ArrayIndex] = new Vector4(0, 0, 0, 0);
            return;
        }

        if (EnemyType == 0)// Base Enemy that only moves stright. Copy and Paste to make a new enemy.
        {
            // Base Values
            int HP = 3;
            float Size = 22;
            float EnemySpeed = 10.0f;

            //If the enemy has more health then HP
            if (EnemyCoords[ArrayIndex].Z > HP)
                // Then clamp it to HP
                EnemyCoords[ArrayIndex] = new Vector4(EnemyCoords[ArrayIndex].X, EnemyCoords[ArrayIndex].Y, HP, EnemyCoords[ArrayIndex].W);


            // Update location
            EnemyCoords[ArrayIndex] = new Vector4(EnemyCoords[ArrayIndex].X - EnemySpeed * Speed, EnemyCoords[ArrayIndex].Y, EnemyCoords[ArrayIndex].Z, EnemyCoords[ArrayIndex].W);

            // Draw Color and Enemy
            Draw.FillColor = Color.Red;
            Draw.Circle(EnemyCoords[ArrayIndex].X, EnemyCoords[ArrayIndex].Y, Size);

            // Dis cal
            float DisX = EnemyCoords[ArrayIndex].X - PlayerX;
            float DisY = EnemyCoords[ArrayIndex].Y - PlayerY;

            // If DisX is nagtive
            if (DisX < 0)
            {
                DisX = DisX * -1;
            }

            // If DisY is nagtive
            if (DisY < 0)
            {
                DisY = DisY * -1;
            }

            float Dis = DisX + DisY;

            if (Dis <= Size * 2)
            {
                // If Yes Damage Player
                Damage(true, 0);
                EnemyCoords[ArrayIndex] = new Vector4(0, 0, 0, 0);
            }

            // Check if off Screen
            if (EnemyCoords[ArrayIndex].X < 10)
            {
                // If Yes Kill self
                EnemyCoords[ArrayIndex] = new Vector4(0, 0, 0, 0);
            }

            if (Debug)
                Console.WriteLine(Dis + $"= {DisX} + {DisY}");
            return;
        }

        else if (EnemyType == 1)// Enemy that moves stright on X and torword the play on Y.
        {
            // Base Values
            int HP = 1;
            float Size = 22;
            float EnemySpeed = 18.0f;

            //If the enemy has more health then HP
            if (EnemyCoords[ArrayIndex].Z > HP)
                // Then clamp it to HP
                EnemyCoords[ArrayIndex] = new Vector4(EnemyCoords[ArrayIndex].X, EnemyCoords[ArrayIndex].Y, HP, EnemyCoords[ArrayIndex].W);

            // Draw Color and Enemy
            Draw.FillColor = Color.Yellow;
            Draw.Circle(EnemyCoords[ArrayIndex].X, EnemyCoords[ArrayIndex].Y, Size);

            // Dis cal
            float DisX = EnemyCoords[ArrayIndex].X - PlayerX;
            float DisY = EnemyCoords[ArrayIndex].Y - PlayerY;
            // Dir Y
            int DirY = 1;

            if (DisY < 0) DirY = -1;

            if (DisY > 1) DirY = 1;

            if (DisY > -1 & DisY < 1) DirY = 0;

            // Dir X
            int DirX = 1;

            if (DisX < 0) DirX = -1;

            if (DisX > 1) DirX = 1;

            if (DisX > -1 & DisX < 1) DirX = 0;

            // Update location
            EnemyCoords[ArrayIndex] = new Vector4(EnemyCoords[ArrayIndex].X - (EnemySpeed * Speed), EnemyCoords[ArrayIndex].Y - (EnemySpeed * Speed * DirY), EnemyCoords[ArrayIndex].Z, EnemyCoords[ArrayIndex].W);


            // If DisX is nagtive
            if (DisX < 0)
            {
                DisX = DisX * -1;
            }

            // If DisY is nagtive
            if (DisY < 0)
            {
                DisY = DisY * -1;
            }

            float Dis = DisX + DisY;

            if (Dis <= Size * 2)
            {
                // If Yes Damage Player
                Damage(true, 0);
                EnemyCoords[ArrayIndex] = new Vector4(0, 0, 0, 0);
            }

            // Check if off Screen
            if (EnemyCoords[ArrayIndex].X < 10)
            {
                // If Yes Kill self
                EnemyCoords[ArrayIndex] = new Vector4(0, 0, 0, 0);
            }

            if (Debug)
                Console.WriteLine(Dis + $"= {DisX} + {DisY}");
            return;
        }

        if (EnemyType == 2)// Enemy that moves up or down and shoots at the player. Copy and Paste to make a new enemy.
        {
            // Base Values
            int HP = 2;
            float Size = 22;
            float EnemySpeed = 2.0f;

            //If the enemy has more health then HP
            if (EnemyCoords[ArrayIndex].Z > HP)
                // Then clamp it to HP
                EnemyCoords[ArrayIndex] = new Vector4(EnemyCoords[ArrayIndex].X, EnemyCoords[ArrayIndex].Y, HP, EnemyCoords[ArrayIndex].W);

            // Draw Color and Enemy
            Draw.FillColor = Color.Cyan;
            Draw.Circle(EnemyCoords[ArrayIndex].X, EnemyCoords[ArrayIndex].Y, Size);

            int g = 0;//Random.Integer(0,EnemySpots.Length);

            // Dis cal
            float DisX = EnemyCoords[ArrayIndex].X - PlayerX;
            float DisY = EnemyCoords[ArrayIndex].Y - PlayerY;

            // Dir Y
            int DirY = 1;

            if (DisY < 0) DirY = -1;

            if (DisY > 1) DirY = 1;

            if (DisY > -1 & DisY < 1) DirY = 0;

            // Update location
            EnemyCoords[ArrayIndex] = new Vector4(EnemyCoords[ArrayIndex].X - (EnemySpeed * Speed * 2), EnemyCoords[ArrayIndex].Y - (EnemySpeed * Speed * DirY), EnemyCoords[ArrayIndex].Z, EnemyCoords[ArrayIndex].W);

            if (CalTiggerPerSec(1, FC))
            {
                SpawnBullet(EnemyCoords[ArrayIndex].X - (Size + 22), EnemyCoords[ArrayIndex].Y, -9);
            }

            // If DisX is nagtive
            if (DisX < 0)
            {
                DisX = DisX * -1;
            }

            // If DisY is nagtive
            if (DisY < 0)
            {
                DisY = DisY * -1;
            }

            float Dis = DisX + DisY;

            // Check if hitting Player
            if (Dis <= Size * 2)
            {
                // If Yes Damage Player
                Damage(true, 0);
                EnemyCoords[ArrayIndex] = new Vector4(0, 0, 0, 0);
            }
            // Check if off Screen
            if (EnemyCoords[ArrayIndex].X < 10)
            {
                // If Yes Kill self
                EnemyCoords[ArrayIndex] = new Vector4(0, 0, 0, 0);
            }

            if (Debug)
                Console.WriteLine(Dis + $"= {DisX} + {DisY}");
            return;
        }

        return;
    }

    // Update Game
    public void Update()
    {
        // Reset screen
        Window.ClearBackground(BackgroundColor);

        if (Lives <= 0)
        {
            MenuHP = 10;
            GameState = 0;
        }

        if (GameState == 0)
        {
            MainMenu();
        }

        else if (GameState == 1) // Main Game
        {
            // Draw Player at mouse position
            PlayerX = Input.GetMouseX();
            PlayerY = Input.GetMouseY();

            DrawPlayer(PlayerX, PlayerY);



            if (CanFire)
            {
                if (Input.IsMouseButtonDown(MouseInput.Left))
                {
                    SpawnBullet(PlayerX + PlayerSize + 20, PlayerY, BulletSpeed);
                    CanFire = false;
                    FireCount = 0;
                }
            }

            if (!CanFire)
            {
                FireCount++;
                if (FireCount >= FireRate)
                {
                    CanFire = true;
                    FireCount = 0;
                }
            }

            // Evey set number of frames spawn a enemy.
            int CC = ((int)LifeTime / 5);

            if (CalTiggerPerSec( CC , FC))
            {
                // Spawns a random enemy.
                SpawnEnemy(true, 0);
            }

            // Goes through all Bullets and Draws them
            for (int i = 0; i < BulletCoords.Length; i++)
            {
                // If Bullet is't at 0,0 
                if (BulletCoords[i] != new Vector3(0, 0, 0))
                {
                    // Then Draw
                    DrawBullet(i);
                }
            }

            // Goes through all enemys and Draws them
            for (int i = 0; i < EnemyCoords.Length; i++)
            {
                // If enemy is't at 0,0 
                if (EnemyCoords[i] != new Vector4(0, 0, 0, 0))
                {
                    // Then Draw
                    DrawEnemy(i);
                }
            }

            // Draw Player Lives
            for (int i = 0; i < Lives; i++)
            {
                Draw.FillColor = PlayerColor;
                if (i == 0)
                    Draw.Circle(10, 10, PlayerSize);

                Draw.Circle(30 * i, 10, PlayerSize);

            }
            Console.Clear();
            Console.WriteLine($"Current Time {LifeTime}");

        }

        // Frame Counter. Used for timed events.
        FC++;
        if (FC >= 60)
        {
            FC = 0;
            if (GameState == 1)
                LifeTime++;

        }

        
    }
}
