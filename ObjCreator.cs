using RobotOM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spider_Free
{
   class ObjCreator
   {

      public static int AddNode(RobotStructure structureRSA, double x, double y, double z)
      {
         RobotNodeServer nodesRSA = structureRSA.Nodes;
         int freeNum = nodesRSA.FreeNumber;
         nodesRSA.Create(freeNum, x, y, z);
         return freeNum;
      }

      public static void AddBar(RobotStructure structureRSA, RobotNode node1, RobotNode node2, IRobotLabel labelSect)
      {
         int num1 = node1.Number;
         int num2 = node2.Number;
         RobotBarServer barsRSA = structureRSA.Bars;
         int freeNum = barsRSA.FreeNumber;
         barsRSA.Create(freeNum, num1, num2);
         RobotSelection selection = structureRSA.Selections.Create(IRobotObjectType.I_OT_BAR);
         selection.FromText(freeNum.ToString());
         barsRSA.SetLabel(selection, IRobotLabelType.I_LT_BAR_SECTION, labelSect.Name);
      }
      
      public static int AddBar(RobotStructure structureRSA, RobotNode node1, RobotNode node2)
      {
         int num1 = node1.Number;
         int num2 = node2.Number;
         RobotBarServer barsRSA = structureRSA.Bars;
         int freeNum = barsRSA.FreeNumber;
         barsRSA.Create(freeNum, num1, num2);
         return freeNum;
      }

      public static void AddHole()
      {

      }

      public static void AddRigidLink()
      {

      }
   }
}
