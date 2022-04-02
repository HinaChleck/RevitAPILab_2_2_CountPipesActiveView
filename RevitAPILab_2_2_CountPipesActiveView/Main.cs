using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Plumbing;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevitAPILab_2_2_CountPipesActiveView
{
    [Transaction(TransactionMode.Manual)]
    public class Main : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIApplication uiapp = commandData.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Document doc = uidoc.Document;

            List<Pipe> pipes = new FilteredElementCollector(doc, doc.ActiveView.Id)
            .OfClass(typeof(Pipe))
            //.WhereElementIsNotElementType() - не требуется при фильтрации по классу (требуется при фильтрации по категории)
            .Cast<Pipe>()
            .ToList();
            TaskDialog.Show("Количество труб на виде: ", pipes.Count.ToString());
            return Result.Succeeded;
        }
    }
}
