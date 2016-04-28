using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Snake_BLUB
{
   
    public partial class MainWindow : Window
    {
         
        int rows = 18;
        int coloumns = 32;
        Image snake = new Image();
        DispatcherTimer snake_timer = new DispatcherTimer();
        Random random_position = new Random();
        int richtung = 0;
        
        public MainWindow()
        {            
            InitializeComponent();
            
            snake_timer.Interval = new TimeSpan(0, 0, 0, 0, 10);
            snake_timer.Tick += new EventHandler(snake_time);
           
            CreateGrid(rows,coloumns);
                                  
            snake.Source = new BitmapImage(new Uri(@"C:\Users\Stefan\Desktop\3ahit_BLUB_projekt\Bilder_Blub\Snake_Prototyp2.0.png"));
            ChangePosition(snake,random_position.Next(1,30), random_position.Next(1, 16));
            grid.Children.Add(snake);
            int[,] border;
                                
                    
            border = new int[18,32]
            {
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {1,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,1},
                {1,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,1},
                {1,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,1},
                {1,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,1},
                {1,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,1},
                {1,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,1},
                {1,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,1},
                {1,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,1},
                {1,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,1},
                {1,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,1},
                {1,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,1},
                {1,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,1},
                {1,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,1},
                {1,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,1},
                {1,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,1},
                {1,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,1},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0}
            };
           
            for (int y = 0; y < border.GetLength(0); y++)
            {
                for (int x = 0; x < border.GetLength(1); x++)
                {
                    if (border[y, x] == 0)
                    {
                        Border b = new Border(0,0);
                        Image border1 = new Image();
                        border1.Source = new BitmapImage(new Uri(@"C:\Users\Stefan\Desktop\3ahit_BLUB_projekt\Bilder_Blub\Wand_Unten_Oben.png"));
        
                        grid.Children.Add(border1);
                        Grid.SetRow(border1, y);
                        Grid.SetColumn(border1, x);
                    }
                    
                      
                }
                
            }
            for (int y = 0; y < border.GetLength(0); y++)
            {
                for (int x = 0; x < border.GetLength(1); x++)
                {
                    if (border[y, x] == 1)
                    {
                        Border b = new Border(0, 0);
                        Image border2 = new Image();
                        border2.Source = new BitmapImage(new Uri(@"C:\Users\Stefan\Desktop\3ahit_BLUB_projekt\Bilder_Blub\Wand_seite.png"));

                        grid.Children.Add(border2);
                        Grid.SetRow(border2, y);
                        Grid.SetColumn(border2, x);
                    }
                    
                }
                
            }

        }

        private void snake_time(object sender, EventArgs e)
        {

             if (richtung==0)
            {

                ChangePosition(snake, Grid.GetColumn(snake), Grid.GetRow(snake) - 1);
               
                snake.Source = new BitmapImage(new Uri(@"C:\Users\Stefan\Desktop\3ahit_BLUB_projekt\Bilder_Blub\Snake_prototyp_kopf_oben2.0.png"));
            }

            else if (richtung==2)
            {
                ChangePosition(snake, Grid.GetColumn(snake), Grid.GetRow(snake) + 1);
               
                snake.Source = new BitmapImage(new Uri(@"C:\Users\Stefan\Desktop\3ahit_BLUB_projekt\Bilder_Blub\Snake_prototyp_kopf_unten2.0.png"));
            }

            else if (richtung==3)
            {
                ChangePosition(snake, Grid.GetColumn(snake) - 1, Grid.GetRow(snake));
           
                snake.Source = new BitmapImage(new Uri(@"C:\Users\Stefan\Desktop\3ahit_BLUB_projekt\Bilder_Blub\Snake_prototyp2.0.png"));
            }

            else if (richtung==1)
            {
                ChangePosition(snake, Grid.GetColumn(snake) + 1, Grid.GetRow(snake));
                
                snake.Source = new BitmapImage(new Uri(@"C:\Users\Stefan\Desktop\3ahit_BLUB_projekt\Bilder_Blub\Snake_prototyp_kopf_rechts2.0.png"));
            }
        }

        public void CreateGrid(int rows, int columns)
        {
            GridLength Breite = new GridLength(50);
            for (int rowcount = 0; rowcount < rows; rowcount ++)
            {
                var rowDefinition = new RowDefinition();
                rowDefinition.Height = Breite;          
                grid.RowDefinitions.Add(rowDefinition);
            }

            for (int  columncount= 0;  columncount < columns; columncount ++)
            {                
                var columnDefinition = new ColumnDefinition();
                columnDefinition.Width = Breite;
                grid.ColumnDefinitions.Add(columnDefinition);
            }
        }

        public void ChangePosition(Image Bild,int x, int y)
        {
          //int newx = Math.Max(Math.Min(x,coloumns-2), 1);
          //int newy = Math.Max(Math.Min(y, rows - 2), 1);
            Grid.SetColumn(Bild,x);
            Grid.SetRow(Bild,y);
            if (y <= 0 || y >=17 ||x <=0 || x>=31 )
            {
                MessageBox.Show("Game Over.");
                ChangePosition(snake, random_position.Next(1, 30), random_position.Next(1, 16));
                snake_timer.Stop();
            }
 

        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            
        if (Keyboard.IsKeyDown(Key.Up))
            {
                richtung = 0;
                snake_timer.Start();
            }

               else if (Keyboard.IsKeyDown(Key.Down))
            {
                richtung = 2;
                snake_timer.Start();
            }

            else if (Keyboard.IsKeyDown(Key.Left))
            {
                richtung = 3;
                snake_timer.Start();
            }

            else if (Keyboard.IsKeyDown(Key.Right))
            {
                richtung = 1;
                snake_timer.Start();
            }
      }
    }
}
