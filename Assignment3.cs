/*
Class: CSE 1322L
Section: W#1
Term: Fall 2024
Instructor: Manosmi Gundu
Name: Alex Molina
Lab#: Assignment3
*/

public abstract class WeatherEvent
{
    private string location;
    private static int nextId = 0;
    private int id;
    private bool active;

    public WeatherEvent(string location, bool active)
    {
        this.location = location;
        this.active = active;
        this.id = nextId;
        nextId++;
    }

    public string GetLocation()
    {
        return location;
    }

    public int GetId()
    {
        return id;
    }

    public bool IsActive()
    {
        return active;
    }

    public void SetLocation(string location)
    {
        this.location = location;
    }

    public void SetActive(bool active)
    {
        this.active = active;
    }

    public override string ToString()
    {
        return $"Weather Event Location: {location}\nid: {id}\nActive: {active}";
    }
}

public abstract class Precipitation : WeatherEvent
{
    private double rateOfFall;

    public Precipitation(string location, bool active, double rateOfFall) : base(location, active)
    {
        if (rateOfFall < 0)
        {
            throw new ArgumentException("Rate of fall cannot be negative.");
        }
        this.rateOfFall = rateOfFall;
    }

    public double GetRateOfFall()
    {
        return rateOfFall;
    }

    public void SetRateOfFall(double rateOfFall)
    {
        if (rateOfFall < 0)
        {
            throw new ArgumentException("Rate of fall cannot be negative.");
        }
        this.rateOfFall = rateOfFall;
    }

    public override string ToString()
    {
        string rateCategory;

        if (rateOfFall < 0.5)
        {
            rateCategory = "Light";
        }
        else if (rateOfFall >= 0.5 && rateOfFall <= 1.5)
        {
            rateCategory = "Medium";
        }
        else
        {
            rateCategory = "Heavy";
        }

        return base.ToString() + $"\nRate of fall: {rateOfFall} in/h ({rateCategory})";
    }
}

public abstract class Obscuration : WeatherEvent
{
    private int visibility;

    public Obscuration(string location, bool active, int visibility) : base(location, active)
    {
        if (visibility < 0)
        {
            throw new ArgumentException("Visibility cannot be negative.");
        }
        this.visibility = visibility;
    }

    public int GetVisibility()
    {
        return visibility;
    }

    public void SetVisibility(int visibility)
    {
        if (visibility < 0)
        {
            throw new ArgumentException("Visibility cannot be negative.");
        }
        this.visibility = visibility;
    }

    public override string ToString()
    {
        string visibilityInfo;

        if (visibility >= 56)
        {
            visibilityInfo = "Normal";
        }
        else
        {
            visibilityInfo = $"{visibility}/8 mi";
        }

        return base.ToString() + $"\nVisibility: {visibilityInfo}";
    }
}

public class Rain : Precipitation
{
    private double dropSize;

    public Rain(string location, bool active, double rateOfFall, double dropSize) : base(location, active, rateOfFall)
    {
        if (dropSize < 0.02)
        {
            throw new ArgumentException("Drop size cannot be less than 0.02 inches.");
        }
        this.dropSize = dropSize;
    }

    public double GetDropSize()
    {
        return dropSize;
    }

    public void SetDropSize(double dropSize)
    {
        if (dropSize < 0.02)
        {
            throw new ArgumentException("Drop size cannot be less than 0.02 inches.");
        }
        this.dropSize = dropSize;
    }

    public override string ToString()
    {
        string dropSizeCategory;

        if (dropSize < 0.066)
        {
            dropSizeCategory = "Small";
        }
        else if (dropSize >= 0.066 && dropSize <= 0.112)
        {
            dropSizeCategory = "Medium";
        }
        else
        {
            dropSizeCategory = "Large";
        }

        return base.ToString() + $"\nDrop size: {dropSize} inches ({dropSizeCategory})";
    }
}

public class Snow : Precipitation
{
    private double temperature;

    public Snow(string location, bool active, double rateOfFall, double temperature) : base(location, active, rateOfFall)
    {
        if (temperature < -459.67 || temperature > 32)
        {
            temperature = 32;
        }
        this.temperature = temperature;
    }

    public double GetTemperature()
    {
        return temperature;
    }

    public void SetTemperature(double temperature)
    {
        if (temperature < -459.67 || temperature > 32)
        {
            temperature = 32;
        }
        this.temperature = temperature;
    }

    public override string ToString()
    {
        return base.ToString() + $"\nTemperature: {temperature}°F";
    }
}

public class Fog : Obscuration
{
    private bool freezingFog;

    public Fog(string location, bool active, int visibility, bool freezingFog) : base(location, active, visibility)
    {
        this.freezingFog = freezingFog;
        SetVisibility(visibility);
    }

    public bool IsFreezingFog()
    {
        return freezingFog;
    }

    public void SetFreezingFog(bool freezingFog)
    {
        this.freezingFog = freezingFog;
    }

    public virtual void SetVisibility(int visibility)
    {
        if (visibility < 1)
        {
            visibility = 1;
        }
        else if (visibility > 4)
        {
            visibility = 4;
        }
        base.SetVisibility(visibility);
    }

    public override string ToString()
    {
        string result = base.ToString();

        if (freezingFog)
        {
            result += "\nALERT! FREEZING FOG!";
        }

        return result;
    }
}

