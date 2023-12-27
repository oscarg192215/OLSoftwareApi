

INSERT INTO LenguajesProgramacion (nombre_lenguaje, descripcion_lenguaje) VALUES
    ('JavaScript', 'Lenguaje de programaci�n para el desarrollo web.'),
    ('Python', 'Lenguaje de programaci�n de prop�sito general.'),
    ('Java', 'Lenguaje de programaci�n orientado a objetos.'),
    ('C#', 'Lenguaje de programaci�n desarrollado por Microsoft.'),
    ('C++', 'Extensi�n del lenguaje C con caracter�sticas de programaci�n orientada a objetos.'),
    ('TypeScript', 'Lenguaje de programaci�n tipado y basado en JavaScript.'),
    ('PHP', 'Lenguaje de programaci�n dise�ado para el desarrollo web.'),
    ('C', 'Lenguaje de programaci�n de bajo nivel.'),
    ('Ruby', 'Lenguaje de programaci�n din�mico y orientado a objetos.'),
    ('Swift', 'Lenguaje de programaci�n para el desarrollo de aplicaciones en iOS.'),
    ('Kotlin', 'Lenguaje de programaci�n interoperable con Java.'),
    ('Rust', 'Lenguaje de programaci�n de sistemas enfocado en la seguridad y el rendimiento.'),
    ('Go', 'Lenguaje de programaci�n desarrollado por Google.'),
    ('SQL', 'Lenguaje de consulta estructurada para bases de datos.'),
    ('Objective-C', 'Lenguaje de programaci�n utilizado en el desarrollo de aplicaciones para iOS.'),
    ('Shell', 'Lenguaje de script para la automatizaci�n de tareas en sistemas operativos.'),
    ('Scala', 'Lenguaje de programaci�n que combina programaci�n orientada a objetos y funcional.'),
    ('R', 'Lenguaje de programaci�n estad�stica y entorno de software.'),
    ('Matlab', 'Lenguaje de programaci�n utilizado en matem�ticas y simulaciones.'),
    ('Groovy', 'Lenguaje de programaci�n din�mico para la plataforma Java.');

INSERT INTO EstadosPruebaAspirante (nombre_estado, descripcion_estado) VALUES
    ('Registrada', 'La prueba ha sido registrada pero no ha comenzado.'),
    ('En Proceso', 'La prueba est� en curso.'),
    ('Terminada', 'La prueba ha sido completada con �xito.'),
    ('Anulada', 'La prueba ha sido cancelada o anulada.');
	
INSERT INTO NivelesConocimiento (nombre_nivel, descripcion_nivel) VALUES
    ('Junior', 'Nivel b�sico con poca experiencia.'),
    ('Middle', 'Nivel intermedio con experiencia moderada.'),
    ('Senior', 'Nivel avanzado con experiencia extensa.');

INSERT INTO TiposPruebas (nombre_tipo_prueba, descripcion_tipo_prueba) VALUES
    ('T�cnica', 'Prueba que eval�a conocimientos te�ricos y habilidades t�cnicas.'),
    ('Pr�ctica', 'Prueba que eval�a habilidades pr�cticas y capacidad de resoluci�n de problemas.');
	
	
-- Preguntas para el lenguaje de programaci�n JavaScript 
INSERT INTO Preguntas (contenido_pregunta, id_lenguaje_programacion, id_nivel_conocimiento) VALUES
    -- Preguntas para Junior
    ('�C�mo se declara una variable en JavaScript?', 1, 1),
    ('Explique el concepto de un bucle "for" en JavaScript.', 1, 1),
    ('Hable sobre la diferencia entre "==" y "===".', 1, 1),
    
    -- Preguntas para Middle
    ('Explique el concepto de closures en JavaScript y proporcione un ejemplo.', 1, 2),
    ('�Qu� es el "hoisting" y c�mo afecta a las variables en JavaScript?', 1, 2),
    ('Hable sobre el uso de promesas y "async/await".', 1, 2),
    
    -- Preguntas para Senior
    ('Explique c�mo funcionan los prototipos en JavaScript.', 1, 3),
    ('Hable sobre la manipulaci�n del DOM en JavaScript.', 1, 3),
    ('�C�mo se maneja la asincron�a en JavaScript sin utilizar promesas ni "async/await"?', 1, 3);
	
