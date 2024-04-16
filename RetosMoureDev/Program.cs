using RetosMoureDev;
using RetosMoureDev.Ejercicios;
using RetosMoureDev.Models;
using RetosMoureDev.Models.Poligonos;

#region Ejercicio 1 - Fizz Buzz
//Ejercicios1a20.N1();
#endregion

#region Ejercicio 2 - ¿Es un anagrama?
//Ejercicios1a20.N2("aba", "aab");
#endregion

#region Ejercicio 3 - La sucesion de Fibonacci
//Ejercicios1a20.N3();
#endregion

#region Ejercicio 4 - ¿Es un numero primo?
//Ejercicios1a20.N4();
#endregion

#region Ejercicio 5 - Area de un poligono
//Ejercicios1a20.N5(new Triangulo(2, 5));
//Ejercicios1a20.N5(new Cuadrado(2));
//Ejercicios1a20.N5(new Rectangulo(2, 5));
#endregion

#region Ejercicio 6 - Aspect ratio de una imagen
//await Ejercicios1a20.N6("https://i.pinimg.com/originals/8e/51/30/8e51302d51089d0f234dc16314c4e5b6.jpg");
#endregion

#region Ejercicio 7 - Invirtiendo cadenas
//Ejercicios1a20.N7("Hola mundo!");
#endregion

#region Ejercicio 8 - Contando palabras
//Ejercicios1a20.N8("Hola, mi nombre es mac. Mi nombre completo es mac y nada mas (macisnotcoding).");
#endregion

#region Ejercicio 9 - Transformar numero decimal a binario
//Ejercicios1a20.N9(10);
#endregion

#region Ejercicio 10 - Codigo Morse
//Ejercicios1a20.N10("¡Este es un mensaje de prueba!");
//Ejercicios1a20.N10("¡ . ... - .   . ...   ..- -.   -- . -. ... .- .--- .   -.. .   .--. .-. ..- . -... .- !");
#endregion

#region Ejercicio 11 - Expresiones equilibradas
//Ejercicios1a20.N11("{a + b [c] * (2x2)}}}}");
//Ejercicios1a20.N11("{ [ a * ( c + d ) ] - 5 }");
//Ejercicios1a20.N11("{ a * ( c + d ) ] - 5 }");
//Ejercicios1a20.N11("{a^4 + (((ax4)}");
//Ejercicios1a20.N11("{ ] a * ( c + d ) + ( 2 - 3 )[ - 5 }");
//Ejercicios1a20.N11("{{{{{{(}}}}}}");
//Ejercicios1a20.N11("(a");
//Ejercicios1a20.N11("([{aaa}])");
#endregion

#region Ejercicio 12 - Mezclando letras en cadenas
//Ejercicios1a20.N12("pepe", "palotes");
#endregion

#region Ejercicio 13 - ¿Es un palindromo?
//Ejercicios1a20.N13("baoáb !!@ - ");
#endregion

#region Ejercicio 14 - Factorial recursivo
//Ejercicios1a20.N14(10);
#endregion

#region Ejercicio 15 - ¿Es un numero de Armstrong?
//Ejercicios1a20.N15(153);
//Ejercicios1a20.N15(370);
//Ejercicios1a20.N15(369);
#endregion

#region Ejercicio 16 - ¿Cuantos dias?
//Ejercicios1a20.N16("18/05/2022", "29/05/2022");
//Ejercicios1a20.N16("macisnotcoding", "29/04/2022");
//Ejercicios1a20.N16("18/5/2022", "29/04/2022");
//Ejercicios1a20.N16("29/05/2022", "04/01/2022");
#endregion

#region Ejercicio 17 - En mayuscula
//Ejercicios1a20.N17("en la granja de pepito");
//Ejercicios1a20.N17("¿hola qué tal estás?");
//Ejercicios1a20.N17("¿hola      qué tal estás?");
//Ejercicios1a20.N17("El niño ñoño
#endregion

