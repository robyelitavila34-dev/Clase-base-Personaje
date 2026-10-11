
using System;

// INTERFAZ PARA CURARSE
public interface ICurable
{
    void Curar();
}

// INTERFAZ PARA DEFENDERSE
public interface IDefendible
{
    void Defender();
}

// CLASE ABSTRACTA PERSONAJE
public abstract class Personaje
{
    public string Nombre { get; private set; }
    public int Vida { get; private set; }
    public int Nivel { get; private set; }

    public Personaje(string nombre, int vida, int nivel)
    {
        if (vida < 1 || vida > 100)
        {
            throw new ArgumentException("La vida debe estar entre 1 y 100.");
        }

        if (nivel < 1)
        {
            throw new ArgumentException("El nivel debe ser minimo 1.");
        }

        Nombre = nombre;
        Vida = vida;
        Nivel = nivel;
    }

    public void MostrarEstado()
    {
        Console.WriteLine("Nombre: " + Nombre);
        Console.WriteLine("Vida: " + Vida);
        Console.WriteLine("Nivel: " + Nivel);
    }

    public abstract void Atacar();

    public void RecibirDanio(int cantidad)
    {
        if (cantidad <= 0 || Vida == 0)
        {
            return;
        }

        Console.WriteLine(Nombre + " recibe " + cantidad + " puntos de daño.");

        Vida = Vida - cantidad;

        if (Vida < 0)
        {
            Vida = 0;
        }

        Console.WriteLine("Vida restante: " + Vida);

        if (Vida == 0)
        {
            Console.WriteLine(Nombre + " ha sido derrotado.");
        }
    }

    public void RecuperarVida(int cantidad)
    {
        if (cantidad <= 0 || Vida == 100)
        {
            return;
        }

        Vida = Vida + cantidad;

        if (Vida > 100)
        {
            Vida = 100;
        }
    }
}

// CLASE GUERRERO
public class Guerrero : Personaje, IDefendible
{
    public int Fuerza { get; set; }

    public Guerrero(string nombre, int vida, int nivel, int fuerza)
        : base(nombre, vida, nivel)
    {
        Fuerza = fuerza;
    }

    public override void Atacar()
    {
        Console.WriteLine(Nombre + " ataca con su espada causando 30 puntos de daño.");
    }

    public void Defender()
    {
        Console.WriteLine(Nombre + " levanta su escudo y se prepara para defenderse.");
    }
}

// CLASE MAGO
public class Mago : Personaje, ICurable
{
    public int Mana { get; set; }

    public Mago(string nombre, int vida, int nivel, int mana)
        : base(nombre, vida, nivel)
    {
        Mana = mana;
    }

    public override void Atacar()
    {
        Console.WriteLine(Nombre + " lanza un hechizo causando 40 puntos de daño.");
    }

    public void Curar()
    {
        int vidaAntes = Vida;

        if (Vida == 100)
        {
            Console.WriteLine(Nombre + " ya tiene la vida completa.");
            return;
        }

        RecuperarVida(20);

        Console.WriteLine(Nombre + " utiliza magia de curacion.");
        Console.WriteLine("Vida recuperada: " + (Vida - vidaAntes));
        Console.WriteLine("Vida actual: " + Vida);
    }
}

// CLASE ARQUERO
public class Arquero : Personaje
{
    public int Flechas { get; private set; }

    public Arquero(string nombre, int vida, int nivel, int flechas)
        : base(nombre, vida, nivel)
    {
        if (flechas < 0)
        {
            throw new ArgumentException("Las flechas no pueden ser negativas.");
        }

        Flechas = flechas;
    }

    public override void Atacar()
    {
        if (Flechas == 0)
        {
            Console.WriteLine(Nombre + " no tiene flechas para disparar.");
            return;
        }

        Console.WriteLine(Nombre + " dispara una flecha causando 25 puntos de daño.");

        Flechas = Flechas - 1;

        Console.WriteLine("Flechas restantes: " + Flechas);
    }
}

// PROGRAMA PRINCIPAL
class Program
{
    static void Main(string[] args)
    {
        Guerrero guerrero = new Guerrero("Kratos", 100, 5, 30);
        Mago mago = new Mago("Merlin", 80, 6, 50);
        Arquero arquero = new Arquero("Legolas", 90, 4, 10);

        Personaje[] personajes = { guerrero, mago, arquero };

        Console.WriteLine("===== PERSONAJES =====");
        Console.WriteLine();

        foreach (Personaje personaje in personajes)
        {
            personaje.MostrarEstado();
            personaje.Atacar();

            Console.WriteLine("--------------------");
            Console.WriteLine();
        }

        Console.WriteLine("===== HABILIDADES =====");
        Console.WriteLine();

        guerrero.Defender();

        Console.WriteLine();

        mago.RecibirDanio(30);

        Console.WriteLine();

        mago.Curar();

        Console.WriteLine();

        Console.WriteLine("===== PRUEBA DEL ARQUERO =====");

        for (int i = 0; i < 11; i++)
        {
            arquero.Atacar();
        }

        Console.WriteLine();

        Console.WriteLine("===== PRUEBA DE DAÑO =====");

        guerrero.RecibirDanio(30);
    }
}
