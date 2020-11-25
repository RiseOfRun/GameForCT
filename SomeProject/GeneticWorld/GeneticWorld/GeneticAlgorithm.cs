using System;
using System.Collections.Generic;
using System.Linq;

namespace GeneticWorld
{
    class GeneticAlgorithm
    {
        public static int populationSize = 10000;
        public static int populationSize2 = populationSize * 2;
        public static int maxParents = 10;
        public static int GenNumb = 11; //Кол-во генов (величина генотипа)
        public double MutationProbability = 0.2;
        public static int m = 10; //Кол-во точек x (Величина фенотипа)
        List<double> X = new List<double>(new double[m]);
        Individ TrueIndivid = new Individ();
        List<Individ> Population = new List<Individ>();
        List<Individ> PopulationTemp = new List<Individ>(new Individ[populationSize2]);


        double GetRandomDouble(double maxValue)
        {
            return new Random(new System.DateTime().Millisecond).NextDouble() * maxValue;
        }

        int GetRandomInt(int minValue, int maxValue)
        {
            return new Random(new System.DateTime().Millisecond).Next(minValue, maxValue);
        }

        GeneticAlgorithm()
        {
            //зададим параметры точек
            X = new List<double> {1, 2, 3, 4, 5, 6, 7, 8, 9, 10};

            //прямая задача
            //зададим истинные значения коэффициентов(генотип)
            TrueIndivid.gens = new List<double> {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 10};

            //посчитаем его фенотип(y)
            TrueIndivid.SetYAndFunctional(X, TrueIndivid);
        }


        void GenerateStartPopulation()
        {
            // Создаем первое поколение
            for (int j = 0; j < populationSize; j++)
            {
                List<double> parametrs = new List<double>();
                for (int i = 0; i < GenNumb; i++)
                {
                    parametrs.Add(GetRandomDouble(10));
                }

                Population.Add(new Individ(parametrs));
            }


            // Посчитаем y и функционал для каждого чела
            foreach (var item in Population)
            {
                item.SetYAndFunctional(X, TrueIndivid);
            }

            // Сортировка по функционалу
            Population = new List<Individ>(Population.OrderBy(poper => poper.F));
        }
        
        int GetMother(){return GetRandomInt(0,populationSize);}

        Individ GetChild(Individ father, Individ mother)
        {
            int i;
            Individ child = new Individ();
            int IndCross=GetRandomInt(0,GenNumb);
            for(i=0;i<IndCross;i++){child.gens[i]=father.gens[i];}
            for(i=IndCross;i<GenNumb;i++){child.gens[i]=mother.gens[i];}
            return child;
        }
        
        void Mutation(Individ ind) // Мутации
        {
            double v=GetRandomDouble(1);
            if(v<MutationProbability)
            {
                int i=GetRandomInt(0,GenNumb);
                ind.gens[i]=GetRandomDouble(10);
            }
        }

   

        void GenerateNewPopulation()
        {
            PopulationTemp = new List<Individ>();
            int i, j, k;
            int nChilds = populationSize2 / maxParents;
            for (i = 0; i < maxParents; i++)
            {
                for (j = 0; j < nChilds; j++)
                {
                    k = GetMother();
                    Individ child = GetChild(Population[i], Population[k]);
                    Mutation(child);
                    PopulationTemp.Add(child);
                }
            }
        }
    }
}