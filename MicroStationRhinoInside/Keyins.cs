using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

using MicroStationRhinoInside.Entry;

namespace MicroStationRhinoInside
{
  public class Keyins
  {
    public static void Hello(string unparsed)
    {
      RhinoInsideTestApp.Instance.Hello(unparsed);
    }

    public static void Start(string unparsed)
    {
      RhinoInsideTestApp.Instance.Start(unparsed);
    }

    public static void RunGH(string unparsed)
    {
      RhinoInsideTestApp.Instance.RunGH(unparsed);
    }

    //public static void EtoApp(string unparsed)
    //{
    //  RhinoInsideTestApp.Instance.EtoApp(unparsed);
    //}

    public static void WinFormsApp(string unparsed)
    {
      RhinoInsideTestApp.Instance.WinFormsApp(unparsed);
    }
  }
}
