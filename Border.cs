using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Snake_BLUB
{
    class Border
    {
        public Border(int x, int y)
        {
            Image border = new Image();
            border.Source = new BitmapImage(new Uri(@"C:\Users\Stefan\Desktop\3ahit_BLUB_projekt\Bilder_Blub\Schlange_Prototyp2.0.png"));
        }
    }
}
