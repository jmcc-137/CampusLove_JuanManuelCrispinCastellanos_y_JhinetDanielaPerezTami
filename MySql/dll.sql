CREATE DATABASE IF NOT EXISTS CampusLove;
USE CampusLove;

-- Tabla de géneros
CREATE TABLE IF NOT EXISTS GENEROS (
    id_genero INT AUTO_INCREMENT PRIMARY KEY,
    nombre_genero VARCHAR(20) NOT NULL UNIQUE
) ENGINE=InnoDB;

-- Tabla de carreras
CREATE TABLE IF NOT EXISTS CARRERAS (
    id_carrera INT AUTO_INCREMENT PRIMARY KEY,
    nombre_carrera VARCHAR(50) NOT NULL UNIQUE
) ENGINE=InnoDB;

-- Tabla de usuarios principal
CREATE TABLE IF NOT EXISTS USUARIOS (
    id_usuario INT AUTO_INCREMENT PRIMARY KEY,
    nombre VARCHAR(50) NOT NULL,
    edad INT NOT NULL CHECK (edad >= 18 AND edad <= 100),
    id_genero INT NOT NULL,
    id_carrera INT NOT NULL,
    frase_perfil VARCHAR(200) NOT NULL,
    nombre_usuario VARCHAR(15) NOT NULL UNIQUE,
    contrasena VARCHAR(100) NOT NULL,
    creditos_diarios INT DEFAULT 10,
    fecha_ultima_interaccion DATETIME DEFAULT NOW(),
    fecha_registro DATETIME DEFAULT NOW(),
    activo BOOLEAN DEFAULT TRUE,
    FOREIGN KEY (id_genero) REFERENCES GENEROS(id_genero),
    FOREIGN KEY (id_carrera) REFERENCES CARRERAS(id_carrera)
) ENGINE=InnoDB;

-- Tabla de intereses
CREATE TABLE IF NOT EXISTS INTERESES (
    id_interes INT AUTO_INCREMENT PRIMARY KEY,
    nombre_interes VARCHAR(30) NOT NULL UNIQUE
) ENGINE=InnoDB;

-- Tabla de relación usuarios-intereses (N:M)
CREATE TABLE IF NOT EXISTS USUARIOS_INTERESES (
    id_usuario_interes INT AUTO_INCREMENT PRIMARY KEY,
    id_usuario INT NOT NULL,
    id_interes INT NOT NULL,
    fecha_registro DATETIME DEFAULT NOW(),
    FOREIGN KEY (id_usuario) REFERENCES USUARIOS(id_usuario) ON DELETE CASCADE,
    FOREIGN KEY (id_interes) REFERENCES INTERESES(id_interes),
    UNIQUE KEY unique_usuario_interes (id_usuario, id_interes)
) ENGINE=InnoDB;

-- Tabla de tipos de interacción
CREATE TABLE IF NOT EXISTS TIPOS_INTERACCION (
    id_tipo_interaccion INT AUTO_INCREMENT PRIMARY KEY,
    nombre_tipo VARCHAR(10) NOT NULL UNIQUE
) ENGINE=InnoDB;

-- Tabla de interacciones
CREATE TABLE IF NOT EXISTS INTERACCIONES (
    id_interaccion INT AUTO_INCREMENT PRIMARY KEY,
    id_usuario_origen INT NOT NULL,
    id_usuario_destino INT NOT NULL,
    id_tipo_interaccion INT NOT NULL,
    fecha_interaccion DATETIME DEFAULT NOW(),
    FOREIGN KEY (id_usuario_origen) REFERENCES USUARIOS(id_usuario),
    FOREIGN KEY (id_usuario_destino) REFERENCES USUARIOS(id_usuario),
    FOREIGN KEY (id_tipo_interaccion) REFERENCES TIPOS_INTERACCION(id_tipo_interaccion),
    UNIQUE KEY unique_interaccion_diaria (id_usuario_origen, id_usuario_destino, DATE(fecha_interaccion))
) ENGINE=InnoDB;

-- Tabla de matches
CREATE TABLE IF NOT EXISTS MATCHES (
    id_match INT AUTO_INCREMENT PRIMARY KEY,
    id_usuario1 INT NOT NULL,
    id_usuario2 INT NOT NULL,
    fecha_match DATETIME DEFAULT NOW(),
    activo BOOLEAN DEFAULT TRUE,
    FOREIGN KEY (id_usuario1) REFERENCES USUARIOS(id_usuario),
    FOREIGN KEY (id_usuario2) REFERENCES USUARIOS(id_usuario),
    UNIQUE KEY unique_match_pair (id_usuario1, id_usuario2),
    CHECK (id_usuario1 < id_usuario2)
) ENGINE=InnoDB;
