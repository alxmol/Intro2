/*
Class: CSE 1322L
Section: W#1
Term: Fall 2024
Instructor: Manosmi Gundu
Name: Alex Molina
Lab#: Assignment4
*/

public interface IMediaStandard
{
    string getMediaInfo();
}

public interface IAudioStandard : IMediaStandard
{
    string getAudioCodec();
}

public interface IImageStandard : IMediaStandard
{
    string getImageCodec();
}

public abstract class Media
{
    private string fileName;
    private int id;
    private static int nextId = 1;

    public Media()
    {
        this.id = nextId;
        nextId++;
    }

    public Media(string fileName) : this()
    {
        this.fileName = fileName;
    }

    public string getFileName()
    {
        return fileName;
    }

    public int getID()
    {
        return id;
    }
}

public class Image : Media, IImageStandard
{
    private string imageCodec;

    public Image(string fileName, string imageCodec) : base(fileName)
    {
        this.imageCodec = imageCodec;
    }

    public string getImageCodec()
    {
        return imageCodec;
    }

    public string getMediaInfo()
    {
        return $"Image ID: {getID()}\nImage Name: {getFileName()}\nImage codec: {getImageCodec()}\n";
    }
}

public class Music : Media, IAudioStandard
{
    private string audioCodec;

    public Music(string fileName, string audioCodec) : base(fileName)
    {
        this.audioCodec = audioCodec;
    }

    public string getAudioCodec()
    {
        return audioCodec;
    }

    public string getMediaInfo()
    {
        return $"Music ID: {getID()}\nMusic Name: {getFileName()}\nAudio codec: {getAudioCodec()}\n";
    }
}

public class Video : Media, IImageStandard, IAudioStandard
{
    private string imageCodec;
    private string audioCodec;

    public Video(string fileName, string imageCodec, string audioCodec) : base(fileName)
    {
        this.imageCodec = imageCodec;
        this.audioCodec = audioCodec;
    }

    public string getImageCodec()
    {
        return imageCodec;
    }

    public string getAudioCodec()
    {
        return audioCodec;
    }

    public string getMediaInfo()
    {
        return $"Video ID: {getID()}\nVideo Name: {getFileName()}\nImage codec: {getImageCodec()}\nAudio codec: {getAudioCodec()}\n";
    }
}

class Assignment4
{
    static void Main(string[] args)
    {
        List<Media> allMedia = new List<Media>();
        bool running = true;

        Console.WriteLine("[Media Manager]\n");
        while (running)
        {
            Console.WriteLine("1-Add Image");
            Console.WriteLine("2-Add Music");
            Console.WriteLine("3-Add Video");
            Console.WriteLine("4-Show images");
            Console.WriteLine("5-Show music");
            Console.WriteLine("6-Show videos");
            Console.WriteLine("7-Show images and videos");
            Console.WriteLine("8-Show music and videos");
            Console.WriteLine("9-Exit");
            Console.Write("Enter option: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.WriteLine();
                    Console.Write("Enter file name: ");
                    string imageName = Console.ReadLine();
                    Console.Write("Enter image codec: ");
                    string imageCodec = Console.ReadLine();
                    allMedia.Add(new Image(imageName, imageCodec));
                    Console.WriteLine();
                    break;

                case "2":
                    Console.WriteLine();
                    Console.Write("Enter file name: ");
                    string musicName = Console.ReadLine();
                    Console.Write("Enter audio codec: ");
                    string audioCodec = Console.ReadLine();
                    allMedia.Add(new Music(musicName, audioCodec));
                    Console.WriteLine();
                    break;

                case "3":
                    Console.WriteLine();
                    Console.Write("Enter file name: ");
                    string videoName = Console.ReadLine();
                    Console.Write("Enter image codec: ");
                    string videoImageCodec = Console.ReadLine();
                    Console.Write("Enter audio codec: ");
                    string videoAudioCodec = Console.ReadLine();
                    allMedia.Add(new Video(videoName, videoImageCodec, videoAudioCodec));
                    Console.WriteLine();
                    break;

                case "4":
                    Console.WriteLine();
                    foreach (var media in allMedia)
                    {
                        if (media is Image imageMedia)
                        {
                            Console.WriteLine(imageMedia.getMediaInfo());
                        }
                    }
                    Console.WriteLine();
                    break;

                case "5":
                    Console.WriteLine();
                    foreach (var media in allMedia)
                    {
                        if (media is Music audioMedia && !(media is Video))
                        {
                            Console.WriteLine(audioMedia.getMediaInfo());
                        }
                    }
                    Console.WriteLine();
                    break;

                case "6":
                    Console.WriteLine();
                    foreach (var media in allMedia)
                    {
                        if (media is Video videMedia)
                        {
                            Console.WriteLine(videMedia.getMediaInfo());
                        }
                    }
                    Console.WriteLine();
                    break;

                case "7":
                    Console.WriteLine();
                    foreach (var media in allMedia)
                    {
                        if (media is IImageStandard imageMedia)
                        {
                            Console.WriteLine(imageMedia.getMediaInfo());
                        }
                    }
                    Console.WriteLine();
                    break;

                case "8":
                    Console.WriteLine();
                    foreach (var media in allMedia)
                    {
                        if (media is IAudioStandard audioMedia)
                        {
                            Console.WriteLine(audioMedia.getMediaInfo());
                        }
                    }
                    Console.WriteLine();
                    break;

                case "9":
                    Console.WriteLine();
                    running = false;
                    Console.WriteLine("Shutting down...");
                    break;

                default:
                    Console.WriteLine();
                    Console.WriteLine("Invalid option.");
                    Console.WriteLine();
                    break;
            }
        }
    }
}