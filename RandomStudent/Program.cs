var students = new[]
{
    "Adrian Gabriel Ozuna Batista",
    "Carmen Miguelina Mata Baez",
    "Daury Jeymer Pérez",
    "Diego Arturo Garcia Velez",
    "Edwin Lestat Díaz Consuegra",
    "Emely Gabriela Rodríguez Santana",
    "Emily Biandra De La Rosa Moquete",
    "Ezequiel Junior Cruz Diaz",
    "Gabriel Arthur Nardi",
    "Hamlet Pavel Sanchez Cruz",
    "Hilel Rodríguez Quezada",
    "Ismael Jeremías Varela Carrasco",
    "Jancarlos Melo Arias",
    "Javier Rafael De Oleo Santana",
    "Jose Enrique Morel Martínez",
    "Kelvin Javier Quezada Anazagatys",
    "Kenji Yohan Abreu Mendez",
    "Lary Francisco Figuereo Sánchez",
    "Miguel Ángel Gónzalez Santana",
    "Reymer Polanco",
    "Ricardo Vladimir Collado Rothschild",
    "Rodolfo Montero Melo",
};

var rnd = new Random();
var index = rnd.Next(0, students.Length);

var chosen = students[index];

Console.WriteLine($"📢 {chosen} is chosen 🗡️");