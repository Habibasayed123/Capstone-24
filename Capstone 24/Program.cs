using ProjectCapstone;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ProjectCapstone
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome To Eva Training Log");
            User user = AuthenticateUser();

            if (user != null)
            {
                if (user is Trainer)
                {
                    Trainer trainer = (Trainer)user;
                    trainer.TakeQuizzes();
                }
                else if (user is Manager)
                {
                    Manager manager = (Manager)user;
                    manager.ShowAssessments();
                }
            }
            else
            {
                Console.WriteLine("Sorry, there is an error.");
            }

            Console.ReadLine();
        }

        static User AuthenticateUser()
        {
            while (true)
            {
                Console.WriteLine("Enter The Email:");
                string email = Console.ReadLine();
                Console.WriteLine("Enter The Password:");
                int password = int.Parse(Console.ReadLine());

                if (email == "training@gmail.com" && password == 1234)
                {
                    Console.WriteLine("Login Success.");
                    break;
                }
                else
                {
                    Console.WriteLine("Login Failed.");
                    Console.WriteLine("Please Try Again.");
                }
            }

            Console.WriteLine("Choose 1 if you are a Trainer or 2 if you are a Manager:");
            int role = int.Parse(Console.ReadLine());

            if (role == 1)
            {
                return new Trainer();
            }
            else if (role == 2)
            {
                return new Manager();
            }
            else
            {
                return null;
            }
        }
    }

    abstract class User
    {
        public string Name { get; set; }
        public int ID { get; set; }
        public string Section { get; set; }

        protected User()
        {
            Console.WriteLine("Enter your name:");
            Name = Console.ReadLine();
            Console.WriteLine("Enter your ID:");
            ID = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter your Section:");
            Section = Console.ReadLine();
            Console.WriteLine("Loading...");
            Thread.Sleep(4000);
        }
    }

    class Trainer : User
    {
        private List<Quiz> quizzes = new List<Quiz>();

        public Trainer()
        {
            InitializeQuizzes();
        }

        public void TakeQuizzes()
        {
            foreach (var quiz in quizzes)
            {
                quiz.StartQuiz();
            }

            Console.WriteLine("Congratulations <3, this is your result");
            Console.WriteLine($"We certify that {Name} completed the course successfully, the duration of the course was... The content of the course was...");
            Console.WriteLine("The date = .../ .../ ...");
            Console.WriteLine("Responsible Supervisor              Company stamp");
        }

        private void InitializeQuizzes()
        {
            quizzes.Add(new Quiz("OOP Basics", GenerateOOPBasicsQuestions()));
            quizzes.Add(new Quiz("OOP Principles", GenerateOOPPrinciplesQuestions()));
            quizzes.Add(new Quiz("C# Basics", GenerateCSharpBasicsQuestions()));
            quizzes.Add(new Quiz("Advanced C#", GenerateAdvancedCSharpQuestions()));
            quizzes.Add(new Quiz("OOP and C# Integration", GenerateOOPCSharpIntegrationQuestions()));
        }

        private List<Question> GenerateOOPBasicsQuestions()
        {
            return new List<Question>
            {
                new Question("What does OOP stand for?", "Object-Oriented Programming", new List<string> { "Object-Oriented Programming", "Object-Observant Programming", "Objective-Oriented Programming", "Object-Operating Programming" }),
                new Question("Which of the following is not a principle of OOP?", "Abstraction", new List<string> { "Abstraction", "Encapsulation", "Polymorphism", "Overloading" }),
                new Question("What is the process of hiding the internal implementation details of an object?", "Encapsulation", new List<string> { "Encapsulation", "Abstraction", "Inheritance", "Polymorphism" }),
                new Question("What is it called when an object has multiple forms?", "Polymorphism", new List<string> { "Polymorphism", "Inheritance", "Encapsulation", "Abstraction" }),
                new Question("What allows a class to inherit members of another class?", "Inheritance", new List<string> { "Inheritance", "Encapsulation", "Abstraction", "Polymorphism" }),
                new Question("What is the blueprint from which objects are created?", "Class", new List<string> { "Class", "Object", "Method", "Property" }),
                new Question("Which keyword is used to create an object in C#?", "new", new List<string> { "new", "create", "init", "construct" }),
                new Question("What is a single instance of a class called?", "Object", new List<string> { "Object", "Class", "Method", "Property" }),
                new Question("What term describes a function or method defined inside a class?", "Method", new List<string> { "Method", "Property", "Field", "Object" }),
                new Question("Which keyword in C# is used to define a class?", "class", new List<string> { "class", "define", "type", "structure" })
            };
        }

        private List<Question> GenerateOOPPrinciplesQuestions()
        {
            return new List<Question>
            {
                new Question("What is the principle of wrapping data and methods into a single unit?", "Encapsulation", new List<string> { "Encapsulation", "Inheritance", "Polymorphism", "Abstraction" }),
                new Question("What allows objects to be treated as instances of their parent class?", "Polymorphism", new List<string> { "Polymorphism", "Inheritance", "Encapsulation", "Abstraction" }),
                new Question("What principle involves using simpler interfaces to interact with complex systems?", "Abstraction", new List<string> { "Abstraction", "Encapsulation", "Inheritance", "Polymorphism" }),
                new Question("What is the ability of an object to take many forms?", "Polymorphism", new List<string> { "Polymorphism", "Inheritance", "Encapsulation", "Abstraction" }),
                new Question("What principle involves a child class inheriting characteristics of a parent class?", "Inheritance", new List<string> { "Inheritance", "Encapsulation", "Polymorphism", "Abstraction" }),
                new Question("Which access modifier in C# makes a member accessible only within its own class?", "private", new List<string> { "private", "public", "protected", "internal" }),
                new Question("Which keyword is used to prevent a class from being inherited?", "sealed", new List<string> { "sealed", "static", "abstract", "final" }),
                new Question("What principle promotes the reuse of existing code?", "Inheritance", new List<string> { "Inheritance", "Encapsulation", "Polymorphism", "Abstraction" }),
                new Question("What keyword in C# is used to define a method that must be overridden?", "abstract", new List<string> { "abstract", "virtual", "override", "sealed" }),
                new Question("Which keyword in C# is used to provide a new implementation of an inherited method?", "override", new List<string> { "override", "virtual", "new", "abstract" })
            };
        }

        private List<Question> GenerateCSharpBasicsQuestions()
        {
            return new List<Question>
            {
                new Question("Which of the following is a value type in C#?", "int", new List<string> { "int", "string", "object", "delegate" }),
                new Question("Which of the following is a reference type in C#?", "string", new List<string> { "string", "int", "bool", "char" }),
                new Question("What keyword is used to create a constant in C#?", "const", new List<string> { "const", "readonly", "static", "final" }),
                new Question("Which keyword is used for inheritance in C#?", ":", new List<string> { ":", "->", "extends", "implements" }),
                new Question("What is the default value of a boolean in C#?", "false", new List<string> { "false", "true", "0", "null" }),
                new Question("Which of the following is the entry point of a C# program?", "Main", new List<string> { "Main", "Start", "Begin", "Entry" }),
                new Question("Which operator is used for string concatenation in C#?", "+", new List<string> { "+", "&", "&&", "." }),
                new Question("Which keyword is used to define a namespace in C#?", "namespace", new List<string> { "namespace", "package", "module", "class" }),
                new Question("What keyword is used to define an enumeration in C#?", "enum", new List<string> { "enum", "enumeration", "list", "array" }),
                new Question("Which of the following is not a loop construct in C#?", "foreach", new List<string> { "foreach", "for", "while", "loop" })
            };
        }

        private List<Question> GenerateAdvancedCSharpQuestions()
        {
            return new List<Question>
            {
                new Question("Which keyword is used to define a lambda expression in C#?", "=>", new List<string> { "=>", "->", "=>", "->>" }),
                new Question("What is the main purpose of delegates in C#?", "To encapsulate a method", new List<string> { "To encapsulate a method","To define a class", "To create an object", "To declare a variable" }),
                new Question("What is the purpose of the 'using' directive in C#?", "To import namespaces", new List<string> { "To import namespaces", "To declare variables", "To define classes", "To create objects" }),
                new Question("What is the difference between 'ref' and 'out' parameters in C#?", "The 'out' parameter does not need to be initialized before being passed to the method", new List<string> { "The 'out' parameter does not need to be initialized before being passed to the method", "The 'ref' parameter must be initialized before being passed to the method", "The 'ref' parameter is passed by value, while the 'out' parameter is passed by reference", "There is no difference between 'ref' and 'out' parameters" }),
                new Question("Which keyword is used to prevent a method from being overridden in derived classes?", "sealed", new List<string> { "sealed", "virtual", "override", "abstract" }),
                new Question("What is the purpose of the 'base' keyword in C#?", "To access members of the base class", new List<string> { "To access members of the base class", "To declare a base class", "To create a new instance of a class", "To specify the base address of an array" }),
                new Question("What is the purpose of the 'this' keyword in C#?", "To refer to the current instance of the class", new List<string> { "To refer to the current instance of the class", "To access static members of the class", "To create a new instance of the class", "To declare a method" }),
                new Question("Which of the following is not a valid access modifier in C#?", "friendly", new List<string> { "friendly", "public", "protected", "private" }),
                new Question("What is the purpose of the 'static' keyword in C#?", "To define members that belong to the class itself, rather than to instances of the class", new List<string> { "To define members that belong to the class itself, rather than to instances of the class", "To prevent a class from being instantiated", "To define a constant", "To allow a method to be overridden in derived classes" }),
                new Question("What is the purpose of the 'abstract' keyword in C#?", "To define a class or method that must be implemented by derived classes", new List<string> { "To define a class or method that must be implemented by derived classes", "To prevent a class from being inherited", "To define a constant", "To prevent a method from being overridden" })
            };
        }

        private List<Question> GenerateOOPCSharpIntegrationQuestions()
        {
            return new List<Question>
            {
                new Question("What is the relationship between a class and an object in C#?", "An object is an instance of a class", new List<string> { "An object is an instance of a class", "A class is an instance of an object", "A class is a blueprint for an object", "An object is a blueprint for a class" }),
                new Question("How does inheritance relate to object-oriented programming in C#?", "It allows one class to inherit properties and methods from another class", new List<string> { "It allows one class to inherit properties and methods from another class", "It allows one object to inherit properties and methods from another object", "It allows one object to contain another object", "It allows one class to contain another class" }),
                new Question("What is the role of polymorphism in object-oriented programming?", "It allows objects of different types to be treated as objects of a common type", new List<string> { "It allows objects of different types to be treated as objects of a common type", "It allows objects to be encapsulated within other objects", "It allows objects to be inherited from multiple classes", "It allows objects to contain other objects" }),
                new Question("How does encapsulation contribute to data hiding in C#?", "It allows the internal details of an object to be hidden from the outside world", new List<string> { "It allows the internal details of an object to be hidden from the outside world", "It allows objects to be inherited from multiple classes", "It allows objects of different types to be treated as objects of a common type", "It allows one object to contain another object" }),
                new Question("What is the purpose of constructors in C#?", "To initialize the state of an object", new List<string> { "To initialize the state of an object", "To define the behavior of a class", "To provide a way to access private members of a class", "To create a new instance of a class" }),
                new Question("How does abstraction help in simplifying complex systems in C#?", "It hides the complex implementation details and provides a simpler interface", new List<string> { "It hides the complex implementation details and provides a simpler interface", "It allows one class to contain another class", "It allows objects to be inherited from multiple classes", "It allows one object to contain another object" }),
                new Question("What is the difference between an interface and a class in C#?", "An interface defines a contract for behavior, while a class provides an implementation of that behavior", new List<string> { "An interface defines a contract for behavior, while a class provides an implementation of that behavior", "An interface can contain fields, while a class cannot", "A class can inherit from multiple interfaces, while it can inherit from only one class", "An interface cannot contain methods, while a class can" }),
                new Question("How does C# support multiple inheritance?", "C# does not support multiple inheritance of classes, but it does support multiple inheritance of interfaces", new List<string> { "C# does not support multiple inheritance of classes, but it does support multiple inheritance of interfaces", "C# allows a class to inherit from multiple classes using a special syntax", "C# automatically resolves conflicts when multiple classes are inherited", "C# provides a built-in mechanism for mixing and matching class members from multiple classes" }),
                new Question("What is the role of access modifiers in C#?", "To control the visibility and accessibility of class members", new List<string> { "To control the visibility and accessibility of class members", "To define the behavior of a class", "To provide a way to access private members of a class", "To create a new instance of a class" }),
                new Question("What is the purpose of the 'base' keyword in C# constructors?", "To call a constructor of the base class", new List<string> { "To call a constructor of the base class", "To access the current instance of a class", "To define the behavior of a class", "To create a new instance of a class" })
            };
        }
    }

    class Quiz
    {
        public string Name { get; set; }
        public List<Question> Questions { get; set; }

        public Quiz(string name, List<Question> questions)
        {
            Name = name;
            Questions = questions;
        }

        public void StartQuiz()
        {

            Console.WriteLine("Please Answer the following questions:");

            int score = 0;
            foreach (var question in Questions)
            {
                Console.WriteLine(question.Text);
                for (int i = 0; i < question.Options.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {question.Options[i]}");
                }
                Console.Write("Your answer: ");
                int userAnswerIndex = int.Parse(Console.ReadLine()) - 1;

                if (question.Options[userAnswerIndex] == question.CorrectAnswer)
                {
                    Console.WriteLine("Correct!");
                    score++;
                }
                else
                {
                    Console.WriteLine("Incorrect!");
                }
            }

            Console.WriteLine($"You get {score} out of {Questions.Count} in the Quiz.");
        }
    }

    class Question
    {
        public string Text { get; }
        public string CorrectAnswer { get; }
        public List<string> Options { get; }

        public Question(string text, string correctAnswer, List<string> options)
        {
            Text = text;
            CorrectAnswer = correctAnswer;
            Options = options;
        }
    }

    class Manager : User
    {
        public void ShowAssessments()
        {
            Console.WriteLine("The assessment is:");
            Thread.Sleep(1000);
            Console.WriteLine("habiba@gmail.com = 5 stars");
            Thread.Sleep(1000);
            Console.WriteLine("mazen@gmail.com = 4.5 stars");
            Thread.Sleep(1000);
            Console.WriteLine("dodo@gmail.com = 4 stars");
            Thread.Sleep(1000);
            Console.WriteLine("zena@gmail.com = 4.5 stars");
            Thread.Sleep(1000);
            Console.WriteLine("ahmed@gmail.com = 2.5 stars");
            Thread.Sleep(1000);
        }
    }
}
