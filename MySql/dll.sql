CREATE DATABASE IF NOT EXISTS CampusLove;
USE CampusLove;

CREATE TABLE IF NOT EXISTS Generos (
    IdGenero INT AUTO_INCREMENT PRIMARY KEY,
    NombreGenero VARCHAR(20) NOT NULL UNIQUE
) ENGINE=InnoDB;

CREATE TABLE IF NOT EXISTS Carreras (
    IdCarrera INT AUTO_INCREMENT PRIMARY KEY,
    NombreCarrera VARCHAR(50) NOT NULL UNIQUE
) ENGINE=InnoDB;

CREATE TABLE IF NOT EXISTS Usuarios (
    IdUsuario INT AUTO_INCREMENT PRIMARY KEY,
    Nombre VARCHAR(50) NOT NULL,
    Edad INT NOT NULL CHECK (Edad >= 18 AND Edad <= 100),
    IdGenero INT NOT NULL,
    IdCarrera INT NOT NULL,
    FrasePerfil VARCHAR(200) NOT NULL,
    NombreUsuario VARCHAR(15) NOT NULL UNIQUE,
    Contrasena VARCHAR(100) NOT NULL,
    CreditosDiarios INT DEFAULT 10,
    FechaUltimaInteraccion DATETIME DEFAULT NOW(),
    FechaRegistro DATETIME DEFAULT NOW(),
    Activo BOOLEAN DEFAULT TRUE,
    FOREIGN KEY (IdGenero) REFERENCES Generos(IdGenero),
    FOREIGN KEY (IdCarrera) REFERENCES Carreras(IdCarrera)
) ENGINE=InnoDB;

CREATE TABLE IF NOT EXISTS Intereses (
    IdInteres INT AUTO_INCREMENT PRIMARY KEY,
    NombreInteres VARCHAR(30) NOT NULL UNIQUE
) ENGINE=InnoDB;

CREATE TABLE IF NOT EXISTS UsuariosIntereses (
    IdUsuarioInteres INT AUTO_INCREMENT PRIMARY KEY,
    IdUsuario INT NOT NULL,
    IdInteres INT NOT NULL,
    FechaRegistro DATETIME DEFAULT NOW(),
    FOREIGN KEY (IdUsuario) REFERENCES Usuarios(IdUsuario) ON DELETE CASCADE,
    FOREIGN KEY (IdInteres) REFERENCES Intereses(IdInteres),
    UNIQUE KEY unique_usuario_interes (IdUsuario, IdInteres)
) ENGINE=InnoDB;

CREATE TABLE IF NOT EXISTS TiposInteracciones (
    IdTipoInteraccion INT AUTO_INCREMENT PRIMARY KEY,
    NombreTipo VARCHAR(10) NOT NULL UNIQUE
) ENGINE=InnoDB;

CREATE TABLE IF NOT EXISTS Interacciones (
    IdInteraccion INT AUTO_INCREMENT PRIMARY KEY,
    IdUsuarioOrigen INT NOT NULL,
    IdUsuarioDestino INT NOT NULL,
    IdTipoInteraccion INT NOT NULL,
    FechaInteraccion DATETIME DEFAULT NOW(),
    FOREIGN KEY (IdUsuarioOrigen) REFERENCES Usuarios(IdUsuario),
    FOREIGN KEY (IdUsuarioDestino) REFERENCES Usuarios(IdUsuario),
    FOREIGN KEY (IdTipoInteraccion) REFERENCES TiposInteracciones(IdTipoInteraccion),
    UNIQUE KEY unique_interaccion_diaria (IdUsuarioOrigen, IdUsuarioDestino, DATE(FechaInteraccion))
) ENGINE=InnoDB;

CREATE TABLE IF NOT EXISTS Matches (
    IdMatch INT AUTO_INCREMENT PRIMARY KEY,
    IdUsuario1 INT NOT NULL,
    IdUsuario2 INT NOT NULL,
    FechaMatch DATETIME DEFAULT NOW(),
    Activo BOOLEAN DEFAULT TRUE,
    FOREIGN KEY (IdUsuario1) REFERENCES Usuarios(IdUsuario),
    FOREIGN KEY (IdUsuario2) REFERENCES Usuarios(IdUsuario),
    UNIQUE KEY unique_match_pair (IdUsuario1, IdUsuario2),
    CHECK (IdUsuario1 < IdUsuario2)
) ENGINE=InnoDB;
