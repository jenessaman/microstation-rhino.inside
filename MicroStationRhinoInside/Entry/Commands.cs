using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Rhino.Runtime.InProcess;
using Rhino.Geometry;

namespace MicroStationRhinoInside.Entry
{
  public class RhinoInsideSample
  {
    [System.STAThread]
    public static void Start()
    {
      try
      {
        using (new RhinoCore())
        {
          HelloWorld.MeshABrep();
        }
      }
      catch (Exception ex)
      {
        MessageBox.Show(ex.Message);
      }
    }

    public static void RunGH()
    {
      try
      {
        using (var core = new Rhino.Runtime.InProcess.RhinoCore())
        {
          RunGrasshopper.RunHelper();
        }
      }
      catch (Exception ex)
      {
        MessageBox.Show(ex.Message);
      }
    }

    public static void WinFormsApp()
    {
      try
      {
        Application.EnableVisualStyles();
        //Application.SetCompatibleTextRenderingDefault(false);
        StartWinFormsApp();
      }
      catch (Exception ex)
      {
        MessageBox.Show(ex.Message);
      }
    }

    public static void StartWinFormsApp()   
    {
      Application.Run(new MainForm());
    }
  }
}
