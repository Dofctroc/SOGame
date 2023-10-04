#include <mysql.h>
#include <string.h>
#include <stdlib.h>
#include <stdio.h>

int main() {
	MYSQL *conn;
	int err;
	MYSQL_RES *resultado;
	MYSQL_ROW row;
	
	
	conn = mysql_init(NULL);
	if (conn==NULL) {
		printf ("Error al crear la conexion: %u %s\n", 
				mysql_errno(conn), mysql_error(conn));
		exit (1);
	}
	conn = mysql_real_connect (conn, "localhost","root", "mysql", "Juego", 0, NULL, 0);
	if (conn==NULL){
		printf ("Error al inicializar la conexion: %u %s\n", 
				mysql_errno(conn), mysql_error(conn));
		exit (1);
	}
	
	/*
	mysql_query(conn,"SELECT Partida.ID,Partida.ciudad FROM Jugador,Partida,Posicion "
	"WHERE Jugador.ID = 'Asier' "
	"AND Participacion.ID_Jugador = Jugador.ID "
	"AND Participacion.ID_Partida = Partida.ID "
	"AND (Participacion.posicion = 1 OR Participacion.posicion = 1");
	
	mysql_query(conn,"SELECT Participacion.ID_Partida FROM Jugador,Posicion "
	"WHERE Jugador.nombre = 'Asier' "
	"AND Jugador.ID = Participacion.ID_Jugador "
	"AND Participacion.ID_Partida IN (SELECT Participacion.ID_Partida FROM Jugador,Participacion "
	"WHERE Jugador.nombre = 'Julia' "
	"AND Jugador.ID = Participacion.ID_Jugador)");
	*/
	
	mysql_query(conn, "USE Juego;");
	
	char jugador[20];
	// Pregunto los nombre de los dos jugadores
	printf ("Dame el nombre de un jugador: \n"); 
	scanf ("%s", jugador);
	
	char consulta [80];
	strcpy (consulta,"SELECT SUM(PartidasJugadores.puntuacion) FROM Jugador,Partida,PartidasJugadores WHERE Jugador.userName = '");
	strcat (consulta, jugador);
	strcat (consulta,"' AND Partida.ID = PartidasJugadores.ID_Partida AND PartidasJugadores.ID_jugador = Jugador.ID");
	mysql_query (conn, consulta);
	
	resultado = mysql_store_result (conn);
	row = mysql_fetch_row (resultado);
	
	if (row == NULL)
		printf ("No se han obtenido datos en la consulta\n");
	else
	{
		while (row !=NULL) {
			// la columna 0 contiene el nombre del jugador
			printf ("%s\n", row[0]);
			// obtenemos la siguiente fila
			row = mysql_fetch_row (resultado);
		}
	}
	
	mysql_close (conn);
	exit(0);
}

