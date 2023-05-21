using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Ticket_sales.Models.Ticketsale
{
    internal class Van
    {
        List<Van> vanCollection;
        private int trainLength = 0;
        public int TrainLength
        {
            get { return trainLength; }
        }
         // Свободные места в вагоне 
        public bool FreePlace(int placeVagon, int placePosition)
        {
            return vanCollection[placeVagon].FreePlace(placePosition);
        }

        private bool FreePlace(int placePosition)
        {
            throw new NotImplementedException();
        }

        // заполненные места
        public void OnPlace(int placeVagon, int placePosition, string passanger)
        {
            vanCollection[placeVagon].OnPlace(placePosition, passanger);
        }

        private void OnPlace(int placePosition, string passanger)
        {
            throw new NotImplementedException();
        }
    }

    class PlaceInTheTrain //новое место для пассажира
    {
        int place;
        public string Passenger { get; set; }
        public PlaceInTheTrain()
        {
            place = 0;
            Passenger = String.Empty;
        }
    }

    internal class Vane
    {
   
        PlaceInTheTrain[] places;
        private List<Van> vanCollection;
        private int trainLength;
        private const int placesInTrain = 30;// максимальное количество 

        public Vane(List<Van> vanCollection, int trainLength, PlaceInTheTrain[] places)
        {
            this.vanCollection = vanCollection ?? throw new ArgumentNullException(nameof(vanCollection));
            this.trainLength = trainLength;
            this.places = places ?? throw new ArgumentNullException(nameof(places));
        }

        public bool FreePlace(int numberPlace)
        {
            return places[numberPlace].Passenger == String.Empty;
        }

        public void OnPlace(int numberPlace, string passanger)
        {
            places[numberPlace].Passenger = passanger;
        }

        public override bool Equals(object? obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string? ToString()
        {
            return base.ToString();
        }
    }
    
    class Program
    {
        static Train train;
        private static int numberTrain = 0;
        private static int numberPlace = 0;
        private static string passangerName = default;
        

        static void Main(string[] args)
        {
            string chooseTrain = default;
            Console.WriteLine("Выберите поезд из списка ниже:\n");
            Console.WriteLine(@"Поезд 'Самара-Казань' нажмите ""1""");
            Console.WriteLine(@"Поезд 'Самара-Волгоград' нажмите ""2""");
            Console.WriteLine(@"Поезд 'Самара-Воронеж' нажмите ""3""");
            chooseTrain = Console.ReadLine();
            switch (chooseTrain)
            {
                case "1":
                    {
                        Console.WriteLine("Выбран поезд 'Самара-Казань'\n");
                        
                        do
                        {
                            EnterData();
                        } while (passangerName != String.Empty);
                        break;
                    }
                case "2":
                
                    {
                        Console.WriteLine("Выбран поезд 'Самара-Волгоград'\n");
                        
                        do
                        {
                            EnterData();
                        } while (passangerName != String.Empty);
                        break;
                    }
                case "3":
                
                    {
                        Console.WriteLine("Выбран поезд 'Самара-Воронеж'\n");
                        
                        do
                        {
                            EnterData();
                        } while (passangerName!= String.Empty);
                        break;
                    }
            }
            Console.ReadKey();
        }
        
        public static void EnterData()
        {
            Console.WriteLine("Укажите номер поезда");
            numberTrain = Convert.ToInt32(Console.ReadLine());
            Console.Write("Выберите свободное место");
            numberPlace = Convert.ToInt32(Console.ReadLine());
            if (train.FreePlace(numberTrain, numberPlace))

           
            {
                Console.WriteLine("Введите ФИО ");
                passangerName = Console.ReadLine();
                train.OnPlace(numberTrain,numberPlace,passangerName);
                Console.WriteLine("Пассажир добавлен!"); 
            }
        }
    }
}

        

    

    
