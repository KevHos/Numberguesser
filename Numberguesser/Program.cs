using System.ComponentModel.Design;

int guess;
int min = 1;
int max = 100;
int abfrage;

Random rnd = new Random();                /*hier rufe ich die Klasse "Random"
                                          auf und erstelle ein Objekt mit dieser Klasse*/
int guesses = 0;

Console.WriteLine("Wilkommen zum Numberguesser!");

//Der folgende Code ist nur für das Zusatzfeature "Eigene Zahlen"

do
{
    Console.Write("Möchtest du die Standardvariante von 1-100 spielen? Antworte mit '1' Ja oder '2' für Nein   ");
    string eingabe = Console.ReadLine();
    int.TryParse(eingabe, out abfrage);
    
    
    if (abfrage == 2)
    {
        Console.WriteLine("In diesem Modus kannst du die Mindest- und Höchstzahl selbst bestimmen");
        abfrage = 1;
        bool exception;
        do
        {
            Console.Write("Nenne mir die Mindestzahl ");
            string eingabe1 = Console.ReadLine();
            if(int.TryParse(eingabe1, out min))
          
            {
                exception = true;
                
            }
            else
            {
                Console.WriteLine("Dein Wert ist ungültig");
                exception = false;
            }
        }
        while (exception == false);


        do 
        {
            Console.Write("Nenne mir die Höchstzahl ");
            string eingabe2 = Console.ReadLine();
            if(int.TryParse(eingabe2, out max))
            {

                exception = true;
                
            }
            else
            {
                Console.WriteLine("Dein Wert ist ungültig");
                exception = false;
            }
            if(max <= min)                      //Hier checke ich ob der max wert kleiner als der min Wert ist.
            {
                exception = false;
                Console.WriteLine("Der Max Wert ist kleiner oder gleich dem Min Wert");
            }
        }
        while (exception == false);
    }

    else if (abfrage != 1)
    {
        Console.WriteLine("Dein Wert ist ungültig");
       
    }
} while (abfrage != 1);

int number = rnd.Next(min, max + 1);  /*"number" ist gleich die variable "rnd",
                                      die die vordefinierte Methode "Next" ausführt*/

//Es folgt das Hauptprogramm

do
{
    Console.Write("Gebe deine Zahl zwischen {0} und {1} ein: ", min, max); //Die Zahlen in den Klammern sind gleich "min" und "max"
    string eingabe = Console.ReadLine();

    if (int.TryParse(eingabe, out guess))
    {
        guesses++;

        if (guess == number)  //number ist die gesuchte Zahl, Guess ist die Eingabe des Spielers.
        {
            Console.WriteLine("RICHTIG! Die Zahl war " + number);
            Console.WriteLine("Du hast {0} Versuche gebraucht!", guesses); //Guesses ist die Anzahl der Versuche des Spielers, die durch die Schleife jedes mal erhöht wird
        }
        else if (guess > number)
        {
            Console.WriteLine("Die Zahl ist kleiner als " + guess);
        }
        else if (guess < number)
        {
            Console.WriteLine("Die Zahl ist größer als " + guess);
        }
    }
    else
    {
        Console.WriteLine("");
        Console.WriteLine("Deine Eingabe ist ungültig");
    }
    Console.WriteLine();
}
while (guess != number);