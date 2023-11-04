#include <string.h>
#include <unistd.h>
#include <stdlib.h>
#include <sys/types.h>
#include <sys/socket.h>
#include <netinet/in.h>
#include <stdio.h>
#include <pthread.h>

/* Codigos:
	1 - longitud nombre
	2 - bool nombre bonito
	3 - bool alto
	4 - contador */

int contador;
pthread_mutex_t mutex = PTHREAD_MUTEX_INITIALIZER;
int i;
int sockets[100];

int consulta1(char nombre[], char respuesta[])
{
	int longitud = strlen(nombre);
	sprintf (respuesta,"1/%d",longitud);
	return 0;
}

void consulta2(char nombre[], char respuesta[])
{
	// quieren saber si el nombre es bonito
	if((nombre[0]=='M') || (nombre[0]=='S'))
		strcpy (respuesta,"2/SI");
	else
		strcpy (respuesta,"2/NO");
}

void consulta3(char nombre[], float altura, char respuesta[])
{
	if (altura > 1.70)
		sprintf (respuesta, "3/%s: eres alto",nombre);
	else
		sprintf (respuesta, "3/%s: eresbajo",nombre);
}

void *AtenderCliente (void *socket)
{
	int sock_conn;
	int *s;
	s= (int *) socket;
	sock_conn= *s;
	
	char peticion[512];
	char respuesta[512];
	int ret;
	
	int terminar =0;
	// Entramos en un bucle para atender todas las peticiones de este cliente
	//hasta que se desconecte
	while (terminar ==0)
	{
		// Ahora recibimos la petici?n
		ret=read(sock_conn,peticion, sizeof(peticion));
		printf ("Recibido\n");
		
		// Tenemos que a?adirle la marca de fin de string 
		// para que no escriba lo que hay despues en el buffer
		peticion[ret]='\0';
		
		
		printf ("Peticion: %s\n",peticion);
		
		// vamos a ver que quieren
		char *p = strtok( peticion, "/");
		int codigo =  atoi (p);
		// Ya tenemos el c?digo de la petici?n
		char nombre[20];
		
		if ((codigo !=0)&&(codigo != 4))
		{
			p = strtok( NULL, "/");
			
			strcpy (nombre, p);
			// Ya tenemos el nombre
			printf ("Codigo: %d, Nombre: %s\n", codigo, nombre);
		}
		
		if (codigo ==0) //petici?n de desconexi?n
			terminar=1;
		else if (codigo ==1)
		{
			//piden la longitd del nombre
			consulta1(nombre, respuesta);
		}
		else if (codigo ==2)
		{
			consulta2(nombre,respuesta);
		}
		else //quiere saber si es alto
			{
				p = strtok( NULL, "/");
				float altura =  atof (p);
				consulta3(nombre, altura, respuesta);
			}
			
		if (codigo !=0)
			{
				printf ("Respuesta: %s\n", respuesta);
				write (sock_conn,respuesta, strlen(respuesta));
			}
		if ((codigo == 1) || (codigo == 2) || (codigo == 3))
		{
			pthread_mutex_lock(&mutex);		//no me interrumpas
			contador = contador +1;
			pthread_mutex_unlock(&mutex);	//me puedes interrumpir
			
			char notificacion[30];
			sprintf(notificacion,"4/%d",contador);
			int j;
			for (j=0;j<i;j++)
				write(sockets[j],notificacion,strlen(notificacion));
		}
	}
	// Se acabo el servicio para este cliente
	close(sock_conn); 
}

int main(int argc, char *argv[])
{
	int sock_conn, sock_listen;
	struct sockaddr_in serv_adr;
	// INICIALITZACIONS
	// Obrim el socket
	if ((sock_listen = socket(AF_INET, SOCK_STREAM, 0)) < 0)
		printf("Error creant socket");
	// Fem el bind al port
	
	
	memset(&serv_adr, 0, sizeof(serv_adr));// inicialitza a zero serv_addr
	serv_adr.sin_family = AF_INET;
	
	// asocia el socket a cualquiera de las IP de la m?quina. 
	//htonl formatea el numero que recibe al formato necesario
	serv_adr.sin_addr.s_addr = htonl(INADDR_ANY);
	// establecemos el puerto de escucha
	serv_adr.sin_port = htons(9040);
	if (bind(sock_listen, (struct sockaddr *) &serv_adr, sizeof(serv_adr)) < 0)
		printf ("Error al bind");
	
	if (listen(sock_listen, 3) < 0)
		printf("Error en el Listen");
	
	contador = 0;
	pthread_t thread;
	i = 0;
	// Bucle infinito
	for (;;){
		printf ("Escuchando\n");
		
		sock_conn = accept(sock_listen, NULL, NULL);
		printf ("He recibido conexion\n");
		
		sockets[i] =sock_conn;
		//sock_conn es el socket que usaremos para este cliente
		
		// Crear thead y decirle lo que tiene que hacer
		
		pthread_create (&thread, NULL, AtenderCliente, &sockets[i]);
		i=i+1;
	}
}

