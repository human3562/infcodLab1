using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using infcodLab1.Models;

namespace infcodLab1
{
    class DataAccess
    {
        Random rnd = new Random();

        public List<ExperimentModel> GetExperiments(int N, int amt, out double totalI, out double totalH)
        {
            List<ExperimentModel> output = new List<ExperimentModel>();

            totalH = Math.Log(N, 2);
            totalI = 0;
            for(int i = 0; i < amt; i++)
            {
                ExperimentModel em = new ExperimentModel();
                em.Title = "Эксперимент " + (i+1);
                em.px = GenerateNumbers(N);
                double ix = GetAverageInformationAmount(em.px);
                totalI += ix;
                em.ix = "<I(x)> = "  + String.Format("{0: 0.0000}", ix);
                em.hx = "H(x)max = " + String.Format("{0: 0.0000}", Math.Log(N, 2));

                output.Add(em);
            }

            totalI /= amt;
            return output;
        }

        private double[] GenerateNumbers(int N)
        {
            double s = 0; ; double b = 1;
            double[] px = new double[N];
            for (int i = 0; i < N - 1; i++)
            {
                px[i] = b * rnd.NextDouble();
                b -= px[i];
                s += px[i];
            }
            px[N-1] = 1 - s;
            return px;
        }

        private double GetAverageInformationAmount(double[] px)
        {
            double result = px[0] * Math.Log(px[0], 2);

            for(int i = 1; i < px.Length; i++)
            {
                result += px[i] * Math.Log(px[i], 2);
            }

            return -result;
        }
    }
}
