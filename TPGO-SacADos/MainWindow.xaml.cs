using MahApps.Metro.Controls;
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
using TPGO_SacADos.Classes;
using System.Media;
using MaterialDesignColors;
using MaterialDesignThemes;
namespace TPGO_SacADos
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        Case[,] matrice;
        public int poids =0;
        string[] nameObject = { "Pen", "Notebook", "Book", "Food", "Cloths", "Shoes", "Box" };      
        List<ObjetSac> objectList = new List<ObjetSac>();
        List<ObjetSac> resultList = new List<ObjetSac>();
        HashSet<int> result;
        
        int valeurMax =0;
      

        public MainWindow()
        {
            InitializeComponent();
        }

        private void homeBnt_Click(object sender, RoutedEventArgs e)
        {
            
            Configuration.buttonClicked(homeBnt);
            tabControl.SelectedIndex = 0;
            header.Text = "Home";
        }

        private void bt1_Click(object sender, RoutedEventArgs e)
        {
            Configuration.buttonClicked(bt1);
            tabControl.SelectedIndex = 1;
            header.Text = "Initialization";
        }

        private void bt2_Click(object sender, RoutedEventArgs e)
        {
            Configuration.buttonClicked(bt2);
            tabControl.SelectedIndex = 2;
            header.Text = "Show Object List";
            if (poids ==0)
            {
                weightShow.Content = 0;
            }
            else
            {
                weightShow.Content = poids - 1;
            }

            if (objectList.Count == 0)
            {
                dataLabel.IsEnabled = true;
                dataLabel.Content = "There is no object to show, Please initialize your object list";
            }
            else
            {

                try
                {
                    dataLabel.IsEnabled = false;
                    dataLabel.Content = "";
                    dataPrint.ItemsSource = objectList;
                    dataPrint.Items.Refresh();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            
        }

        private void bt3_Click(object sender, RoutedEventArgs e)
        {
            Configuration.buttonClicked(bt3);
            tabControl.SelectedIndex = 3;
            header.Text = "Execute Algorithm";
            try
            {
                resultGrid.ItemsSource = null;
                resultGrid.Items.Refresh();
                resultatF.Text = "Max = 0";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            
        }



        private void bt1_MouseEnter(object sender, MouseEventArgs e)
        {
            bt1.Background = new SolidColorBrush(Color.FromArgb(255, 132, 96, 196));
            bt1.BorderBrush = new SolidColorBrush(Color.FromArgb(255, 132, 96, 196));
        }

        private void bt1_MouseLeave(object sender, MouseEventArgs e)
        {
            bt1.Background = new SolidColorBrush(Color.FromArgb(255, 40, 39, 43));
            bt1.BorderBrush = new SolidColorBrush(Color.FromArgb(255, 40, 39, 43));
        }



        private void bt2_MouseEnter(object sender, MouseEventArgs e)
        {
            bt2.Background = new SolidColorBrush(Color.FromArgb(255, 132, 96, 196));
            bt2.BorderBrush = new SolidColorBrush(Color.FromArgb(255, 132, 96, 196));

        }

        private void bt2_MouseLeave(object sender, MouseEventArgs e)
        {
            bt2.Background = new SolidColorBrush(Color.FromArgb(255, 40, 39, 43));
            bt2.BorderBrush = new SolidColorBrush(Color.FromArgb(255, 40, 39, 43));
        }



        private void bt3_MouseEnter(object sender, MouseEventArgs e)
        {
            bt3.Background = new SolidColorBrush(Color.FromArgb(255, 132, 96, 196));
            bt3.BorderBrush = new SolidColorBrush(Color.FromArgb(255, 132, 96, 196));

        }

        private void bt3_MouseLeave(object sender, MouseEventArgs e)
        {
            bt3.Background = new SolidColorBrush(Color.FromArgb(255, 40, 39, 43));
            bt3.BorderBrush = new SolidColorBrush(Color.FromArgb(255, 40, 39, 43));
        }

        private void homeBnt_MouseEnter(object sender, MouseEventArgs e)
        {
            homeBnt.Background = new SolidColorBrush(Color.FromArgb(255, 132, 96, 196));
            homeBnt.BorderBrush = new SolidColorBrush(Color.FromArgb(255, 132, 96, 196));

        }

        private void homeBnt_MouseLeave(object sender, MouseEventArgs e)
        {
            homeBnt.Background = new SolidColorBrush(Color.FromArgb(255, 40, 39, 43));
            homeBnt.BorderBrush = new SolidColorBrush(Color.FromArgb(255, 132, 96, 196));
        }

        private void weight_GotFocus(object sender, RoutedEventArgs e)
        {
            weight.Text = "";
            weight.Opacity = 1;
        }

        private void submit_Click(object sender, RoutedEventArgs e)
        {
            if (!weight.Text.Equals(""))
            {
                try
                {
                    this.poids = Convert.ToInt32(weight.Text) + 1;
                    submit.IsEnabled = false;
                    objectList.Add(new ObjetSac("", 0, 0));
                    addBnt.IsEnabled = true;
                }
                catch
                {
                    MessageBox.Show("Please inter an integer value");
                }
                
            }
            else
            {
                MessageBox.Show("Empty Field");
            }
          
        }

        private void combObjects_Loaded(object sender, RoutedEventArgs e)
        {
            if (combObjects.Items.Count==0)
            {
                foreach (string objet in nameObject)
                {
                    combObjects.Items.Add(objet);
                }
            }
        }

        private void weightObject_GotFocus(object sender, RoutedEventArgs e)
        {
            weightObject.Text = "";
            weightObject.Opacity = 1;
        }

        private void value_GotFocus(object sender, RoutedEventArgs e)
        {
            value.Text = "";
            value.Opacity = 1;
        }

        private void addBnt_Click(object sender, RoutedEventArgs e)
        {
            if(!combObjects.Text.Equals(""))
            {
                if (!weightObject.Text.Equals(""))
                {
                    if (!value.Text.Equals(""))
                    {
                        try
                        {
                            int val,wei;
                            val =Convert.ToInt32(value.Text);
                            wei=Convert.ToInt32(weightObject.Text);
                            ObjetSac obj =new ObjetSac(combObjects.SelectedItem.ToString(),wei,val);
                            objectList.Add(obj);
                            value.Text = "";
                            weightObject.Text = "";                       
                            
                        }
                        catch
                        {
                            MessageBox.Show("Please verify that your entered an integer value for the weight and the value");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please enter the value of the object");
                    }
                }
                else
                {
                    MessageBox.Show("Please enter the weight of the object");
                }

            }
            else
            {
                MessageBox.Show("Please select an object");
            }

        }

        

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            objectList.Clear();
            dataPrint.ItemsSource = objectList;
            dataPrint.Items.Refresh();
            submit.IsEnabled =true;
            addBnt.IsEnabled = false;
            dataLabel.Content = "There is no object to show, Please initialize your object list";
            this.poids = 0;
            weightShow.Content = 0;
        }


        public  void initZero()
        {
            matrice = new Case[this.objectList.Count, poids];
            for (int i = 0; i < poids; i++)
            {
                this.matrice[0, i] = new Case();
                this.matrice[0, i].setValue(0);
                this.matrice[0, i].addObject(0);
            }
        }



        public HashSet<int> sacAdosMatrix()
        {
            initZero();
            for (int i = 1; i < this.objectList.Count; i++)
            {
                for (int j = 0; j < poids; j++)
                {
                    this.matrice[i, j] = new Case();
                    if (j >= this.objectList[i].getWeight())
                    {
                        // this.matrice[i, j].setValue( max(this.matrice[i - 1, j].getValue(), this.matrice[i - 1, j - this.poidsOb[i]].getValue()+valeurOb[i]));
                        if (this.matrice[i - 1, j].getValue() >= this.matrice[i - 1, j - this.objectList[i].getWeight()].getValue() + this.objectList[i].getValue())
                        {
                            this.matrice[i, j].setValue(this.matrice[i - 1, j].getValue());
                            HashSet<int> liste = this.matrice[i - 1, j].getListObject();
                            foreach (int element in liste)
                            {
                                this.matrice[i, j].addObject(element);
                            }
                        }
                        else
                        {
                            this.matrice[i, j].setValue(this.matrice[i - 1, j - this.objectList[i].getWeight()].getValue() + this.objectList[i].getValue());
                            if (matrice[i - 1, j - objectList[i].getWeight()].getListObject().Count == 0)
                            {
                                this.matrice[i, j].addObject(i);
                            }
                            else
                            {
                                HashSet<int> liste = this.matrice[i - 1, j - this.objectList[i].getWeight()].getListObject();
                                foreach (int element in liste)
                                {
                                    this.matrice[i, j].addObject(element);
                                    this.matrice[i, j].addObject(i);
                                }
                            }
                        }
                    }
                    else
                    {
                        this.matrice[i, j].setValue(this.matrice[i - 1, j].getValue());
                        if (this.matrice[i - 1, j].getListObject().Count == 0)
                        {
                            this.matrice[i, j].addObject(i);
                        }
                        else
                        {
                            HashSet<int> liste = matrice[i - 1, j].getListObject();
                            foreach (int element in liste)
                            {
                                this.matrice[i, j].addObject(element);
                            }
                        }
                    }
                    Console.Write("  " + this.matrice[i, j].getValue());
                    valeurMax = this.matrice[i, j].getValue();
                }
                Console.WriteLine();

            }
            Console.WriteLine();
            this.matrice[objectList.Count - 1, poids - 1].getListObject().Remove(0);
            foreach (int k in this.matrice[objectList.Count - 1, poids - 1].getListObject())
            {
                Console.Write("  " + k.ToString());
            }
            Console.WriteLine();
            return this.matrice[this.objectList.Count - 1, poids - 1].getListObject();

        }


        private void execute_Click(object sender, RoutedEventArgs e)
        {
            resultList.Clear();
            if (poids != 0)
            {
                if (objectList.Count >= 2)
                {
                    result = new HashSet<int>();
                    this.result =sacAdosMatrix();
                    foreach (int i in result)
                    {
                        resultList.Add(objectList[i]);

                    }
                    if (valeurMax >0)
                    {
                        resultatF.Text = "Max= " + valeurMax.ToString();
                    }
                    else
                    {
                        resultatF.Text = "Max= 0";
                    }

                    resultGrid.ItemsSource = resultList;
                    resultGrid.Items.Refresh();
                }

                else
                {
                    MessageBox.Show("Please initialize your list objects");
                }
            }
            else
            {
                MessageBox.Show("Please set the weight");
            }

           
            
        }
             
        
    }
}
