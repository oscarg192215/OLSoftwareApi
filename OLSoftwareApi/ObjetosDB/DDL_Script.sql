CREATE TABLE LenguajesProgramacion (
    id_lenguaje INT PRIMARY KEY IDENTITY(1,1),
    nombre_lenguaje VARCHAR(50),
	descripcion_lenguaje TEXT
);

CREATE TABLE EstadosPruebaAspirante (
    id_estado_prueba_aspirante INT PRIMARY KEY IDENTITY(1,1),
    nombre_estado VARCHAR(50),
    descripcion_estado TEXT
);

CREATE TABLE TiposPruebas (
    id_tipo_prueba INT PRIMARY KEY IDENTITY(1,1),
    nombre_tipo_prueba VARCHAR(255),
    descripcion_tipo_prueba TEXT VARCHAR(50)
);

CREATE TABLE NivelesConocimiento (
    id_nivel INT PRIMARY KEY IDENTITY(1,1),
    nombre_nivel VARCHAR(50),
    descripcion_nivel TEXT
);

CREATE TABLE Preguntas (
    id_pregunta INT PRIMARY KEY IDENTITY(1,1),
    contenido_pregunta TEXT,
	id_lenguaje INT,
    id_nivel INT,    
    FOREIGN KEY (id_nivel) REFERENCES NivelesConocimiento(id_nivel),
    FOREIGN KEY (id_lenguaje) REFERENCES LenguajesProgramacion(id_lenguaje)
);

CREATE TABLE Aspirantes (
    id_aspirante INT PRIMARY KEY IDENTITY(1,1),
	id_login nvarchar(450) ,
	nombre_aspirante varchar(50) ,
	apellido_aspirante varchar(50) ,
	documento_aspirante varchar(50) ,
	fecha_nacimiento_aspirante varchar(10) ,
	celular_aspirante varchar(10) ,
	email_aspirante varchar(50) ,
	direccion_aspirante nvarchar(max) ,
	pais_aspirante varchar(50) ,
	ciudad_aspirante varchar(50) 
);

CREATE TABLE AspiranteLogin (
    id_aspirante_login INT PRIMARY KEY IDENTITY(1,1),
    id_login INT,
    id_aspirante INT,
	FOREIGN KEY (id_login) REFERENCES AspNetUsers(Id)
    FOREIGN KEY (id_aspirante) REFERENCES Aspirantes(id_aspirante)
);



CREATE TABLE Pruebas (
    id_prueba INT PRIMARY KEY IDENTITY(1,1),
    nombre_prueba VARCHAR(255),
    id_tipo_prueba INT,
	id_lenguaje INT,
	id_nivel INT, 
	cantidad_preguntas INT NULL,
	id_estado_prueba_aspirante INT NULL,
    FOREIGN KEY (id_nivel) REFERENCES NivelesConocimiento(id_nivel),
    FOREIGN KEY (id_lenguaje) REFERENCES LenguajesProgramacion(id_lenguaje),
	FOREIGN KEY (id_tipo_prueba) REFERENCES TiposPruebas(id_tipo_prueba),
	FOREIGN KEY (id_estado_prueba_aspirante) REFERENCES EstadosPruebaAspirante(id_estado_prueba_aspirante)
);

CREATE TABLE PruebasPreguntas (
    id_prueba_pregunta INT PRIMARY KEY IDENTITY(1,1),
    id_prueba INT,
	id_pregunta INT,
	FOREIGN KEY (id_prueba) REFERENCES Pruebas(id_prueba),
	FOREIGN KEY (id_pregunta) REFERENCES Preguntas(id_pregunta)
);



CREATE TABLE PruebaAspirante (
    id_prueba_aspirante INT PRIMARY KEY IDENTITY(1,1),
    id_prueba INT,
    id_aspirante INT,	
	fecha_inicio DATETIME,
	fecha_finalizacion DATETIME,
    FOREIGN KEY (id_prueba) REFERENCES Pruebas(id_prueba),
    FOREIGN KEY (id_aspirante) REFERENCES Aspirantes(id_aspirante)
);

CREATE TABLE RespuestaPruebaAspirante (
    id_respuesta_prueba_aspirante INT PRIMARY KEY IDENTITY(1,1),
    id_prueba INT,
    id_aspirante INT,
	respuesta_aspirante TEXT,
	id_estado_prueba_aspirante INT ,
    FOREIGN KEY (id_prueba) REFERENCES Pruebas(id_prueba),
    FOREIGN KEY (id_aspirante) REFERENCES Aspirantes(id_aspirante),
	FOREIGN KEY (id_estado_prueba_aspirante) REFERENCES EstadosPruebaAspirante(id_estado_prueba_aspirante)
);

create procedure ObtenerDetalle
@id int 
as
begin
SELECT
    u.UserName UserName,
    a.nombre_aspirante NombreAspirante,
    a.apellido_aspirante ApellidoAspirante,
    a.fecha_nacimiento_aspirante FechaNacimiento,
    a.celular_aspirante Celular,
    a.email_aspirante Email,
    a.direccion_aspirante Direccion,
    a.pais_aspirante Pais,
    a.ciudad_aspirante Ciudad,
    a.documento_aspirante Documento,
    p.nombre_prueba NombrePrueba,
    p.cantidad_preguntas CantidadPreguntas,
    pa.fecha_inicio FechaInicio,
    pa.fecha_finalizacion FechaFinalizacion,
    pr.contenido_pregunta ContenidoPreguntas
FROM
    Aspirantes a
JOIN PruebaAspirante pa ON a.id_aspirante = pa.id_aspirante
JOIN Pruebas p ON pa.id_prueba = p.id_prueba
JOIN AspNetUsers u ON a.id_login = u.Id
JOIN NivelesConocimiento nc ON p.id_nivel = nc.id_nivel
JOIN LenguajesProgramacion lp ON p.id_lenguaje = lp.id_lenguaje
JOIN (
    SELECT
        pp.id_prueba,
        pr.contenido_pregunta
    FROM
        PruebasPreguntas pp
    JOIN Pruebas p ON pp.id_prueba = p.id_prueba
    JOIN Preguntas pr ON pp.id_pregunta = pr.id_pregunta
) pr ON p.id_prueba = pr.id_prueba
WHERE pa.id_prueba_aspirante = @id
END
