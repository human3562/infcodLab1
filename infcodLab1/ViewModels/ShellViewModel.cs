using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using infcodLab1.Models;

namespace infcodLab1.ViewModels
{
    public class ShellViewModel : Screen
    {
        //private DataAccess da = new DataAccess();
        public BindableCollection<ExperimentModel> Experiments { get; set; }
        public int N { get; set; }
        public int expAmt { get; set; }

        public string totalI
        {
            get; set;
        }
        public string totalH {
            get; set;
        }


        public ShellViewModel()
        {
            DataAccess da = new DataAccess();
            N = 9; expAmt = 5;
            Experiments = new BindableCollection<ExperimentModel>(da.GetExperiments(9, 5, out double _totalI, out double _totalH));
            totalI = String.Format("{0:0.0000}" ,_totalI); totalH = String.Format("{0:0.0000}", _totalH);
            NotifyOfPropertyChange(() => totalI);
            NotifyOfPropertyChange(() => totalH);

        }

        public void RunExperiments()
        {
            DataAccess da = new DataAccess();
            Experiments.Clear();

            List<ExperimentModel> models = da.GetExperiments(N, expAmt, out double _totalI, out double _totalH);
            totalI = String.Format("{0:0.0000}", _totalI); totalH = String.Format("{0:0.0000}", _totalH);
            NotifyOfPropertyChange(() => totalI);
            NotifyOfPropertyChange(() => totalH);

            Experiments.AddRange(models);
            
        }

    }
}
