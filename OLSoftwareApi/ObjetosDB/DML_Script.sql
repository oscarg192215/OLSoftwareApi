

INSERT INTO LenguajesProgramacion (nombre_lenguaje, descripcion_lenguaje) VALUES
    ('JavaScript', 'Lenguaje de programación para el desarrollo web.'),
    ('Python', 'Lenguaje de programación de propósito general.'),
    ('Java', 'Lenguaje de programación orientado a objetos.'),
    ('C#', 'Lenguaje de programación desarrollado por Microsoft.'),
    ('C++', 'Extensión del lenguaje C con características de programación orientada a objetos.'),
    ('TypeScript', 'Lenguaje de programación tipado y basado en JavaScript.'),
    ('PHP', 'Lenguaje de programación diseñado para el desarrollo web.'),
    ('C', 'Lenguaje de programación de bajo nivel.'),
    ('Ruby', 'Lenguaje de programación dinámico y orientado a objetos.'),
    ('Swift', 'Lenguaje de programación para el desarrollo de aplicaciones en iOS.'),
    ('Kotlin', 'Lenguaje de programación interoperable con Java.'),
    ('Rust', 'Lenguaje de programación de sistemas enfocado en la seguridad y el rendimiento.'),
    ('Go', 'Lenguaje de programación desarrollado por Google.'),
    ('SQL', 'Lenguaje de consulta estructurada para bases de datos.'),
    ('Objective-C', 'Lenguaje de programación utilizado en el desarrollo de aplicaciones para iOS.'),
    ('Shell', 'Lenguaje de script para la automatización de tareas en sistemas operativos.'),
    ('Scala', 'Lenguaje de programación que combina programación orientada a objetos y funcional.'),
    ('R', 'Lenguaje de programación estadística y entorno de software.'),
    ('Matlab', 'Lenguaje de programación utilizado en matemáticas y simulaciones.'),
    ('Groovy', 'Lenguaje de programación dinámico para la plataforma Java.');

INSERT INTO EstadosPruebaAspirante (nombre_estado, descripcion_estado) VALUES
    ('Registrada', 'La prueba ha sido registrada pero no ha comenzado.'),
    ('En Proceso', 'La prueba está en curso.'),
    ('Terminada', 'La prueba ha sido completada con éxito.'),
    ('Anulada', 'La prueba ha sido cancelada o anulada.');
	
INSERT INTO NivelesConocimiento (nombre_nivel, descripcion_nivel) VALUES
    ('Junior', 'Nivel básico con poca experiencia.'),
    ('Middle', 'Nivel intermedio con experiencia moderada.'),
    ('Senior', 'Nivel avanzado con experiencia extensa.');

INSERT INTO TiposPruebas (nombre_tipo_prueba, descripcion_tipo_prueba) VALUES
    ('Técnica', 'Prueba que evalúa conocimientos teóricos y habilidades técnicas.'),
    ('Práctica', 'Prueba que evalúa habilidades prácticas y capacidad de resolución de problemas.');
	
	
-- Preguntas para el lenguaje de programación JavaScript 
INSERT INTO Preguntas (contenido_pregunta, id_lenguaje_programacion, id_nivel_conocimiento) VALUES
    -- Preguntas para Junior
    ('¿Cómo se declara una variable en JavaScript?', 1, 1),
    ('Explique el concepto de un bucle "for" en JavaScript.', 1, 1),
    ('Hable sobre la diferencia entre "==" y "===".', 1, 1),
    
    -- Preguntas para Middle
    ('Explique el concepto de closures en JavaScript y proporcione un ejemplo.', 1, 2),
    ('¿Qué es el "hoisting" y cómo afecta a las variables en JavaScript?', 1, 2),
    ('Hable sobre el uso de promesas y "async/await".', 1, 2),
    
    -- Preguntas para Senior
    ('Explique cómo funcionan los prototipos en JavaScript.', 1, 3),
    ('Hable sobre la manipulación del DOM en JavaScript.', 1, 3),
    ('¿Cómo se maneja la asincronía en JavaScript sin utilizar promesas ni "async/await"?', 1, 3);
	
