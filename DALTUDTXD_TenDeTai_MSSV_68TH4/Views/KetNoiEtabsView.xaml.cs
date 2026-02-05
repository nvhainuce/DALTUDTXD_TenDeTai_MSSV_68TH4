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
using System.Windows.Shapes;

namespace DALTUDTXD_TenDeTai_MSSV_68TH4.Views
{
    /// <summary>
    /// Interaction logic for KetNoiEtabsView.xaml
    /// </summary>
    public partial class KetNoiEtabsView : Window
    {
        public KetNoiEtabsView()
        {
            InitializeComponent();
        }

        private void ConnectEtabsButton_Click(object sender, RoutedEventArgs e)
        {
            //set the following flag to true to attach to an existing instance of the program 
            //otherwise a new instance of the program will be started 
            bool AttachToInstance;
            AttachToInstance = false;

            //set the following flag to true to manually specify the path to ETABS.exe
            //this allows for a connection to a version of ETABS other than the latest installation
            //otherwise the latest installed version of ETABS will be launched
            bool SpecifyPath;
            SpecifyPath = false;

            //if the above flag is set to true, specify the path to ETABS below
            string ProgramPath;
            ProgramPath = @"C:\Program Files\Computers and Structures\ETABS 22\ETABS.exe";

            //full path to the model 
            //set it to an already existing folder 
            string ModelDirectory = @"C:\CSi_ETABS_API_Example";
            try
            {
                System.IO.Directory.CreateDirectory(ModelDirectory);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not create directory: " + ModelDirectory);
            }

            string ModelName = "ETABS_API_Example.edb";
            string ModelPath = ModelDirectory + System.IO.Path.DirectorySeparatorChar + ModelName;

            //dimension the ETABS Object as cOAPI type
            ETABSv1.cOAPI myETABSObject = null;

            //Use ret to check if functions return successfully (ret = 0) or fail (ret = nonzero) 
            int ret = 0;

            //create API helper object
            ETABSv1.cHelper myHelper;
            try
            {
                myHelper = new ETABSv1.Helper();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cannot create an instance of the Helper object");
                return;
            }

            if (AttachToInstance)
            {
                //attach to a running instance of ETABS 
                try
                {
                    //get the active ETABS object
                    myETABSObject = myHelper.GetObject("CSI.ETABS.API.ETABSObject");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No running instance of the program found or failed to attach.");
                    return;
                }
            }
            else
            {
                if (SpecifyPath)
                {
                    //'create an instance of the ETABS object from the specified path
                    try
                    {
                        //create ETABS object
                        myETABSObject = myHelper.CreateObject(ProgramPath);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Cannot start a new instance of the program from " + ProgramPath);
                        return;
                    }
                }
                else
                {
                    //'create an instance of the ETABS object from the latest installed ETABS
                    try
                    {
                        //create ETABS object
                        myETABSObject = myHelper.CreateObjectProgID("CSI.ETABS.API.ETABSObject");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Cannot start a new instance of the program.");
                        return;
                    }
                }
                //start ETABS application
                ret = myETABSObject.ApplicationStart();
            }

            //Get a reference to cSapModel to access all API classes and functions
            ETABSv1.cSapModel mySapModel = default(ETABSv1.cSapModel);
            mySapModel = myETABSObject.SapModel;

            //Initialize model
            ret = mySapModel.InitializeNewModel();

            //Create steel deck template model
            ret = mySapModel.File.NewSteelDeck(4, 12, 12, 4, 4, 24, 24);

            //Save model
            ret = mySapModel.File.Save(ModelPath);

            //Run analysis
            ret = mySapModel.Analyze.RunAnalysis();

            //Close ETABS
            myETABSObject.ApplicationExit(false);

            //Clean up variables
            mySapModel = null;
            myETABSObject = null;

            //Check ret value 
            if (ret == 0)
            {
                MessageBox.Show("API script completed successfully.");
            }
            else
            {
                MessageBox.Show("API script FAILED to complete.");
            }
        }

    }
}