-- Preguntas para el lenguaje de programaci�n Python
INSERT INTO Preguntas (contenido_pregunta, id_lenguaje_programacion, id_nivel_conocimiento) VALUES
    -- Preguntas para Junior
    ('Explique la diferencia entre una lista y una tupla en Python.', 2, 1),
    ('�C�mo se declara una funci�n en Python?', 2, 1),
    ('Hable sobre el concepto de "indentaci�n" en Python.', 2, 1),
    
    -- Preguntas para Middle
    ('Explique el uso de decoradores en Python.', 2, 2),
    ('�C�mo manejar�a las excepciones en Python?', 2, 2),
    ('Hable sobre la programaci�n orientada a objetos en Python.', 2, 2),
    
    -- Preguntas para Senior
    ('Explique el concepto de generadores en Python y proporcione un ejemplo.', 2, 3),
    ('Hable sobre el manejo de archivos en Python.', 2, 3),
    ('�C�mo se implementa la concurrencia en Python?', 2, 3);


-- Preguntas para el lenguaje de programaci�n Java 
INSERT INTO Preguntas (contenido_pregunta, id_lenguaje_programacion, id_nivel_conocimiento) VALUES
    -- Preguntas para Junior
    ('�Qu� es un bucle y c�mo se utiliza en Java?', 3, 1),
    ('Explique el concepto de variables en Java y proporcione ejemplos.', 3, 1),
    ('Hable sobre el manejo de strings y concatenaci�n en Java.', 3, 1),
    
    -- Preguntas para Middle
    ('Explique el polimorfismo en Java y proporcione un ejemplo.', 3, 2),
    ('�C�mo funciona la concurrencia en Java y cu�ndo usar hilos?', 3, 2),
    ('Hable sobre las expresiones lambda en Java 8.', 3, 2),
    
    -- Preguntas para Senior
    ('�C�mo se implementa el patr�n de dise�o MVC en aplicaciones Java?', 3, 3),
    ('Explique el manejo avanzado de excepciones en Java y proporcione ejemplos.', 3, 3),
    ('Hable sobre el uso de streams y programaci�n funcional en Java.', 3, 3);


-- Preguntas para el lenguaje de programaci�n C# 
INSERT INTO Preguntas (contenido_pregunta, id_lenguaje_programacion, id_nivel_conocimiento) VALUES
    -- Preguntas para Junior
    ('Explique el concepto de variables en C# y proporcione ejemplos.', 4, 1),
    ('�Qu� es una condici�n "if" y c�mo se usa en C#?', 4, 1),
    ('Hable sobre la estructura de un bucle "for" en C#.', 4, 1),
    
    -- Preguntas para Middle
    ('Explique el concepto de herencia en C# y proporcione un ejemplo.', 4, 2),
    ('�C�mo manejar�a la concurrencia en C# y cu�ndo usar hilos?', 4, 2),
    ('Hable sobre el uso de LINQ en C#.', 4, 2),
    
    -- Preguntas para Senior
    ('�C�mo se implementa el manejo avanzado de excepciones en C#?', 4, 3),
    ('Explique el uso de delegados y eventos en C#.', 4, 3),
    ('Hable sobre el manejo de transacciones en aplicaciones C#.', 4, 3);

-- Preguntas para el lenguaje de programaci�n TypeScript 
INSERT INTO Preguntas (contenido_pregunta, id_lenguaje_programacion, id_nivel_conocimiento) VALUES
    -- Preguntas para Junior
    ('Explique la diferencia entre TypeScript y JavaScript.', 6, 1),
    ('�Qu� son los tipos de datos en TypeScript y c�mo se declaran?', 6, 1),
    ('Hable sobre la declaraci�n de variables en TypeScript.', 6, 1),
    
    -- Preguntas para Middle
    ('Explique el concepto de "interfaces" en TypeScript.', 6, 2),
    ('�C�mo funcionan los m�dulos en TypeScript?', 6, 2),
    ('Hable sobre el uso de generics en TypeScript.', 6, 2),
    
    -- Preguntas para Senior
    ('Explique la herencia y la sobrecarga en TypeScript.', 6, 3),
    ('Hable sobre el concepto de "decorators" en TypeScript.', 6, 3),
    ('�C�mo se manejan los tipos de datos complejos en TypeScript?', 6, 3);




