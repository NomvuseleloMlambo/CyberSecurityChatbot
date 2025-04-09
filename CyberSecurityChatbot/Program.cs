
using System;
using System.Media;
using System.Threading;

namespace CyberSecurityBot
{
    class Program
    {
        static void Main(string[] args)
        {
            // Play the greeting at startup
            PlayGreeting();

            // Dispaly Ascii art logo
            ShowAsciiArt();

            System.Threading.Thread.Sleep(11000);

            //Greet user and ask for name
            string userName = GreetUser();

            //Chatbot
            StartChatbot(userName);

            //Placeholder for chatbot logic
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
        //play greeting recording
        static void PlayGreeting()
        {
            try
            {
                SoundPlayer player = new SoundPlayer("Resources/greeting.wav");
                player.Load();
                player.Play();

            }

            catch (Exception ex)
            {
                Console.WriteLine("Audio error: " + ex.Message);
            }

        }
        // Show ascii art method
        static void ShowAsciiArt()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(@"     
                     ________
                    / _______\ 
                   | |      | |  
                   | | LOC  | |   
                   | |______| | 
                    \________/    

                  [CYBER BOT]
               Cybersecurity Awareness
");
            Console.ResetColor();
        }
        //greet user method
        static string GreetUser()
        {
            Console.WriteLine("\nWhat's your name?");
            string name = Console.ReadLine();

            while (string.IsNullOrWhiteSpace(name))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Please enter a valid name.");
                Console.ResetColor();
                name = Console.ReadLine();
            }

            // Personalized welcome message
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\nWelcome, {name}! I'm your Cybersecurity Awareness Assistant.");
            Console.WriteLine("Ask me anything about staying safe online!");
            Console.ResetColor();

            return name;
        }
        //chatbot method
        static void StartChatbot(string userName)
        {
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                TypeResponse("\nWhat would you like to ask about cybersecurity? (Type 'exit' to quit)");
                Console.ResetColor();

                string userInput = Console.ReadLine();

                if (userInput.ToLower() == "exit")
                {
                    Console.WriteLine($"\nGoodbye, {userName}! Stay safe online. 👋");
                    break;
                }

                GetResponse(userInput);
            }
        }
        //response method
        static void GetResponse(string userInput)
        {
            userInput = userInput.ToLower();

            if (userInput.Contains("how are you"))
            {
                TypeResponse("\nI'm doing great, thank you! I'm always ready to help you stay safe online.");
            }
            else if (userInput.Contains("what's your purpose") || userInput.Contains("what is your purpose"))
            {
                TypeResponse("\nMy purpose is to educate and assist you with cybersecurity knowledge so you can protect yourself online.");
            }
            else if (userInput.Contains("what can i ask") || userInput.Contains("topics"))
            {
                TypeResponse("\nYou can ask about:");
                TypeResponse("- Phishing");
                TypeResponse("- Strong passwords");
                TypeResponse("- Malware");
                TypeResponse("- Safe browsing");
                TypeResponse("- Common scams");
                TypeResponse("- Social engineering");
            }
            else if (userInput.Contains("phishing"))
            {
                TypeResponse("\nPhishing is when attackers try to trick you into giving out personal information using fake emails or messages.");
            }
            else if (userInput.Contains("strong password") || userInput.Contains("create password"))
            {
                TypeResponse("\nA strong password should:");
                TypeResponse("- Be at least 12 characters long");
                TypeResponse("- Include uppercase, lowercase, numbers, and symbols");
                TypeResponse("- Avoid names, common words, or personal info");
            }
            else if (userInput.Contains("malware"))
            {
                TypeResponse("\nMalware is malicious software like viruses, spyware, or ransomware that can damage or steal your data.");
            }
            else if (userInput.Contains("safe browsing"))
            {
                TypeResponse("\nSafe browsing means avoiding unknown websites, not clicking suspicious links, and using secure connections.");
            }
            else if (userInput.Contains("social engineering"))
            {
                TypeResponse("\nSocial engineering is when someone tricks you into giving away confidential information by pretending to be someone you trust.");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                TypeResponse("\nHmm... I’m not sure about that. Try asking about phishing, passwords, malware");
                Console.ResetColor();
            }
        }
        // typing feature method
        static void TypeResponse(string message, int delay = 25)
        {
            foreach (char c in message)
            {
                Console.Write(c);
                Thread.Sleep(delay); // Delay between characters
            }
            Console.WriteLine(); // New line after the message is typed
        }
    }
}
