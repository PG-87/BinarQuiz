using System;
using System.IO.Ports;
using System.Threading;

namespace BinarQuiz
{
    public class Program
    {
        static bool _continue;
        static SerialPort _serialPort;
        static Player player;
        static Questions questions;
        static string playerNameArea = "-sc0 -sg0,0,50,8 -f0 -cf2 -cb0 -t";
        static string questionArea = "-sc1 -sg0,8,50,8 -f0 -cf3 -t";
        static string scoreArea = "-sc2 -sg50,0,14,16 -sfm1 -f1 -cf0 -cb3 -sha2 -t";

        public static void Main()
        {
            string message;
            StringComparer stringComparer = StringComparer.OrdinalIgnoreCase;
            _continue = true;

            _serialPort = new SerialPort();
            player = new Player();
            questions = new Questions();
            questions.FillArraysWithQuestionsAndAnswers();

            //Set port and reset display text fields
            DisplayStartup();
                        
            //Start Game
            Console.Write("Player name: ");
            player.setPlayerName(Console.ReadLine());

            Console.WriteLine("Welcome player: " + player.getPlayerName());
            _serialPort.WriteLine(playerNameArea + player.getPlayerName());

            for (int i = 0; i < questions.questions.Length; i++)
            {
                Console.WriteLine("Question: " + (i + 1) + " " + questions.GetQuestion(i));
                _serialPort.WriteLine(questionArea + "Question:" + (i + 1));
                string answer = Console.ReadLine();
                if (answer == questions.GetAnswer(i))
                {
                    player.setPlayerScore(1);
                    _serialPort.WriteLine(scoreArea + player.getPlayerScore());
                }
            }

            Console.WriteLine("Congratulations! You got :" + player.getPlayerScore() + "of 5 questions right!");
            _serialPort.WriteLine(questionArea + "Congratz! -r1");
            
            
            Console.WriteLine("Type QUIT to exit");

            while (_continue)
            {
                message = Console.ReadLine();
               
                if (stringComparer.Equals("quit", message))
                {
                    _continue = false;
                }
                else
                {
                    _serialPort.WriteLine(message);
                }
            }
            _serialPort.WriteLine("-dac");
            _serialPort.Close();
        }

        public static void DisplayStartup()
        {
            _serialPort.PortName = SetPortName(_serialPort.PortName);
            _serialPort.Open();
            _serialPort.WriteLine("-dac");
            Console.WriteLine("Set light intensity 0-100% (default is 100%): ");
            _serialPort.WriteLine("-i" + Console.ReadLine());
            _serialPort.WriteLine(scoreArea);
        }
        public static string SetPortName(string defaultPortName)
        {
            string portName;

            Console.WriteLine("Available Ports:");
            foreach (string s in SerialPort.GetPortNames())
            {
                Console.WriteLine("   {0}", s);
            }

            Console.Write("Enter COM port value (Default: {0}): ", defaultPortName);
            portName = Console.ReadLine();

            if (portName == "" || !(portName.ToLower()).StartsWith("com"))
            {
                portName = defaultPortName;
            }
            return portName;
        }
    }
}