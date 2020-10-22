using RobotOM;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spider_Free
{
   class Class1
   {
      public string[] NamesSectBar { get; private set; }
      public string[] MaterialsRSA { get; private set; }

      void getBarSectionNamesRSA(RobotApplication appRSA)
      {
         RobotLabelServer labelsRSA = appRSA.Project.Structure.Labels;
         //RobotLabel labelRSA;
         RobotNamesArray namArrRSA = labelsRSA.GetAvailableNames(IRobotLabelType.I_LT_BAR_SECTION);
         string[] tmp = new string[namArrRSA.Count];
         for (int i = 0; i < namArrRSA.Count; i++)
         {
            tmp[i] = namArrRSA.Get(i + 1);
         }
         NamesSectBar = tmp;
      }

      public void getBarSectionNamesRSA()
      {
         RobotApplication appRSA = new RobotApplication();
         RobotLabelServer labelsRSA = appRSA.Project.Structure.Labels;
         //RobotLabel labelRSA;
         RobotNamesArray namArrRSA = labelsRSA.GetAvailableNames(IRobotLabelType.I_LT_BAR_SECTION);
         string[] tmp = new string[namArrRSA.Count];
         for (int i = 0; i < namArrRSA.Count; i++)
         {
            tmp[i] = namArrRSA.Get(i + 1);
         }
         NamesSectBar = tmp;
      }

      void getMaterialNameListRSA(RobotApplication appRSA)
      {
         RobotLabelServer labelsRSA = appRSA.Project.Structure.Labels;
         //RobotLabel labelRSA;
         RobotNamesArray namArrRSA = labelsRSA.GetAvailableNames(IRobotLabelType.I_LT_MATERIAL);
         string[] tmp = new string[namArrRSA.Count];
         for (int i = 0; i < namArrRSA.Count; i++)
         {
            tmp[i] = namArrRSA.Get(i + 1);
         }
         MaterialsRSA = tmp;
      }
      public void getMaterialNameListRSA()
      {
         RobotApplication appRSA = new RobotApplication();
         RobotLabelServer labelsRSA = appRSA.Project.Structure.Labels;
         //RobotLabel labelRSA;
         RobotNamesArray namArrRSA = labelsRSA.GetAvailableNames(IRobotLabelType.I_LT_MATERIAL);
         string[] tmp = new string[namArrRSA.Count];
         for (int i = 0; i < namArrRSA.Count; i++)
         {
            tmp[i] = namArrRSA.Get(i + 1);
         }
         MaterialsRSA = tmp;
      }

      public void test()
      {
         RobotApplication appRSA = new RobotApplication();
         getMaterialNameListRSA(appRSA);
         getBarSectionNamesRSA(appRSA);
         RobotStructure structureRSA = appRSA.Project.Structure;
         RobotBarServer barsRSA = structureRSA.Bars;
         RobotNodeServer nodesRSA = structureRSA.Nodes;
         RobotObjObjectServer objRSA = structureRSA.Objects;

         RobotLabelServer labelsRSA = appRSA.Project.Structure.Labels;

         //Определение выборок выделенных в модели объектов
         RobotSelection barSel = structureRSA.Selections.Get(IRobotObjectType.I_OT_BAR);
         RobotSelection plateSel = structureRSA.Selections.Get(IRobotObjectType.I_OT_PANEL);
         RobotSelection holesSel = structureRSA.Selections.Get(IRobotObjectType.I_OT_GEOMETRY);

         RobotBarCollection barsMany = (RobotBarCollection)barsRSA.GetMany(barSel);
         RobotObjObjectCollection platesMany = (RobotObjObjectCollection)objRSA.GetMany(plateSel);
         IRobotBar barRSA = barsMany.Get(3);
         IRobotObjObject plate = platesMany.Get(1);

         IRobotLabel labelPlate = plate.GetLabel(IRobotLabelType.I_LT_PANEL_THICKNESS);
         RobotGeoPoint3DCollection defPoints= (RobotGeoPoint3DCollection)plate.Main.DefPoints;
         RobotGeoPoint3D pt1 = defPoints.Get(1);
         RobotGeoPoint3D pt2 = defPoints.Get(2);
         RobotGeoPoint3D pt3 = defPoints.Get(defPoints.Count);
         //IRobotGeoContour geoContour=(IRobotGeoContour)plate.Main.Geometry;
         //IRobotGeoObject geoObj=plate.Main.Geometry;

         IRobotLabel labelBar = barRSA.GetLabel(IRobotLabelType.I_LT_BAR_SECTION);
         RobotBarSectionData data = labelBar.Data;
         RobotBarSectionConcreteData cData = data.Concrete;
         double b = cData.GetValue(IRobotBarSectionConcreteDataValue.I_BSCDV_COL_B);
         double h = cData.GetValue(IRobotBarSectionConcreteDataValue.I_BSCDV_COL_H);
         double l1 = cData.GetValue(IRobotBarSectionConcreteDataValue.I_BSCDV_COL_L1);
         double l2 = cData.GetValue(IRobotBarSectionConcreteDataValue.I_BSCDV_COL_L2);
         double h1 = cData.GetValue(IRobotBarSectionConcreteDataValue.I_BSCDV_COL_H1);
         double h2 = cData.GetValue(IRobotBarSectionConcreteDataValue.I_BSCDV_COL_H2);
         double de = cData.GetValue(IRobotBarSectionConcreteDataValue.I_BSCDV_COL_DE);
         double alfa = barRSA.Gamma;
      }
   }
}
