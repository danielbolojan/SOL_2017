using Grasshopper.Kernel;
using Owl.Core.Tensors;
using Owl.GH.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwlTestPlugin {
    public class SOL_Component : GH_Component {

        public SOL_Component() : base("SOL Component", "SOL", "Component description", "Owl", "SOL") { }

        public override Guid ComponentGuid => new Guid("{D0D21E1F-CDDA-4C7D-924E-A40D250015DD}");

        protected override void RegisterInputParams(GH_InputParamManager pManager) {
            pManager.AddParameter(new Param_OwlTensor());
        }

        protected override void RegisterOutputParams(GH_OutputParamManager pManager) {
            pManager.AddIntegerParameter("Length", "L", "Length of the Tensor", GH_ParamAccess.item);
        }

        protected override void SolveInstance(IGH_DataAccess DA) {
            // This is a duplicate value.
            // The default way. Prevents the upstream changes by returning a duplicate. 
            Tensor Tens = null;
            DA.GetData(0, ref Tens);

            // This return the pointer to the value from the previous component.
            // This is not a duplicate.
            // GH_OwlTensor GH_Tens = null;
            // DA.GetData(0, ref GH_Tens);

            System.Diagnostics.Debug.WriteLine("Hello"); 

            DA.SetData(0, Tens.ShapeCount); 
        }

    }
}