#region Ejercicio 18 - La carrera de obstaculos
//Ejercicios1a20.N18([AccionAtleta.run, AccionAtleta.jump, AccionAtleta.run, AccionAtleta.jump, AccionAtleta.run], "_|_|_");
//Ejercicios1a20.N18([AccionAtleta.run, AccionAtleta.run, AccionAtleta.run, AccionAtleta.jump, AccionAtleta.run], "_|_|_");
//Ejercicios1a20.N18([AccionAtleta.run, AccionAtleta.run, AccionAtleta.jump, AccionAtleta.jump, AccionAtleta.run], "_|_|_");
//Ejercicios1a20.N18([AccionAtleta.run, AccionAtleta.run, AccionAtleta.jump, AccionAtleta.jump, AccionAtleta.run], "_|_|_|_");
//Ejercicios1a20.N18([AccionAtleta.run, AccionAtleta.jump, AccionAtleta.run, AccionAtleta.jump], "_|_|_");
//Ejercicios1a20.N18([AccionAtleta.run, AccionAtleta.jump, AccionAtleta.run, AccionAtleta.jump, AccionAtleta.run, AccionAtleta.jump, AccionAtleta.run], "_|_|_");
//Ejercicios1a20.N18([AccionAtleta.jump, AccionAtleta.jump, AccionAtleta.jump, AccionAtleta.jump, AccionAtleta.jump], "|||||");
//Ejercicios1a20.N18([AccionAtleta.jump, AccionAtleta.jump, AccionAtleta.jump, AccionAtleta.jump, AccionAtleta.jump], "||?||");
//Ejercicios1a20.N18([AccionAtleta.run, AccionAtleta.jump, AccionAtleta.run, AccionAtleta.jump, "aaa"], "_|_|_");
#endregion

#region Ejercicio 19 - Tres en raya
//Ejercicios1a20.N19(new TresEnRayaValor[,]
//        {
//            { TresEnRayaValor.X, TresEnRayaValor.O, TresEnRayaValor.X },
//            { TresEnRayaValor.O, TresEnRayaValor.X, TresEnRayaValor.O },
//            { TresEnRayaValor.O, TresEnRayaValor.O, TresEnRayaValor.X }
//        });
//Ejercicios1a20.N19(new TresEnRayaValor[,]
//        {
//            { TresEnRayaValor.VACIO, TresEnRayaValor.O, TresEnRayaValor.X },
//            { TresEnRayaValor.VACIO, TresEnRayaValor.X, TresEnRayaValor.O },
//            { TresEnRayaValor.VACIO, TresEnRayaValor.O, TresEnRayaValor.X }
//        });
//Ejercicios1a20.N19(new TresEnRayaValor[,]
//        {
//            { TresEnRayaValor.O, TresEnRayaValor.O, TresEnRayaValor.O },
//            { TresEnRayaValor.O, TresEnRayaValor.X, TresEnRayaValor.X },
//            { TresEnRayaValor.O, TresEnRayaValor.X, TresEnRayaValor.X }
//        });
//Ejercicios1a20.N19(new TresEnRayaValor[,]
//        {
//            { TresEnRayaValor.X, TresEnRayaValor.O, TresEnRayaValor.X },
//            { TresEnRayaValor.X, TresEnRayaValor.X, TresEnRayaValor.O },
//            { TresEnRayaValor.X, TresEnRayaValor.X, TresEnRayaValor.X }
//        });
#endregion

#region Ejercicio 20 - Conversor de tiempo
//Ejercicios1a20.N20(0, 0, 0, 10);
//Ejercicios1a20.N20(2, 5, -45, 10);
//Ejercicios1a20.N20(2000000000, 5, 45, 10);
#endregion

#region Ejercicio 21 - Parando el tiempo
//Task tarea1 = Ejercicios21a40.N21(5, 2, 10);
//Task tarea2 = Ejercicios21a40.N21(1, 3, 5);
//await Task.WhenAll(tarea1, tarea2);  // Espera a que todas las tareas finalicen antes de parar el programa
#endregion

