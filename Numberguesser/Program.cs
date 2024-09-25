using System.ComponentModel.Design;

int guess;
int min = 1;
int max = 100;
int abfrage;

Random rnd = new Random();                                                 /*hier rufe ich die Klasse "Random"
                                                                           auf und erstelle ein Objekt mit dieser Klasse*/
int guesses = 0;

Console.WriteLine("Wilkommen zum Numberguesser!");


    repeat:
    Console.Write("Möchtest du die Standardvariante von 1-100 spielen? Antworte mit '1' für die Standard- und mit '2' für die Costumvariante   ");
    string eingabe = Console.ReadLine();
    int.TryParse(eingabe, out abfrage);

//Der folgende Code ist nur für das Feature "Costumvariante"

if (abfrage == 2)                                                       //Wenn der Spieler die Abfrage mit "2" beantwortet, dann wird die "Costumvariante" ausgeführt.
    {
        Console.WriteLine("In diesem Modus kannst du die Mindest- und Höchstzahl selbst bestimmen");
        bool exception;
        do
        {

            Console.Write("Nenne mir die Mindestzahl ");
            string eingabe1 = Console.ReadLine();
            if (int.TryParse(eingabe1, out min))

            {
                exception = true;

            }
            else
            {
                Console.WriteLine("Deine Eingabe ist ungültig");
                exception = false;
            }
        }
        while (exception == false);


        do
        {
            do
            {
                Console.Write("Nenne mir die Höchstzahl ");
                string eingabe2 = Console.ReadLine();
                if (int.TryParse(eingabe2, out max))
                {

                    exception = true;

                }
                else
                {
                    exception = false;
                    Console.WriteLine("Deine Eingabe ist ungültig");
                }

            } while (exception == false);

            if (max <= min)                                                 //Hier prüfe ich ob der max wert kleiner oder gleich dem min Wert ist.
            {
                exception = false;
                Console.WriteLine("Der Max Wert ist kleiner oder gleich dem Min Wert");
            }

        }
        while (exception == false);
    }

    else if (abfrage <= 0 || abfrage >= 3)                                   /*Wenn der Spieler bei der Abfrage des Spielmodis nicht "1" oder "2" eingegeben hat,
                                                                             dann springt das Programm wieder zur Abfrage*/
    {
        Console.WriteLine("Deine Eingabe ist ungültig");
        goto repeat;
       
    }
                                                                            //Hat der Spieler bei der Abfrage 1 gewählt, dann wird das Hauptprogramm ausgeführt

int number = rnd.Next(min, max + 1);                                       /*"number" ist gleich die variable "rnd",
                                                                            die die vordefinierte Methode "Next" ausführt*/

//Es folgt das Hauptprogramm

do
{
    Console.Write("Gebe deine Zahl zwischen {0} und {1} ein: ", min, max); //Die Zahlen in den Klammern sind gleich "min" und "max"
    string eingabe2 = Console.ReadLine();

    if (int.TryParse(eingabe2, out guess))
    {
        guesses++;

        if (guess == number)                                               //number ist die gesuchte Zahl, Guess ist die Eingabe des Spielers.
        {
            Console.WriteLine("");
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
        
        Console.WriteLine("Deine Eingabe ist ungültig");
    }

    Console.WriteLine();
}
while (guess != number);