
using System;

class Personaje
{
    // Atributos
    private string nombre;
    private int vida;
    private int nivel;
    private int ataque;

    // Constructor sin parámetros
    public Personaje()
    {
        nombre = "Personaje";
        vida = 100;
        nivel = 1;
        ataque = 10;
    }

    // Constructor que recibe solo el nombre
    public Personaje(string nombre)
    {
        this.nombre = nombre;
        vida = 100;
        nivel = 1;
        ataque = 10;
    }

    // Constructor que recibe todos los datos
    public Personaje(string nombre, int vida, int nivel, int ataque)
    {
        this.nombre = nombre;
        this.vida = vida;
        this.nivel = nivel;
        this.ataque = ataque;
    }

    // Muestra la información del personaje
    public void MostrarInformacion()
    {
        Console.WriteLine("Nombre: " + nombre);
        Console.WriteLine("Vida: " + vida);
        Console.WriteLine("Nivel: " + nivel);
        Console.WriteLine("Ataque: " + ataque);
        Console.WriteLine();
    }

    // Recibe daño
    public void RecibirDanio(int cantidad)
    {
        vida = vida - cantidad;

        if (vida < 0)
        {
            vida = 0;
        }

        Console.WriteLine(nombre + " recibió " + cantidad + " puntos de daño.");
    }

    // Cura al personaje
    public void Curar(int cantidad)
    {
        vida = vida + cantidad;

        Console.WriteLine(nombre + " recuperó " + cantidad + " puntos de vida.");
    }

    // Sube de nivel
    public void SubirNivel()
    {
        nivel = nivel + 1;
        ataque = ataque + 5;

        Console.WriteLine(nombre + " subió de nivel.");
    }

    // Ataca a otro personaje
    public void Atacar(Personaje enemigo)
    {
        Console.WriteLine(nombre + " atacó a " + enemigo.nombre + ".");
        enemigo.RecibirDanio(ataque);
    }

    // Retorna la vida actual
    public int ObtenerVida()
    {
        return vida;
    }

    // Comprueba si el personaje está vivo
    public bool EstaVivo()
    {
        if (vida > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Crear tres personajes usando los diferentes constructores
        Personaje kratos = new Personaje();
        Personaje mario = new Personaje("Mario");
        Personaje link = new Personaje("Link", 110, 2, 18);

        Console.WriteLine("=== Estado inicial ===");
        Console.WriteLine();

        Console.WriteLine("Kratos");
        kratos.MostrarInformacion();

        Console.WriteLine("Mario");
        mario.MostrarInformacion();

        Console.WriteLine("Link");
        link.MostrarInformacion();

        Console.WriteLine("=== Combate===");
        Console.WriteLine();

        // Kratos ataca a Mario
        kratos.Atacar(mario);
        Console.WriteLine();

        // Mario ataca a Kratos
        mario.Atacar(kratos);
        Console.WriteLine();

        // Mario se cura
        mario.Curar(20);
        Console.WriteLine();

        // Link sube de nivel
        link.SubirNivel();
        Console.WriteLine();

        Console.WriteLine("=== Estado final ===");
        Console.WriteLine();

        Console.WriteLine("Kratos");
        kratos.MostrarInformacion();

        Console.WriteLine("Mario");
        mario.MostrarInformacion();

        Console.WriteLine("Link");
        link.MostrarInformacion();

        Console.WriteLine("=== Personajes vivos ===");
        Console.WriteLine();

        Console.WriteLine("Kratos está vivo: " + kratos.EstaVivo());
        Console.WriteLine("Mario está vivo: " + mario.EstaVivo());
        Console.WriteLine("Link está vivo: " + link.EstaVivo());

        Console.WriteLine();

        // También podemos obtener la vida de un personaje
        Console.WriteLine("La vida actual de Kratos es: " + kratos.ObtenerVida());
    }
}

