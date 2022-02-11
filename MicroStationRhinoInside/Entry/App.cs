using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

using Bentley.DgnPlatformNET;
using Bentley.DgnPlatformNET.Elements;
using Bentley.GeometryNET;
using Bentley.MstnPlatformNET;


namespace MicroStationRhinoInside.Entry
{
  [AddIn(MdlTaskID = "RhinoInsideTest")]
  public class RhinoInsideTestApp : AddIn
  {
    public static RhinoInsideTestApp App;

    public RhinoInsideTestApp(IntPtr mdlDesc) : base(mdlDesc)
    {
    }

    protected override int Run(string[] commandLine)
    {
      App = this;
      RhinoInside.Resolver.Initialize();
      return 0;
    }

    internal static RhinoInsideTestApp Instance
    {
      get { return App; }
    }

    public void Hello(string unparsed)
    {
      System.Windows.Forms.MessageBox.Show("Hello!");
    }

    public void Start(string unparsed)
    {
      RhinoInsideSample.Start();
    }

    public void RunGH(string unparsed)
    {
      RhinoInsideSample.RunGH();
    }

    //public void EtoApp(string unparsed)
    //{
    //  RhinoInsideSample.EtoApp();
    //}

    public void WinFormsApp(string unparsed)
    {
      RhinoInsideSample.WinFormsApp();
    }
  }
}
