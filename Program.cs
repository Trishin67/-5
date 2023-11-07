using System;
using System.Collections.Generic;

// Задача 1: Животные и метод PetAnimal
interface IAnimal
{
    void Voice();
}

class Dog : IAnimal
{
    public void Voice()
    {
        Console.WriteLine("Гав!");
    }
}

class Cat : IAnimal
{
    public void Voice()
    {
        Console.WriteLine("Мяу!");
    }
}

class Owl : IAnimal
{
    private int GetCurrentTime()
    {
        return Convert.ToInt32(DateTime.Now.ToString("HH"));
    }

    public void Voice()
    {
        int currentTime = GetCurrentTime();
        if (currentTime >= 8 && currentTime <= 20)
        {
            Console.WriteLine("Тише, я сплю!");
        }
        else
        {
            Console.WriteLine("Ух! Ух! Ух!");
        }
    }
}

class Parrot : IAnimal
{
    public void Voice()
    {
        Console.WriteLine("Попугай говорит: Привет!");
    }
}

class Cow : IAnimal
{
    public void Voice()
    {
        Console.WriteLine("Мууу!");
    }
}

// Задача 2: Приветствие на разных языках
interface IHello
{
    void SayHello();
}

class EnglishHello : IHello
{
    public void SayHello()
    {
        Console.WriteLine("Hello");
    }
}

class FrenchHello : IHello
{
    public void SayHello()
    {
        Console.WriteLine("Bonjour");
    }
}

class SpanishHello : IHello
{
    public void SayHello()
    {
        Console.WriteLine("Hola");
    }
}

// Задача 3: Фильтры
interface IFilter
{
    string Execute(string textLine);
}

class DigitFilter : IFilter
{
    public string Execute(string textLine)
    {
        return new string(textLine.Where(c => !char.IsDigit(c)).ToArray());
    }
}

class LetterFilter : IFilter
{
    public string Execute(string textLine)
    {
        return new string(textLine.Where(c => !char.IsLetter(c)).ToArray());
    }
}

// Задача 4: Рисование фигур
interface IShape
{
    void Draw(int size);
}

class VerticalLine : IShape
{
    public void Draw(int size)
    {
        for (int i = 0; i < size; i++)
        {
            Console.WriteLine("|");
        }
    }
}

class HorizontalLine : IShape
{
    public void Draw(int size)
    {
        for (int i = 0; i < size; i++)
        {
            Console.Write("-");
        }
        Console.WriteLine();
    }
}

class Square : IShape
{
    public void Draw(int size)
    {
        for (int i = 0; i < size; i++)
        {
            Console.WriteLine(new string('*', size));
        }
    }
}

// Задача 5: Волшебники
interface ISpellcaster
{
    void CastSpell(string spellName);
}

class Wizard : ISpellcaster
{
    private int mana = 10;

    public void CastSpell(string spellName)
    {
        if (mana >= 5)
        {
            Console.WriteLine($"Волшебник колдует! Эффект от заклинания '{spellName}'");
            mana -= 5;
        }
        else
        {
            Console.WriteLine($"Для использования '{spellName}' не хватает {5 - mana} единиц маны. Пейте зелья!");
        }
    }
}

class Warlock : ISpellcaster
{
    private int mana = 15;

    public void CastSpell(string spellName)
    {
        if (mana >= 8)
        {
            Console.WriteLine($"Чернокнижник колдует! Эффект от заклинания '{spellName}'");
            mana -= 8;
        }
        else
        {
            Console.WriteLine($"Для использования '{spellName}' не хватает {8 - mana} единиц маны. Пейте зелья!");
        }
    }
}

class Program
{
    static void PetAnimal(IAnimal animal)
    {
        Console.Write("Мы гладим зверюшку, а она нам говорит: ");
        animal.Voice();
    }

    static void Main()
    {
        // Задача 1: Погладим разных животных
        List<IAnimal> animals = new List<IAnimal>
        {
            new Dog(),
            new Cat(),
            new Owl(),
            new Parrot(),
            new Cow()
        };

        foreach (IAnimal animal in animals)
        {
            PetAnimal(animal);
        }

        // Задача 2: Приветствие на разных языках
        List<IHello> greetings = new List<IHello>
        {
            new EnglishHello(),
            new FrenchHello(),
            new SpanishHello()
        };
        foreach (IHello greeting in greetings)
        {
            greeting.SayHello();
        }

        // Задача 3: Фильтры
        IFilter digitFilter = new DigitFilter();
        IFilter letterFilter = new LetterFilter();

        string text = "Hello123World";
        Console.WriteLine($"Original Text: {text}");
        Console.WriteLine($"After Digit Filter: {digitFilter.Execute(text)}");
        Console.WriteLine($"After Letter Filter: {letterFilter.Execute(text)}");

        // Задача 4: Рисование фигур
        List<IShape> shapes = new List<IShape>
        {
            new VerticalLine(),
            new HorizontalLine(),
            new Square()
        };

        foreach (IShape shape in shapes)
        {
            shape.Draw(5);
        }

        // Задача 5: Волшебники
        ISpellcaster wizard = new Wizard();
        ISpellcaster warlock = new Warlock();

        wizard.CastSpell("Fireball");
        warlock.CastSpell("Shadow Bolt");
        wizard.CastSpell("Ice Lance");
    }
}