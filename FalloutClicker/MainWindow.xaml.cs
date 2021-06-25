using System;
using System.IO;
using System.Windows;

namespace FalloutClicker
{
    public partial class MainWindow : Window
    {

        public static bool clicked;
        player player = new player();
        objekt objekt1 = new objekt(0, 1, 100, "Plasma Gun");
        objekt objekt2 = new objekt(0, 40, 2000, "Partner");
        objekt objekt3 = new objekt(0, 600, 30000, "Mercenary");
        objekt objekt4 = new objekt(0, 8000, 400000, "BOOOOOOOMB");
        Achievements achievements = new Achievements();
        

        public MainWindow()
        {
            InitializeComponent();
            enablecheck();
            objekt1_Name.Content = objekt1.Name;
            objekt2_Name.Content = objekt2.Name;
            objekt3_Name.Content = objekt3.Name;
            objekt4_Name.Content = objekt4.Name;
            
            designupdate();
            var dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer.Tick += Tick;
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            dispatcherTimer.Start();

        } 

        private void click_Click(object sender, RoutedEventArgs e)
        {
            help.Visibility = System.Windows.Visibility.Collapsed;
            help2.Visibility = System.Windows.Visibility.Collapsed;
            help3.Visibility = System.Windows.Visibility.Collapsed;
            player.addcliks(upgradeslist.upgradadditionalcpc);     
            designupdate();
        } 
        void designupdate()
        {   
           x.Content = string.Format("Количество крышек: {0}", player.Cliks.ToString());
           y.Content = string.Format("{0} крышек в секунду", player.Clikspersecound.ToString());   
        }

       private void Tick(object sender, EventArgs e)
       {
           for (int x = 1; x <= 30; x++)
           {
               enablecheck();
               designupdate();
           }
           player.addcliks(player.Clikspersecound);
       }

       private void o1_1_Click(object sender, RoutedEventArgs e)
       {
           objekt1.add(player, 1);  
            designupdate();
       }

       private void o1_10_Click(object sender, RoutedEventArgs e)
       {
           objekt1.add(player, 10);
           designupdate();
       }

       private void o1_100_Click(object sender, RoutedEventArgs e)
       {
           objekt1.add(player, 100);
           designupdate();
       }
       private void o2_1_Click(object senderm, RoutedEventArgs e)
       {
           objekt2.add(player, 1);
           designupdate();
       }