#region Ejercicio 22 - Calculadora .txt
//Ejercicios21a40.N22();
#endregion

#region Ejercicio 23 - Conjuntos
//Ejercicios21a40.N23([1, 2, 3, 3, 4], [2, 2, 3, 3, 4, 6], true);
//Ejercicios21a40.N23([1, 2, 3, 3, 4], [2, 2, 3, 3, 4, 6], false);
#endregion

#region Ejercicio 24 - Maximo Comun Divisor y Minimo Comun Multiplo
//Ejercicios21a40.N24(56, 180);
#endregion

#region Ejercicio 25 - Iteration master
//Ejercicios21a40.N25();
#endregion

#region Ejercicio 26 - Piedra, Papel, Tijera
//Ejercicios21a40.N26([(PiedraPapelTijeras.Piedra, PiedraPapelTijeras.Piedra)]);
//Ejercicios21a40.N26([(PiedraPapelTijeras.Piedra, PiedraPapelTijeras.Tijeras)]);
//Ejercicios21a40.N26([(PiedraPapelTijeras.Papel, PiedraPapelTijeras.Tijeras)]);
//Ejercicios21a40.N26([
//    (PiedraPapelTijeras.Piedra, PiedraPapelTijeras.Piedra),
//    (PiedraPapelTijeras.Tijeras, PiedraPapelTijeras.Tijeras),
//    (PiedraPapelTijeras.Papel, PiedraPapelTijeras.Papel)
//]);
//Ejercicios21a40.N26([
//    (PiedraPapelTijeras.Piedra, PiedraPapelTijeras.Tijeras),
//    (PiedraPapelTijeras.Tijeras, PiedraPapelTijeras.Papel),
//    (PiedraPapelTijeras.Tijeras, PiedraPapelTijeras.Piedra)
//]); 
//Ejercicios21a40.N26([
//    (PiedraPapelTijeras.Piedra, PiedraPapelTijeras.Papel),
//    (PiedraPapelTijeras.Tijeras, PiedraPapelTijeras.Piedra),
//    (PiedraPapelTijeras.Papel, PiedraPapelTijeras.Tijeras)
//]);
#endregion

#region Ejercicio 27 - Dibujando poligonos
//Ejercicios21a40.N27(10, TipoFigura.CUADRADO);
//Ejercicios21a40.N27(10, TipoFigura.TRIANGULO);
//Ejercicios21a40.N27(5, TipoFigura.CIRCULO);
#endregion

#region Ejercicio 28 - Vectores ortogonales
//Ejercicios21a40.N28([1, 2], [2, 1]);
//Ejercicios21a40.N28([2, 1], [-1, 2]);
//Ejercicios21a40.N28([2, 1, 3], [-1, 2]);
//Ejercicios21a40.N28([2, 1, 3], [3, 4, 8]);
#endregion

#region Ejercicio 29 - Maquina expendedora
//Ejercicios21a40.N29(new(){ Monedas.CINCO, Monedas.CINCO, Monedas.DIEZ, Monedas.DIEZ, Monedas.DIEZ, Monedas.CINCO }, 1);
//Ejercicios21a40.N29(new() { Monedas.CINCO, Monedas.CINCO, Monedas.DIEZ, Monedas.DIEZ, Monedas.DIEZ, Monedas.CINCO }, 3);
//Ejercicios21a40.N29(new() { Monedas.CINCO, Monedas.CINCO, Monedas.DIEZ, Monedas.DIEZ, Monedas.DIEZ, Monedas.CINCO, Monedas.CINCUENTA }, 1);
//Ejercicios21a40.N29(new() { Monedas.DOSCIENTOS }, 5);
#endregion

#region Ejercicio 30 - Ordena la lista
Ejercicios21a40.N30([4, 6, 1, 8, 2], true);
Ejercicios21a40.N30([4, 6, 1, 8, 2], false);
#endregion