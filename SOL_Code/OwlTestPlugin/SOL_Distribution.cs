using Grasshopper.Kernel;
using Owl.Core.Tensors;
using Owl.GH.Common;
using System;
using Accord.Statistics.Distributions.Univariate; //import to make direct calls to the types in the namespace 
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwlTestPlugin {
    public class SOL_Distribution : GH_Component {                                  //RENAME MANUALLY =======================

        public SOL_Distribution() : base("SOL Distribution", "SOL", "Distribution component", "Owl", "SOL") { } //RENAME MANUALLY =======================

        public override Guid ComponentGuid => new Guid("{3DA5996E-106B-40C6-80CB-BD22DA37D34F}"); // CHANGE THIS 

        protected override void RegisterInputParams(GH_InputParamManager pManager) {
            pManager.AddNumberParameter("Mean", "M", "Mean", GH_ParamAccess.item, 0);
            pManager.AddNumberParameter("Deviation", "D", "Standard deviation", GH_ParamAccess.item, 0.1);
            pManager.AddIntegerParameter("Samples", "S", "Number of samples", GH_ParamAccess.item, 100); 
            pManager.AddIntegerParameter("Seed", "R", "Randomness seed", GH_ParamAccess.item, 123); 
        }

        protected override void RegisterOutputParams(GH_OutputParamManager pManager) {
            pManager.AddParameter(new Param_OwlTensor());
        }

        protected override void SolveInstance(IGH_DataAccess DA) {
            double mean = double.NaN;
            double dev = double.NaN;
            int samples = 0; 
            int seed = 0; 

            DA.GetData(0, ref mean);
            DA.GetData(1, ref dev);
            DA.GetData(2, ref samples);
            DA.GetData(3, ref seed);

            Accord.Math.Random.Generator.Seed = seed; 

            NormalDistribution dist = new NormalDistribution(mean, dev);
            Tensor tens = new Tensor(samples); 
            tens.TensorData = dist.Generate(samples);

            DA.SetData(0, tens); 
        }

    }
}
