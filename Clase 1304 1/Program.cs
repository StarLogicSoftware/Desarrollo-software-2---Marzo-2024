
//int resultado = 23;
//string Texto = $"Esto es un texto con este ---: {resultado}";

//string textoCambiado = Texto.Replace("---", "resultado");

//Console.WriteLine(textoCambiado);



// fechas y horas
DateTime fecha = new DateTime(2009,5,21, 21,15,35);
DateTime fechaActual = DateTime.Now.AddDays(-21);

//DateTime fechaModificada =  fechaActual.AddDays(-21);

//fechaActual = fechaModificada;

fechaActual = fechaActual.AddDays(-21);

//Console.WriteLine(fechaActual.ToShortDateString()); // fecha sola
//Console.WriteLine(fechaActual.ToShortTimeString()); // hora sola
//Console.WriteLine(fechaActual.ToLongDateString()); // fecha de forma larga
//Console.WriteLine(fechaActual.ToLongTimeString()); // hora de forma larga

//Console.WriteLine(fechaActual.ToString("dddd yyyy MM FF")); // hora de forma larga

TimeSpan lapsoTiempo = fechaActual - fecha; // lapso de tiempo entre dos fechas

TimeSpan lapsoNuevo = new TimeSpan(2, 5, 40); //lapso creado a mano

Console.WriteLine(lapsoTiempo.TotalDays); // cantidad dias entre dos fechas