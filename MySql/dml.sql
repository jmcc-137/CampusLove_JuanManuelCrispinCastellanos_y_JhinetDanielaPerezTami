INSERT INTO Generos (NombreGenero) VALUES 
('Masculino'), 
('Femenino'), 
('No binario'), 
('Otro');


INSERT INTO Carreras (NombreCarrera) VALUES
('Ingenieria de Sistemas'),
('Diseño Grafico'),
('Psicologia'),
('Medicina'),
('Derecho'),
('Administración');


INSERT INTO Intereses (NombreInteres) VALUES
('Videojuegos'),
('Musica'),
('Arte'),
('Cine'),
('Lectura'),
('Café'),
('Deporte'),
('Series'),
('Debates'),
('Viajes'),
('Finanzas'),
('Ajedrez');


INSERT INTO TiposInteracciones (NombreTipo) VALUES 
('LIKE'), 
('DISLIKE');


INSERT INTO Usuarios (Nombre, Edad, IdGenero, IdCarrera, FrasePerfil, NombreUsuario, Contrasena) VALUES
('Carlos Mendoza', 22, 1, 1, 'Buscando bugs en corazones 💻', 'carlos_m', 'password123'),
('Ana Rodriguez', 21, 2, 2, 'Un match y te diseño el futuro 🎨', 'ana_r', 'password123'),
('Laura Sanchez', 23, 2, 3, 'Te escucho con el corazón 💗', 'laura_s', 'password123'),
('Miguel Torres', 24, 1, 4, 'El mejor remedio: una buena cita 💊', 'miguel_t', 'password123'),
('Sofia Vargas', 22, 2, 5, 'Argumenta tu amor ⚖️', 'sofia_v', 'password123'),
('Diego Morales', 25, 1, 6, 'Invertir en amor, la mejor decisión 💰', 'diego_m', 'password123');


INSERT INTO UsuariosIntereses (IdUsuario, IdInteres) VALUES
(1, 1), (1, 2);


INSERT INTO UsuariosIntereses (IdUsuario, IdInteres) VALUES
(2, 3), (2, 4);


INSERT INTO UsuariosIntereses (IdUsuario, IdInteres) VALUES
(3, 5), (3, 6);


INSERT INTO UsuariosIntereses (IdUsuario, IdInteres) VALUES
(4, 7), (4, 8);


INSERT INTO UsuariosIntereses (IdUsuario, IdInteres) VALUES
(5, 9), (5, 10);


INSERT INTO UsuariosIntereses (IdUsuario, IdInteres) VALUES
(6, 11), (6, 12);