public class Particle : Obscuration
{
    private string particleType;

    public Particle(string location, bool active, int visibility, string particleType) : base(location, active, visibility)
    {
        if (particleType != "Dust" && particleType != "Sand" && particleType != "Ash")
        {
            this.particleType = "Other";
        }
        else
        {
            this.particleType = particleType;
        }
    }

    public string GetParticleType()
    {
        return particleType;
    }

    public void SetParticleType(string particleType)
    {
        if (particleType != "Dust" && particleType != "Sand" && particleType != "Ash")
        {
            this.particleType = "Other";
        }
        else
        {
            this.particleType = particleType;
        }
    }

    public override string ToString()
    {
        return base.ToString() + $"\nParticle type: {particleType}";
    }
}

class Assignment3
{
    static void Main(string[] args)
    {
        List<WeatherEvent> weatherEvents = new List<WeatherEvent>();
        bool running = true;

        Console.WriteLine("[Weather Tracking System]");
        while (running)
        {
            Console.WriteLine("1. Add weather event");
            Console.WriteLine("2. Update location");
            Console.WriteLine("3. Update active");
            Console.WriteLine("4. View all events");
            Console.WriteLine("5. Quit");
            Console.Write("Enter your option: ");
            string option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    AddWeatherEvent(weatherEvents);
                    break;

                case "2":
                    UpdateLocation(weatherEvents);
                    break;

                case "3":
                    UpdateActiveStatus(weatherEvents);
                    break;

                case "4":
                    ViewAllEvents(weatherEvents);
                    break;

                case "5":
                    running = false;
                    Console.WriteLine("Shutting off...");
                    break;

                default:
                    Console.WriteLine("Invalid option!\n");
                    break;
            }
        }
    }

    static void AddWeatherEvent(List<WeatherEvent> weatherEvents)
    {
        Console.WriteLine("\n1. Rain\n2. Snow\n3. Fog\n4. Particle");
        Console.Write("What type of weather event is being added? ");
        string eventType = Console.ReadLine();

        Console.Write("Where is the event happening? ");
        string location = Console.ReadLine();

        bool active = true;

        switch (eventType.ToLower())
        {
            case "1":
                Console.Write("What is the rate of fall? (in/h) ");
                double rateOfFall = double.Parse(Console.ReadLine());

                Console.Write("What is the diameter of the drops? (in) ");
                double dropSize = double.Parse(Console.ReadLine());

                weatherEvents.Add(new Rain(location, active, rateOfFall, dropSize));
                Console.WriteLine("Rain event added\n");
                break;

            case "2":
                Console.Write("What is the rate of fall? (in/h) ");
                rateOfFall = double.Parse(Console.ReadLine());

                Console.Write("What is the temperature? (F) ");
                double temperature = double.Parse(Console.ReadLine());

                weatherEvents.Add(new Snow(location, active, rateOfFall, temperature));
                Console.WriteLine("Snow event added\n");
                break;

            case "3":
                Console.Write("What is the visibility? (1/8 mi): ");
                int visibility = int.Parse(Console.ReadLine());

                Console.Write("Is the fog freezing? (y/n): ");
                string yesNo = Console.ReadLine();
                bool freezingFog;
                if (yesNo.Equals("y"))
                    freezingFog = true;
                else
                    freezingFog = false;

                weatherEvents.Add(new Fog(location, active, visibility, freezingFog));
                Console.WriteLine("Fog event added\n");
                break;

            case "4":
                Console.Write("What is the visibility? (1/8 mi) ");
                visibility = int.Parse(Console.ReadLine());

                Console.Write("What is the obscuration made of? (Dust/Sand/Ash/Other): ");
                string particleType = Console.ReadLine();

                weatherEvents.Add(new Particle(location, active, visibility, particleType));
                Console.WriteLine("Particle event added\n");
                break;

            default:
                Console.WriteLine("Invalid weather event type.\n");
                break;
        }
    }

    static void UpdateLocation(List<WeatherEvent> weatherEvents)
    {
        Console.Write("Enter id of weather event ");
        int id = int.Parse(Console.ReadLine());

        WeatherEvent we = weatherEvents.Find(e => e.GetId() == id);

        if (we != null)
        {
            string oldLocation = we.GetLocation();
            Console.Write($"Enter the new location of weather event (currently \"{oldLocation}\"): ");
            string newLocation = Console.ReadLine();
            we.SetLocation(newLocation);
            Console.WriteLine("Location updated\n");
        }
        else
        {
            Console.WriteLine("No event with that id.\n");
        }
    }

    static void UpdateActiveStatus(List<WeatherEvent> weatherEvents)
    {
        Console.Write("Enter id of weather event: ");
        int id = int.Parse(Console.ReadLine());

        WeatherEvent we = weatherEvents.Find(e => e.GetId() == id);

        if (we != null)
        {
            we.SetActive(!we.IsActive());
            Console.WriteLine("Event set to \"inactive\"\n");
        }
        else
        {
            Console.WriteLine("No event with that id.\n");
        }
    }

    static void ViewAllEvents(List<WeatherEvent> weatherEvents)
    {
        foreach (WeatherEvent we in weatherEvents)
        {
            Console.WriteLine();
            Console.WriteLine(we.ToString());
            Console.WriteLine();
        }
    }
}