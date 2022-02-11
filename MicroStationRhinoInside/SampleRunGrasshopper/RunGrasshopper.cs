using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Rhino.Runtime.InProcess;
using Rhino.Geometry;

namespace MicroStationRhinoInside
{
  public class RunGrasshopper
  {
    public static void RunHelper()
    {
      // Extract definition to sample location as executable
      var assembly = typeof(MicroStationRhinoInside.Entry.RhinoInsideSample).Assembly;
      string dir = System.IO.Path.GetDirectoryName(assembly.Location);
      string filePath = System.IO.Path.Combine(dir, "simple_def.gh");

      using (var resStream = assembly.GetManifestResourceStream("MicroStationRhinoInside.SampleRunGrasshopper.simple_def.gh"))
      using (var outStream = new System.IO.FileStream(filePath, System.IO.FileMode.Create))
      {
        resStream.CopyTo(outStream);
      }

      // Start grasshopper in "headless" mode
      var pluginObject = Rhino.RhinoApp.GetPlugInObject("Grasshopper") as Grasshopper.Plugin.GH_RhinoScriptInterface;
      pluginObject.RunHeadless();

      var io = new Grasshopper.Kernel.GH_DocumentIO();
      if (!io.Open(filePath))
        MessageBox.Show("File loading failed.");
      else
      {
        var doc = io.Document;

        // Documents are typically only enabled when they are loaded
        // into the Grasshopper canvas. In this case we -may- want to
        // make sure our document is enabled before using it.
        doc.Enabled = true;

        foreach (var obj in doc.Objects)
          if (obj is Grasshopper.Kernel.IGH_Param param)
            if (param.NickName == "CollectMe")
            {
              param.CollectData();
              param.ComputeData();

              foreach (var item in param.VolatileData.AllData(true))
                if (item.CastTo(out Line line))
                  MessageBox.Show($"Got a line: {line:0.000}");
                else
                  MessageBox.Show($"Unexpected data of type: {item.TypeName}");

              break;
            }
      }
    }
  }
}