-- Preguntas para el lenguaje de programación Python
INSERT INTO Preguntas (contenido_pregunta, id_lenguaje_programacion, id_nivel_conocimiento) VALUES
    -- Preguntas para Junior
    ('Explique la diferencia entre una lista y una tupla en Python.', 2, 1),
    ('¿Cómo se declara una función en Python?', 2, 1),
    ('Hable sobre el concepto de "indentación" en Python.', 2, 1),
    
    -- Preguntas para Middle
    ('Explique el uso de decoradores en Python.', 2, 2),
    ('¿Cómo manejaría las excepciones en Python?', 2, 2),
    ('Hable sobre la programación orientada a objetos en Python.', 2, 2),
    
    -- Preguntas para Senior
    ('Explique el concepto de generadores en Python y proporcione un ejemplo.', 2, 3),
    ('Hable sobre el manejo de archivos en Python.', 2, 3),
    ('¿Cómo se implementa la concurrencia en Python?', 2, 3);


-- Preguntas para el lenguaje de programación Java 
INSERT INTO Preguntas (contenido_pregunta, id_lenguaje_programacion, id_nivel_conocimiento) VALUES
    -- Preguntas para Junior
    ('¿Qué es un bucle y cómo se utiliza en Java?', 3, 1),
    ('Explique el concepto de variables en Java y proporcione ejemplos.', 3, 1),
    ('Hable sobre el manejo de strings y concatenación en Java.', 3, 1),
    
    -- Preguntas para Middle
    ('Explique el polimorfismo en Java y proporcione un ejemplo.', 3, 2),
    ('¿Cómo funciona la concurrencia en Java y cuándo usar hilos?', 3, 2),
    ('Hable sobre las expresiones lambda en Java 8.', 3, 2),
    
    -- Preguntas para Senior
    ('¿Cómo se implementa el patrón de diseño MVC en aplicaciones Java?', 3, 3),
    ('Explique el manejo avanzado de excepciones en Java y proporcione ejemplos.', 3, 3),
    ('Hable sobre el uso de streams y programación funcional en Java.', 3, 3);


-- Preguntas para el lenguaje de programación C# 
INSERT INTO Preguntas (contenido_pregunta, id_lenguaje_programacion, id_nivel_conocimiento) VALUES
    -- Preguntas para Junior
    ('Explique el concepto de variables en C# y proporcione ejemplos.', 4, 1),
    ('¿Qué es una condición "if" y cómo se usa en C#?', 4, 1),
    ('Hable sobre la estructura de un bucle "for" en C#.', 4, 1),
    
    -- Preguntas para Middle
    ('Explique el concepto de herencia en C# y proporcione un ejemplo.', 4, 2),
    ('¿Cómo manejaría la concurrencia en C# y cuándo usar hilos?', 4, 2),
    ('Hable sobre el uso de LINQ en C#.', 4, 2),
    
    -- Preguntas para Senior
    ('¿Cómo se implementa el manejo avanzado de excepciones en C#?', 4, 3),
    ('Explique el uso de delegados y eventos en C#.', 4, 3),
    ('Hable sobre el manejo de transacciones en aplicaciones C#.', 4, 3);

-- Preguntas para el lenguaje de programación TypeScript 
INSERT INTO Preguntas (contenido_pregunta, id_lenguaje_programacion, id_nivel_conocimiento) VALUES
    -- Preguntas para Junior
    ('Explique la diferencia entre TypeScript y JavaScript.', 6, 1),
    ('¿Qué son los tipos de datos en TypeScript y cómo se declaran?', 6, 1),
    ('Hable sobre la declaración de variables en TypeScript.', 6, 1),
    
    -- Preguntas para Middle
    ('Explique el concepto de "interfaces" en TypeScript.', 6, 2),
    ('¿Cómo funcionan los módulos en TypeScript?', 6, 2),
    ('Hable sobre el uso de generics en TypeScript.', 6, 2),
    
    -- Preguntas para Senior
    ('Explique la herencia y la sobrecarga en TypeScript.', 6, 3),
    ('Hable sobre el concepto de "decorators" en TypeScript.', 6, 3),
    ('¿Cómo se manejan los tipos de datos complejos en TypeScript?', 6, 3);