       private void save_Click(object sender, RoutedEventArgs e)
       {
           var path = Environment.CurrentDirectory + "/save.txt";
            if (File.Exists(path))
           {
               File.Delete(path);
           }
           var s = "/";
            using (var file = new StreamWriter(path))
            {
                var _control = (Math.Round(player.Cliks + objekt1.Amount + objekt2.Amount + objekt3.Amount + objekt4.Amount, 0) * 3) + 7;
                file.WriteLine(player.Cliks + s + objekt1.Amount + s + objekt2.Amount + s + objekt3.Amount + s + objekt4.Amount + s + _control + s + upgradeslist.Upgradelist[0].IsActive + s + upgradeslist.Upgradelist[1].IsActive + s + upgradeslist.Upgradelist[2].IsActive + s + upgradeslist.Upgradelist[3].IsActive + s + upgradeslist.Upgradelist[4].IsActive + s + upgradeslist.Upgradelist[5].IsActive + s + upgradeslist.Upgradelist[6].IsActive + s + upgradeslist.Upgradelist[7].IsActive);
                file.Close();
            }
        }
       private void load_Click(object sender, RoutedEventArgs e)
       {
           try
           {
               var path = Environment.CurrentDirectory + "/save.txt";
                using (var file = new StreamReader(path))
                {
                    var load = file.ReadLine().Split('/');
                    var _control = ((Math.Round(Convert.ToDouble(load[0]) + Convert.ToDouble(load[1]) + Convert.ToDouble(load[2]) + Convert.ToDouble(load[3]) + Convert.ToDouble(load[4]), 0) * 3) + 7);
                    if (Convert.ToInt16(load[5]) == _control)
                    {
                        player.setCliks(Convert.ToDouble(load[0]));
                        objekt1.setAmount(player, Convert.ToInt16(load[1]));
                        objekt2.setAmount(player, Convert.ToInt16(load[2]));
                        objekt3.setAmount(player, Convert.ToInt16(load[3]));
                        objekt4.setAmount(player, Convert.ToInt16(load[4]));
                        if (load[6] == "1")
                        {
                            upgradeslist.Upgradelist[0].setActive();
                            u1_1_cliked = true;
                        }
                        if (load[7] == "1")
                        {
                            upgradeslist.Upgradelist[1].setActive();
                            u1_2_cliked = true;
                        }
                        if (load[8] == "1")
                        {
                            upgradeslist.Upgradelist[2].setActive();
                            u1_3_cliked = true;
                        }
                        if (load[9] == "1")
                        {
                            upgradeslist.Upgradelist[3].setActive();
                            u1_4_cliked = true;
                        }
                        if (load[10] == "1")
                        {
                            upgradeslist.Upgradelist[4].setActive();
                            u2_1_cliked = true;
                        }
                        if (load[11] == "1")
                        {
                            upgradeslist.Upgradelist[5].setActive();
                            u2_2_cliked = true;
                        }
                        if (load[12] == "1")
                        {
                            upgradeslist.Upgradelist[6].setActive();
                            u2_3_cliked = true;
                        }
                        if (load[13] == "1")
                        {
                            upgradeslist.Upgradelist[7].setActive();
                            u2_4_cliked = true;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Фаил повржден и будет удален");
                        File.Delete(path);
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка чтения");
            }
        }

       private void o2_10_Click(object sender, RoutedEventArgs e)
       {
           objekt2.add(player, 10);
           designupdate();
       }

       private void o2_100_Click(object sender, RoutedEventArgs e)
       {
           objekt2.add(player, 100);
           designupdate();
       }

       private void o3_1_Click(object sender, RoutedEventArgs e)
       {
           objekt3.add(player, 1);
           designupdate();
       }

       private void o3_10_Click(object sender, RoutedEventArgs e)
       {
           objekt3.add(player, 10);
           designupdate();
       }

       private void o3_100_Click(object sender, RoutedEventArgs e)
       {
           objekt3.add(player, 100);
           designupdate();
       }

       private void o4_1_Click(object sender, RoutedEventArgs e)
       {
           objekt4.add(player, 1);
           designupdate();
       }

       private void o4_10_Click(object sender, RoutedEventArgs e)
       {
           objekt4.add(player, 10);
           designupdate();
       }

       private void o4_100_Click(object sender, RoutedEventArgs e)
       {
           objekt4.add(player, 100);
           designupdate();
       }

       bool u1_1_cliked;
       bool u1_2_cliked;
       bool u1_3_cliked;
       bool u1_4_cliked;
       bool u2_1_cliked;
       bool u2_2_cliked;
       bool u2_3_cliked;
       bool u2_4_cliked;

        void enablecheck() 
       {
           o1_1.ToolTip = objekt1.dprice(1);
           o1_10.ToolTip = objekt1.dprice(10);
           o1_100.ToolTip = objekt1.dprice(100);
           o2_1.ToolTip = objekt2.dprice(1);
           o2_10.ToolTip = objekt2.dprice(10);
           o2_100.ToolTip = objekt2.dprice(100);
           o3_1.ToolTip = objekt3.dprice(1);
           o3_10.ToolTip = objekt3.dprice(10);
           o3_100.ToolTip = objekt3.dprice(100);
           o4_1.ToolTip = objekt4.dprice(1);
           o4_10.ToolTip = objekt4.dprice(10);
           o4_100.ToolTip = objekt4.dprice(100);
           u1_1.ToolTip = string.Format("Цена: {0} крышек", upgradeslist.Upgradelist[0].cost);
           u1_2.ToolTip = string.Format("Цена: {0} крышек", upgradeslist.Upgradelist[1].cost);
           u1_3.ToolTip = string.Format("Цена: {0} крышек", upgradeslist.Upgradelist[2].cost);
           u1_4.ToolTip = string.Format("Цена: {0} крышек", upgradeslist.Upgradelist[3].cost);
           u2_1.ToolTip = string.Format("Цена: {0} крышек", upgradeslist.Upgradelist[4].cost);
           u2_2.ToolTip = string.Format("Цена: {0} крышек", upgradeslist.Upgradelist[5].cost);
           u2_3.ToolTip = string.Format("Цена: {0} крышек", upgradeslist.Upgradelist[6].cost);
           u2_4.ToolTip = string.Format("Цена: {0} крышек", upgradeslist.Upgradelist[7].cost);
           if (player.Cliks < upgradeslist.Upgradelist[0].cost || u1_1_cliked == true)
           {
               u1_1.IsEnabled = false;
           }
           else { u1_1.IsEnabled = true; }
           if (player.Cliks < upgradeslist.Upgradelist[1].cost || u1_2_cliked == true)
           {
               u1_2.IsEnabled = false;
           }
           else { u1_2.IsEnabled = true; }
           if (player.Cliks < upgradeslist.Upgradelist[2].cost || u1_3_cliked == true)
           {
               u1_3.IsEnabled = false;
           }
           else { u1_3.IsEnabled = true; }
           if (player.Cliks < upgradeslist.Upgradelist[3].cost || u1_4_cliked == true)
           {
               u1_4.IsEnabled = false;
           }
           else { u1_4.IsEnabled = true; }
           if (player.Cliks < upgradeslist.Upgradelist[4].cost || u2_1_cliked == true)
           {
               u2_1.IsEnabled = false;
           }
           else { u2_1.IsEnabled = true; }
           if (player.Cliks < upgradeslist.Upgradelist[5].cost || u2_2_cliked == true)
           {
               u2_2.IsEnabled = false;
           }
           else { u2_2.IsEnabled = true; }
           if (player.Cliks < upgradeslist.Upgradelist[6].cost || u2_3_cliked == true)
           {
               u2_3.IsEnabled = false;
           }
           else { u2_3.IsEnabled = true; }
           if (player.Cliks < upgradeslist.Upgradelist[7].cost || u2_4_cliked == true)
           {
               u2_4.IsEnabled = false;
           }
           else { u2_4.IsEnabled = true; }
           if(player.Cliks < objekt1.Dprice(1)){
               o1_1.IsEnabled = false;
           }
           else { o1_1.IsEnabled = true; }
           if (player.Cliks < objekt1.Dprice(10))
           {
               o1_10.IsEnabled = false;
           }
           else { o1_10.IsEnabled = true; }
           if (player.Cliks < objekt1.Dprice(100))
           {
               o1_100.IsEnabled = false;
           }
           else { o1_100.IsEnabled = true; }
           if (player.Cliks < objekt2.Dprice(1))
           {
               o2_1.IsEnabled = false;
           }
           else { o2_1.IsEnabled = true; }
           if (player.Cliks < objekt2.Dprice(10))
           {
               o2_10.IsEnabled = false;
           }
           else { o2_10.IsEnabled = true; }
           if (player.Cliks < objekt2.Dprice(100))
           {
               o2_100.IsEnabled = false;
           }
           else { o2_100.IsEnabled = true; }
           if (player.Cliks < objekt3.Dprice(1))
           {
               o3_1.IsEnabled = false;
           }
           else { o3_1.IsEnabled = true; }
           if (player.Cliks < objekt3.Dprice(10))
           {
               o3_10.IsEnabled = false;
           }
           else { o3_10.IsEnabled = true; }
           if (player.Cliks < objekt3.Dprice(100))
           {
               o3_100.IsEnabled = false;
           }
           else { o2_100.IsEnabled = true; }
           if (player.Cliks < objekt4.Dprice(1))
           {
               o4_1.IsEnabled = false;
           }
           else { o4_1.IsEnabled = true; }
           if (player.Cliks < objekt4.Dprice(10))
           {
               o4_10.IsEnabled = false;
           }
           else { o4_10.IsEnabled = true; }
           if (player.Cliks < objekt4.Dprice(100))
           {
               o4_100.IsEnabled = false;
           }
           else { o4_100.IsEnabled = true; }
       }

       private void u1_1_Click(object sender, RoutedEventArgs e)
       {
           upgradeslist.Upgradelist[0].setActive();
           u1_1_cliked = true;
           player.pay(upgradeslist.Upgradelist[0].cost);
       }

       private void u1_2_Click(object sender, RoutedEventArgs e)
       {
           upgradeslist.Upgradelist[1].setActive();
           u1_2_cliked = true;
           player.pay(upgradeslist.Upgradelist[1].cost);
       }

       private void u1_3_Click(object sender, RoutedEventArgs e)
       {
           upgradeslist.Upgradelist[2].setActive();
           u1_3_cliked = true;
           player.pay(upgradeslist.Upgradelist[2].cost);
       }

       private void u1_4_Click(object sender, RoutedEventArgs e)
       {
           upgradeslist.Upgradelist[3].setActive();
           u1_4_cliked = true;
           player.pay(upgradeslist.Upgradelist[3].cost);
       }

       private void u2_1_Click(object sender, RoutedEventArgs e)
       {
           upgradeslist.Upgradelist[4].setActive();
           u2_1_cliked = true;
           player.pay(upgradeslist.Upgradelist[4].cost);
       }
       private void u2_2_Click(object sender, RoutedEventArgs e)
       {
           upgradeslist.Upgradelist[5].setActive();
           u2_2_cliked = true;
           player.pay(upgradeslist.Upgradelist[5].cost);
       }

       private void u2_3_Click(object sender, RoutedEventArgs e)
       {
           upgradeslist.Upgradelist[6].setActive();
           u2_3_cliked = true;
           player.pay(upgradeslist.Upgradelist[6].cost);
       }

       private void u2_4_Click(object sender, RoutedEventArgs e)
       {
           upgradeslist.Upgradelist[7].setActive();
           u2_4_cliked = true;
           player.pay(upgradeslist.Upgradelist[7].cost);
       }

        private void Achievements_Click(object sender, RoutedEventArgs e)
        {
            var achievements = new Achievements();
            achievements.Show();
        }
    }
}
