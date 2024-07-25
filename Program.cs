namespace JsonUpdater_Application
{
    internal class Program
    {
        static void Main(string[] args)
        {


            for (int i = 0; i < args.Length; i++)
            {

                if (args[i][0] == '-')
                {
                    switch (args[i])
                    {
                        case ("-add"):
                            {
                                if (i + 3 < args.Length)
                                {
                                    new AddCommand(args[i + 1], args[i + 2], args[i + 3]).Execute();

                                }
                                else Console.WriteLine("Wrong format");

                            }
                            break;
                        case ("-update"):
                            {
                                if (i + 2 < args.Length)
                                {
                                    new UpdateCommand(args[i + 1], args[i + 2]).Execute();

                                }
                                else Console.WriteLine("Wrong format");


                            }
                            break;
                        case ("-get"):
                            {
                                if (i + 1 < args.Length)
                                {
                                    new FindCommand(args[i + 1]).Execute();

                                }
                                else Console.WriteLine("Wrong format");


                            }
                            break;
                        case ("-delete"):
                            {
                                if (i + 1 < args.Length)
                                {
                                    new DeleteCommand(args[i + 1]).Execute();

                                }
                                else Console.WriteLine("Wrong format");


                            }
                            break;
                        case ("-getall"):
                            {
                                new GetAllCommand().Execute();
                            }
                            break;
                    }
                }
                else continue;
            }
            Console.ResetColor();
        }
    }
}