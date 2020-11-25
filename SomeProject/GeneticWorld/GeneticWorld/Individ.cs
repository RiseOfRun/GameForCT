using System;
using System.Collections.Generic;

namespace GeneticWorld
{
    class Individ
    {
        
        public List<double> gens= new List<double>(new double[GeneticAlgorithm.GenNumb]);
        public List<double> y = new List<double>(GeneticAlgorithm.m); //Фенотип
        public double F = Double.MaxValue;

        public Individ(List<double> gens)
        {
            this.gens = gens;
        }

        public Individ()
        {
            
        }
        public double Polynom(double x)// нумерация со старшей степени коэффов
        {
            double multX = 1;
            double Sum = 0;
            for (int i = GeneticAlgorithm.GenNumb-1; i >=0; i++)
            {
                Sum += multX * gens[i];
                multX *= x;
            }
            return Sum;
        }
        double Functional(Individ trueInd)
        {
            double Sum = 0;
            for (int i = 0; i < y.Count; i++)
            {
                Sum += Math.Abs(trueInd.y[i] - y[i]);
            }

            return Sum;
        }

        
        public void SetYAndFunctional(List<double> X,Individ trueInd)
        {
            for (int i = 0; i < X.Count; i++)
            {
                y[i] = Polynom(X[i]);
            } 
            F = Functional(trueInd);
        }
    }
}